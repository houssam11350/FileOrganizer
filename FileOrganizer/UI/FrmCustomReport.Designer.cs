namespace FileOrganizer.UI
{
    partial class FrmCustomReport
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lstStorage = new FileOrganizer.UI.ListViewStorage();
            this.colURL = new System.Windows.Forms.ColumnHeader();
            this.colFullPath = new System.Windows.Forms.ColumnHeader();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colSize = new System.Windows.Forms.ColumnHeader();
            this.coPriority = new System.Windows.Forms.ColumnHeader();
            this.colPagesCount = new System.Windows.Forms.ColumnHeader();
            this.colDesc = new System.Windows.Forms.ColumnHeader();
            this.colCitation = new System.Windows.Forms.ColumnHeader();
            this.colReferencesBib = new System.Windows.Forms.ColumnHeader();
            this.colImportantParts = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(70, 295);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(396, 295);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lstStorage
            // 
            this.lstStorage.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstStorage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colURL,
            this.colFullPath,
            this.colName,
            this.colSize,
            this.coPriority,
            this.colPagesCount,
            this.colDesc,
            this.colCitation,
            this.colReferencesBib,
            this.colImportantParts});
            this.lstStorage.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstStorage.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lstStorage.FullRowSelect = true;
            this.lstStorage.GridLines = true;
            this.lstStorage.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstStorage.HideSelection = false;
            this.lstStorage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lstStorage.Location = new System.Drawing.Point(12, 12);
            this.lstStorage.MultiSelect = false;
            this.lstStorage.Name = "lstStorage";
            this.lstStorage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstStorage.Size = new System.Drawing.Size(748, 264);
            this.lstStorage.TabIndex = 19;
            this.lstStorage.UseCompatibleStateImageBehavior = false;
            this.lstStorage.View = System.Windows.Forms.View.Details;
            this.lstStorage.DoubleClick += new System.EventHandler(this.lstStorage_DoubleClick);
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
            // FrmCustomReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 343);
            this.Controls.Add(this.lstStorage);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCustomReport";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Custom Report";
            this.Load += new System.EventHandler(this.FrmCustomReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnGenerate;
        public ListViewStorage lstStorage;
        private System.Windows.Forms.ColumnHeader colURL;
        private System.Windows.Forms.ColumnHeader colFullPath;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ColumnHeader coPriority;
        private System.Windows.Forms.ColumnHeader colPagesCount;
        private System.Windows.Forms.ColumnHeader colDesc;
        private System.Windows.Forms.ColumnHeader colCitation;
        private System.Windows.Forms.ColumnHeader colReferencesBib;
        private System.Windows.Forms.ColumnHeader colImportantParts;
    }
}