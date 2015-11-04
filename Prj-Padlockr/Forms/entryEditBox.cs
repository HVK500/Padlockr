using System;
using System.Windows.Forms;

namespace Prj_Padlockr
{
    public partial class entryEditBox : Form
    {
        public entryEditBox()
        {
            InitializeComponent();
        }

        private void btnMaskWatcher_MouseDown(object sender, MouseEventArgs e)
        {
            passMaskedTextBox.UseSystemPasswordChar = false;
        }

        private void btnMaskWatcher_MouseUp(object sender, MouseEventArgs e)
        {
            passMaskedTextBox.UseSystemPasswordChar = true;
        }

        private void passMaskedTextBox_TextChanged(object sender, EventArgs e)
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

        private void accNameTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(accNameTxtBox.Text) == false)
            {
                userNameTxtBox.Enabled = true;
            }
            else
            {
                userNameTxtBox.Enabled = false;
                passMaskedTextBox.Enabled = false;
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
                lblLinkVal.Text = "Only paste links - e.g. 'http:\\google.com\'";
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
    }
}
