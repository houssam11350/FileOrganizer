using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileOrganizer.BL;
using MyGeneration.dOOdads;
using System.Drawing;

namespace FileOrganizer.UI
{
    public partial class TreeViewGroup : TreeView
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



        public TreeViewGroup()
        {
            InitializeComponent();
            MyInit();
        }

        private void MyInit()
        {
            this.ImageList = mSysIcons.SmallIconsImageList;
            AfterSelect += new TreeViewEventHandler(TreeViewQList_AfterSelect);
            DoubleClick += new EventHandler(TreeViewQList_DoubleClick);
        }

        void TreeViewQList_DoubleClick(object sender, EventArgs e)
        {
            LocateGroup(this.SelectedNode as TreeNodeGroup);
        }

        void TreeViewQList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LocateGroup(e.Node as TreeNodeGroup);
        }


        //public void LoadGroups()
        //{

        //    this.Nodes.Clear();
        //    View_GroupStorageItemDT view_GroupStorageItem = new View_GroupStorageItemDT();
        //    view_GroupStorageItem.Query.AddWhereParameter(View_GroupStorageItemDT.Parameters.StorageItemID , mStorageItem.ID);
        //    view_GroupStorageItem.Query.AddOrderBy(View_GroupStorageItemDT.ColumnNames.StorageItemID, MyDir.ASC);
        //    view_GroupStorageItem.Query.Load();
        //    foreach (View_GroupStorageItemRow view_GroupStorageItemLoop in view_GroupStorageItem.Rows)
        //    {
        //        AddMainGroupNodeFor(view_GroupStorageItemLoop);

        //    }

        //    this.ExpandAll();
        //}

        //private void AddMainGroupNodeFor(View_GroupStorageItemRow pView_GroupStorageItemLoop)
        //{
        //    View_GroupStorageItemDT view_GroupStorageItem = new View_GroupStorageItemDT();
        //    view_GroupStorageItem.Query.AddWhereParameter(View_GroupStorageItemDT.Parameters.ItemGroupID , pView_GroupStorageItemLoop.ItemGroupID);
        //    //view_GroupStorageItem.Query.AddOrderBy(View_GroupStorageItem.ColumnNames.StorageItemID, WhereParameter.Dir.ASC);
        //    view_GroupStorageItem.Query.Load();
        //    TreeNodeGroup mainNode = new TreeNodeGroup();
        //    mainNode.View_GroupStorageItem = pView_GroupStorageItemLoop;
        //    mainNode.Text = pView_GroupStorageItemLoop.s_GroupName;
        //    mainNode.IsMainNode = true;


        //    foreach (View_GroupStorageItemRow view_GroupStorageItemLoop in view_GroupStorageItem.Rows )
        //    {
        //        //AddMainGroupNodeFor(view_GroupStorageItemLoop);
        //        //AddNewNodeForView_GroupStorageItem(view_GroupStorageItemLoop);
        //        TreeNodeGroup itemNode = GetNewItemNodeForView_GroupStorageItem(view_GroupStorageItemLoop);

        //        mainNode.Nodes.Add(itemNode);


        //    }

        //    mainNode.ExpandAll();
        //    this.Nodes.Add(mainNode);

        //    //AddNewNodeForView_GroupStorageItem(view_GroupStorageItemLoop);
        //}

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

        private TreeNodeGroup GetNewItemNodeForView_GroupStorageItem(View_GroupStorageItemRow pView_GroupStorageItem)
        {
            TreeNodeGroup node = new TreeNodeGroup();
            node.Text = string.Format("{0}({1})", pView_GroupStorageItem.ItemName, pView_GroupStorageItem.Description);
            node.Tag = pView_GroupStorageItem;
            node.View_GroupStorageItem = pView_GroupStorageItem;
            node.ImageIndex = node.SelectedImageIndex = mSysIcons.GetIconIndex(pView_GroupStorageItem.GetPathIcon());
            //this.Nodes.Add(node);
            if (pView_GroupStorageItem.StorageItemID == mStorageItem.ID)
                node.BackColor = Color.Red;

            return node;

        }

        public void LocateGroup(TreeNodeGroup pTreeNodeGroup)
        {
            if (pTreeNodeGroup == null)
                return;

            View_GroupStorageItemRow view_GroupStorageItem = pTreeNodeGroup.View_GroupStorageItem;

            if (pTreeNodeGroup.IsMainNode)
            {
                LocateGroupByMainNode(pTreeNodeGroup);
            }

            else

                mListViewStorage.EnsureHasItem(view_GroupStorageItem.StorageItemID, mTargetColor, false, true);

        }

        private void LocateGroupByMainNode(TreeNodeGroup pTreeNodeGroup)
        {
            mListViewStorage.SetBackColorForAllItemsWith(Color.White);

            bool lIsSkip = false;

            foreach (TreeNodeGroup node in pTreeNodeGroup.Nodes)
            {
                bool isFound = false;
                View_GroupStorageItemRow selectedItem = node.View_GroupStorageItem;

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
                    mListViewStorage.AddNewStorageItem(selectedItem.StorageItemID, mTargetColor, true);

            }
        }

        public void RemoveSelectedNode()
        {
            if (this.SelectedNode == null)
                return;
            TreeNodeGroup selectedTreeNodeGroup = this.SelectedNode as TreeNodeGroup;
            View_GroupStorageItemRow view_GroupStorageItem = selectedTreeNodeGroup.View_GroupStorageItem;
            GroupStorageItemDT groupStorageItem = new GroupStorageItemDT();
            groupStorageItem.Query.AddWhereParameter(GroupStorageItemDT.Parameters.GroupID, view_GroupStorageItem.ItemGroupID);
            groupStorageItem.Query.AddWhereParameter(GroupStorageItemDT.Parameters.StorageItemID, view_GroupStorageItem.StorageItemID);
            if (groupStorageItem.Query.Load())
            {
                groupStorageItem[0].DeleteGroupStorageItem();
                this.Nodes.Remove(this.SelectedNode);

            }


        }


    }
}
