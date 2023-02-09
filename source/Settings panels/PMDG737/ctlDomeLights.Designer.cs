namespace tfm.Settings_panels.PMDG737
{
    partial class ctlDomeLights
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
            this.domeLightsCheckBox = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.domeLightsCheckBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(182, 43);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // domeLightsCheckBox
            // 
            this.domeLightsCheckBox.AccessibleName = "Dome lights";
            this.domeLightsCheckBox.AutoSize = true;
            this.domeLightsCheckBox.Location = new System.Drawing.Point(3, 3);
            this.domeLightsCheckBox.Name = "domeLightsCheckBox";
            this.domeLightsCheckBox.Size = new System.Drawing.Size(176, 37);
            this.domeLightsCheckBox.TabIndex = 0;
            this.domeLightsCheckBox.Text = "&Dome lights";
            this.domeLightsCheckBox.UseVisualStyleBackColor = true;
            this.domeLightsCheckBox.CheckedChanged += new System.EventHandler(this.domeLightsCheckBox_CheckedChanged);
            // 
            // ctlDomeLights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ctlDomeLights";
            this.Size = new System.Drawing.Size(187, 48);
            this.Load += new System.EventHandler(this.ctlDomeLights_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox domeLightsCheckBox;
    }
}
