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
    public partial class FrmReferenceDrag : Form
    {
        bool mIsSaved = false;
        public bool IsSaved
        {
            get { return mIsSaved; }
            set { mIsSaved = value; }
        }


        StorageItemRow mMainStorageItem;
        public StorageItemRow MainStorageItem
        {
            get { return mMainStorageItem; }
            set { mMainStorageItem = value; }
        }


        StorageItemRow mRefStorageItem;
        public StorageItemRow RefStorageItem
        {
            get { return mRefStorageItem; }
            set { mRefStorageItem = value; }
        }

        public FrmReferenceDrag()
        {
            InitializeComponent();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            RefStorageItemDT refStorageItem = new RefStorageItemDT();
            if (refStorageItem.LoadByPrimaryKey(mMainStorageItem.ID, mRefStorageItem.ID))
            {
                Helper.ERRORMSG("Reference already Exists !");
                return;
            }

            if (mMainStorageItem.ID == mRefStorageItem.ID)
            {
                Helper.ERRORMSG("Self Reference Is Not Allowed !");
                return;

            }
            RefStorageItemRow refStorageItemRow = refStorageItem.NewRefStorageItemRow();
            //refStorageItem.AddNew();

            refStorageItemRow.MainStorageItemID = mMainStorageItem.ID;
            refStorageItemRow.RefStorageItemID = mRefStorageItem.ID;
            refStorageItemRow.Save();

            mIsSaved = true;
            Close();

        }
        [DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(int hWnd);

        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);

        private void BringToFront(string className, string CaptionName)
        {
            SetForegroundWindow(FindWindow(className, CaptionName));
        }

        private void FrmReferenceDrag_Load(object sender, EventArgs e)
        {
            SetForegroundWindow(Handle.ToInt32());
            DisplayStorageItems();

        }
        private void DisplayStorageItems()
        {
            txtMainStorageName.Text = mMainStorageItem.ItemName;
            txtMainStorageDesc.Text = mMainStorageItem.Description;

            txtRefStorageName.Text = mRefStorageItem.ItemName;
            txtRefStorageDesc.Text = mRefStorageItem.Description;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            StorageItemRow tmp = mMainStorageItem;
            mMainStorageItem = mRefStorageItem;
            mRefStorageItem = tmp;

            DisplayStorageItems();
        }

    }
}
