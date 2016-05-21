namespace FileOrganizer.UI
{
    partial class FrmReferenceDrag
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
            this.txtMainStorageName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtMainStorageDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSwap = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtRefStorageName = new System.Windows.Forms.TextBox();
            this.txtRefStorageDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMainStorageName
            // 
            this.txtMainStorageName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMainStorageName.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtMainStorageName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtMainStorageName.Location = new System.Drawing.Point(87, 19);
            this.txtMainStorageName.Name = "txtMainStorageName";
            this.txtMainStorageName.ReadOnly = true;
            this.txtMainStorageName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMainStorageName.Size = new System.Drawing.Size(406, 20);
            this.txtMainStorageName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btnSave.Location = new System.Drawing.Point(195, 291);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtMainStorageDesc
            // 
            this.txtMainStorageDesc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMainStorageDesc.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtMainStorageDesc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtMainStorageDesc.Location = new System.Drawing.Point(83, 44);
            this.txtMainStorageDesc.Multiline = true;
            this.txtMainStorageDesc.Name = "txtMainStorageDesc";
            this.txtMainStorageDesc.ReadOnly = true;
            this.txtMainStorageDesc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMainStorageDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMainStorageDesc.Size = new System.Drawing.Size(626, 60);
            this.txtMainStorageDesc.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label4.Location = new System.Drawing.Point(12, 54);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Description";
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btnCancel.Location = new System.Drawing.Point(432, 291);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMainStorageName);
            this.groupBox1.Controls.Add(this.txtMainStorageDesc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(728, 115);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Main Entry";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSwap);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 115);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(728, 43);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            // 
            // btnSwap
            // 
            this.btnSwap.Location = new System.Drawing.Point(274, 12);
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.Size = new System.Drawing.Size(75, 23);
            this.btnSwap.TabIndex = 0;
            this.btnSwap.Text = "Swap";
            this.btnSwap.UseVisualStyleBackColor = true;
            this.btnSwap.Click += new System.EventHandler(this.btnSwap_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtRefStorageName);
            this.groupBox2.Controls.Add(this.txtRefStorageDesc);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(728, 122);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reference";
            // 
            // txtRefStorageName
            // 
            this.txtRefStorageName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRefStorageName.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtRefStorageName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtRefStorageName.Location = new System.Drawing.Point(87, 19);
            this.txtRefStorageName.Name = "txtRefStorageName";
            this.txtRefStorageName.ReadOnly = true;
            this.txtRefStorageName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRefStorageName.Size = new System.Drawing.Size(406, 20);
            this.txtRefStorageName.TabIndex = 5;
            // 
            // txtRefStorageDesc
            // 
            this.txtRefStorageDesc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRefStorageDesc.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtRefStorageDesc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtRefStorageDesc.Location = new System.Drawing.Point(83, 44);
            this.txtRefStorageDesc.Multiline = true;
            this.txtRefStorageDesc.Name = "txtRefStorageDesc";
            this.txtRefStorageDesc.ReadOnly = true;
            this.txtRefStorageDesc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRefStorageDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRefStorageDesc.Size = new System.Drawing.Size(626, 62);
            this.txtRefStorageDesc.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label3.Location = new System.Drawing.Point(16, 23);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name";
            // 
            // FrmReferenceDrag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(728, 335);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReferenceDrag";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reference";
            this.Load += new System.EventHandler(this.FrmReferenceDrag_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtMainStorageName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtMainStorageDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtRefStorageName;
        private System.Windows.Forms.TextBox txtRefStorageDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSwap;
    }
}