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
    /// Interaction logic for AddNewBooking.xaml
    /// </summary>
    public partial class AddNewBooking : Window
    {
        public AddNewBooking()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        Vehicle vehicle = new Vehicle();
        Customer customer = new Customer();
        Booking book = new Booking();

        private void form_addBooking_Loaded(object sender, RoutedEventArgs e)
        {
            dt = vehicle.viewVehicle();
            cmb_vLplate.ItemsSource = dt.DefaultView;
            cmb_vLplate.DisplayMemberPath = "Plate No";
            cmb_vLplate.SelectedValuePath = "Plate No";

            dt = vehicle.viewVehicle();
            cmb_vLplate.ItemsSource = dt.DefaultView;
            cmb_vLplate.DisplayMemberPath = "Plate No";
            cmb_vLplate.SelectedValuePath = "Plate No";
        }
    }
}
