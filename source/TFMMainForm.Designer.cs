namespace tfm
{
    partial class TFMMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFMMainForm));
            this.dbLoadWorker = new System.ComponentModel.BackgroundWorker();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandKeysMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.keyboardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueTrackerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.websiteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.restartMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutDownMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trayIconContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dbLoadWorker
            // 
                        // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayIcon.BalloonTipText = "TFM minimized to the system tray.";
            this.trayIcon.BalloonTipTitle = "TFM";
            this.trayIcon.ContextMenuStrip = this.trayIconContextMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Talking flight monitor";
            // 
            // trayIconContextMenu
            // 
            this.trayIconContextMenu.AccessibleName = "TFM context menu";
            this.trayIconContextMenu.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trayIconContextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.trayIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsMenuItem,
            this.commandKeysMenuItem,
            this.toolStripSeparator3,
            this.keyboardMenuItem,
            this.issueTrackerMenuItem,
            this.websiteMenuItem,
            this.aboutMenuItem,
            this.toolStripSeparator4,
            this.restartMenuItem,
            this.shutDownMenuItem});
            this.trayIconContextMenu.Name = "trayIconContextMenu";
            this.trayIconContextMenu.Size = new System.Drawing.Size(261, 336);
            this.trayIconContextMenu.Text = "TFM";
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.AccessibleName = "Settings...";
            this.settingsMenuItem.Name = "settingsMenuItem";
            this.settingsMenuItem.Size = new System.Drawing.Size(260, 40);
            this.settingsMenuItem.Text = "&Settings";
            this.settingsMenuItem.Click += new System.EventHandler(this.settingsMenuItem_Click);
            // 
            // commandKeysMenuItem
            // 
            this.commandKeysMenuItem.AccessibleName = "Command keys";
            this.commandKeysMenuItem.Name = "commandKeysMenuItem";
            this.commandKeysMenuItem.Size = new System.Drawing.Size(260, 40);
            this.commandKeysMenuItem.Text = "&Command keys";
            this.commandKeysMenuItem.Visible = false;
            this.commandKeysMenuItem.Click += new System.EventHandler(this.commandKeysMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(257, 6);
            // 
            // keyboardMenuItem
            // 
            this.keyboardMenuItem.AccessibleName = "Keyboard...";
            this.keyboardMenuItem.Name = "keyboardMenuItem";
            this.keyboardMenuItem.Size = new System.Drawing.Size(260, 40);
            this.keyboardMenuItem.Text = "&Keyboard...";
            this.keyboardMenuItem.Click += new System.EventHandler(this.keyboardMenuItem_Click);
            // 
            // issueTrackerMenuItem
            // 
            this.issueTrackerMenuItem.AccessibleName = "Issue tracker...";
            this.issueTrackerMenuItem.Name = "issueTrackerMenuItem";
            this.issueTrackerMenuItem.Size = new System.Drawing.Size(260, 40);
            this.issueTrackerMenuItem.Text = "&Issue tracker...";
            this.issueTrackerMenuItem.Click += new System.EventHandler(this.issueTrackerMenuItem_Click);
            // 
            // websiteMenuItem
            // 
            this.websiteMenuItem.AccessibleName = "Website...";
            this.websiteMenuItem.Name = "websiteMenuItem";
            this.websiteMenuItem.Size = new System.Drawing.Size(260, 40);
            this.websiteMenuItem.Text = "&Website...";
            this.websiteMenuItem.Click += new System.EventHandler(this.websiteMenuItem_Click);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.AccessibleName = "About...";
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(260, 40);
            this.aboutMenuItem.Text = "&About...";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(257, 6);
            // 
            // restartMenuItem
            // 
            this.restartMenuItem.AccessibleName = "Restart";
            this.restartMenuItem.Name = "restartMenuItem";
            this.restartMenuItem.Size = new System.Drawing.Size(260, 40);
            this.restartMenuItem.Text = "&Restart";
            this.restartMenuItem.Click += new System.EventHandler(this.restartMenuItem_Click);
            // 
            // shutDownMenuItem
            // 
            this.shutDownMenuItem.AccessibleName = "Shutdown";
            this.shutDownMenuItem.Name = "shutDownMenuItem";
            this.shutDownMenuItem.Size = new System.Drawing.Size(260, 40);
            this.shutDownMenuItem.Text = "&Shutdown";
            this.shutDownMenuItem.Click += new System.EventHandler(this.shutDownMenuItem_Click);
            // 
            // TFMMainForm
            // 
            this.AccessibleDescription = "";
            this.AccessibleName = "Talking flight moniter";
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "TFMMainForm";
            this.Text = "Talking flight moniter";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.TFMMainForm_Load);
            this.trayIconContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker dbLoadWorker;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayIconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandKeysMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem keyboardMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueTrackerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem websiteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem restartMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shutDownMenuItem;
    }
}

