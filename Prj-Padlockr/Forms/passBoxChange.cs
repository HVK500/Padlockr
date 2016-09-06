using System;
using System.Windows.Forms;
using Prj_Padlockr.Properties;

namespace Prj_Padlockr.Forms
{
    public partial class PassBoxChange : Form
    {
        private void maskedOldBox_TextChanged(object sender, EventArgs e)
        {
            // Validates the controls 
            FormValidation();
        }

        private void maskedNewBox_TextChanged(object sender, EventArgs e)
        {
            // Validates the controls 
            FormValidation();

            lblNewPassValidation.Text = maskedRnewBox.Text != maskedNewBox.Text ? Resources.PassDontMatch : string.Empty;
        }

        private void maskedRnewBox_TextChanged(object sender, EventArgs e)
        {
            // Validates the controls 
            FormValidation();

            lblNewPassValidation.Text = maskedRnewBox.Text != maskedNewBox.Text ? Resources.PassDontMatch : string.Empty;
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
            if (DialogResult.ToString() == Resources.Cancel)
                return;

            if (dbContext.PassCheck(maskedOldBox.Text) == true)
            {
                lblOpassValidation.Text = "";
                    
                if (maskedRnewBox.Text == maskedNewBox.Text)
                {
                    if (maskedOldBox.Text != maskedNewBox.Text)
                    {
                        dbContext.ChangePass(maskedNewBox.Text);
                    }
                    else
                    {
                        e.Cancel = true;
                        lblNewPassValidation.Text = Resources.NewPassMustDiffer;
                    }
                        
                }
                else
                {
                    e.Cancel = true;
                }

                return;
            }

            e.Cancel = true;
            lblOpassValidation.Text = Resources.PasswordIncorrect;
        }

        // todo: optimize validation
        private void FormValidation()
        {
            if (string.IsNullOrWhiteSpace(maskedOldBox.Text) == false) // not empty
            {
                // maskedOldBox
                btnMaskWatcherOld.Enabled = true;
                maskedNewBox.Enabled = true;

                if (string.IsNullOrWhiteSpace(maskedNewBox.Text) == false) // not empty
                {
                    // maskedNewBox
                    btnMaskWatcherOld.Enabled = true;
                    btnMaskWatcherNew.Enabled = true;
                    maskedRnewBox.Enabled = true;


                    if (string.IsNullOrWhiteSpace(maskedRnewBox.Text) == false) // not empty
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
