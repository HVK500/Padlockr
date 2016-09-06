﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Prj_Padlockr.Properties;

namespace Prj_Padlockr.Forms
{
    public partial class MainWindow : Form
    {
        // - Create the instance that controls all the DB interactions
        internal IPadlockrDbContext DbContext;

        public MainWindow()
        {
            InitializeComponent();
            DbContext = new PadlockrDbContext(new SqliteWrapper());
        }
        
        private void mainWindow_Load(object sender, EventArgs e)
        {
            // Display current version
            lblVersion.Text = "v" + Assembly.GetExecutingAssembly().GetName().Version.ToString(2);

            //TODO: Optimise!
            // Show master password dialog if there is a default DB set
            if (string.IsNullOrWhiteSpace(Settings.Default.defaultDBpath) == false)
            {
                if (File.Exists(Settings.Default.defaultDBpath))
                {
                    var pbU = new passBoxUnlock();
                    var v = false;
                    while (v == false)
                    {
                        if (string.IsNullOrWhiteSpace(pbU.maskedMasterTextBox.Text) == false)
                        {
                            pbU.maskedMasterTextBox.Text = "";
                            pbU.lblPassVal.Text = Resources.PasswordIncorrect;
                        }
                        else
                        {
                            if (pbU.ShowDialog() == DialogResult.OK)
                            {
                                // Sets path and password
                                DbContext.SetConnectionStrings(Settings.Default.defaultDBpath, pbU.maskedMasterTextBox.Text);
                                // Check if it is the correct password
                                if (DbContext.PassCheck())
                                {
                                    // todo: move into db class
                                    PopulateListBox(DbContext.GetDataTable("SELECT ACC_NAME FROM PDB;"));
                                    // Enable the menu controls
                                    menuItemChangeMasterPassword.Enabled = true;
                                    // Disabled because the open DB is the default already
                                    menuItemSetDefaultDatabase.Enabled = false;
                                    v = true;
                                }
                            }
                            else // DialogResult.Cancel 
                            {
                                // Disabled because no current open DB to default
                                menuItemSetDefaultDatabase.Enabled = false;
                                // Default DB is not loaded
                                v = true;
                            }
                        }
                    }

                    return;
                }

                // Reset the default DB path to empty so that you don't get this message every time you startup padlockr
                Settings.Default.defaultDBpath = "";
                Settings.Default.Save();

                MessageBox.Show(Resources.DefaultDbNotLoaded, Resources.DefaultDbNotLoadedTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        //TODO: When DB is opened or created and there are no entries disable the listbox
        private void menuItemNewDatabase_Click(object sender, EventArgs e)
        {
            // Create a new database file through the file browser
            if (saveDatabaseDialog.ShowDialog() != DialogResult.OK)
                return;

            // Reset controls from the previously opened DB
            if (listBox.Items.Count != 0)
            {
                InitializeMainWindow();
            }

            // todo: rename to dbFileName / path
            // Set the DB directory to create and open
            var dbDir = saveDatabaseDialog.FileName;
                
            // Create a new passBoxLock instance to parse the password back from the firstMaskedTextBox
            var pbL = new PassBoxLock();

            if (pbL.ShowDialog() != DialogResult.OK)
                return;

            // Sets the DB Password and creates the PDB Table
            DbContext.InitializeDb(dbDir, pbL.firstMaskedTextBox.Text);

            if (MessageBox.Show(Resources.MakeDefaultDb, Resources.MakeDefaultDbTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Make the new DB the default
                Settings.Default.defaultDBpath = dbDir;
                Settings.Default.Save();
                menuItemChangeMasterPassword.Enabled = true;
                menuItemSetDefaultDatabase.Enabled = false;
            }
            else
            {
                menuItemChangeMasterPassword.Enabled = true;
                menuItemSetDefaultDatabase.Enabled = true;
            }

            // Open the brand new database (empty)
            // todo: move into db class
            PopulateListBox(DbContext.GetDataTable("SELECT ACC_NAME FROM PDB;"));

            // Change the title of the main window to display the name of the open DB
            Text = string.Format(Resources.WindowTitle, dbDir);
        }

        private void menuItemOpenDatabase_Click(object sender, EventArgs e)
        {
            // Open an existing DB through a file browser
            if (openDatabaseDialog.ShowDialog() != DialogResult.OK)
                return;

            // Reset controls from the previously opened DB
            if (listBox.Items.Count != 0)
            {
                InitializeMainWindow();
            }

            // todo: move into better place
            // todo: [Matt] What is V??
            var pbU = new passBoxUnlock();
            var v = false;

            while (v == false)
            {
                if (string.IsNullOrWhiteSpace(pbU.maskedMasterTextBox.Text) == false)
                {
                    pbU.maskedMasterTextBox.Text = string.Empty;
                    pbU.lblPassVal.Text = Resources.PasswordIncorrect;
                }
                else
                {
                    if (pbU.ShowDialog() == DialogResult.OK)
                    {
                        // Sets path and password
                        DbContext.SetConnectionStrings(openDatabaseDialog.FileName, pbU.maskedMasterTextBox.Text);

                        if (!DbContext.PassCheck())
                            continue;

                        // todo: move into db class
                        PopulateListBox(DbContext.GetDataTable("SELECT ACC_NAME FROM PDB;"));
                        
                        // Enable the menu controls
                        menuItemChangeMasterPassword.Enabled = true;
                        Text = string.Format(Resources.WindowTitle, openDatabaseDialog.FileName);

                        menuItemSetDefaultDatabase.Enabled = Settings.Default.defaultDBpath != openDatabaseDialog.FileName;
                        v = true;
                    }
                    else // DialogResult.Cancel 
                    {
                        // DB is not loaded
                        v = true;
                    }
                }
            }
        }

        private void menuItemSetDefaultDatabase_Click(object sender, EventArgs e)
        {
            // Set the open DB as the default DB
            if (MessageBox.Show(Resources.SetCurrentDbAsDefault, Resources.SetDefaultDb, MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            Settings.Default.defaultDBpath = Text.Substring(11, (Text.Length - 11));
            Settings.Default.Save();
            menuItemSetDefaultDatabase.Enabled = false;
        }

        private void menuItemChangeMasterPassword_Click(object sender, EventArgs e)
        {
            // Change your DB Master password
            var pBc = new PassBoxChange(DbContext);

            if (pBc.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(Resources.MasterPwdChangeSuccess, Resources.MasterPwdChanged, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNewEntry_Click(object sender, EventArgs e)
        {
            // Add new enties in to the PDB Table of the open DB - (Added constructor to pass the liteDB object through)
            var ne = new EntryAddBox(DbContext);

            if (ne.ShowDialog() == DialogResult.OK)
            {
                // Insert data in to the DB
                // todo: move into DB class
                DbContext.InsertData(ApoCleansing(ne.accNameTxtBox.Text), ApoCleansing(ne.userNameTxtBox.Text), ApoCleansing(ne.passMaskedTextBox.Text), ApoCleansing(ne.linkTxtBox.Text), ApoCleansing(ne.notesTxtBox.Text));
            }

            // todo: move into DB class
            // Repop the listbox
            PopulateListBox(DbContext.GetDataTable("SELECT ACC_NAME FROM PDB;"));

        }

        private void btnEditEntry_Click(object sender, EventArgs e)
        {
            // Edit enties in to the PDB Table of the open DB
            if (listBox.SelectedIndex == -1)
                return;

            // Change the title of the dialog to "Edit"
            var ee = new EntryAddBox(DbContext)
            {
                Text = Resources.EditEntry
            };

            //TODO: Optimise!
            // todo: move into DB class
            var dt = DbContext.GetDataTable("SELECT ACC_NAME, USER_NAME, PASS, LINK, NOTES FROM PDB WHERE ACC_NAME = '" + listBox.SelectedItem + "';");

            if (dt.Rows.Count == 0)
                return;

            // todo: move into DB class
            var dr = dt.Rows[dt.Rows.Count - 1];
            var oldAccName = dr["ACC_NAME"].ToString();

            // Print out the read information to the Edit Entry Box
            ee.accNameTxtBox.Text = oldAccName;
            ee.userNameTxtBox.Text = dr["USER_NAME"].ToString();
            ee.passMaskedTextBox.Text = dr["PASS"].ToString();
            ee.linkTxtBox.Text = dr["LINK"].ToString();
            ee.notesTxtBox.Text = dr["NOTES"].ToString();

            if (ee.ShowDialog() != DialogResult.OK)
                return;

            // todo: move into DB class
            // Capture the changes and send them to the DB
            DbContext.UpdateData(oldAccName, ApoCleansing(ee.userNameTxtBox.Text), ApoCleansing(ee.passMaskedTextBox.Text), ApoCleansing(ee.linkTxtBox.Text), ApoCleansing(ee.notesTxtBox.Text));
            PopulateListBox(DbContext.GetDataTable("SELECT ACC_NAME FROM PDB;"));

            listBox.SelectedIndex = -1;
            listBox_SelectedIndexChanged(sender, e);
        }

        private void btnDeleteEntry_Click(object sender, EventArgs e)
        {
            // Delete selected DB entry
            if (listBox.SelectedIndex == -1)
                return;

            var sf = listBox.SelectedItem.ToString();
            var confirmMsg = string.Format(Resources.DeleteEntryConfirm, sf);

            if (MessageBox.Show(confirmMsg, Resources.Delete, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            DbContext.DeleteData(sf);
            // todo: move into DB class
            PopulateListBox(DbContext.GetDataTable("SELECT ACC_NAME FROM PDB;"));

            if (listBox.Items.Count > 1)
                return;

            btnClearSearch.Enabled = false;
            lblSpyGlass.Enabled = false;
            btnVisitLink.Enabled = false;
            btnCopyPassword.Enabled = false;
            btnCopyUsername.Enabled = false;
            txtBoxSearch.Text = "";
            txtBoxSearch.Enabled = false;
            btnDeleteEntry.Enabled = false;
            btnEditEntry.Enabled = false;
            menuItemChangeMasterPassword.Enabled = false;
            menuItemSetDefaultDatabase.Enabled = false;

            if (listBox.Items.Count != 0)
                return;

            listBox.Items.Clear();
            listBox.Enabled = false;
        }

        // Handles the search feature
        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable dt;

            if (string.IsNullOrWhiteSpace(txtBoxSearch.Text) == false)
            {
                // todo: move into DB class
                dt = DbContext.GetDataTable("SELECT ACC_NAME FROM PDB WHERE ACC_NAME LIKE '%" + txtBoxSearch.Text + "%';");
                btnClearSearch.Enabled = true;
            }
            else
            {
                // todo: move into DB class
                dt = DbContext.GetDataTable("SELECT ACC_NAME FROM PDB;");
                btnClearSearch.Enabled = false;
            }

            // Output result to listbox
            PopulateListBox(dt);
            listBox.SelectedIndex = -1;
            listBox_SelectedIndexChanged(sender, e);
        }

        // Handles the control validation from selected listbox items
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                btnEditEntry.Enabled = true;
                btnDeleteEntry.Enabled = true;
                btnCopyPassword.Enabled = true;
                btnCopyUsername.Enabled = true;

                // Check whether the selected item has a link saved
                btnVisitLink.Enabled = string.IsNullOrWhiteSpace(GetColData("LINK")) == false;
                btnViewNotes.Enabled = string.IsNullOrWhiteSpace(GetColData("NOTES")) == false;
                
            }
            else if (listBox.SelectedIndex == -1)
            {
                btnEditEntry.Enabled = false;
                btnDeleteEntry.Enabled = false;
                btnCopyPassword.Enabled = false;
                btnCopyUsername.Enabled = false;
                btnVisitLink.Enabled = false;
                btnViewNotes.Enabled = false;
            }
        }

        // Open a read-only dialog to view the saved notes
        private void btnViewNotes_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                return;

            var vn = new viewNotesBox
            {
                notesTxtBox =
                {
                    Text = GetColData("NOTES")
                }
            };

            vn.ShowDialog();
        }

        // Opens up the link in the browser
        private void btnVisitLink_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                Process.Start(GetColData("LINK"));
            }
        }

        // Copies the Password of the selected DB item to the clipboard
        private void btnCopyPassword_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                Clipboard.SetText(GetColData("PASS"));
            }
        }

        // Copies the Username of the selected DB item to the clipboard
        private void btnCopyUsername_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                Clipboard.SetText(GetColData("USER_NAME"));
            }
        }

        // Clears the searchbox text
        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtBoxSearch.Text = "";
        }

        // Resets the controls back to the initial window
        private void InitializeMainWindow()
        {
            listBox.Items.Clear();
            listBox.Enabled = false;
            Text = "Padlockr";
            btnClearSearch.Enabled = false;
            lblSpyGlass.Enabled = false;
            btnViewNotes.Enabled = false;
            btnVisitLink.Enabled = false;
            btnCopyPassword.Enabled = false;
            btnCopyUsername.Enabled = false;
            txtBoxSearch.Text = "";
            txtBoxSearch.Enabled = false;
            btnDeleteEntry.Enabled = false;
            btnEditEntry.Enabled = false;
            btnNewEntry.Enabled = false;
            menuItemChangeMasterPassword.Enabled = false;
            menuItemSetDefaultDatabase.Enabled = false;
        }

        //TODO: Opitimise! Retrieve specific column data
        private string GetColData(string field)
        {
            // todo: move into DB class
            var dt = DbContext.GetDataTable("SELECT " + field + " FROM PDB WHERE ACC_NAME = '" + listBox.SelectedItem + "';");
            var dr = dt.Rows[dt.Rows.Count - 1];

            return dr[field].ToString();
        }

        //TODO: Opitimise! Populates the listbox when provided with a datatable
        private void PopulateListBox(DataTable dt)
        {
            // Check whether the DataTable has data to output
            if (dt.Rows.Count != 0)
            {
                // Clear the listbox of all items
                listBox.Items.Clear();

                // Cycle through the items in the give DataTable
                foreach (DataRow dr in dt.Rows)
                {
                    // Prints out the datatable items to the listbox
                    listBox.Items.Add(dr["ACC_NAME"].ToString());
                }

                // Enable controls - if there is data to edit and search
                if (dt.Rows.Count > 1 )
                {
                    lblSpyGlass.Enabled = true;
                    txtBoxSearch.Enabled = true;
                }
                else if (dt.Rows.Count == 1 && string.IsNullOrWhiteSpace(txtBoxSearch.Text))
                {
                    lblSpyGlass.Enabled = false;
                    txtBoxSearch.Enabled = false;
                }
            }

            // Enable controls
            btnNewEntry.Enabled = true;
            listBox.Enabled = true;
            listBox.SelectedIndex = -1;
        }

        // todo: move into helper method
        // Handles the doubling up of the apostrophe's in any password to prepare for DB insertion
        private static string ApoCleansing(string pass)
        {
            // Gets stores the password in the p
            var p = pass;
            // Counts the number of apostrophe's there are in the pass string
            var c = p.Split('\'').Length - 1;

            if (c == 0)
                return p;

            // New list to convert to an array to cycle through
            var pos = new List<int>();
            var temp = 0;

            // Assembles the list of the index postions of the apostrophe's
            for (var i = 0; i <= c - 1; i++)
            {
                pos.Add(p.IndexOf('\'', temp));
                temp = p.IndexOf('\'', temp) + 1;
            }

            // Converts the list to an array
            var n = pos.ToArray();

            // Cycle through the array and double up the apostrophe's - because SQLite uses the second apostrophe as an escape symbol
            for (var i = 0; i <= n.Length - 1; i++)
            {
                if (i != 0)
                {
                    // Apostrophe doubling up logic for all apostrophe's not in index 0
                    p = p.Insert(n[i] + i, "'");
                }
                else
                {
                    // Initial doubling at index 0
                    p = p.Insert(n[0], "'");
                }
            }

            // Return the resulting password
            return p;
        }
    }
}
