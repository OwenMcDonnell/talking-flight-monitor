namespace tfm
{
    partial class ctlAircraft
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
            this.aircraftFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.takeoffAssistDropDown = new System.Windows.Forms.ComboBox();
            this.readLocaliserHeadingsCheckBox = new System.Windows.Forms.CheckBox();
            this.readGSAltitudeCheckBox = new System.Windows.Forms.CheckBox();
            this.aircraftFlowLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // aircraftFlowLayout
            // 
            this.aircraftFlowLayout.AccessibleName = "Aircraft layout";
            this.aircraftFlowLayout.AutoSize = true;
            this.aircraftFlowLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.aircraftFlowLayout.Controls.Add(this.takeoffAssistDropDown);
            this.aircraftFlowLayout.Controls.Add(this.readLocaliserHeadingsCheckBox);
            this.aircraftFlowLayout.Controls.Add(this.readGSAltitudeCheckBox);
            this.aircraftFlowLayout.Location = new System.Drawing.Point(0, 0);
            this.aircraftFlowLayout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.aircraftFlowLayout.Name = "aircraftFlowLayout";
            this.aircraftFlowLayout.Size = new System.Drawing.Size(563, 36);
            this.aircraftFlowLayout.TabIndex = 0;
            // 
            // takeoffAssistDropDown
            // 
            this.takeoffAssistDropDown.AccessibleName = "Takeoff assist mode";
            this.takeoffAssistDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.takeoffAssistDropDown.FormattingEnabled = true;
            this.takeoffAssistDropDown.Items.AddRange(new object[] {
            "off",
            "partial",
            "full"});
            this.takeoffAssistDropDown.Location = new System.Drawing.Point(3, 4);
            this.takeoffAssistDropDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.takeoffAssistDropDown.Name = "takeoffAssistDropDown";
            this.takeoffAssistDropDown.Size = new System.Drawing.Size(136, 28);
            this.takeoffAssistDropDown.TabIndex = 0;
            this.takeoffAssistDropDown.SelectedIndexChanged += new System.EventHandler(this.takeoffAssistDropDown_SelectedIndexChanged);
            // 
            // readLocaliserHeadingsCheckBox
            // 
            this.readLocaliserHeadingsCheckBox.AccessibleName = "Read localizer headings";
            this.readLocaliserHeadingsCheckBox.AutoSize = true;
            this.readLocaliserHeadingsCheckBox.Location = new System.Drawing.Point(145, 3);
            this.readLocaliserHeadingsCheckBox.Name = "readLocaliserHeadingsCheckBox";
            this.readLocaliserHeadingsCheckBox.Size = new System.Drawing.Size(204, 24);
            this.readLocaliserHeadingsCheckBox.TabIndex = 1;
            this.readLocaliserHeadingsCheckBox.Text = "Read &localiser headings";
            this.readLocaliserHeadingsCheckBox.UseVisualStyleBackColor = true;
            this.readLocaliserHeadingsCheckBox.CheckedChanged += new System.EventHandler(this.readLocaliserHeadingsCheckBox_CheckedChanged);
            // 
            // readGSAltitudeCheckBox
            // 
            this.readGSAltitudeCheckBox.AccessibleName = "Read glide slope altitude";
            this.readGSAltitudeCheckBox.AutoSize = true;
            this.readGSAltitudeCheckBox.Location = new System.Drawing.Point(355, 3);
            this.readGSAltitudeCheckBox.Name = "readGSAltitudeCheckBox";
            this.readGSAltitudeCheckBox.Size = new System.Drawing.Size(205, 24);
            this.readGSAltitudeCheckBox.TabIndex = 2;
            this.readGSAltitudeCheckBox.Text = "Read &glideslope altitude";
            this.readGSAltitudeCheckBox.UseVisualStyleBackColor = true;
            this.readGSAltitudeCheckBox.CheckedChanged += new System.EventHandler(this.readGSAltitudeCheckBox_CheckedChanged);
            // 
            // ctlAircraft
            // 
            this.AccessibleName = "Aircraft settings";
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.aircraftFlowLayout);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ctlAircraft";
            this.Size = new System.Drawing.Size(566, 40);
            this.Load += new System.EventHandler(this.ctlAircraft_Load);
            this.aircraftFlowLayout.ResumeLayout(false);
            this.aircraftFlowLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel aircraftFlowLayout;
        private System.Windows.Forms.ComboBox takeoffAssistDropDown;
        private System.Windows.Forms.CheckBox readLocaliserHeadingsCheckBox;
        private System.Windows.Forms.CheckBox readGSAltitudeCheckBox;
    }
}
