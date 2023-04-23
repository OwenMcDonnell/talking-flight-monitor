namespace tfm.SimBrief
{
    partial class ctlNavlog
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.navlogListView = new System.Windows.Forms.ListView();
            this.navlogContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.columsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distanceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altitudeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moreDetailsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windDataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navlogContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // navlogListView
            // 
            this.navlogListView.AccessibleName = "Navlog";
            this.navlogListView.ContextMenuStrip = this.navlogContextMenu;
            this.navlogListView.HideSelection = false;
            this.navlogListView.Location = new System.Drawing.Point(0, 0);
            this.navlogListView.Name = "navlogListView";
            this.navlogListView.Size = new System.Drawing.Size(1100, 667);
            this.navlogListView.TabIndex = 0;
            this.navlogListView.UseCompatibleStateImageBehavior = false;
            this.navlogListView.View = System.Windows.Forms.View.Details;
            this.navlogListView.SelectedIndexChanged += new System.EventHandler(this.navlogListView_SelectedIndexChanged);
            // 
            // navlogContextMenu
            // 
            this.navlogContextMenu.AccessibleName = "Navlog menu";
            this.navlogContextMenu.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navlogContextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.navlogContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.columsMenuItem,
            this.moreDetailsMenuItem,
            this.windDataMenuItem});
            this.navlogContextMenu.Name = "navlogContextMenu";
            this.navlogContextMenu.Size = new System.Drawing.Size(347, 157);
            // 
            // columsMenuItem
            // 
            this.columsMenuItem.AccessibleName = "Show/hide columns";
            this.columsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.typeMenuItem,
            this.nameMenuItem,
            this.distanceMenuItem,
            this.altitudeMenuItem});
            this.columsMenuItem.Name = "columsMenuItem";
            this.columsMenuItem.Size = new System.Drawing.Size(346, 40);
            this.columsMenuItem.Text = "Columns";
            // 
            // typeMenuItem
            // 
            this.typeMenuItem.CheckOnClick = true;
            this.typeMenuItem.Name = "typeMenuItem";
            this.typeMenuItem.Size = new System.Drawing.Size(270, 42);
            this.typeMenuItem.Text = "&Type";
            this.typeMenuItem.CheckStateChanged += new System.EventHandler(this.typeMenuItem_CheckStateChanged);
            // 
            // nameMenuItem
            // 
            this.nameMenuItem.CheckOnClick = true;
            this.nameMenuItem.Name = "nameMenuItem";
            this.nameMenuItem.Size = new System.Drawing.Size(270, 42);
            this.nameMenuItem.Text = "&Name";
            this.nameMenuItem.CheckStateChanged += new System.EventHandler(this.nameMenuItem_CheckStateChanged);
            // 
            // distanceMenuItem
            // 
            this.distanceMenuItem.CheckOnClick = true;
            this.distanceMenuItem.Name = "distanceMenuItem";
            this.distanceMenuItem.Size = new System.Drawing.Size(270, 42);
            this.distanceMenuItem.Text = "&Distance";
            this.distanceMenuItem.CheckStateChanged += new System.EventHandler(this.distanceMenuItem_CheckStateChanged);
            // 
            // altitudeMenuItem
            // 
            this.altitudeMenuItem.CheckOnClick = true;
            this.altitudeMenuItem.Name = "altitudeMenuItem";
            this.altitudeMenuItem.Size = new System.Drawing.Size(270, 42);
            this.altitudeMenuItem.Text = "&Altitude";
            this.altitudeMenuItem.CheckStateChanged += new System.EventHandler(this.altitudeMenuItem_CheckStateChanged);
            // 
            // moreDetailsMenuItem
            // 
            this.moreDetailsMenuItem.AccessibleName = "More details...";
            this.moreDetailsMenuItem.Name = "moreDetailsMenuItem";
            this.moreDetailsMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.moreDetailsMenuItem.Size = new System.Drawing.Size(346, 40);
            this.moreDetailsMenuItem.Text = "More &details...";
            this.moreDetailsMenuItem.Click += new System.EventHandler(this.moreDetailsMenuItem_Click);
            // 
            // windDataMenuItem
            // 
            this.windDataMenuItem.AccessibleName = "Wind data...";
            this.windDataMenuItem.Name = "windDataMenuItem";
            this.windDataMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.windDataMenuItem.Size = new System.Drawing.Size(346, 40);
            this.windDataMenuItem.Text = "&Wind data";
            // 
            // ctlNavlog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.navlogListView);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlNavlog";
            this.Size = new System.Drawing.Size(1103, 670);
            this.Load += new System.EventHandler(this.ctlNavlog_Load);
            this.navlogContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView navlogListView;
        private System.Windows.Forms.ContextMenuStrip navlogContextMenu;
        private System.Windows.Forms.ToolStripMenuItem columsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem typeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nameMenuItem;
        private System.Windows.Forms.ToolStripMenuItem distanceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altitudeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moreDetailsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windDataMenuItem;
    }
}
