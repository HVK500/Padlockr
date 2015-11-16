using System;
using System.Data;
using System.Windows.Forms;

namespace Prj_Padlockr
{
    public partial class entryAddBox : Form
    {
        // In "entryAddBox.Designer.cs" at the bottom is the initialization of the "Add Entry" / "Edit Entry" dialog
        //public entryAddBox()
        //{
        //    InitializeComponent();
        //}

        private void entryAddBox_Load(object sender, EventArgs e)
        {
            if (Text == "Edit Entry")
            {
                accNameTxtBox.Enabled = false;
            }
        }

        private void passMaskedBox_TextChanged(object sender, System.EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(passMaskedTextBox.Text) == false)
            {
                btnMaskWatcher.Enabled = true;
                btnSubmit.Enabled = true;
            }
            else
            {
                btnMaskWatcher.Enabled = false;
                btnSubmit.Enabled = false;
            }
        }

        private void btnMaskWatcher_CheckedChanged(object sender, EventArgs e)
        {
            if (btnMaskWatcher.Checked == false)
            {
                passMaskedTextBox.UseSystemPasswordChar = true;
            }
            else if (btnMaskWatcher.Checked == true)
            {
                passMaskedTextBox.UseSystemPasswordChar = false;
            }
        }

        private void accNameTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(accNameTxtBox.Text) == false)
            {
                userNameTxtBox.Enabled = true;
                if (String.IsNullOrWhiteSpace(userNameTxtBox.Text) == false)
                {
                    userNameTxtBox.Enabled = true;
                }
                if (String.IsNullOrWhiteSpace(passMaskedTextBox.Text) == false)
                {
                    passMaskedTextBox.Enabled = true;
                    btnMaskWatcher.Enabled = true;
                    btnGenerate.Enabled = true;
                }
                if (String.IsNullOrWhiteSpace(userNameTxtBox.Text) == false && String.IsNullOrWhiteSpace(passMaskedTextBox.Text) == false)
                {
                    btnSubmit.Enabled = true;
                }
            }
            else
            {
                userNameTxtBox.Enabled = false;
                passMaskedTextBox.Enabled = false;
                btnMaskWatcher.Enabled = false;
                btnGenerate.Enabled = false;
                btnSubmit.Enabled = false;
            }
        }

        private void userNameTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(userNameTxtBox.Text) == false)
            {
                passMaskedTextBox.Enabled = true;
                btnGenerate.Enabled = true;
                if (String.IsNullOrWhiteSpace(passMaskedTextBox.Text) == false)
                {
                    btnSubmit.Enabled = true;
                }
            }
            else
            {
                passMaskedTextBox.Enabled = false;
                btnGenerate.Enabled = false;
                btnSubmit.Enabled = false;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Generate a password in the password creation window
            generatePassBox gPb = new generatePassBox();
            if (gPb.ShowDialog() == DialogResult.OK)
            {
                // Get generated password from txtBoxGen
                passMaskedTextBox.Text = gPb.txtBoxGen.Text;
            }
        }

        private void btnLinkPaste_Click(object sender, EventArgs e)
        {
            // Paste link from clipboard only if it contains a link format!
            string cbText = Clipboard.GetText();
            if (cbText.Contains("http://") == true || cbText.Contains("https://") == true)
            {
                linkTxtBox.Text = cbText;
                lblLinkVal.Text = "";
            }
            else
            {
                lblLinkVal.Text = "Only paste URLs - e.g. 'http:\\www.google.com\'";
            }
        }

        private void btnClearLink_Click(object sender, EventArgs e)
        {
            linkTxtBox.Text = "";
        }

        private void linkTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(linkTxtBox.Text) == false)
            {
                btnClearLink.Enabled = true;
            }
            else
            {
                btnClearLink.Enabled = false;
            }
        }

        // Checks whether ACC_NAME already exists before closing the dialog
        private void entryAddBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.ToString() != "Cancel")
            {
                if (String.IsNullOrWhiteSpace(accNameTxtBox.Text) == false)
                {
                    // Check whether the account name exsits
                    DataTable dt = liteDB.GetDataTable("SELECT ACC_NAME FROM PDB WHERE ACC_NAME = '" + accNameTxtBox.Text + "';");

                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows.Count == 1)
                        {
                            // When New Entry encounters a Account name that is in the DB already it will cancel the closing event and show message 
                            if (Text == "New Entry")
                            {
                                e.Cancel = true;
                                MessageBox.Show("An account with the name '" + accNameTxtBox + "' already exists.", "Account Already Exists");
                            }
                            //    // POST CHANGES
                        }

                    }
                    //    // POST NEW
                }
            }
            
        }
    }
}
