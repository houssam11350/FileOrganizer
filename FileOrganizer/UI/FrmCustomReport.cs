using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FileOrganizer.BL;

namespace FileOrganizer.UI
{
    public partial class FrmCustomReport : Form
    {

        public FrmMain frmMain; 
        ListViewStorage mListViewStorage;
        AllowedStringHandler mAllowedStringHandler;

       


        public FrmCustomReport(ListViewStorage pListViewStorage)
        {
            //Char.
            InitializeComponent();
            mListViewStorage = pListViewStorage;


        }



        private void btnGenerate_Click(object sender, EventArgs e)
        {

            List<StorageItemRow> list = new List<StorageItemRow>();
            mAllowedStringHandler  = AllowedStringHandler.GetInstance();

            foreach (ListViewStorageItem listViewStorageItem in mListViewStorage.Items)
            {
                if (!IsItemOK(listViewStorageItem.StorageItem))
                {
                    lstStorage.AddNewStorageItem(listViewStorageItem.StorageItem);
                }

            }


        }

        private bool IsItemOK(StorageItemRow pStorageItem)
        {
            foreach (char s in pStorageItem.s_Description)
            {
                if (!mAllowedStringHandler.IsSingleStringOK(s))
                {
                    return false;
                }
            }

            return true;
        }

        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lstStorage_DoubleClick(object sender, EventArgs e)
        {
            if (lstStorage.SelectedItems.Count == 0)
                return;
            StorageItemRow storageItem = (StorageItemRow)lstStorage.SelectedItems[0].Tag;
           // WorkSpace workSpace = (WorkSpace)FrmMain.GetInstance().tvWorkSpace.SelectedNode.Tag;
            WorkSpaceDT workSpace = new WorkSpaceDT();
            workSpace.LoadByPrimaryKey(storageItem.WorkSpaceID);
            FrmStorageItem frmStorageItem = new FrmStorageItem();
            frmStorageItem.frmMain = this.frmMain;
            frmStorageItem.TheWorkSpace = workSpace[0];
            frmStorageItem.StorageItem = storageItem;
            frmStorageItem.WorkSpaceList = this.frmMain.tvWorkSpace.GetWorkSpaceListFromTree();
            frmStorageItem.ShowDialog();
            //DisplayStorageItems();
            lstStorage.PutStorageItemInListViewItem((ListViewStorageItem)lstStorage.SelectedItems[0], frmStorageItem.StorageItem);

        }

        private void FrmCustomReport_Load(object sender, EventArgs e)
        {
            lstStorage.SmallImageList = SystemIconsManager.GetInstance().SmallIconsImageList;
            lstStorage.LargeImageList = SystemIconsManager.GetInstance().LargeIconsImageList;

        }
    }
}
