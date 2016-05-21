using System.Windows.Forms;

namespace FileOrganizer.UI
{
    partial class FrmMain : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.mnuStripWorkSpace = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newWorkSpaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemEditWorkSpace = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemDeleteWorkspace = new System.Windows.Forms.ToolStripMenuItem();
            this.imgListForTVWorkSpace = new System.Windows.Forms.ImageList(this.components);
            this.mnuStripStorageItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemOpenStorageItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemOpenCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemNewStorageItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemEditStorageItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemDeleteStorageItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemReomveStorageItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemSetAsMainStorageItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemSetAsReference = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemBrowseHostName = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemBrowseURL = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemWindowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemPutInQList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemFileMove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.muuItemNote = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemOpenNote = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemRemoveNote = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemAddToReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStripRef = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemOpenRef = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemRemoveRef = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemWindowsMenuRef = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemGenerateReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemCustomReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemRefreshQuickLists = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemCheckForUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.tsbCategories = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.statMain = new System.Windows.Forms.StatusStrip();
            this.sslFitered = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslLine = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslColumn = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslInsert = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslOther = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tabControl = new FarsiLibrary.Win.FATabStrip();
            this.tabPageCategory = new FarsiLibrary.Win.FATabStripItem();
            this.splitContainerTree = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkSearchInAllCategories = new System.Windows.Forms.CheckBox();
            this.splitContainerReferenceTree = new System.Windows.Forms.SplitContainer();
            this.txtMainStorageItemDesc = new System.Windows.Forms.TextBox();
            this.splitContainerSiteGroup = new System.Windows.Forms.SplitContainer();
            this.tvOneSiteGroup = new System.Windows.Forms.TreeView();
            this.splitContainerSimilarItems = new System.Windows.Forms.SplitContainer();
            this.tvRefView = new System.Windows.Forms.TreeView();
            this.splitContainerGroupStorage = new System.Windows.Forms.SplitContainer();
            this.tvSimilarItems = new System.Windows.Forms.TreeView();
            this.tabPageReference = new FarsiLibrary.Win.FATabStripItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtMainDesc = new System.Windows.Forms.TextBox();
            this.txtMainFullPath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPageGroupSite = new FarsiLibrary.Win.FATabStripItem();
            this.tvSiteGroup = new System.Windows.Forms.TreeView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BtnGroupBySite = new System.Windows.Forms.Button();
            this.splitContainerStorageItem = new System.Windows.Forms.SplitContainer();
            this.chkShowHint = new System.Windows.Forms.CheckBox();
            this.txtMainStorageItemDesc2 = new System.Windows.Forms.TextBox();
            this.btnEmptyList = new System.Windows.Forms.Button();
            this.lblReportListCount = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbSortType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbTopN = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnPasteSimilar = new System.Windows.Forms.Button();
            this.btnSimilar = new System.Windows.Forms.Button();
            this.btnAmpersand = new System.Windows.Forms.Button();
            this.btnPercent = new System.Windows.Forms.Button();
            this.chkAllowLstStorageMultiSelect = new System.Windows.Forms.CheckBox();
            this.cmbPriorityOperand = new System.Windows.Forms.ComboBox();
            this.cmbOrder = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.upDownPriority = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnuStripQuickList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemOpenQuickList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemLocateQuickList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemLocateAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemRemoveQuikList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator24 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemColor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemUnload = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator25 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemSortByDescription = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemSortByFileName = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemSortByOrderOfAddition = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator26 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemEditQListInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemDeleteQList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tvWorkSpace = new FileOrganizer.UI.TreeViewWorkSpace();
            this.treeViewAllQuickList = new FileOrganizer.UI.TreeViewAllQuickList();
            this.tvRef = new FileOrganizer.UI.TreeViewRef();
            this.ctrlReferenceNavigator = new FileOrganizer.UI.CtrlReferenceNavigator();
            this.txtFilter = new FileOrganizer.UI.MyTextBox(this.components);
            this.btnSearchContent = new FileOrganizer.CTRL.VistaButton();
            this.ctrlSearchContentProgress = new FileOrganizer.UI.CtrlSearchContentProgress();
            this.txtSearchContent = new FileOrganizer.UI.MyTextBox(this.components);
            this.txtSearchReferencesBib = new FileOrganizer.UI.MyTextBox(this.components);
            this.txtSearchImportantParts = new FileOrganizer.UI.MyTextBox(this.components);
            this.txtSearchCitation = new FileOrganizer.UI.MyTextBox(this.components);
            this.txtSearchFileName = new FileOrganizer.UI.MyTextBox(this.components);
            this.txtSearchURL = new FileOrganizer.UI.MyTextBox(this.components);
            this.txtSearchDescription = new FileOrganizer.UI.MyTextBox(this.components);
            this.ctrlTargetArea = new FileOrganizer.UI.CtrlTargetArea();
            this.lstStorageItem = new FileOrganizer.UI.ListViewStorage();
            this.colURL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFullPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coPriority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPagesCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNodeItemID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCitation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReferencesBib = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colImportantParts = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAdditionDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDoSearch = new System.Windows.Forms.Button();
            this.mnuStripWorkSpace.SuspendLayout();
            this.mnuStripStorageItem.SuspendLayout();
            this.mnuStripRef.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.statMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTree)).BeginInit();
            this.splitContainerTree.Panel1.SuspendLayout();
            this.splitContainerTree.Panel2.SuspendLayout();
            this.splitContainerTree.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerReferenceTree)).BeginInit();
            this.splitContainerReferenceTree.Panel1.SuspendLayout();
            this.splitContainerReferenceTree.Panel2.SuspendLayout();
            this.splitContainerReferenceTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSiteGroup)).BeginInit();
            this.splitContainerSiteGroup.Panel1.SuspendLayout();
            this.splitContainerSiteGroup.Panel2.SuspendLayout();
            this.splitContainerSiteGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSimilarItems)).BeginInit();
            this.splitContainerSimilarItems.Panel1.SuspendLayout();
            this.splitContainerSimilarItems.Panel2.SuspendLayout();
            this.splitContainerSimilarItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerGroupStorage)).BeginInit();
            this.splitContainerGroupStorage.Panel1.SuspendLayout();
            this.splitContainerGroupStorage.Panel2.SuspendLayout();
            this.splitContainerGroupStorage.SuspendLayout();
            this.tabPageReference.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPageGroupSite.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerStorageItem)).BeginInit();
            this.splitContainerStorageItem.Panel1.SuspendLayout();
            this.splitContainerStorageItem.Panel2.SuspendLayout();
            this.splitContainerStorageItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownPriority)).BeginInit();
            this.mnuStripQuickList.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuStripWorkSpace
            // 
            this.mnuStripWorkSpace.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.mnuStripWorkSpace.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mnuStripWorkSpace.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWorkSpaceToolStripMenuItem,
            this.mnuItemEditWorkSpace,
            this.mnuItemDeleteWorkspace});
            this.mnuStripWorkSpace.Name = "mnuStripWorkSpace";
            this.mnuStripWorkSpace.Size = new System.Drawing.Size(163, 70);
            this.mnuStripWorkSpace.Opening += new System.ComponentModel.CancelEventHandler(this.mnuStripWorkSpace_Opening);
            // 
            // newWorkSpaceToolStripMenuItem
            // 
            this.newWorkSpaceToolStripMenuItem.Name = "newWorkSpaceToolStripMenuItem";
            this.newWorkSpaceToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.newWorkSpaceToolStripMenuItem.Text = "New WorkSpace";
            this.newWorkSpaceToolStripMenuItem.Click += new System.EventHandler(this.newWorkSpaceToolStripMenuItem_Click);
            // 
            // mnuItemEditWorkSpace
            // 
            this.mnuItemEditWorkSpace.Name = "mnuItemEditWorkSpace";
            this.mnuItemEditWorkSpace.Size = new System.Drawing.Size(162, 22);
            this.mnuItemEditWorkSpace.Text = "Edit WorkSpace";
            this.mnuItemEditWorkSpace.Click += new System.EventHandler(this.mnuItemEditWorkSpace_Click);
            // 
            // mnuItemDeleteWorkspace
            // 
            this.mnuItemDeleteWorkspace.Name = "mnuItemDeleteWorkspace";
            this.mnuItemDeleteWorkspace.Size = new System.Drawing.Size(162, 22);
            this.mnuItemDeleteWorkspace.Text = "Delete WorkSpace";
            this.mnuItemDeleteWorkspace.Click += new System.EventHandler(this.mnuItemDeleteWorkspace_Click);
            // 
            // imgListForTVWorkSpace
            // 
            this.imgListForTVWorkSpace.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListForTVWorkSpace.ImageStream")));
            this.imgListForTVWorkSpace.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListForTVWorkSpace.Images.SetKeyName(0, "Folder.bmp");
            this.imgListForTVWorkSpace.Images.SetKeyName(1, "FolderClosed.bmp");
            this.imgListForTVWorkSpace.Images.SetKeyName(2, "Item.bmp");
            // 
            // mnuStripStorageItem
            // 
            this.mnuStripStorageItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemOpenStorageItem,
            this.mnuItemOpenCopy,
            this.mnuItemOpenFolder,
            this.toolStripSeparator4,
            this.mnuItemNewStorageItem,
            this.mnuItemEditStorageItem,
            this.mnuItemDeleteStorageItem,
            this.mnuItemReomveStorageItem,
            this.toolStripSeparator1,
            this.mnuItemSetAsMainStorageItem,
            this.mnuItemSetAsReference,
            this.toolStripSeparator3,
            this.mnuItemBrowseHostName,
            this.mnuItemBrowseURL,
            this.toolStripSeparator5,
            this.mnuItemWindowsMenu,
            this.toolStripSeparator18,
            this.mnuItemPutInQList,
            this.toolStripSeparator20,
            this.mnuItemCopy,
            this.mnuItemPaste,
            this.mnuItemFileMove,
            this.toolStripSeparator19,
            this.muuItemNote,
            this.toolStripSeparator23,
            this.mnuItemAddToReport});
            this.mnuStripStorageItem.Name = "mnuStripStorageItem";
            this.mnuStripStorageItem.Size = new System.Drawing.Size(207, 448);
            this.mnuStripStorageItem.Opening += new System.ComponentModel.CancelEventHandler(this.mnuStripStorageItem_Opening);
            // 
            // mnuItemOpenStorageItem
            // 
            this.mnuItemOpenStorageItem.Name = "mnuItemOpenStorageItem";
            this.mnuItemOpenStorageItem.Size = new System.Drawing.Size(206, 22);
            this.mnuItemOpenStorageItem.Text = "Open";
            this.mnuItemOpenStorageItem.Click += new System.EventHandler(this.mnuItemOpenStorageItem_Click);
            // 
            // mnuItemOpenCopy
            // 
            this.mnuItemOpenCopy.Name = "mnuItemOpenCopy";
            this.mnuItemOpenCopy.Size = new System.Drawing.Size(206, 22);
            this.mnuItemOpenCopy.Text = "Open Copy";
            this.mnuItemOpenCopy.Click += new System.EventHandler(this.mnuItemOpenCopy_Click);
            // 
            // mnuItemOpenFolder
            // 
            this.mnuItemOpenFolder.Name = "mnuItemOpenFolder";
            this.mnuItemOpenFolder.Size = new System.Drawing.Size(206, 22);
            this.mnuItemOpenFolder.Text = "Open Folder";
            this.mnuItemOpenFolder.Click += new System.EventHandler(this.mnuItemOpenFolder_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(203, 6);
            // 
            // mnuItemNewStorageItem
            // 
            this.mnuItemNewStorageItem.Name = "mnuItemNewStorageItem";
            this.mnuItemNewStorageItem.Size = new System.Drawing.Size(206, 22);
            this.mnuItemNewStorageItem.Text = "New";
            this.mnuItemNewStorageItem.Click += new System.EventHandler(this.mnuItemNewStorageItem_Click);
            // 
            // mnuItemEditStorageItem
            // 
            this.mnuItemEditStorageItem.Name = "mnuItemEditStorageItem";
            this.mnuItemEditStorageItem.Size = new System.Drawing.Size(206, 22);
            this.mnuItemEditStorageItem.Text = "Edit";
            this.mnuItemEditStorageItem.Click += new System.EventHandler(this.mnuItemEditStorageItem_Click);
            // 
            // mnuItemDeleteStorageItem
            // 
            this.mnuItemDeleteStorageItem.Name = "mnuItemDeleteStorageItem";
            this.mnuItemDeleteStorageItem.Size = new System.Drawing.Size(206, 22);
            this.mnuItemDeleteStorageItem.Text = "Delete";
            this.mnuItemDeleteStorageItem.Click += new System.EventHandler(this.mnuItemDeleteStorageItem_Click);
            // 
            // mnuItemReomveStorageItem
            // 
            this.mnuItemReomveStorageItem.Name = "mnuItemReomveStorageItem";
            this.mnuItemReomveStorageItem.Size = new System.Drawing.Size(206, 22);
            this.mnuItemReomveStorageItem.Text = "Remove";
            this.mnuItemReomveStorageItem.Click += new System.EventHandler(this.mnuItemReomveStorageItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(203, 6);
            // 
            // mnuItemSetAsMainStorageItem
            // 
            this.mnuItemSetAsMainStorageItem.Name = "mnuItemSetAsMainStorageItem";
            this.mnuItemSetAsMainStorageItem.Size = new System.Drawing.Size(206, 22);
            this.mnuItemSetAsMainStorageItem.Text = "Set As Main Storage Item";
            this.mnuItemSetAsMainStorageItem.Click += new System.EventHandler(this.mnuItemSetAsMainStorageItem_Click);
            // 
            // mnuItemSetAsReference
            // 
            this.mnuItemSetAsReference.Name = "mnuItemSetAsReference";
            this.mnuItemSetAsReference.Size = new System.Drawing.Size(206, 22);
            this.mnuItemSetAsReference.Text = "Set As Reference";
            this.mnuItemSetAsReference.Click += new System.EventHandler(this.mnuItemSetAsReference_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(203, 6);
            // 
            // mnuItemBrowseHostName
            // 
            this.mnuItemBrowseHostName.Name = "mnuItemBrowseHostName";
            this.mnuItemBrowseHostName.Size = new System.Drawing.Size(206, 22);
            this.mnuItemBrowseHostName.Text = "Browse Host";
            this.mnuItemBrowseHostName.Click += new System.EventHandler(this.mnuItemBrowseHostName_Click);
            // 
            // mnuItemBrowseURL
            // 
            this.mnuItemBrowseURL.Name = "mnuItemBrowseURL";
            this.mnuItemBrowseURL.Size = new System.Drawing.Size(206, 22);
            this.mnuItemBrowseURL.Text = "Browse URL Directory";
            this.mnuItemBrowseURL.Click += new System.EventHandler(this.mnuItemBrowseURL_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(203, 6);
            // 
            // mnuItemWindowsMenu
            // 
            this.mnuItemWindowsMenu.Name = "mnuItemWindowsMenu";
            this.mnuItemWindowsMenu.Size = new System.Drawing.Size(206, 22);
            this.mnuItemWindowsMenu.Text = "Windows Menu";
            this.mnuItemWindowsMenu.DropDownOpening += new System.EventHandler(this.mnuItemWindowsMenu_DropDownOpening);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(203, 6);
            // 
            // mnuItemPutInQList
            // 
            this.mnuItemPutInQList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator21});
            this.mnuItemPutInQList.Name = "mnuItemPutInQList";
            this.mnuItemPutInQList.Size = new System.Drawing.Size(206, 22);
            this.mnuItemPutInQList.Text = "Put In List";
            this.mnuItemPutInQList.DropDownOpening += new System.EventHandler(this.mnuItemPutInQList_DropDownOpening);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(57, 6);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(203, 6);
            // 
            // mnuItemCopy
            // 
            this.mnuItemCopy.Name = "mnuItemCopy";
            this.mnuItemCopy.Size = new System.Drawing.Size(206, 22);
            this.mnuItemCopy.Text = "Copy As Reference";
            this.mnuItemCopy.Click += new System.EventHandler(this.mnuItemCopy_Click);
            // 
            // mnuItemPaste
            // 
            this.mnuItemPaste.Name = "mnuItemPaste";
            this.mnuItemPaste.Size = new System.Drawing.Size(206, 22);
            this.mnuItemPaste.Text = "Paste As Reference";
            this.mnuItemPaste.Click += new System.EventHandler(this.mnuItemPaste_Click);
            // 
            // mnuItemFileMove
            // 
            this.mnuItemFileMove.Name = "mnuItemFileMove";
            this.mnuItemFileMove.Size = new System.Drawing.Size(206, 22);
            this.mnuItemFileMove.Text = "File Move";
            this.mnuItemFileMove.Click += new System.EventHandler(this.mnuItemFileMove_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(203, 6);
            // 
            // muuItemNote
            // 
            this.muuItemNote.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemOpenNote,
            this.mnuItemRemoveNote});
            this.muuItemNote.Name = "muuItemNote";
            this.muuItemNote.Size = new System.Drawing.Size(206, 22);
            this.muuItemNote.Text = "Note";
            this.muuItemNote.DropDownOpening += new System.EventHandler(this.muuItemNote_DropDownOpening);
            // 
            // mnuItemOpenNote
            // 
            this.mnuItemOpenNote.Name = "mnuItemOpenNote";
            this.mnuItemOpenNote.Size = new System.Drawing.Size(146, 22);
            this.mnuItemOpenNote.Text = "Open Note";
            this.mnuItemOpenNote.Click += new System.EventHandler(this.mnuItemOpenNote_Click);
            // 
            // mnuItemRemoveNote
            // 
            this.mnuItemRemoveNote.Name = "mnuItemRemoveNote";
            this.mnuItemRemoveNote.Size = new System.Drawing.Size(146, 22);
            this.mnuItemRemoveNote.Text = "Remove Note";
            this.mnuItemRemoveNote.Click += new System.EventHandler(this.mnuItemRemoveNote_Click);
            // 
            // toolStripSeparator23
            // 
            this.toolStripSeparator23.Name = "toolStripSeparator23";
            this.toolStripSeparator23.Size = new System.Drawing.Size(203, 6);
            // 
            // mnuItemAddToReport
            // 
            this.mnuItemAddToReport.Name = "mnuItemAddToReport";
            this.mnuItemAddToReport.Size = new System.Drawing.Size(206, 22);
            this.mnuItemAddToReport.Text = "Add To Report";
            this.mnuItemAddToReport.Visible = false;
            this.mnuItemAddToReport.Click += new System.EventHandler(this.mnuItemAddToReport_Click);
            // 
            // mnuStripRef
            // 
            this.mnuStripRef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemOpenRef,
            this.mnuItemRemoveRef,
            this.mnuItemWindowsMenuRef});
            this.mnuStripRef.Name = "mnuStripStorageItem";
            this.mnuStripRef.Size = new System.Drawing.Size(158, 70);
            // 
            // mnuItemOpenRef
            // 
            this.mnuItemOpenRef.Name = "mnuItemOpenRef";
            this.mnuItemOpenRef.Size = new System.Drawing.Size(157, 22);
            this.mnuItemOpenRef.Text = "Open";
            // 
            // mnuItemRemoveRef
            // 
            this.mnuItemRemoveRef.Name = "mnuItemRemoveRef";
            this.mnuItemRemoveRef.Size = new System.Drawing.Size(157, 22);
            this.mnuItemRemoveRef.Text = "Remove";
            this.mnuItemRemoveRef.Click += new System.EventHandler(this.mnuItemRemoveRef_Click);
            // 
            // mnuItemWindowsMenuRef
            // 
            this.mnuItemWindowsMenuRef.Name = "mnuItemWindowsMenuRef";
            this.mnuItemWindowsMenuRef.Size = new System.Drawing.Size(157, 22);
            this.mnuItemWindowsMenuRef.Text = "Windows Menu";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mnuTools,
            this.minimizeToTrayToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(2, 2);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1187, 24);
            this.menuStrip1.TabIndex = 28;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewWindow,
            this.toolStripSeparator15,
            this.mnuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuNewWindow
            // 
            this.mnuNewWindow.Name = "mnuNewWindow";
            this.mnuNewWindow.Size = new System.Drawing.Size(145, 22);
            this.mnuNewWindow.Text = "New Window";
            this.mnuNewWindow.Click += new System.EventHandler(this.mnuNewWindow_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(142, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Image = ((System.Drawing.Image)(resources.GetObject("mnuFileExit.Image")));
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuFileExit.Size = new System.Drawing.Size(145, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemGenerateReport,
            this.mnuItemCustomReport,
            this.mnuItemRefreshQuickLists,
            this.mnuItemOptions});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(47, 20);
            this.mnuTools.Text = "&Tools";
            // 
            // mnuItemGenerateReport
            // 
            this.mnuItemGenerateReport.Name = "mnuItemGenerateReport";
            this.mnuItemGenerateReport.Size = new System.Drawing.Size(173, 22);
            this.mnuItemGenerateReport.Text = "Generate Report";
            this.mnuItemGenerateReport.Visible = false;
            this.mnuItemGenerateReport.Click += new System.EventHandler(this.mnuItemGenerateReport_Click);
            // 
            // mnuItemCustomReport
            // 
            this.mnuItemCustomReport.Name = "mnuItemCustomReport";
            this.mnuItemCustomReport.Size = new System.Drawing.Size(173, 22);
            this.mnuItemCustomReport.Text = "Custom Report";
            this.mnuItemCustomReport.Visible = false;
            this.mnuItemCustomReport.Click += new System.EventHandler(this.mnuItemCustomReport_Click);
            // 
            // mnuItemRefreshQuickLists
            // 
            this.mnuItemRefreshQuickLists.Name = "mnuItemRefreshQuickLists";
            this.mnuItemRefreshQuickLists.Size = new System.Drawing.Size(173, 22);
            this.mnuItemRefreshQuickLists.Text = "Refresh Quick Lists";
            this.mnuItemRefreshQuickLists.Click += new System.EventHandler(this.mnuItemRefreshQuickLists_Click);
            // 
            // mnuItemOptions
            // 
            this.mnuItemOptions.Name = "mnuItemOptions";
            this.mnuItemOptions.Size = new System.Drawing.Size(173, 22);
            this.mnuItemOptions.Text = "Options";
            this.mnuItemOptions.Click += new System.EventHandler(this.mnuItemOptions_Click);
            // 
            // minimizeToTrayToolStripMenuItem
            // 
            this.minimizeToTrayToolStripMenuItem.Name = "minimizeToTrayToolStripMenuItem";
            this.minimizeToTrayToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.minimizeToTrayToolStripMenuItem.Text = "&Minimize To Tray";
            this.minimizeToTrayToolStripMenuItem.Click += new System.EventHandler(this.tsbMinimizeToTray_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.mnuItemCheckForUpdate});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // mnuItemCheckForUpdate
            // 
            this.mnuItemCheckForUpdate.Name = "mnuItemCheckForUpdate";
            this.mnuItemCheckForUpdate.Size = new System.Drawing.Size(166, 22);
            this.mnuItemCheckForUpdate.Text = "Check for Update";
            this.mnuItemCheckForUpdate.Click += new System.EventHandler(this.mnuItemCheckForUpdate_Click);
            // 
            // toolStripMain
            // 
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCategories,
            this.toolStripSeparator16});
            this.toolStripMain.Location = new System.Drawing.Point(2, 26);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(1187, 25);
            this.toolStripMain.TabIndex = 29;
            // 
            // tsbCategories
            // 
            this.tsbCategories.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCategories.Image = ((System.Drawing.Image)(resources.GetObject("tsbCategories.Image")));
            this.tsbCategories.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCategories.Name = "tsbCategories";
            this.tsbCategories.Size = new System.Drawing.Size(23, 22);
            this.tsbCategories.Text = "Workspace";
            this.tsbCategories.Click += new System.EventHandler(this.tsbCategories_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 25);
            // 
            // statMain
            // 
            this.statMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslFitered,
            this.sslTotal,
            this.sslLine,
            this.sslColumn,
            this.sslInsert,
            this.sslOther});
            this.statMain.Location = new System.Drawing.Point(2, 540);
            this.statMain.Name = "statMain";
            this.statMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statMain.Size = new System.Drawing.Size(1187, 22);
            this.statMain.TabIndex = 33;
            // 
            // sslFitered
            // 
            this.sslFitered.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.sslFitered.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sslFitered.Name = "sslFitered";
            this.sslFitered.Size = new System.Drawing.Size(586, 17);
            this.sslFitered.Spring = true;
            this.sslFitered.Text = "Filtered by Without";
            this.sslFitered.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sslTotal
            // 
            this.sslTotal.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.sslTotal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sslTotal.Name = "sslTotal";
            this.sslTotal.Size = new System.Drawing.Size(586, 17);
            this.sslTotal.Spring = true;
            this.sslTotal.Text = "Welcome";
            this.sslTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sslLine
            // 
            this.sslLine.Name = "sslLine";
            this.sslLine.Size = new System.Drawing.Size(0, 17);
            // 
            // sslColumn
            // 
            this.sslColumn.Name = "sslColumn";
            this.sslColumn.Size = new System.Drawing.Size(0, 17);
            // 
            // sslInsert
            // 
            this.sslInsert.Name = "sslInsert";
            this.sslInsert.Size = new System.Drawing.Size(0, 17);
            // 
            // sslOther
            // 
            this.sslOther.Name = "sslOther";
            this.sslOther.Size = new System.Drawing.Size(0, 17);
            // 
            // splitContainer
            // 
            this.splitContainer.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(2, 51);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tabControl);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.splitContainerStorageItem);
            this.splitContainer.Size = new System.Drawing.Size(1187, 489);
            this.splitContainer.SplitterDistance = 360;
            this.splitContainer.SplitterWidth = 6;
            this.splitContainer.TabIndex = 31;
            // 
            // tabControl
            // 
            this.tabControl.AlwaysShowClose = false;
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tabControl.Items.AddRange(new FarsiLibrary.Win.FATabStripItem[] {
            this.tabPageCategory,
            this.tabPageReference,
            this.tabPageGroupSite});
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedItem = this.tabPageCategory;
            this.tabControl.Size = new System.Drawing.Size(360, 489);
            this.tabControl.TabIndex = 25;
            this.tabControl.Text = "tabControl";
            this.tabControl.TabStripItemSelectionChanged += new FarsiLibrary.Win.TabStripItemChangedHandler(this.tabControl_TabStripItemSelectionChanged);
            // 
            // tabPageCategory
            // 
            this.tabPageCategory.Controls.Add(this.splitContainerTree);
            this.tabPageCategory.IsDrawn = true;
            this.tabPageCategory.Name = "tabPageCategory";
            this.tabPageCategory.Selected = true;
            this.tabPageCategory.Size = new System.Drawing.Size(358, 468);
            this.tabPageCategory.TabIndex = 0;
            this.tabPageCategory.Title = "Workspace";
            // 
            // splitContainerTree
            // 
            this.splitContainerTree.BackColor = System.Drawing.SystemColors.GrayText;
            this.splitContainerTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTree.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTree.Name = "splitContainerTree";
            this.splitContainerTree.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTree.Panel1
            // 
            this.splitContainerTree.Panel1.Controls.Add(this.panel2);
            this.splitContainerTree.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainerTree.Panel2
            // 
            this.splitContainerTree.Panel2.Controls.Add(this.splitContainerReferenceTree);
            this.splitContainerTree.Size = new System.Drawing.Size(358, 468);
            this.splitContainerTree.SplitterDistance = 72;
            this.splitContainerTree.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tvWorkSpace);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(358, 49);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.chkSearchInAllCategories);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(358, 23);
            this.panel1.TabIndex = 1;
            // 
            // chkSearchInAllCategories
            // 
            this.chkSearchInAllCategories.AutoSize = true;
            this.chkSearchInAllCategories.Location = new System.Drawing.Point(6, 4);
            this.chkSearchInAllCategories.Name = "chkSearchInAllCategories";
            this.chkSearchInAllCategories.Size = new System.Drawing.Size(86, 17);
            this.chkSearchInAllCategories.TabIndex = 0;
            this.chkSearchInAllCategories.Text = "Search In All";
            this.chkSearchInAllCategories.UseVisualStyleBackColor = true;
            this.chkSearchInAllCategories.CheckedChanged += new System.EventHandler(this.chkSearchInAllCategories_CheckedChanged);
            // 
            // splitContainerReferenceTree
            // 
            this.splitContainerReferenceTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerReferenceTree.Location = new System.Drawing.Point(0, 0);
            this.splitContainerReferenceTree.Name = "splitContainerReferenceTree";
            this.splitContainerReferenceTree.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerReferenceTree.Panel1
            // 
            this.splitContainerReferenceTree.Panel1.Controls.Add(this.txtMainStorageItemDesc);
            // 
            // splitContainerReferenceTree.Panel2
            // 
            this.splitContainerReferenceTree.Panel2.Controls.Add(this.splitContainerSiteGroup);
            this.splitContainerReferenceTree.Size = new System.Drawing.Size(358, 392);
            this.splitContainerReferenceTree.SplitterDistance = 58;
            this.splitContainerReferenceTree.TabIndex = 2;
            // 
            // txtMainStorageItemDesc
            // 
            this.txtMainStorageItemDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMainStorageItemDesc.Location = new System.Drawing.Point(0, 0);
            this.txtMainStorageItemDesc.Multiline = true;
            this.txtMainStorageItemDesc.Name = "txtMainStorageItemDesc";
            this.txtMainStorageItemDesc.ReadOnly = true;
            this.txtMainStorageItemDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMainStorageItemDesc.Size = new System.Drawing.Size(358, 58);
            this.txtMainStorageItemDesc.TabIndex = 1;
            // 
            // splitContainerSiteGroup
            // 
            this.splitContainerSiteGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSiteGroup.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSiteGroup.Name = "splitContainerSiteGroup";
            this.splitContainerSiteGroup.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerSiteGroup.Panel1
            // 
            this.splitContainerSiteGroup.Panel1.Controls.Add(this.tvOneSiteGroup);
            // 
            // splitContainerSiteGroup.Panel2
            // 
            this.splitContainerSiteGroup.Panel2.Controls.Add(this.splitContainerSimilarItems);
            this.splitContainerSiteGroup.Size = new System.Drawing.Size(358, 330);
            this.splitContainerSiteGroup.SplitterDistance = 69;
            this.splitContainerSiteGroup.TabIndex = 2;
            // 
            // tvOneSiteGroup
            // 
            this.tvOneSiteGroup.AllowDrop = true;
            this.tvOneSiteGroup.Cursor = System.Windows.Forms.Cursors.Default;
            this.tvOneSiteGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvOneSiteGroup.Font = new System.Drawing.Font("Tahoma", 8F);
            this.tvOneSiteGroup.FullRowSelect = true;
            this.tvOneSiteGroup.HideSelection = false;
            this.tvOneSiteGroup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tvOneSiteGroup.Location = new System.Drawing.Point(0, 0);
            this.tvOneSiteGroup.Name = "tvOneSiteGroup";
            this.tvOneSiteGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tvOneSiteGroup.Size = new System.Drawing.Size(358, 69);
            this.tvOneSiteGroup.TabIndex = 2;
            this.tvOneSiteGroup.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOneSiteGroup_AfterSelect);
            // 
            // splitContainerSimilarItems
            // 
            this.splitContainerSimilarItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSimilarItems.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSimilarItems.Name = "splitContainerSimilarItems";
            this.splitContainerSimilarItems.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerSimilarItems.Panel1
            // 
            this.splitContainerSimilarItems.Panel1.Controls.Add(this.tvRefView);
            // 
            // splitContainerSimilarItems.Panel2
            // 
            this.splitContainerSimilarItems.Panel2.Controls.Add(this.splitContainerGroupStorage);
            this.splitContainerSimilarItems.Size = new System.Drawing.Size(358, 257);
            this.splitContainerSimilarItems.SplitterDistance = 75;
            this.splitContainerSimilarItems.TabIndex = 30;
            // 
            // tvRefView
            // 
            this.tvRefView.AllowDrop = true;
            this.tvRefView.Cursor = System.Windows.Forms.Cursors.Default;
            this.tvRefView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvRefView.Font = new System.Drawing.Font("Tahoma", 8F);
            this.tvRefView.FullRowSelect = true;
            this.tvRefView.HideSelection = false;
            this.tvRefView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tvRefView.Location = new System.Drawing.Point(0, 0);
            this.tvRefView.Name = "tvRefView";
            this.tvRefView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tvRefView.Size = new System.Drawing.Size(358, 75);
            this.tvRefView.TabIndex = 1;
            this.tvRefView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvRefView_BeforeExpand);
            this.tvRefView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvRefView_AfterSelect);
            // 
            // splitContainerGroupStorage
            // 
            this.splitContainerGroupStorage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerGroupStorage.Location = new System.Drawing.Point(0, 0);
            this.splitContainerGroupStorage.Name = "splitContainerGroupStorage";
            this.splitContainerGroupStorage.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerGroupStorage.Panel1
            // 
            this.splitContainerGroupStorage.Panel1.Controls.Add(this.tvSimilarItems);
            // 
            // splitContainerGroupStorage.Panel2
            // 
            this.splitContainerGroupStorage.Panel2.Controls.Add(this.treeViewAllQuickList);
            this.splitContainerGroupStorage.Size = new System.Drawing.Size(358, 178);
            this.splitContainerGroupStorage.SplitterDistance = 57;
            this.splitContainerGroupStorage.TabIndex = 31;
            // 
            // tvSimilarItems
            // 
            this.tvSimilarItems.AllowDrop = true;
            this.tvSimilarItems.Cursor = System.Windows.Forms.Cursors.Default;
            this.tvSimilarItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSimilarItems.Font = new System.Drawing.Font("Tahoma", 8F);
            this.tvSimilarItems.FullRowSelect = true;
            this.tvSimilarItems.HideSelection = false;
            this.tvSimilarItems.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tvSimilarItems.Location = new System.Drawing.Point(0, 0);
            this.tvSimilarItems.Name = "tvSimilarItems";
            this.tvSimilarItems.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tvSimilarItems.Size = new System.Drawing.Size(358, 57);
            this.tvSimilarItems.TabIndex = 3;
            this.tvSimilarItems.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSimilarItems_AfterSelect);
            // 
            // tabPageReference
            // 
            this.tabPageReference.Controls.Add(this.tvRef);
            this.tabPageReference.Controls.Add(this.panel3);
            this.tabPageReference.Controls.Add(this.ctrlReferenceNavigator);
            this.tabPageReference.IsDrawn = true;
            this.tabPageReference.Name = "tabPageReference";
            this.tabPageReference.Size = new System.Drawing.Size(217, 468);
            this.tabPageReference.TabIndex = 1;
            this.tabPageReference.Text = "References";
            this.tabPageReference.Title = "References";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtMainDesc);
            this.panel3.Controls.Add(this.txtMainFullPath);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(217, 97);
            this.panel3.TabIndex = 23;
            // 
            // txtMainDesc
            // 
            this.txtMainDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMainDesc.Location = new System.Drawing.Point(40, 30);
            this.txtMainDesc.Multiline = true;
            this.txtMainDesc.Name = "txtMainDesc";
            this.txtMainDesc.ReadOnly = true;
            this.txtMainDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMainDesc.Size = new System.Drawing.Size(165, 57);
            this.txtMainDesc.TabIndex = 21;
            // 
            // txtMainFullPath
            // 
            this.txtMainFullPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMainFullPath.Location = new System.Drawing.Point(40, 8);
            this.txtMainFullPath.Name = "txtMainFullPath";
            this.txtMainFullPath.ReadOnly = true;
            this.txtMainFullPath.Size = new System.Drawing.Size(165, 21);
            this.txtMainFullPath.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Desc:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Path:";
            // 
            // tabPageGroupSite
            // 
            this.tabPageGroupSite.Controls.Add(this.tvSiteGroup);
            this.tabPageGroupSite.Controls.Add(this.panel4);
            this.tabPageGroupSite.IsDrawn = true;
            this.tabPageGroupSite.Name = "tabPageGroupSite";
            this.tabPageGroupSite.Size = new System.Drawing.Size(355, 468);
            this.tabPageGroupSite.TabIndex = 2;
            this.tabPageGroupSite.Title = "Group By Site";
            // 
            // tvSiteGroup
            // 
            this.tvSiteGroup.AllowDrop = true;
            this.tvSiteGroup.Cursor = System.Windows.Forms.Cursors.Default;
            this.tvSiteGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSiteGroup.Font = new System.Drawing.Font("Tahoma", 8F);
            this.tvSiteGroup.FullRowSelect = true;
            this.tvSiteGroup.HideSelection = false;
            this.tvSiteGroup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tvSiteGroup.Location = new System.Drawing.Point(0, 33);
            this.tvSiteGroup.Name = "tvSiteGroup";
            this.tvSiteGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tvSiteGroup.Size = new System.Drawing.Size(355, 435);
            this.tvSiteGroup.TabIndex = 1;
            this.tvSiteGroup.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSiteGroup_AfterSelect);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.BtnGroupBySite);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(355, 33);
            this.panel4.TabIndex = 4;
            // 
            // BtnGroupBySite
            // 
            this.BtnGroupBySite.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnGroupBySite.Font = new System.Drawing.Font("Tahoma", 8F);
            this.BtnGroupBySite.Location = new System.Drawing.Point(16, 5);
            this.BtnGroupBySite.Name = "BtnGroupBySite";
            this.BtnGroupBySite.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnGroupBySite.Size = new System.Drawing.Size(124, 23);
            this.BtnGroupBySite.TabIndex = 18;
            this.BtnGroupBySite.Text = "Group By Site";
            this.BtnGroupBySite.UseVisualStyleBackColor = true;
            this.BtnGroupBySite.Click += new System.EventHandler(this.BtnGroupBySite_Click);
            // 
            // splitContainerStorageItem
            // 
            this.splitContainerStorageItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerStorageItem.Location = new System.Drawing.Point(0, 0);
            this.splitContainerStorageItem.Name = "splitContainerStorageItem";
            this.splitContainerStorageItem.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerStorageItem.Panel1
            // 
            this.splitContainerStorageItem.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerStorageItem.Panel1.Controls.Add(this.btnDoSearch);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.chkShowHint);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.txtMainStorageItemDesc2);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.btnEmptyList);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.lblReportListCount);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.label14);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.txtFilter);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.label13);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.cmbSortType);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.label12);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.cmbTopN);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.btnClear);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.btnPaste);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.btnPasteSimilar);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.btnSimilar);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.btnAmpersand);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.btnPercent);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.chkAllowLstStorageMultiSelect);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.btnSearchContent);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.cmbPriorityOperand);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.cmbOrder);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.label1);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.upDownPriority);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.ctrlSearchContentProgress);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.label4);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.txtSearchContent);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.label6);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.label3);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.label7);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.txtSearchReferencesBib);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.label10);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.txtSearchImportantParts);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.label11);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.txtSearchCitation);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.label2);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.txtSearchFileName);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.label5);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.txtSearchURL);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.txtSearchDescription);
            this.splitContainerStorageItem.Panel1.Controls.Add(this.ctrlTargetArea);
            // 
            // splitContainerStorageItem.Panel2
            // 
            this.splitContainerStorageItem.Panel2.Controls.Add(this.lstStorageItem);
            this.splitContainerStorageItem.Size = new System.Drawing.Size(821, 489);
            this.splitContainerStorageItem.SplitterDistance = 199;
            this.splitContainerStorageItem.TabIndex = 18;
            // 
            // chkShowHint
            // 
            this.chkShowHint.AutoSize = true;
            this.chkShowHint.Location = new System.Drawing.Point(643, 126);
            this.chkShowHint.Name = "chkShowHint";
            this.chkShowHint.Size = new System.Drawing.Size(75, 17);
            this.chkShowHint.TabIndex = 44;
            this.chkShowHint.Text = "Show Hint";
            this.chkShowHint.UseVisualStyleBackColor = true;
            this.chkShowHint.CheckedChanged += new System.EventHandler(this.chkShowHint_CheckedChanged);
            // 
            // txtMainStorageItemDesc2
            // 
            this.txtMainStorageItemDesc2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMainStorageItemDesc2.Location = new System.Drawing.Point(746, 40);
            this.txtMainStorageItemDesc2.Multiline = true;
            this.txtMainStorageItemDesc2.Name = "txtMainStorageItemDesc2";
            this.txtMainStorageItemDesc2.ReadOnly = true;
            this.txtMainStorageItemDesc2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMainStorageItemDesc2.Size = new System.Drawing.Size(71, 129);
            this.txtMainStorageItemDesc2.TabIndex = 43;
            // 
            // btnEmptyList
            // 
            this.btnEmptyList.Location = new System.Drawing.Point(521, 122);
            this.btnEmptyList.Name = "btnEmptyList";
            this.btnEmptyList.Size = new System.Drawing.Size(76, 22);
            this.btnEmptyList.TabIndex = 41;
            this.btnEmptyList.Text = "Empty List";
            this.btnEmptyList.UseVisualStyleBackColor = true;
            this.btnEmptyList.Click += new System.EventHandler(this.btnEmptyList_Click);
            // 
            // lblReportListCount
            // 
            this.lblReportListCount.AutoSize = true;
            this.lblReportListCount.Location = new System.Drawing.Point(662, 102);
            this.lblReportListCount.Name = "lblReportListCount";
            this.lblReportListCount.Size = new System.Drawing.Size(13, 13);
            this.lblReportListCount.TabIndex = 40;
            this.lblReportListCount.Text = "0";
            this.lblReportListCount.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(593, 103);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 13);
            this.label14.TabIndex = 40;
            this.label14.Text = "Report List :";
            this.label14.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 153);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 38;
            this.label13.Text = "Without";
            // 
            // cmbSortType
            // 
            this.cmbSortType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortType.FormattingEnabled = true;
            this.cmbSortType.Location = new System.Drawing.Point(666, 55);
            this.cmbSortType.Name = "cmbSortType";
            this.cmbSortType.Size = new System.Drawing.Size(77, 21);
            this.cmbSortType.TabIndex = 37;
            this.cmbSortType.SelectedIndexChanged += new System.EventHandler(this.cmbSortType_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(388, 104);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 36;
            this.label12.Text = "Top N :";
            // 
            // cmbTopN
            // 
            this.cmbTopN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTopN.FormattingEnabled = true;
            this.cmbTopN.Location = new System.Drawing.Point(437, 100);
            this.cmbTopN.Name = "cmbTopN";
            this.cmbTopN.Size = new System.Drawing.Size(112, 21);
            this.cmbTopN.TabIndex = 35;
            this.cmbTopN.SelectedIndexChanged += new System.EventHandler(this.cmbTopN_SelectedIndexChanged);
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImage = global::FileOrganizer.Properties.Resources.Clear;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClear.Location = new System.Drawing.Point(674, 7);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(23, 23);
            this.btnClear.TabIndex = 29;
            this.toolTip1.SetToolTip(this.btnClear, "Clear \'Description\' textbox for new search.");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.BackgroundImage = global::FileOrganizer.Properties.Resources.Paste;
            this.btnPaste.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPaste.Location = new System.Drawing.Point(579, 7);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(23, 23);
            this.btnPaste.TabIndex = 29;
            this.toolTip1.SetToolTip(this.btnPaste, "Paste Text From Clipboard.");
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnPasteSimilar
            // 
            this.btnPasteSimilar.Location = new System.Drawing.Point(603, 7);
            this.btnPasteSimilar.Name = "btnPasteSimilar";
            this.btnPasteSimilar.Size = new System.Drawing.Size(72, 23);
            this.btnPasteSimilar.TabIndex = 28;
            this.btnPasteSimilar.Text = "PASTE+ &&";
            this.toolTip1.SetToolTip(this.btnPasteSimilar, "Paste Text From Clipboard and replace space with (&) to find the words by any ord" +
                    "er.");
            this.btnPasteSimilar.UseVisualStyleBackColor = true;
            this.btnPasteSimilar.Click += new System.EventHandler(this.btnPasteSimilar_Click);
            // 
            // btnSimilar
            // 
            this.btnSimilar.Location = new System.Drawing.Point(549, 7);
            this.btnSimilar.Name = "btnSimilar";
            this.btnSimilar.Size = new System.Drawing.Size(28, 23);
            this.btnSimilar.TabIndex = 28;
            this.btnSimilar.Text = "&S";
            this.btnSimilar.UseVisualStyleBackColor = true;
            this.btnSimilar.Visible = false;
            this.btnSimilar.Click += new System.EventHandler(this.btnSimilar_Click);
            // 
            // btnAmpersand
            // 
            this.btnAmpersand.Location = new System.Drawing.Point(521, 7);
            this.btnAmpersand.Name = "btnAmpersand";
            this.btnAmpersand.Size = new System.Drawing.Size(28, 23);
            this.btnAmpersand.TabIndex = 28;
            this.btnAmpersand.Text = "&&";
            this.toolTip1.SetToolTip(this.btnAmpersand, "& word separator to find all words in any order.\r\nEx:\r\nxml&databse finds:\r\nstorin" +
                    "g xml in database.\r\nexporting database to xml file.");
            this.btnAmpersand.UseVisualStyleBackColor = true;
            this.btnAmpersand.Click += new System.EventHandler(this.btnAmpersand_Click);
            // 
            // btnPercent
            // 
            this.btnPercent.Location = new System.Drawing.Point(500, 7);
            this.btnPercent.Name = "btnPercent";
            this.btnPercent.Size = new System.Drawing.Size(18, 23);
            this.btnPercent.TabIndex = 27;
            this.btnPercent.Text = "%";
            this.toolTip1.SetToolTip(this.btnPercent, "% Matches any number of characters.\r\nEx:\r\nwh% finds what, white, and why, but not" +
                    " awhile or watch.");
            this.btnPercent.UseVisualStyleBackColor = true;
            this.btnPercent.Click += new System.EventHandler(this.btnPercent_Click);
            // 
            // chkAllowLstStorageMultiSelect
            // 
            this.chkAllowLstStorageMultiSelect.AutoSize = true;
            this.chkAllowLstStorageMultiSelect.Location = new System.Drawing.Point(665, 35);
            this.chkAllowLstStorageMultiSelect.Name = "chkAllowLstStorageMultiSelect";
            this.chkAllowLstStorageMultiSelect.Size = new System.Drawing.Size(81, 17);
            this.chkAllowLstStorageMultiSelect.TabIndex = 26;
            this.chkAllowLstStorageMultiSelect.Text = "Multi Select";
            this.chkAllowLstStorageMultiSelect.UseVisualStyleBackColor = true;
            this.chkAllowLstStorageMultiSelect.CheckedChanged += new System.EventHandler(this.chkAllowLstStorageMultiSelect_CheckedChanged);
            // 
            // cmbPriorityOperand
            // 
            this.cmbPriorityOperand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriorityOperand.FormattingEnabled = true;
            this.cmbPriorityOperand.Location = new System.Drawing.Point(552, 33);
            this.cmbPriorityOperand.Name = "cmbPriorityOperand";
            this.cmbPriorityOperand.Size = new System.Drawing.Size(51, 21);
            this.cmbPriorityOperand.TabIndex = 24;
            this.cmbPriorityOperand.SelectedIndexChanged += new System.EventHandler(this.cmbPriorityOperand_SelectedIndexChanged);
            // 
            // cmbOrder
            // 
            this.cmbOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrder.FormattingEnabled = true;
            this.cmbOrder.Location = new System.Drawing.Point(552, 55);
            this.cmbOrder.Name = "cmbOrder";
            this.cmbOrder.Size = new System.Drawing.Size(108, 21);
            this.cmbOrder.TabIndex = 24;
            this.cmbOrder.SelectedIndexChanged += new System.EventHandler(this.cmbOrder_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Description";
            // 
            // upDownPriority
            // 
            this.upDownPriority.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.upDownPriority.Location = new System.Drawing.Point(603, 33);
            this.upDownPriority.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.upDownPriority.Name = "upDownPriority";
            this.upDownPriority.Size = new System.Drawing.Size(57, 20);
            this.upDownPriority.TabIndex = 23;
            this.upDownPriority.ValueChanged += new System.EventHandler(this.upDownPriority_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "URL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(516, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Sort:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(384, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Content:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(504, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Priority:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(390, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Ref bib";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Imp Parts";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Citation";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "File Name";
            // 
            // notifyIcon
            // 
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // mnuStripQuickList
            // 
            this.mnuStripQuickList.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.mnuStripQuickList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mnuStripQuickList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemOpenQuickList,
            this.mnuItemLocateQuickList,
            this.mnuItemLocateAll,
            this.mnuItemRemoveQuikList,
            this.toolStripSeparator24,
            this.mnuItemRefresh,
            this.mnuItemColor,
            this.mnuItemUnload,
            this.toolStripSeparator25,
            this.mnuItemSortByDescription,
            this.mnuItemSortByFileName,
            this.mnuItemSortByOrderOfAddition,
            this.toolStripSeparator26,
            this.mnuItemEditQListInfo,
            this.mnuItemDeleteQList});
            this.mnuStripQuickList.Name = "mnuStripWorkSpace";
            this.mnuStripQuickList.Size = new System.Drawing.Size(196, 286);
            // 
            // mnuItemOpenQuickList
            // 
            this.mnuItemOpenQuickList.Name = "mnuItemOpenQuickList";
            this.mnuItemOpenQuickList.Size = new System.Drawing.Size(195, 22);
            this.mnuItemOpenQuickList.Text = "Open";
            this.mnuItemOpenQuickList.Click += new System.EventHandler(this.mnuItemOpenQuickList_Click);
            // 
            // mnuItemLocateQuickList
            // 
            this.mnuItemLocateQuickList.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuItemLocateQuickList.Name = "mnuItemLocateQuickList";
            this.mnuItemLocateQuickList.Size = new System.Drawing.Size(195, 22);
            this.mnuItemLocateQuickList.Text = "Locate";
            this.mnuItemLocateQuickList.Click += new System.EventHandler(this.mnuItemLocateQuickList_Click);
            // 
            // mnuItemLocateAll
            // 
            this.mnuItemLocateAll.Name = "mnuItemLocateAll";
            this.mnuItemLocateAll.Size = new System.Drawing.Size(195, 22);
            this.mnuItemLocateAll.Text = "Locate All";
            this.mnuItemLocateAll.Click += new System.EventHandler(this.mnuItemLocateAll_Click);
            // 
            // mnuItemRemoveQuikList
            // 
            this.mnuItemRemoveQuikList.Name = "mnuItemRemoveQuikList";
            this.mnuItemRemoveQuikList.Size = new System.Drawing.Size(195, 22);
            this.mnuItemRemoveQuikList.Text = "Remove";
            this.mnuItemRemoveQuikList.Click += new System.EventHandler(this.mnuItemRemoveQuikList_Click);
            // 
            // toolStripSeparator24
            // 
            this.toolStripSeparator24.Name = "toolStripSeparator24";
            this.toolStripSeparator24.Size = new System.Drawing.Size(192, 6);
            // 
            // mnuItemRefresh
            // 
            this.mnuItemRefresh.Name = "mnuItemRefresh";
            this.mnuItemRefresh.Size = new System.Drawing.Size(195, 22);
            this.mnuItemRefresh.Text = "Refresh";
            this.mnuItemRefresh.Click += new System.EventHandler(this.mnuItemRefresh_Click);
            // 
            // mnuItemColor
            // 
            this.mnuItemColor.Name = "mnuItemColor";
            this.mnuItemColor.Size = new System.Drawing.Size(195, 22);
            this.mnuItemColor.Text = "Color";
            this.mnuItemColor.Click += new System.EventHandler(this.mnuItemColor_Click);
            // 
            // mnuItemUnload
            // 
            this.mnuItemUnload.Name = "mnuItemUnload";
            this.mnuItemUnload.Size = new System.Drawing.Size(195, 22);
            this.mnuItemUnload.Text = "Unload";
            this.mnuItemUnload.Click += new System.EventHandler(this.mnuItemUnload_Click);
            // 
            // toolStripSeparator25
            // 
            this.toolStripSeparator25.Name = "toolStripSeparator25";
            this.toolStripSeparator25.Size = new System.Drawing.Size(192, 6);
            // 
            // mnuItemSortByDescription
            // 
            this.mnuItemSortByDescription.Name = "mnuItemSortByDescription";
            this.mnuItemSortByDescription.Size = new System.Drawing.Size(195, 22);
            this.mnuItemSortByDescription.Text = "Sort by Description";
            this.mnuItemSortByDescription.Click += new System.EventHandler(this.mnuItemSortByDescription_Click);
            // 
            // mnuItemSortByFileName
            // 
            this.mnuItemSortByFileName.Name = "mnuItemSortByFileName";
            this.mnuItemSortByFileName.Size = new System.Drawing.Size(195, 22);
            this.mnuItemSortByFileName.Text = "Sort by FileName";
            this.mnuItemSortByFileName.Click += new System.EventHandler(this.mnuItemSortByFileName_Click);
            // 
            // mnuItemSortByOrderOfAddition
            // 
            this.mnuItemSortByOrderOfAddition.Name = "mnuItemSortByOrderOfAddition";
            this.mnuItemSortByOrderOfAddition.Size = new System.Drawing.Size(195, 22);
            this.mnuItemSortByOrderOfAddition.Text = "Sort by Order of Addition";
            this.mnuItemSortByOrderOfAddition.Click += new System.EventHandler(this.mnuItemSortByOrderOfAddition_Click);
            // 
            // toolStripSeparator26
            // 
            this.toolStripSeparator26.Name = "toolStripSeparator26";
            this.toolStripSeparator26.Size = new System.Drawing.Size(192, 6);
            // 
            // mnuItemEditQListInfo
            // 
            this.mnuItemEditQListInfo.Name = "mnuItemEditQListInfo";
            this.mnuItemEditQListInfo.Size = new System.Drawing.Size(195, 22);
            this.mnuItemEditQListInfo.Text = "Edit Q List Info";
            this.mnuItemEditQListInfo.Click += new System.EventHandler(this.mnuItemEditQListInfo_Click);
            // 
            // mnuItemDeleteQList
            // 
            this.mnuItemDeleteQList.Name = "mnuItemDeleteQList";
            this.mnuItemDeleteQList.Size = new System.Drawing.Size(195, 22);
            this.mnuItemDeleteQList.Text = "Delete Q List";
            this.mnuItemDeleteQList.Click += new System.EventHandler(this.mnuItemDeleteQList_Click);
            // 
            // tvWorkSpace
            // 
            this.tvWorkSpace.AllowDrop = true;
            this.tvWorkSpace.CheckBoxes = true;
            this.tvWorkSpace.Cursor = System.Windows.Forms.Cursors.Default;
            this.tvWorkSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvWorkSpace.Font = new System.Drawing.Font("Tahoma", 8F);
            this.tvWorkSpace.FullRowSelect = true;
            this.tvWorkSpace.HideSelection = false;
            this.tvWorkSpace.ImageIndex = 1;
            this.tvWorkSpace.ImageList = this.imgListForTVWorkSpace;
            this.tvWorkSpace.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tvWorkSpace.Location = new System.Drawing.Point(0, 0);
            this.tvWorkSpace.Name = "tvWorkSpace";
            this.tvWorkSpace.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tvWorkSpace.SelectedImageIndex = 0;
            this.tvWorkSpace.Size = new System.Drawing.Size(358, 49);
            this.tvWorkSpace.TabIndex = 0;
            this.tvWorkSpace.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvWorkSpace_AfterCheck);
            this.tvWorkSpace.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvWorkSpace_AfterSelect);
            this.tvWorkSpace.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvWorkSpace_DragDrop);
            this.tvWorkSpace.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvWorkSpace_DragEnter);
            this.tvWorkSpace.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tvWorkSpace_MouseUp);
            // 
            // treeViewAllQuickList
            // 
            this.treeViewAllQuickList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewAllQuickList.ImageIndex = 0;
            this.treeViewAllQuickList.ListViewStorage = null;
            this.treeViewAllQuickList.Location = new System.Drawing.Point(0, 0);
            this.treeViewAllQuickList.Name = "treeViewAllQuickList";
            this.treeViewAllQuickList.SelectedImageIndex = 0;
            this.treeViewAllQuickList.Size = new System.Drawing.Size(358, 117);
            this.treeViewAllQuickList.StorageItem = null;
            this.treeViewAllQuickList.TabIndex = 1;
            this.treeViewAllQuickList.TargetColor = System.Drawing.Color.Orange;
            // 
            // tvRef
            // 
            this.tvRef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvRef.ImageIndex = 0;
            this.tvRef.Location = new System.Drawing.Point(0, 122);
            this.tvRef.Name = "tvRef";
            this.tvRef.SelectedImageIndex = 0;
            this.tvRef.Size = new System.Drawing.Size(217, 346);
            this.tvRef.TabIndex = 24;
            // 
            // ctrlReferenceNavigator
            // 
            this.ctrlReferenceNavigator.AutoSize = true;
            this.ctrlReferenceNavigator.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlReferenceNavigator.Location = new System.Drawing.Point(0, 0);
            this.ctrlReferenceNavigator.Name = "ctrlReferenceNavigator";
            this.ctrlReferenceNavigator.Size = new System.Drawing.Size(217, 25);
            this.ctrlReferenceNavigator.TabIndex = 22;
            this.ctrlReferenceNavigator.ReferenceNavigatorPositionChanged += new FileOrganizer.UI.ReferenceNavigatorPositionChangedEventHandler(this.ctrlReferenceNavigator_ReferenceNavigatorPositionChanged);
            this.ctrlReferenceNavigator.LocateClicked += new System.EventHandler(this.ctrlReferenceNavigator_LocateClicked);
            // 
            // txtFilter
            // 
            this.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilter.Location = new System.Drawing.Point(62, 149);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(0, 0, 273, 0);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(306, 20);
            this.txtFilter.TabIndex = 39;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // btnSearchContent
            // 
            this.btnSearchContent.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchContent.BaseColor = System.Drawing.Color.Transparent;
            this.btnSearchContent.ButtonColor = System.Drawing.Color.Silver;
            this.btnSearchContent.ButtonText = "Search Content";
            this.btnSearchContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchContent.ForeColor = System.Drawing.Color.Black;
            this.btnSearchContent.Location = new System.Drawing.Point(618, 166);
            this.btnSearchContent.Name = "btnSearchContent";
            this.btnSearchContent.Size = new System.Drawing.Size(111, 29);
            this.btnSearchContent.TabIndex = 25;
            this.btnSearchContent.Click += new System.EventHandler(this.btnSearchContent_Click);
            // 
            // ctrlSearchContentProgress
            // 
            this.ctrlSearchContentProgress.IsStopped = false;
            this.ctrlSearchContentProgress.ListView = null;
            this.ctrlSearchContentProgress.Location = new System.Drawing.Point(5, 166);
            this.ctrlSearchContentProgress.Name = "ctrlSearchContentProgress";
            this.ctrlSearchContentProgress.Size = new System.Drawing.Size(554, 28);
            this.ctrlSearchContentProgress.TabIndex = 22;
            this.ctrlSearchContentProgress.TextToSearch = null;
            this.ctrlSearchContentProgress.Visible = false;
            // 
            // txtSearchContent
            // 
            this.txtSearchContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchContent.Location = new System.Drawing.Point(437, 145);
            this.txtSearchContent.Margin = new System.Windows.Forms.Padding(0, 0, 273, 0);
            this.txtSearchContent.Name = "txtSearchContent";
            this.txtSearchContent.Size = new System.Drawing.Size(306, 20);
            this.txtSearchContent.TabIndex = 21;
            this.txtSearchContent.TextChanged += new System.EventHandler(this.txtSearchContent_TextChanged);
            // 
            // txtSearchReferencesBib
            // 
            this.txtSearchReferencesBib.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchReferencesBib.Location = new System.Drawing.Point(437, 78);
            this.txtSearchReferencesBib.Margin = new System.Windows.Forms.Padding(0, 0, 273, 0);
            this.txtSearchReferencesBib.Name = "txtSearchReferencesBib";
            this.txtSearchReferencesBib.Size = new System.Drawing.Size(306, 20);
            this.txtSearchReferencesBib.TabIndex = 21;
            this.txtSearchReferencesBib.TextChanged += new System.EventHandler(this.txtSearchReferencesBib_TextChanged);
            // 
            // txtSearchImportantParts
            // 
            this.txtSearchImportantParts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchImportantParts.Location = new System.Drawing.Point(62, 125);
            this.txtSearchImportantParts.Margin = new System.Windows.Forms.Padding(0, 0, 273, 0);
            this.txtSearchImportantParts.Name = "txtSearchImportantParts";
            this.txtSearchImportantParts.Size = new System.Drawing.Size(306, 20);
            this.txtSearchImportantParts.TabIndex = 21;
            this.txtSearchImportantParts.TextChanged += new System.EventHandler(this.txtSearchImportantParts_TextChanged);
            // 
            // txtSearchCitation
            // 
            this.txtSearchCitation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchCitation.Location = new System.Drawing.Point(62, 102);
            this.txtSearchCitation.Margin = new System.Windows.Forms.Padding(0, 0, 273, 0);
            this.txtSearchCitation.Name = "txtSearchCitation";
            this.txtSearchCitation.Size = new System.Drawing.Size(306, 20);
            this.txtSearchCitation.TabIndex = 21;
            this.txtSearchCitation.TextChanged += new System.EventHandler(this.txtSearchCitation_TextChanged);
            // 
            // txtSearchFileName
            // 
            this.txtSearchFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchFileName.Location = new System.Drawing.Point(62, 77);
            this.txtSearchFileName.Margin = new System.Windows.Forms.Padding(0, 0, 273, 0);
            this.txtSearchFileName.Name = "txtSearchFileName";
            this.txtSearchFileName.Size = new System.Drawing.Size(306, 20);
            this.txtSearchFileName.TabIndex = 21;
            this.txtSearchFileName.TextChanged += new System.EventHandler(this.txtSearchFileName_TextChanged);
            // 
            // txtSearchURL
            // 
            this.txtSearchURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchURL.Location = new System.Drawing.Point(62, 54);
            this.txtSearchURL.Margin = new System.Windows.Forms.Padding(0, 0, 403, 0);
            this.txtSearchURL.Name = "txtSearchURL";
            this.txtSearchURL.Size = new System.Drawing.Size(436, 20);
            this.txtSearchURL.TabIndex = 21;
            this.txtSearchURL.TextChanged += new System.EventHandler(this.txtSearchURL_TextChanged);
            // 
            // txtSearchDescription
            // 
            this.txtSearchDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchDescription.Location = new System.Drawing.Point(62, 7);
            this.txtSearchDescription.Margin = new System.Windows.Forms.Padding(0, 0, 500, 0);
            this.txtSearchDescription.Multiline = true;
            this.txtSearchDescription.Name = "txtSearchDescription";
            this.txtSearchDescription.Size = new System.Drawing.Size(436, 45);
            this.txtSearchDescription.TabIndex = 21;
            this.txtSearchDescription.TextChanged += new System.EventHandler(this.txtSearchDescription_TextChanged);
            // 
            // ctrlTargetArea
            // 
            this.ctrlTargetArea.Location = new System.Drawing.Point(696, 2);
            this.ctrlTargetArea.Name = "ctrlTargetArea";
            this.ctrlTargetArea.Padding = new System.Windows.Forms.Padding(5);
            this.ctrlTargetArea.Size = new System.Drawing.Size(118, 32);
            this.ctrlTargetArea.TabIndex = 30;
            this.toolTip1.SetToolTip(this.ctrlTargetArea, "Files Dropping Area:\r\nDrag and drop many files to here, then double click on it \r" +
                    "\nto start adding them to FileOrganizer.");
            this.ctrlTargetArea.LabelDoubleClick += new System.EventHandler(this.ctrlTargetArea_LabelDoubleClick);
            // 
            // lstStorageItem
            // 
            this.lstStorageItem.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstStorageItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colURL,
            this.colFullPath,
            this.colName,
            this.colSize,
            this.coPriority,
            this.colPagesCount,
            this.colDesc,
            this.colNodeItemID,
            this.colCitation,
            this.colReferencesBib,
            this.colImportantParts,
            this.colAdditionDate});
            this.lstStorageItem.ContextMenuStrip = this.mnuStripStorageItem;
            this.lstStorageItem.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstStorageItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstStorageItem.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lstStorageItem.FullRowSelect = true;
            this.lstStorageItem.GridLines = true;
            this.lstStorageItem.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstStorageItem.HideSelection = false;
            this.lstStorageItem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lstStorageItem.Location = new System.Drawing.Point(0, 0);
            this.lstStorageItem.MultiSelect = false;
            this.lstStorageItem.Name = "lstStorageItem";
            this.lstStorageItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstStorageItem.ShowItemToolTips = true;
            this.lstStorageItem.Size = new System.Drawing.Size(821, 286);
            this.lstStorageItem.TabIndex = 17;
            this.lstStorageItem.UseCompatibleStateImageBehavior = false;
            this.lstStorageItem.View = System.Windows.Forms.View.Details;
            this.lstStorageItem.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lstStorageItem_ItemDrag);
            this.lstStorageItem.SelectedIndexChanged += new System.EventHandler(this.lstStorageItem_SelectedIndexChanged);
            this.lstStorageItem.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstStorageItem_DragDrop);
            this.lstStorageItem.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstStorageItem_DragEnter);
            this.lstStorageItem.DragOver += new System.Windows.Forms.DragEventHandler(this.lstStorageItem_DragOver);
            this.lstStorageItem.DoubleClick += new System.EventHandler(this.lstStorageItem_DoubleClick);
            this.lstStorageItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstStorageItem_MouseDown);
            // 
            // colURL
            // 
            this.colURL.Text = "URL";
            this.colURL.Width = 65;
            // 
            // colFullPath
            // 
            this.colFullPath.Text = "Full Path";
            this.colFullPath.Width = 65;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 74;
            // 
            // colSize
            // 
            this.colSize.Text = "Size";
            this.colSize.Width = 61;
            // 
            // coPriority
            // 
            this.coPriority.Text = "Priority";
            // 
            // colPagesCount
            // 
            this.colPagesCount.Text = "Pages";
            // 
            // colDesc
            // 
            this.colDesc.Text = "Desc";
            this.colDesc.Width = 124;
            // 
            // colNodeItemID
            // 
            this.colNodeItemID.Text = "Note";
            // 
            // colCitation
            // 
            this.colCitation.Text = "Citation";
            // 
            // colReferencesBib
            // 
            this.colReferencesBib.Text = "References Bib";
            // 
            // colImportantParts
            // 
            this.colImportantParts.Text = "Important Parts";
            // 
            // colAdditionDate
            // 
            this.colAdditionDate.Text = "Add Date";
            // 
            // btnDoSearch
            // 
            this.btnDoSearch.Location = new System.Drawing.Point(439, 122);
            this.btnDoSearch.Name = "btnDoSearch";
            this.btnDoSearch.Size = new System.Drawing.Size(76, 22);
            this.btnDoSearch.TabIndex = 45;
            this.btnDoSearch.Text = "Search";
            this.btnDoSearch.UseVisualStyleBackColor = true;
            this.btnDoSearch.Click += new System.EventHandler(this.btnDoSearch_Click);
            // 
            // FrmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1191, 564);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statMain);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FrmMain";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragOver);
            this.mnuStripWorkSpace.ResumeLayout(false);
            this.mnuStripStorageItem.ResumeLayout(false);
            this.mnuStripRef.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.statMain.ResumeLayout(false);
            this.statMain.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageCategory.ResumeLayout(false);
            this.splitContainerTree.Panel1.ResumeLayout(false);
            this.splitContainerTree.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTree)).EndInit();
            this.splitContainerTree.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainerReferenceTree.Panel1.ResumeLayout(false);
            this.splitContainerReferenceTree.Panel1.PerformLayout();
            this.splitContainerReferenceTree.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerReferenceTree)).EndInit();
            this.splitContainerReferenceTree.ResumeLayout(false);
            this.splitContainerSiteGroup.Panel1.ResumeLayout(false);
            this.splitContainerSiteGroup.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSiteGroup)).EndInit();
            this.splitContainerSiteGroup.ResumeLayout(false);
            this.splitContainerSimilarItems.Panel1.ResumeLayout(false);
            this.splitContainerSimilarItems.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSimilarItems)).EndInit();
            this.splitContainerSimilarItems.ResumeLayout(false);
            this.splitContainerGroupStorage.Panel1.ResumeLayout(false);
            this.splitContainerGroupStorage.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerGroupStorage)).EndInit();
            this.splitContainerGroupStorage.ResumeLayout(false);
            this.tabPageReference.ResumeLayout(false);
            this.tabPageReference.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPageGroupSite.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.splitContainerStorageItem.Panel1.ResumeLayout(false);
            this.splitContainerStorageItem.Panel1.PerformLayout();
            this.splitContainerStorageItem.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerStorageItem)).EndInit();
            this.splitContainerStorageItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.upDownPriority)).EndInit();
            this.mnuStripQuickList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ContextMenuStrip mnuStripWorkSpace;
        private ToolStripMenuItem newWorkSpaceToolStripMenuItem;
        private ImageList imgListForTVWorkSpace;
        private ContextMenuStrip mnuStripRef;
        private ToolStripMenuItem mnuItemOpenRef;
        private ToolStripMenuItem mnuItemRemoveRef;
        private ToolStripMenuItem mnuItemWindowsMenuRef;
        private ContextMenuStrip mnuStripStorageItem;
        private ToolStripMenuItem mnuItemOpenStorageItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem mnuItemNewStorageItem;
        private ToolStripMenuItem mnuItemEditStorageItem;
        private ToolStripMenuItem mnuItemDeleteStorageItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem mnuItemSetAsMainStorageItem;
        private ToolStripMenuItem mnuItemSetAsReference;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem mnuItemBrowseHostName;
        private ToolStripMenuItem mnuItemBrowseURL;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem mnuItemWindowsMenu;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator15;
        private ToolStripMenuItem mnuFileExit;
        private ToolStripMenuItem mnuTools;
        private ToolStripMenuItem mnuItemCustomReport;
        private ToolStrip toolStripMain;
        private ToolStripSeparator toolStripSeparator16;
        private FarsiLibrary.Win.FATabStrip tabControl;
        private FarsiLibrary.Win.FATabStripItem tabPageCategory;
        public SplitContainer splitContainerReferenceTree;
        private TextBox txtMainStorageItemDesc;
        public SplitContainer splitContainerSiteGroup;
        private TreeView tvOneSiteGroup;
        private TreeView tvRefView;
        private FarsiLibrary.Win.FATabStripItem tabPageReference;
        private TextBox txtMainDesc;
        private TextBox txtMainFullPath;
        private Label label9;
        private Label label8;
        private FarsiLibrary.Win.FATabStripItem tabPageGroupSite;
        private Button BtnGroupBySite;
        private TreeView tvSiteGroup;
        public SplitContainer splitContainerStorageItem;
        private ComboBox cmbPriorityOperand;
        private ComboBox cmbOrder;
        private NumericUpDown upDownPriority;
        private CtrlSearchContentProgress ctrlSearchContentProgress;
        private MyTextBox txtSearchContent;
        private Label label3;
        private MyTextBox txtSearchFileName;
        private MyTextBox txtSearchURL;
        private MyTextBox txtSearchDescription;
        private Label label5;
        private Label label7;
        private Label label6;
        private Label label4;
        private Label label1;
        private ColumnHeader colURL;
        private ColumnHeader colFullPath;
        private ColumnHeader colName;
        private ColumnHeader colSize;
        private ColumnHeader coPriority;
        private ColumnHeader colPagesCount;
        private ColumnHeader colDesc;
        private StatusStrip statMain;
        private ToolStripStatusLabel sslLine;
        private ToolStripStatusLabel sslColumn;
        private ToolStripStatusLabel sslInsert;
        private ToolStripStatusLabel sslOther;
        private FileOrganizer.CTRL.VistaButton btnSearchContent;
        public CtrlReferenceNavigator ctrlReferenceNavigator;
        public SplitContainer splitContainer;
        public ListViewStorage lstStorageItem;
        public SplitContainer splitContainerTree;
        private ToolStripSeparator toolStripSeparator18;
        private ToolStripMenuItem mnuItemOpenFolder;
        private ToolStripSeparator toolStripSeparator19;
        public CheckBox chkAllowLstStorageMultiSelect;
        private Panel panel1;
        private Panel panel2;
        public CheckBox chkSearchInAllCategories;
        private MyTextBox txtSearchReferencesBib;
        private Label label10;
        private MyTextBox txtSearchCitation;
        private Label label2;
        private ColumnHeader colCitation;
        private ColumnHeader colReferencesBib;
        private Button btnPercent;
        private Button btnAmpersand;
        private Button btnPaste;
        private Button btnClear;
        private Button btnSimilar;
        public SplitContainer splitContainerSimilarItems;
        private TreeView tvSimilarItems;
        public TreeViewWorkSpace tvWorkSpace;
        private ColumnHeader colImportantParts;
        private MyTextBox txtSearchImportantParts;
        private Label label11;
        private ToolStripSeparator toolStripSeparator20;
        private ToolStripMenuItem mnuItemCopy;
        private ToolStripMenuItem mnuItemPaste;
        private ToolStripMenuItem mnuItemPutInQList;
        private ToolStripSeparator toolStripSeparator21;
        private CtrlTargetArea ctrlTargetArea;
        public SplitContainer splitContainerGroupStorage;
        private ToolStripMenuItem mnuItemRefreshQuickLists;
        private ToolStripButton tsbCategories;
        private ColumnHeader colAdditionDate;
        private ToolStripStatusLabel sslTotal;
        private Label label12;
        public ComboBox cmbTopN;
        public ComboBox cmbSortType;
        private ToolStripMenuItem mnuItemGenerateReport;
        private ToolStripMenuItem mnuItemOptions;
        private MyTextBox txtFilter;
        private Label label13;
        private ToolStripStatusLabel sslFitered;
        private ColumnHeader colNodeItemID;
        private ToolStripSeparator toolStripSeparator23;
        private ToolStripMenuItem muuItemNote;
        private ToolStripMenuItem mnuItemRemoveNote;
        private ToolStripMenuItem mnuItemOpenNote;
        private ToolStripMenuItem mnuItemReomveStorageItem;
        private ToolStripMenuItem mnuItemAddToReport;
        private Label lblReportListCount;
        private Label label14;
        private Button btnEmptyList;
        private ToolStripMenuItem mnuItemOpenCopy;
        private NotifyIcon notifyIcon;
        private TextBox txtMainStorageItemDesc2;
        public CheckBox chkShowHint;
        private ContextMenuStrip mnuStripQuickList;
        private ToolStripMenuItem mnuItemLocateQuickList;
        private ToolStripMenuItem mnuItemLocateAll;
        private ToolStripMenuItem mnuItemRemoveQuikList;
        private ToolStripSeparator toolStripSeparator24;
        private ToolStripMenuItem mnuItemRefresh;
        private ToolStripMenuItem mnuItemColor;
        private ToolStripMenuItem mnuItemUnload;
        private ToolStripMenuItem mnuItemOpenQuickList;
        private Button btnPasteSimilar;
        private ToolStripSeparator toolStripSeparator25;
        private ToolStripMenuItem mnuItemSortByDescription;
        private ToolStripMenuItem mnuItemSortByFileName;
        private ToolStripMenuItem mnuItemSortByOrderOfAddition;
        private Panel panel3;
        private TreeViewRef tvRef;
        private Panel panel4;
        private ToolStripMenuItem mnuNewWindow;
        private ToolStripMenuItem mnuItemFileMove;
        private ToolStripMenuItem mnuItemEditWorkSpace;
        private ToolStripMenuItem mnuItemDeleteWorkspace;
        private ToolStripSeparator toolStripSeparator26;
        private ToolStripMenuItem mnuItemEditQListInfo;
        private ToolStripMenuItem mnuItemDeleteQList;
        private ToolStripMenuItem minimizeToTrayToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolTip toolTip1;
        private TreeViewAllQuickList treeViewAllQuickList;
        private ToolStripMenuItem mnuItemCheckForUpdate;
        private Button btnDoSearch;
    }
}

