using System;
using System.Windows.Forms;
using Padlockr.Properties;
using Padlockr.Utils;

namespace Padlockr.Forms
{
    public partial class GeneratePassBox : Form
    {
        public GeneratePassBox()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Generate password with the specified parameters
            if (chkBoxCapLetters.Checked == false && chkBoxSLetters.Checked == false && chkBoxNum.Checked == false && chkBoxSpec.Checked == false)
            {
                MessageBox.Show(Resources.GenPassOptionMissing, Resources.GenPassOptionMissingTitle);
                return;
            }
            
            // Generate a password from selected parameters
            var passGenerator = new PasswordGenerator();

            if (chkBoxSLetters.Checked)
                passGenerator.UseSmallLetters();

            if (chkBoxCapLetters.Checked)
                passGenerator.UseCapitalLetters();

            if (chkBoxNum.Checked)
                passGenerator.UseNumbers();

            if (chkBoxSpec.Checked)
                passGenerator.UseSpecial();

            // Output the result password to the read-only text-box
            txtBoxGen.Text = passGenerator.GeneratePass((int) numLength.Value);
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
