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
    public partial class FrmOptions : Form
    {


        public FrmOptions()
        {
            InitializeComponent();

        }

        private void FrmOptions_Load(object sender, EventArgs e)
        {
            chkIsSameSiteLoad.Checked = Options.GetInstance().IsSameSiteLoadingEnabled;
            chkIsSimilarItemsLoad.Checked = Options.GetInstance().IsSimilarItemsLoad ;
            chkIsQuickListLoad.Checked = Options.GetInstance().IsQuickListLoad;
            chkIDM.Checked = Options.GetInstance().IsIDM;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Options.GetInstance().IsSameSiteLoadingEnabled = chkIsSameSiteLoad.Checked;
            Options.GetInstance().IsSimilarItemsLoad = chkIsSimilarItemsLoad.Checked;
            Options.GetInstance().IsQuickListLoad = chkIsQuickListLoad.Checked;
            Options.GetInstance().IsIDM = chkIDM.Checked;
            Close();
        }

       }
}
