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
            //TODO: Generate password with the specifed parameters
            if (chkBoxCapLetters.Checked == false && chkBoxSLetters.Checked == false && chkBoxNum.Checked == false && chkBoxSpec.Checked == false)
            {
                MessageBox.Show("At least one option needs to be selected.", "Character Selection");
            }
            else
            {
                // Generation code goes here!
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            //TODO: Parse the generated password back to new entry window
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
