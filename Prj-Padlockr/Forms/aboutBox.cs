using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace Prj_Padlockr
{
    public partial class aboutBox : Form
    {
        public aboutBox()
        {
            InitializeComponent();
        }

        private void aboutBox_Load(object sender, EventArgs e)
        {       
            lblCopyright.Text = "Copyright © " + DateTime.Today.Year.ToString() + " - Matthew Laird, alias HVK";
            lblAboutVer.Text = "Version " + Assembly.GetExecutingAssembly().GetName().Version.Major + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor + " build" + Assembly.GetExecutingAssembly().GetName().Version.Build + " r" + Assembly.GetExecutingAssembly().GetName().Version.Revision;
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
