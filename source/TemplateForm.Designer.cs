﻿namespace tfm
{
    partial class TemplateForm
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.txtAirspeed = new System.Windows.Forms.TextBox();
            this.chkAvionicsMaster = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timerConnection = new System.Windows.Forms.Timer(this.components);
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblConnectionStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 295);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(430, 22);
            this.statusStrip.TabIndex = 6;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(104, 17);
            this.lblConnectionStatus.Text = "Connection Status";
            // 
            // timerMain
            // 
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // txtAirspeed
            // 
            this.txtAirspeed.Location = new System.Drawing.Point(160, 12);
            this.txtAirspeed.Name = "txtAirspeed";
            this.txtAirspeed.ReadOnly = true;
            this.txtAirspeed.Size = new System.Drawing.Size(100, 20);
            this.txtAirspeed.TabIndex = 9;
            // 
            // chkAvionicsMaster
            // 
            this.chkAvionicsMaster.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAvionicsMaster.Location = new System.Drawing.Point(11, 40);
            this.chkAvionicsMaster.Name = "chkAvionicsMaster";
            this.chkAvionicsMaster.Size = new System.Drawing.Size(164, 24);
            this.chkAvionicsMaster.TabIndex = 8;
            this.chkAvionicsMaster.Text = "Avionics Master";
            this.chkAvionicsMaster.UseVisualStyleBackColor = true;
            this.chkAvionicsMaster.CheckedChanged += new System.EventHandler(this.chkAvionicsMaster_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Indicated Airpeed (Knots)";
            // 
            // timerConnection
            // 
            this.timerConnection.Interval = 1000;
            this.timerConnection.Tick += new System.EventHandler(this.timerConnection_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 317);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.txtAirspeed);
            this.Controls.Add(this.chkAvionicsMaster);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.Text = "Main Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblConnectionStatus;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.TextBox txtAirspeed;
        private System.Windows.Forms.CheckBox chkAvionicsMaster;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerConnection;
    }
}

