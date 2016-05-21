namespace FileOrganizer.UI
{
    partial class CtrlSearchContentProgress
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
            this.prgFiles = new System.Windows.Forms.ProgressBar();
            this.lblTotalFiles = new System.Windows.Forms.Label();
            this.lblFilesFound = new System.Windows.Forms.Label();
            this.btnStop = new FileOrganizer.CTRL.VistaButton();
            this.SuspendLayout();
            // 
            // prgFiles
            // 
            this.prgFiles.Location = new System.Drawing.Point(6, 9);
            this.prgFiles.MarqueeAnimationSpeed = 1;
            this.prgFiles.Name = "prgFiles";
            this.prgFiles.Size = new System.Drawing.Size(299, 13);
            this.prgFiles.Step = 1;
            this.prgFiles.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgFiles.TabIndex = 0;
            // 
            // lblTotalFiles
            // 
            this.lblTotalFiles.AutoSize = true;
            this.lblTotalFiles.Location = new System.Drawing.Point(311, 8);
            this.lblTotalFiles.Name = "lblTotalFiles";
            this.lblTotalFiles.Size = new System.Drawing.Size(52, 13);
            this.lblTotalFiles.TabIndex = 2;
            this.lblTotalFiles.Text = "xxxx/xxxx";
            // 
            // lblFilesFound
            // 
            this.lblFilesFound.AutoSize = true;
            this.lblFilesFound.Location = new System.Drawing.Point(379, 9);
            this.lblFilesFound.Name = "lblFilesFound";
            this.lblFilesFound.Size = new System.Drawing.Size(60, 13);
            this.lblFilesFound.TabIndex = 2;
            this.lblFilesFound.Text = "Found:xxxx";
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.BackColor = System.Drawing.Color.Transparent;
            this.btnStop.BaseColor = System.Drawing.Color.Transparent;
            this.btnStop.ButtonColor = System.Drawing.Color.Silver;
            this.btnStop.ButtonText = "Stop";
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.Black;
            this.btnStop.Location = new System.Drawing.Point(475, 2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(63, 27);
            this.btnStop.TabIndex = 26;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // CtrlSearchContentProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblFilesFound);
            this.Controls.Add(this.lblTotalFiles);
            this.Controls.Add(this.prgFiles);
            this.Name = "CtrlSearchContentProgress";
            this.Size = new System.Drawing.Size(543, 31);
            this.Load += new System.EventHandler(this.FrmSearchContentProgress_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar prgFiles;
        private System.Windows.Forms.Label lblTotalFiles;
        private System.Windows.Forms.Label lblFilesFound;
        private FileOrganizer.CTRL.VistaButton btnStop;
    }
}