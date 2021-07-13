namespace Malshi_Rent_A_Car.View
{
    partial class RViewVehicleBooking
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
            this.crvVehicleBooking = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.cmb_vehicle = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // crvVehicleBooking
            // 
            this.crvVehicleBooking.ActiveViewIndex = -1;
            this.crvVehicleBooking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvVehicleBooking.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvVehicleBooking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvVehicleBooking.Location = new System.Drawing.Point(20, 60);
            this.crvVehicleBooking.Name = "crvVehicleBooking";
            this.crvVehicleBooking.Size = new System.Drawing.Size(760, 370);
            this.crvVehicleBooking.TabIndex = 0;
            this.crvVehicleBooking.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // cmb_vehicle
            // 
            this.cmb_vehicle.FormattingEnabled = true;
            this.cmb_vehicle.ItemHeight = 23;
            this.cmb_vehicle.Location = new System.Drawing.Point(390, 25);
            this.cmb_vehicle.Name = "cmb_vehicle";
            this.cmb_vehicle.Size = new System.Drawing.Size(155, 29);
            this.cmb_vehicle.TabIndex = 1;
            this.cmb_vehicle.UseSelectable = true;
            this.cmb_vehicle.DropDownClosed += new System.EventHandler(this.cmb_vehicle_DropDownClosed);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(298, 30);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(83, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "License Plate";
            // 
            // RViewVehicleBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.cmb_vehicle);
            this.Controls.Add(this.crvVehicleBooking);
            this.Name = "RViewVehicleBooking";
            this.Text = "Report Vehicle Booking";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RViewVehicleBooking_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvVehicleBooking;
        private MetroFramework.Controls.MetroComboBox cmb_vehicle;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}