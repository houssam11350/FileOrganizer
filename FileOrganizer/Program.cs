using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FileOrganizer.UI;
using System.Configuration;
using System.IO;
using System.Diagnostics;

namespace FileOrganizer
{
#if BUID_FOR_ME

#endif

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //string exePath = Path.GetFullPath(Application.ExecutablePath);
            //FileInfo fInfo = new FileInfo(exePath);
            //string dbPath = fInfo.Directory.FullName + Path.DirectorySeparatorChar + "FileOrganizerDB.mdb";
            //string dbConnection = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;User ID=Admin;Data Source={0};Persist Security Info=False", dbPath);
            //ConfigurationSettings.AppSettings["dbConnection"] = dbConnection;
            //Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmMain frm = new FrmMain();
            //FrmTest frm = new FrmTest();
            //Helper.ERRORMSG();
            Application.Run(frm);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Helper.HandleException(e.Exception);
        }
    }
}
