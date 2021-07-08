using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Malshi_Rent_A_Car.View
{
    public partial class ReportCustomerBooking : Form
    {
        public ReportCustomerBooking()
        {
            InitializeComponent();
        }
        public ReportCustomerBooking(string nic)
        {
            InitializeComponent();
            cNIC = nic;
        }
        String cNIC;
        Database db = new Database();
        DataTable dt = new DataTable();
        Booking book = new Booking();

        private void ReportCustomerBooking_Load(object sender, EventArgs e)
        {
            dt = book.viewBooking();
            CrystalReports.crvCustomerBookings cusBK = new CrystalReports.crvCustomerBookings();
            cusBK.Database.Tables["Customer_Booking"].SetDataSource(dt);

            crvCustomerBook.ReportSource = null;
            crvCustomerBook.ReportSource = cusBK;
        }
    }
}
