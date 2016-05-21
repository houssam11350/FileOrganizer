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
    public partial class View_RefStorageItemDT : MyEntity
    {
        private static View_RefStorageItemDT defaultView_RefStorageItemDT;
        SQLiteCommand _insertCommand;
        SQLiteCommand _updateCommand;
        SQLiteCommand _deleteCommand;
        public SQLiteCommand _identityCommand;

        public View_RefStorageItemDT()
            : base()
        {
            base.QuerySource = "[View_RefStorageItem]";

        }
        public virtual bool LoadByPrimaryKey(long MainStorageItemID, long RefStorageItemID)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(View_RefStorageItemDT.Parameters.MainStorageItemID, MainStorageItemID);
            parameters.Add(View_RefStorageItemDT.Parameters.RefStorageItemID, RefStorageItemID);
            return base.LoadFromSql("SELECT * FROM [View_RefStorageItem] WHERE (MainStorageItemID=@MainStorageItemID) AND (RefStorageItemID=@RefStorageItemID)", parameters, CommandType.Text);
        }

        public void LoadAll()
        {
            if (_selectCommand == null)
            {
                _selectCommand = MyDbConnection.Instance.connection.CreateCommand();
                _adapter = new SQLiteDataAdapter(_selectCommand);
            }
            _selectCommand.CommandText = "SELECT * FROM [View_RefStorageItem]";
            _selectCommand.CommandType = CommandType.Text;
            this.Clear();
            _adapter.Fill(this);
        }
        public SQLiteCommand GetInsertCommand()
        {
            if (_insertCommand == null)
            {
                _insertCommand = MyDbConnection.Instance.connection.CreateCommand();
                _insertCommand.CommandText = "INSERT INTO View_RefStorageItem ([MainItemName],[MainItemFullPath],[MainItemDesciption],[ItemName],[Size],[RefDesciption],[URL],[FullPath],[Priority],[PagesCount],[MainStorageItemID],[RefStorageItemID],[Description])VALUES (@MainItemName,@MainItemFullPath,@MainItemDesciption,@ItemName,@Size,@RefDesciption,@URL,@FullPath,@Priority,@PagesCount,@MainStorageItemID,@RefStorageItemID,@Description)";
                _insertCommand.CommandType = CommandType.Text;
                CreateParams(_insertCommand);

            }
            return _insertCommand;
        }
        private void CreateParams(SQLiteCommand command)
        {
            command.Parameters.Add(new SQLiteParameter(ColumnNames.MainItemName, DbType.String, 2147483647, ColumnNames.MainItemName));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.MainItemFullPath, DbType.String, 2147483647, ColumnNames.MainItemFullPath));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.MainItemDesciption, DbType.String, 2147483647, ColumnNames.MainItemDesciption));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.ItemName, DbType.String, 2147483647, ColumnNames.ItemName));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.Size, DbType.String, 2147483647, ColumnNames.Size));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.RefDesciption, DbType.String, 2147483647, ColumnNames.RefDesciption));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.URL, DbType.String, 2147483647, ColumnNames.URL));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.FullPath, DbType.String, 2147483647, ColumnNames.FullPath));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.Priority, DbType.Int64, 8, ColumnNames.Priority));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.PagesCount, DbType.Int64, 8, ColumnNames.PagesCount));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.MainStorageItemID, DbType.Int64, 8, ColumnNames.MainStorageItemID));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.RefStorageItemID, DbType.Int64, 8, ColumnNames.RefStorageItemID));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.Description, DbType.String, 2147483647, ColumnNames.Description));
        }
        public SQLiteCommand GetUpdateCommand()
        {
            if (_updateCommand == null)
            {
                _updateCommand = MyDbConnection.Instance.connection.CreateCommand();
                _updateCommand.CommandText = "UPDATE View_RefStorageItem SET [MainItemName] = @MainItemName,[MainItemFullPath] = @MainItemFullPath,[MainItemDesciption] = @MainItemDesciption,[ItemName] = @ItemName,[Size] = @Size,[RefDesciption] = @RefDesciption,[URL] = @URL,[FullPath] = @FullPath,[Priority] = @Priority,[PagesCount] = @PagesCount,[Description] = @Description WHERE ([MainStorageItemID] = @MainStorageItemID) AND ([RefStorageItemID] = @RefStorageItemID)";
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
                _deleteCommand.CommandText = "DELETE FROM View_RefStorageItem WHERE ([MainStorageItemID] = @MainStorageItemID) AND ([RefStorageItemID] = @RefStorageItemID)";
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

        public static View_RefStorageItemDT GetDefaultView_RefStorageItemDT()
        {
            if (defaultView_RefStorageItemDT == null)
            {
                defaultView_RefStorageItemDT = new View_RefStorageItemDT();
                MyDbConnection.Instance.FillDataTable(defaultView_RefStorageItemDT, "SELECT * FROM [View_RefStorageItem] WHERE 1 > 1");
            }

            return defaultView_RefStorageItemDT;
        }
        protected override Type GetRowType()
        {
            return typeof(View_RefStorageItemRow);
        }

        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new View_RefStorageItemRow(builder);
        }
        public View_RefStorageItemRow this[int idx]
        {
            get { return (View_RefStorageItemRow)Rows[idx]; }
        }
        public View_RefStorageItemRow NewView_RefStorageItemRow()
        {
            return (View_RefStorageItemRow)base.NewRow();
        }
        public static View_RefStorageItemRow NewRowDefault()
        {
            if (defaultView_RefStorageItemDT == null)
            {
                defaultView_RefStorageItemDT = new View_RefStorageItemDT();
                MyDbConnection.Instance.FillDataTable(defaultView_RefStorageItemDT, "SELECT * FROM [View_RefStorageItem] WHERE 1 > 1");
            }
            return (View_RefStorageItemRow)defaultView_RefStorageItemDT.NewRow();
        }

        #region ColumnNames
        public class ColumnNames
        {
            public const string MainItemName = "MainItemName";
            public const string MainItemFullPath = "MainItemFullPath";
            public const string MainItemDesciption = "MainItemDesciption";
            public const string ItemName = "ItemName";
            public const string Size = "Size";
            public const string RefDesciption = "RefDesciption";
            public const string URL = "URL";
            public const string FullPath = "FullPath";
            public const string Priority = "Priority";
            public const string PagesCount = "PagesCount";
            public const string MainStorageItemID = "MainStorageItemID";
            public const string RefStorageItemID = "RefStorageItemID";
            public const string Description = "Description";
        }
        #endregion
        #region Parameters
        public class Parameters
        {

            public static SQLiteParameter MainItemName
            {
                get
                {
                    return new SQLiteParameter(View_RefStorageItemDT.ColumnNames.MainItemName, DbType.String, 2147483647);
                }
            }

            public static SQLiteParameter MainItemFullPath
            {
                get
                {
                    return new SQLiteParameter(View_RefStorageItemDT.ColumnNames.MainItemFullPath, DbType.String, 2147483647);
                }
            }

            public static SQLiteParameter MainItemDesciption
            {
                get
                {
                    return new SQLiteParameter(View_RefStorageItemDT.ColumnNames.MainItemDesciption, DbType.String, 2147483647);
                }
            }

            public static SQLiteParameter ItemName
            {
                get
                {
                    return new SQLiteParameter(View_RefStorageItemDT.ColumnNames.ItemName, DbType.String, 2147483647);
                }
            }

            public static SQLiteParameter Size
            {
                get
                {
                    return new SQLiteParameter(View_RefStorageItemDT.ColumnNames.Size, DbType.String, 2147483647);
                }
            }

            public static SQLiteParameter RefDesciption
            {
                get
                {
                    return new SQLiteParameter(View_RefStorageItemDT.ColumnNames.RefDesciption, DbType.String, 2147483647);
                }
            }

            public static SQLiteParameter URL
            {
                get
                {
                    return new SQLiteParameter(View_RefStorageItemDT.ColumnNames.URL, DbType.String, 2147483647);
                }
            }

            public static SQLiteParameter FullPath
            {
                get
                {
                    return new SQLiteParameter(View_RefStorageItemDT.ColumnNames.FullPath, DbType.String, 2147483647);
                }
            }

            public static SQLiteParameter Priority
            {
                get
                {
                    return new SQLiteParameter(View_RefStorageItemDT.ColumnNames.Priority, DbType.Int64, 8);
                }
            }

            public static SQLiteParameter PagesCount
            {
                get
                {
                    return new SQLiteParameter(View_RefStorageItemDT.ColumnNames.PagesCount, DbType.Int64, 8);
                }
            }

            public static SQLiteParameter MainStorageItemID
            {
                get
                {
                    return new SQLiteParameter(View_RefStorageItemDT.ColumnNames.MainStorageItemID, DbType.Int64, 8);
                }
            }

            public static SQLiteParameter RefStorageItemID
            {
                get
                {
                    return new SQLiteParameter(View_RefStorageItemDT.ColumnNames.RefStorageItemID, DbType.Int64, 8);
                }
            }

            public static SQLiteParameter Description
            {
                get
                {
                    return new SQLiteParameter(View_RefStorageItemDT.ColumnNames.Description, DbType.String, 2147483647);
                }
            }


        }
        #endregion


    }

    public partial class View_RefStorageItemRow : DataRow
    {

        public View_RefStorageItemRow(DataRowBuilder builder)
            : base(builder)
        {
        }
        public void Save()
        {

            if (this.RowState == DataRowState.Added || RowState == DataRowState.Detached)
            {
                SQLiteCommand insertCommand = ((View_RefStorageItemDT)this.Table).GetInsertCommand();
                SetCommadValues(insertCommand);
                insertCommand.ExecuteNonQuery();
                if (((View_RefStorageItemDT)this.Table)._identityCommand == null)
                {
                    ((View_RefStorageItemDT)this.Table)._identityCommand = MyDbConnection.Instance.connection.CreateCommand();
                    ((View_RefStorageItemDT)this.Table)._identityCommand.CommandText = "SELECT last_insert_rowid()";
                }
                this.Table.Rows.Add(this);
                this.AcceptChanges();

            }
            else if (this.RowState == DataRowState.Modified)
            {
                SQLiteCommand updateCommand = ((View_RefStorageItemDT)this.Table).GetUpdateCommand();
                SetCommadValues(updateCommand);
                updateCommand.ExecuteNonQuery();
                this.AcceptChanges();

            }
            else if (RowState == DataRowState.Deleted)
            {
                SQLiteCommand deleteCommand = ((View_RefStorageItemDT)this.Table).GetDeleteCommand();
                deleteCommand.Parameters[View_RefStorageItemDT.ColumnNames.MainStorageItemID].Value = base[View_RefStorageItemDT.ColumnNames.MainStorageItemID];
                deleteCommand.Parameters[View_RefStorageItemDT.ColumnNames.RefStorageItemID].Value = base[View_RefStorageItemDT.ColumnNames.RefStorageItemID];
                deleteCommand.ExecuteNonQuery();
                this.AcceptChanges();
            }
        }
        public void DeleteView_RefStorageItem()
        {
            SQLiteCommand deleteCommand = ((View_RefStorageItemDT)this.Table).GetDeleteCommand();
            deleteCommand.Parameters[View_RefStorageItemDT.ColumnNames.MainStorageItemID].Value = base[View_RefStorageItemDT.ColumnNames.MainStorageItemID];
            deleteCommand.Parameters[View_RefStorageItemDT.ColumnNames.RefStorageItemID].Value = base[View_RefStorageItemDT.ColumnNames.RefStorageItemID];
            deleteCommand.ExecuteNonQuery();
            this.Table.Rows.Remove(this);
            //this.AcceptChanges();
        }
        private void SetCommadValues(SQLiteCommand command)
        {
            command.Parameters[View_RefStorageItemDT.ColumnNames.MainItemName].Value = base[View_RefStorageItemDT.ColumnNames.MainItemName];
            command.Parameters[View_RefStorageItemDT.ColumnNames.MainItemFullPath].Value = base[View_RefStorageItemDT.ColumnNames.MainItemFullPath];
            command.Parameters[View_RefStorageItemDT.ColumnNames.MainItemDesciption].Value = base[View_RefStorageItemDT.ColumnNames.MainItemDesciption];
            command.Parameters[View_RefStorageItemDT.ColumnNames.ItemName].Value = base[View_RefStorageItemDT.ColumnNames.ItemName];
            command.Parameters[View_RefStorageItemDT.ColumnNames.Size].Value = base[View_RefStorageItemDT.ColumnNames.Size];
            command.Parameters[View_RefStorageItemDT.ColumnNames.RefDesciption].Value = base[View_RefStorageItemDT.ColumnNames.RefDesciption];
            command.Parameters[View_RefStorageItemDT.ColumnNames.URL].Value = base[View_RefStorageItemDT.ColumnNames.URL];
            command.Parameters[View_RefStorageItemDT.ColumnNames.FullPath].Value = base[View_RefStorageItemDT.ColumnNames.FullPath];
            command.Parameters[View_RefStorageItemDT.ColumnNames.Priority].Value = base[View_RefStorageItemDT.ColumnNames.Priority];
            command.Parameters[View_RefStorageItemDT.ColumnNames.PagesCount].Value = base[View_RefStorageItemDT.ColumnNames.PagesCount];
            command.Parameters[View_RefStorageItemDT.ColumnNames.MainStorageItemID].Value = base[View_RefStorageItemDT.ColumnNames.MainStorageItemID];
            command.Parameters[View_RefStorageItemDT.ColumnNames.RefStorageItemID].Value = base[View_RefStorageItemDT.ColumnNames.RefStorageItemID];
            command.Parameters[View_RefStorageItemDT.ColumnNames.Description].Value = base[View_RefStorageItemDT.ColumnNames.Description];
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

        public virtual string MainItemName
        {
            get
            {
                return (string)base[View_RefStorageItemDT.ColumnNames.MainItemName];
            }
            set
            {
                base[View_RefStorageItemDT.ColumnNames.MainItemName] = value;
            }
        }

        public virtual string MainItemFullPath
        {
            get
            {
                return (string)base[View_RefStorageItemDT.ColumnNames.MainItemFullPath];
            }
            set
            {
                base[View_RefStorageItemDT.ColumnNames.MainItemFullPath] = value;
            }
        }

        public virtual string MainItemDesciption
        {
            get
            {
                return (string)base[View_RefStorageItemDT.ColumnNames.MainItemDesciption];
            }
            set
            {
                base[View_RefStorageItemDT.ColumnNames.MainItemDesciption] = value;
            }
        }

        public virtual string ItemName
        {
            get
            {
                return (string)base[View_RefStorageItemDT.ColumnNames.ItemName];
            }
            set
            {
                base[View_RefStorageItemDT.ColumnNames.ItemName] = value;
            }
        }

        public virtual string Size
        {
            get
            {
                return (string)base[View_RefStorageItemDT.ColumnNames.Size];
            }
            set
            {
                base[View_RefStorageItemDT.ColumnNames.Size] = value;
            }
        }

        public virtual string RefDesciption
        {
            get
            {
                return (string)base[View_RefStorageItemDT.ColumnNames.RefDesciption];
            }
            set
            {
                base[View_RefStorageItemDT.ColumnNames.RefDesciption] = value;
            }
        }

        public virtual string URL
        {
            get
            {
                return (string)base[View_RefStorageItemDT.ColumnNames.URL];
            }
            set
            {
                base[View_RefStorageItemDT.ColumnNames.URL] = value;
            }
        }

        public virtual string FullPath
        {
            get
            {
                return (string)base[View_RefStorageItemDT.ColumnNames.FullPath];
            }
            set
            {
                base[View_RefStorageItemDT.ColumnNames.FullPath] = value;
            }
        }

        public virtual long Priority
        {
            get
            {
                return (long)base[View_RefStorageItemDT.ColumnNames.Priority];
            }
            set
            {
                base[View_RefStorageItemDT.ColumnNames.Priority] = value;
            }
        }

        public virtual long PagesCount
        {
            get
            {
                return (long)base[View_RefStorageItemDT.ColumnNames.PagesCount];
            }
            set
            {
                base[View_RefStorageItemDT.ColumnNames.PagesCount] = value;
            }
        }

        public virtual long MainStorageItemID
        {
            get
            {
                return (long)base[View_RefStorageItemDT.ColumnNames.MainStorageItemID];
            }
            set
            {
                base[View_RefStorageItemDT.ColumnNames.MainStorageItemID] = value;
            }
        }

        public virtual long RefStorageItemID
        {
            get
            {
                return (long)base[View_RefStorageItemDT.ColumnNames.RefStorageItemID];
            }
            set
            {
                base[View_RefStorageItemDT.ColumnNames.RefStorageItemID] = value;
            }
        }

        public virtual string Description
        {
            get
            {
                return (string)base[View_RefStorageItemDT.ColumnNames.Description];
            }
            set
            {
                base[View_RefStorageItemDT.ColumnNames.Description] = value;
            }
        }



        #region String Properties

        public virtual string s_MainItemName
        {
            get
            {
                return this.IsNull(View_RefStorageItemDT.ColumnNames.MainItemName) ? string.Empty : base[View_RefStorageItemDT.ColumnNames.MainItemName].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[View_RefStorageItemDT.ColumnNames.MainItemName] = DBNull.Value;
                else
                    base[View_RefStorageItemDT.ColumnNames.MainItemName] = (value);
            }
        }

        public virtual string s_MainItemFullPath
        {
            get
            {
                return this.IsNull(View_RefStorageItemDT.ColumnNames.MainItemFullPath) ? string.Empty : base[View_RefStorageItemDT.ColumnNames.MainItemFullPath].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[View_RefStorageItemDT.ColumnNames.MainItemFullPath] = DBNull.Value;
                else
                    base[View_RefStorageItemDT.ColumnNames.MainItemFullPath] = (value);
            }
        }

        public virtual string s_MainItemDesciption
        {
            get
            {
                return this.IsNull(View_RefStorageItemDT.ColumnNames.MainItemDesciption) ? string.Empty : base[View_RefStorageItemDT.ColumnNames.MainItemDesciption].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[View_RefStorageItemDT.ColumnNames.MainItemDesciption] = DBNull.Value;
                else
                    base[View_RefStorageItemDT.ColumnNames.MainItemDesciption] = (value);
            }
        }

        public virtual string s_ItemName
        {
            get
            {
                return this.IsNull(View_RefStorageItemDT.ColumnNames.ItemName) ? string.Empty : base[View_RefStorageItemDT.ColumnNames.ItemName].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[View_RefStorageItemDT.ColumnNames.ItemName] = DBNull.Value;
                else
                    base[View_RefStorageItemDT.ColumnNames.ItemName] = (value);
            }
        }

        public virtual string s_Size
        {
            get
            {
                return this.IsNull(View_RefStorageItemDT.ColumnNames.Size) ? string.Empty : base[View_RefStorageItemDT.ColumnNames.Size].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[View_RefStorageItemDT.ColumnNames.Size] = DBNull.Value;
                else
                    base[View_RefStorageItemDT.ColumnNames.Size] = (value);
            }
        }

        public virtual string s_RefDesciption
        {
            get
            {
                return this.IsNull(View_RefStorageItemDT.ColumnNames.RefDesciption) ? string.Empty : base[View_RefStorageItemDT.ColumnNames.RefDesciption].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[View_RefStorageItemDT.ColumnNames.RefDesciption] = DBNull.Value;
                else
                    base[View_RefStorageItemDT.ColumnNames.RefDesciption] = (value);
            }
        }

        public virtual string s_URL
        {
            get
            {
                return this.IsNull(View_RefStorageItemDT.ColumnNames.URL) ? string.Empty : base[View_RefStorageItemDT.ColumnNames.URL].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[View_RefStorageItemDT.ColumnNames.URL] = DBNull.Value;
                else
                    base[View_RefStorageItemDT.ColumnNames.URL] = (value);
            }
        }

        public virtual string s_FullPath
        {
            get
            {
                return this.IsNull(View_RefStorageItemDT.ColumnNames.FullPath) ? string.Empty : base[View_RefStorageItemDT.ColumnNames.FullPath].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[View_RefStorageItemDT.ColumnNames.FullPath] = DBNull.Value;
                else
                    base[View_RefStorageItemDT.ColumnNames.FullPath] = (value);
            }
        }

        public virtual string s_Priority
        {
            get
            {
                return this.IsNull(View_RefStorageItemDT.ColumnNames.Priority) ? string.Empty : base[View_RefStorageItemDT.ColumnNames.Priority].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[View_RefStorageItemDT.ColumnNames.Priority] = DBNull.Value;
                else
                    base[View_RefStorageItemDT.ColumnNames.Priority] = Convert.ToInt64(value);
            }
        }

        public virtual string s_PagesCount
        {
            get
            {
                return this.IsNull(View_RefStorageItemDT.ColumnNames.PagesCount) ? string.Empty : base[View_RefStorageItemDT.ColumnNames.PagesCount].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[View_RefStorageItemDT.ColumnNames.PagesCount] = DBNull.Value;
                else
                    base[View_RefStorageItemDT.ColumnNames.PagesCount] = Convert.ToInt64(value);
            }
        }

        public virtual string s_MainStorageItemID
        {
            get
            {
                return this.IsNull(View_RefStorageItemDT.ColumnNames.MainStorageItemID) ? string.Empty : base[View_RefStorageItemDT.ColumnNames.MainStorageItemID].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[View_RefStorageItemDT.ColumnNames.MainStorageItemID] = DBNull.Value;
                else
                    base[View_RefStorageItemDT.ColumnNames.MainStorageItemID] = Convert.ToInt64(value);
            }
        }

        public virtual string s_RefStorageItemID
        {
            get
            {
                return this.IsNull(View_RefStorageItemDT.ColumnNames.RefStorageItemID) ? string.Empty : base[View_RefStorageItemDT.ColumnNames.RefStorageItemID].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[View_RefStorageItemDT.ColumnNames.RefStorageItemID] = DBNull.Value;
                else
                    base[View_RefStorageItemDT.ColumnNames.RefStorageItemID] = Convert.ToInt64(value);
            }
        }

        public virtual string s_Description
        {
            get
            {
                return this.IsNull(View_RefStorageItemDT.ColumnNames.Description) ? string.Empty : base[View_RefStorageItemDT.ColumnNames.Description].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[View_RefStorageItemDT.ColumnNames.Description] = DBNull.Value;
                else
                    base[View_RefStorageItemDT.ColumnNames.Description] = (value);
            }
        }


        #endregion
    }

}



