using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FileOrganizer.BL;
using System.IO;
using System.Diagnostics;
using System.Collections;
using Microsoft.Win32;
using System.Threading;
using iTextSharp.text.pdf;
using System.Runtime.InteropServices;
using FarsiLibrary.Win;
using System.Net;

#if BOOK
            //this.Text = "Books";
#else
// this.Text = "FileOrganizer";
#endif

namespace FileOrganizer.UI
{
    public partial class FrmMain : Form
    {
        //MyFileOrganizer mFileOrganizer;
        public static string CurrentVersion = "1.0.0.0";
        static byte Window_Counter = 0;
        bool isInFormLoad = false;

        SystemIconsManager sysIcons = SystemIconsManager.GetInstance();
        //List<WorkSpace> mWorkSpaceList;
        WorkSpaceDT mWorkSpaceList;
        QuickListDT mQuickList;

        List<TreeViewQuickList> mTreeViewQuickList_List = new List<TreeViewQuickList>();
        //List<ItemGroup> mItemGroupList = new List<ItemGroup>();
        //ItemGroupDT mItemGroupList = new ItemGroupDT();
        //List<String> mFilterWordList = new List<string>();
        int mFilteredItemsCount = 0;

        long mSelectedStorageItemID = -1;

        StorageItemRow mMainStorageItem = null;
        public StorageItemRow MainStorageItem
        {
            get { return mMainStorageItem; }
            //set { mMainStorageItem = value; }
        }


        StorageItemCopier mStorageItemCopier = new StorageItemCopier();

        const string ORDER_OF_ADDITION = "Order of Addition";
        const string WORK_SPACE_ID = "Work Space";
        const string NAME = "Name";
        const string PRIORITY = "Priority";
        const string PAGES_COUNT = "Pages Count";
        const string DESCRIPTION = "Description";
        const string CITATION = "Citation";
        const string REFERENCE_BIB = "Reference Bib";
        const string IMPORTANT_PARTS = "Important Parts";

        bool mIsOrderByInFilling = false;
        bool mIsPriorityOperandInFilling = false;


        const string GREATER_THAN = ">=";
        const string EQUAL = "=";
        const string LESS_THAN = "=<";

        List<StorageItemRow> reportStorageItemList = new List<StorageItemRow>();

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern void ExitProcess(int uExitCode);

        [DllImportAttribute("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet =
                                   CharSet.Ansi, SetLastError = true)]
        private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);


        //private static FrmMain mInstance = null;
        public bool IsMainWindow = true;

        AllowedStringHandler mAllowedStringHandler = AllowedStringHandler.GetInstance();
        StorageItemDT similarStorageItem = new StorageItemDT();
        public FrmMain()
        {

            isInFormLoad = true;
            InitializeComponent();
#if BOOK
            this.Text = "Books";
#else
            this.Text = "FileOrganizer";
#endif

            //stStorageItem.Items.Add(dlgOpenFile.FileName, _iconListManager.AddFileIcon(dlgOpenFile.FileName));

            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            if (Window_Counter == 0)
                this.Text += " [Main]";
            else
                this.Text += "[" + Window_Counter + "]";
            Window_Counter++;

            //mFileOrganizer = new MyFileOrganizer();
        }

        //public static FrmMain GetInstance()
        //{
        //    if (mInstance == null)
        //        mInstance = new FrmMain();

        //    return mInstance;
        //}
        void DisplayWorkSpaces()
        {
            //mFileOrganizer.LoadAllWorkSpaces();
            mWorkSpaceList = new WorkSpaceDT();
            mWorkSpaceList.LoadAll();
            tvWorkSpace.Nodes.Clear();
            //InsertDummyAllWorkSpace(mWorkSpaceList);
            foreach (WorkSpaceRow workSpace in mWorkSpaceList.Rows)
            {
                TreeNodeWorkSpace node = new TreeNodeWorkSpace();
                node.Text = workSpace.s_WName;
                node.Tag = workSpace;
                node.WorkSpace = workSpace;
                node.Checked = workSpace.IsActive;
                node.PutColorAsChecked();
                tvWorkSpace.Nodes.Add(node);
            }

        }


        private void FrmMain_Load(object sender, EventArgs e)
        {
            notifyIcon.Icon = this.Icon;
            FillCmbSortType();
            FillCmbTopN();
            FillPriorityOperandCMB();
            FillOrderByCMB();
            lstStorageItem.SmallImageList = sysIcons.SmallIconsImageList;
            lstStorageItem.LargeImageList = sysIcons.LargeIconsImageList;
            tvSiteGroup.ImageList = sysIcons.SmallIconsImageList;
            tvSimilarItems.ImageList = sysIcons.SmallIconsImageList;
            tvOneSiteGroup.ImageList = sysIcons.SmallIconsImageList;
            tvRefView.ImageList = sysIcons.SmallIconsImageList;

            FillTVRefViewWithTowNodes();

            DisplayWorkSpaces();

            IniWorkSpace iniWorkSpace = new IniWorkSpace(tvWorkSpace);
            iniWorkSpace.Load();

            IniStorageItem iniStorageItem = new IniStorageItem(this);
            iniStorageItem.Load();

            this.ActiveControl = lstStorageItem;
            lstStorageItem.Focus();
            if (lstStorageItem.SelectedItems.Count > 0)
                lstStorageItem.SelectedItems[0].EnsureVisible();

            //DOSearch();

            LoadQLists();

            //LoadItemGroupList();

            //ctrlGroup.TheTreeViewGroup.ListViewStorage = lstStorageItem;
            treeViewAllQuickList.ListViewStorage = lstStorageItem;

            tvRef.ListViewStorage = lstStorageItem;
            tvRef.TheContextMenuStrip = mnuStripRef;

            isInFormLoad = false;

        }

        private void FillCmbTopN()
        {
            cmbTopN.Items.Clear();
            cmbTopN.Items.Add(TopNOptions.TWENTY_FIVE);
            cmbTopN.Items.Add(TopNOptions.FIFTY);
            cmbTopN.Items.Add(TopNOptions.SEVENTY_FIVE);
            cmbTopN.Items.Add(TopNOptions.ONE_HUNDRED);
            cmbTopN.Items.Add(TopNOptions.ALL);
        }

        //private void LoadItemGroupList()
        //{
        //    //mItemGroupList.Clear();
        //    //ItemGroupDT itemGroup = new ItemGroupDT();
        //    //itemGroup.LoadAll();
        //    //foreach (ItemGroupRow itemGroupLoop in itemGroup.Rows)
        //    //{
        //    //    mItemGroupList.Rows.Add(itemGroupLoop);
        //    //}

        //    mItemGroupList.LoadAll();
        //}

        private void LoadQLists()
        {
            mQuickList = new QuickListDT();
            mQuickList.LoadAll();
            foreach (QuickListRow quickListLoop in mQuickList.Rows)
            {
                AddQuickList(quickListLoop);
            }
        }

        private void AddQuickList(QuickListRow pQuickList)
        {
            FATabStripItem tabPage = new FATabStripItem(pQuickList.s_LName, null);
            //CtrlQuickList ctrlQuickList = new CtrlQuickList();
            //TreeViewQList treeViewQList = new TreeViewQList();
            TreeViewQuickList treeViewQuickList = new TreeViewQuickList();
            treeViewQuickList.TheContextMenuStrip = mnuStripQuickList;
            treeViewQuickList.QList = pQuickList;
            treeViewQuickList.ListViewStorage = lstStorageItem;
            //ctrlQuickList.TheTreeViewQuickList.LoadQuickList();
            mTreeViewQuickList_List.Add(treeViewQuickList);

            tabPage.Controls.Add(treeViewQuickList);
            tabPage.Tag = treeViewQuickList;
            tabControl.Items.Add(tabPage);
            if (pQuickList.IsInToolBar)
            {
                ToolStripButton toolStripButton = new ToolStripButton(pQuickList.s_LName);
                toolStripButton.Tag = tabPage;
                pQuickList.ToolStripButton = toolStripButton;
                //this.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
                //this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
                //this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
                //this.tsbPrint.Name = "tsbPrint";
                //this.tsbPrint.Size = new System.Drawing.Size(23, 22);
                //this.tsbPrint.Text = "Print";
                //this.tsbPrint.Click += new System.EventHandler(this.mnuFileExit_Click);

                toolStripButton.Click += new EventHandler(toolStripButton_For_QList_Click);
                toolStripMain.Items.Add(toolStripButton);
            }

        }

        void toolStripButton_For_QList_Click(object sender, EventArgs e)
        {
            ToolStripButton toolStripButton = sender as ToolStripButton;
            FATabStripItem tabPage = toolStripButton.Tag as FATabStripItem;
            tabControl.SelectedItem = tabPage;

        }



        private TreeNode GetTreeNodeForGuikListFromStorageItem(StorageItemRow pStorageItem)
        {
            TreeNode node = new TreeNode();
            node.Text = string.Format("{0}({1})", pStorageItem.ItemName, pStorageItem.Description);
            node.Tag = pStorageItem;
            node.ImageIndex = node.SelectedImageIndex = sysIcons.GetIconIndex(pStorageItem.GetPathIconForStorageItem());

            return node;
        }

        private void FillTVRefViewWithTowNodes()
        {
            tvRefView.Nodes.Clear();
            tvRefView.Nodes.Add(GetNewRefNode());
            tvRefView.Nodes.Add(GetNewFatherItemNode());
        }

        private TreeNode GetNewRefNode()
        {
            TreeNode refNode = new TreeNode();
            refNode.Text = string.Format("References ({0})", refNode.Nodes.Count);
            refNode.ImageIndex = refNode.SelectedImageIndex = sysIcons.GetIconIndex(Application.ExecutablePath);

            return refNode;

        }

        private TreeNode GetNewFatherItemNode()
        {
            TreeNode fatherRefNode = new TreeNode();
            fatherRefNode.Text = string.Format("Reference In ({0})", fatherRefNode.Nodes.Count);
            fatherRefNode.ImageIndex = fatherRefNode.SelectedImageIndex = sysIcons.GetIconIndex(Application.ExecutablePath);

            return fatherRefNode;

        }

        private void FillPriorityOperandCMB()
        {

            mIsPriorityOperandInFilling = true;

            cmbPriorityOperand.Items.Clear();
            cmbPriorityOperand.Items.Add(GREATER_THAN);
            cmbPriorityOperand.Items.Add(EQUAL);
            cmbPriorityOperand.Items.Add(LESS_THAN);
            if (cmbPriorityOperand.Items.Count > 0)
                cmbPriorityOperand.SelectedIndex = 0;

            mIsPriorityOperandInFilling = false;

        }
        private void FillCmbSortType()
        {
            cmbSortType.Items.Add(SortTypeOptions.ASC);
            cmbSortType.Items.Add(SortTypeOptions.DESC);
            if (cmbSortType.Items.Count > 0)
                cmbSortType.SelectedIndex = 0;

        }
        private void FillOrderByCMB()
        {
            mIsOrderByInFilling = true;
            cmbOrder.Items.Clear();
            cmbOrder.Items.Add(ORDER_OF_ADDITION);
            cmbOrder.Items.Add(WORK_SPACE_ID);
            cmbOrder.Items.Add(NAME);
            cmbOrder.Items.Add(PRIORITY);
            cmbOrder.Items.Add(PAGES_COUNT);
            cmbOrder.Items.Add(DESCRIPTION);
            cmbOrder.Items.Add(CITATION);
            cmbOrder.Items.Add(REFERENCE_BIB);
            cmbOrder.Items.Add(IMPORTANT_PARTS);
            if (cmbOrder.Items.Count > 0)
                cmbOrder.SelectedIndex = 0;

            mIsOrderByInFilling = false;

        }

        private void newWorkSpaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewWorkSpace frm = new FrmNewWorkSpace();
            frm.WorkSpace = mWorkSpaceList.NewWorkSpaceRow();
            //frm.WorkSpace.AddNew();
            frm.ShowInTaskbar = false;
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;

            frm.ShowDialog();
            if (frm.IsOK)
            {
                //mWorkSpaceList.Rows.Add(frm.WorkSpace);
                tvWorkSpace.AddNewNodeForWorkSpace(frm.WorkSpace);


            }

        }


        private void lstStorageItem_DoubleClick(object sender, EventArgs e)
        {
            if (lstStorageItem.SelectedItems.Count == 0)
                return;
            StorageItemRow storageItem = (StorageItemRow)lstStorageItem.SelectedItems[0].Tag;
            ShowStorageItem(storageItem);


        }
        private WorkSpaceRow GetWorkSpaceByID(long pID)
        {
            foreach (WorkSpaceRow row in mWorkSpaceList.Rows)
                if (row.ID == pID)
                    return row;

            return null;
        }
        private void ShowStorageItem(StorageItemRow pStorageItemRow)
        {
            FrmStorageItem frmStorageItem = new FrmStorageItem();
            frmStorageItem.frmMain = this;
            //mWorkSpaceList
            if (String.IsNullOrEmpty(pStorageItemRow.s_WorkSpaceID))
            {
                WorkSpaceRow workSpace = (WorkSpaceRow)tvWorkSpace.SelectedNode.Tag;
                frmStorageItem.TheWorkSpace = workSpace;
            }
            else
            {
                frmStorageItem.TheWorkSpace = GetWorkSpaceByID(pStorageItemRow.WorkSpaceID);
            }

            frmStorageItem.StorageItem = pStorageItemRow;
            frmStorageItem.WorkSpaceList = tvWorkSpace.GetWorkSpaceListFromTree();
            frmStorageItem.ShowDialog();
            //DisplayStorageItems();
            lstStorageItem.PutStorageItemInListViewItem((ListViewStorageItem)lstStorageItem.SelectedItems[0], frmStorageItem.StorageItem);

            HandleAfterSave(frmStorageItem.StorageItem);
        }
        private void HandleAfterSave(StorageItemRow pStorageItem)
        {
            DisplayDesc(pStorageItem);
            foreach (TreeViewQuickList treeViewQList in mTreeViewQuickList_List)
                treeViewQList.HandleStorageItemAfterSave(pStorageItem);

        }

        private void DisplayDesc(StorageItemRow pStorageItem)
        {
            txtMainStorageItemDesc.Text = pStorageItem.s_Description;
            //item.BackColor = Color.Red;

            txtMainStorageItemDesc.Text += "\r\n----------\r\n";
            txtMainStorageItemDesc.Text += string.Format("{0} pages", pStorageItem.s_PagesCount);

            txtMainStorageItemDesc2.Text = txtMainStorageItemDesc.Text;
            DisplayReferenceView(pStorageItem);
            DisplayOneSiteGroup(pStorageItem);
            DisplaySimilarItesm(pStorageItem);
            // DisplayGroupStorageItem(pStorageItem);
            DisplayListStorageItem(pStorageItem);


        }

        private void DisplayListStorageItem(StorageItemRow pStorageItem)
        {
            treeViewAllQuickList.Nodes.Clear();
            if (!Options.GetInstance().IsQuickListLoad)
                return;
            treeViewAllQuickList.StorageItem = pStorageItem;
            treeViewAllQuickList.LoadLists();
        }

        //private void DisplayGroupStorageItem(StorageItemRow pStorageItem)
        //{
        //    ctrlGroup.TheTreeViewGroup.StorageItem = pStorageItem;
        //    ctrlGroup.TheTreeViewGroup.LoadGroups();

        //}
        private void DisplaySimilarItesm(StorageItemRow pStorageItem)
        {
            tvSimilarItems.Nodes.Clear();
            if (!Options.GetInstance().IsSimilarItemsLoad)
                return;

            if (string.IsNullOrEmpty(pStorageItem.s_Description))
                return;

            StorageItemDT storageItem = new StorageItemDT();
            //List<StorageItem> similarItemsList = 
            storageItem.GetSimilarStorageItems(pStorageItem.Description);
            foreach (StorageItemRow storageItemLoop in storageItem.Rows)
            {
                TreeNode itemNode = new TreeNode(storageItemLoop.ItemName + " (" + storageItemLoop.s_Description + ")");
                //itemNode.ImageIndex = 2;
                //itemNode.SelectedImageIndex = 2;
                itemNode.Tag = storageItemLoop;
                itemNode.ImageIndex = itemNode.SelectedImageIndex = sysIcons.GetIconIndex(storageItemLoop.GetPathIconForStorageItem());
                tvSimilarItems.Nodes.Add(itemNode);

                if (pStorageItem.ID == storageItemLoop.ID)
                {
                    itemNode.EnsureVisible();
                    itemNode.BackColor = Color.Red;

                }

            }
            tvSimilarItems.ExpandAll();

        }
        private void DisplayOneSiteGroup(StorageItemRow pStorageItem)
        {

            tvOneSiteGroup.Nodes.Clear();


            if (Options.GetInstance().IsSameSiteLoadingEnabled == false)
            {
                TreeNode hostNode = new TreeNode(pStorageItem.GetHost());
                hostNode.ImageIndex = hostNode.SelectedImageIndex = sysIcons.GetIconIndex(Application.ExecutablePath);
                tvOneSiteGroup.Nodes.Add(hostNode);

                return;
            }

            string lStorageItemHost = pStorageItem.GetHost().ToUpper();
            Dictionary<string, List<StorageItemRow>> dicStorageItem = new Dictionary<string, List<StorageItemRow>>();
            List<string> iDsList = new List<string>();

            foreach (ListViewItem item in lstStorageItem.Items)
            {

                StorageItemRow storageItem = (StorageItemRow)item.Tag;
                string host = storageItem.GetHost();

                if (lStorageItemHost.Equals(host.ToUpper()))
                {
                    iDsList.Add(storageItem.s_ID);
                    AddStorageItemToDic(storageItem, dicStorageItem);
                }

            }

            List<KeyValuePair<string, List<StorageItemRow>>> myList = new List<KeyValuePair<string, List<StorageItemRow>>>(dicStorageItem);
            DisplayGroupList(tvOneSiteGroup, myList, pStorageItem, "(Visible On List)");

            string iDListStr = string.Join(",", iDsList.ToArray());
            FetchStorageItemsNotInLstStorage(lStorageItemHost, iDListStr);

        }

        private void FetchStorageItemsNotInLstStorage(string pStorageItemHost, string pIDListStr)
        {

            Dictionary<string, List<StorageItemRow>> dicStorageItem = new Dictionary<string, List<StorageItemRow>>();
            StorageItemDT storageItem = new StorageItemDT();
            PutURLIDParameter(storageItem, pStorageItemHost, pIDListStr);
            storageItem.Query.Load();
            foreach (StorageItemRow storageItemLoop in storageItem.Rows)
            {
                if (pStorageItemHost.ToUpper().Equals(storageItemLoop.GetHost().ToUpper()))
                {

                    AddStorageItemToDic(storageItemLoop, dicStorageItem);
                }

            }

            List<KeyValuePair<string, List<StorageItemRow>>> myList = new List<KeyValuePair<string, List<StorageItemRow>>>(dicStorageItem);
            DisplayGroupList(tvOneSiteGroup, myList, null, "(Not Visible In List)");
            tvOneSiteGroup.ExpandAll();

        }

        private void PutURLIDParameter(StorageItemDT pStorageItem, string pStorageItemHost, string pIDListStr)
        {
            pStorageItem.Query.OpenParenthesis();

            MyParameter descParameter1 = pStorageItem.Query.AddWhereParameter(StorageItemDT.Parameters.URL);
            descParameter1.Operator = MyOperand.Like;
            descParameter1.Value = "%" + pStorageItemHost.ToUpper() + "%";
            //descParameter1.Conjuction = WhereParameter.Conj.Or;

            MyParameter descParameter2 = pStorageItem.Query.AddWhereParameter(StorageItemDT.Parameters.URL);
            descParameter2.Operator = MyOperand.Like;
            descParameter2.Value = "%" + pStorageItemHost.ToLower() + "%";
            descParameter2.Conjuction = MyConj.Or;
            pStorageItem.Query.CloseParenthesis();
            //pStorageItem.Query.AddConjunction(WhereParameter.Conj.And);
            MyParameter id_param = pStorageItem.Query.AddWhereParameter(StorageItemDT.Parameters.ID);
            id_param.Operator = MyOperand.NotIn;
            id_param.Value = pIDListStr;
        }

        private void DisplayReferenceView(StorageItemRow pStorageItem)
        {
            TreeNode refNode = tvRefView.Nodes[0];
            refNode.Nodes.Clear();
            DisplayReferenceView_Reference(refNode, pStorageItem.ID);
            refNode.Expand();

            TreeNode fatherRefNode = tvRefView.Nodes[1];
            fatherRefNode.Nodes.Clear();
            DisplayReferenceView_FatherItems(fatherRefNode, pStorageItem.ID);
            fatherRefNode.Expand();
            //tvRefView.ExpandAll();

        }


        private void DisplayReferenceView_Reference(TreeNode pRefNode, long pStorageItemID)
        {
            View_RefStorageItemDT view_RefStorageItem = new View_RefStorageItemDT();
            view_RefStorageItem.Query.AddWhereParameter(View_RefStorageItemDT.Parameters.MainStorageItemID, pStorageItemID);
            //    Where.MainStorageItemID.Value = ;
            view_RefStorageItem.Query.Load();
            foreach (View_RefStorageItemRow view_RefStorageItem_Loop in view_RefStorageItem.Rows)
            {
                RefViewTreeNode view_RefStorageItemNode = new RefViewTreeNode(view_RefStorageItem_Loop.s_ItemName + "(" + view_RefStorageItem_Loop.s_RefDesciption + ")");
                view_RefStorageItemNode.Tag = view_RefStorageItem_Loop;
                view_RefStorageItemNode.StorageItemID = view_RefStorageItem_Loop.RefStorageItemID;
                view_RefStorageItemNode.Nodes.Add(new RefViewTreeNode(string.Empty) { IsFake = true });

                view_RefStorageItemNode.ImageIndex = view_RefStorageItemNode.SelectedImageIndex = sysIcons.GetIconIndex(GetPathIconForStorageItem(view_RefStorageItem_Loop.s_FullPath, view_RefStorageItem_Loop.s_ItemName));

                pRefNode.Nodes.Add(view_RefStorageItemNode);

            }
            pRefNode.Text = string.Format("References ({0})", pRefNode.Nodes.Count);


        }
        private void DisplayReferenceView_FatherItems(TreeNode pFatherRefNode, long pStorageItemID)
        {
            View_RefStorageItemDT view_RefStorageItem = new View_RefStorageItemDT();
            view_RefStorageItem.Query.AddWhereParameter(View_RefStorageItemDT.Parameters.RefStorageItemID, pStorageItemID);
            //    Where.RefStorageItemID.Value = ;
            view_RefStorageItem.Query.Load();
            foreach (View_RefStorageItemRow view_RefStorageItem_Loop in view_RefStorageItem.Rows)
            {
                RefViewTreeNode view_FatherStorageItemNode = new RefViewTreeNode(view_RefStorageItem_Loop.s_MainItemName + "(" + view_RefStorageItem_Loop.MainItemDesciption + ")");
                view_FatherStorageItemNode.Tag = view_RefStorageItem_Loop;
                view_FatherStorageItemNode.StorageItemID = view_RefStorageItem_Loop.MainStorageItemID;
                view_FatherStorageItemNode.Nodes.Add(new RefViewTreeNode(string.Empty) { IsFake = true });
                view_FatherStorageItemNode.ImageIndex = view_FatherStorageItemNode.SelectedImageIndex = sysIcons.GetIconIndex(GetPathIconForStorageItem(view_RefStorageItem_Loop.s_MainItemFullPath, view_RefStorageItem_Loop.s_MainItemName));
                pFatherRefNode.Nodes.Add(view_FatherStorageItemNode);

            }

            pFatherRefNode.Text = string.Format("Reference In ({0})", pFatherRefNode.Nodes.Count);

        }
        //void DisplayStorageItems()
        //{
        //    if (tvWorkSpace.SelectedNode == null)
        //        return;
        //    if (tvWorkSpace.SelectedNode.Tag == null)
        //        return;
        //    //lstStorageItem.Items.Clear();
        //    lstStorageItem.ClearUnFixedItems();

        //    WorkSpace workSpace = (WorkSpace)tvWorkSpace.SelectedNode.Tag;
        //    StorageItem storageItem = new StorageItem();
        //    AddSearchID(storageItem);
        //    AddSearchWorkSpace(storageItem, workSpace);
        //    //storageItem.Where.WorkSpaceID.Value = workSpace.ID;
        //    storageItem.Query.AddOrderBy(StorageItem.ColumnNames.ID, WhereParameter.Dir.ASC);
        //    if (storageItem.Query.Load())
        //    {

        //        foreach (StorageItem sItem in storageItem.AsList())
        //        {
        //            lstStorageItem.AddNewStorageItem(sItem);

        //        }
        //    }

        //    DisplayTotalCount();

        //}


        private string GetPathIconForStorageItem(string pFullPath, string pItemName)
        {
            string pathIcon = "do.dll";
            if (!string.IsNullOrEmpty(pFullPath))
                pathIcon = pFullPath;
            else if (!string.IsNullOrEmpty(pItemName))
                pathIcon = pItemName;

            return pathIcon;
        }


        private void tvWorkSpace_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //this.Text = DateTime.Now.Millisecond.ToString();
            //DisplayStorageItems();
            TreeNodeWorkSpace node = (TreeNodeWorkSpace)e.Node;
            node.PutColorAsChecked();

        }

        private void FrmMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
            {
                e.Effect = DragDropEffects.All;

                // e.Effect = DragDropEffects.None;
            }
        }

        /* Thread t = new Thread(new ThreadStart(new MethodInvoker(delegate()
                {
                    
                
                })));

                t.Start();
                this.Invoke(new MethodInvoker(delegate()
                {
                    

                }));
         * */


        private void FrmMain_DragDrop(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            //e.Effect = DragDropEffects.None;
            Point p = new Point(e.X, e.Y);
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                //if ((e.X >= lblDrop.Location.X) &&
                //    (e.X <= lblDrop.Location.X + lblDrop.Width) &&
                //    (e.Y >= lblDrop.Location.Y) &&
                //    (e.Y <= lblDrop.Location.Y + lblDrop.Height))

                Point cp = ctrlTargetArea.PointToClient(p);

                if (ctrlTargetArea.ClientRectangle.Contains(cp))
                {
                    for (int fileIndex = 0; fileIndex < files.Length; fileIndex++)
                    {

                        string sFile = files[fileIndex];
                        ctrlTargetArea.AddFile(sFile);
                    }
                    ctrlTargetArea.RefreshText();

                }

                else
                {
                    HandleDragOnMainForm(files);
                }

            }
            else
            {
                if (tabControl.SelectedItem == tabPageReference)
                {
                    if (tvRef.ClientRectangle.Contains(p))
                    {
                        mnuItemSetAsReference_Click(sender, e);
                    }
                }
                else
                {
                    TreeViewQuickList tv_ql_target = get_treeViewQuickList_in_point(p);
                    if (tv_ql_target != null)
                    {
                        tv_ql_target.Handle_DragDrop(sender, e);
                    }
                    else
                        lstStorageItem_DragDrop(sender, e);
                }
            }

        }
        private TreeViewQuickList get_treeViewQuickList_in_point(Point point)
        {
            foreach (TreeViewQuickList tv_q_l_loop in mTreeViewQuickList_List)
            {
                FATabStripItem fATabStripItem = tv_q_l_loop.Parent as FATabStripItem;
                if (tabControl.SelectedItem == fATabStripItem)
                {
                    Point cp = tv_q_l_loop.PointToClient(point);
                    if (tv_q_l_loop.ClientRectangle.Contains(cp))
                        return tv_q_l_loop;
                }
            }
            return null;

        }

        private void HandleDragOnMainForm(string[] pFiles)
        {
            if (tvWorkSpace.SelectedNode == null)
            {
                Helper.ERRORMSG("You must Select a Workspace...");
                return;
            }
            //StorageItem storageItem = (StorageItem)lstStorageItem.SelectedItems[0].Tag;
            WorkSpaceRow workSpace = (WorkSpaceRow)tvWorkSpace.SelectedNode.Tag;
            List<WorkSpaceRow> lWorkSpaceList = tvWorkSpace.GetWorkSpaceListFromTree();
            int filesCount = pFiles.Length;
            int fileIndex = 0;
            Application.DoEvents();
            //Thread.CurrentThread.Join();
            for (fileIndex = 0; fileIndex < filesCount; fileIndex++)
            {

                string sFile = pFiles[fileIndex];
                FileInfo fileInfo = new FileInfo(sFile);
                // string s = GetS();
                StorageItemDT lStorageItem = new StorageItemDT();
                lStorageItem.Query.AddWhereParameter(StorageItemDT.Parameters.FullPath, fileInfo.FullName);
                if (lStorageItem.Query.Load())
                {

                    ListViewStorageItem item = lstStorageItem.EnsureHasItem(lStorageItem[0].ID);
                    item.Selected = true;
                    //lstStorageItem_DoubleClick(null, null);
                    ShowStorageItem(item.StorageItem);
                }
                else
                {
                    FrmStorageItem frmStorageItem = new FrmStorageItem();
                    frmStorageItem.frmMain = this;
                    frmStorageItem.TheWorkSpace = workSpace;
                    frmStorageItem.WorkSpaceList = lWorkSpaceList;
                    //frmStorageItem.StorageItem = storageItem;
                    frmStorageItem.SetDraggedFile(fileInfo);
                    frmStorageItem.SetFilesIndexAndCount(fileIndex, filesCount);

                    frmStorageItem.ShowDialog(this);
                    if (frmStorageItem.StorageItem != null)
                    {
                        lstStorageItem.AddNewStorageItem(frmStorageItem.StorageItem);
                        HandleAfterSave(frmStorageItem.StorageItem);
                    }

                    if (frmStorageItem.IsCancelAll)
                    {
                        ctrlTargetArea.CancelAllPressedOnIndex(fileIndex);
                        break;
                    }

                    if (frmStorageItem.IsPaused)
                    {
                        ctrlTargetArea.PausedPressedOnIndex(fileIndex);
                        break;
                    }

                }

                //PutStorageItemInListViewItem(lstStorageItem.SelectedItems[0], frmStorageItem.StorageItem); 

            }
            if (fileIndex == filesCount)
                ctrlTargetArea.DragAllFilesOK();
            // DisplayStorageItems();
            DisplayTotalCount();
        }


        private void DisplayTotalCount()
        {
            int lFixedItemsCount = lstStorageItem.GetFixedItemsCount();
            int lNonFixedItemsCount = lstStorageItem.Items.Count - lFixedItemsCount;

            string sFixedItems = string.Format("Fixed={0}", lFixedItemsCount);
            string sNonFixedItems = string.Format("Non Fixed={0}", lNonFixedItemsCount);
            string sTotalItems = string.Format("Total Items={0}", lstStorageItem.Items.Count);

            sslTotal.Text = string.Format("{0} , {1} , {2}", sFixedItems, sNonFixedItems, sTotalItems);
        }


        private void mnuItemDeleteStorageItem_Click(object sender, EventArgs e)
        {
            if (lstStorageItem.SelectedItems.Count == 0)
                return;
            StorageItemRow storageItem = (StorageItemRow)lstStorageItem.SelectedItems[0].Tag;
            WorkSpaceRow workSpace = (WorkSpaceRow)tvWorkSpace.SelectedNode.Tag;
            //if (
            //    MessageBox.Show("Are You Sure, Do You Want To Delete ?",
            //    "",
            //    MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Question,
            //    MessageBoxDefaultButton.Button2)
            //    == DialogResult.Yes
            //    )

            if (
            MessageBox.Show("Are You Sure, Do You Want To Delete ?",
            "Confirm",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2)
            == DialogResult.Yes
            )
            {
                //bool canDeleteEntry = false;
                //if (storageItem.IsFileExist())
                //{
                //    if (storageItem.DeleteFile())
                //        canDeleteEntry = true;
                //    else
                //        canDeleteEntry = false;


                //}
                //else
                //    canDeleteEntry = true;
                // if (canDeleteEntry)
                {
                    long deletedID = storageItem.ID;
                    storageItem.DeleteStorageItem();
                    //storageItem.Save();
                    lstStorageItem.SelectedItems[0].Remove();
                    //DisplayStorageItems();
                    DisplayTotalCount();
                    foreach (TreeViewQuickList treeViewQList in mTreeViewQuickList_List)
                        treeViewQList.RemoveStorageItemID(deletedID);
                }
            }

        }

        private void mnuItemEditStorageItem_Click(object sender, EventArgs e)
        {
            lstStorageItem_DoubleClick(sender, e);
        }

        private void mnuItemNewStorageItem_Click(object sender, EventArgs e)
        {
            if (tvWorkSpace.SelectedNode == null)
            {
                Helper.ERRORMSG("You must select a workspace..");
                return;
            }
            if (tvWorkSpace.SelectedNode.Tag == null)
                return;
            WorkSpaceRow workSpace = (WorkSpaceRow)tvWorkSpace.SelectedNode.Tag;
            FrmStorageItem frmStorageItem = new FrmStorageItem();
            frmStorageItem.frmMain = this;
            frmStorageItem.TheWorkSpace = workSpace;
            frmStorageItem.WorkSpaceList = tvWorkSpace.GetWorkSpaceListFromTree();
            frmStorageItem.ShowDialog(this);
            if (frmStorageItem.IsSaved)
            {
                lstStorageItem.AddNewStorageItem(frmStorageItem.StorageItem);

                HandleAfterSave(frmStorageItem.StorageItem);

            }

            //DisplayStorageItems();
        }



        private void mnuItemOpenStorageItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = lstStorageItem.SelectedItems;
            StorageItemRow item;

            foreach (ListViewStorageItem itemLoop in selectedItems)
            {
                item = itemLoop.StorageItem;
                item.Open();


            }
        }

        private void mnuItemOpenCopy_Click(object sender, EventArgs e)
        {
            if (lstStorageItem.SelectedItems.Count == 0)
                return;
            ListView.SelectedListViewItemCollection selectedItems = lstStorageItem.SelectedItems;
            StorageItemRow item;
            string tempPath = Path.GetTempPath();
            string destFile;
            string extension;
            string newDest;
            Process process;

            foreach (ListViewStorageItem itemLoop in selectedItems)
            {
                item = itemLoop.StorageItem;
                if (item.IsFileExist())
                {
                    destFile = Path.GetFileNameWithoutExtension(item.FullPath);
                    extension = Path.GetExtension(item.FullPath);

                    // for (short i = 2; i < 1000; i++)
                    //{
                    newDest = Path.Combine(tempPath, destFile) + "_" + item.ID + extension;
                    if (!File.Exists(newDest))
                    {
                        File.Copy(item.FullPath, newDest, overwrite: false);
                        //Helper.OKMSG(newDest);

                    }

                    process = new Process();
                    process.StartInfo.FileName = newDest;
                    process.Start();
                    break;

                    //}
                }

            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ctrlTargetArea.GetFilesCount() > 0)
            {
                DialogResult result = MessageBox.Show(String.Format("You Have {0} File(s) \r\n Are You Sure You Want To Exit ?", ctrlTargetArea.GetFilesCount()),
                    "Exit Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (result == DialogResult.No)
                    e.Cancel = true;
                else
                    e.Cancel = false;

            }
            //txtSearchDescription.Text = string.Empty;
            if (IsMainWindow)
            {
                IniWorkSpace iniWorkSpace = new IniWorkSpace(tvWorkSpace);
                iniWorkSpace.Save();
                IniStorageItem iniStorageItem = new IniStorageItem(this);
                iniStorageItem.Save();

                //ctrlSearchContentProgress.DoStop();
                if (!e.Cancel)
                    ExitProcess(0);
            }
        }

        private void lstStorageItem_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    ListViewItem item = lstStorageItem.GetItemAt(e.X, e.Y);
            //    if (item == null)
            //        return;

            //    item.Selected = true;
            //    if (item.Tag == null)
            //        return;
            //    StorageItem storageItem = (StorageItem)item.Tag;



            //    if (storageItem.IsFolder)
            //    {
            //        ShellContextMenu ctxMnu = new ShellContextMenu();
            //        DirectoryInfo[] dir = new DirectoryInfo[1];
            //        dir[0] = new DirectoryInfo(storageItem.s_FullPath);
            //        ctxMnu.ShowContextMenu(dir, this.PointToScreen(new Point(e.X, e.Y)));


            //    }
            //    else
            //    {
            //        ShellContextMenu ctxMnu = new ShellContextMenu();
            //        FileInfo[] arrFI = new FileInfo[1];
            //        arrFI[0] = new FileInfo(storageItem.s_FullPath);
            //        ctxMnu.ShowContextMenu(arrFI, this.PointToScreen(new Point(e.X, e.Y)));

            //    }
            //}
        }

        private void mnuItemWindowsMenu_DropDownOpening(object sender, EventArgs e)
        {
            List<FileInfo> fileInfoList = new List<FileInfo>();
            foreach (ListViewStorageItem listViewStorageItem in lstStorageItem.SelectedItems)
            {
                fileInfoList.Add(new FileInfo(listViewStorageItem.StorageItem.s_FullPath));
            }

            ShellContextMenu ctxMnu = new ShellContextMenu();
            FileInfo[] arrFI = fileInfoList.ToArray();

            ctxMnu.ShowContextMenu(arrFI, this.PointToScreen(new Point(Cursor.Position.X, Cursor.Position.Y)));



            //ListViewItem item = lstStorageItem.SelectedItems[0];
            //if (item == null)
            //    return;

            //if (item.Tag == null)
            //    return;
            //StorageItem storageItem = (StorageItem)item.Tag;

            //if (storageItem.IsFolder)
            //{
            //    ShellContextMenu ctxMnu = new ShellContextMenu();
            //    DirectoryInfo[] dir = new DirectoryInfo[1];
            //    dir[0] = new DirectoryInfo(storageItem.s_FullPath);
            //    ctxMnu.ShowContextMenu(dir, this.PointToScreen(new Point(Cursor.Position.X, Cursor.Position.Y)));


            //}
            //else
            //{
            //    ShellContextMenu ctxMnu = new ShellContextMenu();
            //    FileInfo[] arrFI = new FileInfo[1];
            //    arrFI[0] = new FileInfo(storageItem.s_FullPath);
            //    ctxMnu.ShowContextMenu(arrFI, this.PointToScreen(new Point(Cursor.Position.X, Cursor.Position.Y)));

            //}

        }

        private void txtSearchDescription_TextChanged(object sender, EventArgs e)
        {
            ChangBackGroundColorForTextBox(txtSearchDescription);
            // if (!mAllowedStringHandler.IsFullStringOK(txtSearchDescription.Text))
            //     Helper.OKMSG("Please Chech Description Which You Are Searching For");
            DOSearch();

        }
        private void txtSearchCitation_TextChanged(object sender, EventArgs e)
        {
            ChangBackGroundColorForTextBox(txtSearchCitation);
            DOSearch();
        }

        private void txtSearchReferencesBib_TextChanged(object sender, EventArgs e)
        {
            ChangBackGroundColorForTextBox(txtSearchReferencesBib);
            DOSearch();
        }
        private void txtSearchImportantParts_TextChanged(object sender, EventArgs e)
        {
            ChangBackGroundColorForTextBox(txtSearchImportantParts);
            DOSearch();
        }

        private void ChangBackGroundColorForTextBox(TextBox pTextBox)
        {
            if (string.IsNullOrEmpty(pTextBox.Text))
                pTextBox.BackColor = SystemColors.Window;
            else
                pTextBox.BackColor = SystemColors.Info;

        }
        private void ChangBackGroundColorForComboBox(ComboBox pComboBox)
        {
            if (pComboBox.SelectedIndex == 0)
                pComboBox.BackColor = SystemColors.Window;
            else
                pComboBox.BackColor = SystemColors.Info;

        }

        private void DOSearch()
        {
            //System.GC.Collect();
            if (isInFormLoad)
                return;

            /*Employees e = new Employees();
             e.Query.OpenParenthesis();
             e.Where.DrivingLicense.Value = false;
             WhereParameter driving = e.Where.TearOff.DrivingLicense;
             driving.Operator = WhereParameter.Operand.IsNull;
             // add conjunction and close parenthesis
             driving.Conjuction = WhereParameter.Conj.Or;
             e.Query.CloseParenthesis();
             if(e.Query.Load())
             {
                 ....
             }*/


            //StorageItem storageItem = (StorageItem)lstStorageItem.SelectedItems[0].Tag;
            //WorkSpaceRow workSpace = (WorkSpaceRow)tvWorkSpace.SelectedNode.Tag;
            StorageItemDT storageItem = new StorageItemDT();
            //AddSearchID(storageItem);
            lstStorageItem.SuspendLayout();
            AddSearchTopN(storageItem);
            AddSearchWorkSpace(storageItem);
            AddSearchURL(storageItem);
            AddSearchFileName(storageItem);
            AddSearchPriority(storageItem);
            if (!string.IsNullOrEmpty(txtSearchDescription.Text))
            {
                string[] searchList = txtSearchDescription.Text.Split('&');
                foreach (string searchWord in searchList)
                {
                    AddAndSearchWord(storageItem, searchWord);
                }


                //storageItem.Where.Desciption.Value = "%" + txtSearchDescription.Text + "%";
                //storageItem.Where.Desciption.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like;

            }
            AddSearchCitation(storageItem);
            AddSearchReferencesBib(storageItem);
            AddSearchImportantParts(storageItem);
            // string sss = storageItem.Query.GenerateSQL();
            AddOrderBy_OrderType_ToQuery(storageItem);

            lstStorageItem.ClearItemsToDisplayNewSearchResult(chkClearPrevResult.Checked);

            //string ss = storageItem.Query.GenerateSQL();
            int fixedCountInQueryResult = 0;
            int nonFixedCountInQueryResult = 0;
            bool isLstStorageEmptyBeforeQuery = lstStorageItem.Items.Count == 0;
            storageItem.Query.Load();
            if (storageItem.Rows.Count > 0)
            {

                //lstStorageItem.ClearUnFixedItems();
                //List<StorageItem> theResultList = storageItem.AsList();
                FilterResults(storageItem);

                for (int i = storageItem.Rows.Count - 1; i >= 0; i--)
                {
                    StorageItemRow sItem = storageItem[i];
                    if (sItem.IsFixed)
                    {
                        fixedCountInQueryResult++;
                        if (isLstStorageEmptyBeforeQuery)
                            lstStorageItem.AddNewStorageItem(sItem, Color.Lavender, false);
                        else
                            lstStorageItem.EnsureHasItem(sItem.ID, Color.Lavender, true, false);
                    }
                    else
                    {
                        nonFixedCountInQueryResult++;
                        lstStorageItem.AddNewStorageItem(sItem);
                    }
                }

                SelectLastViewedStorageItem();

            }


            sslFitered.Text = String.Format("Filtered = {0} ", mFilteredItemsCount);
            DisplayTotalCount();

            //DisplayTotalInQueryResult(fixedCountInQueryResult, nonFixedCountInQueryResult);

            lstStorageItem.ResumeLayout(true);

        }

        //private void DisplayTotalInQueryResult(int pFixedCountInQueryResult, int pNonFixedCountInQueryResult)
        //{
        //    string sFixedItems = string.Format("Fixed={0}", pFixedCountInQueryResult);
        //    string sNonFixedItems = string.Format("Non Fixed={0}", pNonFixedCountInQueryResult);
        //    string sTotalItems = string.Format("Total Items={0}", pFixedCountInQueryResult + pNonFixedCountInQueryResult);

        //   // sslTotalInQueryResult.Text = string.Format("Search Result -> {0} , {1} , {2}", sFixedItems, sNonFixedItems, sTotalItems);

        //}

        private void SelectLastViewedStorageItem()
        {
            foreach (ListViewStorageItem listViewStorageItem in lstStorageItem.Items)
            {
                if (listViewStorageItem.StorageItem.ID == mSelectedStorageItemID)
                {
                    listViewStorageItem.EnsureVisible();
                    listViewStorageItem.Selected = true;
                    break;
                }

            }

        }

        //private void AddSearchID(StorageItem pStorageItem)
        //{
        //    string lIDs = lstStorageItem.GetFixedIDsAsString();
        //    if (!string.IsNullOrEmpty(lIDs))
        //    {
        //        pStorageItem.Where.ID.Operator = WhereParameter.Operand.NotIn;
        //        pStorageItem.Where.ID.Value = lIDs;
        //        pStorageItem.Where.ID.Conjuction = WhereParameter.Conj.And;
        //    }
        //}

        private void AddSearchTopN(StorageItemDT pStorageItem)
        {
            if (!cmbTopN.SelectedItem.Equals(TopNOptions.ALL))
            {
                int topN = Convert.ToInt32(cmbTopN.SelectedItem.ToString());
                if (topN > 0)
                    pStorageItem.Query._top = topN;
            }

        }

        private void AddSearchWorkSpace(StorageItemDT pStorageItem)
        {
            if (!chkSearchInAllCategories.Checked)
            {
                string lWorkSpaceIDSString = tvWorkSpace.GetSelectIDsWithDummyAsString();
                MyParameter param = pStorageItem.Query.AddWhereParameter(StorageItemDT.ColumnNames.WorkSpaceID, MyOperand.In, StorageItemDT.Parameters.WorkSpaceID, lWorkSpaceIDSString);
                param.Conjuction = MyConj.And;

            }


            //if (!pWorkSpace.IsForAll)
            //{
            //    pStorageItem.Where.WorkSpaceID.Value = pWorkSpace.ID;
            //    pStorageItem.Where.WorkSpaceID.Conjuction = WhereParameter.Conj.And;
            //}

        }

        private void AddOrderBy_OrderType_ToQuery(StorageItemDT pStorageItem)
        {
            MyDir theDir = MyDir.ASC;

            //here we reverese because we wil dispay from last to begin
            if (cmbSortType.Text == SortTypeOptions.ASC)
                theDir = MyDir.DESC;
            else
                theDir = MyDir.ASC;


            if ((cmbOrder.SelectedIndex <= -1) || (cmbOrder.Text == ORDER_OF_ADDITION))
                pStorageItem.Query.AddOrderBy(StorageItemDT.ColumnNames.ID, theDir);
            else if (cmbOrder.Text == NAME)
                pStorageItem.Query.AddOrderBy(StorageItemDT.ColumnNames.ItemName, theDir);
            else if (cmbOrder.Text == WORK_SPACE_ID)
                pStorageItem.Query.AddOrderBy(StorageItemDT.ColumnNames.WorkSpaceID, theDir);
            else if (cmbOrder.Text == PRIORITY)
                pStorageItem.Query.AddOrderBy(StorageItemDT.ColumnNames.Priority, theDir);

            else if (cmbOrder.Text == PAGES_COUNT)
                pStorageItem.Query.AddOrderBy(StorageItemDT.ColumnNames.PagesCount, theDir);

            else if (cmbOrder.Text == DESCRIPTION)
                pStorageItem.Query.AddOrderBy(StorageItemDT.ColumnNames.Description, theDir);
            else if (cmbOrder.Text == CITATION)
                pStorageItem.Query.AddOrderBy(StorageItemDT.ColumnNames.Citation, theDir);

            else if (cmbOrder.Text == REFERENCE_BIB)
                pStorageItem.Query.AddOrderBy(StorageItemDT.ColumnNames.ReferenceBib, theDir);

            else if (cmbOrder.Text == IMPORTANT_PARTS)
                pStorageItem.Query.AddOrderBy(StorageItemDT.ColumnNames.ImportantParts, theDir);



        }

        private void AddSearchPriority(StorageItemDT pStorageItem)
        {
            int maxValue = Convert.ToInt32(upDownPriority.Value);
            //if (maxValue > 0)
            //{
            if (pStorageItem.Query.ParameterCount > 0)
                pStorageItem.Query.AddConjunction(MyConj.And);
            pStorageItem.Query.OpenParenthesis();

            MyParameter descParameter1 = pStorageItem.Query.AddWhereParameter(StorageItemDT.Parameters.Priority);

            if (cmbPriorityOperand.Text == GREATER_THAN)
                descParameter1.Operator = MyOperand.GreaterThanOrEqual;
            else if (cmbPriorityOperand.Text == EQUAL)
                descParameter1.Operator = MyOperand.Equal;
            else if (cmbPriorityOperand.Text == LESS_THAN)
                descParameter1.Operator = MyOperand.LessThanOrEqual;


            descParameter1.Value = maxValue;
            //descParameter1.Conjuction = WhereParameter.Conj.Or;


            //WhereParameter descParameter2 = pStorageItem.Where.TearOff.URL;
            //descParameter2.Operator = WhereParameter.Operand.Like;
            //descParameter2.Value = txtToSearch.ToUpper();
            //descParameter2.Conjuction = WhereParameter.Conj.Or;

            pStorageItem.Query.CloseParenthesis();
            //}

        }

        private void AddSearchURL(StorageItemDT pStorageItem)
        {
            if (!string.IsNullOrEmpty(txtSearchURL.Text))
            {
                string txtToSearch = "%" + txtSearchURL.Text + "%";
                if (pStorageItem.Query.ParameterCount > 0)
                    pStorageItem.Query.AddConjunction(MyConj.And);
                pStorageItem.Query.OpenParenthesis();

                MyParameter descParameter1 = pStorageItem.Query.AddWhereParameter(StorageItemDT.Parameters.URL);
                descParameter1.Operator = MyOperand.Like;
                descParameter1.Value = txtToSearch.ToLower();
                //descParameter1.Conjuction = WhereParameter.Conj.Or;


                MyParameter descParameter2 = pStorageItem.Query.AddWhereParameter(StorageItemDT.Parameters.URL);
                descParameter2.Operator = MyOperand.Like;
                descParameter2.Value = txtToSearch.ToUpper();
                descParameter2.Conjuction = MyConj.Or;

                pStorageItem.Query.CloseParenthesis();

            }
        }

        private void AddSearchFileName(StorageItemDT pStorageItem)
        {
            if (!string.IsNullOrEmpty(txtSearchFileName.Text))
            {
                string txtToSearch = "%" + txtSearchFileName.Text + "%";
                if (pStorageItem.Query.ParameterCount > 0)
                    pStorageItem.Query.AddConjunction(MyConj.And);
                pStorageItem.Query.OpenParenthesis();

                MyParameter descParameter1 = pStorageItem.Query.AddWhereParameter(StorageItemDT.Parameters.ItemName);
                descParameter1.Operator = MyOperand.Like;
                descParameter1.Value = txtToSearch.ToLower();
                //descParameter1.Conjuction = WhereParameter.Conj.Or;

                MyParameter descParameter2 = pStorageItem.Query.AddWhereParameter(StorageItemDT.Parameters.ItemName);
                descParameter2.Operator = MyOperand.Like;
                descParameter2.Value = txtToSearch.ToUpper();
                descParameter2.Conjuction = MyConj.Or;

                pStorageItem.Query.CloseParenthesis();

            }
        }

        private void AddAndSearchWord(StorageItemDT pStorageItem, string pSearchWord)
        {
            string[] split_arr = pSearchWord.Split('|');
            if (pStorageItem.Query.ParameterCount > 0)
                pStorageItem.Query.AddConjunction(MyConj.And);
            pStorageItem.Query.OpenParenthesis();

            foreach (string word in split_arr)
            {

                string txtToSearch = "%" + word + "%";
                MyParameter descParameter1 = pStorageItem.Query.AddWhereParameter(StorageItemDT.Parameters.Description);
                descParameter1.Operator = MyOperand.Like;
                descParameter1.Value = txtToSearch.ToLower();
                descParameter1.Conjuction = MyConj.Or;


                MyParameter descParameter2 = pStorageItem.Query.AddWhereParameter(StorageItemDT.Parameters.Description);
                descParameter2.Operator = MyOperand.Like;
                descParameter2.Value = txtToSearch.ToUpper();
                descParameter2.Conjuction = MyConj.Or;
            }

            pStorageItem.Query.CloseParenthesis();
        }
        private void AddSearchReferencesBib(StorageItemDT pStorageItem)
        {
            if (!string.IsNullOrEmpty(txtSearchReferencesBib.Text))
            {
                string txtToSearch = "%" + txtSearchReferencesBib.Text + "%";
                if (pStorageItem.Query.ParameterCount > 0)
                    pStorageItem.Query.AddConjunction(MyConj.And);
                pStorageItem.Query.OpenParenthesis();

                MyParameter descParameter1 = pStorageItem.Query.AddWhereParameter(StorageItemDT.Parameters.ReferenceBib);
                descParameter1.Operator = MyOperand.Like;
                descParameter1.Value = txtToSearch.ToLower();
                //descParameter1.Conjuction = WhereParameter.Conj.Or;


                MyParameter descParameter2 = pStorageItem.Query.AddWhereParameter(StorageItemDT.Parameters.ReferenceBib);
                descParameter2.Operator = MyOperand.Like;
                descParameter2.Value = txtToSearch.ToUpper();
                descParameter2.Conjuction = MyConj.Or;

                pStorageItem.Query.CloseParenthesis();

            }
        }

        private void AddSearchCitation(StorageItemDT pStorageItem)
        {
            if (!string.IsNullOrEmpty(txtSearchCitation.Text))
            {
                string txtToSearch = "%" + txtSearchCitation.Text + "%";
                if (pStorageItem.Query.ParameterCount > 0)
                    pStorageItem.Query.AddConjunction(MyConj.And);
                pStorageItem.Query.OpenParenthesis();

                MyParameter descParameter1 = pStorageItem.Query.AddWhereParameter(StorageItemDT.Parameters.Citation);
                descParameter1.Operator = MyOperand.Like;
                descParameter1.Value = txtToSearch.ToLower();
                //descParameter1.Conjuction = WhereParameter.Conj.Or;


                MyParameter descParameter2 = pStorageItem.Query.AddWhereParameter(StorageItemDT.Parameters.Citation);
                descParameter2.Operator = MyOperand.Like;
                descParameter2.Value = txtToSearch.ToUpper();
                descParameter2.Conjuction = MyConj.Or;

                pStorageItem.Query.CloseParenthesis();

            }

        }
        private void AddSearchImportantParts(StorageItemDT pStorageItem)
        {
            if (!string.IsNullOrEmpty(txtSearchImportantParts.Text))
            {
                string txtToSearch = "%" + txtSearchImportantParts.Text + "%";
                if (pStorageItem.Query.ParameterCount > 0)
                    pStorageItem.Query.AddConjunction(MyConj.And);
                pStorageItem.Query.OpenParenthesis();

                MyParameter descParameter1 = pStorageItem.Query.AddWhereParameter(StorageItemDT.Parameters.ImportantParts);
                descParameter1.Operator = MyOperand.Like;
                descParameter1.Value = txtToSearch.ToLower();
                //descParameter1.Conjuction = WhereParameter.Conj.Or;


                MyParameter descParameter2 = pStorageItem.Query.AddWhereParameter(StorageItemDT.Parameters.ImportantParts);
                descParameter2.Operator = MyOperand.Like;
                descParameter2.Value = txtToSearch.ToUpper();
                descParameter2.Conjuction = MyConj.Or;

                pStorageItem.Query.CloseParenthesis();

            }
        }

        private void lstStorageItem_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtMainStorageItemDesc.Text = string.Empty;
            txtMainStorageItemDesc2.Text = string.Empty;
            if (lstStorageItem.SelectedItems.Count == 0)
                return;

            if (lstStorageItem.SelectedItems.Count >= 2)
                return;

            ListViewItem item = lstStorageItem.SelectedItems[0];
            StorageItemRow storageItem = (StorageItemRow)item.Tag;
            DisplayDesc(storageItem);

            mSelectedStorageItemID = storageItem.ID;


        }

        private void btnSearchContent_Click(object sender, EventArgs e)
        {
            //Thread myThread = new Thread(new ThreadStart(GoToSearchContent));

            // myThread.Start();
            GoToSearchContent();
        }
        private void GoToSearchContent()
        {

            foreach (ListViewStorageItem item in lstStorageItem.Items)
                item.SetColorToDefault();

            ctrlSearchContentProgress.DoStop();
            ctrlSearchContentProgress.ListView = this.lstStorageItem;
            ctrlSearchContentProgress.TextToSearch = txtSearchContent.Text;
            ctrlSearchContentProgress.IsStopped = false;

            if (lstStorageItem.Items.Count > 0)
                lstStorageItem.Items[0].EnsureVisible();


            Application.DoEvents();
            ctrlSearchContentProgress.Visible = true;
            Application.DoEvents();
            ctrlSearchContentProgress.RunSearchThread();
        }

        private void lstStorageItem_ItemDrag(object sender, ItemDragEventArgs e)
        {
            List<ListViewStorageItem> listViewStorageItemList = this.lstStorageItem.GetSelectedListViewStorageItems();
            this.lstStorageItem.DoDragDrop(listViewStorageItemList, DragDropEffects.All);

        }

        private void tvWorkSpace_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<ListViewStorageItem>)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void tvWorkSpace_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<ListViewStorageItem>)))
            {
                //StorageItem storageItem = (StorageItem)lstStorageItem.SelectedItems[0].Tag;
                //WorkSpace workSpace = (WorkSpace)tvWorkSpace.SelectedNode.Tag;
                List<ListViewStorageItem> itemsList = (List<ListViewStorageItem>)e.Data.GetData(typeof(List<ListViewStorageItem>));
                Point pos = tvWorkSpace.PointToClient(new Point(e.X, e.Y));
                TreeNode targetNode = tvWorkSpace.GetNodeAt(pos);
                //TreeNode nodeCopy;
                if (targetNode != null)
                {
                    WorkSpaceRow workSpace = (WorkSpaceRow)targetNode.Tag;
                    foreach (ListViewStorageItem item in itemsList)
                    {
                        StorageItemRow storageItem = (StorageItemRow)item.Tag;
                        storageItem.WorkSpaceID = workSpace.ID;
                        storageItem.Save();
                        lstStorageItem.Items.Remove(item);
                    }
                    //SelectNewItemAfterDelet(item);
                }
            }
        }

        private void SelectNewItemAfterDelet(ListViewItem pItem)
        {
            int i = pItem.Index;
            if (lstStorageItem.Items.Count == 0)
                return;

            if (i < lstStorageItem.Items.Count - 1)
                lstStorageItem.Items[i].Selected = true;
            else
            {
                i = i - 1;
                if (i < lstStorageItem.Items.Count - 1)
                    lstStorageItem.Items[i].Selected = true;
            }
        }

        private void txtSearchURL_TextChanged(object sender, EventArgs e)
        {
            ChangBackGroundColorForTextBox(txtSearchURL);
            DOSearch();
        }

        private void txtSearchFileName_TextChanged(object sender, EventArgs e)
        {
            ChangBackGroundColorForTextBox(txtSearchFileName);
            DOSearch();
        }

        private void upDownPriority_ValueChanged(object sender, EventArgs e)
        {
            int intValue = Convert.ToInt32(upDownPriority.Value);
            if (intValue == 0)
                upDownPriority.BackColor = SystemColors.Window;
            else
                upDownPriority.BackColor = SystemColors.Info;

            DOSearch();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstStorageItem.Items)
            {
                StorageItemRow storageItem = (StorageItemRow)item.Tag;
                try
                {
                    if (storageItem.IsFileExist())

                        if (storageItem.GetExtension().ToUpper().Equals(".PDF".ToUpper()))
                        {
                            string file = Path.GetFullPath(storageItem.s_FullPath);
                            PdfReader reader = new PdfReader(file);
                            storageItem.PagesCount = reader.NumberOfPages;
                            storageItem.Save();
                            //txtMainStorageItemDesc.Text += "\r\n----------\r\n";
                            //txtMainStorageItemDesc.Text += string.Format("{0} pages", reader.NumberOfPages);
                        }
                }
                catch (Exception ex)
                {
                    Helper.HandleException(ex);
                }
            }
        }

        private void cmbOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mIsOrderByInFilling)
                return;
            ChangBackGroundColorForComboBox(cmbOrder);
            DOSearch();
        }

        private void cmbPriorityOperand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mIsPriorityOperandInFilling)
                return;
            ChangBackGroundColorForComboBox(cmbPriorityOperand);
            DOSearch();
        }

        private void mnuItemSetAsMainStorageItem_Click(object sender, EventArgs e)
        {
            if (lstStorageItem.SelectedItems.Count == 0)
                return;
            mMainStorageItem = (StorageItemRow)lstStorageItem.SelectedItems[0].Tag;
            ctrlReferenceNavigator.PutPositionForStorageItemID(mMainStorageItem.ID);
            DisplayMainStorageItem();
            DisplayRefForMainStorage();
            tabControl.SelectedItem = tabPageReference;
        }

        public void LoadMainStorageItemByID(int pID)
        {
            //mMainStorageItem = new StorageItem();
            StorageItemDT dt = new StorageItemDT();
            dt.LoadByPrimaryKey(pID);
            if (dt.Rows.Count > 0)
            {
                mMainStorageItem = dt[0];
                DisplayMainStorageItem();
                //DisplayRefForMainStorage();
            }
            else
                mMainStorageItem = null;
        }


        private void DisplayMainStorageItem()
        {
            txtMainFullPath.Text = mMainStorageItem.s_FullPath;
            txtMainDesc.Text = mMainStorageItem.s_Description;
        }
        private void DisplayRefForMainStorage()
        {
            tvRef.DisplayRefForMainStorage(mMainStorageItem.ID);
        }

        //private ListViewItem GetListViewItemFromViewRrefStorageItem(View_RefStorageItemRow pViewRefItem)
        //{
        //    ListViewItem item = new ListViewItem();
        //    PutViewRefStorageItemInListViewItem(item, pViewRefItem);
        //    return item;

        //}
        //private void PutViewRefStorageItemInListViewItem(ListViewItem pListViewItem, View_RefStorageItemRow pViewRefStorageItem)
        //{
        //    pListViewItem.SubItems.Clear();
        //    pListViewItem.Text = pViewRefStorageItem.s_URL;

        //    pListViewItem.SubItems.Add(pViewRefStorageItem.s_FullPath);
        //    pListViewItem.SubItems.Add(pViewRefStorageItem.s_ItemName);
        //    pListViewItem.SubItems.Add(pViewRefStorageItem.s_Size);
        //    pListViewItem.SubItems.Add(pViewRefStorageItem.s_Priority);
        //    pListViewItem.SubItems.Add(pViewRefStorageItem.s_PagesCount);
        //    pListViewItem.SubItems.Add(pViewRefStorageItem.s_RefDesciption);
        //    pListViewItem.Tag = pViewRefStorageItem;
        //    StorageItemDT storageItem = new StorageItemDT();
        //    storageItem.LoadByPrimaryKey(pViewRefStorageItem.RefStorageItemID);
        //    pListViewItem.ImageIndex = sysIcons.GetIconIndex(storageItem[0].GetPathIconForStorageItem());

        //}

        private void mnuItemSetAsReference_Click(object sender, EventArgs e)
        {
            if (mMainStorageItem == null)
            {
                Helper.ERRORMSG("Please  Select  Main  Entry  First !");
                return;
            }

            if (lstStorageItem.SelectedItems.Count == 0)
                return;

            StorageItemRow detStorageItem = (StorageItemRow)lstStorageItem.SelectedItems[0].Tag;
            RefStorageItemDT refStorageItem = new RefStorageItemDT();
            if (refStorageItem.LoadByPrimaryKey(mMainStorageItem.ID, detStorageItem.ID))
            {
                Helper.ERRORMSG("Reference already Exists !");
                return;
            }

            if (mMainStorageItem.ID == detStorageItem.ID)
            {
                Helper.ERRORMSG("Self Reference Is Not Allowed !");
                return;

            }
            RefStorageItemRow refStorageItemRow = refStorageItem.NewRefStorageItemRow();
            //refStorageItem.AddNew();

            refStorageItemRow.MainStorageItemID = mMainStorageItem.ID;
            refStorageItemRow.RefStorageItemID = detStorageItem.ID;
            refStorageItemRow.Save();
            View_RefStorageItemDT view_RefStorageItem = new View_RefStorageItemDT();
            view_RefStorageItem.Query.AddWhereParameter(View_RefStorageItemDT.Parameters.MainStorageItemID, mMainStorageItem.ID);
            view_RefStorageItem.Query.AddWhereParameter(View_RefStorageItemDT.Parameters.RefStorageItemID, detStorageItem.ID);
            view_RefStorageItem.Query.Load();
            tvRef.AddNewNodeForView_ListStorageItem(view_RefStorageItem[0]);
            tabControl.SelectedItem = tabPageReference;
            DisplayReferenceView(detStorageItem);

        }

        private void mnuItemRemoveRef_Click(object sender, EventArgs e)
        {
            if (tvRef.SelectedNode == null)
                return;
            View_RefStorageItemRow view_RefStorageItem = (View_RefStorageItemRow)tvRef.SelectedNode.Tag;
            RefStorageItemDT refStorageItem = new RefStorageItemDT();
            refStorageItem.LoadByPrimaryKey(view_RefStorageItem.MainStorageItemID, view_RefStorageItem.RefStorageItemID);
            refStorageItem[0].DeleteRefStorageItem();
            //refStorageItem.Save();

            tvRef.SelectedNode.Remove();

            if (lstStorageItem.SelectedItems.Count == 0)
                return;
            StorageItemRow storageItem = (StorageItemRow)lstStorageItem.SelectedItems[0].Tag;
            DisplayReferenceView(storageItem);
        }

        private void BtnGroupBySite_Click(object sender, EventArgs e)
        {
            tvSiteGroup.Nodes.Clear();
            Dictionary<string, List<StorageItemRow>> dicStorageItem = new Dictionary<string, List<StorageItemRow>>();

            foreach (ListViewItem item in lstStorageItem.Items)
            {

                StorageItemRow storageItem = (StorageItemRow)item.Tag;
                AddStorageItemToDic(storageItem, dicStorageItem);

            }

            List<KeyValuePair<string, List<StorageItemRow>>> myList = new List<KeyValuePair<string, List<StorageItemRow>>>(dicStorageItem);
            myList.Sort(
                delegate(KeyValuePair<string, List<StorageItemRow>> first,
                KeyValuePair<string, List<StorageItemRow>> second)
                {
                    return first.Value.Count.CompareTo(second.Value.Count);
                }
            );


            DisplayGroupList(tvSiteGroup, myList, null, string.Empty);

        }

        private void DisplayGroupList(TreeView pTVTarget, List<KeyValuePair<string, List<StorageItemRow>>> pMyList, StorageItemRow pSelectedStorageItem, string pOptionalTextOnNode)
        {
            foreach (KeyValuePair<string, List<StorageItemRow>> pair in pMyList)
            {
                TreeNode hostNode = new TreeNode(pair.Key + " " + pOptionalTextOnNode + " " + " (" + pair.Value.Count + ")");
                hostNode.Tag = pair.Key;
                foreach (StorageItemRow sItem in pair.Value)
                {
                    TreeNode itemNode = new TreeNode(sItem.ItemName + " (" + sItem.Description + ")");
                    //itemNode.ImageIndex = 2;
                    //itemNode.SelectedImageIndex = 2;
                    itemNode.Tag = sItem;
                    itemNode.ImageIndex = itemNode.SelectedImageIndex = sysIcons.GetIconIndex(sItem.GetPathIconForStorageItem());
                    hostNode.Nodes.Add(itemNode);
                    if (pSelectedStorageItem != null)
                        if (pSelectedStorageItem.ID == sItem.ID)
                        {
                            itemNode.EnsureVisible();
                            itemNode.BackColor = Color.Red;
                            hostNode.ExpandAll();

                        }
                }
                hostNode.ImageIndex = hostNode.SelectedImageIndex = sysIcons.GetIconIndex(Application.ExecutablePath);
                pTVTarget.Nodes.Add(hostNode);
            }
        }

        private void AddStorageItemToDic(StorageItemRow pStorageItem, Dictionary<string, List<StorageItemRow>> pDicStorageItem)
        {
            string host = pStorageItem.GetHost();
            if (pDicStorageItem.ContainsKey(host))
                pDicStorageItem[host].Add(pStorageItem);
            else
            {
                List<StorageItemRow> lListStorageItem = new List<StorageItemRow>();
                lListStorageItem.Add(pStorageItem);
                pDicStorageItem.Add(host, lListStorageItem);
            }
        }

        private void tvSiteGroup_AfterSelect(object sender, TreeViewEventArgs e)
        {
            MakeStorageItemVisibleBySiteGroup(tvSiteGroup);

        }

        private void MakeStorageItemVisibleBySiteGroup(TreeView pTVSiteGroup)
        {
            if (pTVSiteGroup.SelectedNode == null)
                return;
            if (pTVSiteGroup.SelectedNode.Tag == null)
                return;
            if (pTVSiteGroup.SelectedNode.Tag is StorageItemRow)
            {

                StorageItemRow selectedItem = (StorageItemRow)pTVSiteGroup.SelectedNode.Tag;
                lstStorageItem.EnsureHasItem(selectedItem.ID, Color.Green, false, true);

            }
            else if (pTVSiteGroup.SelectedNode.Tag is string)
            {
                lstStorageItem.SetBackColorForAllItemsWith(Color.White);

                bool lIsSkip = false;
                Color myColor = Color.Green;
                foreach (TreeNode node in pTVSiteGroup.SelectedNode.Nodes)
                {
                    bool isFound = false;
                    StorageItemRow selectedItem = (StorageItemRow)node.Tag;
                    foreach (ListViewStorageItem item in lstStorageItem.Items)
                    {
                        //item.BackColor = Color.White;
                        if (selectedItem.ID == item.StorageItem.ID)
                        {
                            isFound = true;
                            item.BackColor = myColor;
                            if (!lIsSkip)
                            {
                                item.EnsureVisible();
                                lIsSkip = true;
                            }
                        }
                    }

                    if (!isFound)
                        lstStorageItem.AddNewStorageItem(selectedItem.ID, myColor, true);

                }
            }
        }

        private void tvRefView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {

            if ((e.Node != null) && (e.Node is RefViewTreeNode))
            {
                RefViewTreeNode refViewTreeNode = (RefViewTreeNode)e.Node;
                if (refViewTreeNode.IsLoaded)
                    return;

                if (refViewTreeNode.Nodes.Count > 0)
                    if (refViewTreeNode.Nodes[0] is RefViewTreeNode)
                    {
                        RefViewTreeNode childRefViewTreeNode = (RefViewTreeNode)refViewTreeNode.Nodes[0];
                        if (childRefViewTreeNode.IsFake)
                            childRefViewTreeNode.Remove();
                        View_RefStorageItemRow view_RefStorageItem = (View_RefStorageItemRow)refViewTreeNode.Tag;
                        refViewTreeNode.Nodes.Add(GetNewRefNode());
                        refViewTreeNode.Nodes.Add(GetNewFatherItemNode());
                        DisplayReferenceView_Reference(refViewTreeNode.Nodes[0], refViewTreeNode.StorageItemID);
                        DisplayReferenceView_FatherItems(refViewTreeNode.Nodes[1], refViewTreeNode.StorageItemID);

                        //refViewTreeNode.Expand();
                        refViewTreeNode.Nodes[0].Expand();
                        refViewTreeNode.Nodes[1].Expand();
                        refViewTreeNode.IsLoaded = true;

                    }
            }

        }

        private void tvRefView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvRefView.Nodes.Count == 0)
                return;

            if (!(e.Node is RefViewTreeNode))
                return;
            RefViewTreeNode refViewTreeNode = (RefViewTreeNode)e.Node;
            lstStorageItem.EnsureHasItem(refViewTreeNode.StorageItemID, Color.Yellow, false, true);

        }

        private void mnuItemBrowseHostName_Click(object sender, EventArgs e)
        {
            if (lstStorageItem.SelectedItems.Count == 0)
                return;
            StorageItemRow storageItem = (StorageItemRow)lstStorageItem.SelectedItems[0].Tag;
            string protocolAndHost = storageItem.GetProtocolAndHost();
            Process process = new Process();
            process.StartInfo.FileName = protocolAndHost;
            process.Start();


        }

        private void mnuItemBrowseURL_Click(object sender, EventArgs e)
        {
            if (lstStorageItem.SelectedItems.Count == 0)
                return;
            StorageItemRow storageItem = (StorageItemRow)lstStorageItem.SelectedItems[0].Tag;
            //fInfo.Directory.FullName
            string urlPath = storageItem.GetURLPath();
            Process process = new Process();
            process.StartInfo.FileName = urlPath;
            process.Start();

        }

        private void tvOneSiteGroup_AfterSelect(object sender, TreeViewEventArgs e)
        {
            MakeStorageItemVisibleBySiteGroup(tvOneSiteGroup);
        }

        private void tvWorkSpace_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeNodeWorkSpace treeNodeWorkSpace = (TreeNodeWorkSpace)e.Node;
            treeNodeWorkSpace.PutColorAsChecked();
            treeNodeWorkSpace.WorkSpace.IsActive = treeNodeWorkSpace.Checked;
            treeNodeWorkSpace.WorkSpace.Save();
            DOSearch();
        }

        private void ctrlReferenceNavigator_ReferenceNavigatorPositionChanged(object sender, ReferenceNavigatorPositionChangedEventArgs e)
        {
            StorageItemDT storageItem = new StorageItemDT();
            if (storageItem.LoadByPrimaryKey(e.StorageItemID))
            {

                mMainStorageItem = storageItem[0];
                DisplayMainStorageItem();
                DisplayRefForMainStorage();
            }
        }

        private void ctrlReferenceNavigator_LocateClicked(object sender, EventArgs e)
        {
            bool isFound = false;
            Color myColor = Color.Yellow;
            foreach (ListViewStorageItem listViewStorageItem in lstStorageItem.Items)
            {
                if (listViewStorageItem.BackColor == myColor)
                    listViewStorageItem.SetColorToDefault();

                if (listViewStorageItem.StorageItem.ID == ctrlReferenceNavigator.CurrentStorageItemID)
                {
                    isFound = true;
                    listViewStorageItem.EnsureVisible();
                    listViewStorageItem.BackColor = Color.Yellow;
                }
            }
            if (!isFound)
            {
                lstStorageItem.AddNewStorageItem(ctrlReferenceNavigator.CurrentStorageItemID, myColor, true);
            }
        }

        private void txtSearchContent_TextChanged(object sender, EventArgs e)
        {
            ChangBackGroundColorForTextBox(txtSearchContent);
        }

        private void lstStorageItem_DragEnter(object sender, DragEventArgs e)
        {
            int len = e.Data.GetFormats().Length - 1;
            int i;
            for (i = 0; i <= len; i++)
            {
                if (e.Data.GetFormats()[i].Equals("System.Windows.Forms.ListView+SelectedListViewItemCollection"))
                {
                    //The data from the drag source is moved to the target.	
                    e.Effect = DragDropEffects.Move;
                }
            }

        }

        private void lstStorageItem_DragDrop(object sender, DragEventArgs e)
        {
            //Return if the items are not selected in the ListView control.
            if (lstStorageItem.SelectedItems.Count == 0)
            {
                return;
            }
            //Returns the location of the mouse pointer in the ListView control.
            Point cp = lstStorageItem.PointToClient(new Point(e.X, e.Y));
            //Obtain the item that is located at the specified location of the mouse pointer.
            ListViewStorageItem dragToItem = (ListViewStorageItem)lstStorageItem.GetItemAt(cp.X, cp.Y);
            if (dragToItem == null)
            {
                return;
            }
            //Obtain the index of the item at the mouse pointer.
            int dragIndex = dragToItem.Index;
            ListViewItem[] sel = new ListViewItem[lstStorageItem.SelectedItems.Count];
            for (int i = 0; i <= lstStorageItem.SelectedItems.Count - 1; i++)
            {
                sel[i] = lstStorageItem.SelectedItems[i];
            }
            //for (int i = 0; i < sel.GetLength(0); i++)
            //{
            //Obtain the ListViewItem to be dragged to the target location.
            // ListViewItem dragItem = sel[i];
            ListViewItem dragItem = sel[0];
            int itemIndex = dragIndex;
            if (itemIndex == dragItem.Index)
            {
                return;
            }
            //if (dragItem.Index < itemIndex)
            //    itemIndex++;
            //else
            //    itemIndex = dragIndex + i;
            //Insert the item at the mouse pointer.
            //ListViewItem insertItem = (ListViewItem)dragItem.Clone();
            //lstStorageItem.Items.Insert(itemIndex, insertItem);
            //Removes the item from the initial location while 
            //the item is moved to the new location.
            // lstStorageItem.Items.Remove(dragItem);
            //}
            StorageItemRow lMainStorageItem = dragToItem.StorageItem;
            StorageItemRow lRefStorageItem = ((ListViewStorageItem)dragItem).StorageItem;
            FrmReferenceDrag frmReferenceDrag = new FrmReferenceDrag();
            frmReferenceDrag.MainStorageItem = lMainStorageItem;
            frmReferenceDrag.RefStorageItem = lRefStorageItem;
            frmReferenceDrag.ShowDialog();

            // display on the ref list
            if (frmReferenceDrag.IsSaved)
            {
                View_RefStorageItemDT view_RefStorageItem = new View_RefStorageItemDT();
                view_RefStorageItem.Query.AddWhereParameter(View_RefStorageItemDT.Parameters.MainStorageItemID, frmReferenceDrag.MainStorageItem.ID);
                view_RefStorageItem.Query.AddWhereParameter(View_RefStorageItemDT.Parameters.RefStorageItemID, frmReferenceDrag.RefStorageItem.ID);
                view_RefStorageItem.Query.Load();
                tvRef.AddNewNodeForView_ListStorageItem(view_RefStorageItem[0]);
                //tabControl.SelectedTab = tabPageReference;
                //DisplayReferenceView(lRefStorageItem);
                DisplayReferenceView(frmReferenceDrag.RefStorageItem);
            }
            dragToItem.SetColorToDefaultWithForGround();

        }

        int mLastX = 0;
        int mLastY = 0;
        ListViewStorageItem mLastItem = new ListViewStorageItem();

        private void lstStorageItem_DragOver(object sender, DragEventArgs e)
        {
            if (e.X == mLastX && e.Y == mLastY)
                return;

            mLastX = e.X;
            mLastY = e.Y;

            Point cp = lstStorageItem.PointToClient(new Point(e.X, e.Y));
            ListViewStorageItem dragToItem = (ListViewStorageItem)lstStorageItem.GetItemAt(cp.X, cp.Y);
            if (dragToItem == null)
            {
                return;
            }

            if (mLastItem != dragToItem)
            {
                mLastItem = dragToItem;
                lstStorageItem.HighlightItem(dragToItem);
            }
        }

        private void FrmMain_DragOver(object sender, DragEventArgs e)
        {
            lstStorageItem_DragOver(sender, e);
        }

        private void mnuItemOpenFolder_Click(object sender, EventArgs e)
        {
            if (lstStorageItem.SelectedItems.Count == 0)
                return;
            StorageItemRow storageItem = ((ListViewStorageItem)lstStorageItem.SelectedItems[0]).StorageItem;
            string itemFullPath = storageItem.FullPath;
            if (string.IsNullOrEmpty(itemFullPath))
                return;
            Process process = new Process();
            if (Directory.Exists(itemFullPath))
            {
                process.StartInfo.FileName = itemFullPath;
                //process.StartInfo.Arguments = "ProcessStart.cs";
                process.Start();
            }
            else
            {
                string theFullPath = Path.GetFullPath(itemFullPath);
                FileInfo fInfo = new FileInfo(theFullPath);
                string dirPath = fInfo.Directory.FullName;
                process.StartInfo.FileName = dirPath;
                process.Start();

            }
        }

        private void mnuItemFix_Click(object sender, EventArgs e)
        {
            if (lstStorageItem.SelectedItems.Count == 0)
                return;
            ListViewStorageItem listViewStorageItem = (ListViewStorageItem)lstStorageItem.SelectedItems[0];
            lstStorageItem.FixUnFixItemAt(listViewStorageItem.Index);
            DisplayTotalCount();

        }

        private void mnuItemRemoveNote_Click(object sender, EventArgs e)
        {
            if (lstStorageItem.SelectedItems.Count == 0)
                return;

            ListViewStorageItem listViewStorageItem = (ListViewStorageItem)lstStorageItem.SelectedItems[0];
            if (string.IsNullOrEmpty(listViewStorageItem.StorageItem.s_NoteItemID))
                return;

            NoteItemDT noteItem = new NoteItemDT();
            noteItem.LoadByPrimaryKey(listViewStorageItem.StorageItem.NoteItemID);
            if (File.Exists(noteItem[0].s_NoteFileName))
                File.Delete(noteItem[0].s_NoteFileName);
            noteItem[0].DeleteNoteItem();

            listViewStorageItem.StorageItem.s_NoteItemID = string.Empty;
            listViewStorageItem.StorageItem.Save();
            listViewStorageItem.DisplayStorageItem();

        }
        private void mnuItemOpenNote_Click(object sender, EventArgs e)
        {

            if (lstStorageItem.SelectedItems.Count == 0)
                return;
            ListViewStorageItem listViewStorageItem = (ListViewStorageItem)lstStorageItem.SelectedItems[0];
            if (!String.IsNullOrEmpty(listViewStorageItem.StorageItem.s_NoteItemID))
            {
                NoteItemDT noteItem = new NoteItemDT();
                noteItem.LoadByPrimaryKey(listViewStorageItem.StorageItem.NoteItemID);
                if (File.Exists(noteItem[0].NoteFileName))
                {
                    Process process = new Process();
                    process.StartInfo.FileName = noteItem[0].NoteFileName;
                    process.Start();

                }
                else
                {
                    Helper.ERRORMSG(noteItem[0].s_NoteFileName + " Is not found!");
                }
            }
            else // new Note
            {
                NoteItemRow noteItem = NoteItemDT.NewRowDefault();
                bool is_created = false;
                for (int i = 0; i < Int32.MaxValue; i++)
                {
                    string f_name = string.Format("{0}.{1}.txt",
                        listViewStorageItem.StorageItem.s_FullPath, i);
                    if (!File.Exists(f_name))
                    {
                        File.Create(f_name).Close();
                        noteItem.s_NoteFileName = f_name;
                        noteItem.Save();
                        listViewStorageItem.StorageItem.NoteItemID = noteItem.ID;
                        listViewStorageItem.StorageItem.Save();
                        listViewStorageItem.DisplayStorageItem();
                        //lstStorageItem.PutStorageItemInListViewItem(listViewStorageItem, listViewStorageItem.StorageItem);
                        //HandleAfterSave(listViewStorageItem.StorageItem);
                        Process process = new Process();
                        process.StartInfo.FileName = f_name;
                        process.Start();
                        is_created = true;
                        break;
                    }
                }
                if (!is_created) Helper.ERRORMSG("Can not create note..");
            }

        }

        private void mnuStripStorageItem_Opening(object sender, CancelEventArgs e)
        {
            HanleFixMenuItem();
            bool isEnabled = lstStorageItem.SelectedItems.Count > 0;
            foreach (ToolStripItem item in mnuStripStorageItem.Items)
            {
                if (mnuItemNewStorageItem != item)
                    item.Enabled = isEnabled;
            }
            // mnuItemNewStorageItem.Enabled = true;
            mnuItemPaste.Enabled = lstStorageItem.SelectedItems.Count > 0 &&
                                mStorageItemCopier.SourceList.Count != 0;
        }

        private void HanleFixMenuItem()
        {
            if (lstStorageItem.SelectedItems.Count == 0)
                return;
            ListViewStorageItem listViewStorageItem = (ListViewStorageItem)lstStorageItem.SelectedItems[0];

            if (listViewStorageItem.StorageItem.IsFixed)
                mnuItemFix.Text = "Remove From Fixed ";
            else
                mnuItemFix.Text = "Fix";
        }

        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            mnuFileExit_Click(sender, e);
        }

        private void chkAllowLstStorageMultiSelect_CheckedChanged(object sender, EventArgs e)
        {
            lstStorageItem.MultiSelect = chkAllowLstStorageMultiSelect.Checked;
        }

        private void chkSearchInAllCategories_CheckedChanged(object sender, EventArgs e)
        {
            DOSearch();
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            txtSearchDescription.Text = txtSearchDescription.Text.Replace(" ", "%");
            txtSearchDescription.Text = txtSearchDescription.Text.Replace("&", "%");
            txtSearchDescription.Text = txtSearchDescription.Text.Replace(Environment.NewLine, "%");
        }

        private void btnAmpersand_Click(object sender, EventArgs e)
        {
            txtSearchDescription.Text = txtSearchDescription.Text.Replace(" ", "&");
            txtSearchDescription.Text = txtSearchDescription.Text.Replace("%", "&");
            txtSearchDescription.Text = txtSearchDescription.Text.Replace(Environment.NewLine, "&");
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            txtSearchDescription.Text = Clipboard.GetText().Replace(Environment.NewLine, " ");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchDescription.Text = string.Empty;
            txtSearchDescription.Focus();
            txtSearchDescription.SelectAll();
        }

        private void btnSimilar_Click(object sender, EventArgs e)
        {
            string[] inputWords = similarStorageItem.GetSuitableDescriptionWords(txtSearchDescription.Text);
            //string txtToSearch = "%" + pSearchWord + "%";
            txtSearchDescription.Text = String.Join("&", inputWords);
            //StringBuilder sb = new StringBuilder();
            //foreach (string toSearchWordLoop in inputWords)
            // {
            //   sb.Append(toSearchWordLoop + "&");
            // }

            //txtSearchDescription.Text = sb.ToString();
        }
        private void btnPasteSimilar_Click(object sender, EventArgs e)
        {
            string[] inputWords = similarStorageItem.GetSuitableDescriptionWords(Clipboard.GetText());
            txtSearchDescription.Text = String.Join("&", inputWords);
            //System.Windows.
        }

        private void tvSimilarItems_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvSimilarItems.SelectedNode == null)
                return;
            if (tvSimilarItems.SelectedNode.Tag == null)
                return;
            if (tvSimilarItems.SelectedNode.Tag is StorageItemRow)
            {
                StorageItemRow selectedItem = (StorageItemRow)tvSimilarItems.SelectedNode.Tag;
                lstStorageItem.EnsureHasItem(selectedItem.ID, Color.Chartreuse, false, true);
            }
        }

        private void mnuItemCopy_Click(object sender, EventArgs e)
        {
            mStorageItemCopier.SourceList = lstStorageItem.SelectedListViewStorageItems;
        }

        private void mnuItemPaste_Click(object sender, EventArgs e)
        {
            mStorageItemCopier.TargetList = lstStorageItem.SelectedListViewStorageItems;

            foreach (ListViewStorageItem sourceItem in mStorageItemCopier.SourceList)
                foreach (ListViewStorageItem targetItem in mStorageItemCopier.TargetList)
                {
                    StorageItemRow lMainStorageItem = sourceItem.StorageItem;
                    StorageItemRow lRefStorageItem = targetItem.StorageItem;
                    FrmReferenceDrag frmReferenceDrag = new FrmReferenceDrag();
                    frmReferenceDrag.MainStorageItem = lMainStorageItem;
                    frmReferenceDrag.RefStorageItem = lRefStorageItem;
                    frmReferenceDrag.ShowDialog();

                    // display on the ref list
                    if (frmReferenceDrag.IsSaved)
                    {
                        //View_RefStorageItem view_RefStorageItem = new View_RefStorageItem();
                        // view_RefStorageItem.Where.MainStorageItemID.Value = frmReferenceDrag.MainStorageItem.ID;
                        //view_RefStorageItem.Where.RefStorageItemID.Value = frmReferenceDrag.RefStorageItem.ID;
                        //view_RefStorageItem.Query.Load();
                        //lstRef.Items.Add(GetListViewItemFromViewRrefStorageItem(view_RefStorageItem));
                        //DisplayReferenceView(frmReferenceDrag.RefStorageItem);
                    }

                }
        }
        private void mnuItemFileMove_Click(object sender, EventArgs e)
        {
            if (lstStorageItem.SelectedItems.Count == 0)
                return;
            FrmFileMove frmFileMove = new FrmFileMove();
            foreach (ListViewStorageItem listViewStorageItem in lstStorageItem.SelectedItems)
            {
                //StorageItemRow storageItem = (StorageItemRow)lstStorageItem.SelectedItems[0].Tag;
                StorageItemRow storageItem = listViewStorageItem.StorageItem;
                frmFileMove.StorageItem = storageItem;
                frmFileMove.ShowDialog(this);
                if (frmFileMove.IsOK)
                {
                    listViewStorageItem.DisplayStorageItem();
                }
            }
            frmFileMove.Dispose();
            frmFileMove = null;
        }

        private void mnuItemPutInQList_DropDownOpening(object sender, EventArgs e)
        {
            mnuItemPutInQList.DropDownItems.Clear();
            ToolStripMenuItem toolStripMenuItem;
            toolStripMenuItem = new ToolStripMenuItem("New Q List");
            toolStripMenuItem.Click += new EventHandler(toolStripMenuItemAddToNewQList_Click);
            mnuItemPutInQList.DropDownItems.Add(toolStripMenuItem);

            mnuItemPutInQList.DropDownItems.Add(new ToolStripSeparator());
            foreach (TreeViewQuickList treeViewQListLoop in mTreeViewQuickList_List)
            {
                toolStripMenuItem = new ToolStripMenuItem(treeViewQListLoop.QList.LName);
                toolStripMenuItem.Tag = treeViewQListLoop;
                toolStripMenuItem.Click += new EventHandler(toolStripMenuItemQList_Click);
                mnuItemPutInQList.DropDownItems.Add(toolStripMenuItem);
            }
        }

        private void toolStripMenuItemAddToNewQList_Click(object sender, EventArgs e)
        {
            QuickListRow quickList = QuickListDT.NewRowDefault();
            FrmQuickListEdit frmQuickListEdit = new UI.FrmQuickListEdit();
            frmQuickListEdit.quickListRow = quickList;
            frmQuickListEdit.ShowDialog(this);
            if (frmQuickListEdit.IsOK)
            {
                ListStorageItemDT listStorageItem = ListStorageItemDT.GetDefaultListStorageItemDT();

                foreach (ListViewStorageItem listViewStorageItem in lstStorageItem.SelectedItems)
                {
                    ListStorageItemRow listStorageItemRow = listStorageItem.NewListStorageItemRow();
                    listStorageItemRow.ListID = quickList.ID;
                    listStorageItemRow.StorageItemID = listViewStorageItem.StorageItem.ID;
                    listStorageItemRow.Save();


                }

                AddQuickList(quickList);
            }
        }

        private void toolStripMenuItemQList_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            TreeViewQuickList treeViewQList = toolStripMenuItem.Tag as TreeViewQuickList;
            QuickListRow quickList = treeViewQList.QList;

            ListStorageItemDT listStorageItem = new ListStorageItemDT();
            foreach (ListViewStorageItem listViewStorageItem in lstStorageItem.SelectedItems)
            {
                //listStorageItem = new ListStorageItem();
                listStorageItem.Query.ResetWhereParameters();
                listStorageItem.Query.AddWhereParameter(ListStorageItemDT.Parameters.ListID, quickList.ID);
                listStorageItem.Query.AddWhereParameter(ListStorageItemDT.Parameters.StorageItemID, listViewStorageItem.StorageItem.ID);
                if (listStorageItem.Query.Load())
                    Helper.ERRORMSG(String.Format("Entry '{0}' Already Exists In List '{1}' ! ", listViewStorageItem.StorageItem.ItemName, quickList.LName));
                else
                {
                    ListStorageItemRow listStorageItemRow = listStorageItem.NewListStorageItemRow();
                    listStorageItemRow.ListID = quickList.ID;
                    listStorageItemRow.StorageItemID = listViewStorageItem.StorageItem.ID;
                    listStorageItemRow.Save();
                    treeViewQList.AddNewItem(listStorageItemRow.StorageItemID);


                }

            }

        }

        private void mnuItemGenerateReport_Click(object sender, EventArgs e)
        {
            FrmGenerateReport frm = new FrmGenerateReport(lstStorageItem, reportStorageItemList);
            frm.ShowDialog();

        }

        private void ctrlTargetArea_LabelDoubleClick(object sender, EventArgs e)
        {
            HandleDragOnMainForm(ctrlTargetArea.GetFilesArray());
        }

        //private void mnuItemPutInGroup_DropDownOpening(object sender, EventArgs e)
        //{
        //    mnuItemPutInGroup.DropDownItems.Clear();
        //    ToolStripMenuItem toolStripMenuItem;
        //    toolStripMenuItem = new ToolStripMenuItem("New Group");
        //    toolStripMenuItem.Click += new EventHandler(toolStripMenuItemAddToNewGroup_Click);
        //    mnuItemPutInGroup.DropDownItems.Add(toolStripMenuItem);

        //    mnuItemPutInGroup.DropDownItems.Add(new ToolStripSeparator());
        //    foreach (ItemGroupRow itemGroupLoop in mItemGroupList.Rows)
        //    {

        //        toolStripMenuItem = new ToolStripMenuItem(itemGroupLoop.GroupName);
        //        toolStripMenuItem.Tag = itemGroupLoop;
        //        toolStripMenuItem.Click += new EventHandler(toolStripMenuItemGroupStorageItem_Click);
        //        mnuItemPutInGroup.DropDownItems.Add(toolStripMenuItem);
        //    }

        //}

        //private void toolStripMenuItemAddToNewGroup_Click(object sender, EventArgs e)
        //{
        //    FrmInputBox frm = new FrmInputBox();

        //    frm.ShowInputMsg("New Group", "Please Enter Group Name:");
        //    //frm.ShowInTaskbar = false;
        //    //frm.FormBorderStyle = FormBorderStyle.FixedDialog;

        //    frm.ShowDialog();
        //    if (frm.IsOK)
        //    {
        //        ItemGroupRow itemGroup = mItemGroupList.NewItemGroupRow();
        //        //itemGroup.AddNew();
        //        itemGroup.GroupName = frm.InputValue;
        //        itemGroup.Save();

        //        //LoadItemGroupList();



        //        foreach (ListViewStorageItem listViewStorageItem in lstStorageItem.SelectedItems)
        //        {
        //            GroupStorageItemRow groupStorageItem = GroupStorageItemDT.NewRowDefault();
        //            //groupStorageItem.AddNew();
        //            groupStorageItem.GroupID = itemGroup.ID;
        //            groupStorageItem.StorageItemID = listViewStorageItem.StorageItem.ID;
        //            groupStorageItem.Save();


        //        }

        //        //AddGroup(itemGroup);

        //    }

        //}

        //private void AddGroup(ItemGroupRow pItemGroup)
        //{
        //   // mItemGroupList.Rows.Add(pItemGroup);
        //}


        //private void toolStripMenuItemGroupStorageItem_Click(object sender, EventArgs e)
        //{
        //    ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
        //    ItemGroupRow itemGroup = toolStripMenuItem.Tag as ItemGroupRow;
        //    GroupStorageItemDT groupStorageItem;

        //    foreach (ListViewStorageItem listViewStorageItem in lstStorageItem.SelectedItems)
        //    {
        //        groupStorageItem = new GroupStorageItemDT();
        //        groupStorageItem.Query.AddWhereParameter(GroupStorageItemDT.Parameters.GroupID, itemGroup.ID);
        //        groupStorageItem.Query.AddWhereParameter(GroupStorageItemDT.Parameters.StorageItemID, listViewStorageItem.StorageItem.ID);
        //        if (groupStorageItem.Query.Load())
        //            Helper.MSG(String.Format("Item '{0}' Already Exists In Group'{1}' ! ", listViewStorageItem.StorageItem.ItemName, itemGroup.GroupName));
        //        else
        //        {
        //            GroupStorageItemRow groupStorageItemRow = groupStorageItem.NewGroupStorageItemRow();
        //            groupStorageItemRow.GroupID = itemGroup.ID;
        //            groupStorageItemRow.StorageItemID = listViewStorageItem.StorageItem.ID;
        //            groupStorageItemRow.Save();
        //            //treeViewQList.AddNewItem(groupStorageItem.StorageItemID);

        //        }

        //    }

        //}

        private void mnuItemCustomReport_Click(object sender, EventArgs e)
        {
            FrmCustomReport frm = new FrmCustomReport(lstStorageItem);
            frm.ShowDialog();
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void mnuItemRefreshQuickLists_Click(object sender, EventArgs e)
        {
            foreach (TreeViewQuickList treeViewQListLoop in mTreeViewQuickList_List)
            {
                treeViewQListLoop.LoadQuickList(null);
            }
        }

        private void tsbNewStorageItem_Click(object sender, EventArgs e)
        {
            mnuItemNewStorageItem_Click(sender, e);
        }

        private void tsbOpenStorageItem_Click(object sender, EventArgs e)
        {
            mnuItemOpenStorageItem_Click(sender, e);
        }

        private void tsbEditStorageItem_Click(object sender, EventArgs e)
        {
            mnuItemEditStorageItem_Click(sender, e);
        }

        private void tsbCategories_Click(object sender, EventArgs e)
        {
            tabControl.SelectedItem = tabPageCategory;
        }

        private void cmbTopN_SelectedIndexChanged(object sender, EventArgs e)
        {
            DOSearch();
        }

        private void cmbSortType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DOSearch();
        }

        private void mnuItemOptions_Click(object sender, EventArgs e)
        {
            FrmOptions frmOptions = new FrmOptions();
            frmOptions.ShowDialog();
            IniStorageItem iniStorageItem = new IniStorageItem(this);
            iniStorageItem.Save();
            //Options.FreeInstance();
            //System.GC.Collect();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            ChangBackGroundColorForTextBox(txtFilter);
            DOSearch();
        }
        #region Filter Operations
        private void FilterResults(StorageItemDT pStorageItemList)
        {
            if (txtFilter.Text == String.Empty)
                return;
            //List<StorageItem> newResult = new List<StorageItem>();
            mFilteredItemsCount = 0;
            string[] filterList = txtFilter.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = pStorageItemList.Rows.Count - 1; i >= 0; i--)
            //foreach (StorageItemRow storageItem in pStorageItemList)
            {
                if (ContainFilterWord(pStorageItemList[i], filterList))
                {
                    mFilteredItemsCount++;
                    pStorageItemList.Rows.RemoveAt(i);
                }
                //else
                //    newResult.Add(storageItem);

            }

            //return newResult;


        }

        private bool ContainFilterWord(StorageItemRow pStorageItem, string[] pFilterList)
        {
            foreach (string filterWord in pFilterList)
            {
                if (pStorageItem.Description.ToUpper().Contains(filterWord.ToUpper()))
                    return true;
            }

            return false;
        }

        #endregion

        private void mnuItemReomveStorageItem_Click(object sender, EventArgs e)
        {
            if (lstStorageItem.SelectedItems.Count == 0)
                return;
            lstStorageItem.SuspendLayout();
            ListView.SelectedListViewItemCollection selectedItems = lstStorageItem.SelectedItems;
            foreach (ListViewItem itemLoop in selectedItems)
            {
                //StorageItem storageItem = (StorageItem)itemLoop.Tag;
                lstStorageItem.Items.Remove(itemLoop);
            }
            lstStorageItem.ResumeLayout(true);

        }

        private void mnuItemAddToReport_Click(object sender, EventArgs e)
        {
            if (lstStorageItem.SelectedItems.Count == 0)
                return;
            ListView.SelectedListViewItemCollection selectedItems = lstStorageItem.SelectedItems;
            foreach (ListViewItem itemLoop in selectedItems)
            {
                StorageItemRow storageItem = (StorageItemRow)itemLoop.Tag;
                reportStorageItemList.Add(storageItem);
            }

            lblReportListCount.Text = reportStorageItemList.Count.ToString();
        }

        private void btnEmptyList_Click(object sender, EventArgs e)
        {
            lstStorageItem.Items.Clear();
        }

        private void tabControl_TabStripItemSelectionChanged(TabStripItemChangedEventArgs e)
        {
            if (e.ChangeType == FATabStripItemChangeTypes.SelectionChanged)
            {
                if (e.Item == tabPageReference)
                {
                    if (!tvRef.IsLoaded)
                        if (mMainStorageItem != null)
                            tvRef.DisplayRefForMainStorage(mMainStorageItem.ID);

                }
                else
                {
                    TreeViewQuickList treeViewQuickList = e.Item.Tag as TreeViewQuickList;
                    if (treeViewQuickList == null)
                        return;

                    if (!treeViewQuickList.IsQuickListLoaded)
                        treeViewQuickList.LoadQuickList(null);
                }
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.Normal;
            this.Show();
            notifyIcon.Visible = false;
        }

        private void tsbMinimizeToTray_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            //if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            //{
            //    SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            //}
            System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.Idle;
            notifyIcon.Visible = true;
            this.Hide();
        }

        private void chkShowHint_CheckedChanged(object sender, EventArgs e)
        {
            lstStorageItem.ShowItemToolTips = chkShowHint.Checked;
        }
        private void mnuItemOpenQuickList_Click(object sender, EventArgs e)
        {
            ((TreeViewQuickList)((ToolStripMenuItem)sender).Owner.Tag).OpenSelectedNode();
        }
        private void mnuItemLocateQuickList_Click(object sender, EventArgs e)
        {
            ((TreeViewQuickList)((ToolStripMenuItem)sender).Owner.Tag).LocateSelectedNode();
        }

        private void mnuItemLocateAll_Click(object sender, EventArgs e)
        {
            ((TreeViewQuickList)((ToolStripMenuItem)sender).Owner.Tag).LocateAllNodes();
        }

        private void mnuItemRemoveQuikList_Click(object sender, EventArgs e)
        {
            ((TreeViewQuickList)((ToolStripMenuItem)sender).Owner.Tag).RemoveSelectedNode();
        }

        private void mnuItemRefresh_Click(object sender, EventArgs e)
        {
            ((TreeViewQuickList)((ToolStripMenuItem)sender).Owner.Tag).LoadQuickList(null);
        }

        private void mnuItemColor_Click(object sender, EventArgs e)
        {
            if (((TreeViewQuickList)((ToolStripMenuItem)sender).Owner.Tag).SelectedNode == null)
                return;

            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = ((TreeViewQuickList)((ToolStripMenuItem)sender).Owner.Tag).GetSelectedNodeColor();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    ((TreeViewQuickList)((ToolStripMenuItem)sender).Owner.Tag).SetSelectedNodeColor(colorDialog.Color);
                }
            }

        }

        private void mnuItemUnload_Click(object sender, EventArgs e)
        {
            ((TreeViewQuickList)((ToolStripMenuItem)sender).Owner.Tag).UnLoad();
        }
        private void mnuItemSortByDescription_Click(object sender, EventArgs e)
        {
            ((TreeViewQuickList)((ToolStripMenuItem)sender).Owner.Tag).SortByDescription();
        }

        private void mnuItemSortByFileName_Click(object sender, EventArgs e)
        {
            ((TreeViewQuickList)((ToolStripMenuItem)sender).Owner.Tag).SortByFileName();
        }

        private void mnuItemSortByOrderOfAddition_Click(object sender, EventArgs e)
        {
            ((TreeViewQuickList)((ToolStripMenuItem)sender).Owner.Tag).SortByOrderOfAddition();
        }

        private void mnuNewWindow_Click(object sender, EventArgs e)
        {
            FrmMain frmMain = new FrmMain();
            frmMain.IsMainWindow = false;
            frmMain.Show();
        }

        private void mnuItemEditWorkSpace_Click(object sender, EventArgs e)
        {
            if (tvWorkSpace.SelectedNode != null)
            {
                WorkSpaceRow workSpaceRow = tvWorkSpace.SelectedNode.Tag as WorkSpaceRow;
                FrmNewWorkSpace frm = new FrmNewWorkSpace();
                frm.WorkSpace = workSpaceRow;
                //frm.WorkSpace.AddNew();
                frm.ShowInTaskbar = false;
                frm.FormBorderStyle = FormBorderStyle.FixedDialog;

                frm.ShowDialog();
                if (frm.IsOK)
                {
                    //mWorkSpaceList.Rows.Add(frm.WorkSpace);
                    //tvWorkSpace.AddNewNodeForWorkSpace(frm.WorkSpace);
                    tvWorkSpace.SelectedNode.Text = frm.WorkSpace.s_WName;
                    tvWorkSpace.SelectedNode.Checked = frm.WorkSpace.IsActive;


                }
            }
        }

        private void mnuItemDeleteWorkspace_Click(object sender, EventArgs e)
        {
            if (tvWorkSpace.SelectedNode != null)
            {
                WorkSpaceRow workSpaceRow = tvWorkSpace.SelectedNode.Tag as WorkSpaceRow;
                DialogResult result = MessageBox.Show(string.Format("Do you want to delete the selected workspace '{0}'?" +
                    Environment.NewLine + Environment.NewLine +
                    "All Items in this Workspace will be deleted.", workSpaceRow.s_WName), "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    workSpaceRow.DeleteWorkSpace();
                    tvWorkSpace.Nodes.Remove(tvWorkSpace.SelectedNode);
                    DOSearch();
                }
            }
        }

        private void tvWorkSpace_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mnuStripWorkSpace.Enabled = true;
                //mnuStripWorkSpace.Tag = this;
                // Point where the mouse is clicked.
                Point p = new Point(e.X, e.Y);

                // Get the node that the user has clicked.
                TreeNode node = tvWorkSpace.GetNodeAt(p);
                if (node != null)
                {
                    tvWorkSpace.SelectedNode = node;
                    mnuStripWorkSpace.Show(tvWorkSpace, p);

                }
                else
                {
                    if (tvWorkSpace.Nodes.Count > 0)
                    {

                        TreeNode lastNode = tvWorkSpace.Nodes[tvWorkSpace.Nodes.Count - 1];
                        tvWorkSpace.SelectedNode = lastNode;
                        mnuStripWorkSpace.Show(this, lastNode.Bounds.Location);
                    }
                    else
                    {
                        //TheContextMenuStrip.Enabled = false;
                        mnuStripWorkSpace.Show(tvWorkSpace, p);
                    }

                }
            }
        }

        private void mnuStripWorkSpace_Opening(object sender, CancelEventArgs e)
        {
            mnuItemEditWorkSpace.Enabled = (tvWorkSpace.SelectedNode != null);
            mnuItemDeleteWorkspace.Enabled = (tvWorkSpace.SelectedNode != null);
        }

        private void mnuItemEditQListInfo_Click(object sender, EventArgs e)
        {
            TreeViewQuickList tv = (TreeViewQuickList)((ToolStripMenuItem)sender).Owner.Tag;
            FrmQuickListEdit frmQuickListEdit = new UI.FrmQuickListEdit();
            frmQuickListEdit.quickListRow = tv.QList;
            frmQuickListEdit.ShowDialog(this);
            if (frmQuickListEdit.IsOK)
            {
                FATabStripItem fATabStripItem = (FATabStripItem)tv.Parent;
                fATabStripItem.Title = tv.QList.s_LName;
                if (tv.QList.IsInToolBar)
                {
                    if (tv.QList.ToolStripButton == null)
                        AddQuickList(tv.QList);
                    else
                        tv.QList.ToolStripButton.Text = tv.QList.s_LName;
                }
                else
                {
                    if (tv.QList.ToolStripButton != null)
                    {
                        toolStripMain.Items.Remove(tv.QList.ToolStripButton);
                        tv.QList.ToolStripButton = null;
                    }
                }
            }

        }

        private void mnuItemDeleteQList_Click(object sender, EventArgs e)
        {
            TreeViewQuickList tv = (TreeViewQuickList)((ToolStripMenuItem)sender).Owner.Tag;
            FATabStripItem fATabStripItem = (FATabStripItem)tv.Parent;
            DialogResult result = MessageBox.Show(string.Format("Do you want to delete Q List '{0}'?", tv.QList.s_LName), "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bool isInToolbar = tv.QList.IsInToolBar;
                tv.QList.DeleteQuickList();
                mTreeViewQuickList_List.Remove(tv);
                if (isInToolbar && tv.QList.ToolStripButton != null)
                {
                    toolStripMain.Items.Remove(tv.QList.ToolStripButton);
                }
                tabControl.Items.Remove(fATabStripItem);
                //mQuickList.Rows.Remove(tv.QList);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.ShowInTaskbar = false;
            frmAbout.ShowDialog(this);
        }

        private void muuItemNote_DropDownOpening(object sender, EventArgs e)
        {
            mnuItemOpenNote.Enabled = lstStorageItem.SelectedItems.Count > 0;
            mnuItemRemoveNote.Enabled = lstStorageItem.SelectedItems.Count > 0 &&
              !string.IsNullOrEmpty(((StorageItemRow)lstStorageItem.SelectedItems[0].Tag).s_NoteItemID);
        }

        private void mnuItemCheckForUpdate_Click(object sender, EventArgs e)
        {
            string url = "https://raw.githubusercontent.com/houssam11350/FileOrganizer/master/currentVersion";
            WebClient client = new WebClient();
            string downloadString = client.DownloadString(url);
            string[] arr = downloadString.Split(new char[] { '.' });
            if (arr.Length != 4)
                throw new Exception("Invalid reply from the server:" + downloadString);
            int[] int_arr = new int[] { int.Parse(arr[0]), int.Parse(arr[1]) ,
                                        int.Parse(arr[2]) , int.Parse(arr[3])};

            string[] curr = FrmMain.CurrentVersion.Split(new char[] { '.' });
            int[] curr_arr = new int[] { int.Parse(curr[0]), int.Parse(curr[1]) ,
                                        int.Parse(curr[2]) , int.Parse(curr[3])};

            bool isUpToDate = true;
            for (int i = curr_arr.Length - 1; i >= 0; i--)
            {
                if (curr_arr[i] < int_arr[i])
                {
                    Helper.OKMSG(string.Format(
                      "Your Version: {0}. {1} Server Version: {2} {1} Please download last version from: https://github.com/houssam11350/FileOrganizer",
                      FrmMain.CurrentVersion, Environment.NewLine, downloadString));
                    isUpToDate = false;
                    string browserPath = Helper.GetStandardBrowserPath();
                    if (!string.IsNullOrEmpty(browserPath))
                    {
                        Process.Start(browserPath, "https://github.com/houssam11350/FileOrganizer");
                    }

                    break;

                }

            }
            if (isUpToDate)
                Helper.OKMSG(string.Format(
                     "Your Version: {0}. {1} Server Version: {2} {1} You are uptodate.",
                     FrmMain.CurrentVersion, Environment.NewLine, downloadString));



        }

    }
}

