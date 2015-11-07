using System;
using System.Windows.Forms;

namespace Prj_Padlockr
{
    public partial class passBoxChange : Form
    {
        public passBoxChange()
        {
            InitializeComponent();
        }

        private void maskedOldBox_TextChanged(object sender, EventArgs e)
        {
            formValidation();
        }

        private void maskedNewBox_TextChanged(object sender, EventArgs e)
        {
            formValidation();
            if (maskedRnewBox.Text != maskedNewBox.Text)
            {
                lblNewPassValidation.Text = "Passwords do not match!";
            }
            else
            {
                lblNewPassValidation.Text = "";
            }
        }

        private void maskedRnewBox_TextChanged(object sender, EventArgs e)
        {
            formValidation();
            if (maskedRnewBox.Text != maskedNewBox.Text)
            {
                lblNewPassValidation.Text = "Passwords do not match!";
            }
            else
            {
                lblNewPassValidation.Text = "";
            }
        }

        private void btnMaskWatcherOld_MouseDown(object sender, MouseEventArgs e)
        {
            maskedOldBox.UseSystemPasswordChar = false;
        }

        private void btnMaskWatcherOld_MouseUp(object sender, MouseEventArgs e)
        {
            maskedOldBox.UseSystemPasswordChar = true;
        }

        private void btnMaskWatcherNew_MouseDown(object sender, MouseEventArgs e)
        {
            maskedNewBox.UseSystemPasswordChar = false;
        }

        private void btnMaskWatcherNew_MouseUp(object sender, MouseEventArgs e)
        {
            maskedNewBox.UseSystemPasswordChar = true;
        }

        private void btnMaskWatcherRnew_MouseDown(object sender, MouseEventArgs e)
        {
            maskedRnewBox.UseSystemPasswordChar = false;
        }

        private void btnMaskWatcherRnew_MouseUp(object sender, MouseEventArgs e)
        {
            maskedRnewBox.UseSystemPasswordChar = true;
        }

        private void passBoxChange_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.ToString() != "Cancel")
            {
                if (liteDB.passCheck(maskedOldBox.Text) == true)
                {
                    lblOpassValidation.Text = "";
                    
                    if (maskedRnewBox.Text == maskedNewBox.Text)
                    {
                        if (maskedOldBox.Text != maskedNewBox.Text)
                        {
                            liteDB.ChangePass(maskedNewBox.Text);
                        }
                        else
                        {
                            e.Cancel = true;
                            lblNewPassValidation.Text = "New password must be different!";
                        }
                        
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    e.Cancel = true;
                    lblOpassValidation.Text = "Password is incorrect!";
                }
            }
        }

        public void formValidation()
        {
            if (String.IsNullOrWhiteSpace(maskedOldBox.Text) == false) // not empty
            {
                // maskedOldBox
                btnMaskWatcherOld.Enabled = true;
                maskedNewBox.Enabled = true;

                if (String.IsNullOrWhiteSpace(maskedNewBox.Text) == false) // not empty
                {
                    // maskedNewBox
                    btnMaskWatcherOld.Enabled = true;
                    btnMaskWatcherNew.Enabled = true;
                    maskedRnewBox.Enabled = true;


                    if (String.IsNullOrWhiteSpace(maskedRnewBox.Text) == false) // not empty
                    {
                        // maskedRnewBox
                        btnMaskWatcherOld.Enabled = true;
                        btnMaskWatcherNew.Enabled = true;
                        maskedNewBox.Enabled = true;
                        btnMaskWatcherRnew.Enabled = true;
                        maskedRnewBox.Enabled = true;
                        btnAccept.Enabled = true;
                    }
                    else // empty
                    {
                        // only btnmaskedWatcherRnew + accept is disabled
                        btnMaskWatcherRnew.Enabled = false;
                        btnAccept.Enabled = false;
                    }
                }
                else // empty
                {
                    // only maskedRnewBox + btnmaskedWatcherRnew + btnmaskedWatcherNew + accept is disabled
                    btnMaskWatcherNew.Enabled = false;
                    maskedRnewBox.Enabled = false;
                    btnMaskWatcherRnew.Enabled = false;
                    btnAccept.Enabled = false;
                }
            }
            else // empty
            {
                // Everything is disabled
                btnMaskWatcherOld.Enabled = false;
                maskedNewBox.Enabled = false;
                btnMaskWatcherNew.Enabled = false;
                maskedRnewBox.Enabled = false;
                btnMaskWatcherRnew.Enabled = false;
                btnAccept.Enabled = false;
            }
        }
    }
}
