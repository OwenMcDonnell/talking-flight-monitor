namespace tfm.JumpTo
{
    partial class RunwaysForm
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
            this.airportTextBox = new System.Windows.Forms.TextBox();
            this.runwaysListView = new System.Windows.Forms.ListView();
            this.idColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.inUseColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headingTrueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lengthFeetColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.widthFeetColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.takeoffAllowedColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.landingAllowedColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // airportTextBox
            // 
            this.airportTextBox.AccessibleName = "Airport code";
            this.airportTextBox.Location = new System.Drawing.Point(414, 0);
            this.airportTextBox.Name = "airportTextBox";
            this.airportTextBox.Size = new System.Drawing.Size(504, 40);
            this.airportTextBox.TabIndex = 0;
            this.airportTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.airportTextBox_KeyDown);
            // 
            // runwaysListView
            // 
            this.runwaysListView.AccessibleName = "Runways";
            this.runwaysListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idColumnHeader,
            this.inUseColumnHeader,
            this.headingTrueColumnHeader,
            this.lengthFeetColumnHeader,
            this.widthFeetColumnHeader,
            this.takeoffAllowedColumnHeader,
            this.landingAllowedColumnHeader});
            this.runwaysListView.HideSelection = false;
            this.runwaysListView.Location = new System.Drawing.Point(6, 46);
            this.runwaysListView.Name = "runwaysListView";
            this.runwaysListView.Size = new System.Drawing.Size(1321, 692);
            this.runwaysListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.runwaysListView.TabIndex = 1;
            this.runwaysListView.UseCompatibleStateImageBehavior = false;
            this.runwaysListView.View = System.Windows.Forms.View.Details;
            this.runwaysListView.ItemActivate += new System.EventHandler(this.runwaysListView_ItemActivate);
            // 
            // idColumnHeader
            // 
            this.idColumnHeader.Text = "ID";
            this.idColumnHeader.Width = 150;
            // 
            // inUseColumnHeader
            // 
            this.inUseColumnHeader.Text = "In use";
            this.inUseColumnHeader.Width = 150;
            // 
            // headingTrueColumnHeader
            // 
            this.headingTrueColumnHeader.Text = "Heading true";
            this.headingTrueColumnHeader.Width = 150;
            // 
            // lengthFeetColumnHeader
            // 
            this.lengthFeetColumnHeader.Text = "Length";
            this.lengthFeetColumnHeader.Width = 150;
            // 
            // widthFeetColumnHeader
            // 
            this.widthFeetColumnHeader.Text = "Width";
            this.widthFeetColumnHeader.Width = 150;
            // 
            // takeoffAllowedColumnHeader
            // 
            this.takeoffAllowedColumnHeader.Text = "Takeoff allowed";
            this.takeoffAllowedColumnHeader.Width = 150;
            // 
            // landingAllowedColumnHeader
            // 
            this.landingAllowedColumnHeader.Text = "Landing allowed";
            this.landingAllowedColumnHeader.Width = 150;
            // 
            // RunwaysForm
            // 
            this.AccessibleName = "Jump to runway";
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1333, 743);
            this.Controls.Add(this.runwaysListView);
            this.Controls.Add(this.airportTextBox);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "RunwaysForm";
            this.Text = "Jump to runway";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RunwaysForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox airportTextBox;
        private System.Windows.Forms.ListView runwaysListView;
        private System.Windows.Forms.ColumnHeader idColumnHeader;
        private System.Windows.Forms.ColumnHeader inUseColumnHeader;
        private System.Windows.Forms.ColumnHeader headingTrueColumnHeader;
        private System.Windows.Forms.ColumnHeader lengthFeetColumnHeader;
        private System.Windows.Forms.ColumnHeader widthFeetColumnHeader;
        private System.Windows.Forms.ColumnHeader takeoffAllowedColumnHeader;
        private System.Windows.Forms.ColumnHeader landingAllowedColumnHeader;
    }
}