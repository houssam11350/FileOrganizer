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
    public partial class FrmNote : Form
    {

        public NoteItemRow noteItem { set; get; }
        public bool IsSaved { private set; get; }
        public StorageItemRow theStorageItem { set; get; }

        public FrmNote()
        {
            InitializeComponent();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isNew = false;
            if (string.IsNullOrEmpty(noteItem.s_ID))
            {
                //noteItem.AddNew();
                isNew = true;
            }

            SetNoteItem();
            noteItem.Save();
            if (isNew)
            {
                theStorageItem.NoteItemID = noteItem.ID;
                theStorageItem.Save();
            }

            IsSaved = true;
            Close();

        }
        [DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(int hWnd);

        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);

        private void BringToFront(string className, string CaptionName)
        {
            SetForegroundWindow(FindWindow(className, CaptionName));
        }

        private void FrmNoteItem_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(theStorageItem.s_NoteItemID))
            {
                NoteItemDT dt = new NoteItemDT();
                dt.LoadByPrimaryKey(theStorageItem.NoteItemID);
                noteItem = dt[0];

            }
            else
            {
                noteItem.NoteFileName = theStorageItem.FullPath + ".txt";
            }

            SetForegroundWindow(Handle.ToInt32());
            DisplayStorageItem();
            DisplayNoteItem();

        }
        private void DisplayStorageItem()
        {
            txtStorageName.Text = theStorageItem.ItemName;
            txtStorageDesc.Text = theStorageItem.Description;


        }
        private void DisplayNoteItem()
        {

            txtNoteFileName.Text = noteItem.s_NoteFileName;
            //txtTheNote.Text = noteItem.s_TheNote;

        }
        private void SetNoteItem()
        {
            noteItem.NoteFileName = txtNoteFileName.Text;
            //noteItem.TheNote = txtTheNote.Text;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtNoteFileName.Text))
            {
                File.Create(txtNoteFileName.Text).Close();
            }

            Process process = new Process();
            process.StartInfo.FileName = txtNoteFileName.Text;
            process.Start();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            if (!File.Exists(txtNoteFileName.Text))
            {
                File.Create(txtNoteFileName.Text).Close();
            }

        }


    }
}
