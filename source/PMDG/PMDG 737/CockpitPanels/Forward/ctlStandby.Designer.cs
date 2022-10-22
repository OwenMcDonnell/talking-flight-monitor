namespace tfm.PMDG.PMDG_737.CockpitPanels.Forward
{
    partial class ctlStandby
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
            this.standbyFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.rmi1Button = new System.Windows.Forms.Button();
            this.rmi2Button = new System.Windows.Forms.Button();
            this.standbyFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // standbyFlowLayoutPanel
            // 
            this.standbyFlowLayoutPanel.AutoSize = true;
            this.standbyFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.standbyFlowLayoutPanel.Controls.Add(this.rmi1Button);
            this.standbyFlowLayoutPanel.Controls.Add(this.rmi2Button);
            this.standbyFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.standbyFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.standbyFlowLayoutPanel.Name = "standbyFlowLayoutPanel";
            this.standbyFlowLayoutPanel.Size = new System.Drawing.Size(234, 49);
            this.standbyFlowLayoutPanel.TabIndex = 0;
            // 
            // rmi1Button
            // 
            this.rmi1Button.AutoSize = true;
            this.rmi1Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rmi1Button.Location = new System.Drawing.Point(3, 3);
            this.rmi1Button.Name = "rmi1Button";
            this.rmi1Button.Size = new System.Drawing.Size(111, 43);
            this.rmi1Button.TabIndex = 0;
            this.rmi1Button.Text = "button1";
            this.rmi1Button.UseVisualStyleBackColor = true;
            this.rmi1Button.Click += new System.EventHandler(this.rmi1Button_Click);
            // 
            // rmi2Button
            // 
            this.rmi2Button.AutoSize = true;
            this.rmi2Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rmi2Button.Location = new System.Drawing.Point(120, 3);
            this.rmi2Button.Name = "rmi2Button";
            this.rmi2Button.Size = new System.Drawing.Size(111, 43);
            this.rmi2Button.TabIndex = 1;
            this.rmi2Button.Text = "button2";
            this.rmi2Button.UseVisualStyleBackColor = true;
            this.rmi2Button.Click += new System.EventHandler(this.rmi2Button_Click);
            // 
            // ctlStandby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.standbyFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlStandby";
            this.Size = new System.Drawing.Size(237, 52);
            this.Load += new System.EventHandler(this.ctlStandby_Load);
            this.VisibleChanged += new System.EventHandler(this.ctlStandby_VisibleChanged);
            this.standbyFlowLayoutPanel.ResumeLayout(false);
            this.standbyFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel standbyFlowLayoutPanel;
        private System.Windows.Forms.Button rmi1Button;
        private System.Windows.Forms.Button rmi2Button;
    }
}
