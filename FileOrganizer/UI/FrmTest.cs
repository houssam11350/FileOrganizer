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
using System.Threading;

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

        //void run()
        //{

        //    string[] arr_item = new string[] {
        //            StorageItemDT.ColumnNames.ID ,
        //            StorageItemDT.ColumnNames. WorkSpaceID ,
        //            StorageItemDT.ColumnNames.ItemName,
        //            StorageItemDT.ColumnNames.Size ,
        //            //StorageItemDT.ColumnNames.Description,
        //            StorageItemDT.ColumnNames.URL ,
        //            StorageItemDT.ColumnNames.FullPath ,
        //            StorageItemDT.ColumnNames.Priority ,
        //            StorageItemDT.ColumnNames.PagesCount ,
        //            StorageItemDT.ColumnNames.Citation ,
        //            StorageItemDT.ColumnNames. ReferenceBib,
        //            StorageItemDT.ColumnNames.ImportantParts ,
        //            StorageItemDT.ColumnNames.AdditionDate ,
        //            //StorageItemDT.ColumnNames.NoteItemID
        //    };

        //    List<StorageItemRow> items = new List<StorageItemRow>();
        //    List<RefStorageItemRow> refs = new List<RefStorageItemRow>();

        //    String conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "/FileOrganizerDB.mdb;Persist Security Info=False;";
        //    OleDbConnection con = new OleDbConnection(conStr);
        //    con.Open();
        //    DataTable dt = new DataTable();
        //    OleDbCommand comm = new OleDbCommand("SELECT * FROM Workspace", con);
        //    OleDbDataReader reader = comm.ExecuteReader();
        //    dt.Load(reader);
        //    foreach (DataRow r in dt.Rows)
        //    {
        //        WorkSpaceRow w = WorkSpaceDT.NewRowDefault();
        //        int w_old_id = (int)r[WorkSpaceDT.ColumnNames.ID];
        //        w[WorkSpaceDT.ColumnNames.WName] = r[WorkSpaceDT.ColumnNames.WName];
        //        w[WorkSpaceDT.ColumnNames.IsActive] = r[WorkSpaceDT.ColumnNames.IsActive];
        //        w.Save();
        //        long new_w_id = w.ID;
        //        DataTable dt_item = new DataTable();
        //        OleDbCommand comm_item = new OleDbCommand("SELECT * FROM StorageItem WHERE WorkSpaceID = " + w_old_id, con);
        //        OleDbDataReader reader_item = comm_item.ExecuteReader();
        //        dt_item.Load(reader_item);
        //        foreach (DataRow r_item in dt_item.Rows)
        //        {
        //            StorageItemRow new_item = StorageItemDT.NewRowDefault();
        //            foreach (string col in arr_item)
        //            {
        //                if (!Convert.IsDBNull(r_item[col]))
        //                    new_item[col] = r_item[col];
        //            }
        //            new_item[StorageItemDT.ColumnNames.WorkSpaceID] = Convert.ToInt32(new_w_id);
        //            if (!Convert.IsDBNull(r_item["Desciption"]))
        //                new_item[StorageItemDT.ColumnNames.Description] = r_item["Desciption"];
        //            if (!Convert.IsDBNull(r_item["ID"]))
        //                new_item.old_id = (int)r_item["ID"];
        //            new_item.Save();
        //            items.Add(new_item);

        //        }
        //    }
        //    DataTable dt_ref = new DataTable();
        //    OleDbCommand comm_ref = new OleDbCommand("SELECT * FROM RefStorageItem", con);
        //    OleDbDataReader reader_ref = comm_ref.ExecuteReader();
        //    dt_ref.Load(reader_ref);
        //    foreach (DataRow r_ref in dt_ref.Rows)
        //    {
        //        RefStorageItemRow new_ref = RefStorageItemDT.NewRowDefault();
        //        new_ref[RefStorageItemDT.ColumnNames.MainStorageItemID] = r_ref["MainStorageItemID"];
        //        new_ref[RefStorageItemDT.ColumnNames.RefStorageItemID] = r_ref["RefStorageItemID"];
        //        refs.Add(new_ref);

        //    }
        //    foreach (RefStorageItemRow reff in refs)
        //    {
        //        int i = 0;
        //        foreach (StorageItemRow item in items)
        //        {
        //            if ((long)reff[RefStorageItemDT.ColumnNames.MainStorageItemID] ==
        //                item.old_id)
        //            {
        //                reff[RefStorageItemDT.ColumnNames.MainStorageItemID] = item.ID;
        //                i++;
        //            }
        //            if ((long)reff[RefStorageItemDT.ColumnNames.RefStorageItemID] ==
        //               item.old_id)
        //            {
        //                reff[RefStorageItemDT.ColumnNames.RefStorageItemID] = item.ID;
        //                i++;
        //            }
        //            if (i == 2) break;

        //        }
        //        reff.Save();
        //    }

        //    ////lists
        //    DataTable dt_lst = new DataTable();
        //    OleDbCommand comm_lst = new OleDbCommand("SELECT * FROM QuickList", con);
        //    OleDbDataReader reader_lst = comm_lst.ExecuteReader();
        //    dt_lst.Load(reader_lst);
        //    foreach (DataRow r_lst in dt_lst.Rows)
        //    {
        //        QuickListRow new_lst = QuickListDT.NewRowDefault();
        //        new_lst[QuickListDT.ColumnNames.LName] = r_lst["LName"];
        //        new_lst[QuickListDT.ColumnNames.IsInToolBar] = r_lst["IsInToolBar"];
        //        new_lst.Save();

        //        DataTable dt_lst_item = new DataTable();
        //        OleDbCommand comm_lst_item = new OleDbCommand("SELECT * FROM ListStorageItem WHERE ListID = " + new_lst.ID  , con);
        //        OleDbDataReader reader_lst_item = comm_lst_item.ExecuteReader();
        //        dt_lst_item.Load(reader_lst_item);
        //        foreach (DataRow r_lst_item in dt_lst_item.Rows)
        //        {
        //            ListStorageItemRow new_lst_item = ListStorageItemDT.NewRowDefault();
        //            new_lst_item.ListID = new_lst.ID;
        //            Int32 ll = (Int32)r_lst_item["StorageItemID"];
        //            long new_id = get_new(items , ll);
        //            new_lst_item[ListStorageItemDT.ColumnNames.StorageItemID] = Convert.ToInt32(new_id);
        //            if (!Convert.IsDBNull(r_lst_item["Color"]))
        //                new_lst_item[ListStorageItemDT.ColumnNames.Color] = Convert.ToInt32(r_lst_item["Color"]);
        //            new_lst_item.Save();

        //        }



        //    }


        //    Helper.OKMSG("OK...");
        //}

        //private long get_new(List<StorageItemRow> items, Int32 old_id)
        //{
        //    foreach (StorageItemRow r in items)
        //    {
        //        if (r.old_id == old_id)
        //            return r.ID;
        //    }
        //    throw new Exception("ID Not Found:" + old_id);
        //}

        private void button4_Click(object sender, EventArgs e)
        {
            //Thread t = new Thread(new ThreadStart(run));
            //t.Priority = ThreadPriority.AboveNormal;
            //t.Start();

        }
    }
}
