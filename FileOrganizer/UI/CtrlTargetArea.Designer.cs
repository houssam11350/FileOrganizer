namespace FileOrganizer.UI
{
    partial class CtrlTargetArea
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
            this.lblTarget = new System.Windows.Forms.Label();
            this.mnuStripTargetArea = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemDoDrag = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPasteFileNames = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStripTargetArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTarget
            // 
            this.lblTarget.BackColor = System.Drawing.Color.Lime;
            this.lblTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTarget.Location = new System.Drawing.Point(5, 5);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(105, 48);
            this.lblTarget.TabIndex = 0;
            this.lblTarget.Text = "Dragged Files = 0";
            this.lblTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mnuStripTargetArea
            // 
            this.mnuStripTargetArea.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.mnuStripTargetArea.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mnuStripTargetArea.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemDoDrag,
            this.mnuItemPasteFileNames,
            this.mnuItemClear});
            this.mnuStripTargetArea.Name = "mnuStripWorkSpace";
            this.mnuStripTargetArea.Size = new System.Drawing.Size(114, 70);
            // 
            // mnuItemDoDrag
            // 
            this.mnuItemDoDrag.Name = "mnuItemDoDrag";
            this.mnuItemDoDrag.Size = new System.Drawing.Size(113, 22);
            this.mnuItemDoDrag.Text = "Do Drag";
            this.mnuItemDoDrag.Click += new System.EventHandler(this.mnuItemDoDrag_Click);
            // 
            // mnuItemPasteFileNames
            // 
            this.mnuItemPasteFileNames.Name = "mnuItemPasteFileNames";
            this.mnuItemPasteFileNames.Size = new System.Drawing.Size(113, 22);
            this.mnuItemPasteFileNames.Text = "Paste";
            this.mnuItemPasteFileNames.Click += new System.EventHandler(this.mnuItemPasteFileNames_Click);
            // 
            // mnuItemClear
            // 
            this.mnuItemClear.Name = "mnuItemClear";
            this.mnuItemClear.Size = new System.Drawing.Size(113, 22);
            this.mnuItemClear.Text = "Clear";
            this.mnuItemClear.Click += new System.EventHandler(this.mnuItemClear_Click);
            // 
            // CtrlTargetArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.mnuStripTargetArea;
            this.Controls.Add(this.lblTarget);
            this.Name = "CtrlTargetArea";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(115, 58);
            this.mnuStripTargetArea.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.ContextMenuStrip mnuStripTargetArea;
        private System.Windows.Forms.ToolStripMenuItem mnuItemDoDrag;
        private System.Windows.Forms.ToolStripMenuItem mnuItemClear;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPasteFileNames;
    }
}
