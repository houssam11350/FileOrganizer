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

namespace FileOrganizer.UI
{
    public partial class FrmFileMove : Form
    {

        bool mIsOK = false;
        public bool IsOK
        {
            get { return mIsOK; }
            //set { mIsOK = value; }
        }

        public StorageItemRow StorageItem;

        public FrmFileMove()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                File.Move(txtFullPath.Text, txtNewFullPath.Text);
                FileInfo fileInfo = new FileInfo(txtNewFullPath.Text);
                txtName.Text = fileInfo.Name;
                StorageItem.s_FullPath = txtNewFullPath.Text;
                StorageItem.s_ItemName = txtName.Text;
                StorageItem.s_Description = txtDescription.Text;
                StorageItem.Save();
                mIsOK = true;

            }
            catch (Exception ex)
            {
                Helper.HandleException(ex);
                mIsOK = false;
            }

            if (mIsOK)
                Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mIsOK = false;
            Close();
        }


        private void FrmFileMove_Load(object sender, EventArgs e)
        {
            mIsOK = false;
            txtID.Text = StorageItem.s_ID;
            //txtURL.Text = mStorageItem.s_URL;
            txtFullPath.Text = StorageItem.s_FullPath;
            txtName.Text = StorageItem.s_ItemName;
            txtDescription.Text = StorageItem.s_Description;
            txtNewFullPath.Text = StorageItem.s_FullPath;
        }

        private void FrmFileMove_Activated(object sender, EventArgs e)
        {
            txtNewFullPath.Focus();
        }

        private void btnBrows_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName =txtNewFullPath.Text;
            //savefile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                txtNewFullPath.Text = savefile.FileName;

            }
        }
    }
}
