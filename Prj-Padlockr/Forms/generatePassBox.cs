using System;
using System.Windows.Forms;
using Prj_Padlockr.Properties;

namespace Prj_Padlockr.Forms
{
    public partial class GeneratePassBox : Form
    {
        public GeneratePassBox()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Generate password with the specifed parameters
            if (chkBoxCapLetters.Checked == false && chkBoxSLetters.Checked == false && chkBoxNum.Checked == false && chkBoxSpec.Checked == false)
            {
                MessageBox.Show(Resources.GenPassOptionMissing, Resources.GenPassOptionMissingTitle);
                return;
            }

            // todo: move Random to some global class
            // Generate a password from selected parameters
            var rnd = new Random();
            var str = "";
            var c = "";

            // todo: move into helper method
            if (chkBoxSLetters.Checked)
            {
                // Small letters 26
                c += "abcdefghijklmnopqrstuvwxyz";
            }

            if (chkBoxCapLetters.Checked)
            {
                // Capital letters 26
                c += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }

            if (chkBoxNum.Checked)
            {
                // Numbers 1-9
                c += "0123456789"; 
            }

            if (chkBoxSpec.Checked)
            {
                // Special symbols 
                c += "~`!@#$%^&*()_+-={}'[]:\";<>?,./|\\";
            }

            for (var i = numLength.Value; i > 0; --i)
            {
                str += c[rnd.Next(0, (c.Length - 1))];
            }

            // Output the result password to the read-only text-box
            txtBoxGen.Text = str;
        }

        private void txtBoxGen_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxGen.Text) == false)
            {
                btnAccept.Enabled = true;
                return;
            }

            btnAccept.Enabled = false;
        }
    }
}
