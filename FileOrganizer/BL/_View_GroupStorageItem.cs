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
    public partial class View_GroupStorageItemDT : MyEntity
    {
        private static View_GroupStorageItemDT defaultView_GroupStorageItemDT;
        SQLiteCommand _insertCommand;
        SQLiteCommand _updateCommand;
        SQLiteCommand _deleteCommand;
        public SQLiteCommand _identityCommand;

        public View_GroupStorageItemDT()
            : base()
        {
            base.QuerySource = "[View_GroupStorageItem]";

        }
        public virtual bool LoadByPrimaryKey(long StorageItemID, long ItemGroupID)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(View_GroupStorageItemDT.Parameters.StorageItemID, StorageItemID);
            parameters.Add(View_GroupStorageItemDT.Parameters.ItemGroupID, ItemGroupID);
            return base.LoadFromSql("SELECT * FROM [View_GroupStorageItem] WHERE (StorageItemID=@StorageItemID) AND (ItemGroupID=@ItemGroupID)", parameters, CommandType.Text);
        }

        public void LoadAll()
        {
            if (_selectCommand == null)
            {
                _selectCommand = MyDbConnection.Instance.connection.CreateCommand();
                _adapter = new SQLiteDataAdapter(_selectCommand);
            }
            _selectCommand.CommandText = "SELECT * FROM [View_GroupStorageItem]";
            _selectCommand.CommandType = CommandType.Text;
            this.Clear();
            _adapter.Fill(this);
        }
        public SQLiteCommand GetInsertCommand()
        {
            if (_insertCommand == null)
            {
                _insertCommand = MyDbConnection.Instance.connection.CreateCommand();
                _insertCommand.CommandText = "INSERT INTO View_GroupStorageItem ([ItemName],[Description],[FullPath],[GroupName])VALUES (@ItemName,@Description,@FullPath,@GroupName)";
                _insertCommand.CommandType = CommandType.Text;
                CreateParams(_insertCommand);

            }
            return _insertCommand;
        }
        private void CreateParams(SQLiteCommand command)
        {
            command.Parameters.Add(new SQLiteParameter(ColumnNames.StorageItemID, DbType.Int64, 8, ColumnNames.StorageItemID));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.ItemName, DbType.String, 2147483647, ColumnNames.ItemName));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.Description, DbType.String, 2147483647, ColumnNames.Description));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.FullPath, DbType.String, 2147483647, ColumnNames.FullPath));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.GroupName, DbType.String, 2147483647, ColumnNames.GroupName));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.ItemGroupID, DbType.Int64, 8, ColumnNames.ItemGroupID));
        }
        public SQLiteCommand GetUpdateCommand()
        {
            if (_updateCommand == null)
            {
                _updateCommand = MyDbConnection.Instance.connection.CreateCommand();
                _updateCommand.CommandText = "UPDATE View_GroupStorageItem SET [ItemName] = @ItemName,[Description] = @Description,[FullPath] = @FullPath,[GroupName] = @GroupName WHERE ([StorageItemID] = @StorageItemID) AND ([ItemGroupID] = @ItemGroupID)";
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
                _deleteCommand.CommandText = "DELETE FROM View_GroupStorageItem WHERE ([StorageItemID] = @StorageItemID) AND ([ItemGroupID] = @ItemGroupID)";
                _deleteCommand.CommandType = CommandType.Text;
                _deleteCommand.Parameters.Add(new SQLiteParameter(ColumnNames.StorageItemID, DbType.Int64, 8, ColumnNames.StorageItemID));
                _deleteCommand.Parameters.Add(new SQLiteParameter(ColumnNames.ItemGroupID, DbType.Int64, 8, ColumnNames.ItemGroupID));
            }
            return _deleteCommand;
        }
        #region @@IDENTITY Logic
        // Overloaded in the generated class
        public virtual string GetAutoKeyColumn()
        {
            return View_GroupStorageItemDT.ColumnNames.ItemGroupID;
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

        public static View_GroupStorageItemDT GetDefaultView_GroupStorageItemDT()
        {
            if (defaultView_GroupStorageItemDT == null)
            {
                defaultView_GroupStorageItemDT = new View_GroupStorageItemDT();
                MyDbConnection.Instance.FillDataTable(defaultView_GroupStorageItemDT, "SELECT * FROM [View_GroupStorageItem] WHERE 1 > 1");
            }

            return defaultView_GroupStorageItemDT;
        }
        protected override Type GetRowType()
        {
            return typeof(View_GroupStorageItemRow);
        }

        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new View_GroupStorageItemRow(builder);
        }
        public View_GroupStorageItemRow this[int idx]
        {
            get { return (View_GroupStorageItemRow)Rows[idx]; }
        }
        public View_GroupStorageItemRow NewView_GroupStorageItemRow()
        {
            return (View_GroupStorageItemRow)base.NewRow();
        }
        public static View_GroupStorageItemRow NewRowDefault()
        {
            if (defaultView_GroupStorageItemDT == null)
            {
                defaultView_GroupStorageItemDT = new View_GroupStorageItemDT();
                MyDbConnection.Instance.FillDataTable(defaultView_GroupStorageItemDT, "SELECT * FROM [View_GroupStorageItem] WHERE 1 > 1");
            }
            return (View_GroupStorageItemRow)defaultView_GroupStorageItemDT.NewRow();
        }

        #region ColumnNames
        public class ColumnNames
        {
            public const string StorageItemID = "StorageItemID";
            public const string ItemName = "ItemName";
            public const string Description = "Description";
            public const string FullPath = "FullPath";
            public const string GroupName = "GroupName";
            public const string ItemGroupID = "ItemGroupID";
        }
        #endregion
        #region Parameters
        public class Parameters
        {

            public static SQLiteParameter StorageItemID
            {
                get
                {
                    return new SQLiteParameter(View_GroupStorageItemDT.ColumnNames.StorageItemID, DbType.Int64, 8);
                }
            }

            public static SQLiteParameter ItemName
            {
                get
                {
                    return new SQLiteParameter(View_GroupStorageItemDT.ColumnNames.ItemName, DbType.String, 2147483647);
                }
            }

            public static SQLiteParameter Description
            {
                get
                {
                    return new SQLiteParameter(View_GroupStorageItemDT.ColumnNames.Description, DbType.String, 2147483647);
                }
            }

            public static SQLiteParameter FullPath
            {
                get
                {
                    return new SQLiteParameter(View_GroupStorageItemDT.ColumnNames.FullPath, DbType.String, 2147483647);
                }
            }

            public static SQLiteParameter GroupName
            {
                get
                {
                    return new SQLiteParameter(View_GroupStorageItemDT.ColumnNames.GroupName, DbType.String, 2147483647);
                }
            }

            public static SQLiteParameter ItemGroupID
            {
                get
                {
                    return new SQLiteParameter(View_GroupStorageItemDT.ColumnNames.ItemGroupID, DbType.Int64, 8);
                }
            }


        }
        #endregion


    }

    public partial class View_GroupStorageItemRow : DataRow
    {

        public View_GroupStorageItemRow(DataRowBuilder builder)
            : base(builder)
        {
        }
        public void Save()
        {

            if (this.RowState == DataRowState.Added || RowState == DataRowState.Detached)
            {
                SQLiteCommand insertCommand = ((View_GroupStorageItemDT)this.Table).GetInsertCommand();
                SetCommadValues(insertCommand);
                insertCommand.ExecuteNonQuery();
                if (((View_GroupStorageItemDT)this.Table)._identityCommand == null)
                {
                    ((View_GroupStorageItemDT)this.Table)._identityCommand = MyDbConnection.Instance.connection.CreateCommand();
                    ((View_GroupStorageItemDT)this.Table)._identityCommand.CommandText = "SELECT last_insert_rowid()";
                }
                base[View_GroupStorageItemDT.ColumnNames.ItemGroupID] = ((View_GroupStorageItemDT)this.Table)._identityCommand.ExecuteScalar();
                this.Table.Rows.Add(this);
                this.AcceptChanges();

            }
            else if (this.RowState == DataRowState.Modified)
            {
                SQLiteCommand updateCommand = ((View_GroupStorageItemDT)this.Table).GetUpdateCommand();
                SetCommadValues(updateCommand);
                updateCommand.ExecuteNonQuery();
                this.AcceptChanges();

            }
            else if (RowState == DataRowState.Deleted)
            {
                SQLiteCommand deleteCommand = ((View_GroupStorageItemDT)this.Table).GetDeleteCommand();
                deleteCommand.Parameters[View_GroupStorageItemDT.ColumnNames.StorageItemID].Value = base[View_GroupStorageItemDT.ColumnNames.StorageItemID];
                deleteCommand.Parameters[View_GroupStorageItemDT.ColumnNames.ItemGroupID].Value = base[View_GroupStorageItemDT.ColumnNames.ItemGroupID];
                deleteCommand.ExecuteNonQuery();
                this.AcceptChanges();
            }
        }
        public void DeleteView_GroupStorageItem()
        {
            SQLiteCommand deleteCommand = ((View_GroupStorageItemDT)this.Table).GetDeleteCommand();
            deleteCommand.Parameters[View_GroupStorageItemDT.ColumnNames.StorageItemID].Value = base[View_GroupStorageItemDT.ColumnNames.StorageItemID];
            deleteCommand.Parameters[View_GroupStorageItemDT.ColumnNames.ItemGroupID].Value = base[View_GroupStorageItemDT.ColumnNames.ItemGroupID];
            deleteCommand.ExecuteNonQuery();
            this.Table.Rows.Remove(this);
            //this.AcceptChanges();
        }
        private void SetCommadValues(SQLiteCommand command)
        {
            command.Parameters[View_GroupStorageItemDT.ColumnNames.StorageItemID].Value = base[View_GroupStorageItemDT.ColumnNames.StorageItemID];
            command.Parameters[View_GroupStorageItemDT.ColumnNames.ItemName].Value = base[View_GroupStorageItemDT.ColumnNames.ItemName];
            command.Parameters[View_GroupStorageItemDT.ColumnNames.Description].Value = base[View_GroupStorageItemDT.ColumnNames.Description];
            command.Parameters[View_GroupStorageItemDT.ColumnNames.FullPath].Value = base[View_GroupStorageItemDT.ColumnNames.FullPath];
            command.Parameters[View_GroupStorageItemDT.ColumnNames.GroupName].Value = base[View_GroupStorageItemDT.ColumnNames.GroupName];
            command.Parameters[View_GroupStorageItemDT.ColumnNames.ItemGroupID].Value = base[View_GroupStorageItemDT.ColumnNames.ItemGroupID];
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

        public virtual long StorageItemID
        {
            get
            {
                return (long)base[View_GroupStorageItemDT.ColumnNames.StorageItemID];
            }
            set
            {
                base[View_GroupStorageItemDT.ColumnNames.StorageItemID] = value;
            }
        }

        public virtual string ItemName
        {
            get
            {
                return (string)base[View_GroupStorageItemDT.ColumnNames.ItemName];
            }
            set
            {
                base[View_GroupStorageItemDT.ColumnNames.ItemName] = value;
            }
        }

        public virtual string Description
        {
            get
            {
                return (string)base[View_GroupStorageItemDT.ColumnNames.Description];
            }
            set
            {
                base[View_GroupStorageItemDT.ColumnNames.Description] = value;
            }
        }

        public virtual string FullPath
        {
            get
            {
                return (string)base[View_GroupStorageItemDT.ColumnNames.FullPath];
            }
            set
            {
                base[View_GroupStorageItemDT.ColumnNames.FullPath] = value;
            }
        }

        public virtual string GroupName
        {
            get
            {
                return (string)base[View_GroupStorageItemDT.ColumnNames.GroupName];
            }
            set
            {
                base[View_GroupStorageItemDT.ColumnNames.GroupName] = value;
            }
        }

        public virtual long ItemGroupID
        {
            get
            {
                return (long)base[View_GroupStorageItemDT.ColumnNames.ItemGroupID];
            }
            set
            {
                base[View_GroupStorageItemDT.ColumnNames.ItemGroupID] = value;
            }
        }



        #region String Properties

        public virtual string s_StorageItemID
        {
            get
            {
                return this.IsNull(View_GroupStorageItemDT.ColumnNames.StorageItemID) ? string.Empty : base[View_GroupStorageItemDT.ColumnNames.StorageItemID].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[View_GroupStorageItemDT.ColumnNames.StorageItemID] = DBNull.Value;
                else
                    base[View_GroupStorageItemDT.ColumnNames.StorageItemID] = Convert.ToInt64(value);
            }
        }

        public virtual string s_ItemName
        {
            get
            {
                return this.IsNull(View_GroupStorageItemDT.ColumnNames.ItemName) ? string.Empty : base[View_GroupStorageItemDT.ColumnNames.ItemName].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[View_GroupStorageItemDT.ColumnNames.ItemName] = DBNull.Value;
                else
                    base[View_GroupStorageItemDT.ColumnNames.ItemName] = (value);
            }
        }

        public virtual string s_Description
        {
            get
            {
                return this.IsNull(View_GroupStorageItemDT.ColumnNames.Description) ? string.Empty : base[View_GroupStorageItemDT.ColumnNames.Description].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[View_GroupStorageItemDT.ColumnNames.Description] = DBNull.Value;
                else
                    base[View_GroupStorageItemDT.ColumnNames.Description] = (value);
            }
        }

        public virtual string s_FullPath
        {
            get
            {
                return this.IsNull(View_GroupStorageItemDT.ColumnNames.FullPath) ? string.Empty : base[View_GroupStorageItemDT.ColumnNames.FullPath].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[View_GroupStorageItemDT.ColumnNames.FullPath] = DBNull.Value;
                else
                    base[View_GroupStorageItemDT.ColumnNames.FullPath] = (value);
            }
        }

        public virtual string s_GroupName
        {
            get
            {
                return this.IsNull(View_GroupStorageItemDT.ColumnNames.GroupName) ? string.Empty : base[View_GroupStorageItemDT.ColumnNames.GroupName].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[View_GroupStorageItemDT.ColumnNames.GroupName] = DBNull.Value;
                else
                    base[View_GroupStorageItemDT.ColumnNames.GroupName] = (value);
            }
        }

        public virtual string s_ItemGroupID
        {
            get
            {
                return this.IsNull(View_GroupStorageItemDT.ColumnNames.ItemGroupID) ? string.Empty : base[View_GroupStorageItemDT.ColumnNames.ItemGroupID].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[View_GroupStorageItemDT.ColumnNames.ItemGroupID] = DBNull.Value;
                else
                    base[View_GroupStorageItemDT.ColumnNames.ItemGroupID] = Convert.ToInt64(value);
            }
        }


        #endregion
    }

}



