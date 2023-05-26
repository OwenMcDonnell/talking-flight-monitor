namespace tfm.PMDG.PMDG_737.CockpitPanels.AftOverhead
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
            this.domeLightsComboBox = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.domeLightsComboBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(127, 47);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // domeLightsComboBox
            // 
            this.domeLightsComboBox.AccessibleName = "Dome lights";
            this.domeLightsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.domeLightsComboBox.FormattingEnabled = true;
            this.domeLightsComboBox.Items.AddRange(new object[] {
            "dim",
            "off",
            "bright"});
            this.domeLightsComboBox.Location = new System.Drawing.Point(3, 3);
            this.domeLightsComboBox.Name = "domeLightsComboBox";
            this.domeLightsComboBox.Size = new System.Drawing.Size(121, 41);
            this.domeLightsComboBox.TabIndex = 0;
            this.domeLightsComboBox.SelectedIndexChanged += new System.EventHandler(this.domeLightsComboBox_SelectedIndexChanged);
            // 
            // ctlDomeLights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ctlDomeLights";
            this.Size = new System.Drawing.Size(130, 50);
            this.Load += new System.EventHandler(this.ctlDomeLights_Load);
            this.VisibleChanged += new System.EventHandler(this.ctlDomeLights_VisibleChanged);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox domeLightsComboBox;
    }
}
