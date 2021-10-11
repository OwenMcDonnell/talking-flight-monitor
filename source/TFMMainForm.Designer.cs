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
            this.settingsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.commandKeysToggleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.keyboardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportBugMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.websiteMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.connectToSimMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutDownMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trayIconContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dbLoadWorker
            // 
            this.dbLoadWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.dbLoadWorker_DoWork);
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
            this.settingsMenu,
            this.commandKeysToggleMenuItem,
            this.toolStripSeparator3,
            this.keyboardMenuItem,
            this.reportBugMenuItem,
            this.websiteMenu,
            this.aboutMenu,
            this.toolStripSeparator4,
            this.connectToSimMenuItem,
            this.shutDownMenuItem});
            this.trayIconContextMenu.Name = "trayIconContextMenu";
            this.trayIconContextMenu.Size = new System.Drawing.Size(324, 336);
            this.trayIconContextMenu.Text = "TFM";
            // 
            // settingsMenu
            // 
            this.settingsMenu.AccessibleName = "Settings...";
            this.settingsMenu.Name = "settingsMenu";
            this.settingsMenu.Size = new System.Drawing.Size(323, 40);
            this.settingsMenu.Text = "&Settings";
            // 
            // commandKeysToggleMenuItem
            // 
            this.commandKeysToggleMenuItem.AccessibleName = "Command keys";
            this.commandKeysToggleMenuItem.Name = "commandKeysToggleMenuItem";
            this.commandKeysToggleMenuItem.Size = new System.Drawing.Size(323, 40);
            this.commandKeysToggleMenuItem.Text = "&Command keys";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(320, 6);
            // 
            // keyboardMenuItem
            // 
            this.keyboardMenuItem.AccessibleName = "Keyboard...";
            this.keyboardMenuItem.Name = "keyboardMenuItem";
            this.keyboardMenuItem.Size = new System.Drawing.Size(323, 40);
            this.keyboardMenuItem.Text = "&Keyboard...";
            // 
            // reportBugMenuItem
            // 
            this.reportBugMenuItem.AccessibleName = "Report a bug";
            this.reportBugMenuItem.Name = "reportBugMenuItem";
            this.reportBugMenuItem.Size = new System.Drawing.Size(323, 40);
            this.reportBugMenuItem.Text = "&Report a bug";
            // 
            // websiteMenu
            // 
            this.websiteMenu.AccessibleName = "Website...";
            this.websiteMenu.Name = "websiteMenu";
            this.websiteMenu.Size = new System.Drawing.Size(323, 40);
            this.websiteMenu.Text = "&Website...";
            // 
            // aboutMenu
            // 
            this.aboutMenu.AccessibleName = "About...";
            this.aboutMenu.Name = "aboutMenu";
            this.aboutMenu.Size = new System.Drawing.Size(323, 40);
            this.aboutMenu.Text = "&About...";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(320, 6);
            // 
            // connectToSimMenuItem
            // 
            this.connectToSimMenuItem.AccessibleName = "Connect to simulator";
            this.connectToSimMenuItem.Name = "connectToSimMenuItem";
            this.connectToSimMenuItem.Size = new System.Drawing.Size(323, 40);
            this.connectToSimMenuItem.Text = "&Connect to simulator";
            // 
            // shutDownMenuItem
            // 
            this.shutDownMenuItem.AccessibleName = "Shutdown";
            this.shutDownMenuItem.Name = "shutDownMenuItem";
            this.shutDownMenuItem.Size = new System.Drawing.Size(323, 40);
            this.shutDownMenuItem.Text = "&Shutdown";
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
            this.trayIconContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker dbLoadWorker;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayIconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem settingsMenu;
        private System.Windows.Forms.ToolStripMenuItem commandKeysToggleMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem keyboardMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportBugMenuItem;
        private System.Windows.Forms.ToolStripMenuItem websiteMenu;
        private System.Windows.Forms.ToolStripMenuItem aboutMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem connectToSimMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shutDownMenuItem;
    }
}

