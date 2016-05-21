using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileOrganizer.UI
{
    public partial class CtrlTargetArea : UserControl
    {
        List<string> mDropedFilesList = new List<string>();

        List<EventHandler> mEventHandlerList = new List<EventHandler>();
        public event EventHandler LabelDoubleClick
        {
            add
            {
                lblTarget.DoubleClick += value;
                mEventHandlerList.Add(value);
            }

            remove
            {
                lblTarget.DoubleClick -= value;
                mEventHandlerList.Remove(value);
            }
        }

        public CtrlTargetArea()
        {
            InitializeComponent();
        }

        public void AddFile(string pFilePath)
        {
            mDropedFilesList.Add(pFilePath);
        }

        public void RefreshText()
        {
            lblTarget.Text = "Dragged Files = " + mDropedFilesList.Count.ToString();
        }

        public void DragAllFilesOK()
        {
            mDropedFilesList.Clear();
            RefreshText();

        }

        public void PausedPressedOnIndex(int pFileIndex)
        {
            List<String> tmpList = new List<string>();
            for (int index = pFileIndex; index < mDropedFilesList.Count; index++)
            {
                tmpList.Add(mDropedFilesList[index]);
            }
            mDropedFilesList = tmpList;
            RefreshText();

        }
        public void CancelAllPressedOnIndex(int pFileIndex)
        {
            mDropedFilesList.Clear();
            RefreshText();
        }

        public int GetFilesCount()
        {
            return mDropedFilesList.Count;
        }

        public String[] GetFilesArray()
        {
            return mDropedFilesList.ToArray();
        }

        private void mnuItemDoDrag_Click(object sender, EventArgs e)
        {

            foreach (EventHandler evt in mEventHandlerList)
            {
                evt(sender, e);
            }

        }

        private void mnuItemClear_Click(object sender, EventArgs e)
        {

            mDropedFilesList.Clear();
            RefreshText();

        }

        private void mnuItemPasteFileNames_Click(object sender, EventArgs e)
        {
            foreach (String sFileName in Clipboard.GetFileDropList())
                mDropedFilesList.Add(sFileName);

            RefreshText();
        }

    }
}
