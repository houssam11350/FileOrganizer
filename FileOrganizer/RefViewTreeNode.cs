using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileOrganizer
{
    public class RefViewTreeNode : TreeNode
    {
        bool mIsFake = false;
        public bool IsFake
        {
            get { return mIsFake; }
            set { mIsFake = value; }
        }

        bool mIsLoaded = false;
        public bool IsLoaded
        {
            get { return mIsLoaded; }
            set { mIsLoaded = value; }
        }


        long mStorageItemID = -1;
        public long StorageItemID
        {
            get { return mStorageItemID; }
            set { mStorageItemID = value; }
        }

        public RefViewTreeNode(TreeNode parent)
            : base()
        {
            parent.Nodes.Add(this);
        }
        public RefViewTreeNode(string pText )
            : base(pText)
        {
            
        }
   
    
    }
}


