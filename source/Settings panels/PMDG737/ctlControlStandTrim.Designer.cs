namespace tfm.Settings_panels.PMDG737
{
    partial class ctlControlStandTrim
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
            this.trimFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.electricalTrimCheckBox = new System.Windows.Forms.CheckBox();
            this.autoPilotTrimCheckBox = new System.Windows.Forms.CheckBox();
            this.trimCheckBox = new System.Windows.Forms.CheckBox();
            this.trimFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // trimFlowLayoutPanel
            // 
            this.trimFlowLayoutPanel.AutoSize = true;
            this.trimFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.trimFlowLayoutPanel.Controls.Add(this.electricalTrimCheckBox);
            this.trimFlowLayoutPanel.Controls.Add(this.autoPilotTrimCheckBox);
            this.trimFlowLayoutPanel.Controls.Add(this.trimCheckBox);
            this.trimFlowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.trimFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.trimFlowLayoutPanel.Name = "trimFlowLayoutPanel";
            this.trimFlowLayoutPanel.Size = new System.Drawing.Size(534, 43);
            this.trimFlowLayoutPanel.TabIndex = 0;
            // 
            // electricalTrimCheckBox
            // 
            this.electricalTrimCheckBox.AccessibleName = "Electrical stab trim switch";
            this.electricalTrimCheckBox.AutoSize = true;
            this.electricalTrimCheckBox.Location = new System.Drawing.Point(3, 3);
            this.electricalTrimCheckBox.Name = "electricalTrimCheckBox";
            this.electricalTrimCheckBox.Size = new System.Drawing.Size(194, 37);
            this.electricalTrimCheckBox.TabIndex = 0;
            this.electricalTrimCheckBox.Text = "Elec stab trim";
            this.electricalTrimCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoPilotTrimCheckBox
            // 
            this.autoPilotTrimCheckBox.AccessibleName = "Auto pilot stab trim switch";
            this.autoPilotTrimCheckBox.AutoSize = true;
            this.autoPilotTrimCheckBox.Location = new System.Drawing.Point(203, 3);
            this.autoPilotTrimCheckBox.Name = "autoPilotTrimCheckBox";
            this.autoPilotTrimCheckBox.Size = new System.Drawing.Size(179, 37);
            this.autoPilotTrimCheckBox.TabIndex = 1;
            this.autoPilotTrimCheckBox.Text = "AP stab trim";
            this.autoPilotTrimCheckBox.UseVisualStyleBackColor = true;
            // 
            // trimCheckBox
            // 
            this.trimCheckBox.AccessibleName = "Stab trim switch";
            this.trimCheckBox.AutoSize = true;
            this.trimCheckBox.Location = new System.Drawing.Point(388, 3);
            this.trimCheckBox.Name = "trimCheckBox";
            this.trimCheckBox.Size = new System.Drawing.Size(143, 37);
            this.trimCheckBox.TabIndex = 2;
            this.trimCheckBox.Text = "Stab trim";
            this.trimCheckBox.UseVisualStyleBackColor = true;
            // 
            // ctlControlStandTrim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.trimFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlControlStandTrim";
            this.Size = new System.Drawing.Size(540, 49);
            this.Load += new System.EventHandler(this.ctlControlStandTrim_Load);
            this.trimFlowLayoutPanel.ResumeLayout(false);
            this.trimFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel trimFlowLayoutPanel;
        private System.Windows.Forms.CheckBox electricalTrimCheckBox;
        private System.Windows.Forms.CheckBox autoPilotTrimCheckBox;
        private System.Windows.Forms.CheckBox trimCheckBox;
    }
}
