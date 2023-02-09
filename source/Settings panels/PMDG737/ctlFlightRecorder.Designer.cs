namespace tfm.Settings_panels.PMDG737
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
            this.flightRecorderCheckBox = new System.Windows.Forms.CheckBox();
            this.flightRecorderLightCheckBox = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.flightRecorderCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.flightRecorderLightCheckBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(510, 43);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // flightRecorderCheckBox
            // 
            this.flightRecorderCheckBox.AccessibleName = "Flight recorder switch";
            this.flightRecorderCheckBox.AutoSize = true;
            this.flightRecorderCheckBox.Location = new System.Drawing.Point(3, 3);
            this.flightRecorderCheckBox.Name = "flightRecorderCheckBox";
            this.flightRecorderCheckBox.Size = new System.Drawing.Size(206, 37);
            this.flightRecorderCheckBox.TabIndex = 0;
            this.flightRecorderCheckBox.Text = "&Flight recorder";
            this.flightRecorderCheckBox.UseVisualStyleBackColor = true;
            this.flightRecorderCheckBox.CheckedChanged += new System.EventHandler(this.flightRecorderCheckBox_CheckedChanged);
            // 
            // flightRecorderLightCheckBox
            // 
            this.flightRecorderLightCheckBox.AccessibleName = "Flight recorder indicator";
            this.flightRecorderLightCheckBox.AutoSize = true;
            this.flightRecorderLightCheckBox.Location = new System.Drawing.Point(215, 3);
            this.flightRecorderLightCheckBox.Name = "flightRecorderLightCheckBox";
            this.flightRecorderLightCheckBox.Size = new System.Drawing.Size(292, 37);
            this.flightRecorderLightCheckBox.TabIndex = 1;
            this.flightRecorderLightCheckBox.Text = "&1. Flight recorder light";
            this.flightRecorderLightCheckBox.UseVisualStyleBackColor = true;
            this.flightRecorderLightCheckBox.CheckedChanged += new System.EventHandler(this.flightRecorderLightCheckBox_CheckedChanged);
            // 
            // ctlFlightRecorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ctlFlightRecorder";
            this.Size = new System.Drawing.Size(513, 46);
            this.Load += new System.EventHandler(this.ctlFlightRecorder_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox flightRecorderCheckBox;
        private System.Windows.Forms.CheckBox flightRecorderLightCheckBox;
    }
}
