using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileOrganizer.BL
{
    public class StorageItemCopier
    {
        ICollection<ListViewStorageItem> mSourceList = new List<ListViewStorageItem>();
        public ICollection<ListViewStorageItem> SourceList
        {
            get { return mSourceList; }
            set { mSourceList = value; }
        }


        ICollection<ListViewStorageItem> mTargetList = new List<ListViewStorageItem>();
        public ICollection<ListViewStorageItem> TargetList
        {
            get { return mTargetList; }
            set { mTargetList = value; }
        }


        public StorageItemCopier()
        {
        }



    }
}
