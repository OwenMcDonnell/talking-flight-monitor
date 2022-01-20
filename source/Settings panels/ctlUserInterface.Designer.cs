namespace tfm
{
    partial class ctlUserInterface
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
            this.ctlFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.chkPlayStartupSound = new System.Windows.Forms.CheckBox();
            this.chkPlayShutdownSound = new System.Windows.Forms.CheckBox();
            this.ctlFlowLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctlFlowLayout
            // 
            this.ctlFlowLayout.AutoSize = true;
            this.ctlFlowLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlFlowLayout.Controls.Add(this.chkPlayStartupSound);
            this.ctlFlowLayout.Controls.Add(this.chkPlayShutdownSound);
            this.ctlFlowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlFlowLayout.Location = new System.Drawing.Point(0, 0);
            this.ctlFlowLayout.Name = "ctlFlowLayout";
            this.ctlFlowLayout.Size = new System.Drawing.Size(548, 45);
            this.ctlFlowLayout.TabIndex = 0;
            // 
            // chkPlayStartupSound
            // 
            this.chkPlayStartupSound.AutoSize = true;
            this.chkPlayStartupSound.Location = new System.Drawing.Point(3, 3);
            this.chkPlayStartupSound.Name = "chkPlayStartupSound";
            this.chkPlayStartupSound.Size = new System.Drawing.Size(257, 37);
            this.chkPlayStartupSound.TabIndex = 2;
            this.chkPlayStartupSound.Text = "Play Startup Sound";
            this.chkPlayStartupSound.UseVisualStyleBackColor = true;
            this.chkPlayStartupSound.CheckedChanged += new System.EventHandler(this.chkPlayStartupSound_CheckedChanged);
            // 
            // chkPlayShutdownSound
            // 
            this.chkPlayShutdownSound.AutoSize = true;
            this.chkPlayShutdownSound.Location = new System.Drawing.Point(266, 3);
            this.chkPlayShutdownSound.Name = "chkPlayShutdownSound";
            this.chkPlayShutdownSound.Size = new System.Drawing.Size(279, 39);
            this.chkPlayShutdownSound.TabIndex = 3;
            this.chkPlayShutdownSound.Text = "Play shutdown sound";
            this.chkPlayShutdownSound.UseCompatibleTextRendering = true;
            this.chkPlayShutdownSound.UseVisualStyleBackColor = true;
            this.chkPlayShutdownSound.CheckedChanged += new System.EventHandler(this.chkPlayShutdownSound_CheckedChanged);
            // 
            // ctlUserInterface
            // 
            this.AccessibleName = "User interface settings";
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.ctlFlowLayout);
            this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ctlUserInterface";
            this.Size = new System.Drawing.Size(548, 45);
            this.Load += new System.EventHandler(this.ctlUserInterface_Load);
            this.ctlFlowLayout.ResumeLayout(false);
            this.ctlFlowLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel ctlFlowLayout;
        private System.Windows.Forms.CheckBox chkPlayStartupSound;
        private System.Windows.Forms.CheckBox chkPlayShutdownSound;
    }
}
