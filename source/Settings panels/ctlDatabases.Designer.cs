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
            this.p3dFlowLayoutPanel.SuspendLayout();
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
            this.p3dFlowLayoutPanel.Size = new System.Drawing.Size(576, 52);
            this.p3dFlowLayoutPanel.TabIndex = 0;
            // 
            // p3dLabel
            // 
            this.p3dLabel.AccessibleName = "P3D label";
            this.p3dLabel.AutoSize = true;
            this.p3dLabel.Location = new System.Drawing.Point(6, 3);
            this.p3dLabel.Name = "p3dLabel";
            this.p3dLabel.Size = new System.Drawing.Size(110, 33);
            this.p3dLabel.TabIndex = 0;
            this.p3dLabel.Text = "P3d 4/5:";
            // 
            // p3dPathTextBox
            // 
            this.p3dPathTextBox.AccessibleName = "P3D Database path";
            this.p3dPathTextBox.Location = new System.Drawing.Point(122, 6);
            this.p3dPathTextBox.Name = "p3dPathTextBox";
            this.p3dPathTextBox.Size = new System.Drawing.Size(350, 40);
            this.p3dPathTextBox.TabIndex = 1;
            // 
            // p3dBrowseButton
            // 
            this.p3dBrowseButton.AccessibleName = "Browse for P3D airports database...";
            this.p3dBrowseButton.Location = new System.Drawing.Point(495, 6);
            this.p3dBrowseButton.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.p3dBrowseButton.Name = "p3dBrowseButton";
            this.p3dBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.p3dBrowseButton.TabIndex = 2;
            this.p3dBrowseButton.Text = "&Browse...";
            this.p3dBrowseButton.UseVisualStyleBackColor = true;
            this.p3dBrowseButton.Click += new System.EventHandler(this.p3dBrowseButton_Click);
            // 
            // ctlDatabases
            // 
            this.AccessibleName = "Airport databases";
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.p3dFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ctlDatabases";
            this.Size = new System.Drawing.Size(579, 55);
            this.Load += new System.EventHandler(this.ctlDatabases_Load);
            this.p3dFlowLayoutPanel.ResumeLayout(false);
            this.p3dFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel p3dFlowLayoutPanel;
        private System.Windows.Forms.Label p3dLabel;
        private System.Windows.Forms.TextBox p3dPathTextBox;
        private System.Windows.Forms.Button p3dBrowseButton;
    }
}
