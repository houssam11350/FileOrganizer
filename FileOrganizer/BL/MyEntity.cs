using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Specialized;
using System.Collections;
using System.Data.OleDb;
using System.Data.SQLite;

namespace FileOrganizer.BL
{

    public class MyEntity : DataTable
    {
        public string QuerySource;
        public SQLiteCommand _selectCommand;
        public SQLiteDataAdapter _adapter;
        public MyQuery Query;
        public bool _isAdapterHooked = false;

        public MyEntity()
        {
            Query = new MyQuery(this);
        }

        protected bool LoadFromSql(string sp, ListDictionary Parameters)
        {
            return this.LoadFromSql(sp, Parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// This method allows you to pass in direct sql.
        /// </summary>
        /// <param name="sp">This can be a stored procedure, a table, or direct sql</param>
        /// <param name="Parameters">Two types of key/value pairs are allowed, see the coding samples for this method</param>
        /// <param name="commandType">This property determines the type being passed in the "sp" parameter</param>
        /// <returns>True if at least one row was loaded</returns>
        protected bool LoadFromSql(string sp, ListDictionary Parameters, CommandType commandType)
        {
            //DataTable dataTable = null;
            bool loaded = false;

            try
            {
                //dataTable = new DataTable();

                SQLiteCommand cmd = MyDbConnection.Instance.connection.CreateCommand();
                cmd.CommandText = sp;
                cmd.CommandType = commandType;

                IDataParameter p;

                if (Parameters != null)
                {
                    foreach (DictionaryEntry param in Parameters)
                    {
                        p = param.Key as IDataParameter;

                        if (null == p)
                        {
                            p = new SQLiteParameter((string)param.Key, param.Value);
                        }
                        else
                        {
                            p.Value = param.Value;
                        }

                        cmd.Parameters.Add(p);
                    }
                }

                SQLiteDataAdapter da = new SQLiteDataAdapter();

                da.SelectCommand = cmd;

                //TransactionMgr txMgr = TransactionMgr.ThreadTransactionMgr();

                //txMgr.Enlist(cmd, this);
                //DbDataAdapter dba = ConvertIDbDataAdapter(da);
                this.Clear();
                da.Fill(this);
                //txMgr.DeEnlist(cmd, this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //this.DataTable = dataTable;
                loaded = (this.Rows.Count > 0);
            }

            return loaded;
        }


        public SQLiteCommand _LoadFromRawSql(string rawSql, params object[] parameters)
        {
            int i = 0;
            string token = "";
            string sIndex = "";
            string param = "";

            SQLiteCommand cmd = new SQLiteCommand();

            foreach (object o in parameters)
            {
                sIndex = i.ToString();
                token = '{' + sIndex + '}';
                param = "@p" + sIndex;

                rawSql = rawSql.Replace(token, param);

                SQLiteParameter p = new SQLiteParameter(param, o);
                cmd.Parameters.Add(p);
                i++;
            }

            cmd.CommandText = rawSql;
            return cmd;
        }


        /// <summary>
        /// LoadFromRawSql provides a quick and easy way (easier than say LoadFromSql) to execute a raw sql statement. All
        /// values passed in via parameters will be passed in via actual SQL Parameters to prevent
        /// SQL injection techniques, you can pass in any number of values via {0}, {1} and so on ...
        /// </summary>
        /// <param name="rawSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// public class Employees : _Employees
        /// {
        /// 	public bool MySpecialLoad()
        /// 	{
        /// 		// Load All Employees with an 'o' in the last name
        /// 		return base.LoadFromRawSql("Select * from Employees where LastName LIKE {0}", "%o%");
        /// 	}
        /// }
        /// </code>
        /// </example> 
        protected bool LoadFromRawSql(string rawSql, params object[] parameters)
        {
            bool loaded = false;
            DataTable dt = null;

            try
            {
                SQLiteCommand cmd = _LoadFromRawSql(rawSql, parameters);

                SQLiteDataAdapter da = new SQLiteDataAdapter();
                da.SelectCommand = cmd;

                //TransactionMgr txMgr = TransactionMgr.ThreadTransactionMgr();

                dt = new DataTable();

                //txMgr.Enlist(cmd, this);
                //DbDataAdapter dbDataAdapter = this.ConvertIDbDataAdapter(da);
                da.Fill(dt);
                //txMgr.DeEnlist(cmd, this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //this.DataTable = dt;
                loaded = (dt.Rows.Count > 0);
            }

            return loaded;
        }

        public void LoadFromSQL(string sql)
        {
            if (_selectCommand == null)
            {

                _selectCommand = MyDbConnection.Instance.connection.CreateCommand();
                _adapter = new SQLiteDataAdapter(_selectCommand);
            }
            _selectCommand.CommandText = sql;
            this.Clear();
            _adapter.Fill(this);

        }

    }


}
