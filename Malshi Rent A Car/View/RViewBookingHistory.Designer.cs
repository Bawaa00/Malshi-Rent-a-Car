namespace Malshi_Rent_A_Car.View
{
    partial class RViewBookingHistory
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
            this.crvBooking = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crvBooking1 = new Malshi_Rent_A_Car.CrystalReports.crvBooking();
            this.SuspendLayout();
            // 
            // crvBooking
            // 
            this.crvBooking.ActiveViewIndex = -1;
            this.crvBooking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvBooking.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvBooking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvBooking.Location = new System.Drawing.Point(0, 0);
            this.crvBooking.Name = "crvBooking";
            this.crvBooking.ReportSource = this.crvBooking1;
            this.crvBooking.Size = new System.Drawing.Size(800, 450);
            this.crvBooking.TabIndex = 0;
            this.crvBooking.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // RViewBookingHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvBooking);
            this.Name = "RViewBookingHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Booking History Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvBooking;
        private CrystalReports.crvBooking crvBooking1;
    }
}