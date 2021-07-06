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

namespace Malshi_Rent_A_Car
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        String utype;
        public Dashboard(string utype)
        {
            InitializeComponent();
            this.utype = utype;
        }

        private void list_customer_Selected(object sender, RoutedEventArgs e)
        {
            SearchViewCustomer obj = new SearchViewCustomer();
            obj.Show();
        }

        private void list_owners_Selected(object sender, RoutedEventArgs e)
        {
            searchViewOwners obj = new searchViewOwners();
            obj.Show();
        }

        private void list_pricing_Selected(object sender, RoutedEventArgs e)
        {
            Pricing obj = new Pricing();
            obj.Show();
        }

        private void list_repairs_Selected(object sender, RoutedEventArgs e)
        {
            searchViewRepair obj = new searchViewRepair();
            obj.Show();
        }

        private void list_service_Selected(object sender, RoutedEventArgs e)
        {
            searchViewServices obj = new searchViewServices();
            obj.Show();
        }

        private void list_vehicle_Selected(object sender, RoutedEventArgs e)
        {
            SearchViewVehicle obj = new SearchViewVehicle();
            obj.Show();
        }
    }
}
