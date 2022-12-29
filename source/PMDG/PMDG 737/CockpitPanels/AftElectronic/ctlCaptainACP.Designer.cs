namespace tfm.PMDG.PMDG_737.CockpitPanels.AftElectronic
{
    partial class ctlCaptainACP
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
            this.acpFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.micLabel = new System.Windows.Forms.Label();
            this.micComboBox = new System.Windows.Forms.ComboBox();
            this.acpFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // acpFlowLayoutPanel
            // 
            this.acpFlowLayoutPanel.AutoSize = true;
            this.acpFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.acpFlowLayoutPanel.Controls.Add(this.micLabel);
            this.acpFlowLayoutPanel.Controls.Add(this.micComboBox);
            this.acpFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.acpFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.acpFlowLayoutPanel.Name = "acpFlowLayoutPanel";
            this.acpFlowLayoutPanel.Size = new System.Drawing.Size(274, 47);
            this.acpFlowLayoutPanel.TabIndex = 0;
            // 
            // micLabel
            // 
            this.micLabel.AutoSize = true;
            this.micLabel.Location = new System.Drawing.Point(10, 0);
            this.micLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.micLabel.Name = "micLabel";
            this.micLabel.Size = new System.Drawing.Size(134, 33);
            this.micLabel.TabIndex = 0;
            this.micLabel.Text = "Capt. MIC";
            // 
            // micComboBox
            // 
            this.micComboBox.AccessibleName = "Captain\'s microphone";
            this.micComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.micComboBox.FormattingEnabled = true;
            this.micComboBox.Items.AddRange(new object[] {
            "vhf1",
            "vhf2",
            "vhf3",
            "hf1",
            "hf2",
            "flt",
            "svc",
            "pa"});
            this.micComboBox.Location = new System.Drawing.Point(150, 3);
            this.micComboBox.Name = "micComboBox";
            this.micComboBox.Size = new System.Drawing.Size(121, 41);
            this.micComboBox.TabIndex = 1;
            this.micComboBox.SelectedIndexChanged += new System.EventHandler(this.micComboBox_SelectedIndexChanged);
            this.micComboBox.Enter += new System.EventHandler(this.micComboBox_Enter);
            // 
            // ctlCaptainACP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.acpFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlCaptainACP";
            this.Size = new System.Drawing.Size(277, 50);
            this.Load += new System.EventHandler(this.ctlCaptainACP_Load);
            this.acpFlowLayoutPanel.ResumeLayout(false);
            this.acpFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel acpFlowLayoutPanel;
        private System.Windows.Forms.Label micLabel;
        private System.Windows.Forms.ComboBox micComboBox;
    }
}
