namespace tfm
{
    partial class ctlIRU_777
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
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnIRU = new System.Windows.Forms.Button();
            this.tmrIRU = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnIRU);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnIRU
            // 
            this.btnIRU.AutoSize = true;
            this.btnIRU.Location = new System.Drawing.Point(3, 3);
            this.btnIRU.Name = "btnIRU";
            this.btnIRU.Size = new System.Drawing.Size(75, 30);
            this.btnIRU.TabIndex = 0;
            this.btnIRU.Text = "IRU";
            this.btnIRU.UseVisualStyleBackColor = true;
            this.btnIRU.Click += new System.EventHandler(this.btnIRU_Click);
            // 
            // tmrIRU
            // 
            this.tmrIRU.Interval = 1000;
            this.tmrIRU.Tick += new System.EventHandler(this.tmrIRU_Tick);
            // 
            // ctlIRU_777
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ctlIRU_777";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnIRU;
        private System.Windows.Forms.Timer tmrIRU;
    }
}
