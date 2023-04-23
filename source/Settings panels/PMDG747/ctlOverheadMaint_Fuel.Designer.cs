namespace tfm.Settings_panels.PMDG747
{
    partial class ctlOverheadMaint_Fuel
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
            this.fuelFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.scavengeCheckBox = new System.Windows.Forms.CheckBox();
            this.rsv23XferCheckBox = new System.Windows.Forms.CheckBox();
            this.fuelFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // fuelFlowLayoutPanel
            // 
            this.fuelFlowLayoutPanel.AutoSize = true;
            this.fuelFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fuelFlowLayoutPanel.Controls.Add(this.scavengeCheckBox);
            this.fuelFlowLayoutPanel.Controls.Add(this.rsv23XferCheckBox);
            this.fuelFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.fuelFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.fuelFlowLayoutPanel.Name = "fuelFlowLayoutPanel";
            this.fuelFlowLayoutPanel.Size = new System.Drawing.Size(399, 43);
            this.fuelFlowLayoutPanel.TabIndex = 0;
            // 
            // scavengeCheckBox
            // 
            this.scavengeCheckBox.AccessibleName = "CWT scavenge switch";
            this.scavengeCheckBox.AutoSize = true;
            this.scavengeCheckBox.Location = new System.Drawing.Point(3, 3);
            this.scavengeCheckBox.Name = "scavengeCheckBox";
            this.scavengeCheckBox.Size = new System.Drawing.Size(206, 37);
            this.scavengeCheckBox.TabIndex = 0;
            this.scavengeCheckBox.Text = "CWT scavenge";
            this.scavengeCheckBox.UseVisualStyleBackColor = true;
            // 
            // rsv23XferCheckBox
            // 
            this.rsv23XferCheckBox.AccessibleName = "Reserve 2-3 transfer switch";
            this.rsv23XferCheckBox.AutoSize = true;
            this.rsv23XferCheckBox.Location = new System.Drawing.Point(215, 3);
            this.rsv23XferCheckBox.Name = "rsv23XferCheckBox";
            this.rsv23XferCheckBox.Size = new System.Drawing.Size(181, 37);
            this.rsv23XferCheckBox.TabIndex = 1;
            this.rsv23XferCheckBox.Text = "RSV 23 xfer";
            this.rsv23XferCheckBox.UseVisualStyleBackColor = true;
            // 
            // ctlOverheadMaint_Fuel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.fuelFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlOverheadMaint_Fuel";
            this.Size = new System.Drawing.Size(402, 46);
            this.Load += new System.EventHandler(this.ctlOverheadMaint_Fuel_Load);
            this.fuelFlowLayoutPanel.ResumeLayout(false);
            this.fuelFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fuelFlowLayoutPanel;
        private System.Windows.Forms.CheckBox scavengeCheckBox;
        private System.Windows.Forms.CheckBox rsv23XferCheckBox;
    }
}
