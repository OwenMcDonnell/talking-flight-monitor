namespace tfm.PMDG.PMDG_737.CockpitPanels.ForwardOverhead
{
    partial class ctlNav_displays
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
            this.label1 = new System.Windows.Forms.Label();
            this.vhfComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.irsComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fmcComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.sourceComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.controlPaneComboBox = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.vhfComboBox);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.irsComboBox);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.fmcComboBox);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.sourceComboBox);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.controlPaneComboBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1165, 47);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "&VHF nav";
            // 
            // vhfComboBox
            // 
            this.vhfComboBox.AccessibleName = "VHF selector";
            this.vhfComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vhfComboBox.FormattingEnabled = true;
            this.vhfComboBox.Items.AddRange(new object[] {
            "both on 1",
            "normal",
            "both on 2"});
            this.vhfComboBox.Location = new System.Drawing.Point(124, 3);
            this.vhfComboBox.Name = "vhfComboBox";
            this.vhfComboBox.Size = new System.Drawing.Size(121, 41);
            this.vhfComboBox.TabIndex = 1;
            this.vhfComboBox.SelectedIndexChanged += new System.EventHandler(this.vhfComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "&IRS";
            // 
            // irsComboBox
            // 
            this.irsComboBox.AccessibleName = "IRS selector";
            this.irsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.irsComboBox.FormattingEnabled = true;
            this.irsComboBox.Items.AddRange(new object[] {
            "left",
            "normal",
            "right"});
            this.irsComboBox.Location = new System.Drawing.Point(315, 3);
            this.irsComboBox.Name = "irsComboBox";
            this.irsComboBox.Size = new System.Drawing.Size(121, 41);
            this.irsComboBox.TabIndex = 3;
            this.irsComboBox.SelectedIndexChanged += new System.EventHandler(this.irsComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(442, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 33);
            this.label3.TabIndex = 4;
            this.label3.Text = "&FMC";
            // 
            // fmcComboBox
            // 
            this.fmcComboBox.AccessibleName = "FMC selector";
            this.fmcComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fmcComboBox.FormattingEnabled = true;
            this.fmcComboBox.Items.AddRange(new object[] {
            "left",
            "normal",
            "right"});
            this.fmcComboBox.Location = new System.Drawing.Point(523, 3);
            this.fmcComboBox.Name = "fmcComboBox";
            this.fmcComboBox.Size = new System.Drawing.Size(121, 41);
            this.fmcComboBox.TabIndex = 5;
            this.fmcComboBox.SelectedIndexChanged += new System.EventHandler(this.fmcComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(650, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 33);
            this.label4.TabIndex = 6;
            this.label4.Text = "&Source";
            // 
            // sourceComboBox
            // 
            this.sourceComboBox.AccessibleName = "Source selector";
            this.sourceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourceComboBox.FormattingEnabled = true;
            this.sourceComboBox.Items.AddRange(new object[] {
            "all on 1",
            "auto",
            "all on 2"});
            this.sourceComboBox.Location = new System.Drawing.Point(748, 3);
            this.sourceComboBox.Name = "sourceComboBox";
            this.sourceComboBox.Size = new System.Drawing.Size(121, 41);
            this.sourceComboBox.TabIndex = 7;
            this.sourceComboBox.SelectedIndexChanged += new System.EventHandler(this.sourceComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(875, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 33);
            this.label5.TabIndex = 8;
            this.label5.Text = "&Control pane";
            // 
            // controlPaneComboBox
            // 
            this.controlPaneComboBox.AccessibleName = "Control pane selector";
            this.controlPaneComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.controlPaneComboBox.FormattingEnabled = true;
            this.controlPaneComboBox.Items.AddRange(new object[] {
            "both on 1",
            "normal",
            "both on 2"});
            this.controlPaneComboBox.Location = new System.Drawing.Point(1041, 3);
            this.controlPaneComboBox.Name = "controlPaneComboBox";
            this.controlPaneComboBox.Size = new System.Drawing.Size(121, 41);
            this.controlPaneComboBox.TabIndex = 9;
            this.controlPaneComboBox.SelectedIndexChanged += new System.EventHandler(this.controlPaneComboBox_SelectedIndexChanged);
            // 
            // ctlNav_displays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlNav_displays";
            this.Size = new System.Drawing.Size(1168, 51);
            this.Load += new System.EventHandler(this.ctlNav_displays_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox vhfComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox irsComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox fmcComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox sourceComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox controlPaneComboBox;
    }
}
