namespace tfm.Settings_panels
{
    partial class ctlAircraftFlows
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
            this.FlowAircraftFlows = new System.Windows.Forms.FlowLayoutPanel();
            this.chkMuteDuringFlows = new System.Windows.Forms.CheckBox();
            this.chkAlignIRS = new System.Windows.Forms.CheckBox();
            this.FlowAircraftFlows.SuspendLayout();
            this.SuspendLayout();
            // 
            // FlowAircraftFlows
            // 
            this.FlowAircraftFlows.Controls.Add(this.chkMuteDuringFlows);
            this.FlowAircraftFlows.Controls.Add(this.chkAlignIRS);
            this.FlowAircraftFlows.Location = new System.Drawing.Point(0, 0);
            this.FlowAircraftFlows.Name = "FlowAircraftFlows";
            this.FlowAircraftFlows.Size = new System.Drawing.Size(200, 100);
            this.FlowAircraftFlows.TabIndex = 0;
            // 
            // chkMuteDuringFlows
            // 
            this.chkMuteDuringFlows.AutoSize = true;
            this.chkMuteDuringFlows.Location = new System.Drawing.Point(3, 3);
            this.chkMuteDuringFlows.Name = "chkMuteDuringFlows";
            this.chkMuteDuringFlows.Size = new System.Drawing.Size(294, 17);
            this.chkMuteDuringFlows.TabIndex = 0;
            this.chkMuteDuringFlows.Text = "Mute speech for aircraft controls while folows are running";
            this.chkMuteDuringFlows.UseVisualStyleBackColor = true;
            // 
            // chkAlignIRS
            // 
            this.chkAlignIRS.AutoSize = true;
            this.chkAlignIRS.Location = new System.Drawing.Point(3, 26);
            this.chkAlignIRS.Name = "chkAlignIRS";
            this.chkAlignIRS.Size = new System.Drawing.Size(121, 11);
            this.chkAlignIRS.TabIndex = 1;
            this.chkAlignIRS.Text = "Align IRS during preflight preflight";
            this.chkAlignIRS.UseVisualStyleBackColor = true;
            // 
            // ctlAircraftFlows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.FlowAircraftFlows);
            this.Name = "ctlAircraftFlows";
            this.Size = new System.Drawing.Size(203, 103);
            this.Load += new System.EventHandler(this.ctlAircraftFlows_Load);
            this.FlowAircraftFlows.ResumeLayout(false);
            this.FlowAircraftFlows.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FlowAircraftFlows;
        private System.Windows.Forms.CheckBox chkMuteDuringFlows;
        private System.Windows.Forms.CheckBox chkAlignIRS;
    }
}
