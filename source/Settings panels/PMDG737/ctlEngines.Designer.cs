namespace tfm.Settings_panels.PMDG737
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
            this.apuSelectorCheckBox = new System.Windows.Forms.CheckBox();
            this.engine1SelectorCheckBox = new System.Windows.Forms.CheckBox();
            this.engine2Selectorh = new System.Windows.Forms.CheckBox();
            this.ignitionSelectorCheckBox = new System.Windows.Forms.CheckBox();
            this.enginesFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // enginesFlowLayoutPanel
            // 
            this.enginesFlowLayoutPanel.AutoSize = true;
            this.enginesFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.enginesFlowLayoutPanel.Controls.Add(this.apuSelectorCheckBox);
            this.enginesFlowLayoutPanel.Controls.Add(this.engine1SelectorCheckBox);
            this.enginesFlowLayoutPanel.Controls.Add(this.engine2Selectorh);
            this.enginesFlowLayoutPanel.Controls.Add(this.ignitionSelectorCheckBox);
            this.enginesFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.enginesFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.enginesFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.enginesFlowLayoutPanel.Name = "enginesFlowLayoutPanel";
            this.enginesFlowLayoutPanel.Size = new System.Drawing.Size(1260, 43);
            this.enginesFlowLayoutPanel.TabIndex = 0;
            // 
            // apuSelectorCheckBox
            // 
            this.apuSelectorCheckBox.AccessibleName = "APU start selector switch";
            this.apuSelectorCheckBox.AutoSize = true;
            this.apuSelectorCheckBox.Location = new System.Drawing.Point(3, 3);
            this.apuSelectorCheckBox.Name = "apuSelectorCheckBox";
            this.apuSelectorCheckBox.Size = new System.Drawing.Size(267, 37);
            this.apuSelectorCheckBox.TabIndex = 0;
            this.apuSelectorCheckBox.Text = "&APU selector switch";
            this.apuSelectorCheckBox.UseVisualStyleBackColor = true;
            // 
            // engine1SelectorCheckBox
            // 
            this.engine1SelectorCheckBox.AccessibleName = "Engine #1 start selector switch";
            this.engine1SelectorCheckBox.AutoSize = true;
            this.engine1SelectorCheckBox.Location = new System.Drawing.Point(276, 3);
            this.engine1SelectorCheckBox.Name = "engine1SelectorCheckBox";
            this.engine1SelectorCheckBox.Size = new System.Drawing.Size(381, 37);
            this.engine1SelectorCheckBox.TabIndex = 1;
            this.engine1SelectorCheckBox.Text = "Engine #&1 start selector switch";
            this.engine1SelectorCheckBox.UseVisualStyleBackColor = true;
            // 
            // engine2Selectorh
            // 
            this.engine2Selectorh.AccessibleName = "Engine #2 start selector switch";
            this.engine2Selectorh.AutoSize = true;
            this.engine2Selectorh.Location = new System.Drawing.Point(663, 3);
            this.engine2Selectorh.Name = "engine2Selectorh";
            this.engine2Selectorh.Size = new System.Drawing.Size(381, 37);
            this.engine2Selectorh.TabIndex = 2;
            this.engine2Selectorh.Text = "Engine #&2 start selector switch";
            this.engine2Selectorh.UseVisualStyleBackColor = true;
            // 
            // ignitionSelectorCheckBox
            // 
            this.ignitionSelectorCheckBox.AccessibleName = "Ignition starter switch";
            this.ignitionSelectorCheckBox.AutoSize = true;
            this.ignitionSelectorCheckBox.Location = new System.Drawing.Point(1050, 3);
            this.ignitionSelectorCheckBox.Name = "ignitionSelectorCheckBox";
            this.ignitionSelectorCheckBox.Size = new System.Drawing.Size(207, 37);
            this.ignitionSelectorCheckBox.TabIndex = 3;
            this.ignitionSelectorCheckBox.Text = "&Ignition switch";
            this.ignitionSelectorCheckBox.UseVisualStyleBackColor = true;
            // 
            // ctlEngines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.enginesFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlEngines";
            this.Size = new System.Drawing.Size(1265, 48);
            this.Load += new System.EventHandler(this.ctlEngines_Load);
            this.enginesFlowLayoutPanel.ResumeLayout(false);
            this.enginesFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel enginesFlowLayoutPanel;
        private System.Windows.Forms.CheckBox apuSelectorCheckBox;
        private System.Windows.Forms.CheckBox engine1SelectorCheckBox;
        private System.Windows.Forms.CheckBox engine2Selectorh;
        private System.Windows.Forms.CheckBox ignitionSelectorCheckBox;
    }
}
