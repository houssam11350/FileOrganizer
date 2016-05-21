namespace FileOrganizer.UI
{
    partial class FrmStorageItem
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFullPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPriority = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCancelAll = new System.Windows.Forms.Button();
            this.lblFileIndex = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPagesCount = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.chkIsFixed = new System.Windows.Forms.CheckBox();
            this.lstCategory = new System.Windows.Forms.ListBox();
            this.btnCalcSizeName = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtCitation = new System.Windows.Forms.TextBox();
            this.txtReferencesBib = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtImportantParts = new System.Windows.Forms.TextBox();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnGetURL = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.pkrAdditionDate = new FileOrganizer.CTRL.NullableDateTimePicker();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtName.Location = new System.Drawing.Point(74, 80);
            this.txtName.Name = "txtName";
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtName.Size = new System.Drawing.Size(580, 20);
            this.txtName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label2.Location = new System.Drawing.Point(8, 82);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // txtID
            // 
            this.txtID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtID.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtID.Location = new System.Drawing.Point(74, 10);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtID.Size = new System.Drawing.Size(218, 20);
            this.txtID.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID";
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btnSave.Location = new System.Drawing.Point(91, 563);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtDescription.Location = new System.Drawing.Point(74, 127);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(580, 93);
            this.txtDescription.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label4.Location = new System.Drawing.Point(8, 149);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Description";
            // 
            // txtSize
            // 
            this.txtSize.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSize.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtSize.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtSize.Location = new System.Drawing.Point(74, 104);
            this.txtSize.Name = "txtSize";
            this.txtSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSize.Size = new System.Drawing.Size(120, 20);
            this.txtSize.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label3.Location = new System.Drawing.Point(8, 115);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Size";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label5.Location = new System.Drawing.Point(8, 56);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Full Path";
            // 
            // txtFullPath
            // 
            this.txtFullPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFullPath.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtFullPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtFullPath.Location = new System.Drawing.Point(74, 56);
            this.txtFullPath.Name = "txtFullPath";
            this.txtFullPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFullPath.Size = new System.Drawing.Size(508, 20);
            this.txtFullPath.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label6.Location = new System.Drawing.Point(8, 38);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "URL";
            // 
            // txtURL
            // 
            this.txtURL.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtURL.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtURL.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtURL.Location = new System.Drawing.Point(74, 33);
            this.txtURL.Name = "txtURL";
            this.txtURL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtURL.Size = new System.Drawing.Size(580, 20);
            this.txtURL.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label7.Location = new System.Drawing.Point(438, 106);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Priority";
            // 
            // txtPriority
            // 
            this.txtPriority.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPriority.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtPriority.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtPriority.Location = new System.Drawing.Point(484, 103);
            this.txtPriority.Name = "txtPriority";
            this.txtPriority.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPriority.Size = new System.Drawing.Size(169, 20);
            this.txtPriority.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btnCancel.Location = new System.Drawing.Point(217, 563);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCancelAll
            // 
            this.btnCancelAll.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancelAll.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btnCancelAll.Location = new System.Drawing.Point(371, 563);
            this.btnCancelAll.Name = "btnCancelAll";
            this.btnCancelAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCancelAll.Size = new System.Drawing.Size(75, 23);
            this.btnCancelAll.TabIndex = 6;
            this.btnCancelAll.Text = "&Cancel All";
            this.btnCancelAll.UseVisualStyleBackColor = true;
            this.btnCancelAll.Visible = false;
            this.btnCancelAll.Click += new System.EventHandler(this.btnCancelAll_Click);
            // 
            // lblFileIndex
            // 
            this.lblFileIndex.AutoSize = true;
            this.lblFileIndex.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFileIndex.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lblFileIndex.Location = new System.Drawing.Point(368, 544);
            this.lblFileIndex.Name = "lblFileIndex";
            this.lblFileIndex.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblFileIndex.Size = new System.Drawing.Size(110, 13);
            this.lblFileIndex.TabIndex = 8;
            this.lblFileIndex.Text = "File {0} from Files {1}";
            this.lblFileIndex.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Cursor = System.Windows.Forms.Cursors.Default;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label8.Location = new System.Drawing.Point(271, 106);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Pages";
            // 
            // txtPagesCount
            // 
            this.txtPagesCount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPagesCount.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtPagesCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtPagesCount.Location = new System.Drawing.Point(314, 103);
            this.txtPagesCount.Name = "txtPagesCount";
            this.txtPagesCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPagesCount.Size = new System.Drawing.Size(117, 20);
            this.txtPagesCount.TabIndex = 9;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblCategory.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lblCategory.Location = new System.Drawing.Point(601, 9);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCategory.Size = new System.Drawing.Size(52, 13);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Category";
            // 
            // chkIsFixed
            // 
            this.chkIsFixed.AutoSize = true;
            this.chkIsFixed.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkIsFixed.Font = new System.Drawing.Font("Tahoma", 8F);
            this.chkIsFixed.Location = new System.Drawing.Point(74, 540);
            this.chkIsFixed.Name = "chkIsFixed";
            this.chkIsFixed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkIsFixed.Size = new System.Drawing.Size(64, 17);
            this.chkIsFixed.TabIndex = 11;
            this.chkIsFixed.Text = "Is Fixed";
            this.chkIsFixed.UseVisualStyleBackColor = true;
            // 
            // lstCategory
            // 
            this.lstCategory.FormattingEnabled = true;
            this.lstCategory.Location = new System.Drawing.Point(660, 12);
            this.lstCategory.Name = "lstCategory";
            this.lstCategory.ScrollAlwaysVisible = true;
            this.lstCategory.Size = new System.Drawing.Size(197, 316);
            this.lstCategory.TabIndex = 13;
            // 
            // btnCalcSizeName
            // 
            this.btnCalcSizeName.Location = new System.Drawing.Point(200, 102);
            this.btnCalcSizeName.Name = "btnCalcSizeName";
            this.btnCalcSizeName.Size = new System.Drawing.Size(67, 23);
            this.btnCalcSizeName.TabIndex = 14;
            this.btnCalcSizeName.Text = "ReCalc";
            this.btnCalcSizeName.UseVisualStyleBackColor = true;
            this.btnCalcSizeName.Click += new System.EventHandler(this.btnCalcSizeName_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOpen.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btnOpen.Location = new System.Drawing.Point(578, 563);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 6;
            this.btnOpen.Text = "&Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtCitation
            // 
            this.txtCitation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCitation.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtCitation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtCitation.Location = new System.Drawing.Point(73, 223);
            this.txtCitation.Multiline = true;
            this.txtCitation.Name = "txtCitation";
            this.txtCitation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCitation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCitation.Size = new System.Drawing.Size(580, 81);
            this.txtCitation.TabIndex = 10;
            // 
            // txtReferencesBib
            // 
            this.txtReferencesBib.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtReferencesBib.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtReferencesBib.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtReferencesBib.Location = new System.Drawing.Point(73, 307);
            this.txtReferencesBib.Multiline = true;
            this.txtReferencesBib.Name = "txtReferencesBib";
            this.txtReferencesBib.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtReferencesBib.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReferencesBib.Size = new System.Drawing.Size(580, 110);
            this.txtReferencesBib.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Cursor = System.Windows.Forms.Cursors.Default;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label9.Location = new System.Drawing.Point(7, 233);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Citation";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Cursor = System.Windows.Forms.Cursors.Default;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label10.Location = new System.Drawing.Point(7, 326);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "References";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Cursor = System.Windows.Forms.Cursors.Default;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label11.Location = new System.Drawing.Point(7, 442);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Imp Parts";
            // 
            // txtImportantParts
            // 
            this.txtImportantParts.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtImportantParts.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtImportantParts.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtImportantParts.Location = new System.Drawing.Point(73, 423);
            this.txtImportantParts.Multiline = true;
            this.txtImportantParts.Name = "txtImportantParts";
            this.txtImportantParts.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtImportantParts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtImportantParts.Size = new System.Drawing.Size(580, 110);
            this.txtImportantParts.TabIndex = 10;
            // 
            // btnPause
            // 
            this.btnPause.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnPause.Font = new System.Drawing.Font("Tahoma", 8F);
            this.btnPause.Location = new System.Drawing.Point(464, 563);
            this.btnPause.Name = "btnPause";
            this.btnPause.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 6;
            this.btnPause.Text = "&Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Visible = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnGetURL
            // 
            this.btnGetURL.Location = new System.Drawing.Point(586, 56);
            this.btnGetURL.Name = "btnGetURL";
            this.btnGetURL.Size = new System.Drawing.Size(67, 23);
            this.btnGetURL.TabIndex = 14;
            this.btnGetURL.Text = "Get URL";
            this.btnGetURL.UseVisualStyleBackColor = true;
            this.btnGetURL.Click += new System.EventHandler(this.btnGetURL_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Cursor = System.Windows.Forms.Cursors.Default;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label12.Location = new System.Drawing.Point(659, 353);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Addition Date";
            // 
            // pkrAdditionDate
            // 
            this.pkrAdditionDate.CustomFormat = "dd  /  MM  /  yyyy";
            this.pkrAdditionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkrAdditionDate.Location = new System.Drawing.Point(737, 349);
            this.pkrAdditionDate.Name = "pkrAdditionDate";
            this.pkrAdditionDate.Size = new System.Drawing.Size(127, 20);
            this.pkrAdditionDate.TabIndex = 15;
            this.pkrAdditionDate.Value = new System.DateTime(2011, 8, 29, 14, 3, 10, 703);
            // 
            // FrmStorageItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(869, 595);
            this.Controls.Add(this.pkrAdditionDate);
            this.Controls.Add(this.btnGetURL);
            this.Controls.Add(this.btnCalcSizeName);
            this.Controls.Add(this.lstCategory);
            this.Controls.Add(this.chkIsFixed);
            this.Controls.Add(this.txtImportantParts);
            this.Controls.Add(this.txtReferencesBib);
            this.Controls.Add(this.txtCitation);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblFileIndex);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPagesCount);
            this.Controls.Add(this.txtPriority);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnCancelAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFullPath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmStorageItem";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Entry";
            this.Load += new System.EventHandler(this.FrmStorageItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFullPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPriority;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCancelAll;
        private System.Windows.Forms.Label lblFileIndex;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPagesCount;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.CheckBox chkIsFixed;
        private System.Windows.Forms.ListBox lstCategory;
        private System.Windows.Forms.Button btnCalcSizeName;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtCitation;
        private System.Windows.Forms.TextBox txtReferencesBib;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtImportantParts;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnGetURL;
        private System.Windows.Forms.Label label12;
        private FileOrganizer.CTRL.NullableDateTimePicker pkrAdditionDate;
    }
}