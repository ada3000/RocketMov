namespace RocketMov
{
    partial class frmMain
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
            System.Windows.Forms.ColumnHeader Name;
            System.Windows.Forms.ColumnHeader Size;
            System.Windows.Forms.ColumnHeader Status;
            System.Windows.Forms.ColumnHeader Id;
            this.lvFiles = new System.Windows.Forms.ListView();
            this.cbConvert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbVideoBitrate = new System.Windows.Forms.ComboBox();
            this.cbVideoSize = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbCurrent = new System.Windows.Forms.ProgressBar();
            this.cbStop = new System.Windows.Forms.Button();
            this.txtFileError = new System.Windows.Forms.TextBox();
            Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Name
            // 
            Name.Text = "Name";
            Name.Width = 180;
            // 
            // Size
            // 
            Size.Text = "Size";
            Size.Width = 80;
            // 
            // Status
            // 
            Status.Text = "Status";
            Status.Width = 100;
            // 
            // Id
            // 
            Id.Text = "Id";
            Id.Width = 40;
            // 
            // lvFiles
            // 
            this.lvFiles.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvFiles.AllowDrop = true;
            this.lvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            Id,
            Name,
            Size,
            Status});
            this.lvFiles.FullRowSelect = true;
            this.lvFiles.GridLines = true;
            this.lvFiles.HideSelection = false;
            this.lvFiles.Location = new System.Drawing.Point(0, 0);
            this.lvFiles.MultiSelect = false;
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(412, 554);
            this.lvFiles.TabIndex = 0;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
            this.lvFiles.SelectedIndexChanged += new System.EventHandler(this.lvFiles_SelectedIndexChanged);
            this.lvFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvFiles_DragDrop);
            this.lvFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvFiles_DragEnter);
            // 
            // cbConvert
            // 
            this.cbConvert.Location = new System.Drawing.Point(418, 117);
            this.cbConvert.Name = "cbConvert";
            this.cbConvert.Size = new System.Drawing.Size(75, 23);
            this.cbConvert.TabIndex = 1;
            this.cbConvert.Text = "Convert";
            this.cbConvert.UseVisualStyleBackColor = true;
            this.cbConvert.Click += new System.EventHandler(this.cbConvert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Size";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbVideoBitrate);
            this.groupBox1.Controls.Add(this.cbVideoSize);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(418, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 99);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Video";
            // 
            // cbVideoBitrate
            // 
            this.cbVideoBitrate.FormattingEnabled = true;
            this.cbVideoBitrate.Items.AddRange(new object[] {
            "8192",
            "4096",
            "1024",
            "512",
            "256"});
            this.cbVideoBitrate.Location = new System.Drawing.Point(65, 59);
            this.cbVideoBitrate.Name = "cbVideoBitrate";
            this.cbVideoBitrate.Size = new System.Drawing.Size(121, 24);
            this.cbVideoBitrate.TabIndex = 6;
            this.cbVideoBitrate.Text = "4096";
            this.cbVideoBitrate.SelectedIndexChanged += new System.EventHandler(this.cbVideoBitrate_SelectedIndexChanged);
            this.cbVideoBitrate.TextUpdate += new System.EventHandler(this.cbVideoBitrate_TextUpdate);
            // 
            // cbVideoSize
            // 
            this.cbVideoSize.FormattingEnabled = true;
            this.cbVideoSize.Items.AddRange(new object[] {
            "1902x1080",
            "1280x720",
            "720x1280"});
            this.cbVideoSize.Location = new System.Drawing.Point(65, 25);
            this.cbVideoSize.Name = "cbVideoSize";
            this.cbVideoSize.Size = new System.Drawing.Size(121, 24);
            this.cbVideoSize.TabIndex = 5;
            this.cbVideoSize.Text = "1280x720";
            this.cbVideoSize.SelectedIndexChanged += new System.EventHandler(this.cbVideoSize_SelectedIndexChanged);
            this.cbVideoSize.TextUpdate += new System.EventHandler(this.cbVideoSize_TextUpdate);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bitrate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "K";
            // 
            // pbCurrent
            // 
            this.pbCurrent.Location = new System.Drawing.Point(427, 193);
            this.pbCurrent.Name = "pbCurrent";
            this.pbCurrent.Size = new System.Drawing.Size(376, 23);
            this.pbCurrent.TabIndex = 4;
            // 
            // cbStop
            // 
            this.cbStop.Enabled = false;
            this.cbStop.Location = new System.Drawing.Point(499, 117);
            this.cbStop.Name = "cbStop";
            this.cbStop.Size = new System.Drawing.Size(75, 23);
            this.cbStop.TabIndex = 5;
            this.cbStop.Text = "Stop";
            this.cbStop.UseVisualStyleBackColor = true;
            this.cbStop.Click += new System.EventHandler(this.cbStop_Click);
            // 
            // txtFileError
            // 
            this.txtFileError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileError.Location = new System.Drawing.Point(427, 222);
            this.txtFileError.Multiline = true;
            this.txtFileError.Name = "txtFileError";
            this.txtFileError.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFileError.Size = new System.Drawing.Size(494, 320);
            this.txtFileError.TabIndex = 6;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 554);
            this.Controls.Add(this.txtFileError);
            this.Controls.Add(this.cbStop);
            this.Controls.Add(this.pbCurrent);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbConvert);
            this.Controls.Add(this.lvFiles);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.Button cbConvert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbVideoBitrate;
        private System.Windows.Forms.ComboBox cbVideoSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar pbCurrent;
        private System.Windows.Forms.Button cbStop;
        private System.Windows.Forms.TextBox txtFileError;
    }
}