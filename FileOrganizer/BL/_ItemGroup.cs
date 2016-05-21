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
    public partial class ItemGroupDT : MyEntity
    {
        private static ItemGroupDT defaultItemGroupDT;
        SQLiteCommand _insertCommand;
        SQLiteCommand _updateCommand;
        SQLiteCommand _deleteCommand;
        public SQLiteCommand _identityCommand;

        public ItemGroupDT()
            : base()
        {
            base.QuerySource = "[ItemGroup]";

        }
        public virtual bool LoadByPrimaryKey(long ID)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(ItemGroupDT.Parameters.ID, ID);
            return base.LoadFromSql("SELECT * FROM [ItemGroup] WHERE (ID=@ID)", parameters, CommandType.Text);
        }

        public void LoadAll()
        {
            if (_selectCommand == null)
            {
                _selectCommand = MyDbConnection.Instance.connection.CreateCommand();
                _adapter = new SQLiteDataAdapter(_selectCommand);
            }
            _selectCommand.CommandText = "SELECT * FROM [ItemGroup]";
            _selectCommand.CommandType = CommandType.Text;
            this.Clear();
            _adapter.Fill(this);
        }
        public SQLiteCommand GetInsertCommand()
        {
            if (_insertCommand == null)
            {
                _insertCommand = MyDbConnection.Instance.connection.CreateCommand();
                _insertCommand.CommandText = "INSERT INTO ItemGroup ([GroupName])VALUES (@GroupName)";
                _insertCommand.CommandType = CommandType.Text;
                CreateParams(_insertCommand);

            }
            return _insertCommand;
        }
        private void CreateParams(SQLiteCommand command)
        {
            command.Parameters.Add(new SQLiteParameter(ColumnNames.ID, DbType.Int64, 8, ColumnNames.ID));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.GroupName, DbType.String, 2147483647, ColumnNames.GroupName));
        }
        public SQLiteCommand GetUpdateCommand()
        {
            if (_updateCommand == null)
            {
                _updateCommand = MyDbConnection.Instance.connection.CreateCommand();
                _updateCommand.CommandText = "UPDATE ItemGroup SET [GroupName] = @GroupName WHERE ([ID] = @ID)";
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
                _deleteCommand.CommandText = "DELETE FROM ItemGroup WHERE ([ID] = @ID)";
                _deleteCommand.CommandType = CommandType.Text;
                _deleteCommand.Parameters.Add(new SQLiteParameter(ColumnNames.ID, DbType.Int64, 8, ColumnNames.ID));
            }
            return _deleteCommand;
        }
        #region @@IDENTITY Logic
        // Overloaded in the generated class
        public virtual string GetAutoKeyColumn()
        {
            return ItemGroupDT.ColumnNames.ID;
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

        public static ItemGroupDT GetDefaultItemGroupDT()
        {
            if (defaultItemGroupDT == null)
            {
                defaultItemGroupDT = new ItemGroupDT();
                MyDbConnection.Instance.FillDataTable(defaultItemGroupDT, "SELECT * FROM [ItemGroup] WHERE 1 > 1");
            }

            return defaultItemGroupDT;
        }
        protected override Type GetRowType()
        {
            return typeof(ItemGroupRow);
        }

        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new ItemGroupRow(builder);
        }
        public ItemGroupRow this[int idx]
        {
            get { return (ItemGroupRow)Rows[idx]; }
        }
        public ItemGroupRow NewItemGroupRow()
        {
            return (ItemGroupRow)base.NewRow();
        }
        public static ItemGroupRow NewRowDefault()
        {
            if (defaultItemGroupDT == null)
            {
                defaultItemGroupDT = new ItemGroupDT();
                MyDbConnection.Instance.FillDataTable(defaultItemGroupDT, "SELECT * FROM [ItemGroup] WHERE 1 > 1");
            }
            return (ItemGroupRow)defaultItemGroupDT.NewRow();
        }

        #region ColumnNames
        public class ColumnNames
        {
            public const string ID = "ID";
            public const string GroupName = "GroupName";
        }
        #endregion
        #region Parameters
        public class Parameters
        {

            public static SQLiteParameter ID
            {
                get
                {
                    return new SQLiteParameter(ItemGroupDT.ColumnNames.ID, DbType.Int64, 8);
                }
            }

            public static SQLiteParameter GroupName
            {
                get
                {
                    return new SQLiteParameter(ItemGroupDT.ColumnNames.GroupName, DbType.String, 2147483647);
                }
            }


        }
        #endregion


    }

    public partial class ItemGroupRow : DataRow
    {

        public ItemGroupRow(DataRowBuilder builder)
            : base(builder)
        {
        }
        public void Save()
        {

            if (this.RowState == DataRowState.Added || RowState == DataRowState.Detached)
            {
                SQLiteCommand insertCommand = ((ItemGroupDT)this.Table).GetInsertCommand();
                SetCommadValues(insertCommand);
                insertCommand.ExecuteNonQuery();
                if (((ItemGroupDT)this.Table)._identityCommand == null)
                {
                    ((ItemGroupDT)this.Table)._identityCommand = MyDbConnection.Instance.connection.CreateCommand();
                    ((ItemGroupDT)this.Table)._identityCommand.CommandText = "SELECT last_insert_rowid()";
                }
                base[ItemGroupDT.ColumnNames.ID] = ((ItemGroupDT)this.Table)._identityCommand.ExecuteScalar();
                this.Table.Rows.Add(this);
                this.AcceptChanges();

            }
            else if (this.RowState == DataRowState.Modified)
            {
                SQLiteCommand updateCommand = ((ItemGroupDT)this.Table).GetUpdateCommand();
                SetCommadValues(updateCommand);
                updateCommand.ExecuteNonQuery();
                this.AcceptChanges();

            }
            else if (RowState == DataRowState.Deleted)
            {
                SQLiteCommand deleteCommand = ((ItemGroupDT)this.Table).GetDeleteCommand();
                deleteCommand.Parameters[ItemGroupDT.ColumnNames.ID].Value = base[ItemGroupDT.ColumnNames.ID];
                deleteCommand.ExecuteNonQuery();
                this.AcceptChanges();
            }
        }
        public void DeleteItemGroup()
        {
            SQLiteCommand deleteCommand = ((ItemGroupDT)this.Table).GetDeleteCommand();
            deleteCommand.Parameters[ItemGroupDT.ColumnNames.ID].Value = base[ItemGroupDT.ColumnNames.ID];
            deleteCommand.ExecuteNonQuery();
            this.Table.Rows.Remove(this);
            //this.AcceptChanges();
        }
        private void SetCommadValues(SQLiteCommand command)
        {
            command.Parameters[ItemGroupDT.ColumnNames.ID].Value = base[ItemGroupDT.ColumnNames.ID];
            command.Parameters[ItemGroupDT.ColumnNames.GroupName].Value = base[ItemGroupDT.ColumnNames.GroupName];
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
                return (long)base[ItemGroupDT.ColumnNames.ID];
            }
            set
            {
                base[ItemGroupDT.ColumnNames.ID] = value;
            }
        }

        public virtual string GroupName
        {
            get
            {
                return (string)base[ItemGroupDT.ColumnNames.GroupName];
            }
            set
            {
                base[ItemGroupDT.ColumnNames.GroupName] = value;
            }
        }



        #region String Properties

        public virtual string s_ID
        {
            get
            {
                return this.IsNull(ItemGroupDT.ColumnNames.ID) ? string.Empty : base[ItemGroupDT.ColumnNames.ID].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[ItemGroupDT.ColumnNames.ID] = DBNull.Value;
                else
                    base[ItemGroupDT.ColumnNames.ID] = Convert.ToInt64(value);
            }
        }

        public virtual string s_GroupName
        {
            get
            {
                return this.IsNull(ItemGroupDT.ColumnNames.GroupName) ? string.Empty : base[ItemGroupDT.ColumnNames.GroupName].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[ItemGroupDT.ColumnNames.GroupName] = DBNull.Value;
                else
                    base[ItemGroupDT.ColumnNames.GroupName] = (value);
            }
        }


        #endregion
    }

}



