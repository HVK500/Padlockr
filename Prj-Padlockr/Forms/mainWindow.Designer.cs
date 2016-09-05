namespace Prj_Padlockr.Forms
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpenDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemChangeMasterPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSetDefaultDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnNewEntry = new System.Windows.Forms.ToolStripButton();
            this.btnEditEntry = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteEntry = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCopyUsername = new System.Windows.Forms.ToolStripButton();
            this.btnCopyPassword = new System.Windows.Forms.ToolStripButton();
            this.btnVisitLink = new System.Windows.Forms.ToolStripButton();
            this.btnViewNotes = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblSpyGlass = new System.Windows.Forms.ToolStripLabel();
            this.txtBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.btnClearSearch = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.listBox = new System.Windows.Forms.ListBox();
            this.saveDatabaseDialog = new System.Windows.Forms.SaveFileDialog();
            this.openDatabaseDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.databaseToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(384, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNewDatabase,
            this.menuItemOpenDatabase,
            this.toolStripSeparator1,
            this.menuItemExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // menuItemNewDatabase
            // 
            this.menuItemNewDatabase.Image = global::Prj_Padlockr.Properties.Resources.DB_Create;
            this.menuItemNewDatabase.Name = "menuItemNewDatabase";
            this.menuItemNewDatabase.Size = new System.Drawing.Size(154, 22);
            this.menuItemNewDatabase.Text = "New Database";
            this.menuItemNewDatabase.Click += new System.EventHandler(this.menuItemNewDatabase_Click);
            // 
            // menuItemOpenDatabase
            // 
            this.menuItemOpenDatabase.Image = global::Prj_Padlockr.Properties.Resources.DB_Open;
            this.menuItemOpenDatabase.Name = "menuItemOpenDatabase";
            this.menuItemOpenDatabase.Size = new System.Drawing.Size(154, 22);
            this.menuItemOpenDatabase.Text = "Open Database";
            this.menuItemOpenDatabase.Click += new System.EventHandler(this.menuItemOpenDatabase_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(151, 6);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Image = global::Prj_Padlockr.Properties.Resources.Exit;
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(154, 22);
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemChangeMasterPassword,
            this.menuItemSetDefaultDatabase});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // menuItemChangeMasterPassword
            // 
            this.menuItemChangeMasterPassword.Enabled = false;
            this.menuItemChangeMasterPassword.Name = "menuItemChangeMasterPassword";
            this.menuItemChangeMasterPassword.Size = new System.Drawing.Size(207, 22);
            this.menuItemChangeMasterPassword.Text = "Change Master Password";
            this.menuItemChangeMasterPassword.Click += new System.EventHandler(this.menuItemChangeMasterPassword_Click);
            // 
            // menuItemSetDefaultDatabase
            // 
            this.menuItemSetDefaultDatabase.Enabled = false;
            this.menuItemSetDefaultDatabase.Name = "menuItemSetDefaultDatabase";
            this.menuItemSetDefaultDatabase.Size = new System.Drawing.Size(207, 22);
            this.menuItemSetDefaultDatabase.Text = "Set Default Database";
            this.menuItemSetDefaultDatabase.Click += new System.EventHandler(this.menuItemSetDefaultDatabase_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.GripMargin = new System.Windows.Forms.Padding(1);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewEntry,
            this.btnEditEntry,
            this.btnDeleteEntry,
            this.toolStripSeparator2,
            this.btnCopyUsername,
            this.btnCopyPassword,
            this.btnVisitLink,
            this.btnViewNotes,
            this.toolStripSeparator3,
            this.lblSpyGlass,
            this.txtBoxSearch,
            this.btnClearSearch});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(384, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip";
            // 
            // btnNewEntry
            // 
            this.btnNewEntry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNewEntry.Enabled = false;
            this.btnNewEntry.Image = global::Prj_Padlockr.Properties.Resources.New;
            this.btnNewEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewEntry.Name = "btnNewEntry";
            this.btnNewEntry.Size = new System.Drawing.Size(23, 22);
            this.btnNewEntry.Text = "New entry";
            this.btnNewEntry.Click += new System.EventHandler(this.btnNewEntry_Click);
            // 
            // btnEditEntry
            // 
            this.btnEditEntry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditEntry.Enabled = false;
            this.btnEditEntry.Image = global::Prj_Padlockr.Properties.Resources.Edit;
            this.btnEditEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditEntry.Name = "btnEditEntry";
            this.btnEditEntry.Size = new System.Drawing.Size(23, 22);
            this.btnEditEntry.Text = "Edit entry";
            this.btnEditEntry.Click += new System.EventHandler(this.btnEditEntry_Click);
            // 
            // btnDeleteEntry
            // 
            this.btnDeleteEntry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteEntry.Enabled = false;
            this.btnDeleteEntry.Image = global::Prj_Padlockr.Properties.Resources.Delete;
            this.btnDeleteEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteEntry.Name = "btnDeleteEntry";
            this.btnDeleteEntry.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteEntry.Text = "Delete entry";
            this.btnDeleteEntry.Click += new System.EventHandler(this.btnDeleteEntry_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCopyUsername
            // 
            this.btnCopyUsername.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCopyUsername.Enabled = false;
            this.btnCopyUsername.Image = global::Prj_Padlockr.Properties.Resources.CopyU;
            this.btnCopyUsername.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopyUsername.Name = "btnCopyUsername";
            this.btnCopyUsername.Size = new System.Drawing.Size(23, 22);
            this.btnCopyUsername.Text = "Copy username to clipboard";
            this.btnCopyUsername.Click += new System.EventHandler(this.btnCopyUsername_Click);
            // 
            // btnCopyPassword
            // 
            this.btnCopyPassword.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCopyPassword.Enabled = false;
            this.btnCopyPassword.Image = global::Prj_Padlockr.Properties.Resources.CopyP;
            this.btnCopyPassword.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopyPassword.Name = "btnCopyPassword";
            this.btnCopyPassword.Size = new System.Drawing.Size(23, 22);
            this.btnCopyPassword.Text = "Copy password to clipboard";
            this.btnCopyPassword.Click += new System.EventHandler(this.btnCopyPassword_Click);
            // 
            // btnVisitLink
            // 
            this.btnVisitLink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnVisitLink.Enabled = false;
            this.btnVisitLink.Image = global::Prj_Padlockr.Properties.Resources.Link;
            this.btnVisitLink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVisitLink.Name = "btnVisitLink";
            this.btnVisitLink.Size = new System.Drawing.Size(23, 22);
            this.btnVisitLink.Text = "Open url in browser";
            this.btnVisitLink.Click += new System.EventHandler(this.btnVisitLink_Click);
            // 
            // btnViewNotes
            // 
            this.btnViewNotes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnViewNotes.Enabled = false;
            this.btnViewNotes.Image = global::Prj_Padlockr.Properties.Resources.Notes;
            this.btnViewNotes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewNotes.Name = "btnViewNotes";
            this.btnViewNotes.Size = new System.Drawing.Size(23, 22);
            this.btnViewNotes.Text = "View notes";
            this.btnViewNotes.Click += new System.EventHandler(this.btnViewNotes_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // lblSpyGlass
            // 
            this.lblSpyGlass.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lblSpyGlass.Enabled = false;
            this.lblSpyGlass.Image = global::Prj_Padlockr.Properties.Resources.SpyGlass;
            this.lblSpyGlass.Name = "lblSpyGlass";
            this.lblSpyGlass.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.lblSpyGlass.Size = new System.Drawing.Size(22, 22);
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxSearch.Enabled = false;
            this.txtBoxSearch.MaxLength = 255;
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(155, 25);
            this.txtBoxSearch.TextChanged += new System.EventHandler(this.txtBoxSearch_TextChanged);
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClearSearch.Enabled = false;
            this.btnClearSearch.Image = global::Prj_Padlockr.Properties.Resources.Clear;
            this.btnClearSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(23, 22);
            this.btnClearSearch.Text = "Clear Search";
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblVersion});
            this.statusStrip.Location = new System.Drawing.Point(0, 380);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(384, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 6F);
            this.lblVersion.ForeColor = System.Drawing.Color.Gray;
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(20, 17);
            this.lblVersion.Text = "v*.**";
            // 
            // listBox
            // 
            this.listBox.Enabled = false;
            this.listBox.Location = new System.Drawing.Point(12, 52);
            this.listBox.Name = "listBox";
            this.listBox.ScrollAlwaysVisible = true;
            this.listBox.Size = new System.Drawing.Size(360, 316);
            this.listBox.Sorted = true;
            this.listBox.TabIndex = 0;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // saveDatabaseDialog
            // 
            this.saveDatabaseDialog.Filter = "DB Files|*.db";
            this.saveDatabaseDialog.Title = "Create New Database";
            // 
            // openDatabaseDialog
            // 
            this.openDatabaseDialog.Filter = "DB Files|*.db";
            this.openDatabaseDialog.Title = "Open Existing Database";
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 402);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Padlockr";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.mainWindow_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewDatabase;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpenDatabase;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemChangeMasterPassword;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnNewEntry;
        private System.Windows.Forms.ToolStripButton btnDeleteEntry;
        private System.Windows.Forms.ToolStripButton btnEditEntry;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnCopyUsername;
        private System.Windows.Forms.ToolStripButton btnCopyPassword;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblVersion;
        private System.Windows.Forms.ToolStripButton btnVisitLink;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel lblSpyGlass;
        private System.Windows.Forms.ToolStripTextBox txtBoxSearch;
        private System.Windows.Forms.ToolStripButton btnClearSearch;
        private System.Windows.Forms.ToolStripMenuItem menuItemSetDefaultDatabase;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.SaveFileDialog saveDatabaseDialog;
        private System.Windows.Forms.OpenFileDialog openDatabaseDialog;
        private System.Windows.Forms.ToolStripButton btnViewNotes;
    }
}

