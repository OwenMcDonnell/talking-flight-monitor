namespace tfm.PMDG.PMDG_737.CockpitPanels.ForwardOverhead
{
    partial class ctlWipers
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
            this.wipersFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.leftWipersLabel = new System.Windows.Forms.Label();
            this.leftWipersComboBox = new System.Windows.Forms.ComboBox();
            this.rightWipersLabel = new System.Windows.Forms.Label();
            this.rightWipersComboBox = new System.Windows.Forms.ComboBox();
            this.wipersFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // wipersFlowLayoutPanel
            // 
            this.wipersFlowLayoutPanel.AutoSize = true;
            this.wipersFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.wipersFlowLayoutPanel.Controls.Add(this.leftWipersLabel);
            this.wipersFlowLayoutPanel.Controls.Add(this.leftWipersComboBox);
            this.wipersFlowLayoutPanel.Controls.Add(this.rightWipersLabel);
            this.wipersFlowLayoutPanel.Controls.Add(this.rightWipersComboBox);
            this.wipersFlowLayoutPanel.Location = new System.Drawing.Point(0, 1);
            this.wipersFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.wipersFlowLayoutPanel.Name = "wipersFlowLayoutPanel";
            this.wipersFlowLayoutPanel.Size = new System.Drawing.Size(610, 47);
            this.wipersFlowLayoutPanel.TabIndex = 0;
            // 
            // leftWipersLabel
            // 
            this.leftWipersLabel.AutoSize = true;
            this.leftWipersLabel.Location = new System.Drawing.Point(3, 0);
            this.leftWipersLabel.Name = "leftWipersLabel";
            this.leftWipersLabel.Size = new System.Drawing.Size(140, 33);
            this.leftWipersLabel.TabIndex = 0;
            this.leftWipersLabel.Text = "&Left wipers";
            // 
            // leftWipersComboBox
            // 
            this.leftWipersComboBox.AccessibleName = "Left wipers";
            this.leftWipersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.leftWipersComboBox.FormattingEnabled = true;
            this.leftWipersComboBox.Items.AddRange(new object[] {
            "off",
            "intermittent",
            "low",
            "high"});
            this.leftWipersComboBox.Location = new System.Drawing.Point(149, 3);
            this.leftWipersComboBox.Name = "leftWipersComboBox";
            this.leftWipersComboBox.Size = new System.Drawing.Size(121, 41);
            this.leftWipersComboBox.TabIndex = 1;
            this.leftWipersComboBox.SelectedIndexChanged += new System.EventHandler(this.leftWipersComboBox_SelectedIndexChanged);
            // 
            // rightWipersLabel
            // 
            this.rightWipersLabel.AutoSize = true;
            this.rightWipersLabel.Location = new System.Drawing.Point(323, 0);
            this.rightWipersLabel.Margin = new System.Windows.Forms.Padding(50, 0, 3, 0);
            this.rightWipersLabel.Name = "rightWipersLabel";
            this.rightWipersLabel.Size = new System.Drawing.Size(157, 33);
            this.rightWipersLabel.TabIndex = 2;
            this.rightWipersLabel.Text = "&Right wipers";
            // 
            // rightWipersComboBox
            // 
            this.rightWipersComboBox.AccessibleName = "Right wipers";
            this.rightWipersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rightWipersComboBox.FormattingEnabled = true;
            this.rightWipersComboBox.Items.AddRange(new object[] {
            "off",
            "imtermittent",
            "low",
            "high"});
            this.rightWipersComboBox.Location = new System.Drawing.Point(486, 3);
            this.rightWipersComboBox.Name = "rightWipersComboBox";
            this.rightWipersComboBox.Size = new System.Drawing.Size(121, 41);
            this.rightWipersComboBox.TabIndex = 3;
            this.rightWipersComboBox.SelectedIndexChanged += new System.EventHandler(this.rightWipersComboBox_SelectedIndexChanged);
            // 
            // ctlWipers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.wipersFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlWipers";
            this.Size = new System.Drawing.Size(613, 51);
            this.Load += new System.EventHandler(this.ctlWipers_Load);
            this.VisibleChanged += new System.EventHandler(this.ctlWipers_VisibleChanged);
            this.wipersFlowLayoutPanel.ResumeLayout(false);
            this.wipersFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel wipersFlowLayoutPanel;
        private System.Windows.Forms.Label leftWipersLabel;
        private System.Windows.Forms.ComboBox leftWipersComboBox;
        private System.Windows.Forms.Label rightWipersLabel;
        private System.Windows.Forms.ComboBox rightWipersComboBox;
    }
}
