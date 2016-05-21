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
    public partial class FrmGenerateReport : Form
    {

        ListViewStorage mListViewStorage;
        List<StorageItemRow> mRreportStorageItemList;

        public FrmGenerateReport(ListViewStorage pListViewStorage, List<StorageItemRow> pRreportStorageItemList)
        {
            InitializeComponent();
            mListViewStorage = pListViewStorage;
            mRreportStorageItemList = pRreportStorageItemList;


        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "HTML|*.html|HTM|*.htm|All Files|*.*";
            dialog.Title = "Save Report File";
            dialog.AddExtension = true;

            StreamWriter sWriter;
            String targetDir = "";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                sWriter = new StreamWriter(dialog.FileName);
                targetDir = Path.GetDirectoryName(dialog.FileName);
                //FileStream fs = new FileStream(dialog.FileName , 

            }
            else
            {
                return;
            }



            List<StorageItemRow> storageItemList = GetSortedStorageItemList();
            StringBuilder sBuilder = new StringBuilder();
            //StorageItem storageItem;
            sBuilder.Append("<table border=\"3\">");
            //foreach (ListViewStorageItem listViewStorageItem in mListViewStorage.SelectedItems)
            sBuilder.Append("<tr>\r\n");
            //if (chkIsHyperLink.Checked)
           sBuilder.Append("<th>File</th>\r\n");
            if (chkInferedYear.Checked)
                sBuilder.Append("<th>Publishing Year</th>\r\n");

            sBuilder.Append("<th>Title</th>\r\n");
            sBuilder.Append("</tr>\r\n");
            foreach (StorageItemRow storageItem in storageItemList)
            {
                // storageItem = listViewStorageItem.StorageItem;
                sBuilder.Append("<tr>");
                sBuilder.Append("<td>");
                if (chkIsHyperLink.Checked)
                    sBuilder.Append(string.Format("<a href='{0}'>", storageItem.s_ItemName));

                sBuilder.Append(storageItem.s_ItemName);

                if (chkIsHyperLink.Checked)
                    sBuilder.Append("</a>");


                sBuilder.Append("</td>");

                if (chkID.Checked)
                {
                    sBuilder.Append("<td>");
                    sBuilder.Append(storageItem.s_ID);
                    sBuilder.Append("</td>");
                }
                if (chkURL.Checked)
                {
                    sBuilder.Append("<td>");
                    sBuilder.Append(string.Format("<a href='{0}'>", storageItem.s_URL));
                    sBuilder.Append("Link");
                    sBuilder.Append("</a>");
                    sBuilder.Append("</td>");
                }

                if (chkFullPath.Checked)
                {
                    sBuilder.Append("<td>");
                    sBuilder.Append(storageItem.s_FullPath);
                    sBuilder.Append("</td>");
                }

                if (chkInferedYear.Checked)
                {
                    sBuilder.Append("<td>");
                    sBuilder.Append(storageItem.InferedYear.ToString());
                    sBuilder.Append("</td>");
                }


                sBuilder.Append("<td>");
                sBuilder.Append(storageItem.s_Description);
                sBuilder.Append("</td>");

                sBuilder.Append("</tr>\r\n");

                if (chkCopyFiles.Checked)
                    CopyStorageItemToDir(storageItem, targetDir);

            }
            sBuilder.Append("</table>");


            sWriter.Write(sBuilder.ToString());
            sWriter.Flush();
            sWriter.Close();
            Helper.OKMSG("Generate Completed ");
            dialog.Dispose();
            dialog = null;




        }

        private List<StorageItemRow> GetSortedStorageItemList()
        {
            List<StorageItemRow> list = new List<StorageItemRow>();
            if (rdioFullList.Checked)
            {
                foreach (ListViewStorageItem listViewStorageItem in mListViewStorage.SelectedItems)
                    list.Add(listViewStorageItem.StorageItem);


            }
            else
                list = mRreportStorageItemList;


            if (chkSortByInferedYear.Checked)
                foreach (StorageItemRow storageItemLoop in list)
                    storageItemLoop.InferYear();

            if (chkSortByInferedYear.Checked)
            {
                list.Sort(
                   delegate(StorageItemRow first, StorageItemRow second)
                   {
                       return first.InferedYear.CompareTo(second.InferedYear);
                   }
               );
            }


            return list;
        }

        private void CopyStorageItemToDir(StorageItemRow pStorageItem, string pTargetDir)
        {

            StorageItemRow sItem = pStorageItem;
            if (sItem.IsFileExist())
            {
                string sourceFileName = Path.GetFileName(sItem.FullPath);
                string destFile = Path.Combine(pTargetDir, sourceFileName);
                File.Copy(sItem.FullPath, destFile, true);
            }
            else if (sItem.IsDirectoryExist())
            {

                DirectoryInfo dirInfo = new DirectoryInfo(sItem.s_FullPath);

                String destDir = pTargetDir + Path.DirectorySeparatorChar + dirInfo.Name;
                CopyDirectory(sItem.s_FullPath, destDir);
                //string[] files = System.IO.Directory.GetFiles(sItem.s_FullPath);

                //string fileName;
                //string destFile;
                //foreach (string s in files)
                //{
                //    // Use static Path methods to extract only the file name from the path.
                //    fileName = System.IO.Path.GetFileName(s);
                //    destFile = System.IO.Path.Combine(pTargetDir, fileName);
                //    System.IO.File.Copy(s, destFile, true);
                //}

            }
        }
        private void CopyDirectory(string Src, string Dst)
        {
            String[] Files;

            if (Dst[Dst.Length - 1] != Path.DirectorySeparatorChar)
                Dst += Path.DirectorySeparatorChar;
            if (!Directory.Exists(Dst))
                Directory.CreateDirectory(Dst);
            Files = Directory.GetFileSystemEntries(Src);
            foreach (string Element in Files)
            {
                // Sub directories

                if (Directory.Exists(Element))
                    CopyDirectory(Element, Dst + Path.GetFileName(Element));
                // Files in directory

                else
                    File.Copy(Element, Dst + Path.GetFileName(Element), true);
            }
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
