namespace tfm.PMDG.PMDG737.McpComponents
{
    partial class mcpVerticalSpeed
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
            this.vertSpeedFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.vertSpeedLabel = new System.Windows.Forms.Label();
            this.verticalSpeedTextBox = new System.Windows.Forms.TextBox();
            this.verticalSpeedButton = new System.Windows.Forms.Button();
            this.vertSpeedLightLabel = new System.Windows.Forms.Label();
            this.verticalSpeedLightTextBox = new System.Windows.Forms.TextBox();
            this.vertSpeedFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // vertSpeedFlowLayoutPanel
            // 
            this.vertSpeedFlowLayoutPanel.AutoSize = true;
            this.vertSpeedFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.vertSpeedFlowLayoutPanel.Controls.Add(this.vertSpeedLabel);
            this.vertSpeedFlowLayoutPanel.Controls.Add(this.verticalSpeedTextBox);
            this.vertSpeedFlowLayoutPanel.Controls.Add(this.verticalSpeedButton);
            this.vertSpeedFlowLayoutPanel.Controls.Add(this.vertSpeedLightLabel);
            this.vertSpeedFlowLayoutPanel.Controls.Add(this.verticalSpeedLightTextBox);
            this.vertSpeedFlowLayoutPanel.Location = new System.Drawing.Point(10, 10);
            this.vertSpeedFlowLayoutPanel.Name = "vertSpeedFlowLayoutPanel";
            this.vertSpeedFlowLayoutPanel.Size = new System.Drawing.Size(773, 53);
            this.vertSpeedFlowLayoutPanel.TabIndex = 0;
            // 
            // vertSpeedLabel
            // 
            this.vertSpeedLabel.AutoSize = true;
            this.vertSpeedLabel.Location = new System.Drawing.Point(10, 5);
            this.vertSpeedLabel.Margin = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.vertSpeedLabel.Name = "vertSpeedLabel";
            this.vertSpeedLabel.Size = new System.Drawing.Size(171, 33);
            this.vertSpeedLabel.TabIndex = 0;
            this.vertSpeedLabel.Text = "Vertical sp&eed";
            // 
            // verticalSpeedTextBox
            // 
            this.verticalSpeedTextBox.AccessibleName = "Vertical speed";
            this.verticalSpeedTextBox.Location = new System.Drawing.Point(189, 3);
            this.verticalSpeedTextBox.Name = "verticalSpeedTextBox";
            this.verticalSpeedTextBox.Size = new System.Drawing.Size(100, 40);
            this.verticalSpeedTextBox.TabIndex = 1;
            this.verticalSpeedTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.verticalSpeedTextBox_KeyDown);
            // 
            // verticalSpeedButton
            // 
            this.verticalSpeedButton.AutoSize = true;
            this.verticalSpeedButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.verticalSpeedButton.Location = new System.Drawing.Point(322, 5);
            this.verticalSpeedButton.Margin = new System.Windows.Forms.Padding(30, 5, 30, 5);
            this.verticalSpeedButton.Name = "verticalSpeedButton";
            this.verticalSpeedButton.Size = new System.Drawing.Size(111, 43);
            this.verticalSpeedButton.TabIndex = 2;
            this.verticalSpeedButton.Text = "button1";
            this.verticalSpeedButton.UseVisualStyleBackColor = true;
            this.verticalSpeedButton.Click += new System.EventHandler(this.verticalSpeedButton_Click);
            // 
            // vertSpeedLightLabel
            // 
            this.vertSpeedLightLabel.AutoSize = true;
            this.vertSpeedLightLabel.Location = new System.Drawing.Point(466, 0);
            this.vertSpeedLightLabel.Name = "vertSpeedLightLabel";
            this.vertSpeedLightLabel.Size = new System.Drawing.Size(198, 33);
            this.vertSpeedLightLabel.TabIndex = 3;
            this.vertSpeedLightLabel.Text = "&1. Vertical speed";
            // 
            // verticalSpeedLightTextBox
            // 
            this.verticalSpeedLightTextBox.AccessibleName = "Vertical speed";
            this.verticalSpeedLightTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.verticalSpeedLightTextBox.Location = new System.Drawing.Point(670, 3);
            this.verticalSpeedLightTextBox.Name = "verticalSpeedLightTextBox";
            this.verticalSpeedLightTextBox.ReadOnly = true;
            this.verticalSpeedLightTextBox.Size = new System.Drawing.Size(100, 40);
            this.verticalSpeedLightTextBox.TabIndex = 4;
            this.verticalSpeedLightTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mcpVerticalSpeed
            // 
            this.AccessibleName = "MCP vertical speed";
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(793, 73);
            this.Controls.Add(this.vertSpeedFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "mcpVerticalSpeed";
            this.Text = "MCP vertical speed";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mcpVerticalSpeed_FormClosing);
            this.Load += new System.EventHandler(this.mcpVerticalSpeed_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mcpVerticalSpeed_KeyDown);
            this.vertSpeedFlowLayoutPanel.ResumeLayout(false);
            this.vertSpeedFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel vertSpeedFlowLayoutPanel;
        private System.Windows.Forms.Label vertSpeedLabel;
        private System.Windows.Forms.TextBox verticalSpeedTextBox;
        private System.Windows.Forms.Button verticalSpeedButton;
        private System.Windows.Forms.Label vertSpeedLightLabel;
        private System.Windows.Forms.TextBox verticalSpeedLightTextBox;
    }
}