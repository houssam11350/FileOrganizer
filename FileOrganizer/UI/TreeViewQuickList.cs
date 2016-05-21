using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileOrganizer.BL;

namespace FileOrganizer.UI
{
    public partial class TreeViewQuickList : TreeView
    {
        public ContextMenuStrip TheContextMenuStrip;

        QuickListRow mQList;
        public QuickListRow QList
        {
            get { return mQList; }
            set { mQList = value; }
        }

        SystemIconsManager mSysIcons = SystemIconsManager.GetInstance();


        ListViewStorage mListViewStorage;
        public bool IsQuickListLoaded = false;
        public ListViewStorage ListViewStorage
        {
            get { return mListViewStorage; }
            set { mListViewStorage = value; }
        }

        public TreeViewQuickList()
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
            LocateSelectedNode();
        }

        void TreeViewQList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LocateSelectedNode();
        }


        public void LoadQuickList(String pOrderBy)
        {
            IsQuickListLoaded = true;
            this.Nodes.Clear();
            View_ListStorageItemDT view_ListStorageItem = new View_ListStorageItemDT();
            view_ListStorageItem.Query.AddWhereParameter(View_ListStorageItemDT.Parameters.ListID, mQList.ID);
            if(pOrderBy == null)
                view_ListStorageItem.Query.AddOrderBy(View_ListStorageItemDT.ColumnNames.Description, MyDir.ASC);
            else
                view_ListStorageItem.Query.AddOrderBy(pOrderBy, MyDir.ASC);

            //View_ListStorageItemDT.ColumnNames.StorageItemID

            view_ListStorageItem.Query.Load();
            foreach (View_ListStorageItemRow view_ListStorageItemLoop in view_ListStorageItem.Rows)
            {
                AddNewNodeForView_ListStorageItem(view_ListStorageItemLoop);
            }

            this.ExpandAll();
        }

        public void AddNewItem(long pStorageItemID)
        {
            View_ListStorageItemDT view_ListStorageItem = new View_ListStorageItemDT();
            view_ListStorageItem.Query.AddWhereParameter(View_ListStorageItemDT.Parameters.ListID, mQList.ID);
            view_ListStorageItem.Query.AddWhereParameter(View_ListStorageItemDT.Parameters.StorageItemID, pStorageItemID);
            //view_ListStorageItem.Where.StorageItemID.Value = pStorageItemID;
            //view_ListStorageItem.Query.AddOrderBy(View_ListStorageItem.ColumnNames.StorageItemID, WhereParameter.Dir.ASC);
            view_ListStorageItem.Query.Load();
            foreach (View_ListStorageItemRow view_ListStorageItemLoop in view_ListStorageItem.Rows)
            {
                AddNewNodeForView_ListStorageItem(view_ListStorageItemLoop);

            }
        }

        private TreeNodeQuickList AddNewNodeForView_ListStorageItem(View_ListStorageItemRow pView_ListStorageItem)
        {
            TreeNodeQuickList node = new TreeNodeQuickList();
            //node.Text = string.Format("{0}({1})", pView_ListStorageItem.ItemName, pView_ListStorageItem.Desciption);
            node.Text = string.Format("{0} ({1})", pView_ListStorageItem.Description, pView_ListStorageItem.ItemName);
            node.Tag = pView_ListStorageItem;
            node.View_ListStorageItem = pView_ListStorageItem;
            node.ImageIndex = node.SelectedImageIndex = mSysIcons.GetIconIndex(pView_ListStorageItem.GetPathIcon());
            this.Nodes.Add(node);
            //node.BackColor = Color.Yellow;
            if (!node.View_ListStorageItem.IsNull(View_ListStorageItemDT.ColumnNames.Color))
                node.BackColor = System.Drawing.Color.FromArgb(node.View_ListStorageItem.Color);

            return node;

        }


        /*
        public void EnsureStorageItemExitsts(StorageItem pStorageItem)
        {
            bool isFound = false;
            foreach (TreeNodeQuickList node in this.Nodes)
            {
                if (node.StorageItem.ID == pStorageItem.ID)
                {
                    isFound = true;
                    break;
                }


            }

            if (!isFound)
            {
                AddNewNodeForStorageItem(pStorageItem);
            }

        }

        public void HandleStorageItemAfterSave(StorageItem pStorageItem)
        {
            if (pStorageItem.IsInQuikList)

                EnsureStorageItemExitsts(pStorageItem);

            else
                RemoveStorageItem(pStorageItem);
        }

        public void PutInQuikList(StorageItem pStorageItem)
        {
            Color foundedNodeColor = Color.Yellow;
            foreach (TreeNodeQuickList node in this.Nodes)
            {
                node.BackColor = Color.White;
            }
            if (pStorageItem.IsInQuikList)
            {
                foreach (TreeNodeQuickList node in this.Nodes)
                {
                    node.BackColor = Color.White;
                    if (node.StorageItem.ID == pStorageItem.ID)
                    {
                        node.BackColor = foundedNodeColor;
                        break;

                    }
                }

            }
            else
            {
                pStorageItem.IsInQuikList = true;
                pStorageItem.Save();
                TreeNode node = AddNewNodeForStorageItem(pStorageItem);
                node.BackColor = foundedNodeColor;


            }

        }
*/

        public void HandleStorageItemAfterSave(StorageItemRow pStorageItem)
        {
            //cop it from above
            //todo

        }
        public void RemoveStorageItemID(long PID)
        {
            for (int index = 0; index <= this.Nodes.Count - 1; index++)
            {
                TreeNodeQuickList node = (TreeNodeQuickList)this.Nodes[index];
                if (node.View_ListStorageItem.StorageItemID == PID)
                {
                    this.Nodes.RemoveAt(index);
                    break;
                }

            }
        }
        private void LocateNode(TreeNodeQuickList node)
        {
            if (node == null)
                return;
            Color color = Color.Orange;
            View_ListStorageItemRow view_ListStorageItem = node.View_ListStorageItem;
            mListViewStorage.EnsureHasItem(view_ListStorageItem.StorageItemID, color, pAllowMultiple: false,pIsEnsueVisible: true);

        }
        public void LocateSelectedNode()
        {
            LocateNode((TreeNodeQuickList)SelectedNode);
        }

        public void RemoveSelectedNode()
        {
            if (this.SelectedNode == null)
                return;
            TreeNodeQuickList selectedTreeNodeQList = this.SelectedNode as TreeNodeQuickList;
            View_ListStorageItemRow view_ListStorageItem = selectedTreeNodeQList.View_ListStorageItem;
            ListStorageItemDT listStorageItem = new ListStorageItemDT();
            listStorageItem.Query.AddWhereParameter(ListStorageItemDT.Parameters.ListID, view_ListStorageItem.ListID);
            listStorageItem.Query.AddWhereParameter(ListStorageItemDT.Parameters.StorageItemID, view_ListStorageItem.StorageItemID);
            if (listStorageItem.Query.Load())
            {
                listStorageItem[0].DeleteListStorageItem();
                //listStorageItem.Save();
                this.Nodes.Remove(this.SelectedNode);

            }


        }

        public void SetSelectedNodeColor(Color pColor)
        {
            if (this.SelectedNode == null)
                return;
            TreeNodeQuickList selectedTreeNodeQList = this.SelectedNode as TreeNodeQuickList;
            selectedTreeNodeQList.BackColor = pColor;
            View_ListStorageItemRow view_ListStorageItem = selectedTreeNodeQList.View_ListStorageItem;
            ListStorageItemDT listStorageItem = new ListStorageItemDT();
            listStorageItem.Query.AddWhereParameter(ListStorageItemDT.Parameters.ListID, view_ListStorageItem.ListID);
            listStorageItem.Query.AddWhereParameter(ListStorageItemDT.Parameters.StorageItemID, view_ListStorageItem.StorageItemID);
            if (listStorageItem.Query.Load())
            {
                listStorageItem[0].Color = pColor.ToArgb();
                listStorageItem[0].Save();
            }
        }

        public Color GetSelectedNodeColor()
        {
            if (this.SelectedNode == null)
                return Color.Empty;
            return this.SelectedNode.BackColor;
        }

        public void Handle_DragDrop(object sender, DragEventArgs e)
        {
            if (mListViewStorage.SelectedItems.Count == 0)
                return;

            //TreeViewQuickList treeViewQList = toolStripMenuItem.Tag as TreeViewQuickList;
            //QuickList quickList = treeViewQList.QList;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                return;

            ListStorageItemDT listStorageItem = new ListStorageItemDT();
            foreach (ListViewStorageItem listViewStorageItem in mListViewStorage.SelectedItems)
            {
                listStorageItem.Query.ResetWhereParameters();
                listStorageItem.Query.AddWhereParameter(ListStorageItemDT.Parameters.ListID, this.mQList.ID);
                listStorageItem.Query.AddWhereParameter(ListStorageItemDT.Parameters.StorageItemID, listViewStorageItem.StorageItem.ID);
                if (listStorageItem.Query.Load())
                    Helper.ERRORMSG(String.Format("Entry '{0}' Already Exists In List '{1}' ! ", listViewStorageItem.StorageItem.ItemName, this.mQList.LName));
                else
                {
                    ListStorageItemRow listStorageItemRow = listStorageItem.NewListStorageItemRow();
                    listStorageItemRow.ListID = this.mQList.ID;
                    listStorageItemRow.StorageItemID = listViewStorageItem.StorageItem.ID;
                    listStorageItemRow.Save();
                    this.AddNewItem(listStorageItemRow.StorageItemID);


                }

            }

        }

        private void TreeViewQuickList_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TheContextMenuStrip.Enabled = true;
                TheContextMenuStrip.Tag = this;
                // Point where the mouse is clicked.
                Point p = new Point(e.X, e.Y);

                // Get the node that the user has clicked.
                TreeNode node = this.GetNodeAt(p);
                if (node != null)
                {
                    this.SelectedNode = node;
                    TheContextMenuStrip.Show(this, p);

                }
                else
                {
                    if (this.Nodes.Count > 0)
                    {

                        TreeNode lastNode = this.Nodes[this.Nodes.Count - 1];
                        this.SelectedNode = lastNode;
                        TheContextMenuStrip.Show(this, lastNode.Bounds.Location);
                    }
                    else
                    {
                        //TheContextMenuStrip.Enabled = false;
                        TheContextMenuStrip.Show(this, p);
                    }

                }
            }

        }


        public void LocateAllNodes()
        {
            foreach (TreeNodeQuickList node_loop in Nodes)
                LocateNode(node_loop);
        }

        public void UnLoad()
        {
            Nodes.Clear();
        }

        public void OpenSelectedNode()
        {
            if (SelectedNode == null)
                return;
            TreeNodeQuickList node = (TreeNodeQuickList)SelectedNode;
            View_ListStorageItemRow view_ListStorageItem = node.View_ListStorageItem;
            //mListViewStorage.EnsureHasItem(view_ListStorageItem.StorageItemID, color, false, true);
            StorageItemDT storageItem = new StorageItemDT();
            storageItem.LoadByPrimaryKey(view_ListStorageItem.StorageItemID);
            storageItem[0].Open();

        }

        public void SortByDescription()
        {
            LoadQuickList(View_ListStorageItemDT.ColumnNames.Description);
        }

        public void SortByFileName()
        {
            LoadQuickList(View_ListStorageItemDT.ColumnNames.ItemName);
        }

        public void SortByOrderOfAddition()
        {
            LoadQuickList(View_ListStorageItemDT.ColumnNames.StorageItemID);
        }
    }
}
