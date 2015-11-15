using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Prj_Padlockr
{
    public partial class mainWindow : Form
    {

        public mainWindow()
        {
            InitializeComponent();
        }

        // - Create the instance that controls all the DB interactions
        internal SQLiteHandler liteDB = new SQLiteHandler();

        private void mainWindow_Load(object sender, EventArgs e)
        {
            // Display current version
            lblVersion.Text = "v" + Assembly.GetExecutingAssembly().GetName().Version.ToString(2);

            //TODO: Optimise!
            // Show master password dialog if there is a default DB set
            if (String.IsNullOrWhiteSpace(Properties.Settings.Default.defaultDBpath) == false)
            {
                if (File.Exists(Properties.Settings.Default.defaultDBpath) == true)
                {
                    passBoxUnlock pbU = new passBoxUnlock();
                    bool v = false;
                    while (v == false)
                    {
                        if (String.IsNullOrWhiteSpace(pbU.maskedMasterTextBox.Text) == false)
                        {
                            pbU.maskedMasterTextBox.Text = "";
                            pbU.lblPassVal.Text = "Password incorrect!";
                        }
                        else
                        {
                            if (pbU.ShowDialog() == DialogResult.OK)
                            {
                                // Sets path and password
                                liteDB.DBUnlock(Properties.Settings.Default.defaultDBpath, pbU.maskedMasterTextBox.Text);
                                // Check if it is the correct password
                                if (liteDB.passCheck() == true)
                                {
                                    populateListBox(liteDB.GetDataTable("SELECT ACC_NAME FROM PDB;"));
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
                }
                else
                {
                    // Reset the default DB path to empty so that you don't get this message everytime you startup padlockr
                    Properties.Settings.Default.defaultDBpath = "";
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Default database could not be loaded. The database has been Deleted, Moved or Renamed. Set a new default database via the \"Set Default Database\" under the \"Database\" menu item.", "Problem Opening Default Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            new aboutBox().ShowDialog();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //TODO: When DB is opened or created and there are no entries disable the listbox
        private void menuItemNewDatabase_Click(object sender, EventArgs e)
        {
            // Create a new database file through the file browser
            if (saveDatabaseDialog.ShowDialog() == DialogResult.OK)
            {
                // Reset controls from the previously opened DB
                if (listBox.Items.Count != 0)
                {
                    initializeMainWindow();
                }

                // Set the DB directory to create and open
                string dbDir = saveDatabaseDialog.FileName;
                
                // Create a new passBoxLock instance to parse the password back from the firstMaskedTextBox
                passBoxLock pbL = new passBoxLock();
                if (pbL.ShowDialog() == DialogResult.OK)
                {
                    // Sets the DB Password and creates the PDB Table
                    liteDB.InitializeDB(dbDir, pbL.firstMaskedTextBox.Text);
                    if (MessageBox.Show("Would you like to set the new database to your default?", "Set Default Database", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //Make the new DB the default
                        Properties.Settings.Default.defaultDBpath = dbDir;
                        Properties.Settings.Default.Save();
                        menuItemChangeMasterPassword.Enabled = true;
                        menuItemSetDefaultDatabase.Enabled = false;
                    }
                    else
                    {
                        menuItemChangeMasterPassword.Enabled = true;
                        menuItemSetDefaultDatabase.Enabled = true;
                    }

                    // Open the brand new database (empty)
                    populateListBox(liteDB.GetDataTable("SELECT ACC_NAME FROM PDB;"));
                    // Change the title of the main window to display the name of the open DB
                    Text = "Padlockr - " + dbDir;
                }
            }
        }

        private void menuItemOpenDatabase_Click(object sender, EventArgs e)
        {

            // Open an exsisting DB through a file browser
            if (openDatabaseDialog.ShowDialog() == DialogResult.OK)
            {
                // Reset controls from the previously opened DB
                if (listBox.Items.Count != 0)
                {
                    initializeMainWindow();
                }

                passBoxUnlock pbU = new passBoxUnlock();
                bool v = false;
                while (v == false)
                {
                    if (String.IsNullOrWhiteSpace(pbU.maskedMasterTextBox.Text) == false)
                    {
                        pbU.maskedMasterTextBox.Text = "";
                        pbU.lblPassVal.Text = "Password incorrect!";
                    }
                    else
                    {
                        if (pbU.ShowDialog() == DialogResult.OK)
                        {
                            // Sets path and password
                            liteDB.DBUnlock(openDatabaseDialog.FileName, pbU.maskedMasterTextBox.Text);

                            if (liteDB.passCheck() == true)
                            {
                                populateListBox(liteDB.GetDataTable("SELECT ACC_NAME FROM PDB;"));
                                // Enable the menu controls
                                menuItemChangeMasterPassword.Enabled = true;
                                Text = "Padlockr - " + openDatabaseDialog.FileName;
                                if (Properties.Settings.Default.defaultDBpath != openDatabaseDialog.FileName)
                                {
                                    menuItemSetDefaultDatabase.Enabled = true;
                                }
                                else
                                {
                                    menuItemSetDefaultDatabase.Enabled = false;
                                }
                                v = true;
                            }
                        }
                        else // DialogResult.Cancel 
                        {
                            // DB is not loaded
                            v = true;
                        }
                    }
                }
            }
        }

        private void menuItemSetDefaultDatabase_Click(object sender, EventArgs e)
        {
            // Set the open DB as the default DB
            if (MessageBox.Show("Set current database as your default?", "Set Default Database", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Properties.Settings.Default.defaultDBpath = Text.Substring(11, (Text.Length - 11));
                Properties.Settings.Default.Save();
                menuItemSetDefaultDatabase.Enabled = false;
            }
        }

        private void menuItemChangeMasterPassword_Click(object sender, EventArgs e)
        {
            // Change your DB Master password
            passBoxChange pBc = new passBoxChange(liteDB);
            if (pBc.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Master password has been successfully changed.", "Master Password Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNewEntry_Click(object sender, EventArgs e)
        {
            // Add new enties in to the PDB Table of the open DB - (Added constructor to pass the liteDB object through)
            entryAddBox ne = new entryAddBox(liteDB);
            if (ne.ShowDialog() == DialogResult.OK)
            {
                liteDB.InsertData(ne.accNameTxtBox.Text, ne.userNameTxtBox.Text, ne.passMaskedTextBox.Text, ne.linkTxtBox.Text, ne.notesTxtBox.Text);
            }

            populateListBox(liteDB.GetDataTable("SELECT ACC_NAME FROM PDB;"));

        }

        private void btnEditEntry_Click(object sender, EventArgs e)
        {
            // Edit enties in to the PDB Table of the open DB
            if (listBox.SelectedIndex != -1)
            {
                entryAddBox ee = new entryAddBox(liteDB);
                // Change the title of the dialog to "Edit"
                ee.Text = "Edit Entry";

                //TODO: Optimise!
                DataTable dt = liteDB.GetDataTable("SELECT ACC_NAME, USER_NAME, PASS, LINK, NOTES FROM PDB WHERE ACC_NAME = '" + listBox.SelectedItem.ToString() + "';");
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[dt.Rows.Count - 1];
                    string oldAccName = dr["ACC_NAME"].ToString();

                    // Print out the read information to the Edit Entry Box
                    ee.accNameTxtBox.Text = oldAccName;
                    ee.userNameTxtBox.Text = dr["USER_NAME"].ToString();
                    ee.passMaskedTextBox.Text = dr["PASS"].ToString();
                    ee.linkTxtBox.Text = dr["LINK"].ToString();
                    ee.notesTxtBox.Text = dr["NOTES"].ToString();

                    if (ee.ShowDialog() == DialogResult.OK)
                    {
                        // Capture the changes and send them to the DB
                        liteDB.UpdateData(oldAccName, ee.userNameTxtBox.Text, ee.passMaskedTextBox.Text, ee.linkTxtBox.Text, ee.notesTxtBox.Text);
                        populateListBox(liteDB.GetDataTable("SELECT ACC_NAME FROM PDB;"));

                        listBox.SelectedIndex = -1;
                        listBox_SelectedIndexChanged(sender, e);
                    }
                }
            }
        }

        private void btnDeleteEntry_Click(object sender, EventArgs e)
        {
            // Delete selected DB entry
            if (listBox.SelectedIndex != -1)
            {
                string sf = listBox.SelectedItem.ToString();
                if (MessageBox.Show("Permanently delete entry \"" + sf + "\"?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    liteDB.DeleteData(sf);
                    populateListBox(liteDB.GetDataTable("SELECT ACC_NAME FROM PDB;"));

                    if (listBox.Items.Count <= 1)
                    {
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

                        if (listBox.Items.Count == 0)
                        {
                            listBox.Items.Clear();
                            listBox.Enabled = false;
                        }
                    }
                }
            }
        }

        // Handles the search feature
        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = null;

            if (String.IsNullOrWhiteSpace(txtBoxSearch.Text) == false)
            {
                dt = liteDB.GetDataTable("SELECT ACC_NAME FROM PDB WHERE ACC_NAME LIKE '%" + txtBoxSearch.Text + "%';");
                btnClearSearch.Enabled = true;
            }
            else
            {
                dt = liteDB.GetDataTable("SELECT ACC_NAME FROM PDB;");
                btnClearSearch.Enabled = false;
            }

            // Output result to listbox
            populateListBox(dt);
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
                if (String.IsNullOrWhiteSpace(getColData("LINK")) == false)
                {
                    btnVisitLink.Enabled = true;
                }
                else
                {
                    btnVisitLink.Enabled = false;
                }
                if (String.IsNullOrWhiteSpace(getColData("NOTES")) == false)
                {
                    btnViewNotes.Enabled = true;
                }
                else
                {
                    btnViewNotes.Enabled = false;
                }
                
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
            if (listBox.SelectedIndex != -1)
            {
                viewNotesBox vn = new viewNotesBox();
                vn.notesTxtBox.Text = getColData("NOTES");
                vn.ShowDialog();
            }
        }

        // Opens up the link in the browser
        private void btnVisitLink_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                Process.Start(getColData("LINK"));
            }
        }

        // Copies the Password of the selected DB item to the clipboard
        private void btnCopyPassword_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                Clipboard.SetText(getColData("PASS"));
            }
        }

        // Copies the Username of the selected DB item to the clipboard
        private void btnCopyUsername_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                Clipboard.SetText(getColData("USER_NAME"));
            }
        }

        // Clears the searchbox text
        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtBoxSearch.Text = "";
        }

        // Resets the controls back to the initial window
        private void initializeMainWindow()
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
        private string getColData(string field)
        {
            DataTable dt = liteDB.GetDataTable("SELECT " + field + " FROM PDB WHERE ACC_NAME = '" + listBox.SelectedItem.ToString() + "';");
            DataRow dr = dt.Rows[dt.Rows.Count - 1];

            return dr[field].ToString();
        }

        //TODO: Opitimise! Populates the listbox when provided with a datatable
        private void populateListBox(DataTable dt)
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
                else if (dt.Rows.Count == 1 && String.IsNullOrWhiteSpace(txtBoxSearch.Text) == true)
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
    }
}
