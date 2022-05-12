namespace tfm
{
    partial class DestinationForm
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
            this.airportTextBox = new System.Windows.Forms.TextBox();
            this.runwayComboBox = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.ilsDetailsTextBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.airportTextBox);
            this.flowLayoutPanel1.Controls.Add(this.runwayComboBox);
            this.flowLayoutPanel1.Controls.Add(this.okButton);
            this.flowLayoutPanel1.Controls.Add(this.cancelButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(36, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(406, 49);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // airportTextBox
            // 
            this.airportTextBox.AccessibleName = "Airport";
            this.airportTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.airportTextBox.Location = new System.Drawing.Point(3, 3);
            this.airportTextBox.Name = "airportTextBox";
            this.airportTextBox.Size = new System.Drawing.Size(100, 40);
            this.airportTextBox.TabIndex = 0;
            this.airportTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.airportTextBox_KeyDown);
            // 
            // runwayComboBox
            // 
            this.runwayComboBox.AccessibleName = "Runway";
            this.runwayComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.runwayComboBox.FormattingEnabled = true;
            this.runwayComboBox.Location = new System.Drawing.Point(109, 3);
            this.runwayComboBox.Name = "runwayComboBox";
            this.runwayComboBox.Size = new System.Drawing.Size(121, 41);
            this.runwayComboBox.TabIndex = 1;
            this.runwayComboBox.SelectedIndexChanged += new System.EventHandler(this.runwayComboBox_SelectedIndexChanged);
            // 
            // okButton
            // 
            this.okButton.AccessibleName = "Ok";
            this.okButton.AutoSize = true;
            this.okButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.okButton.Location = new System.Drawing.Point(236, 3);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(59, 43);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "&Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.AccessibleName = "Cancel";
            this.cancelButton.AutoSize = true;
            this.cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cancelButton.Location = new System.Drawing.Point(301, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(102, 43);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // ilsDetailsTextBox
            // 
            this.ilsDetailsTextBox.AccessibleName = "ILS details";
            this.ilsDetailsTextBox.Location = new System.Drawing.Point(118, 53);
            this.ilsDetailsTextBox.Multiline = true;
            this.ilsDetailsTextBox.Name = "ilsDetailsTextBox";
            this.ilsDetailsTextBox.ReadOnly = true;
            this.ilsDetailsTextBox.Size = new System.Drawing.Size(243, 41);
            this.ilsDetailsTextBox.TabIndex = 1;
            // 
            // DestinationForm
            // 
            this.AccessibleName = "Choose destination runway";
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(478, 94);
            this.Controls.Add(this.ilsDetailsTextBox);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "DestinationForm";
            this.Text = "Destination runway";
            this.Load += new System.EventHandler(this.DestinationForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DestinationForm_KeyDown);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox airportTextBox;
        private System.Windows.Forms.ComboBox runwayComboBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox ilsDetailsTextBox;
    }
}