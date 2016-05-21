using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileOrganizer.BL;
using System.Drawing;

namespace FileOrganizer.UI
{
    public partial class TreeViewAllQuickList : TreeView
    {
        SystemIconsManager mSysIcons = SystemIconsManager.GetInstance();

        ListViewStorage mListViewStorage;
        public ListViewStorage ListViewStorage
        {
            get { return mListViewStorage; }
            set { mListViewStorage = value; }
        }

        StorageItemRow mStorageItem;
        public StorageItemRow StorageItem
        {
            get { return mStorageItem; }
            set { mStorageItem = value; }
        }

        Color mTargetColor = Color.Orange;
        public Color TargetColor
        {
            get { return mTargetColor; }
            set { mTargetColor = value; }
        }



        public TreeViewAllQuickList()
        {
            InitializeComponent();
            MyInit();
        }

        private void MyInit()
        {
            this.ImageList = mSysIcons.SmallIconsImageList;
            AfterSelect += new TreeViewEventHandler(TreeViewAllQuickList_AfterSelect);
            DoubleClick += new EventHandler(TreeViewAllQuickList_DoubleClick);
        }

        void TreeViewAllQuickList_DoubleClick(object sender, EventArgs e)
        {
            LocateList(this.SelectedNode as TreeNodeQuickList);
        }

        void TreeViewAllQuickList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LocateList(e.Node as TreeNodeQuickList);
        }


        public void LoadLists()
        {

            this.Nodes.Clear();
            View_ListStorageItemDT view_ListStorageItem = new View_ListStorageItemDT();
            view_ListStorageItem.Query.AddWhereParameter(View_ListStorageItemDT.Parameters.StorageItemID, mStorageItem.ID);
                //Where.StorageItemID.Value = mStorageItem.ID;
            view_ListStorageItem.Query.AddOrderBy(View_ListStorageItemDT.ColumnNames.StorageItemID, MyDir.ASC);
            view_ListStorageItem.Query.Load();
            foreach (View_ListStorageItemRow view_ListStorageItemLoop in view_ListStorageItem.Rows )
            {
                AddMainGroupNodeFor(view_ListStorageItemLoop);
                //AddNewNodeForView_GroupStorageItem(view_GroupStorageItemLoop);

            }

            this.ExpandAll();
        }

        private void AddMainGroupNodeFor(View_ListStorageItemRow pView_ListStorageItemLoop)
        {
            View_ListStorageItemDT view_ListStorageItem = new View_ListStorageItemDT();
            view_ListStorageItem.Query.AddWhereParameter(View_ListStorageItemDT.Parameters.ListID, pView_ListStorageItemLoop.ListID);
            //    Where.ListID.Value = pView_ListStorageItemLoop.ListID;
            //view_GroupStorageItem.Query.AddOrderBy(View_GroupStorageItem.ColumnNames.StorageItemID, WhereParameter.Dir.ASC);
            view_ListStorageItem.Query.Load();
            TreeNodeQuickList mainNode = new TreeNodeQuickList();
            mainNode.View_ListStorageItem = pView_ListStorageItemLoop;
            mainNode.Text = pView_ListStorageItemLoop.s_LName;
            mainNode.IsMainNode = true;


            foreach (View_ListStorageItemRow view_ListStorageItemLoop in view_ListStorageItem.Rows )
            {
                //AddMainGroupNodeFor(view_GroupStorageItemLoop);
                //AddNewNodeForView_GroupStorageItem(view_GroupStorageItemLoop);
                TreeNodeQuickList itemNode = GetNewItemNodeForView_ListStorageItem(view_ListStorageItemLoop);

                mainNode.Nodes.Add(itemNode);


            }

            mainNode.ExpandAll();
            this.Nodes.Add(mainNode);

            //AddNewNodeForView_GroupStorageItem(view_GroupStorageItemLoop);
        }

        //public void AddNewItem(int pStorageItemID)
        //{
        //    View_GroupStorageItem view_GroupStorageItem = new View_GroupStorageItem();
        //    view_GroupStorageItem.Where.ListID.Value = mQList.ID;
        //    view_GroupStorageItem.Where.StorageItemID.Value = pStorageItemID;
        //    //view_GroupStorageItem.Query.AddOrderBy(View_ListStorageItem.ColumnNames.StorageItemID, WhereParameter.Dir.ASC);
        //    view_GroupStorageItem.Query.Load();
        //    foreach (View_GroupStorageItem view_GroupStorageItemLoop in view_GroupStorageItem.AsList())
        //    {
        //        AddNewNodeForView_GroupStorageItem(view_GroupStorageItemLoop);

        //    }
        //}

        private TreeNodeQuickList GetNewItemNodeForView_ListStorageItem(View_ListStorageItemRow pView_ListStorageItem)
        {
            TreeNodeQuickList node = new TreeNodeQuickList();
            node.Text = string.Format("{0}({1})", pView_ListStorageItem.ItemName, pView_ListStorageItem.Description);
            node.Tag = pView_ListStorageItem;
            node.View_ListStorageItem = pView_ListStorageItem;
            node.ImageIndex = node.SelectedImageIndex = mSysIcons.GetIconIndex(pView_ListStorageItem.GetPathIcon());
            //this.Nodes.Add(node);
            if (pView_ListStorageItem.StorageItemID == mStorageItem.ID)
                node.BackColor = Color.Red;
            
            return node;

        }

        public void LocateList(TreeNodeQuickList pTreeNodeQuickList)
        {
            if (pTreeNodeQuickList == null)
                return;

            View_ListStorageItemRow view_ListStorageItem = pTreeNodeQuickList.View_ListStorageItem;

            if (pTreeNodeQuickList.IsMainNode)
            {
                LocateListByMainNode(pTreeNodeQuickList);
            }

            else

                mListViewStorage.EnsureHasItem(view_ListStorageItem.StorageItemID, mTargetColor, false , true);

        }

        private void LocateListByMainNode(TreeNodeQuickList pTreeNodeQuickList)
        {
            mListViewStorage.SetBackColorForAllItemsWith(Color.White);

            bool lIsSkip = false;

            foreach (TreeNodeQuickList node in pTreeNodeQuickList.Nodes)
            {
                bool isFound = false;
                View_ListStorageItemRow selectedItem = node.View_ListStorageItem;

                foreach (ListViewStorageItem item in mListViewStorage.Items)
                {
                    //item.BackColor = Color.White;
                    if (selectedItem.StorageItemID == item.StorageItem.ID)
                    {
                        isFound = true;
                        item.BackColor = mTargetColor;
                        if (!lIsSkip)
                        {
                            item.EnsureVisible();
                            lIsSkip = true;
                        }
                    }
                }

                if (!isFound)
                    mListViewStorage.AddNewStorageItem(selectedItem.StorageItemID, mTargetColor , true);

            }
        }

        public void RemoveSelectedNode()
        {
            if (this.SelectedNode == null)
                return;
            TreeNodeQuickList selectedTreeNodeQuickList = this.SelectedNode as TreeNodeQuickList;
            View_ListStorageItemRow view_ListStorageItem = selectedTreeNodeQuickList.View_ListStorageItem;
            ListStorageItemDT listStorageItem = new ListStorageItemDT();
            listStorageItem.Query.AddWhereParameter(ListStorageItemDT.Parameters.ListID , view_ListStorageItem.ListID);
            listStorageItem.Query.AddWhereParameter(ListStorageItemDT.Parameters.StorageItemID , view_ListStorageItem.StorageItemID);
            if (listStorageItem.Query.Load())
            {
                listStorageItem[0].DeleteListStorageItem();
                //listStorageItem.Save();
                this.Nodes.Remove(this.SelectedNode);

            }


        }


    }
}
