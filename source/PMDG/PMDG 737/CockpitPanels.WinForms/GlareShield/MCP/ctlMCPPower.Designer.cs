namespace tfm.PMDG.PMDG_737.CockpitPanels.GlareShield.MCP
{
    partial class ctlMCPPower
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
            this.mcpPowerFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.powerLabel = new System.Windows.Forms.Label();
            this.powerTextBox = new System.Windows.Forms.TextBox();
            this.mcpPowerFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mcpPowerFlowLayoutPanel
            // 
            this.mcpPowerFlowLayoutPanel.AutoSize = true;
            this.mcpPowerFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mcpPowerFlowLayoutPanel.Controls.Add(this.powerLabel);
            this.mcpPowerFlowLayoutPanel.Controls.Add(this.powerTextBox);
            this.mcpPowerFlowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.mcpPowerFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.mcpPowerFlowLayoutPanel.Name = "mcpPowerFlowLayoutPanel";
            this.mcpPowerFlowLayoutPanel.Size = new System.Drawing.Size(194, 46);
            this.mcpPowerFlowLayoutPanel.TabIndex = 0;
            // 
            // powerLabel
            // 
            this.powerLabel.AutoSize = true;
            this.powerLabel.Location = new System.Drawing.Point(10, 0);
            this.powerLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.powerLabel.Name = "powerLabel";
            this.powerLabel.Size = new System.Drawing.Size(85, 33);
            this.powerLabel.TabIndex = 0;
            this.powerLabel.Text = "&Power";
            // 
            // powerTextBox
            // 
            this.powerTextBox.AccessibleName = "MCp power";
            this.powerTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.powerTextBox.Location = new System.Drawing.Point(101, 3);
            this.powerTextBox.Name = "powerTextBox";
            this.powerTextBox.ReadOnly = true;
            this.powerTextBox.Size = new System.Drawing.Size(90, 40);
            this.powerTextBox.TabIndex = 1;
            this.powerTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ctlMCPPower
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.mcpPowerFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlMCPPower";
            this.Size = new System.Drawing.Size(200, 52);
            this.Load += new System.EventHandler(this.ctlMCPPower_Load);
            this.mcpPowerFlowLayoutPanel.ResumeLayout(false);
            this.mcpPowerFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel mcpPowerFlowLayoutPanel;
        private System.Windows.Forms.Label powerLabel;
        private System.Windows.Forms.TextBox powerTextBox;
    }
}
