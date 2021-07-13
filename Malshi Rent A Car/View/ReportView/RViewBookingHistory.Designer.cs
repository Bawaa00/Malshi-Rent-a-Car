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
            this.crvBook = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.date_start = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.date_end = new MetroFramework.Controls.MetroDateTime();
            this.btn_generate = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // crvBook
            // 
            this.crvBook.ActiveViewIndex = -1;
            this.crvBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvBook.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvBook.Location = new System.Drawing.Point(20, 60);
            this.crvBook.Name = "crvBook";
            this.crvBook.Size = new System.Drawing.Size(917, 418);
            this.crvBook.TabIndex = 0;
            this.crvBook.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // date_start
            // 
            this.date_start.Location = new System.Drawing.Point(270, 24);
            this.date_start.MinimumSize = new System.Drawing.Size(0, 29);
            this.date_start.Name = "date_start";
            this.date_start.Size = new System.Drawing.Size(200, 29);
            this.date_start.TabIndex = 1;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(477, 29);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(22, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "To";
            // 
            // date_end
            // 
            this.date_end.Location = new System.Drawing.Point(506, 25);
            this.date_end.MinimumSize = new System.Drawing.Size(0, 29);
            this.date_end.Name = "date_end";
            this.date_end.Size = new System.Drawing.Size(200, 29);
            this.date_end.TabIndex = 3;
            // 
            // btn_generate
            // 
            this.btn_generate.ActiveControl = null;
            this.btn_generate.Location = new System.Drawing.Point(755, 18);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(87, 36);
            this.btn_generate.TabIndex = 4;
            this.btn_generate.Text = "GENERATE";
            this.btn_generate.UseSelectable = true;
            this.btn_generate.Click += new System.EventHandler(this.btn_generate_Click);
            // 
            // RViewBookingHistory
            // 
            this.ClientSize = new System.Drawing.Size(957, 498);
            this.Controls.Add(this.btn_generate);
            this.Controls.Add(this.date_end);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.date_start);
            this.Controls.Add(this.crvBook);
            this.Name = "RViewBookingHistory";
            this.Text = "Booking History";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RViewBookingHistory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvBooking;
        private CrystalReports.crvBooking crvBooking1;
        private MetroFramework.Controls.MetroDateTime metroDateTime1;
        private MetroFramework.Controls.MetroDateTime metroDateTime2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvBook;
        private MetroFramework.Controls.MetroDateTime date_start;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroDateTime date_end;
        private MetroFramework.Controls.MetroTile btn_generate;
    }
}