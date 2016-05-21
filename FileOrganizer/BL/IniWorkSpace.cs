using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileOrganizer.BL
{
    public class IniWorkSpace
    {
        TreeView mTreeView;
        string mIniFilePath;
        IniFile mIniFile;
        const string SELECTED_NODE_INDEX = "selected_node_index";

        public IniWorkSpace(TreeView pTreeView)
        {
            mTreeView = pTreeView;
            string exePath = Path.GetFullPath(Application.ExecutablePath);
            FileInfo fInfo = new FileInfo(exePath);
            mIniFilePath = fInfo.Directory.FullName + Path.DirectorySeparatorChar + "StorageItem.ini";
            mIniFile = new IniFile(mIniFilePath);

        }

        public void Save()
        {
            mIniFile = new IniFile(mIniFilePath);
            int selectedNodeIndex = -1;
            if (mTreeView.Nodes.Count != 0)
                if (mTreeView.SelectedNode != null)
                    selectedNodeIndex = mTreeView.SelectedNode.Index;

            mIniFile.IniWriteValue(string.Empty, SELECTED_NODE_INDEX, selectedNodeIndex.ToString());
        }

        public void Load()
        {
            mIniFile = new IniFile(mIniFilePath);
            int selectedNodeIndex = int.Parse(mIniFile.IniReadValue(string.Empty, SELECTED_NODE_INDEX));
            if (selectedNodeIndex == -1)
                return;
            if (mTreeView.Nodes.Count != 0)
                if (selectedNodeIndex <= mTreeView.Nodes.Count - 1)
                {
                    mTreeView.SelectedNode = mTreeView.Nodes[selectedNodeIndex];
                }

        }
    }

}
