namespace NightreignSaveManager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.bttn_save = new System.Windows.Forms.Button();
            this.bttn_restoreSaves = new System.Windows.Forms.Button();
            this.listBackups = new System.Windows.Forms.ListBox();
            this.txtLogs = new System.Windows.Forms.RichTextBox();
            this.bttn_deleteSelected = new System.Windows.Forms.Button();
            this.bttn_deleteAll = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuItem_clearLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_openBackupFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_gitRepository = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // bttn_save
            // 
            this.bttn_save.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bttn_save.Location = new System.Drawing.Point(794, 26);
            this.bttn_save.Name = "bttn_save";
            this.bttn_save.Size = new System.Drawing.Size(171, 45);
            this.bttn_save.TabIndex = 0;
            this.bttn_save.Text = "Save";
            this.bttn_save.UseVisualStyleBackColor = true;
            this.bttn_save.Click += new System.EventHandler(this.bttn_save_Click);
            // 
            // bttn_restoreSaves
            // 
            this.bttn_restoreSaves.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bttn_restoreSaves.Location = new System.Drawing.Point(794, 77);
            this.bttn_restoreSaves.Name = "bttn_restoreSaves";
            this.bttn_restoreSaves.Size = new System.Drawing.Size(171, 45);
            this.bttn_restoreSaves.TabIndex = 1;
            this.bttn_restoreSaves.Text = "Restore Save";
            this.bttn_restoreSaves.UseVisualStyleBackColor = true;
            this.bttn_restoreSaves.Click += new System.EventHandler(this.bttn_restoreSaves_Click);
            // 
            // listBackups
            // 
            this.listBackups.FormattingEnabled = true;
            this.listBackups.ItemHeight = 15;
            this.listBackups.Location = new System.Drawing.Point(395, 26);
            this.listBackups.Name = "listBackups";
            this.listBackups.Size = new System.Drawing.Size(393, 259);
            this.listBackups.TabIndex = 2;
            // 
            // txtLogs
            // 
            this.txtLogs.HideSelection = false;
            this.txtLogs.Location = new System.Drawing.Point(12, 26);
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ReadOnly = true;
            this.txtLogs.Size = new System.Drawing.Size(377, 259);
            this.txtLogs.TabIndex = 3;
            this.txtLogs.Text = "";
            this.txtLogs.WordWrap = false;
            // 
            // bttn_deleteSelected
            // 
            this.bttn_deleteSelected.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bttn_deleteSelected.Location = new System.Drawing.Point(794, 128);
            this.bttn_deleteSelected.Name = "bttn_deleteSelected";
            this.bttn_deleteSelected.Size = new System.Drawing.Size(171, 45);
            this.bttn_deleteSelected.TabIndex = 4;
            this.bttn_deleteSelected.Text = "Delete Selected";
            this.bttn_deleteSelected.UseVisualStyleBackColor = true;
            this.bttn_deleteSelected.Click += new System.EventHandler(this.bttn_deleteSelected_Click);
            // 
            // bttn_deleteAll
            // 
            this.bttn_deleteAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bttn_deleteAll.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bttn_deleteAll.Location = new System.Drawing.Point(794, 239);
            this.bttn_deleteAll.Name = "bttn_deleteAll";
            this.bttn_deleteAll.Size = new System.Drawing.Size(171, 45);
            this.bttn_deleteAll.TabIndex = 5;
            this.bttn_deleteAll.Text = "DeleteAll";
            this.bttn_deleteAll.UseVisualStyleBackColor = false;
            this.bttn_deleteAll.Click += new System.EventHandler(this.bttn_deleteAll_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_clearLogs,
            this.MenuItem_openBackupFolder,
            this.MenuItem_gitRepository});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(977, 24);
            this.menuStrip.TabIndex = 6;
            this.menuStrip.Text = "menuStrip";
            // 
            // MenuItem_clearLogs
            // 
            this.MenuItem_clearLogs.Name = "MenuItem_clearLogs";
            this.MenuItem_clearLogs.Size = new System.Drawing.Size(74, 20);
            this.MenuItem_clearLogs.Text = "Clear Logs";
            this.MenuItem_clearLogs.Click += new System.EventHandler(this.MenuItem_clearLogs_Click);
            // 
            // MenuItem_openBackupFolder
            // 
            this.MenuItem_openBackupFolder.Name = "MenuItem_openBackupFolder";
            this.MenuItem_openBackupFolder.Size = new System.Drawing.Size(126, 20);
            this.MenuItem_openBackupFolder.Text = "Open Backup Folder";
            this.MenuItem_openBackupFolder.Click += new System.EventHandler(this.MenuItem_openBackupFolder_Click);
            // 
            // MenuItem_gitRepository
            // 
            this.MenuItem_gitRepository.Name = "MenuItem_gitRepository";
            this.MenuItem_gitRepository.Size = new System.Drawing.Size(93, 20);
            this.MenuItem_gitRepository.Text = "Git Repository";
            this.MenuItem_gitRepository.Click += new System.EventHandler(this.MenuItem_gitRepository_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 314);
            this.Controls.Add(this.bttn_deleteAll);
            this.Controls.Add(this.bttn_deleteSelected);
            this.Controls.Add(this.txtLogs);
            this.Controls.Add(this.listBackups);
            this.Controls.Add(this.bttn_restoreSaves);
            this.Controls.Add(this.bttn_save);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Nightreign Save Manager";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button bttn_save;
        private Button bttn_restoreSaves;
        private ListBox listBackups;
        private RichTextBox txtLogs;
        private Button bttn_deleteSelected;
        private Button bttn_deleteAll;
        private MenuStrip menuStrip;
        private ToolStripMenuItem MenuItem_clearLogs;
        private ToolStripMenuItem MenuItem_openBackupFolder;
        private ToolStripMenuItem MenuItem_gitRepository;
    }
}