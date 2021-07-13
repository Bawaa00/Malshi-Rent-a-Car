namespace Malshi_Rent_A_Car.View
{
    partial class RViewServiceHistory
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
            this.crvService = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crvService1 = new Malshi_Rent_A_Car.CrystalReports.crvService();
            this.SuspendLayout();
            // 
            // crvService
            // 
            this.crvService.ActiveViewIndex = -1;
            this.crvService.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvService.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvService.Location = new System.Drawing.Point(0, 0);
            this.crvService.Name = "crvService";
            this.crvService.ReportSource = this.crvService1;
            this.crvService.Size = new System.Drawing.Size(800, 450);
            this.crvService.TabIndex = 0;
            this.crvService.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // RViewServiceHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvService);
            this.Name = "RViewServiceHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Service History Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvService;
        private CrystalReports.crvService crvService1;
    }
}