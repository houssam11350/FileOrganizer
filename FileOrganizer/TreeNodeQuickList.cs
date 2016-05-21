using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileOrganizer.BL;

namespace FileOrganizer
{
    public class TreeNodeQuickList : TreeNode
    {
        View_ListStorageItemRow mView_ListStorageItem;
        public View_ListStorageItemRow View_ListStorageItem
        {
            get { return mView_ListStorageItem; }
            set { mView_ListStorageItem = value; }
        }

        bool mIsMainNode = false;
        public bool IsMainNode
        {
            get { return mIsMainNode; }
            set { mIsMainNode = value; }
        }



        public TreeNodeQuickList()
            : base()
        {
        }

        public TreeNodeQuickList(string text)
            : base(text)
        {
        }


    }
}
