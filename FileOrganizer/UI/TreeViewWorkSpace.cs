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
    public partial class TreeViewWorkSpace : TreeView
    {


        public TreeViewWorkSpace()
        {
            InitializeComponent();
        }


        public TreeNodeWorkSpace SelectedTreeNodeWorkSpace
        {
            get
            {
                if (this.SelectedNode == null)
                    return null;

                return (TreeNodeWorkSpace)SelectedNode;
            }
        }

        public WorkSpaceRow SelectedWorkSpace
        {
            get
            {
                if (SelectedTreeNodeWorkSpace == null)
                    return null;
                return SelectedTreeNodeWorkSpace.WorkSpace;

            }
        }

        public string GetSelectIDsAsString()
        {
            string lIDsAsString = string.Empty;

            List<string> iDsList = new List<string>();
            foreach (TreeNodeWorkSpace node in this.Nodes)
                if (node.Checked)
                    iDsList.Add(node.WorkSpace.s_ID);
            string iDListStr = string.Join(",", iDsList.ToArray());

            return lIDsAsString;
        }


        public string GetSelectIDsWithDummyAsString()
        {
            string lIDsAsString = string.Empty;

            List<string> iDsList = new List<string>();
            foreach (TreeNodeWorkSpace node in this.Nodes)
                if (node.Checked)
                    iDsList.Add(node.WorkSpace.s_ID);

            if (iDsList.Count == 0)
                iDsList.Add("-1");

            lIDsAsString = string.Join(",", iDsList.ToArray());
            return lIDsAsString;
        }


        public List<WorkSpaceRow> GetWorkSpaceListFromTree()
        {
            List<WorkSpaceRow> lWorkSpaceList = new List<WorkSpaceRow>();
            foreach (TreeNodeWorkSpace node in this.Nodes)
                lWorkSpaceList.Add(node.WorkSpace);


            return lWorkSpaceList;
        }


        public void AddNewNodeForWorkSpace(WorkSpaceRow pWorkSpace)
        {

            TreeNodeWorkSpace node = new TreeNodeWorkSpace();
            node.Text = pWorkSpace.s_WName;
            node.Tag = pWorkSpace;
            node.WorkSpace = pWorkSpace;
            node.Checked = pWorkSpace.IsActive;

            this.Nodes.Add(node);
        }
    }
}
