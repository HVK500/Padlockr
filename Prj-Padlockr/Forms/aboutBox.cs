using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using Prj_Padlockr.Properties;

namespace Prj_Padlockr.Forms
{
    public partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
        }

        private void aboutBox_Load(object sender, EventArgs e)
        {
            var appVersion = Assembly.GetExecutingAssembly().GetName().Version;

            lblCopyright.Text = string.Format(Resources.AboutCopy, DateTime.Now.Year);

            lblAboutVer.Text = string.Format(Resources.AboutVersion,
                appVersion.Major, appVersion.Minor, appVersion.Build, appVersion.Revision);
        }

        private void lnkCC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://creativecommons.org/licenses/by/3.0");
        }

        private void lnki8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://icons8.com");
        }

        private void lnkCCnd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://creativecommons.org/licenses/by-nd/3.0");
        }
    }
}
