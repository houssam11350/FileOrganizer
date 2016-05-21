using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileOrganizer.BL;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using iTextSharp.text.pdf;

namespace FileOrganizer.UI
{
    public enum FrmSimilarItemsResult { None, Save, DontSave };

    public partial class FrmSimilarItems : Form
    {
        public FrmMain frmMain;

        bool mIsLoadEvent = true;
        public bool IsLoadEvent
        {
            get { return mIsLoadEvent; }
            set { mIsLoadEvent = value; }
        }
        SystemIconsManager sysIcons = SystemIconsManager.GetInstance();

        //List<StorageItem> mStorageItemList = new List<StorageItem>();
        public StorageItemDT StorageItemList = new StorageItemDT();
        //public List<StorageItem> StorageItemList
        //{
        //    get { return mStorageItemList; }
        //    set { mStorageItemList = value; }
        //}

        //string mOriginalDesc = string.Empty;
        //public string OriginalDesc
        //{
        //    get { return mOriginalDesc; }
        //    set { mOriginalDesc = value; }
        //}
        FrmSimilarItemsResult mFrmSimilarItemsResult = FrmSimilarItemsResult.None;
        public FrmSimilarItemsResult FrmSimilarItemsResult
        {
            get { return mFrmSimilarItemsResult; }
            //set { mFrmSimilarItemsResult = value; }
        }



        public FrmSimilarItems()
        {
            mIsLoadEvent = true;
            InitializeComponent();
            mIsLoadEvent = false;
        }
        [DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(int hWnd);

        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);

        private void BringToFront(string className, string CaptionName)
        {
            SetForegroundWindow(FindWindow(className, CaptionName));
        }

        private void FrmSimilarItems_Load(object sender, EventArgs e)
        {
            mIsLoadEvent = true;

            IniSimilarItems iniSimilarItems = new IniSimilarItems(lstStorageItem);
            iniSimilarItems.Load();

            lstStorageItem.SmallImageList = sysIcons.SmallIconsImageList;
            lstStorageItem.LargeImageList = sysIcons.LargeIconsImageList;

            // SetForegroundWindow(Handle.ToInt32());

            mIsLoadEvent = false;



        }

        public void CheckSimilarStorageItems()
        {
            StorageItemDT storageItem = new StorageItemDT();

            StorageItemList.GetSimilarStorageItems(txtDescription.Text);

            DisplayStorageItemList();

        }

       
        void DisplayStorageItemList()
        {
            lstStorageItem.Items.Clear();
            foreach (StorageItemRow sItem in StorageItemList.Rows)
            {

                lstStorageItem.AddNewStorageItem(sItem);
            }

        }
        private void btnCheckSimilarStorageItems_Click(object sender, EventArgs e)
        {
            CheckSimilarStorageItems();

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            mFrmSimilarItemsResult = FrmSimilarItemsResult.Save;
            this.Close();
        }

        private void btnDontSave_Click(object sender, EventArgs e)
        {
            mFrmSimilarItemsResult = FrmSimilarItemsResult.DontSave;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void lstStorageItem_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            if (mIsLoadEvent)
                return;
            IniSimilarItems iniSimilarItems = new IniSimilarItems(lstStorageItem);
            iniSimilarItems.Save();
        }

        private void lstStorageItem_DoubleClick(object sender, EventArgs e)
        {
            if (lstStorageItem.SelectedItems.Count == 0)
                return;
            StorageItemRow storageItem = (StorageItemRow)lstStorageItem.SelectedItems[0].Tag;
            WorkSpaceRow workSpace = (WorkSpaceRow)this.frmMain.tvWorkSpace.SelectedNode.Tag;

            FrmStorageItem frmStorageItem = new FrmStorageItem();
            frmStorageItem.frmMain = this.frmMain;
            frmStorageItem.TheWorkSpace = workSpace;
            frmStorageItem.StorageItem = storageItem;
            frmStorageItem.WorkSpaceList = this.frmMain.tvWorkSpace.GetWorkSpaceListFromTree();
            frmStorageItem.ShowDialog();
            //DisplayStorageItems();
            lstStorageItem.PutStorageItemInListViewItem((ListViewStorageItem)lstStorageItem.SelectedItems[0], frmStorageItem.StorageItem);

        }






    }
}
