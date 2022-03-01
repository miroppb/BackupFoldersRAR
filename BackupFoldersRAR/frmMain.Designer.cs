namespace BackupFoldersRAR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.LstFiles = new System.Windows.Forms.CheckedListBox();
            this.BtnBackup = new System.Windows.Forms.Button();
            this.TxtLocation = new System.Windows.Forms.TextBox();
            this.BtnRestore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LstFiles
            // 
            this.LstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LstFiles.CheckOnClick = true;
            this.LstFiles.FormattingEnabled = true;
            this.LstFiles.Location = new System.Drawing.Point(12, 38);
            this.LstFiles.Name = "LstFiles";
            this.LstFiles.Size = new System.Drawing.Size(633, 394);
            this.LstFiles.TabIndex = 8;
            this.LstFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LstFiles_KeyDown);
            // 
            // BtnBackup
            // 
            this.BtnBackup.Location = new System.Drawing.Point(397, 9);
            this.BtnBackup.Name = "BtnBackup";
            this.BtnBackup.Size = new System.Drawing.Size(121, 23);
            this.BtnBackup.TabIndex = 5;
            this.BtnBackup.Text = "Backup Selected Files";
            this.BtnBackup.UseVisualStyleBackColor = true;
            this.BtnBackup.Click += new System.EventHandler(this.BtnBackup_Click);
            // 
            // TxtLocation
            // 
            this.TxtLocation.Location = new System.Drawing.Point(12, 11);
            this.TxtLocation.Name = "TxtLocation";
            this.TxtLocation.Size = new System.Drawing.Size(379, 20);
            this.TxtLocation.TabIndex = 9;
            this.TxtLocation.Click += new System.EventHandler(this.TxtLocation_Click);
            // 
            // BtnRestore
            // 
            this.BtnRestore.Location = new System.Drawing.Point(524, 9);
            this.BtnRestore.Name = "BtnRestore";
            this.BtnRestore.Size = new System.Drawing.Size(121, 23);
            this.BtnRestore.TabIndex = 10;
            this.BtnRestore.Text = "Restore Selected Files";
            this.BtnRestore.UseVisualStyleBackColor = true;
            this.BtnRestore.Click += new System.EventHandler(this.BtnRestore_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 450);
            this.Controls.Add(this.BtnRestore);
            this.Controls.Add(this.TxtLocation);
            this.Controls.Add(this.LstFiles);
            this.Controls.Add(this.BtnBackup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Thing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox LstFiles;
        private System.Windows.Forms.Button BtnBackup;
        private System.Windows.Forms.TextBox TxtLocation;
        private System.Windows.Forms.Button BtnRestore;
    }
}

