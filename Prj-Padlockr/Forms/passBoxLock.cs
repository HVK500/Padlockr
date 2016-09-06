using System;
using System.Windows.Forms;
using Padlockr.Properties;

namespace Padlockr.Forms
{
    public partial class PassBoxLock : Form
    {
        public PassBoxLock()
        {
            InitializeComponent();
        }

        // Prevents the form from being closed
        private void passBoxLock_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnSet.Enabled != true)
            {
                e.Cancel = true;
            }
        }

        private void btnMaskWatcher1_MouseDown(object sender, MouseEventArgs e)
        {
            firstMaskedTextBox.UseSystemPasswordChar = false;
        }

        private void btnMaskWatcher1_MouseUp(object sender, MouseEventArgs e)
        {
            firstMaskedTextBox.UseSystemPasswordChar = true;
        }

        private void firstMaskedTextBox_TextChanged(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(firstMaskedTextBox.Text) == false)
            {
                btnMaskWatcher1.Enabled = true;
                secondMaskedTextBox.Enabled = true;
                return;
            }

            btnMaskWatcher1.Enabled = false;
            secondMaskedTextBox.Text = "";
            secondMaskedTextBox.Enabled = false;
        }

        private void btnMaskWatcher2_MouseDown(object sender, MouseEventArgs e)
        {
            secondMaskedTextBox.UseSystemPasswordChar = false;
        }

        private void btnMaskWatcher2_MouseUp(object sender, MouseEventArgs e)
        {
            secondMaskedTextBox.UseSystemPasswordChar = true;
        }

        private void secondMaskedTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(secondMaskedTextBox.Text) == false)
            {
                btnMaskWatcher2.Enabled = true;
                if (firstMaskedTextBox.Text != secondMaskedTextBox.Text)
                {
                    lblValidation.Text = Resources.DosntMatch;
                }
                else
                {
                    lblValidation.Text = "";
                    btnSet.Enabled = true;
                }

                return;
            }

            btnMaskWatcher2.Enabled = false;
            lblValidation.Text = "";
        }
    }
}
