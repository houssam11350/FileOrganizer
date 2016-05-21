using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileOrganizer.UI
{
    public partial class FrmInputBox : Form
    {

        bool mIsOK = false;
        string mInputValue = string.Empty;

        public string InputValue
        {
            get { return mInputValue; }
            //set { mInputValue = value; }
        }

        public bool IsOK
        {
            get { return mIsOK; }
            //set { mIsOK = value; }
        }

        public FrmInputBox()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            mInputValue = txtValue.Text;
            mIsOK = true;
            Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mIsOK = false;
            Close();
        }

        public void ShowInputMsg(String pTitle, String pInputMsg)
        {
            this.Text = pTitle;
            lblMsg.Text = pInputMsg;
            ShowInTaskbar = false;


        }

        private void FrmInputBox_Activated(object sender, EventArgs e)
        {
            txtValue.Focus();
        }
    }
}
