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
using System.Threading;
using iTextSharp.text.pdf;

namespace FileOrganizer.UI
{
    public partial class CtrlSearchContentProgress : UserControl
    {
        ListView mListView;
        public ListView ListView
        {
            get { return mListView; }
            set { mListView = value; }
        }

        string mTextToSearch;
        public string TextToSearch
        {
            get { return mTextToSearch; }
            set { mTextToSearch = value; }
        }

        bool mIsStopped = false;
        public bool IsStopped
        {
            get { return mIsStopped; }
            set { mIsStopped = value; }
        }
        int mFilesFound = 0;

        Thread myThread;
        private bool IsDisposed = false;

        List<FileEntry> mLstFileEntry;

        public CtrlSearchContentProgress()
        {
            InitializeComponent();
        }

        ~CtrlSearchContentProgress()
        {

            //Console.WriteLine("DESTRUCTING...");

            H_Dispose(true);

        }

        public void H_Dispose()
        {

            H_Dispose(false);

        }

        private void H_Dispose(bool IsCallFromDestructor)
        {

            if (!IsDisposed)
            {

                if (myThread != null) myThread.Abort();
                myThread = null;

                if (!IsCallFromDestructor)
                    System.GC.SuppressFinalize(this);
                IsDisposed = true;

            }


        }

        private void FrmSearchContentProgress_Load(object sender, EventArgs e)
        {


        }

        public void RunSearchThread()
        {
            if (string.IsNullOrEmpty(mTextToSearch))
            {
                lblFilesFound.Text = "";
                lblTotalFiles.Text = "No Text To Search!";
                btnStop.ButtonText = "Close";
                return;
            }
            prgFiles.Value = 0;
            prgFiles.Minimum = 0;
            btnStop.ButtonText = "Stop";
            mFilesFound = 0;
            lblFilesFound.Text = string.Format("Found: {0}", mFilesFound);
            FillLstFileEntry();
            prgFiles.Maximum = mLstFileEntry.Count;
            if (mLstFileEntry.Count == 0)
            {
                lblFilesFound.Text = "";
                lblTotalFiles.Text = "No Files !";
                btnStop.ButtonText = "Close";
                return;
            }

            if (myThread != null)
                if (myThread.ThreadState == ThreadState.Running)
                {
                    myThread.Abort();

                }
            myThread = new Thread(new ThreadStart(DOSearch));
            myThread.Priority = ThreadPriority.Normal;
            myThread.IsBackground = true;
            myThread.Start();
        }

        private void FillLstFileEntry()
        {
            mLstFileEntry = new List<FileEntry>();
            int itemsCount = mListView.Items.Count;
            List<string> extensionList = new List<string>() { ".TXT", ".HTM", ".HTM", ".XML" };

            for (int index = 0; index < itemsCount; index++)
            {


                ListViewItem item = mListView.Items[index];
                StorageItemRow storageItem = (StorageItemRow)item.Tag;

                if (storageItem.IsFileExist())
                {
                    string file = Path.GetFullPath(storageItem.s_FullPath);
                    string extension = storageItem.GetExtension();

                    if (extension.ToUpper().Equals(".PDF".ToUpper()))

                        mLstFileEntry.Add(new FileEntry(file, false, index, FileEntryType.PDF));

                    else if (extension.ToUpper().Equals(".DOCX".ToUpper()))

                        mLstFileEntry.Add(new FileEntry(file, false, index, FileEntryType.DOCX));
                    else if (extensionList.Contains(extension.ToUpper()))
                        mLstFileEntry.Add(new FileEntry(file, false, index, FileEntryType.TXT));
                }


            }
        }


        //    this.BeginInvoke(new MethodInvoker(delegate()
        //                    {
        //}));
        private void DOSearch()
        {

            int fileCounts = mLstFileEntry.Count;
            for (int fileIndex = 0; fileIndex < fileCounts; fileIndex++)
            {
                if (mIsStopped)
                    return;

                FileEntry fileEntry = mLstFileEntry[fileIndex];
                this.Invoke(new MethodInvoker(delegate()
                                {
                                    lblTotalFiles.Text = string.Format("{0}/{1}", (fileIndex + 1), fileCounts);
                                    prgFiles.Value++;
                                }));

                Application.DoEvents();
                HandleFileEntry(fileEntry);


            }//for
            this.Invoke(new MethodInvoker(delegate()
             {
                 btnStop.ButtonText = "Close";
             }));

        }

        private void HandleFileEntry(FileEntry pFileEntry)
        {
            if (pFileEntry.FileEntryType == FileEntryType.PDF)
                HanldPDFFileEntry(pFileEntry);
            else if (pFileEntry.FileEntryType == FileEntryType.DOCX)
                HandleDOCXFileEntry(pFileEntry);

            else if (pFileEntry.FileEntryType == FileEntryType.TXT)
                HandleTXTFileEntry(pFileEntry);

        }



        private void HandleDOCXFileEntry(FileEntry pFileEntry)
        {
            DocxToText dtt = new DocxToText(pFileEntry.FilePath);
            if (dtt.IsFileContainString(mTextToSearch))
                PutFileEntryToSearchResult(pFileEntry);


        }

        private void HanldPDFFileEntry(FileEntry pFileEntry)
        {
            PDFParser pdfParser = new PDFParser(this);
            //pdfParser.ExtractText(file, Path.GetFileNameWithoutExtension(file) + ".txt");
            if (pdfParser.IsFileContainString(pFileEntry.FilePath, mTextToSearch))
            {
                PutFileEntryToSearchResult(pFileEntry);



            }
        }

        private void HandleTXTFileEntry(FileEntry pFileEntry)
        {
            TxTParser txTParser = new TxTParser(pFileEntry.FilePath);
            if (txTParser.IsContainTxt(mTextToSearch))
                PutFileEntryToSearchResult(pFileEntry);


        }

        private void PutFileEntryToSearchResult(FileEntry pFileEntry)
        {
            mFilesFound++;
            pFileEntry.IsContain = true;
            //item.BackColor = Color.Red;
            this.Invoke(new MethodInvoker(delegate()
            {
                mListView.Items[pFileEntry.OriginalIndex].BackColor = Color.Red;
                lblFilesFound.Text = string.Format("Found: {0}", mFilesFound);
            }));
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            DoStop();

        }

        public void DoStop()
        {
            if (myThread != null)
            {
                if (myThread.ThreadState != ThreadState.Stopped)
                    if (myThread.ThreadState != ThreadState.Aborted)

                        myThread.Priority = ThreadPriority.Highest;
            }
            mIsStopped = true;
            btnStop.ButtonText = "Stopping...";
            H_Dispose();
            Application.DoEvents();
            if (myThread == null)
            {
                Hide();
                return;
            }
            while (myThread.IsAlive)
            {
                //myThread.Abort();
                Console.WriteLine(DateTime.Now.Millisecond);
            }




            if (myThread.ThreadState == ThreadState.Running)
            {
                myThread.Abort();
                Application.ExitThread();
                Hide();
            }

            if (myThread.ThreadState == ThreadState.Stopped)
            {
                myThread.Abort();
                //Application.ExitThread();
                Hide();
            }


            Hide();
        }




        //private void FrmSearchContentProgress_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    mIsStopped = true;
        //    btnStop.Text = "Stopping...";
        //    Application.DoEvents();
        //    while (myThread.IsAlive)
        //    {
        //        //Console.WriteLine(DateTime.Now.Millisecond);
        //    }



        //    if (myThread == null)
        //    {
        //        e.Cancel = false;
        //        return;
        //    }
        //    if (myThread.ThreadState == ThreadState.Running)
        //    {
        //        myThread.Abort();
        //        e.Cancel = false;
        //        Application.ExitThread();

        //    }

        //    e.Cancel = false;

        //}


    }
}
