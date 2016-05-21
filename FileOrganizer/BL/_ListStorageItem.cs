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
    public partial class ListStorageItemDT : MyEntity
    {
        private static ListStorageItemDT defaultListStorageItemDT;
        SQLiteCommand _insertCommand;
        SQLiteCommand _updateCommand;
        SQLiteCommand _deleteCommand;
        public SQLiteCommand _identityCommand;

        public ListStorageItemDT()
            : base()
        {
            base.QuerySource = "[ListStorageItem]";

        }
        public virtual bool LoadByPrimaryKey(long ListID, long StorageItemID)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(ListStorageItemDT.Parameters.ListID, ListID);
            parameters.Add(ListStorageItemDT.Parameters.StorageItemID, StorageItemID);
            return base.LoadFromSql("SELECT * FROM [ListStorageItem] WHERE (ListID=@ListID) AND (StorageItemID=@StorageItemID)", parameters, CommandType.Text);
        }

        public void LoadAll()
        {
            if (_selectCommand == null)
            {
                _selectCommand = MyDbConnection.Instance.connection.CreateCommand();
                _adapter = new SQLiteDataAdapter(_selectCommand);
            }
            _selectCommand.CommandText = "SELECT * FROM [ListStorageItem]";
            _selectCommand.CommandType = CommandType.Text;
            this.Clear();
            _adapter.Fill(this);
        }
        public SQLiteCommand GetInsertCommand()
        {
            if (_insertCommand == null)
            {
                _insertCommand = MyDbConnection.Instance.connection.CreateCommand();
                _insertCommand.CommandText = "INSERT INTO ListStorageItem ([ListID],[StorageItemID],[Color])VALUES (@ListID,@StorageItemID,@Color)";
                _insertCommand.CommandType = CommandType.Text;
                CreateParams(_insertCommand);

            }
            return _insertCommand;
        }
        private void CreateParams(SQLiteCommand command)
        {
            command.Parameters.Add(new SQLiteParameter(ColumnNames.ListID, DbType.Int64, 8, ColumnNames.ListID));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.StorageItemID, DbType.Int64, 8, ColumnNames.StorageItemID));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.Color, DbType.Int32, 4, ColumnNames.Color));
        }
        public SQLiteCommand GetUpdateCommand()
        {
            if (_updateCommand == null)
            {
                _updateCommand = MyDbConnection.Instance.connection.CreateCommand();
                _updateCommand.CommandText = "UPDATE ListStorageItem SET [Color] = @Color WHERE ([ListID] = @ListID) AND ([StorageItemID] = @StorageItemID)";
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
                _deleteCommand.CommandText = "DELETE FROM ListStorageItem WHERE ([ListID] = @ListID) AND ([StorageItemID] = @StorageItemID)";
                _deleteCommand.CommandType = CommandType.Text;
                _deleteCommand.Parameters.Add(new SQLiteParameter(ColumnNames.ListID, DbType.Int64, 8, ColumnNames.ListID));
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

        public static ListStorageItemDT GetDefaultListStorageItemDT()
        {
            if (defaultListStorageItemDT == null)
            {
                defaultListStorageItemDT = new ListStorageItemDT();
                MyDbConnection.Instance.FillDataTable(defaultListStorageItemDT, "SELECT * FROM [ListStorageItem] WHERE 1 > 1");
            }

            return defaultListStorageItemDT;
        }
        protected override Type GetRowType()
        {
            return typeof(ListStorageItemRow);
        }

        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new ListStorageItemRow(builder);
        }
        public ListStorageItemRow this[int idx]
        {
            get { return (ListStorageItemRow)Rows[idx]; }
        }
        public ListStorageItemRow NewListStorageItemRow()
        {
            return (ListStorageItemRow)base.NewRow();
        }
        public static ListStorageItemRow NewRowDefault()
        {
            if (defaultListStorageItemDT == null)
            {
                defaultListStorageItemDT = new ListStorageItemDT();
                MyDbConnection.Instance.FillDataTable(defaultListStorageItemDT, "SELECT * FROM [ListStorageItem] WHERE 1 > 1");
            }
            return (ListStorageItemRow)defaultListStorageItemDT.NewRow();
        }

        #region ColumnNames
        public class ColumnNames
        {
            public const string ListID = "ListID";
            public const string StorageItemID = "StorageItemID";
            public const string Color = "Color";
        }
        #endregion
        #region Parameters
        public class Parameters
        {

            public static SQLiteParameter ListID
            {
                get
                {
                    return new SQLiteParameter(ListStorageItemDT.ColumnNames.ListID, DbType.Int64, 8);
                }
            }

            public static SQLiteParameter StorageItemID
            {
                get
                {
                    return new SQLiteParameter(ListStorageItemDT.ColumnNames.StorageItemID, DbType.Int64, 8);
                }
            }

            public static SQLiteParameter Color
            {
                get
                {
                    return new SQLiteParameter(ListStorageItemDT.ColumnNames.Color, DbType.Int32, 4);
                }
            }


        }
        #endregion


    }

    public partial class ListStorageItemRow : DataRow
    {

        public ListStorageItemRow(DataRowBuilder builder)
            : base(builder)
        {
        }
        public void Save()
        {

            if (this.RowState == DataRowState.Added || RowState == DataRowState.Detached)
            {
                SQLiteCommand insertCommand = ((ListStorageItemDT)this.Table).GetInsertCommand();
                SetCommadValues(insertCommand);
                insertCommand.ExecuteNonQuery();
                if (((ListStorageItemDT)this.Table)._identityCommand == null)
                {
                    ((ListStorageItemDT)this.Table)._identityCommand = MyDbConnection.Instance.connection.CreateCommand();
                    ((ListStorageItemDT)this.Table)._identityCommand.CommandText = "SELECT last_insert_rowid()";
                }
                this.Table.Rows.Add(this);
                this.AcceptChanges();

            }
            else if (this.RowState == DataRowState.Modified)
            {
                SQLiteCommand updateCommand = ((ListStorageItemDT)this.Table).GetUpdateCommand();
                SetCommadValues(updateCommand);
                updateCommand.ExecuteNonQuery();
                this.AcceptChanges();

            }
            else if (RowState == DataRowState.Deleted)
            {
                SQLiteCommand deleteCommand = ((ListStorageItemDT)this.Table).GetDeleteCommand();
                deleteCommand.Parameters[ListStorageItemDT.ColumnNames.ListID].Value = base[ListStorageItemDT.ColumnNames.ListID];
                deleteCommand.Parameters[ListStorageItemDT.ColumnNames.StorageItemID].Value = base[ListStorageItemDT.ColumnNames.StorageItemID];
                deleteCommand.ExecuteNonQuery();
                this.AcceptChanges();
            }
        }
        public void DeleteListStorageItem()
        {
            SQLiteCommand deleteCommand = ((ListStorageItemDT)this.Table).GetDeleteCommand();
            deleteCommand.Parameters[ListStorageItemDT.ColumnNames.ListID].Value = base[ListStorageItemDT.ColumnNames.ListID];
            deleteCommand.Parameters[ListStorageItemDT.ColumnNames.StorageItemID].Value = base[ListStorageItemDT.ColumnNames.StorageItemID];
            deleteCommand.ExecuteNonQuery();
            this.Table.Rows.Remove(this);
            //this.AcceptChanges();
        }
        private void SetCommadValues(SQLiteCommand command)
        {
            command.Parameters[ListStorageItemDT.ColumnNames.ListID].Value = base[ListStorageItemDT.ColumnNames.ListID];
            command.Parameters[ListStorageItemDT.ColumnNames.StorageItemID].Value = base[ListStorageItemDT.ColumnNames.StorageItemID];
            command.Parameters[ListStorageItemDT.ColumnNames.Color].Value = base[ListStorageItemDT.ColumnNames.Color];
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

        public virtual long ListID
        {
            get
            {
                return (long)base[ListStorageItemDT.ColumnNames.ListID];
            }
            set
            {
                base[ListStorageItemDT.ColumnNames.ListID] = value;
            }
        }

        public virtual long StorageItemID
        {
            get
            {
                return (long)base[ListStorageItemDT.ColumnNames.StorageItemID];
            }
            set
            {
                base[ListStorageItemDT.ColumnNames.StorageItemID] = value;
            }
        }

        public virtual int Color
        {
            get
            {
                return (int)base[ListStorageItemDT.ColumnNames.Color];
            }
            set
            {
                base[ListStorageItemDT.ColumnNames.Color] = value;
            }
        }



        #region String Properties

        public virtual string s_ListID
        {
            get
            {
                return this.IsNull(ListStorageItemDT.ColumnNames.ListID) ? string.Empty : base[ListStorageItemDT.ColumnNames.ListID].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[ListStorageItemDT.ColumnNames.ListID] = DBNull.Value;
                else
                    base[ListStorageItemDT.ColumnNames.ListID] = Convert.ToInt64(value);
            }
        }

        public virtual string s_StorageItemID
        {
            get
            {
                return this.IsNull(ListStorageItemDT.ColumnNames.StorageItemID) ? string.Empty : base[ListStorageItemDT.ColumnNames.StorageItemID].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[ListStorageItemDT.ColumnNames.StorageItemID] = DBNull.Value;
                else
                    base[ListStorageItemDT.ColumnNames.StorageItemID] = Convert.ToInt64(value);
            }
        }

        public virtual string s_Color
        {
            get
            {
                return this.IsNull(ListStorageItemDT.ColumnNames.Color) ? string.Empty : base[ListStorageItemDT.ColumnNames.Color].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[ListStorageItemDT.ColumnNames.Color] = DBNull.Value;
                else
                    base[ListStorageItemDT.ColumnNames.Color] = Convert.ToInt32(value);
            }
        }


        #endregion
    }

}



