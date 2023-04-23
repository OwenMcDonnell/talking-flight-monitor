namespace tfm.Settings_panels
{
    partial class ctlSimBrief
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
            this.simBriefFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.simBriefCheckBox = new System.Windows.Forms.CheckBox();
            this.userIDLabel = new System.Windows.Forms.Label();
            this.userIDTextBox = new System.Windows.Forms.TextBox();
            this.validateUserIdButton = new System.Windows.Forms.Button();
            this.simBriefFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // simBriefFlowLayoutPanel
            // 
            this.simBriefFlowLayoutPanel.AutoSize = true;
            this.simBriefFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.simBriefFlowLayoutPanel.Controls.Add(this.simBriefCheckBox);
            this.simBriefFlowLayoutPanel.Controls.Add(this.userIDLabel);
            this.simBriefFlowLayoutPanel.Controls.Add(this.userIDTextBox);
            this.simBriefFlowLayoutPanel.Controls.Add(this.validateUserIdButton);
            this.simBriefFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.simBriefFlowLayoutPanel.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.simBriefFlowLayoutPanel.Name = "simBriefFlowLayoutPanel";
            this.simBriefFlowLayoutPanel.Size = new System.Drawing.Size(677, 49);
            this.simBriefFlowLayoutPanel.TabIndex = 0;
            // 
            // simBriefCheckBox
            // 
            this.simBriefCheckBox.AccessibleName = "Enable SimBrief support";
            this.simBriefCheckBox.AutoSize = true;
            this.simBriefCheckBox.Checked = global::tfm.Properties.Settings.Default.IsSimBriefEnabled;
            this.simBriefCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.simBriefCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::tfm.Properties.Settings.Default, "IsSimBriefEnabled", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.simBriefCheckBox.Location = new System.Drawing.Point(3, 3);
            this.simBriefCheckBox.Name = "simBriefCheckBox";
            this.simBriefCheckBox.Size = new System.Drawing.Size(233, 37);
            this.simBriefCheckBox.TabIndex = 0;
            this.simBriefCheckBox.Text = "SimBrief support";
            this.simBriefCheckBox.UseVisualStyleBackColor = true;
            this.simBriefCheckBox.CheckedChanged += new System.EventHandler(this.simBriefCheckBox_CheckedChanged);
            // 
            // userIDLabel
            // 
            this.userIDLabel.AutoSize = true;
            this.userIDLabel.Location = new System.Drawing.Point(249, 0);
            this.userIDLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.userIDLabel.Name = "userIDLabel";
            this.userIDLabel.Size = new System.Drawing.Size(197, 33);
            this.userIDLabel.TabIndex = 1;
            this.userIDLabel.Text = "SimBrief userID";
            // 
            // userIDTextBox
            // 
            this.userIDTextBox.AccessibleName = "SimBrief user ID";
            this.userIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::tfm.Properties.Settings.Default, "SimBriefUserID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.userIDTextBox.Location = new System.Drawing.Point(452, 3);
            this.userIDTextBox.Name = "userIDTextBox";
            this.userIDTextBox.Size = new System.Drawing.Size(100, 40);
            this.userIDTextBox.TabIndex = 2;
            this.userIDTextBox.Text = global::tfm.Properties.Settings.Default.SimBriefUserID;
            // 
            // validateUserIdButton
            // 
            this.validateUserIdButton.AccessibleName = "Validate SimBrief user ID";
            this.validateUserIdButton.AutoSize = true;
            this.validateUserIdButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.validateUserIdButton.Location = new System.Drawing.Point(558, 3);
            this.validateUserIdButton.Name = "validateUserIdButton";
            this.validateUserIdButton.Size = new System.Drawing.Size(116, 43);
            this.validateUserIdButton.TabIndex = 3;
            this.validateUserIdButton.Text = "Validate";
            this.validateUserIdButton.UseVisualStyleBackColor = true;
            this.validateUserIdButton.Click += new System.EventHandler(this.validateUserIdButton_Click);
            // 
            // ctlSimBrief
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.simBriefFlowLayoutPanel);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "ctlSimBrief";
            this.Size = new System.Drawing.Size(680, 52);
            this.simBriefFlowLayoutPanel.ResumeLayout(false);
            this.simBriefFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel simBriefFlowLayoutPanel;
        private System.Windows.Forms.CheckBox simBriefCheckBox;
        private System.Windows.Forms.Label userIDLabel;
        private System.Windows.Forms.TextBox userIDTextBox;
        private System.Windows.Forms.Button validateUserIdButton;
    }
}
