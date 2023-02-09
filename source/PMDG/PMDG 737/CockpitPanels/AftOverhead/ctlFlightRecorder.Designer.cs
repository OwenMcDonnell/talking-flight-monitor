namespace tfm.PMDG.PMDG_737.CockpitPanels.AftOverhead
{
    partial class ctlFlightRecorder
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flightRecorderButton = new System.Windows.Forms.Button();
            this.flightRecorderLightFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.flightRecorderTextBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.flightRecorderLightFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.flightRecorderButton);
            this.flowLayoutPanel1.Controls.Add(this.flightRecorderLightFlowLayoutPanel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(301, 85);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // flightRecorderButton
            // 
            this.flightRecorderButton.Location = new System.Drawing.Point(3, 3);
            this.flightRecorderButton.Name = "flightRecorderButton";
            this.flightRecorderButton.Size = new System.Drawing.Size(75, 23);
            this.flightRecorderButton.TabIndex = 0;
            this.flightRecorderButton.Text = "button1";
            this.flightRecorderButton.UseVisualStyleBackColor = true;
            this.flightRecorderButton.Click += new System.EventHandler(this.flightRecorderButton_Click);
            // 
            // flightRecorderLightFlowLayoutPanel
            // 
            this.flightRecorderLightFlowLayoutPanel.AutoSize = true;
            this.flightRecorderLightFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flightRecorderLightFlowLayoutPanel.Controls.Add(this.label1);
            this.flightRecorderLightFlowLayoutPanel.Controls.Add(this.flightRecorderTextBox);
            this.flightRecorderLightFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flightRecorderLightFlowLayoutPanel.Location = new System.Drawing.Point(84, 3);
            this.flightRecorderLightFlowLayoutPanel.Name = "flightRecorderLightFlowLayoutPanel";
            this.flightRecorderLightFlowLayoutPanel.Size = new System.Drawing.Size(214, 79);
            this.flightRecorderLightFlowLayoutPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "&1. Flight recorder";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flightRecorderTextBox
            // 
            this.flightRecorderTextBox.AccessibleName = "Flight recorder";
            this.flightRecorderTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator;
            this.flightRecorderTextBox.Location = new System.Drawing.Point(3, 36);
            this.flightRecorderTextBox.Name = "flightRecorderTextBox";
            this.flightRecorderTextBox.ReadOnly = true;
            this.flightRecorderTextBox.Size = new System.Drawing.Size(208, 40);
            this.flightRecorderTextBox.TabIndex = 1;
            this.flightRecorderTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ctlFlightRecorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ctlFlightRecorder";
            this.Size = new System.Drawing.Size(304, 88);
            this.Load += new System.EventHandler(this.ctlFlightRecorder_Load);
            this.VisibleChanged += new System.EventHandler(this.ctlFlightRecorder_VisibleChanged);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flightRecorderLightFlowLayoutPanel.ResumeLayout(false);
            this.flightRecorderLightFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button flightRecorderButton;
        private System.Windows.Forms.FlowLayoutPanel flightRecorderLightFlowLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox flightRecorderTextBox;
    }
}
