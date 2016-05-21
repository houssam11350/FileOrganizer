using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;

namespace FileOrganizer.BL
{
    public partial class QuickListDT : MyEntity
    {
        private static QuickListDT defaultQuickListDT;
        SQLiteCommand _insertCommand;
        SQLiteCommand _updateCommand;
        SQLiteCommand _deleteCommand;
        public SQLiteCommand _identityCommand;

        public QuickListDT()
            : base()
        {
            base.QuerySource = "[QuickList]";

        }
        public virtual bool LoadByPrimaryKey(long ID)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(QuickListDT.Parameters.ID, ID);
            return base.LoadFromSql("SELECT * FROM [QuickList] WHERE (ID=@ID)", parameters, CommandType.Text);
        }

        public void LoadAll()
        {
            if (_selectCommand == null)
            {
                _selectCommand = MyDbConnection.Instance.connection.CreateCommand();
                _adapter = new SQLiteDataAdapter(_selectCommand);
            }
            _selectCommand.CommandText = "SELECT * FROM [QuickList]";
            _selectCommand.CommandType = CommandType.Text;
            this.Clear();
            _adapter.Fill(this);
        }
        public SQLiteCommand GetInsertCommand()
        {
            if (_insertCommand == null)
            {
                _insertCommand = MyDbConnection.Instance.connection.CreateCommand();
                _insertCommand.CommandText = "INSERT INTO QuickList ([LName],[IsInToolBar])VALUES (@LName,@IsInToolBar)";
                _insertCommand.CommandType = CommandType.Text;
                CreateParams(_insertCommand);

            }
            return _insertCommand;
        }
        private void CreateParams(SQLiteCommand command)
        {
            command.Parameters.Add(new SQLiteParameter(ColumnNames.ID, DbType.Int64, 8, ColumnNames.ID));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.LName, DbType.String, 2147483647, ColumnNames.LName));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.IsInToolBar, DbType.Boolean, 1, ColumnNames.IsInToolBar));
        }
        public SQLiteCommand GetUpdateCommand()
        {
            if (_updateCommand == null)
            {
                _updateCommand = MyDbConnection.Instance.connection.CreateCommand();
                _updateCommand.CommandText = "UPDATE QuickList SET [LName] = @LName,[IsInToolBar] = @IsInToolBar WHERE ([ID] = @ID)";
                _updateCommand.CommandType = CommandType.Text;
                CreateParams(_updateCommand);
            }
            return _updateCommand;
        }
        public SQLiteCommand GetDeleteCommand()
        {
            if (_deleteCommand == null)
            {
                _deleteCommand = MyDbConnection.Instance.connection.CreateCommand();
                _deleteCommand.CommandText = "DELETE FROM QuickList WHERE ([ID] = @ID)";
                _deleteCommand.CommandType = CommandType.Text;
                _deleteCommand.Parameters.Add(new SQLiteParameter(ColumnNames.ID, DbType.Int64, 8, ColumnNames.ID));
            }
            return _deleteCommand;
        }
        #region @@IDENTITY Logic
        // Overloaded in the generated class
        public virtual string GetAutoKeyColumn()
        {
            return QuickListDT.ColumnNames.ID;
        }
        // Called just before the Save() is truly executed
        protected void HookupRowUpdateEvents(SQLiteDataAdapter adapter)
        {
            // We only bother hooking up the event if we have an AutoKey
            if (this.GetAutoKeyColumn().Length > 0)
            {
                adapter.RowUpdated += new EventHandler<RowUpdatedEventArgs>(OnRowUpdated);
            }
        }


        // If it's an Insert we fetch the @@Identity value and stuff it in the proper column
        protected void OnRowUpdated(object sender, RowUpdatedEventArgs e)
        {
            //try
            {
                if (e.Status == UpdateStatus.Continue && e.StatementType == StatementType.Insert)
                {
                    //TransactionMgr txMgr = TransactionMgr.ThreadTransactionMgr();

                    if (_identityCommand == null)
                    {
                        _identityCommand = MyDbConnection.Instance.connection.CreateCommand();
                        _identityCommand.CommandText = "SELECT last_insert_rowid()";
                    }

                    // We make sure we enlist in the ongoing transaction, otherwise, we
                    // would most likely deadlock
                    //txMgr.Enlist(cmd, this);
                    object o = _identityCommand.ExecuteScalar(); // Get the Identity Value
                    //txMgr.DeEnlist(cmd, this);

                    if (o != null)
                    {
                        e.Row[this.GetAutoKeyColumn()] = o;
                        e.Row.AcceptChanges();
                    }
                }
            }
            // catch { }
        }
        #endregion
        public void Save()
        {
            if (_adapter == null)
            {
                _adapter = new SQLiteDataAdapter();
                this.HookupRowUpdateEvents(_adapter);
                base._isAdapterHooked = true;
            }
            else if (!base._isAdapterHooked)
            {
                this.HookupRowUpdateEvents(_adapter);
                base._isAdapterHooked = true;
            }
            _adapter.InsertCommand = GetInsertCommand();
            _adapter.UpdateCommand = GetUpdateCommand();
            _adapter.DeleteCommand = GetDeleteCommand();

            _adapter.Update(this);
            this.AcceptChanges();
        }

        public static QuickListDT GetDefaultQuickListDT()
        {
            if (defaultQuickListDT == null)
            {
                defaultQuickListDT = new QuickListDT();
                MyDbConnection.Instance.FillDataTable(defaultQuickListDT, "SELECT * FROM [QuickList] WHERE 1 > 1");
            }

            return defaultQuickListDT;
        }
        protected override Type GetRowType()
        {
            return typeof(QuickListRow);
        }

        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new QuickListRow(builder);
        }
        public QuickListRow this[int idx]
        {
            get { return (QuickListRow)Rows[idx]; }
        }
        public QuickListRow NewQuickListRow()
        {
            return (QuickListRow)base.NewRow();
        }
        public static QuickListRow NewRowDefault()
        {
            if (defaultQuickListDT == null)
            {
                defaultQuickListDT = new QuickListDT();
                MyDbConnection.Instance.FillDataTable(defaultQuickListDT, "SELECT * FROM [QuickList] WHERE 1 > 1");
            }
            return (QuickListRow)defaultQuickListDT.NewRow();
        }

        #region ColumnNames
        public class ColumnNames
        {
            public const string ID = "ID";
            public const string LName = "LName";
            public const string IsInToolBar = "IsInToolBar";
        }
        #endregion
        #region Parameters
        public class Parameters
        {

            public static SQLiteParameter ID
            {
                get
                {
                    return new SQLiteParameter(QuickListDT.ColumnNames.ID, DbType.Int64, 8);
                }
            }

            public static SQLiteParameter LName
            {
                get
                {
                    return new SQLiteParameter(QuickListDT.ColumnNames.LName, DbType.String, 2147483647);
                }
            }

            public static SQLiteParameter IsInToolBar
            {
                get
                {
                    return new SQLiteParameter(QuickListDT.ColumnNames.IsInToolBar, DbType.Boolean, 1);
                }
            }


        }
        #endregion


    }

    public partial class QuickListRow : DataRow
    {

        public QuickListRow(DataRowBuilder builder)
            : base(builder)
        {
        }
        public void Save()
        {

            if (this.RowState == DataRowState.Added || RowState == DataRowState.Detached)
            {
                SQLiteCommand insertCommand = ((QuickListDT)this.Table).GetInsertCommand();
                SetCommadValues(insertCommand);
                insertCommand.ExecuteNonQuery();
                if (((QuickListDT)this.Table)._identityCommand == null)
                {
                    ((QuickListDT)this.Table)._identityCommand = MyDbConnection.Instance.connection.CreateCommand();
                    ((QuickListDT)this.Table)._identityCommand.CommandText = "SELECT last_insert_rowid()";
                }
                base[QuickListDT.ColumnNames.ID] = ((QuickListDT)this.Table)._identityCommand.ExecuteScalar();
                this.Table.Rows.Add(this);
                this.AcceptChanges();

            }
            else if (this.RowState == DataRowState.Modified)
            {
                SQLiteCommand updateCommand = ((QuickListDT)this.Table).GetUpdateCommand();
                SetCommadValues(updateCommand);
                updateCommand.ExecuteNonQuery();
                this.AcceptChanges();

            }
            else if (RowState == DataRowState.Deleted)
            {
                SQLiteCommand deleteCommand = ((QuickListDT)this.Table).GetDeleteCommand();
                deleteCommand.Parameters[QuickListDT.ColumnNames.ID].Value = base[QuickListDT.ColumnNames.ID];
                deleteCommand.ExecuteNonQuery();
                this.AcceptChanges();
            }
        }
        public void DeleteQuickList()
        {
            SQLiteCommand deleteCommand = ((QuickListDT)this.Table).GetDeleteCommand();
            deleteCommand.Parameters[QuickListDT.ColumnNames.ID].Value = base[QuickListDT.ColumnNames.ID];
            deleteCommand.ExecuteNonQuery();
            this.Table.Rows.Remove(this);
            //this.AcceptChanges();
        }
        private void SetCommadValues(SQLiteCommand command)
        {
            command.Parameters[QuickListDT.ColumnNames.ID].Value = base[QuickListDT.ColumnNames.ID];
            command.Parameters[QuickListDT.ColumnNames.LName].Value = base[QuickListDT.ColumnNames.LName];
            command.Parameters[QuickListDT.ColumnNames.IsInToolBar].Value = base[QuickListDT.ColumnNames.IsInToolBar];
        }

        virtual public void SetColumnNull(string columnName)
        {
            base[columnName] = DBNull.Value;
        }
        public void SetColumn(string columnName, object Value)
        {
            base[columnName] = Value;
        }
        public object GetColumn(string columnName)
        {
            return base[columnName];
        }

        public virtual long ID
        {
            get
            {
                return (long)base[QuickListDT.ColumnNames.ID];
            }
            set
            {
                base[QuickListDT.ColumnNames.ID] = value;
            }
        }

        public virtual string LName
        {
            get
            {
                return (string)base[QuickListDT.ColumnNames.LName];
            }
            set
            {
                base[QuickListDT.ColumnNames.LName] = value;
            }
        }

        public virtual bool IsInToolBar
        {
            get
            {
                return (bool)base[QuickListDT.ColumnNames.IsInToolBar];
            }
            set
            {
                base[QuickListDT.ColumnNames.IsInToolBar] = value;
            }
        }



        #region String Properties

        public virtual string s_ID
        {
            get
            {
                return this.IsNull(QuickListDT.ColumnNames.ID) ? string.Empty : base[QuickListDT.ColumnNames.ID].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[QuickListDT.ColumnNames.ID] = DBNull.Value;
                else
                    base[QuickListDT.ColumnNames.ID] = Convert.ToInt64(value);
            }
        }

        public virtual string s_LName
        {
            get
            {
                return this.IsNull(QuickListDT.ColumnNames.LName) ? string.Empty : base[QuickListDT.ColumnNames.LName].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[QuickListDT.ColumnNames.LName] = DBNull.Value;
                else
                    base[QuickListDT.ColumnNames.LName] = (value);
            }
        }

        public virtual string s_IsInToolBar
        {
            get
            {
                return this.IsNull(QuickListDT.ColumnNames.IsInToolBar) ? string.Empty : base[QuickListDT.ColumnNames.IsInToolBar].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[QuickListDT.ColumnNames.IsInToolBar] = DBNull.Value;
                else
                    base[QuickListDT.ColumnNames.IsInToolBar] = Convert.ToBoolean(value);
            }
        }


        #endregion
    }

}



