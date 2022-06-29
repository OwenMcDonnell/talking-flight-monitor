namespace tfm.PMDG.PMDG_737.CockpitPanels.ForwardOverhead
{
    partial class ctlAPU
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
            this.apuFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.egtLabel = new System.Windows.Forms.Label();
            this.egtTextBox = new System.Windows.Forms.TextBox();
            this.maintLabel = new System.Windows.Forms.Label();
            this.maintTextBox = new System.Windows.Forms.TextBox();
            this.oilPressureLabel = new System.Windows.Forms.Label();
            this.lowOilPressureTextBox = new System.Windows.Forms.TextBox();
            this.faultLabel = new System.Windows.Forms.Label();
            this.faultTextBox = new System.Windows.Forms.TextBox();
            this.overSpeedLabel = new System.Windows.Forms.Label();
            this.overSpeedTextBox = new System.Windows.Forms.TextBox();
            this.apuFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // apuFlowLayoutPanel
            // 
            this.apuFlowLayoutPanel.AutoSize = true;
            this.apuFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.apuFlowLayoutPanel.Controls.Add(this.egtLabel);
            this.apuFlowLayoutPanel.Controls.Add(this.egtTextBox);
            this.apuFlowLayoutPanel.Controls.Add(this.maintLabel);
            this.apuFlowLayoutPanel.Controls.Add(this.maintTextBox);
            this.apuFlowLayoutPanel.Controls.Add(this.oilPressureLabel);
            this.apuFlowLayoutPanel.Controls.Add(this.lowOilPressureTextBox);
            this.apuFlowLayoutPanel.Controls.Add(this.faultLabel);
            this.apuFlowLayoutPanel.Controls.Add(this.faultTextBox);
            this.apuFlowLayoutPanel.Controls.Add(this.overSpeedLabel);
            this.apuFlowLayoutPanel.Controls.Add(this.overSpeedTextBox);
            this.apuFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.apuFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.apuFlowLayoutPanel.Name = "apuFlowLayoutPanel";
            this.apuFlowLayoutPanel.Size = new System.Drawing.Size(1173, 46);
            this.apuFlowLayoutPanel.TabIndex = 0;
            // 
            // egtLabel
            // 
            this.egtLabel.AutoSize = true;
            this.egtLabel.Location = new System.Drawing.Point(3, 0);
            this.egtLabel.Name = "egtLabel";
            this.egtLabel.Size = new System.Drawing.Size(67, 33);
            this.egtLabel.TabIndex = 0;
            this.egtLabel.Text = "EG&T";
            // 
            // egtTextBox
            // 
            this.egtTextBox.AccessibleName = "EGT needle";
            this.egtTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.egtTextBox.Location = new System.Drawing.Point(76, 3);
            this.egtTextBox.Name = "egtTextBox";
            this.egtTextBox.ReadOnly = true;
            this.egtTextBox.Size = new System.Drawing.Size(100, 40);
            this.egtTextBox.TabIndex = 1;
            this.egtTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maintLabel
            // 
            this.maintLabel.AutoSize = true;
            this.maintLabel.Location = new System.Drawing.Point(199, 0);
            this.maintLabel.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.maintLabel.Name = "maintLabel";
            this.maintLabel.Size = new System.Drawing.Size(82, 33);
            this.maintLabel.TabIndex = 2;
            this.maintLabel.Text = "&Maint";
            // 
            // maintTextBox
            // 
            this.maintTextBox.AccessibleDescription = "Maint";
            this.maintTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.maintTextBox.Location = new System.Drawing.Point(287, 3);
            this.maintTextBox.Name = "maintTextBox";
            this.maintTextBox.ReadOnly = true;
            this.maintTextBox.Size = new System.Drawing.Size(100, 40);
            this.maintTextBox.TabIndex = 3;
            this.maintTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // oilPressureLabel
            // 
            this.oilPressureLabel.AutoSize = true;
            this.oilPressureLabel.Location = new System.Drawing.Point(410, 0);
            this.oilPressureLabel.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.oilPressureLabel.Name = "oilPressureLabel";
            this.oilPressureLabel.Size = new System.Drawing.Size(192, 33);
            this.oilPressureLabel.TabIndex = 4;
            this.oilPressureLabel.Text = "low &oil pressure";
            // 
            // lowOilPressureTextBox
            // 
            this.lowOilPressureTextBox.AccessibleName = "Low oil pressure";
            this.lowOilPressureTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.lowOilPressureTextBox.Location = new System.Drawing.Point(608, 3);
            this.lowOilPressureTextBox.Name = "lowOilPressureTextBox";
            this.lowOilPressureTextBox.ReadOnly = true;
            this.lowOilPressureTextBox.Size = new System.Drawing.Size(100, 40);
            this.lowOilPressureTextBox.TabIndex = 5;
            this.lowOilPressureTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // faultLabel
            // 
            this.faultLabel.AutoSize = true;
            this.faultLabel.Location = new System.Drawing.Point(731, 0);
            this.faultLabel.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.faultLabel.Name = "faultLabel";
            this.faultLabel.Size = new System.Drawing.Size(73, 33);
            this.faultLabel.TabIndex = 6;
            this.faultLabel.Text = "&Fault";
            // 
            // faultTextBox
            // 
            this.faultTextBox.AccessibleName = "Fault";
            this.faultTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.faultTextBox.Location = new System.Drawing.Point(810, 3);
            this.faultTextBox.Name = "faultTextBox";
            this.faultTextBox.ReadOnly = true;
            this.faultTextBox.Size = new System.Drawing.Size(100, 40);
            this.faultTextBox.TabIndex = 7;
            this.faultTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // overSpeedLabel
            // 
            this.overSpeedLabel.AutoSize = true;
            this.overSpeedLabel.Location = new System.Drawing.Point(933, 0);
            this.overSpeedLabel.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.overSpeedLabel.Name = "overSpeedLabel";
            this.overSpeedLabel.Size = new System.Drawing.Size(131, 33);
            this.overSpeedLabel.TabIndex = 8;
            this.overSpeedLabel.Text = "Over&speed";
            // 
            // overSpeedTextBox
            // 
            this.overSpeedTextBox.AccessibleName = "Overspeed";
            this.overSpeedTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.overSpeedTextBox.Location = new System.Drawing.Point(1070, 3);
            this.overSpeedTextBox.Name = "overSpeedTextBox";
            this.overSpeedTextBox.ReadOnly = true;
            this.overSpeedTextBox.Size = new System.Drawing.Size(100, 40);
            this.overSpeedTextBox.TabIndex = 9;
            this.overSpeedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ctlAPU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.apuFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlAPU";
            this.Size = new System.Drawing.Size(1176, 49);
            this.Load += new System.EventHandler(this.ctlAPU_Load);
            this.apuFlowLayoutPanel.ResumeLayout(false);
            this.apuFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel apuFlowLayoutPanel;
        private System.Windows.Forms.Label egtLabel;
        private System.Windows.Forms.TextBox egtTextBox;
        private System.Windows.Forms.Label maintLabel;
        private System.Windows.Forms.TextBox maintTextBox;
        private System.Windows.Forms.Label oilPressureLabel;
        private System.Windows.Forms.TextBox lowOilPressureTextBox;
        private System.Windows.Forms.Label faultLabel;
        private System.Windows.Forms.TextBox faultTextBox;
        private System.Windows.Forms.Label overSpeedLabel;
        private System.Windows.Forms.TextBox overSpeedTextBox;
    }
}
