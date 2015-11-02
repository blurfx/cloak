using System;
using System.Windows.Forms;
using Cloak.Helper;
using Microsoft.Win32;

namespace Cloak
{
    public partial class Cloak : Form
    {
        GlobalKeyHook hook = new GlobalKeyHook();

        public Cloak()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

        }

        private void Cloak_Load(object sender, EventArgs e)
        {
            //SetHook
            hook.SetHook();
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if(registryKey.GetValue("Cloak") != null)
            {
                iAutorun.Checked = false;
            }
            tray.ShowBalloonTip(5);
        }

        private void Cloak_FormClosing(object sender, FormClosingEventArgs e)
        {
            //UnHook
            hook.UnHook();
        }

        private void iExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;
            base.OnLoad(e);
        }

        private void iAutorun_Click(object sender, EventArgs e)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (iAutorun.Checked)
            {
                registryKey.DeleteValue("Cloak");
                iAutorun.Checked = false;
            }
            else
            {
                registryKey.SetValue("Cloak", Application.ExecutablePath);
                iAutorun.Checked = true;
            }
        }
    }
}
