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
    public partial class NoteItemDT : MyEntity
    {
        private static NoteItemDT defaultNoteItemDT;
        SQLiteCommand _insertCommand;
        SQLiteCommand _updateCommand;
        SQLiteCommand _deleteCommand;
        public SQLiteCommand _identityCommand;

        public NoteItemDT()
            : base()
        {
            base.QuerySource = "[NoteItem]";

        }
        public virtual bool LoadByPrimaryKey(long ID)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(NoteItemDT.Parameters.ID, ID);
            return base.LoadFromSql("SELECT * FROM [NoteItem] WHERE (ID=@ID)", parameters, CommandType.Text);
        }

        public void LoadAll()
        {
            if (_selectCommand == null)
            {
                _selectCommand = MyDbConnection.Instance.connection.CreateCommand();
                _adapter = new SQLiteDataAdapter(_selectCommand);
            }
            _selectCommand.CommandText = "SELECT * FROM [NoteItem]";
            _selectCommand.CommandType = CommandType.Text;
            this.Clear();
            _adapter.Fill(this);
        }
        public SQLiteCommand GetInsertCommand()
        {
            if (_insertCommand == null)
            {
                _insertCommand = MyDbConnection.Instance.connection.CreateCommand();
                _insertCommand.CommandText = "INSERT INTO NoteItem ([NoteFileName])VALUES (@NoteFileName)";
                _insertCommand.CommandType = CommandType.Text;
                CreateParams(_insertCommand);

            }
            return _insertCommand;
        }
        private void CreateParams(SQLiteCommand command)
        {
            command.Parameters.Add(new SQLiteParameter(ColumnNames.ID, DbType.Int64, 8, ColumnNames.ID));
            command.Parameters.Add(new SQLiteParameter(ColumnNames.NoteFileName, DbType.String, 2147483647, ColumnNames.NoteFileName));
        }
        public SQLiteCommand GetUpdateCommand()
        {
            if (_updateCommand == null)
            {
                _updateCommand = MyDbConnection.Instance.connection.CreateCommand();
                _updateCommand.CommandText = "UPDATE NoteItem SET [NoteFileName] = @NoteFileName WHERE ([ID] = @ID)";
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
                _deleteCommand.CommandText = "DELETE FROM NoteItem WHERE ([ID] = @ID)";
                _deleteCommand.CommandType = CommandType.Text;
                _deleteCommand.Parameters.Add(new SQLiteParameter(ColumnNames.ID, DbType.Int64, 8, ColumnNames.ID));
            }
            return _deleteCommand;
        }
        #region @@IDENTITY Logic
        // Overloaded in the generated class
        public virtual string GetAutoKeyColumn()
        {
            return NoteItemDT.ColumnNames.ID;
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

        public static NoteItemDT GetDefaultNoteItemDT()
        {
            if (defaultNoteItemDT == null)
            {
                defaultNoteItemDT = new NoteItemDT();
                MyDbConnection.Instance.FillDataTable(defaultNoteItemDT, "SELECT * FROM [NoteItem] WHERE 1 > 1");
            }

            return defaultNoteItemDT;
        }
        protected override Type GetRowType()
        {
            return typeof(NoteItemRow);
        }

        protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
        {
            return new NoteItemRow(builder);
        }
        public NoteItemRow this[int idx]
        {
            get { return (NoteItemRow)Rows[idx]; }
        }
        public NoteItemRow NewNoteItemRow()
        {
            return (NoteItemRow)base.NewRow();
        }
        public static NoteItemRow NewRowDefault()
        {
            if (defaultNoteItemDT == null)
            {
                defaultNoteItemDT = new NoteItemDT();
                MyDbConnection.Instance.FillDataTable(defaultNoteItemDT, "SELECT * FROM [NoteItem] WHERE 1 > 1");
            }
            return (NoteItemRow)defaultNoteItemDT.NewRow();
        }

        #region ColumnNames
        public class ColumnNames
        {
            public const string ID = "ID";
            public const string NoteFileName = "NoteFileName";
        }
        #endregion
        #region Parameters
        public class Parameters
        {

            public static SQLiteParameter ID
            {
                get
                {
                    return new SQLiteParameter(NoteItemDT.ColumnNames.ID, DbType.Int64, 8);
                }
            }

            public static SQLiteParameter NoteFileName
            {
                get
                {
                    return new SQLiteParameter(NoteItemDT.ColumnNames.NoteFileName, DbType.String, 2147483647);
                }
            }


        }
        #endregion


    }

    public partial class NoteItemRow : DataRow
    {

        public NoteItemRow(DataRowBuilder builder)
            : base(builder)
        {
        }
        public void Save()
        {

            if (this.RowState == DataRowState.Added || RowState == DataRowState.Detached)
            {
                SQLiteCommand insertCommand = ((NoteItemDT)this.Table).GetInsertCommand();
                SetCommadValues(insertCommand);
                insertCommand.ExecuteNonQuery();
                if (((NoteItemDT)this.Table)._identityCommand == null)
                {
                    ((NoteItemDT)this.Table)._identityCommand = MyDbConnection.Instance.connection.CreateCommand();
                    ((NoteItemDT)this.Table)._identityCommand.CommandText = "SELECT last_insert_rowid()";
                }
                base[NoteItemDT.ColumnNames.ID] = ((NoteItemDT)this.Table)._identityCommand.ExecuteScalar();
                this.Table.Rows.Add(this);
                this.AcceptChanges();

            }
            else if (this.RowState == DataRowState.Modified)
            {
                SQLiteCommand updateCommand = ((NoteItemDT)this.Table).GetUpdateCommand();
                SetCommadValues(updateCommand);
                updateCommand.ExecuteNonQuery();
                this.AcceptChanges();

            }
            else if (RowState == DataRowState.Deleted)
            {
                SQLiteCommand deleteCommand = ((NoteItemDT)this.Table).GetDeleteCommand();
                deleteCommand.Parameters[NoteItemDT.ColumnNames.ID].Value = base[NoteItemDT.ColumnNames.ID];
                deleteCommand.ExecuteNonQuery();
                this.AcceptChanges();
            }
        }
        public void DeleteNoteItem()
        {
            SQLiteCommand deleteCommand = ((NoteItemDT)this.Table).GetDeleteCommand();
            deleteCommand.Parameters[NoteItemDT.ColumnNames.ID].Value = base[NoteItemDT.ColumnNames.ID];
            deleteCommand.ExecuteNonQuery();
            this.Table.Rows.Remove(this);
            //this.AcceptChanges();
        }
        private void SetCommadValues(SQLiteCommand command)
        {
            command.Parameters[NoteItemDT.ColumnNames.ID].Value = base[NoteItemDT.ColumnNames.ID];
            command.Parameters[NoteItemDT.ColumnNames.NoteFileName].Value = base[NoteItemDT.ColumnNames.NoteFileName];
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
                return (long)base[NoteItemDT.ColumnNames.ID];
            }
            set
            {
                base[NoteItemDT.ColumnNames.ID] = value;
            }
        }

        public virtual string NoteFileName
        {
            get
            {
                return (string)base[NoteItemDT.ColumnNames.NoteFileName];
            }
            set
            {
                base[NoteItemDT.ColumnNames.NoteFileName] = value;
            }
        }



        #region String Properties

        public virtual string s_ID
        {
            get
            {
                return this.IsNull(NoteItemDT.ColumnNames.ID) ? string.Empty : base[NoteItemDT.ColumnNames.ID].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[NoteItemDT.ColumnNames.ID] = DBNull.Value;
                else
                    base[NoteItemDT.ColumnNames.ID] = Convert.ToInt64(value);
            }
        }

        public virtual string s_NoteFileName
        {
            get
            {
                return this.IsNull(NoteItemDT.ColumnNames.NoteFileName) ? string.Empty : base[NoteItemDT.ColumnNames.NoteFileName].ToString();
            }
            set
            {
                if (string.Empty == value)
                    this[NoteItemDT.ColumnNames.NoteFileName] = DBNull.Value;
                else
                    base[NoteItemDT.ColumnNames.NoteFileName] = (value);
            }
        }


        #endregion
    }

}



