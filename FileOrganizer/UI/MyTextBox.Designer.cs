namespace FileOrganizer.UI
{
    partial class MyTextBox
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
            this.myButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // myButton
            // 
            this.myButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.myButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.myButton.Location = new System.Drawing.Point(173, 0);
            this.myButton.MaximumSize = new System.Drawing.Size(23, 0);
            this.myButton.MinimumSize = new System.Drawing.Size(23, 0);
            this.myButton.Name = "myButton";
            this.myButton.Size = new System.Drawing.Size(23, 83);
            this.myButton.TabIndex = 1;
            this.myButton.UseVisualStyleBackColor = false;
            this.myButton.Click += new System.EventHandler(this.myButton_Click);
            this.myButton.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            // 
            // MyTextBox
            // 
            this.Margin = new System.Windows.Forms.Padding(0);
            this.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Size = new System.Drawing.Size(196, 83);
            this.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button myButton;
    }
}
