using System;
using System.Windows.Forms;

namespace Prj_Padlockr.Forms
{
    public partial class passBoxLock : Form
    {
        public passBoxLock()
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
            if (String.IsNullOrWhiteSpace(firstMaskedTextBox.Text) == false)
            {
                btnMaskWatcher1.Enabled = true;
                secondMaskedTextBox.Enabled = true;
            }
            else
            {
                btnMaskWatcher1.Enabled = false;
                secondMaskedTextBox.Text = "";
                secondMaskedTextBox.Enabled = false;
            }
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
            if (String.IsNullOrWhiteSpace(secondMaskedTextBox.Text) == false)
            {
                btnMaskWatcher2.Enabled = true;
                if (firstMaskedTextBox.Text != secondMaskedTextBox.Text)
                {
                    lblValidation.Text = "Does not match!";
                }
                else
                {
                    lblValidation.Text = "";
                    btnSet.Enabled = true;
                }
            }
            else
            {
                btnMaskWatcher2.Enabled = false;
                lblValidation.Text = "";
            }
        }
    }
}
