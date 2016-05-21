using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;

namespace FileOrganizer.BL
{
    public class MyQuery
    {
        ArrayList _whereParameters = new ArrayList();
        //ArrayList _whereParameters = null;
        public int _top = -1;
        public string _orderBy = string.Empty;
        string _resultColumns = string.Empty;
        public MyEntity myEntity;
        byte inc = 0;
        public int ParameterCount { get { return _whereParameters.Count; } }

        public MyQuery(MyEntity myEntity)
        {
            this.myEntity = myEntity;
        }
        public void ResetWhereParameters()
        {
            _whereParameters.Clear();
        }
        public void AddWhereParameter(MyParameter wItem)
        {
            _whereParameters.Add(wItem);
        }
        public MyParameter AddWhereParameter(SQLiteParameter param)
        {
            MyParameter my_param = new MyParameter(param.ParameterName, param);
            _whereParameters.Add(my_param);
            return my_param;
        }
        //public MyParameter AddWhereParameter(string columnName, IDataParameter param)
        //{
        //    MyParameter my_param = new MyParameter(columnName, param);
        //    _whereParameters.Add(my_param);
        //    return my_param;
        //}
        public MyParameter AddWhereParameter(SQLiteParameter param, object value)
        {
            MyParameter my_param = new MyParameter(param.ParameterName, param) { Value = value };
            _whereParameters.Add(my_param);
            return my_param;
        }

        public MyParameter AddWhereParameter(String columnName, MyOperand op, SQLiteParameter param, object value)
        {
            MyParameter my_param = new MyParameter(columnName, param) { Operator = op, Value = value };
            _whereParameters.Add(my_param);
            return my_param;
        }


        public void OpenParenthesis()
        {
            _whereParameters.Add("(");
        }

        public void CloseParenthesis()
        {
            _whereParameters.Add(")");
        }
        public void AddConjunction(MyConj conjuction)
        {


            if (conjuction != MyConj.UseDefault)
            {
                if (conjuction == MyConj.And)
                    _whereParameters.Add(" AND ");
                else
                    _whereParameters.Add(" OR ");
            }
        }
        public virtual void AddOrderBy(string column, MyDir direction)
        {
            if (_orderBy.Length > 0)
            {
                _orderBy += ", ";
            }

            _orderBy += column;

            if (direction == MyDir.ASC)
                _orderBy += " ASC";
            else
                _orderBy += " DESC";
        }

        public virtual void AddResultColumn(string columnName)
        {
            if (_resultColumns.Length > 0)
            {
                _resultColumns += ", ";
            }

            _resultColumns += columnName;

            // We don't allow Save() to succeed once they reduce the columns
            //this._entity._canSave = false;
        }


        public bool Load()
        {
            //bool hasColumn = false;
            myEntity.Clear();
            string conjuction = "AND";
            bool selectAll = true;
            StringBuilder query = new StringBuilder(20);

            query.Append("SELECT ");

            //if (this._distinct) query += " DISTINCT ";
            //if (this._top >= 0) query.Append(" TOP " + this._top + " ");

            if (this._resultColumns.Length > 0)
            {
                query.Append(this._resultColumns);
                //hasColumn = true;
                selectAll = false;
            }

            //if (this._countAll)
            //{
            //    if (hasColumn)
            //    {
            //        query += ", ";
            //    }

            //    query += "Count(*)";

            //    if (this._countAllAlias != string.Empty)
            //    {
            //        query += " AS [" + this._countAllAlias + "]";
            //    }

            //    hasColumn = true;
            //    selectAll = false;
            //}

            //if (_aggregateParameters != null && _aggregateParameters.Count > 0)
            //{
            //    bool isFirst = true;

            //    if (hasColumn)
            //    {
            //        query += ", ";
            //    }

            //    AggregateParameter wItem;

            //    foreach (object obj in _aggregateParameters)
            //    {
            //        wItem = obj as AggregateParameter;

            //        if (wItem.IsDirty)
            //        {
            //            if (isFirst)
            //            {
            //                query += GetAggregate(wItem, true);
            //                isFirst = false;
            //            }
            //            else
            //            {
            //                query += ", " + GetAggregate(wItem, true);
            //            }
            //        }
            //    }

            //    selectAll = false;
            //}

            //aggreagate

            if (selectAll)
            {
                query.Append("*");
            }

            query.Append(" FROM " + this.myEntity.QuerySource);

            SQLiteCommand cmd = MyDbConnection.Instance.connection.CreateCommand();

            if (_whereParameters != null && _whereParameters.Count > 0)
            {
                query.Append(" WHERE ");

                bool first = true;

                bool requiresParam;

                MyParameter wItem;
                bool skipConjuction = false;

                string paramName;
                string columnName;

                foreach (object obj in _whereParameters)
                {
                    // Maybe we injected text or a WhereParameter
                    if (obj.GetType().ToString() == "System.String")
                    {
                        string text = obj as string;
                        query.Append(text);

                        if (text == "(")
                        {
                            skipConjuction = true;
                        }
                    }
                    else
                    {
                        wItem = obj as MyParameter;

                        if (wItem.IsDirty)
                        {
                            if (!first && !skipConjuction)
                            {
                                if (wItem.Conjuction != MyConj.UseDefault)
                                {
                                    if (wItem.Conjuction == MyConj.And)
                                        query.Append(" AND ");
                                    else
                                        query.Append(" OR ");
                                }
                                else
                                {
                                    query.Append(" " + conjuction + " ");
                                }
                            }

                            requiresParam = true;

                            columnName = "[" + wItem.Column + "]";
                            paramName = "@" + wItem.Column + (++inc).ToString();
                            wItem.Param.ParameterName = paramName;

                            switch (wItem.Operator)
                            {
                                case MyOperand.Equal:
                                    query.Append(columnName + " = ? ");
                                    break;
                                case MyOperand.NotEqual:
                                    query.Append(columnName + " <> ? ");
                                    break;
                                case MyOperand.GreaterThan:
                                    query.Append(columnName + " > ? ");
                                    break;
                                case MyOperand.LessThan:
                                    query.Append(columnName + " < ? ");
                                    break;
                                case MyOperand.LessThanOrEqual:
                                    query.Append(columnName + " <= ? ");
                                    break;
                                case MyOperand.GreaterThanOrEqual:
                                    query.Append(columnName + " >= ? ");
                                    break;
                                case MyOperand.Like:
                                    query.Append(columnName + " LIKE ? ");
                                    break;
                                case MyOperand.NotLike:
                                    query.Append(columnName + " NOT LIKE ? ");
                                    break;
                                case MyOperand.IsNull:
                                    query.Append(columnName + " IS NULL ");
                                    requiresParam = false;
                                    break;
                                case MyOperand.IsNotNull:
                                    query.Append(columnName + " IS NOT NULL ");
                                    requiresParam = false;
                                    break;
                                case MyOperand.In:
                                    query.Append(columnName + " IN (" + wItem.Value + ") ");
                                    requiresParam = false;
                                    break;
                                case MyOperand.NotIn:
                                    query.Append(columnName + " NOT IN (" + wItem.Value + ") ");
                                    requiresParam = false;
                                    break;
                                case MyOperand.Between:
                                    query.Append(columnName + " BETWEEN ? AND ? ");
                                    //this.AddParameter(cmd, paramName, wItem.BetweenBeginValue);
                                    cmd.Parameters.Add(new SQLiteParameter(paramName, wItem.Param.DbType, wItem.Param.Size).Value = wItem.BetweenBeginValue);

                                    paramName = "@" + wItem.Column + (++inc).ToString();
                                    //this.AddParameter(cmd, paramName, wItem.BetweenEndValue);
                                    //cmd.Parameters.Add(paramName, wItem.BetweenEndValue);
                                    cmd.Parameters.Add(new SQLiteParameter(paramName, wItem.Param.DbType, wItem.Param.Size).Value = wItem.BetweenEndValue);
                                    requiresParam = false;
                                    break;
                            }

                            if (requiresParam)
                            {
                                IDbCommand dbCmd = cmd as IDbCommand;
                                dbCmd.Parameters.Add(wItem.Param);
                                wItem.Param.Value = wItem.Value;
                            }

                            first = false;
                            skipConjuction = false;
                        }
                    }
                }
            }

            //if (_groupBy.Length > 0)
            //{
            //    query += " GROUP BY " + _groupBy;

            //    if (this._withRollup)
            //    {
            //        query += " WITH ROLLUP";
            //    }
            //}

            if (_orderBy.Length > 0)
            {
                query.Append(" ORDER BY " + _orderBy);
            }
            if (this._top >= 0) query.Append(" LIMIT " + this._top + " ");
            cmd.CommandText = query.ToString();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(myEntity);
            //Helper.MSG(cmd.CommandText);
            return (myEntity.Rows.Count > 0);


        }

        //        private void AddParameter(SQLiteCommand cmd, string paramName, object data)
        //        {
        //#if(VS2005)
        //            cmd.Parameters.AddWithValue(paramName, data);
        //#else
        //            cmd.Parameters.Add(paramName, data);
        //#endif
        //        }



    }
    /// <summary>
    /// The type of comparison this parameter shoud use
    /// </summary>
    public enum MyOperand
    {
        /// <summary>
        /// Equal Comparison
        /// </summary>
        Equal = 1,
        /// <summary>
        /// Not Equal Comparison
        /// </summary>
        NotEqual,
        /// <summary>
        /// Greater Than Comparison
        /// </summary>
        GreaterThan,
        /// <summary>
        /// Greater Than or Equal Comparison
        /// </summary>
        GreaterThanOrEqual,
        /// <summary>
        /// Less Than Comparison
        /// </summary>
        LessThan,
        /// <summary>
        /// Less Than or Equal Comparison
        /// </summary>
        LessThanOrEqual,
        /// <summary>
        /// Like Comparison, "%s%" does it have an 's' in it? "s%" does it begin with 's'?
        /// </summary>
        Like,
        /// <summary>
        /// Is the value null in the database
        /// </summary>
        IsNull,
        /// <summary>
        /// Is the value non-null in the database
        /// </summary>
        IsNotNull,
        /// <summary>
        /// Is the value between two parameters? see <see cref="BetweenBeginValue"/> and <see cref="BetweenEndValue"/>. 
        /// Note that Between can be for other data types than just dates.
        /// </summary>
        Between,
        /// <summary>
        /// Is the value in a list, ie, "4,5,6,7,8"
        /// </summary>
        In,
        /// <summary>
        /// NOT in a list, ie not in, "4,5,6,7,8"
        /// </summary>
        NotIn,
        /// <summary>
        /// Not Like Comparison, "%s%", anything that does not it have an 's' in it.
        /// </summary>
        NotLike
    };

    /// <summary>
    /// The direction used by DynamicQuery.AddOrderBy
    /// </summary>
    public enum MyDir
    {
        /// <summary>
        /// Ascending
        /// </summary>
        ASC = 1,
        /// <summary>
        /// Descending
        /// </summary>
        DESC
    };

    /// <summary>
    /// The conjuction used between WhereParameters
    /// </summary>
    public enum MyConj
    {
        /// <summary>
        /// WhereParameters are joined via "And"
        /// </summary>
        And = 1,
        /// <summary>
        /// WhereParameters are joined via "Or"
        /// </summary>
        Or,
        /// <summary>
        /// WhereParameters are used via the default passed into DynamicQuery.Load.
        /// </summary>
        UseDefault
    };



}
