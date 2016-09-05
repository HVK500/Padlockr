using System;
using System.Data;
using System.Windows.Forms;

namespace Prj_Padlockr.Forms
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
            if (string.IsNullOrWhiteSpace(passMaskedTextBox.Text) == false)
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
            if (string.IsNullOrWhiteSpace(accNameTxtBox.Text) == false)
            {
                userNameTxtBox.Enabled = true;
                if (string.IsNullOrWhiteSpace(userNameTxtBox.Text) == false)
                {
                    userNameTxtBox.Enabled = true;
                }
                if (string.IsNullOrWhiteSpace(passMaskedTextBox.Text) == false)
                {
                    passMaskedTextBox.Enabled = true;
                    btnMaskWatcher.Enabled = true;
                    btnGenerate.Enabled = true;
                }
                if (string.IsNullOrWhiteSpace(userNameTxtBox.Text) == false && string.IsNullOrWhiteSpace(passMaskedTextBox.Text) == false)
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
            if (string.IsNullOrWhiteSpace(userNameTxtBox.Text) == false)
            {
                passMaskedTextBox.Enabled = true;
                btnGenerate.Enabled = true;
                if (string.IsNullOrWhiteSpace(passMaskedTextBox.Text) == false)
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
            var gPb = new generatePassBox();
            if (gPb.ShowDialog() == DialogResult.OK)
            {
                // Get generated password from txtBoxGen
                passMaskedTextBox.Text = gPb.txtBoxGen.Text;
            }
        }

        private void btnLinkPaste_Click(object sender, EventArgs e)
        {
            // Paste link from clipboard only if it contains a link format!
            var cbText = Clipboard.GetText();
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
            if (string.IsNullOrWhiteSpace(linkTxtBox.Text) == false)
            {
                btnClearLink.Enabled = true;
            }
            else
            {
                btnClearLink.Enabled = false;
            }
        }

        // todo: add tests
        // Checks whether ACC_NAME already exists before closing the dialog
        private void entryAddBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
                return;

            if (string.IsNullOrWhiteSpace(accNameTxtBox.Text))
                return;

            // Check whether the account name exists
            if (!dbContext.AccountExists(accNameTxtBox.Text))
                return;

            if (Text != "New Entry")
                return;

            e.Cancel = true;
            var errorMsg = string.Format(Properties.Resources.AccountWithNameExists, accNameTxtBox);
            MessageBox.Show(errorMsg, Properties.Resources.AccountWithNameExistsTitle);
        }
    }
}
