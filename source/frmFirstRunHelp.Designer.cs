namespace tfm
{
    partial class frmFirstRunHelp
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtHelpMessage = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkDoNotShow = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.txtHelpMessage);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(606, 412);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // txtHelpMessage
            // 
            this.txtHelpMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHelpMessage.Location = new System.Drawing.Point(3, 3);
            this.txtHelpMessage.Multiline = true;
            this.txtHelpMessage.Name = "txtHelpMessage";
            this.txtHelpMessage.ReadOnly = true;
            this.txtHelpMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHelpMessage.Size = new System.Drawing.Size(600, 300);
            this.txtHelpMessage.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.chkDoNotShow);
            this.flowLayoutPanel2.Controls.Add(this.btnOk);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 309);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // chkDoNotShow
            // 
            this.chkDoNotShow.AutoSize = true;
            this.chkDoNotShow.Location = new System.Drawing.Point(3, 3);
            this.chkDoNotShow.Name = "chkDoNotShow";
            this.chkDoNotShow.Size = new System.Drawing.Size(378, 37);
            this.chkDoNotShow.TabIndex = 0;
            this.chkDoNotShow.Text = "Don\'t show this message again";
            this.chkDoNotShow.UseVisualStyleBackColor = true;
            this.chkDoNotShow.CheckedChanged += new System.EventHandler(this.chkDoNotShow_CheckedChanged);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(3, 46);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // frmFirstRunHelp
            // 
            this.AcceptButton = this.btnOk;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.Name = "frmFirstRunHelp";
            this.ShowInTaskbar = false;
            this.Text = "TFM First Run";
            this.Load += new System.EventHandler(this.frmFirstRunHelp_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtHelpMessage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox chkDoNotShow;
        private System.Windows.Forms.Button btnOk;
    }
}