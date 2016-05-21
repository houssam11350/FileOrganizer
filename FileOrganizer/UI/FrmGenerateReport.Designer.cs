namespace FileOrganizer.UI
{
    partial class FrmGenerateReport
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
            this.chkIsHyperLink = new System.Windows.Forms.CheckBox();
            this.chkCopyFiles = new System.Windows.Forms.CheckBox();
            this.chkSortByInferedYear = new System.Windows.Forms.CheckBox();
            this.chkID = new System.Windows.Forms.CheckBox();
            this.chkURL = new System.Windows.Forms.CheckBox();
            this.chkFullPath = new System.Windows.Forms.CheckBox();
            this.rdioFullList = new System.Windows.Forms.RadioButton();
            this.rdioReportList = new System.Windows.Forms.RadioButton();
            this.chkInferedYear = new System.Windows.Forms.CheckBox();
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
            // chkIsHyperLink
            // 
            this.chkIsHyperLink.AutoSize = true;
            this.chkIsHyperLink.Location = new System.Drawing.Point(86, 53);
            this.chkIsHyperLink.Name = "chkIsHyperLink";
            this.chkIsHyperLink.Size = new System.Drawing.Size(190, 17);
            this.chkIsHyperLink.TabIndex = 1;
            this.chkIsHyperLink.Text = "Generate With Hyper Link for Files";
            this.chkIsHyperLink.UseVisualStyleBackColor = true;
            // 
            // chkCopyFiles
            // 
            this.chkCopyFiles.AutoSize = true;
            this.chkCopyFiles.Location = new System.Drawing.Point(86, 76);
            this.chkCopyFiles.Name = "chkCopyFiles";
            this.chkCopyFiles.Size = new System.Drawing.Size(75, 17);
            this.chkCopyFiles.TabIndex = 1;
            this.chkCopyFiles.Text = "Copy Files";
            this.chkCopyFiles.UseVisualStyleBackColor = true;
            // 
            // chkSortByInferedYear
            // 
            this.chkSortByInferedYear.AutoSize = true;
            this.chkSortByInferedYear.Location = new System.Drawing.Point(86, 99);
            this.chkSortByInferedYear.Name = "chkSortByInferedYear";
            this.chkSortByInferedYear.Size = new System.Drawing.Size(125, 17);
            this.chkSortByInferedYear.TabIndex = 1;
            this.chkSortByInferedYear.Text = "Sort By Infered Year";
            this.chkSortByInferedYear.UseVisualStyleBackColor = true;
            // 
            // chkID
            // 
            this.chkID.AutoSize = true;
            this.chkID.Location = new System.Drawing.Point(86, 122);
            this.chkID.Name = "chkID";
            this.chkID.Size = new System.Drawing.Size(37, 17);
            this.chkID.TabIndex = 2;
            this.chkID.Text = "ID";
            this.chkID.UseVisualStyleBackColor = true;
            // 
            // chkURL
            // 
            this.chkURL.AutoSize = true;
            this.chkURL.Location = new System.Drawing.Point(86, 145);
            this.chkURL.Name = "chkURL";
            this.chkURL.Size = new System.Drawing.Size(45, 17);
            this.chkURL.TabIndex = 3;
            this.chkURL.Text = "URL";
            this.chkURL.UseVisualStyleBackColor = true;
            // 
            // chkFullPath
            // 
            this.chkFullPath.AutoSize = true;
            this.chkFullPath.Location = new System.Drawing.Point(86, 168);
            this.chkFullPath.Name = "chkFullPath";
            this.chkFullPath.Size = new System.Drawing.Size(67, 17);
            this.chkFullPath.TabIndex = 4;
            this.chkFullPath.Text = "Full Path";
            this.chkFullPath.UseVisualStyleBackColor = true;
            // 
            // rdioFullList
            // 
            this.rdioFullList.AutoSize = true;
            this.rdioFullList.Checked = true;
            this.rdioFullList.Location = new System.Drawing.Point(86, 0);
            this.rdioFullList.Name = "rdioFullList";
            this.rdioFullList.Size = new System.Drawing.Size(60, 17);
            this.rdioFullList.TabIndex = 5;
            this.rdioFullList.TabStop = true;
            this.rdioFullList.Text = "Full List";
            this.rdioFullList.UseVisualStyleBackColor = true;
            // 
            // rdioReportList
            // 
            this.rdioReportList.AutoSize = true;
            this.rdioReportList.Location = new System.Drawing.Point(86, 23);
            this.rdioReportList.Name = "rdioReportList";
            this.rdioReportList.Size = new System.Drawing.Size(77, 17);
            this.rdioReportList.TabIndex = 5;
            this.rdioReportList.Text = "Report List";
            this.rdioReportList.UseVisualStyleBackColor = true;
            // 
            // chkInferedYear
            // 
            this.chkInferedYear.AutoSize = true;
            this.chkInferedYear.Location = new System.Drawing.Point(86, 191);
            this.chkInferedYear.Name = "chkInferedYear";
            this.chkInferedYear.Size = new System.Drawing.Size(87, 17);
            this.chkInferedYear.TabIndex = 4;
            this.chkInferedYear.Text = "Infered Year";
            this.chkInferedYear.UseVisualStyleBackColor = true;
            // 
            // FrmGenerateReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 343);
            this.Controls.Add(this.rdioReportList);
            this.Controls.Add(this.rdioFullList);
            this.Controls.Add(this.chkInferedYear);
            this.Controls.Add(this.chkFullPath);
            this.Controls.Add(this.chkURL);
            this.Controls.Add(this.chkID);
            this.Controls.Add(this.chkSortByInferedYear);
            this.Controls.Add(this.chkCopyFiles);
            this.Controls.Add(this.chkIsHyperLink);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGenerateReport";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Generate Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.CheckBox chkIsHyperLink;
        private System.Windows.Forms.CheckBox chkCopyFiles;
        private System.Windows.Forms.CheckBox chkSortByInferedYear;
        private System.Windows.Forms.CheckBox chkID;
        private System.Windows.Forms.CheckBox chkURL;
        private System.Windows.Forms.CheckBox chkFullPath;
        private System.Windows.Forms.RadioButton rdioFullList;
        private System.Windows.Forms.RadioButton rdioReportList;
        private System.Windows.Forms.CheckBox chkInferedYear;
    }
}