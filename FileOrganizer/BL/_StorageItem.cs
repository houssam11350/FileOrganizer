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
    public partial class StorageItemDT : MyEntity
    {
        private static StorageItemDT defaultStorageItemDT;
        SQLiteCommand _insertCommand;
        SQLiteCommand _updateCommand;
        SQLiteCommand _deleteCommand;
        public SQLiteCommand _identityCommand;

        public StorageItemDT()
            : base()
        {
            base.QuerySource = "[StorageItem]";

        }
        public virtual bool LoadByPrimaryKey(long ID)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(StorageItemDT.Parameters.ID, ID);
            return base.LoadFromSql("SELECT * FROM [StorageItem] WHERE (ID=@ID)", parameters, CommandType.Text);
        }

        public void LoadAll()
        {
            if (_selectCommand == null)
            {
                _selectCommand = MyDbConnection.Instance.connection.CreateCommand();
                _adapter = new SQLiteDataAdapter(_selectCommand);
            }
            _selectCommand.CommandText = "SELECT * FROM [StorageItem]";
            _selectCommand.CommandType = CommandType.Text;
            this.Clear();
            _adapter.Fill(this);
        }
        public SQLiteCommand GetInsertCommand()
        {
            if (_insertCommand == null)
            {
                _insertCommand = MyDbConnection.Instance.connection.CreateCommand();
                _insertCommand.CommandText = "INSERT INTO StorageItem ([WorkSpaceID],[ItemName],[Size],[Description],[URL],[FullPath],[Priority],[PagesCount],[Citation],[ReferenceBib],[ImportantParts],[AdditionDate],[NoteItemID])VALUES (@WorkSpaceID,@ItemName,@Size,@Description,@URL,@FullPath,@Priority,@PagesCount,@Citation,@ReferenceBib,@ImportantParts,@AdditionDate,@NoteItemID)";
                _insertCommand.CommandType = CommandType.Text;
                CreateParams(_insertCommand);

            }
            return _insertCommand;
        }
        private void CreateParams(SQLiteCommand command)
        {
            command.Parameters.Add(new SQLiteParameter(ColumnNames.ID, DbType.Int64, 8, ColumnNames.ID));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.WorkSpaceID, DbType.Int64, 8, ColumnNames.WorkSpaceID));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.ItemName, DbType.String, 2147483647, ColumnNames.ItemName));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.Size, DbType.String, 2147483647, ColumnNames.Size));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.Description, DbType.String, 2147483647, ColumnNames.Description));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.URL, DbType.String, 2147483647, ColumnNames.URL));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.FullPath, DbType.String, 2147483647, ColumnNames.FullPath));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.Priority, DbType.Int64, 8, ColumnNames.Priority));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.PagesCount, DbType.Int64, 8, ColumnNames.PagesCount));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.Citation, DbType.String, 2147483647, ColumnNames.Citation));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.ReferenceBib, DbType.String, 2147483647, ColumnNames.ReferenceBib));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.ImportantParts, DbType.String, 2147483647, ColumnNames.ImportantParts));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.AdditionDate, DbType.DateTime, 8, ColumnNames.AdditionDate));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.NoteItemID, DbType.Int64, 8, ColumnNames.NoteItemID));
        }
        public SQLiteCommand GetUpdateCommand()
        {
            if (_updateCommand == null)
            {
                _updateCommand = MyDbConnection.Instance.connection.CreateCommand();
                _updateCommand.CommandText = "UPDATE StorageItem SET [WorkSpaceID] = @WorkSpaceID,[ItemName] = @ItemName,[Size] = @Size,[Description] = @Description,[URL] = @URL,[FullPath] = @FullPath,[Priority] = @Priority,[PagesCount] = @PagesCount,[Citation] = @Citation,[ReferenceBib] = @ReferenceBib,[ImportantParts] = @ImportantParts,[AdditionDate] = @AdditionDate,[NoteItemID] = @NoteItemID WHERE ([ID] = @ID)";
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
                _deleteCommand.CommandText = "DELETE FROM StorageItem WHERE ([ID] = @ID)";
                _deleteCommand.CommandType = CommandType.Text;
                _deleteCommand.Parameters.Add(new SQLiteParameter(ColumnNames.ID, DbType.Int64, 8, ColumnNames.ID));
            }
            return _deleteCommand;
        }
        #region @@IDENTITY Logic
        // Overloaded in the generated class
        public virtual string GetAutoKeyColumn()
        {
            return StorageItemDT.ColumnNames.ID;
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

        public static StorageItemDT GetDefaultStorageItemDT()
        {
            if (defaultStorageItemDT == null)
            {
                defaultStorageItemDT = new StorageItemDT();
                MyDbConnection.Instance.FillDataTable(defaultStorageItemDT, "SELECT * FROM [StorageItem] WHERE 1 > 1");
            }

            return defaultStorageItemDT;
        }
        protected override Type GetRowType()
        {
            return typeof(StorageItemRow);
        }

        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new StorageItemRow(builder);
        }
        public StorageItemRow this[int idx]
        {
            get { return (StorageItemRow)Rows[idx]; }
        }
        public StorageItemRow NewStorageItemRow()
        {
            return (StorageItemRow)base.NewRow();
        }
        public static StorageItemRow NewRowDefault()
        {
            if (defaultStorageItemDT == null)
            {
                defaultStorageItemDT = new StorageItemDT();
                MyDbConnection.Instance.FillDataTable(defaultStorageItemDT, "SELECT * FROM [StorageItem] WHERE 1 > 1");
            }
            return (StorageItemRow)defaultStorageItemDT.NewRow();
        }

        #region ColumnNames
        public class ColumnNames
        {
            public const string ID = "ID";
            public const string WorkSpaceID = "WorkSpaceID";
            public const string ItemName = "ItemName";
            public const string Size = "Size";
            public const string Description = "Description";
            public const string URL = "URL";
            public const string FullPath = "FullPath";
            public const string Priority = "Priority";
            public const string PagesCount = "PagesCount";
            public const string Citation = "Citation";
            public const string ReferenceBib = "ReferenceBib";
            public const string ImportantParts = "ImportantParts";
            public const string AdditionDate = "AdditionDate";
            public const string NoteItemID = "NoteItemID";
        }
        #endregion
        #region Parameters
        public class Parameters
        {

            public static SQLiteParameter ID
            {
                get
                {
                    return new SQLiteParameter(StorageItemDT.ColumnNames.ID, DbType.Int64, 8);
                }
            }

            public static SQLiteParameter WorkSpaceID
            {
                get
                {
                    return new SQLiteParameter(StorageItemDT.ColumnNames.WorkSpaceID, DbType.Int64, 8);
                }
            }

            public static SQLiteParameter ItemName
            {
                get
                {
                    return new SQLiteParameter(StorageItemDT.ColumnNames.ItemName, DbType.String, 2147483647);
                }
            }

            public static SQLiteParameter Size
            {
                get
                {
                    return new SQLiteParameter(StorageItemDT.ColumnNames.Size, DbType.String, 2147483647);
                }
            }

            public static SQLiteParameter Description
            {
                get
                {
                    return new SQLiteParameter(StorageItemDT.ColumnNames.Description, DbType.String, 2147483647);
                }
            }

            public static SQLiteParameter URL
            {
                get
                {
                    return new SQLiteParameter(StorageItemDT.ColumnNames.URL, DbType.String, 2147483647);
                }
            }

            public static SQLiteParameter FullPath
            {
                get
                {
                    return new SQLiteParameter(StorageItemDT.ColumnNames.FullPath, DbType.String, 255);
                }
            }

            public static SQLiteParameter Priority
            {
                get
                {
                    return new SQLiteParameter(StorageItemDT.ColumnNames.Priority, DbType.Int64, 8);
                }
            }

            public static SQLiteParameter PagesCount
            {
                get
                {
                    return new SQLiteParameter(StorageItemDT.ColumnNames.PagesCount, DbType.Int64, 8);
                }
            }

            public static SQLiteParameter Citation
            {
                get
                {
                    return new SQLiteParameter(StorageItemDT.ColumnNames.Citation, DbType.String, 2147483647);
                }
            }

            public static SQLiteParameter ReferenceBib
            {
                get
                {
                    return new SQLiteParameter(StorageItemDT.ColumnNames.ReferenceBib, DbType.String, 2147483647);
                }
            }

            public static SQLiteParameter ImportantParts
            {
                get
                {
                    return new SQLiteParameter(StorageItemDT.ColumnNames.ImportantParts, DbType.String, 2147483647);
                }
            }

            public static SQLiteParameter AdditionDate
            {
                get
                {
                    return new SQLiteParameter(StorageItemDT.ColumnNames.AdditionDate, DbType.DateTime, 8);
                }
            }

            public static SQLiteParameter NoteItemID
            {
                get
                {
                    return new SQLiteParameter(StorageItemDT.ColumnNames.NoteItemID, DbType.Int64, 8);
                }
            }


        }
        #endregion


    }

    public partial class StorageItemRow : DataRow
    {

        public StorageItemRow(DataRowBuilder builder)
            : base(builder)
        {
        }
        public void Save()
        {

            if (this.RowState == DataRowState.Added || RowState == DataRowState.Detached)
            {
                SQLiteCommand insertCommand = ((StorageItemDT)this.Table).GetInsertCommand();
                SetCommadValues(insertCommand);
                insertCommand.ExecuteNonQuery();
                if (((StorageItemDT)this.Table)._identityCommand == null)
                {
                    ((StorageItemDT)this.Table)._identityCommand = MyDbConnection.Instance.connection.CreateCommand();
                    ((StorageItemDT)this.Table)._identityCommand.CommandText = "SELECT last_insert_rowid()";
                }
                base[StorageItemDT.ColumnNames.ID] = ((StorageItemDT)this.Table)._identityCommand.ExecuteScalar();
                this.Table.Rows.Add(this);
                this.AcceptChanges();

            }
            else if (this.RowState == DataRowState.Modified)
            {
                SQLiteCommand updateCommand = ((StorageItemDT)this.Table).GetUpdateCommand();
                SetCommadValues(updateCommand);
                updateCommand.ExecuteNonQuery();
                this.AcceptChanges();

            }
            else if (RowState == DataRowState.Deleted)
            {
                SQLiteCommand deleteCommand = ((StorageItemDT)this.Table).GetDeleteCommand();
                deleteCommand.Parameters[StorageItemDT.ColumnNames.ID].Value = base[StorageItemDT.ColumnNames.ID];
                deleteCommand.ExecuteNonQuery();
                this.AcceptChanges();
            }
        }
        public void DeleteStorageItem()
        {
            SQLiteCommand deleteCommand = ((StorageItemDT)this.Table).GetDeleteCommand();
            deleteCommand.Parameters[StorageItemDT.ColumnNames.ID].Value = base[StorageItemDT.ColumnNames.ID];
            deleteCommand.ExecuteNonQuery();
            this.Table.Rows.Remove(this);
            //this.AcceptChanges();
        }
        private void SetCommadValues(SQLiteCommand command)
        {
            command.Parameters[StorageItemDT.ColumnNames.ID].Value = base[StorageItemDT.ColumnNames.ID];
            command.Parameters[StorageItemDT.ColumnNames.WorkSpaceID].Value = base[StorageItemDT.ColumnNames.WorkSpaceID];
            command.Parameters[StorageItemDT.ColumnNames.ItemName].Value = base[StorageItemDT.ColumnNames.ItemName];
            command.Parameters[StorageItemDT.ColumnNames.Size].Value = base[StorageItemDT.ColumnNames.Size];
            command.Parameters[StorageItemDT.ColumnNames.Description].Value = base[StorageItemDT.ColumnNames.Description];
            command.Parameters[StorageItemDT.ColumnNames.URL].Value = base[StorageItemDT.ColumnNames.URL];
            command.Parameters[StorageItemDT.ColumnNames.FullPath].Value = base[StorageItemDT.ColumnNames.FullPath];
            command.Parameters[StorageItemDT.ColumnNames.Priority].Value = base[StorageItemDT.ColumnNames.Priority];
            command.Parameters[StorageItemDT.ColumnNames.PagesCount].Value = base[StorageItemDT.ColumnNames.PagesCount];
            command.Parameters[StorageItemDT.ColumnNames.Citation].Value = base[StorageItemDT.ColumnNames.Citation];
            command.Parameters[StorageItemDT.ColumnNames.ReferenceBib].Value = base[StorageItemDT.ColumnNames.ReferenceBib];
            command.Parameters[StorageItemDT.ColumnNames.ImportantParts].Value = base[StorageItemDT.ColumnNames.ImportantParts];
            command.Parameters[StorageItemDT.ColumnNames.AdditionDate].Value = base[StorageItemDT.ColumnNames.AdditionDate];
            command.Parameters[StorageItemDT.ColumnNames.NoteItemID].Value = base[StorageItemDT.ColumnNames.NoteItemID];
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
                return (long)base[StorageItemDT.ColumnNames.ID];
            }
            set
            {
                base[StorageItemDT.ColumnNames.ID] = value;
            }
        }

        public virtual long WorkSpaceID
        {
            get
            {
                return (long)base[StorageItemDT.ColumnNames.WorkSpaceID];
            }
            set
            {
                base[StorageItemDT.ColumnNames.WorkSpaceID] = value;
            }
        }

        public virtual string ItemName
        {
            get
            {
                return (string)base[StorageItemDT.ColumnNames.ItemName];
            }
            set
            {
                base[StorageItemDT.ColumnNames.ItemName] = value;
            }
        }

        public virtual string Size
        {
            get
            {
                return (string)base[StorageItemDT.ColumnNames.Size];
            }
            set
            {
                base[StorageItemDT.ColumnNames.Size] = value;
            }
        }

        public virtual string Description
        {
            get
            {
                return (string)base[StorageItemDT.ColumnNames.Description];
            }
            set
            {
                base[StorageItemDT.ColumnNames.Description] = value;
            }
        }

        public virtual string URL
        {
            get
            {
                return (string)base[StorageItemDT.ColumnNames.URL];
            }
            set
            {
                base[StorageItemDT.ColumnNames.URL] = value;
            }
        }

        public virtual string FullPath
        {
            get
            {
                return (string)base[StorageItemDT.ColumnNames.FullPath];
            }
            set
            {
                base[StorageItemDT.ColumnNames.FullPath] = value;
            }
        }

        public virtual long Priority
        {
            get
            {
                return (long)base[StorageItemDT.ColumnNames.Priority];
            }
            set
            {
                base[StorageItemDT.ColumnNames.Priority] = value;
            }
        }

        public virtual long PagesCount
        {
            get
            {
                return (long)base[StorageItemDT.ColumnNames.PagesCount];
            }
            set
            {
                base[StorageItemDT.ColumnNames.PagesCount] = value;
            }
        }

        public virtual string Citation
        {
            get
            {
                return (string)base[StorageItemDT.ColumnNames.Citation];
            }
            set
            {
                base[StorageItemDT.ColumnNames.Citation] = value;
            }
        }

        public virtual string ReferenceBib
        {
            get
            {
                return (string)base[StorageItemDT.ColumnNames.ReferenceBib];
            }
            set
            {
                base[StorageItemDT.ColumnNames.ReferenceBib] = value;
            }
        }

        public virtual string ImportantParts
        {
            get
            {
                return (string)base[StorageItemDT.ColumnNames.ImportantParts];
            }
            set
            {
                base[StorageItemDT.ColumnNames.ImportantParts] = value;
            }
        }

        public virtual DateTime AdditionDate
        {
            get
            {
                return (DateTime)base[StorageItemDT.ColumnNames.AdditionDate];
            }
            set
            {
                base[StorageItemDT.ColumnNames.AdditionDate] = value;
            }
        }

        public virtual long NoteItemID
        {
            get
            {
                return (long)base[StorageItemDT.ColumnNames.NoteItemID];
            }
            set
            {
                base[StorageItemDT.ColumnNames.NoteItemID] = value;
            }
        }



        #region String Properties

        public virtual string s_ID
        {
            get
            {
                return this.IsNull(StorageItemDT.ColumnNames.ID) ? string.Empty : base[StorageItemDT.ColumnNames.ID].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[StorageItemDT.ColumnNames.ID] = DBNull.Value;
                else
                    base[StorageItemDT.ColumnNames.ID] = Convert.ToInt64(value);
            }
        }

        public virtual string s_WorkSpaceID
        {
            get
            {
                return this.IsNull(StorageItemDT.ColumnNames.WorkSpaceID) ? string.Empty : base[StorageItemDT.ColumnNames.WorkSpaceID].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[StorageItemDT.ColumnNames.WorkSpaceID] = DBNull.Value;
                else
                    base[StorageItemDT.ColumnNames.WorkSpaceID] = Convert.ToInt64(value);
            }
        }

        public virtual string s_ItemName
        {
            get
            {
                return this.IsNull(StorageItemDT.ColumnNames.ItemName) ? string.Empty : base[StorageItemDT.ColumnNames.ItemName].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[StorageItemDT.ColumnNames.ItemName] = DBNull.Value;
                else
                    base[StorageItemDT.ColumnNames.ItemName] = (value);
            }
        }

        public virtual string s_Size
        {
            get
            {
                return this.IsNull(StorageItemDT.ColumnNames.Size) ? string.Empty : base[StorageItemDT.ColumnNames.Size].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[StorageItemDT.ColumnNames.Size] = DBNull.Value;
                else
                    base[StorageItemDT.ColumnNames.Size] = (value);
            }
        }

        public virtual string s_Description
        {
            get
            {
                return this.IsNull(StorageItemDT.ColumnNames.Description) ? string.Empty : base[StorageItemDT.ColumnNames.Description].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[StorageItemDT.ColumnNames.Description] = DBNull.Value;
                else
                    base[StorageItemDT.ColumnNames.Description] = (value);
            }
        }

        public virtual string s_URL
        {
            get
            {
                return this.IsNull(StorageItemDT.ColumnNames.URL) ? string.Empty : base[StorageItemDT.ColumnNames.URL].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[StorageItemDT.ColumnNames.URL] = DBNull.Value;
                else
                    base[StorageItemDT.ColumnNames.URL] = (value);
            }
        }

        public virtual string s_FullPath
        {
            get
            {
                return this.IsNull(StorageItemDT.ColumnNames.FullPath) ? string.Empty : base[StorageItemDT.ColumnNames.FullPath].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[StorageItemDT.ColumnNames.FullPath] = DBNull.Value;
                else
                    base[StorageItemDT.ColumnNames.FullPath] = (value);
            }
        }

        public virtual string s_Priority
        {
            get
            {
                return this.IsNull(StorageItemDT.ColumnNames.Priority) ? string.Empty : base[StorageItemDT.ColumnNames.Priority].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[StorageItemDT.ColumnNames.Priority] = DBNull.Value;
                else
                    base[StorageItemDT.ColumnNames.Priority] = Convert.ToInt64(value);
            }
        }

        public virtual string s_PagesCount
        {
            get
            {
                return this.IsNull(StorageItemDT.ColumnNames.PagesCount) ? string.Empty : base[StorageItemDT.ColumnNames.PagesCount].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[StorageItemDT.ColumnNames.PagesCount] = DBNull.Value;
                else
                    base[StorageItemDT.ColumnNames.PagesCount] = Convert.ToInt64(value);
            }
        }

        public virtual string s_Citation
        {
            get
            {
                return this.IsNull(StorageItemDT.ColumnNames.Citation) ? string.Empty : base[StorageItemDT.ColumnNames.Citation].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[StorageItemDT.ColumnNames.Citation] = DBNull.Value;
                else
                    base[StorageItemDT.ColumnNames.Citation] = (value);
            }
        }

        public virtual string s_ReferenceBib
        {
            get
            {
                return this.IsNull(StorageItemDT.ColumnNames.ReferenceBib) ? string.Empty : base[StorageItemDT.ColumnNames.ReferenceBib].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[StorageItemDT.ColumnNames.ReferenceBib] = DBNull.Value;
                else
                    base[StorageItemDT.ColumnNames.ReferenceBib] = (value);
            }
        }

        public virtual string s_ImportantParts
        {
            get
            {
                return this.IsNull(StorageItemDT.ColumnNames.ImportantParts) ? string.Empty : base[StorageItemDT.ColumnNames.ImportantParts].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[StorageItemDT.ColumnNames.ImportantParts] = DBNull.Value;
                else
                    base[StorageItemDT.ColumnNames.ImportantParts] = (value);
            }
        }

        public virtual string s_AdditionDate
        {
            get
            {
                return this.IsNull(StorageItemDT.ColumnNames.AdditionDate) ? string.Empty : base[StorageItemDT.ColumnNames.AdditionDate].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[StorageItemDT.ColumnNames.AdditionDate] = DBNull.Value;
                else
                    base[StorageItemDT.ColumnNames.AdditionDate] = Convert.ToDateTime(value);
            }
        }

        public virtual string s_NoteItemID
        {
            get
            {
                return this.IsNull(StorageItemDT.ColumnNames.NoteItemID) ? string.Empty : base[StorageItemDT.ColumnNames.NoteItemID].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[StorageItemDT.ColumnNames.NoteItemID] = DBNull.Value;
                else
                    base[StorageItemDT.ColumnNames.NoteItemID] = Convert.ToInt64(value);
            }
        }


        #endregion
    }

}



