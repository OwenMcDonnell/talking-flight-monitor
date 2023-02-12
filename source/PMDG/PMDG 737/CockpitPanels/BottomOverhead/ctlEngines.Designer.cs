namespace tfm.PMDG.PMDG_737.CockpitPanels.BottomOverhead
{
    partial class ctlEngines
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
            this.enginesFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.apuLabel = new System.Windows.Forms.Label();
            this.apuSelectorComboBox = new System.Windows.Forms.ComboBox();
            this.engine1GroupBox = new System.Windows.Forms.GroupBox();
            this.engine1FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.engine1Label = new System.Windows.Forms.Label();
            this.engine1SelectorComboBox = new System.Windows.Forms.ComboBox();
            this.engFuel1Label = new System.Windows.Forms.Label();
            this.engFuel1ComboBox = new System.Windows.Forms.ComboBox();
            this.engine2GroupBox = new System.Windows.Forms.GroupBox();
            this.engine2FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.engine2Label = new System.Windows.Forms.Label();
            this.engine2SelectorComboBox = new System.Windows.Forms.ComboBox();
            this.engFuel2Label = new System.Windows.Forms.Label();
            this.engFuel2ComboBox = new System.Windows.Forms.ComboBox();
            this.ignitionLabel = new System.Windows.Forms.Label();
            this.ignitionSelectorComboBox = new System.Windows.Forms.ComboBox();
            this.enginesFlowLayoutPanel.SuspendLayout();
            this.engine1GroupBox.SuspendLayout();
            this.engine1FlowLayoutPanel.SuspendLayout();
            this.engine2GroupBox.SuspendLayout();
            this.engine2FlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // enginesFlowLayoutPanel
            // 
            this.enginesFlowLayoutPanel.AutoSize = true;
            this.enginesFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.enginesFlowLayoutPanel.Controls.Add(this.apuLabel);
            this.enginesFlowLayoutPanel.Controls.Add(this.apuSelectorComboBox);
            this.enginesFlowLayoutPanel.Controls.Add(this.engine1GroupBox);
            this.enginesFlowLayoutPanel.Controls.Add(this.engine2GroupBox);
            this.enginesFlowLayoutPanel.Controls.Add(this.ignitionLabel);
            this.enginesFlowLayoutPanel.Controls.Add(this.ignitionSelectorComboBox);
            this.enginesFlowLayoutPanel.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enginesFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.enginesFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(5);
            this.enginesFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.enginesFlowLayoutPanel.Name = "enginesFlowLayoutPanel";
            this.enginesFlowLayoutPanel.Size = new System.Drawing.Size(1373, 97);
            this.enginesFlowLayoutPanel.TabIndex = 0;
            // 
            // apuLabel
            // 
            this.apuLabel.AutoSize = true;
            this.apuLabel.Location = new System.Drawing.Point(10, 0);
            this.apuLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.apuLabel.Name = "apuLabel";
            this.apuLabel.Size = new System.Drawing.Size(47, 21);
            this.apuLabel.TabIndex = 0;
            this.apuLabel.Text = "&APU";
            // 
            // apuSelectorComboBox
            // 
            this.apuSelectorComboBox.AccessibleName = "APU start selector";
            this.apuSelectorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.apuSelectorComboBox.FormattingEnabled = true;
            this.apuSelectorComboBox.Items.AddRange(new object[] {
            "off",
            "on",
            "start"});
            this.apuSelectorComboBox.Location = new System.Drawing.Point(65, 3);
            this.apuSelectorComboBox.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.apuSelectorComboBox.Name = "apuSelectorComboBox";
            this.apuSelectorComboBox.Size = new System.Drawing.Size(121, 29);
            this.apuSelectorComboBox.TabIndex = 1;
            this.apuSelectorComboBox.SelectedIndexChanged += new System.EventHandler(this.apuSelectorComboBox_SelectedIndexChanged);
            // 
            // engine1GroupBox
            // 
            this.engine1GroupBox.AccessibleName = "Engine #1";
            this.engine1GroupBox.AutoSize = true;
            this.engine1GroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.engine1GroupBox.Controls.Add(this.engine1FlowLayoutPanel);
            this.engine1GroupBox.Location = new System.Drawing.Point(192, 3);
            this.engine1GroupBox.Name = "engine1GroupBox";
            this.engine1GroupBox.Size = new System.Drawing.Size(482, 91);
            this.engine1GroupBox.TabIndex = 2;
            this.engine1GroupBox.TabStop = false;
            this.engine1GroupBox.Text = "Engine #&1";
            // 
            // engine1FlowLayoutPanel
            // 
            this.engine1FlowLayoutPanel.AutoSize = true;
            this.engine1FlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.engine1FlowLayoutPanel.Controls.Add(this.engine1Label);
            this.engine1FlowLayoutPanel.Controls.Add(this.engine1SelectorComboBox);
            this.engine1FlowLayoutPanel.Controls.Add(this.engFuel1Label);
            this.engine1FlowLayoutPanel.Controls.Add(this.engFuel1ComboBox);
            this.engine1FlowLayoutPanel.Location = new System.Drawing.Point(3, 36);
            this.engine1FlowLayoutPanel.Name = "engine1FlowLayoutPanel";
            this.engine1FlowLayoutPanel.Size = new System.Drawing.Size(473, 27);
            this.engine1FlowLayoutPanel.TabIndex = 0;
            // 
            // engine1Label
            // 
            this.engine1Label.AutoSize = true;
            this.engine1Label.Location = new System.Drawing.Point(20, 0);
            this.engine1Label.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.engine1Label.Name = "engine1Label";
            this.engine1Label.Size = new System.Drawing.Size(84, 21);
            this.engine1Label.TabIndex = 3;
            this.engine1Label.Text = "Engine #&1";
            // 
            // engine1SelectorComboBox
            // 
            this.engine1SelectorComboBox.AccessibleName = "Engine #1 start selector";
            this.engine1SelectorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.engine1SelectorComboBox.FormattingEnabled = true;
            this.engine1SelectorComboBox.Items.AddRange(new object[] {
            "grd",
            "auto",
            "cont",
            "flt"});
            this.engine1SelectorComboBox.Location = new System.Drawing.Point(112, 3);
            this.engine1SelectorComboBox.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.engine1SelectorComboBox.Name = "engine1SelectorComboBox";
            this.engine1SelectorComboBox.Size = new System.Drawing.Size(121, 29);
            this.engine1SelectorComboBox.TabIndex = 4;
            this.engine1SelectorComboBox.SelectedIndexChanged += new System.EventHandler(this.engine1SelectorComboBox_SelectedIndexChanged);
            // 
            // engFuel1Label
            // 
            this.engFuel1Label.AutoSize = true;
            this.engFuel1Label.Location = new System.Drawing.Point(246, 0);
            this.engFuel1Label.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.engFuel1Label.Name = "engFuel1Label";
            this.engFuel1Label.Size = new System.Drawing.Size(95, 21);
            this.engFuel1Label.TabIndex = 5;
            this.engFuel1Label.Text = "Eng fuel #1";
            // 
            // engFuel1ComboBox
            // 
            this.engFuel1ComboBox.AccessibleName = "Engine #1 fuel switch";
            this.engFuel1ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.engFuel1ComboBox.FormattingEnabled = true;
            this.engFuel1ComboBox.Items.AddRange(new object[] {
            "idle",
            "cutoff"});
            this.engFuel1ComboBox.Location = new System.Drawing.Point(349, 3);
            this.engFuel1ComboBox.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.engFuel1ComboBox.Name = "engFuel1ComboBox";
            this.engFuel1ComboBox.Size = new System.Drawing.Size(121, 29);
            this.engFuel1ComboBox.TabIndex = 6;
            this.engFuel1ComboBox.SelectedIndexChanged += new System.EventHandler(this.engFuel1ComboBox_SelectedIndexChanged);
            // 
            // engine2GroupBox
            // 
            this.engine2GroupBox.AccessibleName = "Engine #2";
            this.engine2GroupBox.AutoSize = true;
            this.engine2GroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.engine2GroupBox.Controls.Add(this.engine2FlowLayoutPanel);
            this.engine2GroupBox.Location = new System.Drawing.Point(680, 3);
            this.engine2GroupBox.Name = "engine2GroupBox";
            this.engine2GroupBox.Size = new System.Drawing.Size(472, 91);
            this.engine2GroupBox.TabIndex = 7;
            this.engine2GroupBox.TabStop = false;
            this.engine2GroupBox.Text = "Engine #&2";
            // 
            // engine2FlowLayoutPanel
            // 
            this.engine2FlowLayoutPanel.AutoSize = true;
            this.engine2FlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.engine2FlowLayoutPanel.Controls.Add(this.engine2Label);
            this.engine2FlowLayoutPanel.Controls.Add(this.engine2SelectorComboBox);
            this.engine2FlowLayoutPanel.Controls.Add(this.engFuel2Label);
            this.engine2FlowLayoutPanel.Controls.Add(this.engFuel2ComboBox);
            this.engine2FlowLayoutPanel.Location = new System.Drawing.Point(3, 36);
            this.engine2FlowLayoutPanel.Name = "engine2FlowLayoutPanel";
            this.engine2FlowLayoutPanel.Size = new System.Drawing.Size(463, 27);
            this.engine2FlowLayoutPanel.TabIndex = 0;
            // 
            // engine2Label
            // 
            this.engine2Label.AutoSize = true;
            this.engine2Label.Location = new System.Drawing.Point(10, 0);
            this.engine2Label.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.engine2Label.Name = "engine2Label";
            this.engine2Label.Size = new System.Drawing.Size(84, 21);
            this.engine2Label.TabIndex = 8;
            this.engine2Label.Text = "Engine #&2";
            // 
            // engine2SelectorComboBox
            // 
            this.engine2SelectorComboBox.AccessibleName = "Engine #2 start selector";
            this.engine2SelectorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.engine2SelectorComboBox.FormattingEnabled = true;
            this.engine2SelectorComboBox.Items.AddRange(new object[] {
            "grd",
            "auto",
            "cont",
            "flt"});
            this.engine2SelectorComboBox.Location = new System.Drawing.Point(102, 3);
            this.engine2SelectorComboBox.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.engine2SelectorComboBox.Name = "engine2SelectorComboBox";
            this.engine2SelectorComboBox.Size = new System.Drawing.Size(121, 29);
            this.engine2SelectorComboBox.TabIndex = 9;
            this.engine2SelectorComboBox.SelectedIndexChanged += new System.EventHandler(this.engine2SelectorComboBox_SelectedIndexChanged);
            // 
            // engFuel2Label
            // 
            this.engFuel2Label.AutoSize = true;
            this.engFuel2Label.Location = new System.Drawing.Point(236, 0);
            this.engFuel2Label.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.engFuel2Label.Name = "engFuel2Label";
            this.engFuel2Label.Size = new System.Drawing.Size(95, 21);
            this.engFuel2Label.TabIndex = 10;
            this.engFuel2Label.Text = "Eng fuel #2";
            // 
            // engFuel2ComboBox
            // 
            this.engFuel2ComboBox.AccessibleName = "Engine #2 fuel switch";
            this.engFuel2ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.engFuel2ComboBox.FormattingEnabled = true;
            this.engFuel2ComboBox.Items.AddRange(new object[] {
            "idle",
            "cutoff"});
            this.engFuel2ComboBox.Location = new System.Drawing.Point(339, 3);
            this.engFuel2ComboBox.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.engFuel2ComboBox.Name = "engFuel2ComboBox";
            this.engFuel2ComboBox.Size = new System.Drawing.Size(121, 29);
            this.engFuel2ComboBox.TabIndex = 11;
            this.engFuel2ComboBox.SelectedIndexChanged += new System.EventHandler(this.engFuel2ComboBox_SelectedIndexChanged);
            // 
            // ignitionLabel
            // 
            this.ignitionLabel.AutoSize = true;
            this.ignitionLabel.Location = new System.Drawing.Point(1175, 0);
            this.ignitionLabel.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.ignitionLabel.Name = "ignitionLabel";
            this.ignitionLabel.Size = new System.Drawing.Size(66, 21);
            this.ignitionLabel.TabIndex = 12;
            this.ignitionLabel.Text = "&Ignition";
            // 
            // ignitionSelectorComboBox
            // 
            this.ignitionSelectorComboBox.AccessibleName = "Ignition selector";
            this.ignitionSelectorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ignitionSelectorComboBox.FormattingEnabled = true;
            this.ignitionSelectorComboBox.Items.AddRange(new object[] {
            "ign L",
            "both",
            "ign R"});
            this.ignitionSelectorComboBox.Location = new System.Drawing.Point(1249, 3);
            this.ignitionSelectorComboBox.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.ignitionSelectorComboBox.Name = "ignitionSelectorComboBox";
            this.ignitionSelectorComboBox.Size = new System.Drawing.Size(121, 29);
            this.ignitionSelectorComboBox.TabIndex = 13;
            this.ignitionSelectorComboBox.SelectedIndexChanged += new System.EventHandler(this.ignitionSelectorComboBox_SelectedIndexChanged);
            // 
            // ctlEngines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.enginesFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(3200, 1782);
            this.Name = "ctlEngines";
            this.Size = new System.Drawing.Size(1378, 102);
            this.Load += new System.EventHandler(this.ctlEngines_Load);
            this.VisibleChanged += new System.EventHandler(this.ctlEngines_VisibleChanged);
            this.enginesFlowLayoutPanel.ResumeLayout(false);
            this.enginesFlowLayoutPanel.PerformLayout();
            this.engine1GroupBox.ResumeLayout(false);
            this.engine1GroupBox.PerformLayout();
            this.engine1FlowLayoutPanel.ResumeLayout(false);
            this.engine1FlowLayoutPanel.PerformLayout();
            this.engine2GroupBox.ResumeLayout(false);
            this.engine2GroupBox.PerformLayout();
            this.engine2FlowLayoutPanel.ResumeLayout(false);
            this.engine2FlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel enginesFlowLayoutPanel;
        private System.Windows.Forms.Label apuLabel;
        private System.Windows.Forms.ComboBox apuSelectorComboBox;
        private System.Windows.Forms.Label ignitionLabel;
        private System.Windows.Forms.ComboBox ignitionSelectorComboBox;
        private System.Windows.Forms.GroupBox engine1GroupBox;
        private System.Windows.Forms.FlowLayoutPanel engine1FlowLayoutPanel;
        private System.Windows.Forms.Label engine1Label;
        private System.Windows.Forms.ComboBox engine1SelectorComboBox;
        private System.Windows.Forms.Label engFuel1Label;
        private System.Windows.Forms.GroupBox engine2GroupBox;
        private System.Windows.Forms.FlowLayoutPanel engine2FlowLayoutPanel;
        private System.Windows.Forms.Label engine2Label;
        private System.Windows.Forms.ComboBox engine2SelectorComboBox;
        private System.Windows.Forms.ComboBox engFuel1ComboBox;
        private System.Windows.Forms.Label engFuel2Label;
        private System.Windows.Forms.ComboBox engFuel2ComboBox;
    }
}
