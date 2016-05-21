using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileOrganizer.BL;
using System.Data.OleDb;
using System.IO;

namespace FileOrganizer.UI
{
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
        }
        StorageItemDT dt = new StorageItemDT();
        private void button1_Click(object sender, EventArgs e)
        {
            //dt = new  StorageItemDT();
            //dt.LoadAll();
            //dt.Query.ResetWhereParameters();
            //dt.Query.AddWhereParameter(StorageItemDT.ColumnNames.ID, MyOperand.GreaterThan, StorageItemDT.Parameters.ID, 300);
            //dt.Query.AddWhereParameter(StorageItemDT.ColumnNames.WorkSpaceID, MyOperand.Equal, StorageItemDT.Parameters.WorkSpaceID, 14);
            //dt.Query.Load();
            StorageItemRow row = StorageItemDT.NewRowDefault();
            row.WorkSpaceID = 14;
            row.FullPath = "FFFFFFFF";
            row.Save();
            Helper.OKMSG(row.FullPath);
            StorageItemRow row2 = StorageItemDT.NewRowDefault();
            row2.WorkSpaceID = 14;
            row2.FullPath = "SSSSSSSSS";
            row2.Save();
            StorageItemDT.GetDefaultStorageItemDT().Clear();
            Helper.OKMSG(row.FullPath);
            dataGridView1.DataSource = StorageItemDT.GetDefaultStorageItemDT();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dt.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StorageItemRow row = StorageItemDT.NewRowDefault();
            row.WorkSpaceID = 17;
            row.Save();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "/BooksDB.mdb;Persist Security Info=False;";
            OleDbConnection con = new OleDbConnection(conStr);
            con.Open();
            DataTable dt = new DataTable();
            OleDbCommand comm = new OleDbCommand("SELECT * FROM StorageItem", con);
            OleDbDataReader reader = comm.ExecuteReader();
            dt.Load(reader);
            string[] arr = new string[] {
                    StorageItemDT.ColumnNames.ID ,
                    StorageItemDT.ColumnNames. WorkSpaceID ,
                    StorageItemDT.ColumnNames.ItemName,
                    StorageItemDT.ColumnNames.Size ,
                    //StorageItemDT.ColumnNames.Description,
                    StorageItemDT.ColumnNames.URL ,
                    StorageItemDT.ColumnNames.FullPath ,
                    StorageItemDT.ColumnNames.Priority ,
                    StorageItemDT.ColumnNames.PagesCount ,
                    StorageItemDT.ColumnNames.Citation ,
                    StorageItemDT.ColumnNames. ReferenceBib,
                    StorageItemDT.ColumnNames.ImportantParts ,
                    StorageItemDT.ColumnNames.AdditionDate ,
                    StorageItemDT.ColumnNames.NoteItemID 
            };
            foreach (DataRow r in dt.Rows)
            {
                StorageItemRow row = StorageItemDT.NewRowDefault();
                foreach (string col in arr)
                    row[col] = r[col];

                //row.WorkSpaceID = 1;
                //row[StorageItemDT.ColumnNames.Description] = r["Desciption"];
                //row.Save();
            }
            Helper.OKMSG("OK...");
        }
    }
}
