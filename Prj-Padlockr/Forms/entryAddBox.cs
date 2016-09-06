using System;
using System.Windows.Forms;
using Padlockr.Properties;

namespace Padlockr.Forms
{
    public partial class EntryAddBox : Form
    {
        private void entryAddBox_Load(object sender, EventArgs e)
        {
            if (Text == Resources.EditEntry)
            {
                accNameTxtBox.Enabled = false;
            }
        }

        private void passMaskedBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(passMaskedTextBox.Text) == false)
            {
                btnMaskWatcher.Enabled = true;
                btnSubmit.Enabled = true;

                return;
            }

            btnMaskWatcher.Enabled = false;
            btnSubmit.Enabled = false;
        }

        private void btnMaskWatcher_CheckedChanged(object sender, EventArgs e)
        {
            if (btnMaskWatcher.Checked == false)
            {
                passMaskedTextBox.UseSystemPasswordChar = true;
            }
            else if (btnMaskWatcher.Checked)
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

                return;
            }

            userNameTxtBox.Enabled = false;
            passMaskedTextBox.Enabled = false;
            btnMaskWatcher.Enabled = false;
            btnGenerate.Enabled = false;
            btnSubmit.Enabled = false;
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

                return;
            }

            passMaskedTextBox.Enabled = false;
            btnGenerate.Enabled = false;
            btnSubmit.Enabled = false;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Generate a password in the password creation window
            var gPb = new GeneratePassBox();

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

            if (cbText.Contains("http://") || cbText.Contains("https://"))
            {
                linkTxtBox.Text = cbText;
                lblLinkVal.Text = string.Empty;
                return;
            }

            lblLinkVal.Text = Resources.PasteLinkMessage;
        }

        private void btnClearLink_Click(object sender, EventArgs e)
        {
            linkTxtBox.Text = string.Empty;
        }

        private void linkTxtBox_TextChanged(object sender, EventArgs e)
        {
            btnClearLink.Enabled = string.IsNullOrWhiteSpace(linkTxtBox.Text) == false;
        }

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

            if (Text != Resources.NewEntry)
                return;

            e.Cancel = true;
            var errorMsg = string.Format(Resources.AccountWithNameExists, accNameTxtBox);
            MessageBox.Show(errorMsg, Resources.AccountWithNameExistsTitle);
        }
    }
}
