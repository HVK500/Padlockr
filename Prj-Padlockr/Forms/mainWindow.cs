using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
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
        SQLiteDatabase liteDB = new SQLiteDatabase();

        private void mainWindow_Load(object sender, EventArgs e)
        {
            // Display current version
            lblVersion.Text = "v" + Assembly.GetExecutingAssembly().GetName().Version.ToString(2);

            // Show master password dialog if there is a default DB set
            if (String.IsNullOrWhiteSpace(Properties.Settings.Default.defaultDBpath) == false && Properties.Settings.Default.defaultDBset == true)
            {
                passBoxUnlock pbU = new passBoxUnlock();
                bool v = false;
                while (v == false)
                {
                    if (String.IsNullOrWhiteSpace(pbU.maskedMasterTextBox.Text) == false)
                    {
                        pbU.maskedMasterTextBox.Text = "";
                        pbU.lblPassVal.Text = "Password Incorrect!";
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
                                menuItemSetDefaultDatabase.Enabled = true;
                                v = true;
                            }
                        }
                        else // DialogResult.Cancel 
                        {
                            // It is possible to change the path of the default DB if canceled
                            menuItemSetDefaultDatabase.Enabled = true;
                            // Default DB is not loaded
                            v = true;
                        }
                    }
                    
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

        private void menuItemNewDatabase_Click(object sender, EventArgs e)
        {
            // Create a new database file through the file browser
            if (saveDatabaseDialog.ShowDialog() == DialogResult.OK)
            {
                // Reset controls from the previously opened DB
                if (listBox.Items.Count != 0)
                {
                    listBox.Items.Clear();
                    Text = "Padlockr";
                    btnClearSearch.Enabled = false;
                    lblSpyGlass.Enabled = false;
                    btnVisitLink.Enabled = false;
                    btnCopyPassword.Enabled = false;
                    btnCopyUsername.Enabled = false;
                    txtBoxSearch.Text = "";
                    txtBoxSearch.Enabled = false;
                    btnDeleteEntry.Enabled = false;
                    btnEditEntry.Enabled = false;
                    btnNewEntry.Enabled = false;
                }

                // Set the database directory to create and open
                string dbDir = saveDatabaseDialog.FileName;
                SQLiteConnection.CreateFile(dbDir);
                // Create a new passBoxLock instance to parse the password back from the firstMaskedTextBox
                passBoxLock pbL = new passBoxLock();
                if (pbL.ShowDialog() == DialogResult.OK)
                {
                    // Sets the DB Password and creates the PDB Table
                    liteDB.InitializeDB(dbDir, pbL.firstMaskedTextBox.Text);
                    if (MessageBox.Show("Would you like to set the new database to your default?", "Set new database to default", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //Make the new DB the default
                        Properties.Settings.Default.defaultDBpath = dbDir;
                        Properties.Settings.Default.defaultDBset = true;
                        Properties.Settings.Default.Save();
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
                    listBox.Items.Clear();
                    Text = "Padlockr";
                    btnClearSearch.Enabled = false;
                    lblSpyGlass.Enabled = false;
                    btnVisitLink.Enabled = false;
                    btnCopyPassword.Enabled = false;
                    btnCopyUsername.Enabled = false;
                    txtBoxSearch.Text = "";
                    txtBoxSearch.Enabled = false;
                    btnDeleteEntry.Enabled = false;
                    btnEditEntry.Enabled = false;
                    btnNewEntry.Enabled = false;
                }

                passBoxUnlock pbU = new passBoxUnlock();
                bool v = false;
                while (v == false)
                {
                    if (String.IsNullOrWhiteSpace(pbU.maskedMasterTextBox.Text) == false)
                    {
                        pbU.maskedMasterTextBox.Text = "";
                        pbU.lblPassVal.Text = "Password Incorrect!";
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
                                if (String.IsNullOrWhiteSpace(Properties.Settings.Default.defaultDBpath) == false)
                                {
                                    menuItemSetDefaultDatabase.Enabled = true;
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
            //TODO: Set the open DB as the default DB
            throw new NotImplementedException();
        }

        private void menuItemChangeMasterPassword_Click(object sender, EventArgs e)
        {
            //TODO: Change your DB Master password
            throw new NotImplementedException();
        }

        private void btnNewEntry_Click(object sender, EventArgs e)
        {
            // Add new enties in to the PDB Table of the open DB - (Added constructor to pass the liteDB object through)
            entryAddBox ne = new entryAddBox(liteDB);
            if (ne.ShowDialog() == DialogResult.OK)
            {
                liteDB.InsertData(ne.accNameTxtBox.Text, ne.userNameTxtBox.Text, ne.passMaskedTextBox.Text, ne.linkTxtBox.Text);
            }
            
            populateListBox(liteDB.GetDataTable("SELECT ACC_NAME FROM PDB;"));

        }

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = null;

            if (String.IsNullOrWhiteSpace(txtBoxSearch.Text) == false)
            {
                dt = liteDB.GetDataTable("SELECT ACC_NAME FROM PDB WHERE ACC_NAME LIKE '" + txtBoxSearch + "';");
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

        private void btnEditEntry_Click(object sender, EventArgs e)
        {
            // Edit enties in to the PDB Table of the open DB
            if (listBox.SelectedIndex != -1)
            {
                entryAddBox ee = new entryAddBox(liteDB);
                // Change the title of the dialog to "Edit"
                ee.Text = "Edit Entry";
                string sf = listBox.SelectedItem.ToString();

                //TODO: Optimise!
                DataTable dt = liteDB.GetDataTable("SELECT ACC_NAME, USER_NAME, PASS, LINK FROM PDB WHERE ACC_NAME = '" + sf + "';");
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[dt.Rows.Count - 1];
                    string oldAccName = dr["ACC_NAME"].ToString();
                    // Print out the read information to the Edit Entry Box
                    ee.accNameTxtBox.Text = oldAccName;
                    ee.userNameTxtBox.Text = dr["USER_NAME"].ToString();
                    ee.passMaskedTextBox.Text = dr["PASS"].ToString();
                    ee.linkTxtBox.Text = dr["LINK"].ToString();

                    if (ee.ShowDialog() == DialogResult.OK)
                    {
                        // Capture the changes and send them to the DB
                        liteDB.UpdateData(oldAccName, ee.userNameTxtBox.Text, ee.passMaskedTextBox.Text, ee.linkTxtBox.Text);
                        populateListBox(liteDB.GetDataTable("SELECT ACC_NAME FROM PDB;"));
                    }
                }
            }

        }

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
                
            }
            else if (listBox.SelectedIndex == -1)
            {
                btnEditEntry.Enabled = false;
                btnDeleteEntry.Enabled = false;
                btnCopyPassword.Enabled = false;
                btnCopyUsername.Enabled = false;
                btnVisitLink.Enabled = false;
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

        //TODO: Opitimise! Retrieve specific column data
        public string getColData(string field)
        {
            DataTable dt = liteDB.GetDataTable("SELECT " + field + " FROM PDB WHERE ACC_NAME = '" + listBox.SelectedItem.ToString() + "';");
            DataRow dr = dt.Rows[dt.Rows.Count - 1];

            return dr[field].ToString();
        }

        //TODO: Search the listbox
        public void searchList()
        {
            listBox.Items.Contains(txtBoxSearch.Text);
        }

        //TODO: Opitimise!
        public void populateListBox(DataTable dt)
        {
            listBox.Items.Clear();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    listBox.Items.Add(dr["ACC_NAME"].ToString());
                }
                // Enable controls - if there is data to edit and search
                lblSpyGlass.Enabled = true;
                txtBoxSearch.Enabled = true;
            }

            // Enable controls
            btnNewEntry.Enabled = true;
            listBox.Enabled = true;
            //TODO: Add logic to return the to the previously selected index
            listBox.SelectedIndex = -1;
        }
    }
}
