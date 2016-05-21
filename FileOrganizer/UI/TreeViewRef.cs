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
    public partial class TreeViewRef : TreeView
    {
        public ContextMenuStrip TheContextMenuStrip;
        public ListViewStorage ListViewStorage;
        SystemIconsManager mSysIcons = SystemIconsManager.GetInstance();
        public bool IsLoaded = false;

        public TreeViewRef()
        {
            InitializeComponent();
            MyInit();
        }
        private void MyInit()
        {
            this.ImageList = mSysIcons.SmallIconsImageList;
            AfterSelect += new TreeViewEventHandler(TreeViewRef_AfterSelect);
            DoubleClick += new EventHandler(TreeViewRef_DoubleClick);
        }

        private void TreeViewRef_DoubleClick(object sender, EventArgs e)
        {
            TreeViewRef_AfterSelect(sender, null);
        }

        private void TreeViewRef_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.SelectedNode == null)
                return;
            View_RefStorageItemRow view_RefStorageItem = (View_RefStorageItemRow)this.SelectedNode.Tag;
            this.ListViewStorage.EnsureHasItem(view_RefStorageItem.RefStorageItemID, Color.LightCoral, false, true);

        }
        public TreeNodeRef AddNewNodeForView_ListStorageItem(View_RefStorageItemRow pView_RefStorageItemRow)
        {
            TreeNodeRef node = new TreeNodeRef();
            //node.Text = string.Format("{0}({1})", pView_ListStorageItem.ItemName, pView_ListStorageItem.Desciption);
            node.Text = string.Format("{0} ({1})", pView_RefStorageItemRow.s_RefDesciption, pView_RefStorageItemRow.s_ItemName);
            node.Tag = pView_RefStorageItemRow;
            node.View_RefStorageItemRow = pView_RefStorageItemRow;
            node.ImageIndex = node.SelectedImageIndex = mSysIcons.GetIconIndex(pView_RefStorageItemRow.GetPathIcon());
            this.Nodes.Add(node);
            //node.BackColor = Color.Yellow;
            //if (!node.View_RefStorageItemRow.IsNull(View_RefStorageItemDT.ColumnNames.Color))
            //    node.BackColor = System.Drawing.Color.FromArgb(node.View_ListStorageItem.Color);

            return node;

        }


        public void DisplayRefForMainStorage(long pStorageItemID)
        {
            IsLoaded = true;
            this.Nodes.Clear();
            View_RefStorageItemDT view_RefStorageItem = new View_RefStorageItemDT();
            view_RefStorageItem.Query.AddWhereParameter(View_RefStorageItemDT.Parameters.MainStorageItemID, pStorageItemID);
            view_RefStorageItem.Query.AddOrderBy(View_RefStorageItemDT.ColumnNames.RefDesciption, MyDir.ASC);
            view_RefStorageItem.Query.Load();
            foreach (View_RefStorageItemRow vRef in view_RefStorageItem.Rows)
            {
                AddNewNodeForView_ListStorageItem(vRef);
            }
            this.ExpandAll();
        }
        private void TreeView_MouseUp(object sender, MouseEventArgs e)
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


    }
}
