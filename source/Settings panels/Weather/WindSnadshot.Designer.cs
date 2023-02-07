namespace tfm.Settings_panels.Weather
{
    partial class WindSnadshot
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
            this.windFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.upperAltitudeCheckBox = new System.Windows.Forms.CheckBox();
            this.directionCheckBox = new System.Windows.Forms.CheckBox();
            this.speedCheckBox = new System.Windows.Forms.CheckBox();
            this.gustsCheckBox = new System.Windows.Forms.CheckBox();
            this.visibilityCheckBox = new System.Windows.Forms.CheckBox();
            this.turbulenceCheckBox = new System.Windows.Forms.CheckBox();
            this.shearCheckBox = new System.Windows.Forms.CheckBox();
            this.windFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // windFlowLayoutPanel
            // 
            this.windFlowLayoutPanel.AutoSize = true;
            this.windFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.windFlowLayoutPanel.Controls.Add(this.upperAltitudeCheckBox);
            this.windFlowLayoutPanel.Controls.Add(this.directionCheckBox);
            this.windFlowLayoutPanel.Controls.Add(this.speedCheckBox);
            this.windFlowLayoutPanel.Controls.Add(this.gustsCheckBox);
            this.windFlowLayoutPanel.Controls.Add(this.visibilityCheckBox);
            this.windFlowLayoutPanel.Controls.Add(this.turbulenceCheckBox);
            this.windFlowLayoutPanel.Controls.Add(this.shearCheckBox);
            this.windFlowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.windFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.windFlowLayoutPanel.Name = "windFlowLayoutPanel";
            this.windFlowLayoutPanel.Size = new System.Drawing.Size(1015, 43);
            this.windFlowLayoutPanel.TabIndex = 0;
            // 
            // upperAltitudeCheckBox
            // 
            this.upperAltitudeCheckBox.AccessibleName = "Include upper altitude.";
            this.upperAltitudeCheckBox.AutoSize = true;
            this.upperAltitudeCheckBox.Location = new System.Drawing.Point(3, 3);
            this.upperAltitudeCheckBox.Name = "upperAltitudeCheckBox";
            this.upperAltitudeCheckBox.Size = new System.Drawing.Size(200, 37);
            this.upperAltitudeCheckBox.TabIndex = 0;
            this.upperAltitudeCheckBox.Text = "Upper altitude";
            this.upperAltitudeCheckBox.UseVisualStyleBackColor = true;
            this.upperAltitudeCheckBox.CheckedChanged += new System.EventHandler(this.upperAltitudeCheckBox_CheckedChanged);
            // 
            // directionCheckBox
            // 
            this.directionCheckBox.AccessibleName = "Include wind direction.";
            this.directionCheckBox.AutoSize = true;
            this.directionCheckBox.Location = new System.Drawing.Point(209, 3);
            this.directionCheckBox.Name = "directionCheckBox";
            this.directionCheckBox.Size = new System.Drawing.Size(146, 37);
            this.directionCheckBox.TabIndex = 1;
            this.directionCheckBox.Text = "Direction";
            this.directionCheckBox.UseVisualStyleBackColor = true;
            // 
            // speedCheckBox
            // 
            this.speedCheckBox.AccessibleName = "Include wind speed.";
            this.speedCheckBox.AutoSize = true;
            this.speedCheckBox.Location = new System.Drawing.Point(361, 3);
            this.speedCheckBox.Name = "speedCheckBox";
            this.speedCheckBox.Size = new System.Drawing.Size(109, 37);
            this.speedCheckBox.TabIndex = 2;
            this.speedCheckBox.Text = "Speed";
            this.speedCheckBox.UseVisualStyleBackColor = true;
            // 
            // gustsCheckBox
            // 
            this.gustsCheckBox.AccessibleName = "Include wind gusts.";
            this.gustsCheckBox.AutoSize = true;
            this.gustsCheckBox.Location = new System.Drawing.Point(476, 3);
            this.gustsCheckBox.Name = "gustsCheckBox";
            this.gustsCheckBox.Size = new System.Drawing.Size(104, 37);
            this.gustsCheckBox.TabIndex = 3;
            this.gustsCheckBox.Text = "Gusts";
            this.gustsCheckBox.UseVisualStyleBackColor = true;
            // 
            // visibilityCheckBox
            // 
            this.visibilityCheckBox.AccessibleName = "Include visibility.";
            this.visibilityCheckBox.AutoSize = true;
            this.visibilityCheckBox.Location = new System.Drawing.Point(586, 3);
            this.visibilityCheckBox.Name = "visibilityCheckBox";
            this.visibilityCheckBox.Size = new System.Drawing.Size(145, 37);
            this.visibilityCheckBox.TabIndex = 4;
            this.visibilityCheckBox.Text = "Visibility";
            this.visibilityCheckBox.UseVisualStyleBackColor = true;
            // 
            // turbulenceCheckBox
            // 
            this.turbulenceCheckBox.AccessibleName = "Include wind turbulence.";
            this.turbulenceCheckBox.AutoSize = true;
            this.turbulenceCheckBox.Location = new System.Drawing.Point(737, 3);
            this.turbulenceCheckBox.Name = "turbulenceCheckBox";
            this.turbulenceCheckBox.Size = new System.Drawing.Size(165, 37);
            this.turbulenceCheckBox.TabIndex = 5;
            this.turbulenceCheckBox.Text = "Turbulence";
            this.turbulenceCheckBox.UseVisualStyleBackColor = true;
            // 
            // shearCheckBox
            // 
            this.shearCheckBox.AccessibleName = "Include wind shear.";
            this.shearCheckBox.AutoSize = true;
            this.shearCheckBox.Location = new System.Drawing.Point(908, 3);
            this.shearCheckBox.Name = "shearCheckBox";
            this.shearCheckBox.Size = new System.Drawing.Size(104, 37);
            this.shearCheckBox.TabIndex = 6;
            this.shearCheckBox.Text = "Shear";
            this.shearCheckBox.UseVisualStyleBackColor = true;
            // 
            // WindSnadshot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.windFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "WindSnadshot";
            this.Size = new System.Drawing.Size(1021, 49);
            this.Load += new System.EventHandler(this.WindSnadshot_Load);
            this.windFlowLayoutPanel.ResumeLayout(false);
            this.windFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel windFlowLayoutPanel;
        private System.Windows.Forms.CheckBox upperAltitudeCheckBox;
        private System.Windows.Forms.CheckBox directionCheckBox;
        private System.Windows.Forms.CheckBox speedCheckBox;
        private System.Windows.Forms.CheckBox gustsCheckBox;
        private System.Windows.Forms.CheckBox visibilityCheckBox;
        private System.Windows.Forms.CheckBox turbulenceCheckBox;
        private System.Windows.Forms.CheckBox shearCheckBox;
    }
}
