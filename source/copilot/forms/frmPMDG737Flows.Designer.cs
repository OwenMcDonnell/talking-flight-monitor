namespace tfm.copilot
{
    partial class frmPMDG737Flows
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.VerticalFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.HorizontalFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.GrpElectricalPower = new System.Windows.Forms.GroupBox();
            this.ElectricalFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAPU = new System.Windows.Forms.Button();
            this.tmrFlowStatus = new System.Windows.Forms.Timer(this.components);
            this.VerticalFlowPanel.SuspendLayout();
            this.HorizontalFlowPanel.SuspendLayout();
            this.GrpElectricalPower.SuspendLayout();
            this.ElectricalFlowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // VerticalFlowPanel
            // 
            this.VerticalFlowPanel.AutoSize = true;
            this.VerticalFlowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.VerticalFlowPanel.Controls.Add(this.txtStatus);
            this.VerticalFlowPanel.Controls.Add(this.HorizontalFlowPanel);
            this.VerticalFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.VerticalFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.VerticalFlowPanel.Name = "VerticalFlowPanel";
            this.VerticalFlowPanel.Size = new System.Drawing.Size(806, 412);
            this.VerticalFlowPanel.TabIndex = 0;
            // 
            // txtStatus
            // 
            this.txtStatus.AccessibleName = "Flow Status";
            this.txtStatus.Location = new System.Drawing.Point(3, 3);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(800, 300);
            this.txtStatus.TabIndex = 0;
            // 
            // HorizontalFlowPanel
            // 
            this.HorizontalFlowPanel.Controls.Add(this.GrpElectricalPower);
            this.HorizontalFlowPanel.Location = new System.Drawing.Point(3, 309);
            this.HorizontalFlowPanel.Name = "HorizontalFlowPanel";
            this.HorizontalFlowPanel.Size = new System.Drawing.Size(200, 100);
            this.HorizontalFlowPanel.TabIndex = 1;
            // 
            // GrpElectricalPower
            // 
            this.GrpElectricalPower.AutoSize = true;
            this.GrpElectricalPower.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GrpElectricalPower.Controls.Add(this.ElectricalFlowPanel);
            this.GrpElectricalPower.Location = new System.Drawing.Point(3, 3);
            this.GrpElectricalPower.Name = "GrpElectricalPower";
            this.GrpElectricalPower.Size = new System.Drawing.Size(209, 165);
            this.GrpElectricalPower.TabIndex = 0;
            this.GrpElectricalPower.TabStop = false;
            this.GrpElectricalPower.Text = "Electrical Poer";
            // 
            // ElectricalFlowPanel
            // 
            this.ElectricalFlowPanel.Controls.Add(this.btnAPU);
            this.ElectricalFlowPanel.Location = new System.Drawing.Point(3, 31);
            this.ElectricalFlowPanel.Name = "ElectricalFlowPanel";
            this.ElectricalFlowPanel.Size = new System.Drawing.Size(200, 100);
            this.ElectricalFlowPanel.TabIndex = 0;
            // 
            // btnAPU
            // 
            this.btnAPU.AutoSize = true;
            this.btnAPU.Location = new System.Drawing.Point(3, 3);
            this.btnAPU.Name = "btnAPU";
            this.btnAPU.Size = new System.Drawing.Size(301, 39);
            this.btnAPU.TabIndex = 0;
            this.btnAPU.Text = "Electrical Power with APU";
            this.btnAPU.UseVisualStyleBackColor = true;
            this.btnAPU.Click += new System.EventHandler(this.btnAPU_Click);
            // 
            // tmrFlowStatus
            // 
            this.tmrFlowStatus.Interval = 500;
            this.tmrFlowStatus.Tick += new System.EventHandler(this.tmrFlowStatus_Tick);
            // 
            // frmPMDG737Flows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1244, 652);
            this.Controls.Add(this.VerticalFlowPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "frmPMDG737Flows";
            this.ShowInTaskbar = false;
            this.Text = "PMDG737 Flows";
            this.VerticalFlowPanel.ResumeLayout(false);
            this.VerticalFlowPanel.PerformLayout();
            this.HorizontalFlowPanel.ResumeLayout(false);
            this.HorizontalFlowPanel.PerformLayout();
            this.GrpElectricalPower.ResumeLayout(false);
            this.ElectricalFlowPanel.ResumeLayout(false);
            this.ElectricalFlowPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel VerticalFlowPanel;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.FlowLayoutPanel HorizontalFlowPanel;
        private System.Windows.Forms.GroupBox GrpElectricalPower;
        private System.Windows.Forms.FlowLayoutPanel ElectricalFlowPanel;
        private System.Windows.Forms.Button btnAPU;
        private System.Windows.Forms.Timer tmrFlowStatus;
    }
}