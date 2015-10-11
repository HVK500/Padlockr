using System;
using System.Reflection;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Prj_Padlockr
{
    public partial class mainWindow : Form
    {
        public mainWindow()
        {
            InitializeComponent();
        }

        // Global vars
        bool defaultDatabaseSet = false;

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
                try
                {
                    //SQLiteConnection.CreateFile(saveDatabaseDialog.FileName);
                    // Add method to open up the database in the saved location
                    openSqlConnection(saveDatabaseDialog.FileName);
                }
                catch (Exception f)
                {
                    MessageBox.Show("Didn't save due to this error: " + f);
                }
            }
        }

        private void menuItemOpenDatabase_Click(object sender, EventArgs e)
        {

        }

        private void menuItemChangeMasterPassword_Click(object sender, EventArgs e)
        {

        }

        private void btnNewEntry_Click(object sender, EventArgs e)
        {

        }

        public void openSqlConnection(string fileName)
        {
            //SQLiteConnection conn = new SQLiteConnection("Data Source=" + fileName + ";Version=3"); // Parse the parameters for the connection to the DB
            if(new passBoxLock().ShowDialog() == DialogResult.OK)
            {

            }
            //conn.SetPassword(); // Parse the password in here
            //conn.Open();
        }
    }
}
