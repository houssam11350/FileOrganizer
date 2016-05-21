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
    public partial class FrmQuickListEdit : Form
    {
        public QuickListRow quickListRow { set; get; }
        public bool IsOK { private set; get; }


        public FrmQuickListEdit()
        {
            InitializeComponent();
            IsOK = false;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            IsOK = false;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            quickListRow.LName = txtLName.Text;
            quickListRow.IsInToolBar = chkIsInTollbar.Checked;
            quickListRow.Save();
            IsOK = true;
            Close();
        }

        private void FrmQuickListEdit_Load(object sender, EventArgs e)
        {
            
            txtLName.Text = quickListRow.s_LName;
            this.ActiveControl = txtLName;
            if (!string.IsNullOrEmpty(quickListRow.s_ID))
                chkIsInTollbar.Checked = quickListRow.IsInToolBar;

        }
    }
}
