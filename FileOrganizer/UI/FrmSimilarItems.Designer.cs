namespace FileOrganizer.UI
{
    partial class FrmSimilarItems
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDontSave = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCheckSimilarStorageItems = new System.Windows.Forms.Button();
            this.lstStorageItem = new FileOrganizer.UI.ListViewStorage();
            this.colURL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFullPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coPriority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPagesCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNoteItemID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCitation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReferencesBib = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colImportantParts = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btnSave.Location = new System.Drawing.Point(191, 363);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDontSave
            // 
            this.btnDontSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDontSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDontSave.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btnDontSave.Location = new System.Drawing.Point(319, 363);
            this.btnDontSave.Name = "btnDontSave";
            this.btnDontSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDontSave.Size = new System.Drawing.Size(75, 23);
            this.btnDontSave.TabIndex = 6;
            this.btnDontSave.Text = "&DONT Save";
            this.btnDontSave.UseVisualStyleBackColor = true;
            this.btnDontSave.Click += new System.EventHandler(this.btnDontSave_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtDescription.Location = new System.Drawing.Point(103, 3);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(572, 75);
            this.txtDescription.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label4.Location = new System.Drawing.Point(24, 28);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Description";
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btnClose.Location = new System.Drawing.Point(435, 363);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCheckSimilarStorageItems
            // 
            this.btnCheckSimilarStorageItems.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCheckSimilarStorageItems.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btnCheckSimilarStorageItems.Location = new System.Drawing.Point(681, 12);
            this.btnCheckSimilarStorageItems.Name = "btnCheckSimilarStorageItems";
            this.btnCheckSimilarStorageItems.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCheckSimilarStorageItems.Size = new System.Drawing.Size(75, 23);
            this.btnCheckSimilarStorageItems.TabIndex = 6;
            this.btnCheckSimilarStorageItems.Text = "Check";
            this.btnCheckSimilarStorageItems.UseVisualStyleBackColor = true;
            this.btnCheckSimilarStorageItems.Click += new System.EventHandler(this.btnCheckSimilarStorageItems_Click);
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
            this.colNoteItemID,
            this.colCitation,
            this.colReferencesBib,
            this.colImportantParts});
            this.lstStorageItem.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstStorageItem.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lstStorageItem.FullRowSelect = true;
            this.lstStorageItem.GridLines = true;
            this.lstStorageItem.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstStorageItem.HideSelection = false;
            this.lstStorageItem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lstStorageItem.Location = new System.Drawing.Point(12, 84);
            this.lstStorageItem.MultiSelect = false;
            this.lstStorageItem.Name = "lstStorageItem";
            this.lstStorageItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstStorageItem.Size = new System.Drawing.Size(736, 264);
            this.lstStorageItem.TabIndex = 18;
            this.lstStorageItem.UseCompatibleStateImageBehavior = false;
            this.lstStorageItem.View = System.Windows.Forms.View.Details;
            this.lstStorageItem.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.lstStorageItem_ColumnWidthChanged);
            this.lstStorageItem.DoubleClick += new System.EventHandler(this.lstStorageItem_DoubleClick);
            // 
            // colURL
            // 
            this.colURL.Text = "URL";
            this.colURL.Width = 57;
            // 
            // colFullPath
            // 
            this.colFullPath.Text = "Full Path";
            this.colFullPath.Width = 80;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 128;
            // 
            // colSize
            // 
            this.colSize.Text = "Size";
            this.colSize.Width = 46;
            // 
            // coPriority
            // 
            this.coPriority.Text = "Priority";
            this.coPriority.Width = 53;
            // 
            // colPagesCount
            // 
            this.colPagesCount.Text = "Pages";
            this.colPagesCount.Width = 45;
            // 
            // colDesc
            // 
            this.colDesc.Text = "Desc";
            this.colDesc.Width = 273;
            // 
            // colNoteItemID
            // 
            this.colNoteItemID.Text = "Note";
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
            // FrmSimilarItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnDontSave;
            this.ClientSize = new System.Drawing.Size(760, 398);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstStorageItem);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDontSave);
            this.Controls.Add(this.btnCheckSimilarStorageItems);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSimilarItems";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Similar Entries";
            this.Load += new System.EventHandler(this.FrmSimilarItems_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDontSave;
        public ListViewStorage lstStorageItem;
        private System.Windows.Forms.ColumnHeader colURL;
        private System.Windows.Forms.ColumnHeader colFullPath;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ColumnHeader coPriority;
        private System.Windows.Forms.ColumnHeader colPagesCount;
        private System.Windows.Forms.ColumnHeader colDesc;
        private System.Windows.Forms.ColumnHeader colCitation;
        private System.Windows.Forms.ColumnHeader colReferencesBib;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnCheckSimilarStorageItems;
        private System.Windows.Forms.ColumnHeader colImportantParts;
        private System.Windows.Forms.ColumnHeader colNoteItemID;
    }
}