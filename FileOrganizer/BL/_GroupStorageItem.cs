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
    public partial class GroupStorageItemDT : MyEntity
    {

        private static GroupStorageItemDT defaultGroupStorageItemDT;
        SQLiteCommand _insertCommand;
        SQLiteCommand _updateCommand;
        SQLiteCommand _deleteCommand;
        public SQLiteCommand _identityCommand;

        public GroupStorageItemDT()
            : base()
        {
            base.QuerySource = "[GroupStorageItem]";

        }
        public virtual bool LoadByPrimaryKey(long GroupID, long StorageItemID)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(GroupStorageItemDT.Parameters.GroupID, GroupID);
            parameters.Add(GroupStorageItemDT.Parameters.StorageItemID, StorageItemID);
            return base.LoadFromSql("SELECT * FROM [GroupStorageItem] WHERE (GroupID=@GroupID) AND (StorageItemID=@StorageItemID)", parameters, CommandType.Text);
        }

        public void LoadAll()
        {
            if (_selectCommand == null)
            {
                _selectCommand = MyDbConnection.Instance.connection.CreateCommand();
                _adapter = new SQLiteDataAdapter(_selectCommand);
            }
            _selectCommand.CommandText = "SELECT * FROM [GroupStorageItem]";
            _selectCommand.CommandType = CommandType.Text;
            this.Clear();
            _adapter.Fill(this);
        }
        public SQLiteCommand GetInsertCommand()
        {
            if (_insertCommand == null)
            {
                _insertCommand = MyDbConnection.Instance.connection.CreateCommand();
                _insertCommand.CommandText = "INSERT INTO GroupStorageItem ([GroupID],[StorageItemID])VALUES (@GroupID,@StorageItemID)";
                _insertCommand.CommandType = CommandType.Text;
                CreateParams(_insertCommand);

            }
            return _insertCommand;
        }
        private void CreateParams(SQLiteCommand command)
        {
            command.Parameters.Add(new SQLiteParameter(ColumnNames.GroupID, DbType.Int64, 8, ColumnNames.GroupID));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.StorageItemID, DbType.Int64, 8, ColumnNames.StorageItemID));
        }
        public SQLiteCommand GetUpdateCommand()
        {
            if (_updateCommand == null)
            {
                _updateCommand = MyDbConnection.Instance.connection.CreateCommand();
                _updateCommand.CommandText = "UPDATE GroupStorageItem SET  WHERE ([GroupID] = @GroupID) AND ([StorageItemID] = @StorageItemID)";
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
                _deleteCommand.CommandText = "DELETE FROM GroupStorageItem WHERE ([GroupID] = @GroupID) AND ([StorageItemID] = @StorageItemID)";
                _deleteCommand.CommandType = CommandType.Text;
                _deleteCommand.Parameters.Add(new SQLiteParameter(ColumnNames.GroupID, DbType.Int64, 8, ColumnNames.GroupID));
                _deleteCommand.Parameters.Add(new SQLiteParameter(ColumnNames.StorageItemID, DbType.Int64, 8, ColumnNames.StorageItemID));
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

        public static GroupStorageItemDT GetDefaultGroupStorageItemDT()
        {
            if (defaultGroupStorageItemDT == null)
            {
                defaultGroupStorageItemDT = new GroupStorageItemDT();
                MyDbConnection.Instance.FillDataTable(defaultGroupStorageItemDT, "SELECT * FROM [GroupStorageItem] WHERE 1 > 1");
            }

            return defaultGroupStorageItemDT;
        }
        protected override Type GetRowType()
        {
            return typeof(GroupStorageItemRow);
        }

        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new GroupStorageItemRow(builder);
        }
        public GroupStorageItemRow this[int idx]
        {
            get { return (GroupStorageItemRow)Rows[idx]; }
        }
        public GroupStorageItemRow NewGroupStorageItemRow()
        {
            return (GroupStorageItemRow)base.NewRow();
        }
        public static GroupStorageItemRow NewRowDefault()
        {
            if (defaultGroupStorageItemDT == null)
            {
                defaultGroupStorageItemDT = new GroupStorageItemDT();
                MyDbConnection.Instance.FillDataTable(defaultGroupStorageItemDT, "SELECT * FROM [GroupStorageItem] WHERE 1 > 1");
            }
            return (GroupStorageItemRow)defaultGroupStorageItemDT.NewRow();
        }

        #region ColumnNames
        public class ColumnNames
        {
            public const string GroupID = "GroupID";
            public const string StorageItemID = "StorageItemID";
        }
        #endregion
        #region Parameters
        public class Parameters
        {

            public static SQLiteParameter GroupID
            {
                get
                {
                    return new SQLiteParameter(GroupStorageItemDT.ColumnNames.GroupID, DbType.Int64, 8);
                }
            }

            public static SQLiteParameter StorageItemID
            {
                get
                {
                    return new SQLiteParameter(GroupStorageItemDT.ColumnNames.StorageItemID, DbType.Int64, 8);
                }
            }


        }
        #endregion


    }

    public partial class GroupStorageItemRow : DataRow
    {

        public GroupStorageItemRow(DataRowBuilder builder)
            : base(builder)
        {
        }
        public void Save()
        {

            if (this.RowState == DataRowState.Added || RowState == DataRowState.Detached)
            {
                SQLiteCommand insertCommand = ((GroupStorageItemDT)this.Table).GetInsertCommand();
                SetCommadValues(insertCommand);
                insertCommand.ExecuteNonQuery();
                if (((GroupStorageItemDT)this.Table)._identityCommand == null)
                {
                    ((GroupStorageItemDT)this.Table)._identityCommand = MyDbConnection.Instance.connection.CreateCommand();
                    ((GroupStorageItemDT)this.Table)._identityCommand.CommandText = "SELECT last_insert_rowid()";
                }
                this.Table.Rows.Add(this);
                this.AcceptChanges();

            }
            else if (this.RowState == DataRowState.Modified)
            {
                SQLiteCommand updateCommand = ((GroupStorageItemDT)this.Table).GetUpdateCommand();
                SetCommadValues(updateCommand);
                updateCommand.ExecuteNonQuery();
                this.AcceptChanges();

            }
            else if (RowState == DataRowState.Deleted)
            {
                SQLiteCommand deleteCommand = ((GroupStorageItemDT)this.Table).GetDeleteCommand();
                deleteCommand.Parameters[GroupStorageItemDT.ColumnNames.GroupID].Value = base[GroupStorageItemDT.ColumnNames.GroupID];
                deleteCommand.Parameters[GroupStorageItemDT.ColumnNames.StorageItemID].Value = base[GroupStorageItemDT.ColumnNames.StorageItemID];
                deleteCommand.ExecuteNonQuery();
                this.AcceptChanges();
            }
        }
        public void DeleteGroupStorageItem()
        {
            SQLiteCommand deleteCommand = ((GroupStorageItemDT)this.Table).GetDeleteCommand();
            deleteCommand.Parameters[GroupStorageItemDT.ColumnNames.GroupID].Value = base[GroupStorageItemDT.ColumnNames.GroupID];
            deleteCommand.Parameters[GroupStorageItemDT.ColumnNames.StorageItemID].Value = base[GroupStorageItemDT.ColumnNames.StorageItemID];
            deleteCommand.ExecuteNonQuery();
            this.Table.Rows.Remove(this);
            //this.AcceptChanges();
        }
        private void SetCommadValues(SQLiteCommand command)
        {
            command.Parameters[GroupStorageItemDT.ColumnNames.GroupID].Value = base[GroupStorageItemDT.ColumnNames.GroupID];
            command.Parameters[GroupStorageItemDT.ColumnNames.StorageItemID].Value = base[GroupStorageItemDT.ColumnNames.StorageItemID];
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

        public virtual long GroupID
        {
            get
            {
                return (long)base[GroupStorageItemDT.ColumnNames.GroupID];
            }
            set
            {
                base[GroupStorageItemDT.ColumnNames.GroupID] = value;
            }
        }

        public virtual long StorageItemID
        {
            get
            {
                return (long)base[GroupStorageItemDT.ColumnNames.StorageItemID];
            }
            set
            {
                base[GroupStorageItemDT.ColumnNames.StorageItemID] = value;
            }
        }



        #region String Properties

        public virtual string s_GroupID
        {
            get
            {
                return this.IsNull(GroupStorageItemDT.ColumnNames.GroupID) ? string.Empty : base[GroupStorageItemDT.ColumnNames.GroupID].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[GroupStorageItemDT.ColumnNames.GroupID] = DBNull.Value;
                else
                    base[GroupStorageItemDT.ColumnNames.GroupID] = Convert.ToInt64(value);
            }
        }

        public virtual string s_StorageItemID
        {
            get
            {
                return this.IsNull(GroupStorageItemDT.ColumnNames.StorageItemID) ? string.Empty : base[GroupStorageItemDT.ColumnNames.StorageItemID].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[GroupStorageItemDT.ColumnNames.StorageItemID] = DBNull.Value;
                else
                    base[GroupStorageItemDT.ColumnNames.StorageItemID] = Convert.ToInt64(value);
            }
        }


        #endregion
    }

}



