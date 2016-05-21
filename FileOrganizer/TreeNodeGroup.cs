using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileOrganizer.BL;

namespace FileOrganizer
{
    public class TreeNodeGroup : TreeNode
    {
        View_GroupStorageItemRow mView_GroupStorageItem;
        public View_GroupStorageItemRow View_GroupStorageItem
        {
            get { return mView_GroupStorageItem; }
            set { mView_GroupStorageItem = value; }
        }

        bool mIsMainNode = false;
        public bool IsMainNode
        {
            get { return mIsMainNode; }
            set { mIsMainNode = value; }
        }


        public TreeNodeGroup()
            : base()
        {
        }

        public TreeNodeGroup(string text)
            : base(text)
        {
        }


    }
}
