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

            dt = customer.viewCustomer();
            cmb_cNIC.ItemsSource = dt.DefaultView;
            cmb_cNIC.DisplayMemberPath = "NIC";
            cmb_cNIC.SelectedValuePath = "NIC";

            book_date.Text = DateTime.Now.ToString();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            Booking book = new Booking(txt_bid.Text,book_date.Text,dte_lend.Text,dte_return.Text,Int32.Parse(txt_advance.Text));
            int i = book.addBooking(cmb_cNIC.Text, cmb_vLplate.Text);
            if (i == 1)
            {
                MessageBox.Show("Data Saved Successfully");
                //btn_cls_Click(this, null);
            }
            else
                MessageBox.Show("Could not save data,Please try agian");
        }

        private void cmb_cNIC_DropDownClosed(object sender, EventArgs e)
        {
            dt = customer.viewCustomer(cmb_cNIC.Text);
            txt_cName.Text = dt.Rows[0][1].ToString();
        }

        private void cmb_vLplate_DropDownClosed(object sender, EventArgs e)
        {
            dt = vehicle.viewVehicle(cmb_vLplate.Text);
            string model= dt.Rows[0][1].ToString();
            ModelPricing mp = new ModelPricing();
            dt = mp.viewPricing(model);
            txt_vYear.Text = dt.Rows[0][2].ToString();
            txt_vMake.Text = dt.Rows[0][3].ToString();
            txt_vModel.Text = dt.Rows[0][4].ToString();
        }

        private void btn_clr_Click(object sender, RoutedEventArgs e)
        {
            cmb_cNIC.SelectedIndex = -1;
            txt_cName.Clear();
            cmb_vLplate.SelectedIndex = -1;
            txt_vYear.Clear();
            txt_vMake.Clear();
            txt_vModel.Clear();
            txt_advance.Clear();
            dte_lend.SelectedDate = null;
            dte_return.SelectedDate = null;
        }
    }
}
