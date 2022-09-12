namespace tfm.PMDG.PMDG737.McpComponents
{
    partial class mcpHeading
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
            this.headingFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.headingLabel = new System.Windows.Forms.Label();
            this.headingTextBox = new System.Windows.Forms.TextBox();
            this.hdgSelButton = new System.Windows.Forms.Button();
            this.lNavButton = new System.Windows.Forms.Button();
            this.hdgSelLabel = new System.Windows.Forms.Label();
            this.hdgSelTextBox = new System.Windows.Forms.TextBox();
            this.lNavLabel = new System.Windows.Forms.Label();
            this.lnavTextBox = new System.Windows.Forms.TextBox();
            this.headingFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headingFlowLayoutPanel
            // 
            this.headingFlowLayoutPanel.AutoSize = true;
            this.headingFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.headingFlowLayoutPanel.Controls.Add(this.headingLabel);
            this.headingFlowLayoutPanel.Controls.Add(this.headingTextBox);
            this.headingFlowLayoutPanel.Controls.Add(this.hdgSelButton);
            this.headingFlowLayoutPanel.Controls.Add(this.lNavButton);
            this.headingFlowLayoutPanel.Controls.Add(this.hdgSelLabel);
            this.headingFlowLayoutPanel.Controls.Add(this.hdgSelTextBox);
            this.headingFlowLayoutPanel.Controls.Add(this.lNavLabel);
            this.headingFlowLayoutPanel.Controls.Add(this.lnavTextBox);
            this.headingFlowLayoutPanel.Location = new System.Drawing.Point(8, -35);
            this.headingFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(5);
            this.headingFlowLayoutPanel.Name = "headingFlowLayoutPanel";
            this.headingFlowLayoutPanel.Size = new System.Drawing.Size(1062, 53);
            this.headingFlowLayoutPanel.TabIndex = 0;
            // 
            // headingLabel
            // 
            this.headingLabel.AutoSize = true;
            this.headingLabel.Location = new System.Drawing.Point(17, 8);
            this.headingLabel.Margin = new System.Windows.Forms.Padding(17, 8, 8, 8);
            this.headingLabel.Name = "headingLabel";
            this.headingLabel.Size = new System.Drawing.Size(119, 33);
            this.headingLabel.TabIndex = 0;
            this.headingLabel.Text = "H&eeading";
            // 
            // headingTextBox
            // 
            this.headingTextBox.AccessibleName = "Heading";
            this.headingTextBox.Location = new System.Drawing.Point(147, 3);
            this.headingTextBox.Name = "headingTextBox";
            this.headingTextBox.Size = new System.Drawing.Size(100, 40);
            this.headingTextBox.TabIndex = 1;
            this.headingTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.headingTextBox_KeyDown);
            // 
            // hdgSelButton
            // 
            this.hdgSelButton.AutoSize = true;
            this.hdgSelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.hdgSelButton.Location = new System.Drawing.Point(300, 5);
            this.hdgSelButton.Margin = new System.Windows.Forms.Padding(50, 5, 5, 3);
            this.hdgSelButton.Name = "hdgSelButton";
            this.hdgSelButton.Size = new System.Drawing.Size(111, 43);
            this.hdgSelButton.TabIndex = 2;
            this.hdgSelButton.Text = "button1";
            this.hdgSelButton.UseVisualStyleBackColor = true;
            this.hdgSelButton.Click += new System.EventHandler(this.hdgSelButton_Click);
            // 
            // lNavButton
            // 
            this.lNavButton.AutoSize = true;
            this.lNavButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lNavButton.Location = new System.Drawing.Point(421, 5);
            this.lNavButton.Margin = new System.Windows.Forms.Padding(5, 5, 50, 5);
            this.lNavButton.Name = "lNavButton";
            this.lNavButton.Size = new System.Drawing.Size(111, 43);
            this.lNavButton.TabIndex = 3;
            this.lNavButton.Text = "button1";
            this.lNavButton.UseVisualStyleBackColor = true;
            this.lNavButton.Click += new System.EventHandler(this.lNavButton_Click);
            // 
            // hdgSelLabel
            // 
            this.hdgSelLabel.AutoSize = true;
            this.hdgSelLabel.Location = new System.Drawing.Point(587, 5);
            this.hdgSelLabel.Margin = new System.Windows.Forms.Padding(5);
            this.hdgSelLabel.Name = "hdgSelLabel";
            this.hdgSelLabel.Size = new System.Drawing.Size(132, 33);
            this.hdgSelLabel.TabIndex = 4;
            this.hdgSelLabel.Text = "&1. Hdg Sel";
            // 
            // hdgSelTextBox
            // 
            this.hdgSelTextBox.AccessibleName = "Heading select";
            this.hdgSelTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.hdgSelTextBox.Location = new System.Drawing.Point(729, 5);
            this.hdgSelTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.hdgSelTextBox.Name = "hdgSelTextBox";
            this.hdgSelTextBox.ReadOnly = true;
            this.hdgSelTextBox.Size = new System.Drawing.Size(100, 40);
            this.hdgSelTextBox.TabIndex = 5;
            this.hdgSelTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lNavLabel
            // 
            this.lNavLabel.AutoSize = true;
            this.lNavLabel.Location = new System.Drawing.Point(844, 5);
            this.lNavLabel.Margin = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.lNavLabel.Name = "lNavLabel";
            this.lNavLabel.Size = new System.Drawing.Size(103, 33);
            this.lNavLabel.TabIndex = 6;
            this.lNavLabel.Text = "&2. LNav";
            // 
            // lnavTextBox
            // 
            this.lnavTextBox.AccessibleName = "LNav";
            this.lnavTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.lnavTextBox.Location = new System.Drawing.Point(957, 5);
            this.lnavTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.lnavTextBox.Name = "lnavTextBox";
            this.lnavTextBox.ReadOnly = true;
            this.lnavTextBox.Size = new System.Drawing.Size(100, 40);
            this.lnavTextBox.TabIndex = 7;
            this.lnavTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mcpHeading
            // 
            this.AccessibleName = "MCP heading";
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1078, 17);
            this.Controls.Add(this.headingFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "mcpHeading";
            this.Text = "MCP heading";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mcpHeading_FormClosing);
            this.Load += new System.EventHandler(this.mcpHeading_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mcpHeading_KeyDown);
            this.headingFlowLayoutPanel.ResumeLayout(false);
            this.headingFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel headingFlowLayoutPanel;
        private System.Windows.Forms.Label headingLabel;
        private System.Windows.Forms.TextBox headingTextBox;
        private System.Windows.Forms.Button hdgSelButton;
        private System.Windows.Forms.Button lNavButton;
        private System.Windows.Forms.Label hdgSelLabel;
        private System.Windows.Forms.TextBox hdgSelTextBox;
        private System.Windows.Forms.Label lNavLabel;
        private System.Windows.Forms.TextBox lnavTextBox;
    }
}