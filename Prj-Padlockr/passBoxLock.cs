using System.Windows.Forms;

namespace Prj_Padlockr
{
    public partial class passBoxLock : Form
    {
        public passBoxLock()
        {
            InitializeComponent();
        }

        // Stops the form from being closed
        private void passBoxLock_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnMaskWatcher1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void btnMaskWatcher1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void btnMaskWatcher2_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void btnMaskWatcher2_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void btnSet_Click(object sender, System.EventArgs e)
        {

        }
    }
}
