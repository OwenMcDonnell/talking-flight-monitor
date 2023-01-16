namespace tfm
{
    partial class ctlDatabases
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
            this.p3dFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.p3dLabel = new System.Windows.Forms.Label();
            this.p3dPathTextBox = new System.Windows.Forms.TextBox();
            this.p3dBrowseButton = new System.Windows.Forms.Button();
            this.msfsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.msfsLabel = new System.Windows.Forms.Label();
            this.msfsTextBox = new System.Windows.Forms.TextBox();
            this.msfsBrowseButton = new System.Windows.Forms.Button();
            this.rebuildAirportsDatabaseButton = new System.Windows.Forms.Button();
            this.p3dFlowLayoutPanel.SuspendLayout();
            this.msfsFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // p3dFlowLayoutPanel
            // 
            this.p3dFlowLayoutPanel.AutoSize = true;
            this.p3dFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.p3dFlowLayoutPanel.Controls.Add(this.p3dLabel);
            this.p3dFlowLayoutPanel.Controls.Add(this.p3dPathTextBox);
            this.p3dFlowLayoutPanel.Controls.Add(this.p3dBrowseButton);
            this.p3dFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.p3dFlowLayoutPanel.Name = "p3dFlowLayoutPanel";
            this.p3dFlowLayoutPanel.Padding = new System.Windows.Forms.Padding(3);
            this.p3dFlowLayoutPanel.Size = new System.Drawing.Size(696, 52);
            this.p3dFlowLayoutPanel.TabIndex = 0;
            // 
            // p3dLabel
            // 
            this.p3dLabel.AccessibleName = "";
            this.p3dLabel.AutoSize = true;
            this.p3dLabel.Location = new System.Drawing.Point(13, 3);
            this.p3dLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.p3dLabel.Name = "p3dLabel";
            this.p3dLabel.Size = new System.Drawing.Size(73, 33);
            this.p3dLabel.TabIndex = 0;
            this.p3dLabel.Text = "&P3D:";
            // 
            // p3dPathTextBox
            // 
            this.p3dPathTextBox.AccessibleName = "P3D Database path";
            this.p3dPathTextBox.Location = new System.Drawing.Point(92, 6);
            this.p3dPathTextBox.Name = "p3dPathTextBox";
            this.p3dPathTextBox.Size = new System.Drawing.Size(500, 40);
            this.p3dPathTextBox.TabIndex = 1;
            // 
            // p3dBrowseButton
            // 
            this.p3dBrowseButton.AccessibleName = "Browse for P3D airports database...";
            this.p3dBrowseButton.Location = new System.Drawing.Point(615, 6);
            this.p3dBrowseButton.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.p3dBrowseButton.Name = "p3dBrowseButton";
            this.p3dBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.p3dBrowseButton.TabIndex = 2;
            this.p3dBrowseButton.Text = "&Browse...";
            this.p3dBrowseButton.UseVisualStyleBackColor = true;
            this.p3dBrowseButton.Click += new System.EventHandler(this.p3dBrowseButton_Click);
            // 
            // msfsFlowLayoutPanel
            // 
            this.msfsFlowLayoutPanel.AutoSize = true;
            this.msfsFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.msfsFlowLayoutPanel.Controls.Add(this.msfsLabel);
            this.msfsFlowLayoutPanel.Controls.Add(this.msfsTextBox);
            this.msfsFlowLayoutPanel.Controls.Add(this.msfsBrowseButton);
            this.msfsFlowLayoutPanel.Location = new System.Drawing.Point(0, 66);
            this.msfsFlowLayoutPanel.Name = "msfsFlowLayoutPanel";
            this.msfsFlowLayoutPanel.Size = new System.Drawing.Size(751, 49);
            this.msfsFlowLayoutPanel.TabIndex = 1;
            // 
            // msfsLabel
            // 
            this.msfsLabel.AutoSize = true;
            this.msfsLabel.Location = new System.Drawing.Point(10, 0);
            this.msfsLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.msfsLabel.Name = "msfsLabel";
            this.msfsLabel.Size = new System.Drawing.Size(96, 33);
            this.msfsLabel.TabIndex = 0;
            this.msfsLabel.Text = "&MSFS:";
            // 
            // msfsTextBox
            // 
            this.msfsTextBox.AccessibleName = "MSFS airports database folder";
            this.msfsTextBox.Location = new System.Drawing.Point(112, 3);
            this.msfsTextBox.Name = "msfsTextBox";
            this.msfsTextBox.Size = new System.Drawing.Size(500, 40);
            this.msfsTextBox.TabIndex = 1;
            // 
            // msfsBrowseButton
            // 
            this.msfsBrowseButton.AccessibleName = "Browse for MSFS airports database";
            this.msfsBrowseButton.AutoSize = true;
            this.msfsBrowseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.msfsBrowseButton.Location = new System.Drawing.Point(618, 3);
            this.msfsBrowseButton.Name = "msfsBrowseButton";
            this.msfsBrowseButton.Size = new System.Drawing.Size(130, 43);
            this.msfsBrowseButton.TabIndex = 2;
            this.msfsBrowseButton.Text = "B&rowse...";
            this.msfsBrowseButton.UseVisualStyleBackColor = true;
            this.msfsBrowseButton.Click += new System.EventHandler(this.msfsBrowseButton_Click);
            // 
            // rebuildAirportsDatabaseButton
            // 
            this.rebuildAirportsDatabaseButton.AccessibleName = "Rebuild airports database";
            this.rebuildAirportsDatabaseButton.AutoSize = true;
            this.rebuildAirportsDatabaseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rebuildAirportsDatabaseButton.Location = new System.Drawing.Point(269, 130);
            this.rebuildAirportsDatabaseButton.Name = "rebuildAirportsDatabaseButton";
            this.rebuildAirportsDatabaseButton.Size = new System.Drawing.Size(216, 43);
            this.rebuildAirportsDatabaseButton.TabIndex = 2;
            this.rebuildAirportsDatabaseButton.Text = "Reb&uild database";
            this.rebuildAirportsDatabaseButton.UseVisualStyleBackColor = true;
            this.rebuildAirportsDatabaseButton.Click += new System.EventHandler(this.rebuildAirportsDatabaseButton_Click);
            // 
            // ctlDatabases
            // 
            this.AccessibleName = "Airport databases";
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.rebuildAirportsDatabaseButton);
            this.Controls.Add(this.msfsFlowLayoutPanel);
            this.Controls.Add(this.p3dFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ctlDatabases";
            this.Size = new System.Drawing.Size(754, 176);
            this.Load += new System.EventHandler(this.ctlDatabases_Load);
            this.p3dFlowLayoutPanel.ResumeLayout(false);
            this.p3dFlowLayoutPanel.PerformLayout();
            this.msfsFlowLayoutPanel.ResumeLayout(false);
            this.msfsFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel p3dFlowLayoutPanel;
        private System.Windows.Forms.Label p3dLabel;
        private System.Windows.Forms.TextBox p3dPathTextBox;
        private System.Windows.Forms.Button p3dBrowseButton;
        private System.Windows.Forms.FlowLayoutPanel msfsFlowLayoutPanel;
        private System.Windows.Forms.Label msfsLabel;
        private System.Windows.Forms.TextBox msfsTextBox;
        private System.Windows.Forms.Button msfsBrowseButton;
        private System.Windows.Forms.Button rebuildAirportsDatabaseButton;
    }
}
