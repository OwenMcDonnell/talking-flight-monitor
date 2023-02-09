namespace tfm.JumpTo
{
    partial class GatesForm
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
            this.gatesListView = new System.Windows.Forms.ListView();
            this.idColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numberColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.inUseColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            // gatesListView
            // 
            this.gatesListView.AccessibleName = "Gates";
            this.gatesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idColumnHeader,
            this.nameColumnHeader,
            this.numberColumnHeader,
            this.typeColumnHeader,
            this.inUseColumnHeader});
            this.gatesListView.HideSelection = false;
            this.gatesListView.Location = new System.Drawing.Point(6, 46);
            this.gatesListView.Name = "gatesListView";
            this.gatesListView.Size = new System.Drawing.Size(1321, 690);
            this.gatesListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.gatesListView.TabIndex = 1;
            this.gatesListView.UseCompatibleStateImageBehavior = false;
            this.gatesListView.View = System.Windows.Forms.View.Details;
            this.gatesListView.ItemActivate += new System.EventHandler(this.gatesListView_ItemActivate);
            // 
            // idColumnHeader
            // 
            this.idColumnHeader.Text = "ID";
            this.idColumnHeader.Width = 200;
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 200;
            // 
            // numberColumnHeader
            // 
            this.numberColumnHeader.Text = "Number";
            this.numberColumnHeader.Width = 200;
            // 
            // typeColumnHeader
            // 
            this.typeColumnHeader.Text = "Type";
            this.typeColumnHeader.Width = 200;
            // 
            // inUseColumnHeader
            // 
            this.inUseColumnHeader.Text = "In use";
            this.inUseColumnHeader.Width = 200;
            // 
            // GatesForm
            // 
            this.AccessibleName = "Jump to gate";
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1333, 742);
            this.Controls.Add(this.gatesListView);
            this.Controls.Add(this.airportTextBox);
            this.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "GatesForm";
            this.Text = "Jump to gate";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GatesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox airportTextBox;
        private System.Windows.Forms.ListView gatesListView;
        private System.Windows.Forms.ColumnHeader idColumnHeader;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader numberColumnHeader;
        private System.Windows.Forms.ColumnHeader typeColumnHeader;
        private System.Windows.Forms.ColumnHeader inUseColumnHeader;
    }
}