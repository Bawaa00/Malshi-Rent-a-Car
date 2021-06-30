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
    /// Interaction logic for searchViewOwners.xaml
    /// </summary>
    public partial class searchViewOwners : Window
    {
        public searchViewOwners()
        {
            InitializeComponent();
        }
        Owner owner = new Owner();
        private void btn_view_Click(object sender, RoutedEventArgs e)
        {
            
            DataTable dt = new DataTable();
            dt = owner.viewOwner();
            dg_owner.ItemsSource = dt.DefaultView;
        }

        private void btn_searchOwnNIC_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = owner.viewOwner(txt_OwnNIC.Text);
            dg_owner.ItemsSource = dt.DefaultView;
        }

        private void btn_searchOwnName_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = owner.searchOwner(txt_OwnName.Text);
            dg_owner.ItemsSource = dt.DefaultView;
        }

        private void txt_OwnNIC_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_OwnNIC.Clear();
        }

        private void txt_OwnName_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_OwnName.Clear();
        }
    }
}
