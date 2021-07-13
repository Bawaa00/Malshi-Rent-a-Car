using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Malshi_Rent_A_Car.View
{
    /// <summary>
    /// Interaction logic for ReportMenu.xaml
    /// </summary>
    public partial class ReportMenu : Window
    {
        public ReportMenu()
        {
            InitializeComponent();
        }

        private void btn_status_Click(object sender, RoutedEventArgs e)
        {
            RViewVehicleStatus obj = new RViewVehicleStatus();
            obj.Show();
        }

        private void btn_book_Click(object sender, RoutedEventArgs e)
        {
            RViewBookingHistory obj = new RViewBookingHistory();
            obj.Show();
        }

        private void btn_service_Click(object sender, RoutedEventArgs e)
        {
            RViewServiceHistory obj = new RViewServiceHistory();
            obj.Show();
        }

        private void btn_maintenance_Click(object sender, RoutedEventArgs e)
        {
            RViewMaintenanceH obj = new RViewMaintenanceH();
            obj.Show();
        }

        private void btn_accident_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_cus_book_Click(object sender, RoutedEventArgs e)
        {
            View.RViewCustomerBooking obj = new View.RViewCustomerBooking(); ;
            obj.Show();
        }

        private void btn_vehicle_book_Click(object sender, RoutedEventArgs e)
        {
            View.RViewVehicleBooking obj = new RViewVehicleBooking();
            obj.Show();
        }
    }
}
