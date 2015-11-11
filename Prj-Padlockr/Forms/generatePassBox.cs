using System;
using System.Windows.Forms;

namespace Prj_Padlockr
{
    public partial class generatePassBox : Form
    {
        public generatePassBox()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Generate password with the specifed parameters
            if (chkBoxCapLetters.Checked == false && chkBoxSLetters.Checked == false && chkBoxNum.Checked == false && chkBoxSpec.Checked == false)
            {
                MessageBox.Show("At least one option needs to be selected.", "Character Selection");
            }
            else
            {
                // Generate a password from selected parameters
                Random rnd = new Random();
                string str = "";
                var c = "";

                if (chkBoxSLetters.Checked == true)
                {
                    // Small letters 26
                    c += "abcdefghijklmnopqrstuvwxyz";
                }
                if (chkBoxCapLetters.Checked == true)
                {
                    // Capital letters 26
                    c += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                }
                if (chkBoxNum.Checked == true)
                {
                    // Numbers 1-9
                    c += "0123456789"; 
                }
                if (chkBoxSpec.Checked == true)
                {
                    // Special symbols 
                    c += "~`!@#$%^&*()_+-={}[]:\";<>?,./|\\";
                }

                for (decimal i = numLength.Value; i > 0; --i)
                {
                     str += c[rnd.Next(0, (c.Length - 1))];
                }

                // Output the result password to the readonly textbox
                txtBoxGen.Text = str;

            }
        }

        private void txtBoxGen_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtBoxGen.Text) == false)
            {
                btnAccept.Enabled = true;
            }
            else
            {
                btnAccept.Enabled = false;
            }
        }
    }
}
