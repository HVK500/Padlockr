using System;
using System.Windows.Forms;

namespace Prj_Padlockr
{
    public partial class passBoxUnlock : Form
    {
        public passBoxUnlock()
        {
            InitializeComponent();
        }

        private void btnMaskWatcher_MouseDown(object sender, MouseEventArgs e)
        {
            maskedMasterTextBox.UseSystemPasswordChar = false;
        }

        private void btnMaskWatcher_MouseUp(object sender, MouseEventArgs e)
        {
            maskedMasterTextBox.UseSystemPasswordChar = true;
        }

        private void maskedMasterTextBox_TextChanged(object sender, System.EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(maskedMasterTextBox.Text) == false)
            {
                btnMaskWatcher.Enabled = true;
                btnUnlock.Enabled = true;
            }
            else
            {
                btnMaskWatcher.Enabled = false;
                btnUnlock.Enabled = false;
            }
        }

    }
}
