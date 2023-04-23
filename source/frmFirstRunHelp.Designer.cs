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
            flowLayoutPanel1 = new FlowLayoutPanel();
            txtHelpMessage = new TextBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            chkDoNotShow = new CheckBox();
            btnOk = new Button();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(txtHelpMessage);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel2);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(7);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(606, 412);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // txtHelpMessage
            // 
            txtHelpMessage.Cursor = Cursors.IBeam;
            txtHelpMessage.Location = new Point(3, 3);
            txtHelpMessage.Multiline = true;
            txtHelpMessage.Name = "txtHelpMessage";
            txtHelpMessage.ReadOnly = true;
            txtHelpMessage.ScrollBars = ScrollBars.Vertical;
            txtHelpMessage.Size = new Size(600, 300);
            txtHelpMessage.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(chkDoNotShow);
            flowLayoutPanel2.Controls.Add(btnOk);
            flowLayoutPanel2.Location = new Point(3, 309);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(200, 100);
            flowLayoutPanel2.TabIndex = 1;
            // 
            // chkDoNotShow
            // 
            chkDoNotShow.AutoSize = true;
            chkDoNotShow.Location = new Point(3, 3);
            chkDoNotShow.Name = "chkDoNotShow";
            chkDoNotShow.Size = new Size(378, 37);
            chkDoNotShow.TabIndex = 0;
            chkDoNotShow.Text = "Don't show this message again";
            chkDoNotShow.UseVisualStyleBackColor = true;
            chkDoNotShow.CheckedChanged += chkDoNotShow_CheckedChanged;
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(3, 46);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 1;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // frmFirstRunHelp
            // 
            AcceptButton = btnOk;
            AccessibleRole = AccessibleRole.Dialog;
            AutoScaleDimensions = new SizeF(15F, 33F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1924, 1050);
            ControlBox = false;
            Controls.Add(flowLayoutPanel1);
            Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(7);
            Name = "frmFirstRunHelp";
            ShowInTaskbar = false;
            Text = "TFM First Run";
            Load += frmFirstRunHelp_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtHelpMessage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox chkDoNotShow;
        private System.Windows.Forms.Button btnOk;
    }
}