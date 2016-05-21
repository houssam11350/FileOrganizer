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
using System.Diagnostics;

namespace FileOrganizer.UI
{
    public partial class FrmStorageItem : Form
    {
        public FrmMain frmMain;
        bool mIsDownloadManagerHandledOK = false;
        bool mIsSaved = false;
        public bool IsSaved
        {
            get { return mIsSaved; }
            set { mIsSaved = value; }
        }
        bool mIsCancelAll = false;
        public bool IsCancelAll
        {
            get { return mIsCancelAll; }
            //set { mIsCancelAll = value; }
        }


        bool mIsDragged = false;
        public bool IsDragged
        {
            get { return mIsDragged; }
            set { mIsDragged = value; }
        }

        bool mIsPaused = false;
        public bool IsPaused
        {
            get { return mIsPaused; }
            set { mIsPaused = value; }
        }
        StorageItemRow mStorageItem;
        public StorageItemRow StorageItem
        {
            get { return mStorageItem; }
            set { mStorageItem = value; }
        }

        WorkSpaceRow mWorkSpace;
        public WorkSpaceRow TheWorkSpace
        {
            get { return mWorkSpace; }
            set { mWorkSpace = value; }
        }

        //WorkSpaceDT mWorkSpaceList;
        List<WorkSpaceRow> mWorkSpaceList;
        public List<WorkSpaceRow> WorkSpaceList
        {
            get { return mWorkSpaceList; }
            set { mWorkSpaceList = value; }
        }

        public FrmStorageItem()
        {
            InitializeComponent();
        }
        void SetStorageItem()
        {
            //mStorageItem.WorkSpaceID = mWorkSpace.ID;
            mStorageItem.WorkSpaceID = int.Parse(lstCategory.SelectedValue.ToString());
            mStorageItem.URL = txtURL.Text;
            mStorageItem.FullPath = txtFullPath.Text;
            mStorageItem.ItemName = txtName.Text;
            mStorageItem.Size = txtSize.Text;
            if (string.IsNullOrEmpty(txtPriority.Text))
                txtPriority.Text = "0";
            mStorageItem.Priority = int.Parse(txtPriority.Text);
            if (string.IsNullOrEmpty(txtPagesCount.Text))
                txtPagesCount.Text = "0";
            mStorageItem.PagesCount = int.Parse(txtPagesCount.Text);
            mStorageItem.Description = txtDescription.Text;
            mStorageItem.IsFixed = chkIsFixed.Checked;
            mStorageItem.Citation = txtCitation.Text;
            mStorageItem.ReferenceBib = txtReferencesBib.Text;
            mStorageItem.ImportantParts = txtImportantParts.Text;
            if (pkrAdditionDate.Value == null)
                mStorageItem.s_AdditionDate = String.Empty;
            else
                mStorageItem.AdditionDate = DateTime.Parse(pkrAdditionDate.Value.ToString());

        }


        void DisplayStorageItem()
        {
            txtID.Text = mStorageItem.s_ID;
            txtURL.Text = mStorageItem.s_URL;
            txtFullPath.Text = mStorageItem.s_FullPath;
            txtName.Text = mStorageItem.s_ItemName;
            txtSize.Text = mStorageItem.s_Size;
            txtPriority.Text = mStorageItem.s_Priority;
            txtPagesCount.Text = mStorageItem.s_PagesCount;
            txtDescription.Text = mStorageItem.s_Description;
            lstCategory.SelectedValue = mStorageItem.WorkSpaceID;
            chkIsFixed.Checked = mStorageItem.IsFixed;
            txtCitation.Text = mStorageItem.s_Citation;
            txtReferencesBib.Text = mStorageItem.s_ReferenceBib;
            txtImportantParts.Text = mStorageItem.s_ImportantParts;

            if (string.IsNullOrEmpty(mStorageItem.s_AdditionDate))
                pkrAdditionDate.Value = null;
            else
                pkrAdditionDate.Value = mStorageItem.AdditionDate;


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            txtDescription.Text = txtDescription.Text.Replace(Environment.NewLine, " ");
            CheckTextBoxes();

            bool isNew = true;
            FrmSimilarItems frmSimilarItems = new FrmSimilarItems();
            frmSimilarItems.frmMain = this.frmMain;

            mStorageItem = StorageItemDT.NewRowDefault();
            if (!string.IsNullOrEmpty(txtID.Text))
            {
                isNew = false;
                StorageItemDT dt = new StorageItemDT();
                dt.LoadByPrimaryKey(int.Parse(txtID.Text));
                //mStorageItem.LoadByPrimaryKey(int.Parse(txtID.Text));
                mStorageItem = dt[0];
                SetStorageItem();
                mStorageItem.Save();
                DisplayStorageItem();
                mIsSaved = true;
                Close();

            }
            else
            {
                isNew = true;
                frmSimilarItems.IsLoadEvent = true;
                frmSimilarItems.txtDescription.Text = txtDescription.Text;
                frmSimilarItems.CheckSimilarStorageItems();
                frmSimilarItems.ShowDialog(this);
                if (frmSimilarItems.FrmSimilarItemsResult == FrmSimilarItemsResult.Save)
                {
                    //mStorageItem.AddNew();
                    SetStorageItem();
                    mStorageItem.Save();
                }


            }

            if (frmSimilarItems.FrmSimilarItemsResult == FrmSimilarItemsResult.Save)
            {
                DisplayStorageItem();
                mIsSaved = true;
                Close();
            }
            else if (frmSimilarItems.FrmSimilarItemsResult == FrmSimilarItemsResult.DontSave)
            {
                mStorageItem = null;
                mIsSaved = false;
                Close();
            }
            else if (frmSimilarItems.FrmSimilarItemsResult == FrmSimilarItemsResult.None)
            {
                if (isNew)
                    mStorageItem = null;
            }


        }

        private void CheckTextBoxes()
        {
#if BUID_FOR_ME


            if (!IsURL_OK())
            {
                Helper.ERRORMSG("Please Check URL ! ");

            }

            if (!IsDescription_OK())
            {
                Helper.ERRORMSG("Please Check Description ! ");

            }
#endif
        }

        private bool IsDescription_OK()
        {
            return AllowedStringHandler.GetInstance().IsFullStringOK(txtDescription.Text);
        }

        private bool IsURL_OK()
        {
            if (string.IsNullOrEmpty(txtURL.Text))
                return false;

            try
            {
                UriBuilder uriBuilder = new UriBuilder(txtURL.Text);
                //host = uriBuilder.Host;
                return true;
            }
            catch
            {
                return false;

            }



        }

        [DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(int hWnd);

        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);

        private void BringToFront(string className, string CaptionName)
        {
            SetForegroundWindow(FindWindow(className, CaptionName));
        }

        private void FrmStorageItem_Load(object sender, EventArgs e)
        {
            pkrAdditionDate.Value = DateTime.Now;
            //BringToFront("Notepad", "Untitled - Notepad");
            //BringToFront("Notepad", this.Text);
            DisplayWorkSpaceList();
            //SetForegroundWindow(Handle.ToInt32());
            if (mIsDownloadManagerHandledOK)
            {
                this.ActiveControl = txtDescription;
                txtDescription.Focus();
                txtDescription.SelectAll();
            }
            if (mIsDragged)
                return;
            if (mStorageItem == null)
                return;
            DisplayStorageItem();
        }

        private void DisplayWorkSpaceList()
        {
            //lblCategory.Visible = mWorkSpace.IsForAll;
            lstCategory.DataSource = mWorkSpaceList;
            lstCategory.DisplayMember = WorkSpaceDT.ColumnNames.WName;
            lstCategory.ValueMember = WorkSpaceDT.ColumnNames.ID;

            lstCategory.Text = mWorkSpace.s_WName;

            //if (mWorkSpace.IsForAll)
            //{
            //    lstCategory.Enabled = true;

            //}
            //else
            //{
            //    if (mStorageItem != null)
            //    {
            //        if (mStorageItem.ID > 0)
            //            lstCategory.Enabled = false; ;
            //    }
            //    else
            //        lstCategory.Enabled = false; ;

            //   lstCategory.Text = mWorkSpace.WName;

            // }




        }

        internal void SetDraggedFile(FileInfo pFileInfo)
        {

            txtName.Text = pFileInfo.Name;
            txtFullPath.Text = pFileInfo.FullName;
            PutPagesCount();
            DirectorySize dSize = new DirectorySize();
            if (Directory.Exists(pFileInfo.FullName))
            {
                txtSize.Text = dSize.GetStringSize(pFileInfo.FullName); ;
                //chkIsFolder.Checked = true;
            }
            else
                txtSize.Text = dSize.FormatSize(pFileInfo.Length);
            try
            {
                HandleDownLoadManager(pFileInfo.Name);
            }
            catch (Exception ex)
            {
                Helper.HandleException(ex);
            }
            mIsDragged = true;
        }

        private void HandleDownLoadManager(string pDraggedFileName)
        {
            if (!Options.GetInstance().IsIDM)
                return;

            string draggedFileName = pDraggedFileName;
            if (string.IsNullOrEmpty(draggedFileName))
                return;

            RegistryKey currentRegistryKey = Registry.CurrentUser;
            RegistryKey softwareRegistryKey = currentRegistryKey.OpenSubKey("SOFTWARE");
            RegistryKey downloadManagerRegistryKey = softwareRegistryKey.OpenSubKey("DownloadManager");
            int valueCount = downloadManagerRegistryKey.ValueCount;
            List<string> mList = new List<string>();
            string[] subKeyNames = downloadManagerRegistryKey.GetSubKeyNames();
            for (int i = 0; i < subKeyNames.Length; i++)
            {

                //string subKey = (string)downloadManagerRegistryKey.GetValue(subKeyNames[i]);
                //if (subKeyNames[i] == "386")
                //    MessageBox.Show("386");
#if(DEBUG)
                if (subKeyNames[i] == "687")
                {

                }
# endif
                RegistryKey entryRegistryKey = downloadManagerRegistryKey.OpenSubKey(subKeyNames[i]);
                //object objFileName = entryRegistryKey.GetValue("FileName");
                //if (objFileName != null)
                //    if (objFileName is string)
                //    {
                //        string regFileName = (string)objFileName;
                //        if (string.IsNullOrEmpty(regFileName))
                //            return;

                //        mList.Add(regFileName);
                //    }






                object objUrl0 = entryRegistryKey.GetValue("Url0");
                string url0 = string.Empty;
                if (objUrl0 != null)
                    if (objUrl0 is string)
                    {
                        url0 = (string)objUrl0;
                        string regFileName = url0.Substring(url0.LastIndexOf("/") + 1);
                        if (!string.IsNullOrEmpty(regFileName))
                            if (IsStringsEquals(regFileName, draggedFileName))
                            {
                                txtURL.Text = url0;
                                mIsDownloadManagerHandledOK = true;
                                break;
                            }


                    }

                object objLocalFileName = entryRegistryKey.GetValue("LocalFileName");
                if (objLocalFileName != null)
                    if (objLocalFileName is string)
                    {
                        string regLocalFileName = (string)objLocalFileName;
                        if (!string.IsNullOrEmpty(regLocalFileName))
                        {
                            string lLocalFileName = Path.GetFileName(regLocalFileName);
                            if (!string.IsNullOrEmpty(lLocalFileName))
                            {
                                if (IsStringsEquals(lLocalFileName, draggedFileName))
                                {
                                    string extractedURL = HandleGoogleURL(url0);
                                    txtURL.Text = extractedURL;
                                    mIsDownloadManagerHandledOK = true;
                                    break;
                                }

                            }

                        }

                    }


                //object objFileSize = entryRegistryKey.GetValue("FileSize");
                //if (objFileSize != null)
                //    if (objFileSize is string)
                //    {
                //        string fileSize = (string)objFileSize;


                //        mList.Add(fileSize);
                //    }


            }

        }

        private string HandleGoogleURL(string pUrl0)
        {
            string newUrl = pUrl0;
            QueryString queryString = QueryString.FromUrl(pUrl0);
            string urlValue = queryString.GetValue("url");
            if (urlValue != string.Empty)

                newUrl = Uri.UnescapeDataString(urlValue);

            return newUrl;
        }

        private bool IsStringsEquals(string pStrA, string pStrB)
        {
            if (string.IsNullOrEmpty(pStrA))
            {
                if (string.IsNullOrEmpty(pStrB))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(pStrA))
                {
                    return false;
                }
                else
                {
                    //both not null
                    string newStrA = Uri.UnescapeDataString(pStrA);
                    string newStrB = Uri.UnescapeDataString(pStrB);
                    return newStrA.Trim().ToUpper().Equals(newStrB.Trim().ToUpper());
                }
            }
        }
        public void PutPagesCount()
        {
            try
            {
                string extension = string.Empty;

                extension = Path.GetExtension(txtFullPath.Text);
                if (string.IsNullOrEmpty(extension))
                    extension = Path.GetExtension(txtName.Text);

                if (string.IsNullOrEmpty(extension))
                {
                    return;
                }


                if (extension.ToUpper().Equals(".PDF".ToUpper()))
                {
                    string file = Path.GetFullPath(txtFullPath.Text);
                    if (File.Exists(file))
                    {
                        PdfReader reader = new PdfReader(file);
                        txtPagesCount.Text = reader.NumberOfPages.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                Helper.HandleException(ex);
            }



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetFilesIndexAndCount(int pFileIndex, int pFilesCount)
        {
            btnCancelAll.Visible = true;
            btnPause.Visible = true;
            lblFileIndex.Visible = true;
            if ((pFilesCount == 0) || (pFilesCount == 1))
            {
                btnCancelAll.Visible = false;
                btnPause.Visible = false;
                lblFileIndex.Visible = false;
            }
            if (pFileIndex == (pFilesCount - 1))
            {
                btnCancelAll.Visible = false;
                btnPause.Visible = false;
                lblFileIndex.Visible = false;

            }

            lblFileIndex.Text = string.Format("File {0} From Files {1}", (pFileIndex + 1), pFilesCount);


        }

        private void btnCancelAll_Click(object sender, EventArgs e)
        {
            mIsCancelAll = true;
            this.Close();

        }

        private void btnCalcSizeName_Click(object sender, EventArgs e)
        {

            FileInfo fileInfo = new FileInfo(txtFullPath.Text);
            txtName.Text = fileInfo.Name;
            PutPagesCount();
            DirectorySize dSize = new DirectorySize();
            if (Directory.Exists(fileInfo.FullName))
            {

                txtSize.Text = dSize.GetStringSize(fileInfo.FullName); ;
                //chkIsFolder.Checked = true;
            }
            else
                txtSize.Text = dSize.FormatSize(fileInfo.Length);



        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = txtFullPath.Text;
            process.Start();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            mIsPaused = true;
            this.Close();
        }

        private void btnGetURL_Click(object sender, EventArgs e)
        {
            FileInfo fileInfo = new FileInfo(txtFullPath.Text);
            HandleDownLoadManager(fileInfo.Name);
        }
    }
}
