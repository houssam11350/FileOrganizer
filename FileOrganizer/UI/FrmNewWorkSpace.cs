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
    public partial class FrmNewWorkSpace : Form
    {
        WorkSpaceRow mWorkSpace;
        public WorkSpaceRow WorkSpace
        {
            get { return mWorkSpace; }
            set { mWorkSpace = value; }
        }

        bool mIsOK = false;
        public bool IsOK
        {
            get { return mIsOK; }
            //set { mIsOK = value; }
        }

        public FrmNewWorkSpace()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mWorkSpace.WName = txtWName.Text;
            mWorkSpace.IsActive = chkIsActive.Checked;
            mWorkSpace.Save();
            mIsOK = true;
            Close();


        }

        private void FrmNewWorkSpace_Load(object sender, EventArgs e)
        {
            
            txtID.Text = mWorkSpace.s_ID;
            txtWName.Text = mWorkSpace.s_WName;
            if (!string.IsNullOrEmpty(mWorkSpace.s_IsActive))
                chkIsActive.Checked = mWorkSpace.IsActive;

            ActiveControl = txtWName;
        }
    }
}
