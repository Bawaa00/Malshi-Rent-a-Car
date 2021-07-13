namespace Malshi_Rent_A_Car.View
{
    partial class RViewMaintenanceH
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
            this.crvMRepair = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crvMaintenance1 = new Malshi_Rent_A_Car.CrystalReports.crvMaintenance();
            this.SuspendLayout();
            // 
            // crvMRepair
            // 
            this.crvMRepair.ActiveViewIndex = -1;
            this.crvMRepair.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvMRepair.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvMRepair.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvMRepair.Location = new System.Drawing.Point(0, 0);
            this.crvMRepair.Name = "crvMRepair";
            this.crvMRepair.ReportSource = this.crvMaintenance1;
            this.crvMRepair.Size = new System.Drawing.Size(800, 450);
            this.crvMRepair.TabIndex = 0;
            this.crvMRepair.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // RViewMaintenanceH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvMRepair);
            this.Name = "RViewMaintenanceH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maintenance History Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvMRepair;
        private CrystalReports.crvMaintenance crvMaintenance1;
    }
}