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
    /// Interaction logic for SearchViewCustomer.xaml
    /// </summary>
    public partial class SearchViewCustomer : Window
    {
        public SearchViewCustomer()
        {
            InitializeComponent();
        }

        Customer customer = new Customer();
        Database db = new Database();
        DataTable dt = new DataTable();
      

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            AddCustomer obj = new AddCustomer();
            obj.Show();
        }

       

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            UpdateCustomer obj = new UpdateCustomer();
            obj.Show();
        }

        private void view_customer_Loaded(object sender, RoutedEventArgs e)
        {
            dt = customer.viewCustomer();
            dg_customer.ItemsSource = dt.DefaultView;
        }

        private void btn_view_Click(object sender, RoutedEventArgs e)
        {
            view_customer_Loaded(this, null);
        }

        private void btn_searchNIC_Click(object sender, RoutedEventArgs e)
        {
            dt = customer.viewCustomerNIC(txt_CusNIC.Text);
            dg_customer.ItemsSource = dt.DefaultView;
        }

        private void btn_searchName_Click(object sender, RoutedEventArgs e)
        {
            dt = customer.viewCustomerName(txt_CusName.Text);
            dg_customer.ItemsSource = dt.DefaultView;
        }

        private void txt_CusNIC_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_CusNIC.Clear();
            txt_CusName.Text = "Name";
        }

        private void txt_CusName_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_CusName.Clear();
            txt_CusNIC.Text = "Customer NIC";
        }
    }

}
