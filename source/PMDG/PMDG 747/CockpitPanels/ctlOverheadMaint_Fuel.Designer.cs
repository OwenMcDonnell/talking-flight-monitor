namespace tfm.PMDG.PMDG_747.CockpitPanels
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
            this.scavengePumpButton = new System.Windows.Forms.Button();
            this.rsv23XferButton = new System.Windows.Forms.Button();
            this.fuelFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // fuelFlowLayoutPanel
            // 
            this.fuelFlowLayoutPanel.AutoSize = true;
            this.fuelFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fuelFlowLayoutPanel.Controls.Add(this.scavengePumpButton);
            this.fuelFlowLayoutPanel.Controls.Add(this.rsv23XferButton);
            this.fuelFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.fuelFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.fuelFlowLayoutPanel.Name = "fuelFlowLayoutPanel";
            this.fuelFlowLayoutPanel.Size = new System.Drawing.Size(234, 49);
            this.fuelFlowLayoutPanel.TabIndex = 0;
            // 
            // scavengePumpButton
            // 
            this.scavengePumpButton.AutoSize = true;
            this.scavengePumpButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.scavengePumpButton.Location = new System.Drawing.Point(3, 3);
            this.scavengePumpButton.Name = "scavengePumpButton";
            this.scavengePumpButton.Size = new System.Drawing.Size(111, 43);
            this.scavengePumpButton.TabIndex = 0;
            this.scavengePumpButton.Text = "button1";
            this.scavengePumpButton.UseVisualStyleBackColor = true;
            // 
            // rsv23XferButton
            // 
            this.rsv23XferButton.AutoSize = true;
            this.rsv23XferButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rsv23XferButton.Location = new System.Drawing.Point(120, 3);
            this.rsv23XferButton.Name = "rsv23XferButton";
            this.rsv23XferButton.Size = new System.Drawing.Size(111, 43);
            this.rsv23XferButton.TabIndex = 1;
            this.rsv23XferButton.Text = "button2";
            this.rsv23XferButton.UseVisualStyleBackColor = true;
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
            this.Size = new System.Drawing.Size(237, 52);
            this.Load += new System.EventHandler(this.ctlOverheadMaint_Fuel_Load);
            this.fuelFlowLayoutPanel.ResumeLayout(false);
            this.fuelFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fuelFlowLayoutPanel;
        private System.Windows.Forms.Button scavengePumpButton;
        private System.Windows.Forms.Button rsv23XferButton;
    }
}
