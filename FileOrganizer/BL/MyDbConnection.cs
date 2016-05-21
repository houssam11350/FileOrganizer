using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace FileOrganizer.BL
{

    public class MyDbConnection
    {

#if BOOK
        public string connectin_string = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "/BooksDB.mdb;Persist Security Info=False;";
#else
        public string connectin_string = "Data Source=" + Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) 
                                        + "/FileOrganizerDB.sqlite;Version=3;New=False;Compress=False;";
#endif

        public static MyDbConnection Instance = new MyDbConnection();
        public SQLiteConnection connection;
        SQLiteCommand commandWithNoParameter;
        SQLiteDataAdapter adapter;

        private MyDbConnection()
        {
            connection = new SQLiteConnection(connectin_string);
            connection.Open();
            commandWithNoParameter = connection.CreateCommand();
            adapter = new SQLiteDataAdapter(commandWithNoParameter);
            commandWithNoParameter.CommandText = "PRAGMA foreign_keys=ON;";
            commandWithNoParameter.ExecuteNonQuery();
            //adapter.SelectCommand = commandWithNoParameter;
        }

        public void FillDataTable(DataTable dataTable, string sql)
        {
            commandWithNoParameter.CommandText = sql;
            adapter.Fill(dataTable);

        }
        public void CloseConnection()
        {
            if (connection != null && connection.State == ConnectionState.Open)
                connection.Close();
        }
        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

    }
}
