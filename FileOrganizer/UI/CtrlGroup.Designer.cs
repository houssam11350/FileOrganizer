namespace FileOrganizer.UI
{
    partial class CtrlGroup
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mnuStripGroup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemLocateGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemRemoveGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.mTreeViewGroup = new FileOrganizer.UI.TreeViewGroup();
            this.mnuStripGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuStripGroup
            // 
            this.mnuStripGroup.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.mnuStripGroup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mnuStripGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemLocateGroup,
            this.mnuItemRemoveGroup});
            this.mnuStripGroup.Name = "mnuStripWorkSpace";
            this.mnuStripGroup.Size = new System.Drawing.Size(114, 48);
            // 
            // mnuItemLocateGroup
            // 
            this.mnuItemLocateGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuItemLocateGroup.Name = "mnuItemLocateGroup";
            this.mnuItemLocateGroup.Size = new System.Drawing.Size(113, 22);
            this.mnuItemLocateGroup.Text = "Locate";
            this.mnuItemLocateGroup.Click += new System.EventHandler(this.mnuItemLocateGroup_Click);
            // 
            // mnuItemRemoveGroup
            // 
            this.mnuItemRemoveGroup.Name = "mnuItemRemoveGroup";
            this.mnuItemRemoveGroup.Size = new System.Drawing.Size(113, 22);
            this.mnuItemRemoveGroup.Text = "Remove";
            this.mnuItemRemoveGroup.Click += new System.EventHandler(this.mnuItemRemoveGroup_Click);
            // 
            // mTreeViewGroup
            // 
            this.mTreeViewGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTreeViewGroup.ImageIndex = 0;
            this.mTreeViewGroup.ListViewStorage = null;
            this.mTreeViewGroup.Location = new System.Drawing.Point(0, 0);
            this.mTreeViewGroup.Margin = new System.Windows.Forms.Padding(0);
            this.mTreeViewGroup.Name = "mTreeViewGroup";
            this.mTreeViewGroup.SelectedImageIndex = 0;
            this.mTreeViewGroup.Size = new System.Drawing.Size(223, 281);
            this.mTreeViewGroup.StorageItem = null;
            this.mTreeViewGroup.TabIndex = 1;
            this.mTreeViewGroup.TargetColor = System.Drawing.Color.Orange;
            this.mTreeViewGroup.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mTreeViewGroup_MouseUp);
            // 
            // CtrlGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mTreeViewGroup);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CtrlGroup";
            this.Size = new System.Drawing.Size(223, 281);
            this.mnuStripGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip mnuStripGroup;
        private System.Windows.Forms.ToolStripMenuItem mnuItemLocateGroup;
        private System.Windows.Forms.ToolStripMenuItem mnuItemRemoveGroup;
        private TreeViewGroup mTreeViewGroup;
    }
}
