using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;

namespace FileOrganizer.UI
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();

        }
         private void pictureBox1_Click(object sender, EventArgs e)
        {
            string url = "";

            string business = "houssam11350@yahoo.com";  // your paypal email
            string description = "Donation";            // '%20' represents a space. remember HTML!
            string country = "DE";                  // AU, US, etc.
            string currency = "USD";                 // AUD, USD, etc.

            url += "https://www.paypal.com/cgi-bin/webscr" +
                "?cmd=" + "_donations" +
                "&business=" + business +
                "&lc=" + country +
                "&item_name=" + description +
                "&currency_code=" + currency +
                "&bn=" + "PP%2dDonationsBF";

            string browserPath = Helper.GetStandardBrowserPath();
            if (string.IsNullOrEmpty(browserPath))
            {
               //MessageBox.Show("No default browser found!");
            }
            else
            {
                Process.Start(browserPath, url);
            }
        }

         private void FrmAbout_Load(object sender, EventArgs e)
         {
             lblCurrentVersion.Text = FrmMain.CurrentVersion;
         }

         private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
         {
             string browserPath = Helper.GetStandardBrowserPath();
             if (!string.IsNullOrEmpty(browserPath))
             {
                 Process.Start(browserPath, "https://github.com/houssam11350/FileOrganizer/");
             }
             
         }






    }
}
