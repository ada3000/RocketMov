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
            Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.cbConvert.Location = new System.Drawing.Point(608, 12);
            this.cbConvert.Name = "cbConvert";
            this.cbConvert.Size = new System.Drawing.Size(75, 23);
            this.cbConvert.TabIndex = 1;
            this.cbConvert.Text = "Convert";
            this.cbConvert.UseVisualStyleBackColor = true;
            this.cbConvert.Click += new System.EventHandler(this.cbConvert_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 554);
            this.Controls.Add(this.cbConvert);
            this.Controls.Add(this.lvFiles);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.Button cbConvert;
    }
}