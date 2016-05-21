using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileOrganizer.BL;

namespace FileOrganizer
{
    public class TreeNodeRef : TreeNode
    {
        View_RefStorageItemRow mView_RefStorageItem;
        public View_RefStorageItemRow View_RefStorageItemRow
        {
            get { return mView_RefStorageItem; }
            set { mView_RefStorageItem = value; }
        }

     
        public TreeNodeRef()
            : base()
        {
        }

        public TreeNodeRef(string text)
            : base(text)
        {
        }


    }
}
