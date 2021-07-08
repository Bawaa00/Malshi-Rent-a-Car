namespace Malshi_Rent_A_Car.View
{
    partial class ReportCustomerBooking
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
            this.crvCustomerBook = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvCustomerBook
            // 
            this.crvCustomerBook.ActiveViewIndex = -1;
            this.crvCustomerBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCustomerBook.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvCustomerBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvCustomerBook.Location = new System.Drawing.Point(0, 0);
            this.crvCustomerBook.Name = "crvCustomerBook";
            this.crvCustomerBook.Size = new System.Drawing.Size(800, 450);
            this.crvCustomerBook.TabIndex = 0;
            this.crvCustomerBook.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ReportCustomerBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvCustomerBook);
            this.Name = "ReportCustomerBooking";
            this.Text = "ReportCustomerBooking";
            this.Load += new System.EventHandler(this.ReportCustomerBooking_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvCustomerBook;
    }
}