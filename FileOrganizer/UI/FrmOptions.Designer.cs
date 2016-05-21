namespace FileOrganizer.UI
{
    partial class FrmOptions
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
            this.btnOK = new System.Windows.Forms.Button();
            this.chkIsSameSiteLoad = new System.Windows.Forms.CheckBox();
            this.chkIsSimilarItemsLoad = new System.Windows.Forms.CheckBox();
            this.chkIsQuickListLoad = new System.Windows.Forms.CheckBox();
            this.chkIDM = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 109);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(93, 109);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkIsSameSiteLoad
            // 
            this.chkIsSameSiteLoad.AutoSize = true;
            this.chkIsSameSiteLoad.Location = new System.Drawing.Point(31, 16);
            this.chkIsSameSiteLoad.Name = "chkIsSameSiteLoad";
            this.chkIsSameSiteLoad.Size = new System.Drawing.Size(112, 17);
            this.chkIsSameSiteLoad.TabIndex = 1;
            this.chkIsSameSiteLoad.Text = "Is Same Site Load";
            this.chkIsSameSiteLoad.UseVisualStyleBackColor = true;
            // 
            // chkIsSimilarItemsLoad
            // 
            this.chkIsSimilarItemsLoad.AutoSize = true;
            this.chkIsSimilarItemsLoad.Location = new System.Drawing.Point(31, 39);
            this.chkIsSimilarItemsLoad.Name = "chkIsSimilarItemsLoad";
            this.chkIsSimilarItemsLoad.Size = new System.Drawing.Size(122, 17);
            this.chkIsSimilarItemsLoad.TabIndex = 1;
            this.chkIsSimilarItemsLoad.Text = "Is Similar Items Load";
            this.chkIsSimilarItemsLoad.UseVisualStyleBackColor = true;
            // 
            // chkIsQuickListLoad
            // 
            this.chkIsQuickListLoad.AutoSize = true;
            this.chkIsQuickListLoad.Location = new System.Drawing.Point(31, 62);
            this.chkIsQuickListLoad.Name = "chkIsQuickListLoad";
            this.chkIsQuickListLoad.Size = new System.Drawing.Size(116, 17);
            this.chkIsQuickListLoad.TabIndex = 1;
            this.chkIsQuickListLoad.Text = "Is Quick Lists Load";
            this.chkIsQuickListLoad.UseVisualStyleBackColor = true;
            // 
            // chkIDM
            // 
            this.chkIDM.AutoSize = true;
            this.chkIDM.Location = new System.Drawing.Point(31, 81);
            this.chkIDM.Name = "chkIDM";
            this.chkIDM.Size = new System.Drawing.Size(309, 17);
            this.chkIDM.TabIndex = 2;
            this.chkIDM.Text = "Load URLs from Internet Download Manager (IDM) registery";
            this.chkIDM.UseVisualStyleBackColor = true;
            // 
            // FrmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 165);
            this.Controls.Add(this.chkIDM);
            this.Controls.Add(this.chkIsQuickListLoad);
            this.Controls.Add(this.chkIsSimilarItemsLoad);
            this.Controls.Add(this.chkIsSameSiteLoad);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOptions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.FrmOptions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkIsSameSiteLoad;
        private System.Windows.Forms.CheckBox chkIsSimilarItemsLoad;
        private System.Windows.Forms.CheckBox chkIsQuickListLoad;
        private System.Windows.Forms.CheckBox chkIDM;
    }
}