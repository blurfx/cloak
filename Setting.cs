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
    public partial class Setting : Form
    {
        GlobalKeyHook hook = new GlobalKeyHook();

        public Setting()
        {
            InitializeComponent();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            //SetHook
            hook.SetHook();
        }

        private void Setting_FormClosing(object sender, FormClosingEventArgs e)
        {
            //UnHook
            hook.UnHook();
        }

        private void iExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
