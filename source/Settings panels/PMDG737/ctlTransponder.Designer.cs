namespace tfm.Settings_panels.PMDG737
{
    partial class ctlTransponder
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
            this.transponderFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.sourceCheckBox = new System.Windows.Forms.CheckBox();
            this.altSourceCheckBox = new System.Windows.Forms.CheckBox();
            this.modeCheckBox = new System.Windows.Forms.CheckBox();
            this.failureCheckBox = new System.Windows.Forms.CheckBox();
            this.transponderFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // transponderFlowLayoutPanel
            // 
            this.transponderFlowLayoutPanel.AutoSize = true;
            this.transponderFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.transponderFlowLayoutPanel.Controls.Add(this.sourceCheckBox);
            this.transponderFlowLayoutPanel.Controls.Add(this.altSourceCheckBox);
            this.transponderFlowLayoutPanel.Controls.Add(this.modeCheckBox);
            this.transponderFlowLayoutPanel.Controls.Add(this.failureCheckBox);
            this.transponderFlowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.transponderFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.transponderFlowLayoutPanel.Name = "transponderFlowLayoutPanel";
            this.transponderFlowLayoutPanel.Size = new System.Drawing.Size(488, 43);
            this.transponderFlowLayoutPanel.TabIndex = 0;
            // 
            // sourceCheckBox
            // 
            this.sourceCheckBox.AccessibleName = "Source switch";
            this.sourceCheckBox.AutoSize = true;
            this.sourceCheckBox.Location = new System.Drawing.Point(3, 3);
            this.sourceCheckBox.Name = "sourceCheckBox";
            this.sourceCheckBox.Size = new System.Drawing.Size(118, 37);
            this.sourceCheckBox.TabIndex = 0;
            this.sourceCheckBox.Text = "Source";
            this.sourceCheckBox.UseVisualStyleBackColor = true;
            // 
            // altSourceCheckBox
            // 
            this.altSourceCheckBox.AccessibleName = "Alternate source switch";
            this.altSourceCheckBox.AutoSize = true;
            this.altSourceCheckBox.Location = new System.Drawing.Point(127, 3);
            this.altSourceCheckBox.Name = "altSourceCheckBox";
            this.altSourceCheckBox.Size = new System.Drawing.Size(155, 37);
            this.altSourceCheckBox.TabIndex = 1;
            this.altSourceCheckBox.Text = "Alt source";
            this.altSourceCheckBox.UseVisualStyleBackColor = true;
            // 
            // modeCheckBox
            // 
            this.modeCheckBox.AccessibleName = "Mode switch";
            this.modeCheckBox.AutoSize = true;
            this.modeCheckBox.Location = new System.Drawing.Point(288, 3);
            this.modeCheckBox.Name = "modeCheckBox";
            this.modeCheckBox.Size = new System.Drawing.Size(106, 37);
            this.modeCheckBox.TabIndex = 2;
            this.modeCheckBox.Text = "Mode";
            this.modeCheckBox.UseVisualStyleBackColor = true;
            // 
            // failureCheckBox
            // 
            this.failureCheckBox.AccessibleName = "Failure indicator";
            this.failureCheckBox.AutoSize = true;
            this.failureCheckBox.Location = new System.Drawing.Point(400, 3);
            this.failureCheckBox.Name = "failureCheckBox";
            this.failureCheckBox.Size = new System.Drawing.Size(85, 37);
            this.failureCheckBox.TabIndex = 3;
            this.failureCheckBox.Text = "Fail";
            this.failureCheckBox.UseVisualStyleBackColor = true;
            // 
            // ctlTransponder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.transponderFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlTransponder";
            this.Size = new System.Drawing.Size(494, 49);
            this.Load += new System.EventHandler(this.ctlTransponder_Load);
            this.transponderFlowLayoutPanel.ResumeLayout(false);
            this.transponderFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel transponderFlowLayoutPanel;
        private System.Windows.Forms.CheckBox sourceCheckBox;
        private System.Windows.Forms.CheckBox altSourceCheckBox;
        private System.Windows.Forms.CheckBox modeCheckBox;
        private System.Windows.Forms.CheckBox failureCheckBox;
    }
}
