using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using FileOrganizer.BL;
using System.Collections;

namespace FileOrganizer.UI
{
    public partial class ListViewStorage : ListView
    {
        private SystemIconsManager mSysIcons = SystemIconsManager.GetInstance();
        Color mFixedItemBackColor = Color.SlateGray;

        public Color FixedItemBackColor
        {
            get { return mFixedItemBackColor; }
            //set { mFixedItemBackColor = value; }
        }

        Color mUnFixedItemBackColor = Color.White;
        public Color UnFixedItemBackColor
        {
            get { return mUnFixedItemBackColor; }
            //set { mUnFixedItemBackColor = value; }
        }


        //public ICollection<ListViewStorageItem> ListViewStorageItems
        //{
        //    get
        //    {
        //        return ((ICollection<ListViewStorageItem>)Items);
        //    }
        //}

        public List<ListViewStorageItem> SelectedListViewStorageItems
        {
            get
            {
                List<ListViewStorageItem> selectedListViewStorageItemsList = new List<ListViewStorageItem>();
                foreach (ListViewItem item in SelectedItems)
                    selectedListViewStorageItemsList.Add((ListViewStorageItem)item);

                return (selectedListViewStorageItemsList);
            }
        }



        public ListViewStorage()
        {
            MyInit();
            InitializeComponent();
        }

        private void MyInit()
        {
            SetStyle(ControlStyles.DoubleBuffer, true);
            this.DoubleBuffered = true;
            // Activate double buffering
            //SetStyle(ControlStyles.AllPaintingInWmPaint
            //| ControlStyles.DoubleBuffer
            //| ControlStyles.ResizeRedraw, true);

            //// Allows for catching the WM_ERASEBKGND message
            //SetStyle(ControlStyles.EnableNotifyMessage, true);
        }


        public void HighlightItem(ListViewStorageItem pTargetItem)
        {
            this.SuspendLayout();
            //BeginUpdate();
            //ListViewItem lvi1 = this.GetItemAt(this.ClientRectangle.X + 6, this.ClientRectangle.Y + 6);
            //ListViewItem lvi2 = this.GetItemAt(this.ClientRectangle.X + 6, this.ClientRectangle.Bottom - 10);


            //int startIdx = this.Items.IndexOf(lvi1);
            //int endIdx = this.Items.IndexOf(lvi2);
            //if (endIdx == -1)
            //    endIdx = this.Items.Count;

            int startIdx = GetPreviousItemIndex(pTargetItem, 3);
            int endIdx = GetNextItemIndex(pTargetItem, 3);

            for (int index = startIdx; index <= endIdx; index++)
            {
                if (Items[index] != pTargetItem)
                {
                    ((ListViewStorageItem)Items[index]).SetColorToDefault(); ;
                    Items[index].ForeColor = SystemColors.WindowText;
                }

            }

            pTargetItem.BackColor = SystemColors.Highlight;
            pTargetItem.ForeColor = SystemColors.Window;

            //EndUpdate();
            // this.ResumeLayout(false);
            //this.Bounds = new Rectangle(0, 0, 10, 10);
            //foreach (ListViewItem item in Items)
            //{
            //    item.BackColor = SystemColors.Window;
            //    item.ForeColor = SystemColors.WindowText;

            //}
            //pTargetItem.BackColor = SystemColors.Highlight;
            //pTargetItem.ForeColor = SystemColors.Window;
            this.ResumeLayout(false);
            this.PerformLayout();




        }

        private int GetPreviousItemIndex(ListViewItem pTargetItem, int pOffSet)
        {
            int index = pTargetItem.Index;
            int prevIndex = index - pOffSet;
            if (prevIndex < 0)
                prevIndex = 0;


            return prevIndex;
        }

        private int GetNextItemIndex(ListViewItem pTargetItem, int pOffSet)
        {
            int index = pTargetItem.Index;
            int nextIndex = index + pOffSet;
            if (nextIndex >= this.Items.Count)
                nextIndex = this.Items.Count - 1;
            return nextIndex;
        }


        public ListViewStorageItem GetListViewItemFromStorageItem(StorageItemRow sItem)
        {
            ListViewStorageItem item = new ListViewStorageItem(sItem);
            PutStorageItemInListViewItem(item, sItem);
            return item;

        }

        public void PutStorageItemInListViewItem(ListViewStorageItem pListViewItem, StorageItemRow pStorageItem)
        {
            pListViewItem.SubItems.Clear();
            pListViewItem.Text = pStorageItem.s_URL;

            //pListViewItem.SubItems.Add(pStorageItem.s_URL);
            pListViewItem.SubItems.Add(pStorageItem.s_FullPath);
            pListViewItem.SubItems.Add(pStorageItem.s_ItemName);
            pListViewItem.SubItems.Add(pStorageItem.s_Size);
            pListViewItem.SubItems.Add(pStorageItem.s_Priority);
            pListViewItem.SubItems.Add(pStorageItem.s_PagesCount);
            pListViewItem.SubItems.Add(pStorageItem.s_Description);
            //pListViewItem.SubItems.Add(pStorageItem.s_NoteItemID);
            pListViewItem.SubItems.Add(pStorageItem.NoteAsYesEmpty);
            pListViewItem.SubItems.Add(pStorageItem.s_Citation);
            pListViewItem.SubItems.Add(pStorageItem.s_ReferenceBib);
            pListViewItem.SubItems.Add(pStorageItem.s_ImportantParts);

            if (string.IsNullOrEmpty(pStorageItem.s_AdditionDate))
                pListViewItem.SubItems.Add(String.Empty);
            else
                pListViewItem.SubItems.Add(pStorageItem.AdditionDate.ToString("dd/MM/yyyy"));
            pListViewItem.Tag = pStorageItem;
            pListViewItem.StorageItem = pStorageItem;
            // item.ImageIndex = GetImageIndexForExtension(GetExtensionForStorageItem(sItem)); ;
            pListViewItem.ImageIndex = mSysIcons.GetIconIndex(pStorageItem.GetPathIconForStorageItem());
            if (pStorageItem.IsFixed)
                pListViewItem.BackColor = mFixedItemBackColor;
            else
                pListViewItem.BackColor = mUnFixedItemBackColor;

            pListViewItem.ToolTipText = pStorageItem.s_Description;




        }

        public ListViewStorageItem AddNewStorageItem(long pStorageItemID)
        {
            StorageItemDT storageItem = new StorageItemDT();
            storageItem.Query.AddWhereParameter(StorageItemDT.ColumnNames.ID , MyOperand.Equal , 
                StorageItemDT.Parameters.ID ,  pStorageItemID);
            if (storageItem.Query.Load())
            {
                ListViewStorageItem item = GetListViewItemFromStorageItem(storageItem[0]);
                this.Items.Add(item);
                return item;
            }
            return null;
        }
        public ListViewStorageItem AddNewStorageItem(StorageItemRow pStorageItem)
        {
            ListViewStorageItem item = GetListViewItemFromStorageItem(pStorageItem);
            this.Items.Add(item);
            return item;
        }

        public ListViewStorageItem AddNewStorageItem(StorageItemRow pStorageItem, Color pColor , bool pIsEnsueVisible)
        {
            ListViewStorageItem newListViewStorageItem = this.GetListViewItemFromStorageItem(pStorageItem);
            newListViewStorageItem.BackColor = pColor;
            this.Items.Add(newListViewStorageItem);
            if (pIsEnsueVisible)
                newListViewStorageItem.EnsureVisible();
            return newListViewStorageItem;
        }

        public ListViewStorageItem AddNewStorageItem(long pStorageItemID, Color pColor  ,bool pIsEnsueVisible)
        {
            StorageItemDT lStorageItem = new StorageItemDT();
            ListViewStorageItem newListViewStorageItem = null;
            if (lStorageItem.LoadByPrimaryKey(pStorageItemID))
            {
                newListViewStorageItem = this.GetListViewItemFromStorageItem(lStorageItem[0]);
                newListViewStorageItem.BackColor = pColor;
                this.Items.Add(newListViewStorageItem);
                if(pIsEnsueVisible)
                    newListViewStorageItem.EnsureVisible();
            }

            return newListViewStorageItem;
        }


        public ListViewStorageItem EnsureHasItem(long pStorageItemID, Color pColor, bool pAllowMultiple, bool pIsEnsueVisible)
        {
            bool isFound = false;
            ListViewStorageItem lTheItem = null;
            foreach (ListViewStorageItem item in this.Items)
            {
                if (!pAllowMultiple)
                {
                    if (item.BackColor == pColor)
                        item.SetColorToDefault();
                }

                if (pStorageItemID == item.StorageItem.ID)
                {
                    isFound = true;
                    lTheItem = item;
                    item.BackColor = pColor;
                    item.EnsureVisible();
                }
            }

            if (!isFound)
            {
                lTheItem = AddNewStorageItem(pStorageItemID, pColor , pIsEnsueVisible);
            }

            return lTheItem;
        }

        public ListViewStorageItem EnsureHasItem(long pStorageItemID)
        {
            bool isFound = false;
            ListViewStorageItem lTheItem = null;
            foreach (ListViewStorageItem item in this.Items)
            {


                if (pStorageItemID == item.StorageItem.ID)
                {
                    isFound = true;
                    lTheItem = item;
                    item.EnsureVisible();
                }
            }

            if (!isFound)
            {
                lTheItem = AddNewStorageItem(pStorageItemID);
            }

            return lTheItem;
        }


        public void SetBackColorForAllItemsWith(Color pColor)
        {
            foreach (ListViewStorageItem item in this.Items)
            {
                if (item.StorageItem.IsFixed)
                    item.BackColor = mFixedItemBackColor;
                else
                    item.BackColor = pColor;

            }
        }

        public void ClearItemsToDisplayNewSearchResult(bool pIsClearPrevResult)
        {
            if (pIsClearPrevResult)
            {
                this.Items.Clear();
                return;
            }
            for (int index = this.Items.Count - 1; index >= 0; index--)
            {
                ListViewStorageItem item = (ListViewStorageItem)this.Items[index];
                if (item.StorageItem.IsFixed)
                    item.SetColorToDefault();
                else
                    this.Items.RemoveAt(index);

            }
        }

        public void FixUnFixItemAt(int pIndex)
        {
            ListViewStorageItem listViewStorageItem = (ListViewStorageItem)Items[pIndex];
            listViewStorageItem.StorageItem.IsFixed = !listViewStorageItem.StorageItem.IsFixed;
            listViewStorageItem.StorageItem.Save();
            if (listViewStorageItem.StorageItem.IsFixed)
            {
                listViewStorageItem.BackColor = mFixedItemBackColor;
                //mFixedItemList.Add(listViewStorageItem);
            }
            else
            {
                listViewStorageItem.BackColor = mUnFixedItemBackColor;
                // mFixedItemList.Remove(listViewStorageItem);
            }
        }


        public string GetFixedIDsAsString()
        {
            List<string> lIDsList = new List<string>();
            foreach (ListViewStorageItem item in Items)
            {
                if (item.StorageItem.IsFixed)
                {
                    lIDsList.Add(item.StorageItem.s_ID);
                }
            }
            return string.Join(",", lIDsList.ToArray());
        }



        public int GetFixedItemsCount()
        {
            int lFixedItemsCount = 0;
            foreach (ListViewStorageItem item in Items)
            {
                if (item.StorageItem.IsFixed)
                {
                    lFixedItemsCount++;
                }

            }
            return lFixedItemsCount;
        }

        public List<ListViewStorageItem> GetSelectedListViewStorageItems()
        {
            List<ListViewStorageItem> listViewStorageItemList = new List<ListViewStorageItem>();
            foreach (ListViewStorageItem item in SelectedItems)
                listViewStorageItemList.Add(item);
            return listViewStorageItemList;
        }
    }
}
