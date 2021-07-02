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
    /// Interaction logic for SearchViewVehicle.xaml
    /// </summary>
    public partial class SearchViewVehicle : Window
    {
        public SearchViewVehicle()
        {
            InitializeComponent();
        }
        Vehicle vehicle = new Vehicle();
        DataTable dt = new DataTable();

        private void frm_viewVehicles_Loaded(object sender, RoutedEventArgs e)
        {
            dt = vehicle.viewVehicle();
            dg_vehicle.ItemsSource = dt.DefaultView;
        }

        private void cmb_catagory_DropDownClosed(object sender, EventArgs e)
        {
            dt = vehicle.viewVehicleCategory(cmb_catagory.Text);
            dg_vehicle.ItemsSource = dt.DefaultView;
        }

        private void cmb_make_DropDownClosed(object sender, EventArgs e)
        {
            dt = vehicle.viewVehicleMake(cmb_make.Text);
            dg_vehicle.ItemsSource = dt.DefaultView;
        }

        private void cmb_trans_DropDownClosed(object sender, EventArgs e)
        {
            dt = vehicle.viewVehicleTrans(cmb_trans.Text);
            dg_vehicle.ItemsSource = dt.DefaultView;
        }


        private void cmb_fuel_DropDownClosed(object sender, EventArgs e)
        {
            dt = vehicle.viewVehicleFuel(cmb_fuel.Text);
            dg_vehicle.ItemsSource = dt.DefaultView;
        }

        private void btn_view_Click(object sender, RoutedEventArgs e)
        {
            frm_viewVehicles_Loaded(this, null);
        }
    }
}
