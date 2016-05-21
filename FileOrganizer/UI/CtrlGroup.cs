using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileOrganizer.UI
{
    public partial class CtrlGroup : UserControl
    {
        public TreeViewGroup TheTreeViewGroup
        {
            get
            {
                return mTreeViewGroup;
            }
        }


        public CtrlGroup()
        {
            InitializeComponent();
        }

        private void mTreeViewGroup_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mnuStripGroup.Enabled = true;
                // Point where the mouse is clicked.
                Point p = new Point(e.X, e.Y);

                // Get the node that the user has clicked.
                TreeNodeGroup node = (TreeNodeGroup)mTreeViewGroup.GetNodeAt(p);
                if (node != null)
                {
                    mTreeViewGroup.SelectedNode = node;
                    mnuStripGroup.Show(mTreeViewGroup, p);
                    mnuItemRemoveGroup.Enabled = ! node.IsMainNode;

                }
                else
                {
                    if (mTreeViewGroup.Nodes.Count > 0)
                    {

                        TreeNodeGroup lastNode = (TreeNodeGroup)mTreeViewGroup.Nodes[mTreeViewGroup.Nodes.Count - 1];
                        mTreeViewGroup.SelectedNode = lastNode;
                        mnuStripGroup.Show(mTreeViewGroup, lastNode.Bounds.Location);
                        mnuItemRemoveGroup.Enabled = !node.IsMainNode;
                    }
                    else
                    {
                        mnuStripGroup.Enabled = false;
                    }

                }
            }
        }

        private void mnuItemLocateGroup_Click(object sender, EventArgs e)
        {
            mTreeViewGroup.LocateGroup(mTreeViewGroup.SelectedNode as TreeNodeGroup);
        }

        private void mnuItemRemoveGroup_Click(object sender, EventArgs e)
        {
            mTreeViewGroup.RemoveSelectedNode();
        }
    }
}
