using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Cloak.Helper;

namespace Cloak
{
    public partial class Cloak : Form
    {
        GlobalKeyHook hook = new GlobalKeyHook();

        public Cloak()
        {
            InitializeComponent();
        }

        private void Cloak_Load(object sender, EventArgs e)
        {
            //SetHook
            hook.SetHook();
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
    }
}
