namespace tfm.SimBrief
{
    partial class SimBriefForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Navlog");
            this.contentPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.flightPlanCategoriesTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.contentPanel.Location = new System.Drawing.Point(307, 14);
            this.contentPanel.Margin = new System.Windows.Forms.Padding(5);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1033, 667);
            this.contentPanel.TabIndex = 4;
            // 
            // closeButton
            // 
            this.closeButton.AccessibleName = "Close the weather center.";
            this.closeButton.AutoSize = true;
            this.closeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.closeButton.Location = new System.Drawing.Point(622, 699);
            this.closeButton.Margin = new System.Windows.Forms.Padding(5);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(89, 43);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // flightPlanCategoriesTreeView
            // 
            this.flightPlanCategoriesTreeView.AccessibleName = "Flight plan sections";
            this.flightPlanCategoriesTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.flightPlanCategoriesTreeView.Location = new System.Drawing.Point(0, 0);
            this.flightPlanCategoriesTreeView.Margin = new System.Windows.Forms.Padding(8);
            this.flightPlanCategoriesTreeView.Name = "flightPlanCategoriesTreeView";
            treeNode1.Name = "navlogNode";
            treeNode1.Text = "Navlog";
            this.flightPlanCategoriesTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.flightPlanCategoriesTreeView.Size = new System.Drawing.Size(299, 742);
            this.flightPlanCategoriesTreeView.TabIndex = 3;
            this.flightPlanCategoriesTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.flightPlanCategoriesTreeView_AfterSelect);
            // 
            // SimBriefForm
            // 
            this.AccessibleName = "SimBrief flight plan";
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1333, 742);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.flightPlanCategoriesTreeView);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "SimBriefForm";
            this.Text = "SimBrief flight plan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TreeView flightPlanCategoriesTreeView;
    }
}