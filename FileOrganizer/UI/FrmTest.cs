using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileOrganizer.BL;

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
            StorageItemRow row = StorageItemDT.NewRowDefault() ;
            row.WorkSpaceID = 17;
            row.Save();
        }
    }
}
