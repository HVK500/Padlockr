using System;
using System.Data.SQLite;
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

        // Global vars
        //TODO: Set this on startup to match the whats in the xml/registry
        bool defaultDatabaseSet = false;
        string dbDir;
        // - Create the instance that controls all the DB interactions
        SQLiteDatabase liteDB = new SQLiteDatabase();

        private void mainWindow_Load(object sender, EventArgs e)
        {
            // == Self-Versioning-System == //

            // Manually enter the Major & Minor numbers in "AssemblyInfo.cs", Only handles Build & Revision numbers
            decimal ver;
            decimal verCalc;

            // Build [Length-4] 
            ver = Assembly.GetExecutingAssembly().GetName().Version.Build;
            verCalc = ver / 100;
            decimal b = Math.Round(verCalc);

            // Revision [Length-5]
            ver = Assembly.GetExecutingAssembly().GetName().Version.Revision;
            verCalc = ver / 1000;
            decimal r = Math.Round(verCalc);

            // Auto output of the new build number - Title & Win Text
            string fullVersion = "0.0." + b + "r" + r;// (Assembly.GetExecutingAssembly().GetName().Version).ToString().Remove(4, 10) Removed -> caused problems (OutOfRange exception)
            lblVersion.Text = "v" + fullVersion;

            // == Self-Versioning-System == //

            // Show master password dialog - Add logic to check if there is a default database set, if so then open it
            if (defaultDatabaseSet == true)
            {
                new passBoxUnlock().ShowDialog();
            }
            
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
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
                dbDir = saveDatabaseDialog.FileName;
                SQLiteConnection.CreateFile(dbDir);
                liteDB.DBConnect(dbDir);
                // Create a new passBoxLock instance to parse the password back from the firstMaskedTextBox
                passBoxLock pb = new passBoxLock();
                if (pb.ShowDialog() == DialogResult.OK)
                {
                    // Sets the DB Password and creates the PDB Table
                    liteDB.InitializeDB(pb.firstMaskedTextBox.Text);
                    if (MessageBox.Show("Would you like to set the new database to your default?", "Set new database to default", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //TODO: Make the new DB the default

                    }
                }
                
            }
        }

        private void menuItemOpenDatabase_Click(object sender, EventArgs e)
        {
            //TODO: Create away to open an exsisting DB through a file browser
        }

        private void menuItemChangeMasterPassword_Click(object sender, EventArgs e)
        {
            //TODO: Link up the window to change your DB Master password
        }

        private void btnNewEntry_Click(object sender, EventArgs e)
        {
            //TODO: Link up the method to add new enties in to the PDB Table of the open DB
        }

    }
}
