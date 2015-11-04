using System;
using System.Data;
using System.Data.SQLite;
using System.Reflection;
using System.Windows.Forms;

namespace Prj_Padlockr
{
    public partial class mainWindow : Form
    {
        // Initialization of Global vars

        // - Create the instance that controls all the DB interactions
        SQLiteDatabase liteDB = new SQLiteDatabase();

    public mainWindow()
        {
            InitializeComponent();
        }

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
                            //TODO: Condition to check if it is the correct password
                            liteDB.DBUnlock(Properties.Settings.Default.defaultDBpath, pbU.maskedMasterTextBox.Text);

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
            //else if ()
            //{

            //}
            
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
            //TODO: Implement
            throw new NotImplementedException();
        }

        private void menuItemChangeMasterPassword_Click(object sender, EventArgs e)
        {
            //TODO: Link up the window to change your DB Master password
            throw new NotImplementedException();
        }

        private void btnNewEntry_Click(object sender, EventArgs e)
        {
            // Add new enties in to the PDB Table of the open DB
            entryAddBox ne = new entryAddBox();
            if (ne.ShowDialog() == DialogResult.OK)
            {
                liteDB.InsertData(ne.accNameTxtBox.Text, ne.userNameTxtBox.Text, ne.passMaskedTextBox.Text, ne.linkTxtBox.Text);
            }
            
            populateListBox(liteDB.GetDataTable("SELECT ACC_NAME FROM PDB;"));

        }

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtBoxSearch.Text) == false)
            {
                btnClearSearch.Enabled = true;
            }
            else
            {
                btnClearSearch.Enabled = false;
            }
        }

        private void btnEditEntry_Click(object sender, EventArgs e)
        {
            // Edit enties in to the PDB Table of the open DB
            if (listBox.SelectedIndex != -1)
            {
                entryEditBox ee = new entryEditBox();
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
                        liteDB.UpdateData(oldAccName, ee.accNameTxtBox.Text, ee.userNameTxtBox.Text, ee.passMaskedTextBox.Text, ee.linkTxtBox.Text);
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

                //TODO: Optimise! Check whether the selected item has a link saved
                DataTable dt = liteDB.GetDataTable("SELECT LINK FROM PDB WHERE ACC_NAME = '" + listBox.SelectedItem + "';");
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt.Rows[dt.Rows.Count - 1];
                    if (String.IsNullOrWhiteSpace(dr["LINK"].ToString()) == false)
                    {
                        btnVisitLink.Enabled = true;
                    }
                    else
                    {
                        btnVisitLink.Enabled = false;
                    }
                }
                
            }
            else if (listBox.SelectedIndex == -1)
            {
                btnEditEntry.Enabled = false;
                btnDeleteEntry.Enabled = false;
            }
        }

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
            listBox.SelectedIndex = -1;
        }
    }
}
