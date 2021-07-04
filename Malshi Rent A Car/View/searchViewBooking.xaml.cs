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
using System.Data;

namespace Malshi_Rent_A_Car
{
    /// <summary>
    /// Interaction logic for searchViewBooking.xaml
    /// </summary>
    public partial class searchViewBooking : Window
    {
        public searchViewBooking()
        {
            InitializeComponent();
        }
        Vehicle vehicle = new Vehicle();
        Customer customer = new Customer();
        Booking book = new Booking();
        DataTable dt = new DataTable();

        private void form_viewBooking_Loaded(object sender, RoutedEventArgs e)
        {
            dt = vehicle.viewVehicle();
            cmb_vno.ItemsSource = dt.DefaultView;
            cmb_vno.DisplayMemberPath = "Plate No";
            cmb_vno.SelectedValuePath = "Plate No";

            dt = customer.viewCustomer();
            cmb_cno.ItemsSource = dt.DefaultView;
            cmb_cno.DisplayMemberPath = "NIC";
            cmb_cno.SelectedValuePath = "NIC";
        }

        private void btn_view_Click(object sender, RoutedEventArgs e)
        {
            cmb_vno.SelectedIndex = -1;
            cmb_cno.SelectedIndex = -1;
            dte_bDate.SelectedDate = null;

            dt = book.viewBookingForm();
            dg_booking.ItemsSource = dt.DefaultView;
        }

        private void cmb_vno_DropDownClosed(object sender, EventArgs e)
        {
            dte_bDate.SelectedDate = null;
            cmb_cno.SelectedIndex = -1;
            dt = book.viewBookingVehicle(cmb_vno.Text);
            dg_booking.ItemsSource = dt.DefaultView;
        }

        private void cmb_cno_DropDownClosed(object sender, EventArgs e)
        {
            dte_bDate.SelectedDate = null;
            cmb_vno.SelectedIndex = -1;
            dt = book.viewBookingCustomer(cmb_cno.Text);
            dg_booking.ItemsSource = dt.DefaultView;
        }

        private void dte_bDate_CalendarClosed(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(dte_bDate.SelectedDate.Value.ToString("yyyy-MM-dd"));
            Console.WriteLine(dte_bDate.Text);
            dt = book.viewBookingDate(dte_bDate.Text);           
            dg_booking.ItemsSource = dt.DefaultView;
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            AddNewBooking obj = new AddNewBooking();
            obj.Show();
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            UpdateBooking obj = new UpdateBooking();
            obj.Show();
        }
    }
}
