namespace tfm.Weather
{
    partial class WeatherCenterForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Wind");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Clouds");
            this.weatherCategoriesTreeView = new System.Windows.Forms.TreeView();
            this.closeButton = new System.Windows.Forms.Button();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // weatherCategoriesTreeView
            // 
            this.weatherCategoriesTreeView.AccessibleName = "Weather categories";
            this.weatherCategoriesTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.weatherCategoriesTreeView.Location = new System.Drawing.Point(0, 0);
            this.weatherCategoriesTreeView.Margin = new System.Windows.Forms.Padding(5);
            this.weatherCategoriesTreeView.Name = "weatherCategoriesTreeView";
            treeNode1.Name = "windNode";
            treeNode1.Text = "Wind";
            treeNode2.Name = "cloudsNode";
            treeNode2.Text = "Clouds";
            this.weatherCategoriesTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.weatherCategoriesTreeView.Size = new System.Drawing.Size(300, 742);
            this.weatherCategoriesTreeView.TabIndex = 0;
            this.weatherCategoriesTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.weatherCategoriesTreeView_AfterSelect);
            // 
            // closeButton
            // 
            this.closeButton.AccessibleName = "Close the weather center.";
            this.closeButton.AutoSize = true;
            this.closeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.closeButton.Location = new System.Drawing.Point(622, 697);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(89, 43);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // contentPanel
            // 
            this.contentPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.contentPanel.Location = new System.Drawing.Point(308, 2);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1033, 676);
            this.contentPanel.TabIndex = 1;
            // 
            // WeatherCenterForm
            // 
            this.AccessibleName = "Weather center";
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1333, 742);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.weatherCategoriesTreeView);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "WeatherCenterForm";
            this.Text = "Weather center";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WeatherCenterForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView weatherCategoriesTreeView;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Panel contentPanel;
    }
}