using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileOrganizer.BL;
using FileOrganizer.UI;
using System.Drawing;

namespace FileOrganizer
{
    public class ListViewStorageItem : ListViewItem
    {
        private StorageItemRow mStorageItem;
        public StorageItemRow StorageItem
        {
            get { return mStorageItem; }
            set { mStorageItem = value; }
        }

        ListViewStorage ParentListView
        {
            get
            {
                return (ListViewStorage)this.ListView;
            }
        }
        //private bool mIsFixed = false;
        //public bool IsFixed
        //{
        //    get { return mIsFixed; }
        //    set { mIsFixed = value; }
        //}


        public ListViewStorageItem()
            : base()
        {

        }

        public ListViewStorageItem(StorageItemRow pStorageItem)
            : base()
        {

            mStorageItem = pStorageItem;
            pStorageItem.ListViewStorageItem = this;
        }

        public void DisplayStorageItem()
        {
            ParentListView.PutStorageItemInListViewItem(this, mStorageItem);
        }

        //public void SetColorToDefault()
        //{
        //    if (mStorageItem.IsFixed)
        //        this.BackColor = ParentListView.FixedItemBackColor;
        //    else
        //        this.BackColor = ParentListView.UnFixedItemBackColor;
        //}



        //public void SetColorToDefaultWithForGround()
        //{
        //    SetColorToDefault();
        //    this.ForeColor = SystemColors.WindowText;
        //}
    }
}
