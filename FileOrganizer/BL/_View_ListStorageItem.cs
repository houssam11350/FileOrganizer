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
    public partial class View_ListStorageItemDT : MyEntity
    {
        private static View_ListStorageItemDT defaultView_ListStorageItemDT;
        SQLiteCommand _insertCommand;
        SQLiteCommand _updateCommand;
        SQLiteCommand _deleteCommand;
        public SQLiteCommand _identityCommand;

        public View_ListStorageItemDT()
            : base()
        {
            base.QuerySource = "[View_ListStorageItem]";

        }
        public virtual bool LoadByPrimaryKey(long StorageItemID, long ListID)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(View_ListStorageItemDT.Parameters.StorageItemID, StorageItemID);
            parameters.Add(View_ListStorageItemDT.Parameters.ListID, ListID);
            return base.LoadFromSql("SELECT * FROM [View_ListStorageItem] WHERE (StorageItemID=@StorageItemID) AND (ListID=@ListID)", parameters, CommandType.Text);
        }

        public void LoadAll()
        {
            if (_selectCommand == null)
            {
                _selectCommand = MyDbConnection.Instance.connection.CreateCommand();
                _adapter = new SQLiteDataAdapter(_selectCommand);
            }
            _selectCommand.CommandText = "SELECT * FROM [View_ListStorageItem]";
            _selectCommand.CommandType = CommandType.Text;
            this.Clear();
            _adapter.Fill(this);
        }
        public SQLiteCommand GetInsertCommand()
        {
            if (_insertCommand == null)
            {
                _insertCommand = MyDbConnection.Instance.connection.CreateCommand();
                _insertCommand.CommandText = "INSERT INTO View_ListStorageItem ([ItemName],[Description],[FullPath],[ListID],[LName],[Color])VALUES (@ItemName,@Description,@FullPath,@ListID,@LName,@Color)";
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
            command.Parameters.Add(new SQLiteParameter(ColumnNames.ListID, DbType.Int64, 8, ColumnNames.ListID));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.LName, DbType.String, 2147483647, ColumnNames.LName));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.Color, DbType.Int32, 4, ColumnNames.Color));
        }
        public SQLiteCommand GetUpdateCommand()
        {
            if (_updateCommand == null)
            {
                _updateCommand = MyDbConnection.Instance.connection.CreateCommand();
                _updateCommand.CommandText = "UPDATE View_ListStorageItem SET [ItemName] = @ItemName,[Description] = @Description,[FullPath] = @FullPath,[LName] = @LName,[Color] = @Color WHERE ([StorageItemID] = @StorageItemID) AND ([ListID] = @ListID)";
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
                _deleteCommand.CommandText = "DELETE FROM View_ListStorageItem WHERE ([StorageItemID] = @StorageItemID) AND ([ListID] = @ListID)";
                _deleteCommand.CommandType = CommandType.Text;
                _deleteCommand.Parameters.Add(new SQLiteParameter(ColumnNames.StorageItemID, DbType.Int64, 8, ColumnNames.StorageItemID));
                _deleteCommand.Parameters.Add(new SQLiteParameter(ColumnNames.ListID, DbType.Int64, 8, ColumnNames.ListID));
            }
            return _deleteCommand;
        }
        #region @@IDENTITY Logic
        // Overloaded in the generated class
        public virtual string GetAutoKeyColumn()
        {
            return View_ListStorageItemDT.ColumnNames.StorageItemID;
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

        public static View_ListStorageItemDT GetDefaultView_ListStorageItemDT()
        {
            if (defaultView_ListStorageItemDT == null)
            {
                defaultView_ListStorageItemDT = new View_ListStorageItemDT();
                MyDbConnection.Instance.FillDataTable(defaultView_ListStorageItemDT, "SELECT * FROM [View_ListStorageItem] WHERE 1 > 1");
            }

            return defaultView_ListStorageItemDT;
        }
        protected override Type GetRowType()
        {
            return typeof(View_ListStorageItemRow);
        }

        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new View_ListStorageItemRow(builder);
        }
        public View_ListStorageItemRow this[int idx]
        {
            get { return (View_ListStorageItemRow)Rows[idx]; }
        }
        public View_ListStorageItemRow NewView_ListStorageItemRow()
        {
            return (View_ListStorageItemRow)base.NewRow();
        }
        public static View_ListStorageItemRow NewRowDefault()
        {
            if (defaultView_ListStorageItemDT == null)
            {
                defaultView_ListStorageItemDT = new View_ListStorageItemDT();
                MyDbConnection.Instance.FillDataTable(defaultView_ListStorageItemDT, "SELECT * FROM [View_ListStorageItem] WHERE 1 > 1");
            }
            return (View_ListStorageItemRow)defaultView_ListStorageItemDT.NewRow();
        }

        #region ColumnNames
        public class ColumnNames
        {
            public const string StorageItemID = "StorageItemID";
            public const string ItemName = "ItemName";
            public const string Description = "Description";
            public const string FullPath = "FullPath";
            public const string ListID = "ListID";
            public const string LName = "LName";
            public const string Color = "Color";
        }
        #endregion
        #region Parameters
        public class Parameters
        {

            public static SQLiteParameter StorageItemID
            {
                get
                {
                    return new SQLiteParameter(View_ListStorageItemDT.ColumnNames.StorageItemID, DbType.Int64, 8);
                }
            }

            public static SQLiteParameter ItemName
            {
                get
                {
                    return new SQLiteParameter(View_ListStorageItemDT.ColumnNames.ItemName, DbType.String, 2147483647);
                }
            }

            public static SQLiteParameter Description
            {
                get
                {
                    return new SQLiteParameter(View_ListStorageItemDT.ColumnNames.Description, DbType.String, 2147483647);
                }
            }

            public static SQLiteParameter FullPath
            {
                get
                {
                    return new SQLiteParameter(View_ListStorageItemDT.ColumnNames.FullPath, DbType.String, 2147483647);
                }
            }

            public static SQLiteParameter ListID
            {
                get
                {
                    return new SQLiteParameter(View_ListStorageItemDT.ColumnNames.ListID, DbType.Int64, 8);
                }
            }

            public static SQLiteParameter LName
            {
                get
                {
                    return new SQLiteParameter(View_ListStorageItemDT.ColumnNames.LName, DbType.String, 2147483647);
                }
            }

            public static SQLiteParameter Color
            {
                get
                {
                    return new SQLiteParameter(View_ListStorageItemDT.ColumnNames.Color, DbType.Int32, 4);
                }
            }


        }
        #endregion


    }

    public partial class View_ListStorageItemRow : DataRow
    {

        public View_ListStorageItemRow(DataRowBuilder builder)
            : base(builder)
        {
        }
        public void Save()
        {

            if (this.RowState == DataRowState.Added || RowState == DataRowState.Detached)
            {
                SQLiteCommand insertCommand = ((View_ListStorageItemDT)this.Table).GetInsertCommand();
                SetCommadValues(insertCommand);
                insertCommand.ExecuteNonQuery();
                if (((View_ListStorageItemDT)this.Table)._identityCommand == null)
                {
                    ((View_ListStorageItemDT)this.Table)._identityCommand = MyDbConnection.Instance.connection.CreateCommand();
                    ((View_ListStorageItemDT)this.Table)._identityCommand.CommandText = "SELECT last_insert_rowid()";
                }
                base[View_ListStorageItemDT.ColumnNames.StorageItemID] = ((View_ListStorageItemDT)this.Table)._identityCommand.ExecuteScalar();
                this.Table.Rows.Add(this);
                this.AcceptChanges();

            }
            else if (this.RowState == DataRowState.Modified)
            {
                SQLiteCommand updateCommand = ((View_ListStorageItemDT)this.Table).GetUpdateCommand();
                SetCommadValues(updateCommand);
                updateCommand.ExecuteNonQuery();
                this.AcceptChanges();

            }
            else if (RowState == DataRowState.Deleted)
            {
                SQLiteCommand deleteCommand = ((View_ListStorageItemDT)this.Table).GetDeleteCommand();
                deleteCommand.Parameters[View_ListStorageItemDT.ColumnNames.StorageItemID].Value = base[View_ListStorageItemDT.ColumnNames.StorageItemID];
                deleteCommand.Parameters[View_ListStorageItemDT.ColumnNames.ListID].Value = base[View_ListStorageItemDT.ColumnNames.ListID];
                deleteCommand.ExecuteNonQuery();
                this.AcceptChanges();
            }
        }
        public void DeleteView_ListStorageItem()
        {
            SQLiteCommand deleteCommand = ((View_ListStorageItemDT)this.Table).GetDeleteCommand();
            deleteCommand.Parameters[View_ListStorageItemDT.ColumnNames.StorageItemID].Value = base[View_ListStorageItemDT.ColumnNames.StorageItemID];
            deleteCommand.Parameters[View_ListStorageItemDT.ColumnNames.ListID].Value = base[View_ListStorageItemDT.ColumnNames.ListID];
            deleteCommand.ExecuteNonQuery();
            this.Table.Rows.Remove(this);
            //this.AcceptChanges();
        }
        private void SetCommadValues(SQLiteCommand command)
        {
            command.Parameters[View_ListStorageItemDT.ColumnNames.StorageItemID].Value = base[View_ListStorageItemDT.ColumnNames.StorageItemID];
            command.Parameters[View_ListStorageItemDT.ColumnNames.ItemName].Value = base[View_ListStorageItemDT.ColumnNames.ItemName];
            command.Parameters[View_ListStorageItemDT.ColumnNames.Description].Value = base[View_ListStorageItemDT.ColumnNames.Description];
            command.Parameters[View_ListStorageItemDT.ColumnNames.FullPath].Value = base[View_ListStorageItemDT.ColumnNames.FullPath];
            command.Parameters[View_ListStorageItemDT.ColumnNames.ListID].Value = base[View_ListStorageItemDT.ColumnNames.ListID];
            command.Parameters[View_ListStorageItemDT.ColumnNames.LName].Value = base[View_ListStorageItemDT.ColumnNames.LName];
            command.Parameters[View_ListStorageItemDT.ColumnNames.Color].Value = base[View_ListStorageItemDT.ColumnNames.Color];
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
                return (long)base[View_ListStorageItemDT.ColumnNames.StorageItemID];
            }
            set
            {
                base[View_ListStorageItemDT.ColumnNames.StorageItemID] = value;
            }
        }

        public virtual string ItemName
        {
            get
            {
                return (string)base[View_ListStorageItemDT.ColumnNames.ItemName];
            }
            set
            {
                base[View_ListStorageItemDT.ColumnNames.ItemName] = value;
            }
        }

        public virtual string Description
        {
            get
            {
                return (string)base[View_ListStorageItemDT.ColumnNames.Description];
            }
            set
            {
                base[View_ListStorageItemDT.ColumnNames.Description] = value;
            }
        }

        public virtual string FullPath
        {
            get
            {
                return (string)base[View_ListStorageItemDT.ColumnNames.FullPath];
            }
            set
            {
                base[View_ListStorageItemDT.ColumnNames.FullPath] = value;
            }
        }

        public virtual long ListID
        {
            get
            {
                return (long)base[View_ListStorageItemDT.ColumnNames.ListID];
            }
            set
            {
                base[View_ListStorageItemDT.ColumnNames.ListID] = value;
            }
        }

        public virtual string LName
        {
            get
            {
                return (string)base[View_ListStorageItemDT.ColumnNames.LName];
            }
            set
            {
                base[View_ListStorageItemDT.ColumnNames.LName] = value;
            }
        }

        public virtual int Color
        {
            get
            {
                return (int)base[View_ListStorageItemDT.ColumnNames.Color];
            }
            set
            {
                base[View_ListStorageItemDT.ColumnNames.Color] = value;
            }
        }



        #region String Properties

        public virtual string s_StorageItemID
        {
            get
            {
                return this.IsNull(View_ListStorageItemDT.ColumnNames.StorageItemID) ? string.Empty : base[View_ListStorageItemDT.ColumnNames.StorageItemID].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[View_ListStorageItemDT.ColumnNames.StorageItemID] = DBNull.Value;
                else
                    base[View_ListStorageItemDT.ColumnNames.StorageItemID] = Convert.ToInt64(value);
            }
        }

        public virtual string s_ItemName
        {
            get
            {
                return this.IsNull(View_ListStorageItemDT.ColumnNames.ItemName) ? string.Empty : base[View_ListStorageItemDT.ColumnNames.ItemName].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[View_ListStorageItemDT.ColumnNames.ItemName] = DBNull.Value;
                else
                    base[View_ListStorageItemDT.ColumnNames.ItemName] = (value);
            }
        }

        public virtual string s_Description
        {
            get
            {
                return this.IsNull(View_ListStorageItemDT.ColumnNames.Description) ? string.Empty : base[View_ListStorageItemDT.ColumnNames.Description].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[View_ListStorageItemDT.ColumnNames.Description] = DBNull.Value;
                else
                    base[View_ListStorageItemDT.ColumnNames.Description] = (value);
            }
        }

        public virtual string s_FullPath
        {
            get
            {
                return this.IsNull(View_ListStorageItemDT.ColumnNames.FullPath) ? string.Empty : base[View_ListStorageItemDT.ColumnNames.FullPath].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[View_ListStorageItemDT.ColumnNames.FullPath] = DBNull.Value;
                else
                    base[View_ListStorageItemDT.ColumnNames.FullPath] = (value);
            }
        }

        public virtual string s_ListID
        {
            get
            {
                return this.IsNull(View_ListStorageItemDT.ColumnNames.ListID) ? string.Empty : base[View_ListStorageItemDT.ColumnNames.ListID].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[View_ListStorageItemDT.ColumnNames.ListID] = DBNull.Value;
                else
                    base[View_ListStorageItemDT.ColumnNames.ListID] = Convert.ToInt64(value);
            }
        }

        public virtual string s_LName
        {
            get
            {
                return this.IsNull(View_ListStorageItemDT.ColumnNames.LName) ? string.Empty : base[View_ListStorageItemDT.ColumnNames.LName].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[View_ListStorageItemDT.ColumnNames.LName] = DBNull.Value;
                else
                    base[View_ListStorageItemDT.ColumnNames.LName] = (value);
            }
        }

        public virtual string s_Color
        {
            get
            {
                return this.IsNull(View_ListStorageItemDT.ColumnNames.Color) ? string.Empty : base[View_ListStorageItemDT.ColumnNames.Color].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[View_ListStorageItemDT.ColumnNames.Color] = DBNull.Value;
                else
                    base[View_ListStorageItemDT.ColumnNames.Color] = Convert.ToInt32(value);
            }
        }


        #endregion
    }

}



