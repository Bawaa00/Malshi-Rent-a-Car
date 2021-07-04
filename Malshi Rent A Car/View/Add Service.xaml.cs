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
    /// Interaction logic for Add_Service.xaml
    /// </summary>
    public partial class Add_Service : Window
    {
        public Add_Service()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {}
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {}
        private void txt_details_TextChanged(object sender, TextChangedEventArgs e)
        {}
        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {}
        private void txt_mileage_TextChanged(object sender, TextChangedEventArgs e)
        {}
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {}
        private void txt_sLocation_TextChanged(object sender, TextChangedEventArgs e)
        {}
        private void txt_sCost_Copy1_TextChanged(object sender, TextChangedEventArgs e)
        {}
        private void txt_nxtMileage_TextChanged(object sender, TextChangedEventArgs e)
        {}
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {}

        private void save_service_click(object sender, RoutedEventArgs e)
        {
            


            Service Service = new Service(vehicleID.Text,sID.Text,sDetails.Text,sLocation.Text,sDate.Text,Convert.ToDouble(milage.Text),Convert.ToDouble(nxtMilage.Text),Convert.ToDouble(sCost.Text));
            int i = Service.addService();
            if (i == 1)
            {
                MessageBox.Show("Data Saved Successfully!");
                Button_Click_1(this, null);
            }
            else
            {
                MessageBox.Show("Couldnt Save data.Please Try Again");
            }

        }

        private void nxtMilage_TextChanged(object sender, TextChangedEventArgs e)
        {}

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {}

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            vehicleID.Text = "";
            sID.Clear();
            sDetails.Clear();
            sLocation.Clear();
            sDate.Text = "";
            milage.Clear();
            nxtMilage.Clear();
            sCost.Clear();

        }

        private void sDetails_TextChanged(object sender, TextChangedEventArgs e)
        {
            Service Service = new Service();
            Service.viewService();
        }
    }
}
