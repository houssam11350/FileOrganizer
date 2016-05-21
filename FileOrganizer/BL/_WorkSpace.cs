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
    public partial class WorkSpaceDT : MyEntity
    {
        private static WorkSpaceDT defaultWorkSpaceDT;
        SQLiteCommand _insertCommand;
        SQLiteCommand _updateCommand;
        SQLiteCommand _deleteCommand;
        public SQLiteCommand _identityCommand;

        public WorkSpaceDT()
            : base()
        {
            base.QuerySource = "[WorkSpace]";

        }
        public virtual bool LoadByPrimaryKey(long ID)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(WorkSpaceDT.Parameters.ID, ID);
            return base.LoadFromSql("SELECT * FROM [WorkSpace] WHERE (ID=@ID)", parameters, CommandType.Text);
        }

        public void LoadAll()
        {
            if (_selectCommand == null)
            {
                _selectCommand = MyDbConnection.Instance.connection.CreateCommand();
                _adapter = new SQLiteDataAdapter(_selectCommand);
            }
            _selectCommand.CommandText = "SELECT * FROM [WorkSpace]";
            _selectCommand.CommandType = CommandType.Text;
            this.Clear();
            _adapter.Fill(this);
        }
        public SQLiteCommand GetInsertCommand()
        {
            if (_insertCommand == null)
            {
                _insertCommand = MyDbConnection.Instance.connection.CreateCommand();
                _insertCommand.CommandText = "INSERT INTO WorkSpace ([WName],[IsActive])VALUES (@WName,@IsActive)";
                _insertCommand.CommandType = CommandType.Text;
                CreateParams(_insertCommand);

            }
            return _insertCommand;
        }
        private void CreateParams(SQLiteCommand command)
        {
            command.Parameters.Add(new SQLiteParameter(ColumnNames.ID, DbType.Int64, 8, ColumnNames.ID));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.WName, DbType.String, 2147483647, ColumnNames.WName));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.IsActive, DbType.Boolean, 1, ColumnNames.IsActive));
        }
        public SQLiteCommand GetUpdateCommand()
        {
            if (_updateCommand == null)
            {
                _updateCommand = MyDbConnection.Instance.connection.CreateCommand();
                _updateCommand.CommandText = "UPDATE WorkSpace SET [WName] = @WName,[IsActive] = @IsActive WHERE ([ID] = @ID)";
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
                _deleteCommand.CommandText = "DELETE FROM WorkSpace WHERE ([ID] = @ID)";
                _deleteCommand.CommandType = CommandType.Text;
                _deleteCommand.Parameters.Add(new SQLiteParameter(ColumnNames.ID, DbType.Int64, 8, ColumnNames.ID));
            }
            return _deleteCommand;
        }
        #region @@IDENTITY Logic
        // Overloaded in the generated class
        public virtual string GetAutoKeyColumn()
        {
            return WorkSpaceDT.ColumnNames.ID;
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

        public static WorkSpaceDT GetDefaultWorkSpaceDT()
        {
            if (defaultWorkSpaceDT == null)
            {
                defaultWorkSpaceDT = new WorkSpaceDT();
                MyDbConnection.Instance.FillDataTable(defaultWorkSpaceDT, "SELECT * FROM [WorkSpace] WHERE 1 > 1");
            }

            return defaultWorkSpaceDT;
        }
        protected override Type GetRowType()
        {
            return typeof(WorkSpaceRow);
        }

        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new WorkSpaceRow(builder);
        }
        public WorkSpaceRow this[int idx]
        {
            get { return (WorkSpaceRow)Rows[idx]; }
        }
        public WorkSpaceRow NewWorkSpaceRow()
        {
            return (WorkSpaceRow)base.NewRow();
        }
        public static WorkSpaceRow NewRowDefault()
        {
            if (defaultWorkSpaceDT == null)
            {
                defaultWorkSpaceDT = new WorkSpaceDT();
                MyDbConnection.Instance.FillDataTable(defaultWorkSpaceDT, "SELECT * FROM [WorkSpace] WHERE 1 > 1");
            }
            return (WorkSpaceRow)defaultWorkSpaceDT.NewRow();
        }

        #region ColumnNames
        public class ColumnNames
        {
            public const string ID = "ID";
            public const string WName = "WName";
            public const string IsActive = "IsActive";
        }
        #endregion
        #region Parameters
        public class Parameters
        {

            public static SQLiteParameter ID
            {
                get
                {
                    return new SQLiteParameter(WorkSpaceDT.ColumnNames.ID, DbType.Int64, 8);
                }
            }

            public static SQLiteParameter WName
            {
                get
                {
                    return new SQLiteParameter(WorkSpaceDT.ColumnNames.WName, DbType.String, 2147483647);
                }
            }

            public static SQLiteParameter IsActive
            {
                get
                {
                    return new SQLiteParameter(WorkSpaceDT.ColumnNames.IsActive, DbType.Boolean, 1);
                }
            }


        }
        #endregion


    }

    public partial class WorkSpaceRow : DataRow
    {

        public WorkSpaceRow(DataRowBuilder builder)
            : base(builder)
        {
        }
        public void Save()
        {

            if (this.RowState == DataRowState.Added || RowState == DataRowState.Detached)
            {
                SQLiteCommand insertCommand = ((WorkSpaceDT)this.Table).GetInsertCommand();
                SetCommadValues(insertCommand);
                insertCommand.ExecuteNonQuery();
                if (((WorkSpaceDT)this.Table)._identityCommand == null)
                {
                    ((WorkSpaceDT)this.Table)._identityCommand = MyDbConnection.Instance.connection.CreateCommand();
                    ((WorkSpaceDT)this.Table)._identityCommand.CommandText = "SELECT last_insert_rowid()";
                }
                base[WorkSpaceDT.ColumnNames.ID] = ((WorkSpaceDT)this.Table)._identityCommand.ExecuteScalar();
                this.Table.Rows.Add(this);
                this.AcceptChanges();

            }
            else if (this.RowState == DataRowState.Modified)
            {
                SQLiteCommand updateCommand = ((WorkSpaceDT)this.Table).GetUpdateCommand();
                SetCommadValues(updateCommand);
                updateCommand.ExecuteNonQuery();
                this.AcceptChanges();

            }
            else if (RowState == DataRowState.Deleted)
            {
                SQLiteCommand deleteCommand = ((WorkSpaceDT)this.Table).GetDeleteCommand();
                deleteCommand.Parameters[WorkSpaceDT.ColumnNames.ID].Value = base[WorkSpaceDT.ColumnNames.ID];
                deleteCommand.ExecuteNonQuery();
                this.AcceptChanges();
            }
        }
        public void DeleteWorkSpace()
        {
            SQLiteCommand deleteCommand = ((WorkSpaceDT)this.Table).GetDeleteCommand();
            deleteCommand.Parameters[WorkSpaceDT.ColumnNames.ID].Value = base[WorkSpaceDT.ColumnNames.ID];
            deleteCommand.ExecuteNonQuery();
            this.Table.Rows.Remove(this);
            //this.AcceptChanges();
        }
        private void SetCommadValues(SQLiteCommand command)
        {
            command.Parameters[WorkSpaceDT.ColumnNames.ID].Value = base[WorkSpaceDT.ColumnNames.ID];
            command.Parameters[WorkSpaceDT.ColumnNames.WName].Value = base[WorkSpaceDT.ColumnNames.WName];
            command.Parameters[WorkSpaceDT.ColumnNames.IsActive].Value = base[WorkSpaceDT.ColumnNames.IsActive];
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
                return (long)base[WorkSpaceDT.ColumnNames.ID];
            }
            set
            {
                base[WorkSpaceDT.ColumnNames.ID] = value;
            }
        }

        public virtual string WName
        {
            get
            {
                return (string)base[WorkSpaceDT.ColumnNames.WName];
            }
            set
            {
                base[WorkSpaceDT.ColumnNames.WName] = value;
            }
        }

        public virtual bool IsActive
        {
            get
            {
                return (bool)base[WorkSpaceDT.ColumnNames.IsActive];
            }
            set
            {
                base[WorkSpaceDT.ColumnNames.IsActive] = value;
            }
        }



        #region String Properties

        public virtual string s_ID
        {
            get
            {
                return this.IsNull(WorkSpaceDT.ColumnNames.ID) ? string.Empty : base[WorkSpaceDT.ColumnNames.ID].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[WorkSpaceDT.ColumnNames.ID] = DBNull.Value;
                else
                    base[WorkSpaceDT.ColumnNames.ID] = Convert.ToInt64(value);
            }
        }

        public virtual string s_WName
        {
            get
            {
                return this.IsNull(WorkSpaceDT.ColumnNames.WName) ? string.Empty : base[WorkSpaceDT.ColumnNames.WName].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[WorkSpaceDT.ColumnNames.WName] = DBNull.Value;
                else
                    base[WorkSpaceDT.ColumnNames.WName] = (value);
            }
        }

        public virtual string s_IsActive
        {
            get
            {
                return this.IsNull(WorkSpaceDT.ColumnNames.IsActive) ? string.Empty : base[WorkSpaceDT.ColumnNames.IsActive].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[WorkSpaceDT.ColumnNames.IsActive] = DBNull.Value;
                else
                    base[WorkSpaceDT.ColumnNames.IsActive] = Convert.ToBoolean(value);
            }
        }


        #endregion
    }

}



