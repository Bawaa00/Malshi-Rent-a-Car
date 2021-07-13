namespace Malshi_Rent_A_Car.View
{
    partial class RViewVehicleStatus
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
            this.crvVStatus = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crvVehicleStatus1 = new Malshi_Rent_A_Car.CrystalReports.crvVehicleStatus();
            this.SuspendLayout();
            // 
            // crvVStatus
            // 
            this.crvVStatus.ActiveViewIndex = -1;
            this.crvVStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvVStatus.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvVStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvVStatus.Location = new System.Drawing.Point(0, 0);
            this.crvVStatus.Name = "crvVStatus";
            this.crvVStatus.ReportSource = this.crvVehicleStatus1;
            this.crvVStatus.Size = new System.Drawing.Size(800, 450);
            this.crvVStatus.TabIndex = 0;
            this.crvVStatus.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // RViewVehicleStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvVStatus);
            this.Name = "RViewVehicleStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vehicle Status Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvVStatus;
        private CrystalReports.crvVehicleStatus crvVehicleStatus1;
    }
}