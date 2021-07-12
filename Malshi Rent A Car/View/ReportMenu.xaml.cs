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

        private void cmb_type_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_type.SelectedIndex == 0)
            {
                lbl_option1.Visibility = Visibility.Hidden;
                cmb_option1.Visibility = Visibility.Hidden;
            }
            if (cmb_type.SelectedIndex == 1)
            {
                lbl_option1.Visibility = Visibility.Hidden;
                cmb_option1.Visibility = Visibility.Hidden;
            }
            if (cmb_type.SelectedIndex == 2)
            {
                lbl_option1.Visibility = Visibility.Visible;
                lbl_option1.Text = "Customer NIC";
                cmb_option1.Visibility = Visibility.Visible;
                cmb_option1.ItemsSource = null;

            }
            if (cmb_type.SelectedIndex == 3)
            {
                lbl_option1.Visibility = Visibility.Visible;
                lbl_option1.Text = "Vehicle No";
                cmb_option1.Visibility = Visibility.Visible;
                cmb_option1.ItemsSource = null;
            }
        }
    }
}
