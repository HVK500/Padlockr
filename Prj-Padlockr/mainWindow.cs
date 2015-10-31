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
                bool v = false;
                while (v == false)
                {
                    passBoxUnlock pbU = new passBoxUnlock();
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
                bool v = false;
                while (v == false)
                {
                    passBoxUnlock pbU = new passBoxUnlock();
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
                btnEditEntry.Enabled = true;
                btnDeleteEntry.Enabled = true;
                lbSpyGlass.Enabled = true;
                txtBoxSearch.Enabled = true;
            }

            // Enable controls
            btnNewEntry.Enabled = true;
            listBox.Enabled = true;
            listBox.SelectedIndex = -1;
        }

    }
}
