namespace Cloak
{
    partial class Cloak
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cloak));
            this.tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.iExit = new System.Windows.Forms.ToolStripMenuItem();
            this.iAutorun = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tray
            // 
            this.tray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tray.BalloonTipText = "Cloak is running";
            this.tray.ContextMenuStrip = this.menuStrip;
            this.tray.Icon = ((System.Drawing.Icon)(resources.GetObject("tray.Icon")));
            this.tray.Text = "Cloak";
            this.tray.Visible = true;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iAutorun,
            this.iExit});
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(206, 48);
            // 
            // iExit
            // 
            this.iExit.Name = "iExit";
            this.iExit.Size = new System.Drawing.Size(205, 22);
            this.iExit.Text = "E&xit";
            this.iExit.Click += new System.EventHandler(this.iExit_Click);
            // 
            // iAutorun
            // 
            this.iAutorun.Name = "iAutorun";
            this.iAutorun.Size = new System.Drawing.Size(205, 22);
            this.iAutorun.Text = "Run at Windows Startup";
            this.iAutorun.Click += new System.EventHandler(this.iAutorun_Click);
            // 
            // Cloak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(121, 23);
            this.DoubleBuffered = true;
            this.Name = "Cloak";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Cloak";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Cloak_FormClosing);
            this.Load += new System.EventHandler(this.Cloak_Load);
            this.menuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon tray;
        private System.Windows.Forms.ContextMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem iExit;
        private System.Windows.Forms.ToolStripMenuItem iAutorun;
    }
}