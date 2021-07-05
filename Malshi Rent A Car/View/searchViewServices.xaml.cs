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
    /// Interaction logic for searchViewServices.xaml
    /// </summary>
    public partial class searchViewServices : Window
    {
        public searchViewServices()
        {
            InitializeComponent();
        }
        Vehicle vehicle = new Vehicle();
        Service service = new Service();
        DataTable dt = new DataTable();

        private void form_viewService_Loaded(object sender, RoutedEventArgs e)
        {
            dt = vehicle.viewVehicle();
            cmb_vehicle.ItemsSource = dt.DefaultView;
            cmb_vehicle.DisplayMemberPath = "Plate No";
            cmb_vehicle.SelectedValuePath = "Plate No";

            dt = service.viewService();
            dg_service.ItemsSource = dt.DefaultView;
        }

        private void btn_view_Click(object sender, RoutedEventArgs e)
        {
            form_viewService_Loaded(this, null);
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            Add_Service obj = new Add_Service();
            obj.Show();
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            UpdateService obj = new UpdateService();
            obj.Show();
        }

        private void cmb_vehicle_DropDownClosed(object sender, EventArgs e)
        {
            dt =service.viewService(cmb_vehicle.Text);
            dg_service.ItemsSource = dt.DefaultView;
        }
    }
}
