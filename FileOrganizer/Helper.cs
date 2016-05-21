using System;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using Microsoft.Win32;

namespace System
{
    public class Helper
    {

        public Helper()
        {

        }

        //public static void MSG(string msg)
        //{
        //    System.Windows.Forms.MessageBox.Show(msg);
        //}
        public static string GetStandardBrowserPath()
        {
            string browserPath = string.Empty;
            RegistryKey browserKey = null;
            try
            {
                //Read default browser path from Win XP registry key
                browserKey = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command", false);
                //If browser path wasn't found, try Win Vista (and newer) registry key
                if (browserKey == null)
                {
                    browserKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http", false); ;
                }

                //If browser path was found, clean it
                if (browserKey != null)
                {
                    //Remove quotation marks
                    browserPath = (browserKey.GetValue(null) as string).ToLower().Replace("\"", "");

                    //Cut off optional parameters
                    if (!browserPath.EndsWith("exe"))
                    {
                        browserPath = browserPath.Substring(0, browserPath.LastIndexOf(".exe") + 4);
                    }

                    //Close registry key
                    browserKey.Close();
                }
            }
            catch
            {
                //Return empty string, if no path was found
                return string.Empty;
            }
            //Return default browsers path
            return browserPath;
        }

      


        public static int DecimalToFloorInt(decimal DecimalVal_)
        {
            int nVal = 0;
            nVal = (int)Math.Floor((double)DecimalVal_);
            return nVal;
        }

        public static int DecimalToCeilingInt(decimal DecimalVal_)
        {
            int nVal = 0;
            nVal = (int)Math.Ceiling((double)DecimalVal_);
            return nVal;
        }

        public static int DecimalToCeilingInt(double DoubleVal_)
        {
            int nVal = 0;
            nVal = (int)Math.Ceiling(DoubleVal_);
            return nVal;
        }
        public static void HandleException(Exception e)
        {
            string s = "Message= " + e.Message + "\n";
            s += "Source= " + e.Source + "\n";
            s += "Stack Trace= " + e.StackTrace + "\n";
            Exception inner = e.InnerException;
            MessageBox.Show(s);
            while (inner != null)
            {
                string ss = "Message= " + inner.Message + "\n";
                ss += "Source= " + inner.Source + "\n";
                ss += "Stack Trace= " + inner.StackTrace + "\n";
                MessageBox.Show(ss);
                inner = inner.InnerException;
            }
        }

        public static void ERRORMSG(string _Msg)
        {
            string _Caption = "File Organizer";
            System.Windows.Forms.MessageBox.Show(_Msg, _Caption,
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Error,
                System.Windows.Forms.MessageBoxDefaultButton.Button1);
        }
        public static void OKMSG(string _Msg)
        {
            string _Caption = "File Organizer";
            System.Windows.Forms.MessageBox.Show(_Msg, _Caption,
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Information,
                System.Windows.Forms.MessageBoxDefaultButton.Button1);
        }

        public static bool GetResultFromMSG(string msg)
        {
            if (msg.Equals(String.Empty))
                return true;
            else
            {
                Helper.ERRORMSG(msg);
                return false;
            }
        }
    }

}
