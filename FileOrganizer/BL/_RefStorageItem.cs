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
    public partial class RefStorageItemDT : MyEntity
    {
        private static RefStorageItemDT defaultRefStorageItemDT;
        SQLiteCommand _insertCommand;
        SQLiteCommand _updateCommand;
        SQLiteCommand _deleteCommand;
        public SQLiteCommand _identityCommand;

        public RefStorageItemDT()
            : base()
        {
            base.QuerySource = "[RefStorageItem]";

        }
        public virtual bool LoadByPrimaryKey(long MainStorageItemID, long RefStorageItemID)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(RefStorageItemDT.Parameters.MainStorageItemID, MainStorageItemID);
            parameters.Add(RefStorageItemDT.Parameters.RefStorageItemID, RefStorageItemID);
            return base.LoadFromSql("SELECT * FROM [RefStorageItem] WHERE (MainStorageItemID=@MainStorageItemID) AND (RefStorageItemID=@RefStorageItemID)", parameters, CommandType.Text);
        }

        public void LoadAll()
        {
            if (_selectCommand == null)
            {
                _selectCommand = MyDbConnection.Instance.connection.CreateCommand();
                _adapter = new SQLiteDataAdapter(_selectCommand);
            }
            _selectCommand.CommandText = "SELECT * FROM [RefStorageItem]";
            _selectCommand.CommandType = CommandType.Text;
            this.Clear();
            _adapter.Fill(this);
        }
        public SQLiteCommand GetInsertCommand()
        {
            if (_insertCommand == null)
            {
                _insertCommand = MyDbConnection.Instance.connection.CreateCommand();
                _insertCommand.CommandText = "INSERT INTO RefStorageItem ([MainStorageItemID],[RefStorageItemID],[Description])VALUES (@MainStorageItemID,@RefStorageItemID,@Description)";
                _insertCommand.CommandType = CommandType.Text;
                CreateParams(_insertCommand);

            }
            return _insertCommand;
        }
        private void CreateParams(SQLiteCommand command)
        {
            command.Parameters.Add(new SQLiteParameter(ColumnNames.MainStorageItemID, DbType.Int64, 8, ColumnNames.MainStorageItemID));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.RefStorageItemID, DbType.Int64, 8, ColumnNames.RefStorageItemID));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.Description, DbType.String, 2147483647, ColumnNames.Description));
        }
        public SQLiteCommand GetUpdateCommand()
        {
            if (_updateCommand == null)
            {
                _updateCommand = MyDbConnection.Instance.connection.CreateCommand();
                _updateCommand.CommandText = "UPDATE RefStorageItem SET [Description] = @Description WHERE ([MainStorageItemID] = @MainStorageItemID) AND ([RefStorageItemID] = @RefStorageItemID)";
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
                _deleteCommand.CommandText = "DELETE FROM RefStorageItem WHERE ([MainStorageItemID] = @MainStorageItemID) AND ([RefStorageItemID] = @RefStorageItemID)";
                _deleteCommand.CommandType = CommandType.Text;
                _deleteCommand.Parameters.Add(new SQLiteParameter(ColumnNames.MainStorageItemID, DbType.Int64, 8, ColumnNames.MainStorageItemID));
                _deleteCommand.Parameters.Add(new SQLiteParameter(ColumnNames.RefStorageItemID, DbType.Int64, 8, ColumnNames.RefStorageItemID));
            }
            return _deleteCommand;
        }
        #region @@IDENTITY Logic
        // Overloaded in the generated class
        public virtual string GetAutoKeyColumn()
        {
            return string.Empty;
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

        public static RefStorageItemDT GetDefaultRefStorageItemDT()
        {
            if (defaultRefStorageItemDT == null)
            {
                defaultRefStorageItemDT = new RefStorageItemDT();
                MyDbConnection.Instance.FillDataTable(defaultRefStorageItemDT, "SELECT * FROM [RefStorageItem] WHERE 1 > 1");
            }

            return defaultRefStorageItemDT;
        }
        protected override Type GetRowType()
        {
            return typeof(RefStorageItemRow);
        }

        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new RefStorageItemRow(builder);
        }
        public RefStorageItemRow this[int idx]
        {
            get { return (RefStorageItemRow)Rows[idx]; }
        }
        public RefStorageItemRow NewRefStorageItemRow()
        {
            return (RefStorageItemRow)base.NewRow();
        }
        public static RefStorageItemRow NewRowDefault()
        {
            if (defaultRefStorageItemDT == null)
            {
                defaultRefStorageItemDT = new RefStorageItemDT();
                MyDbConnection.Instance.FillDataTable(defaultRefStorageItemDT, "SELECT * FROM [RefStorageItem] WHERE 1 > 1");
            }
            return (RefStorageItemRow)defaultRefStorageItemDT.NewRow();
        }

        #region ColumnNames
        public class ColumnNames
        {
            public const string MainStorageItemID = "MainStorageItemID";
            public const string RefStorageItemID = "RefStorageItemID";
            public const string Description = "Description";
        }
        #endregion
        #region Parameters
        public class Parameters
        {

            public static SQLiteParameter MainStorageItemID
            {
                get
                {
                    return new SQLiteParameter(RefStorageItemDT.ColumnNames.MainStorageItemID, DbType.Int64, 8);
                }
            }

            public static SQLiteParameter RefStorageItemID
            {
                get
                {
                    return new SQLiteParameter(RefStorageItemDT.ColumnNames.RefStorageItemID, DbType.Int64, 8);
                }
            }

            public static SQLiteParameter Description
            {
                get
                {
                    return new SQLiteParameter(RefStorageItemDT.ColumnNames.Description, DbType.String, 2147483647);
                }
            }


        }
        #endregion


    }

    public partial class RefStorageItemRow : DataRow
    {

        public RefStorageItemRow(DataRowBuilder builder)
            : base(builder)
        {
        }
        public void Save()
        {

            if (this.RowState == DataRowState.Added || RowState == DataRowState.Detached)
            {
                SQLiteCommand insertCommand = ((RefStorageItemDT)this.Table).GetInsertCommand();
                SetCommadValues(insertCommand);
                insertCommand.ExecuteNonQuery();
                if (((RefStorageItemDT)this.Table)._identityCommand == null)
                {
                    ((RefStorageItemDT)this.Table)._identityCommand = MyDbConnection.Instance.connection.CreateCommand();
                    ((RefStorageItemDT)this.Table)._identityCommand.CommandText = "SELECT last_insert_rowid()";
                }
                this.Table.Rows.Add(this);
                this.AcceptChanges();

            }
            else if (this.RowState == DataRowState.Modified)
            {
                SQLiteCommand updateCommand = ((RefStorageItemDT)this.Table).GetUpdateCommand();
                SetCommadValues(updateCommand);
                updateCommand.ExecuteNonQuery();
                this.AcceptChanges();

            }
            else if (RowState == DataRowState.Deleted)
            {
                SQLiteCommand deleteCommand = ((RefStorageItemDT)this.Table).GetDeleteCommand();
                deleteCommand.Parameters[RefStorageItemDT.ColumnNames.MainStorageItemID].Value = base[RefStorageItemDT.ColumnNames.MainStorageItemID];
                deleteCommand.Parameters[RefStorageItemDT.ColumnNames.RefStorageItemID].Value = base[RefStorageItemDT.ColumnNames.RefStorageItemID];
                deleteCommand.ExecuteNonQuery();
                this.AcceptChanges();
            }
        }
        public void DeleteRefStorageItem()
        {
            SQLiteCommand deleteCommand = ((RefStorageItemDT)this.Table).GetDeleteCommand();
            deleteCommand.Parameters[RefStorageItemDT.ColumnNames.MainStorageItemID].Value = base[RefStorageItemDT.ColumnNames.MainStorageItemID];
            deleteCommand.Parameters[RefStorageItemDT.ColumnNames.RefStorageItemID].Value = base[RefStorageItemDT.ColumnNames.RefStorageItemID];
            deleteCommand.ExecuteNonQuery();
            this.Table.Rows.Remove(this);
            //this.AcceptChanges();
        }
        private void SetCommadValues(SQLiteCommand command)
        {
            command.Parameters[RefStorageItemDT.ColumnNames.MainStorageItemID].Value = base[RefStorageItemDT.ColumnNames.MainStorageItemID];
            command.Parameters[RefStorageItemDT.ColumnNames.RefStorageItemID].Value = base[RefStorageItemDT.ColumnNames.RefStorageItemID];
            command.Parameters[RefStorageItemDT.ColumnNames.Description].Value = base[RefStorageItemDT.ColumnNames.Description];
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

        public virtual long MainStorageItemID
        {
            get
            {
                return (long)base[RefStorageItemDT.ColumnNames.MainStorageItemID];
            }
            set
            {
                base[RefStorageItemDT.ColumnNames.MainStorageItemID] = value;
            }
        }

        public virtual long RefStorageItemID
        {
            get
            {
                return (long)base[RefStorageItemDT.ColumnNames.RefStorageItemID];
            }
            set
            {
                base[RefStorageItemDT.ColumnNames.RefStorageItemID] = value;
            }
        }

        public virtual string Description
        {
            get
            {
                return (string)base[RefStorageItemDT.ColumnNames.Description];
            }
            set
            {
                base[RefStorageItemDT.ColumnNames.Description] = value;
            }
        }



        #region String Properties

        public virtual string s_MainStorageItemID
        {
            get
            {
                return this.IsNull(RefStorageItemDT.ColumnNames.MainStorageItemID) ? string.Empty : base[RefStorageItemDT.ColumnNames.MainStorageItemID].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[RefStorageItemDT.ColumnNames.MainStorageItemID] = DBNull.Value;
                else
                    base[RefStorageItemDT.ColumnNames.MainStorageItemID] = Convert.ToInt64(value);
            }
        }

        public virtual string s_RefStorageItemID
        {
            get
            {
                return this.IsNull(RefStorageItemDT.ColumnNames.RefStorageItemID) ? string.Empty : base[RefStorageItemDT.ColumnNames.RefStorageItemID].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[RefStorageItemDT.ColumnNames.RefStorageItemID] = DBNull.Value;
                else
                    base[RefStorageItemDT.ColumnNames.RefStorageItemID] = Convert.ToInt64(value);
            }
        }

        public virtual string s_Description
        {
            get
            {
                return this.IsNull(RefStorageItemDT.ColumnNames.Description) ? string.Empty : base[RefStorageItemDT.ColumnNames.Description].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[RefStorageItemDT.ColumnNames.Description] = DBNull.Value;
                else
                    base[RefStorageItemDT.ColumnNames.Description] = (value);
            }
        }


        #endregion
    }

}



