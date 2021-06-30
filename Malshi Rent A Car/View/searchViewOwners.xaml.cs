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

        private void btn_view_Click(object sender, RoutedEventArgs e)
        {
            Owner owner = new Owner();
            DataTable dt = new DataTable();
            dt = owner.viewOwner();
            dg_owner.ItemsSource = dt.DefaultView;
        }
    }
}
