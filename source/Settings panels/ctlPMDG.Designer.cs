
namespace tfm
{
    partial class ctlPMDG
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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radCDUKeysDefault = new System.Windows.Forms.RadioButton();
            this.radCDUKeysAlternate = new System.Windows.Forms.RadioButton();
            this.announcePerfInitCompleteCheckbox = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.groupBox1);
            this.flowLayoutPanel2.Controls.Add(this.announcePerfInitCompleteCheckbox);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(418, 106);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleName = "CDU soft keys";
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CDU Soft Key mode";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.radCDUKeysDefault);
            this.flowLayoutPanel1.Controls.Add(this.radCDUKeysAlternate);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // radCDUKeysDefault
            // 
            this.radCDUKeysDefault.AutoSize = true;
            this.radCDUKeysDefault.Location = new System.Drawing.Point(3, 3);
            this.radCDUKeysDefault.Name = "radCDUKeysDefault";
            this.radCDUKeysDefault.Size = new System.Drawing.Size(394, 24);
            this.radCDUKeysDefault.TabIndex = 0;
            this.radCDUKeysDefault.TabStop = true;
            this.radCDUKeysDefault.Text = "Default (Ctrl+1-6 for left keys, Alt+1-6 for right keys)";
            this.radCDUKeysDefault.UseVisualStyleBackColor = true;
            // 
            // radCDUKeysAlternate
            // 
            this.radCDUKeysAlternate.AutoSize = true;
            this.radCDUKeysAlternate.Location = new System.Drawing.Point(3, 33);
            this.radCDUKeysAlternate.Name = "radCDUKeysAlternate";
            this.radCDUKeysAlternate.Size = new System.Drawing.Size(395, 24);
            this.radCDUKeysAlternate.TabIndex = 1;
            this.radCDUKeysAlternate.TabStop = true;
            this.radCDUKeysAlternate.Text = "Alternate (F1-F6 for left keys, F7-F12 for right keys)";
            this.radCDUKeysAlternate.UseVisualStyleBackColor = true;
            // 
            // announcePerfInitCompleteCheckbox
            // 
            this.announcePerfInitCompleteCheckbox.AccessibleName = "Speak message when FMC perf init is complete";
            this.announcePerfInitCompleteCheckbox.AutoSize = true;
            this.announcePerfInitCompleteCheckbox.Location = new System.Drawing.Point(209, 3);
            this.announcePerfInitCompleteCheckbox.Name = "announcePerfInitCompleteCheckbox";
            this.announcePerfInitCompleteCheckbox.Size = new System.Drawing.Size(206, 24);
            this.announcePerfInitCompleteCheckbox.TabIndex = 2;
            this.announcePerfInitCompleteCheckbox.Text = "Speak perf init complete";
            this.announcePerfInitCompleteCheckbox.UseVisualStyleBackColor = true;
            this.announcePerfInitCompleteCheckbox.CheckedChanged += new System.EventHandler(this.announcePerfInitCompleteCheckbox_CheckedChanged);
            // 
            // ctlPMDG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel2);
            this.Name = "ctlPMDG";
            this.Size = new System.Drawing.Size(421, 109);
            this.Load += new System.EventHandler(this.ctlPMDG_Load);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radCDUKeysDefault;
        private System.Windows.Forms.RadioButton radCDUKeysAlternate;
        private System.Windows.Forms.CheckBox announcePerfInitCompleteCheckbox;
    }
}