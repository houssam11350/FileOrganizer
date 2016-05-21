namespace FileOrganizer.UI
{
    partial class FrmQuickListEdit
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
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.chkIsInTollbar = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(266, 66);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 35);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(22, 16);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(72, 13);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.Text = "Q Lick Name:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(73, 66);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 35);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(100, 13);
            this.txtLName.Name = "txtLName";
            this.txtLName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLName.Size = new System.Drawing.Size(319, 20);
            this.txtLName.TabIndex = 2;
            // 
            // chkIsInTollbar
            // 
            this.chkIsInTollbar.AutoSize = true;
            this.chkIsInTollbar.Location = new System.Drawing.Point(100, 43);
            this.chkIsInTollbar.Name = "chkIsInTollbar";
            this.chkIsInTollbar.Size = new System.Drawing.Size(91, 17);
            this.chkIsInTollbar.TabIndex = 3;
            this.chkIsInTollbar.Text = "Is In Toolbar?";
            this.chkIsInTollbar.UseVisualStyleBackColor = true;
            // 
            // FrmQuickListEdit
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(431, 111);
            this.Controls.Add(this.chkIsInTollbar);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmQuickListEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quick List";
            this.Load += new System.EventHandler(this.FrmQuickListEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.CheckBox chkIsInTollbar;
    }
}