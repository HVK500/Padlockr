using System.Windows.Forms;

namespace Prj_Padlockr.Forms
{
    public partial class PassBoxUnlock : Form
    {
        public PassBoxUnlock()
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
            if (string.IsNullOrWhiteSpace(maskedMasterTextBox.Text) == false)
            {
                btnMaskWatcher.Enabled = true;
                btnUnlock.Enabled = true;

                return;
            }

            btnMaskWatcher.Enabled = false;
            btnUnlock.Enabled = false;
        }

    }
}
