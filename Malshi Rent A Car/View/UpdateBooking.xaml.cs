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
using System.Text.RegularExpressions;

namespace Malshi_Rent_A_Car
{
    /// <summary>
    /// Interaction logic for UpdateBooking.xaml
    /// </summary>
    public partial class UpdateBooking : Window
    {
        public UpdateBooking()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        Booking booking = new Booking();
        Vehicle vehicle = new Vehicle();
        Customer customer = new Customer();

        private void form_updateBooking_Loaded(object sender, RoutedEventArgs e)
        {           
            dt = booking.viewBooking();
            cmb_bid.ItemsSource = dt.DefaultView;
            cmb_bid.DisplayMemberPath = "bookingID";
            cmb_bid.SelectedValuePath = "bookingID";

            dt = vehicle.viewVehicle();
            cmb_vLplate.ItemsSource = dt.DefaultView;
            cmb_vLplate.DisplayMemberPath = "Plate No";
            cmb_vLplate.SelectedValuePath = "Plate No";

            dt = customer.viewCustomer();
            cmb_cNIC.ItemsSource = dt.DefaultView;
            cmb_cNIC.DisplayMemberPath = "NIC";
            cmb_cNIC.SelectedValuePath = "NIC";

            cmb_bid.SelectedIndex = -1;
            cmb_cNIC.SelectedIndex = -1;
            txt_cName.Clear();
            cmb_vLplate.SelectedIndex = -1;
            txt_vYear.Clear();
            txt_vMake.Clear();
            txt_vModel.Clear();
            txt_advance.Clear();
            dte_lend.SelectedDate = null;
            dte_return.SelectedDate = null;

            book_date.Text = DateTime.Now.ToString();
        }

        private void cmb_bid_DropDownClosed(object sender, EventArgs e)
        {

            if (cmb_bid.SelectedItem == null)
            {
                error_msg.Text = "Please Select Booking ID";
            }
            else
            {
                dt = booking.viewBookingID(cmb_bid.Text);
                txt_advance.Text = dt.Rows[0][4].ToString();
                dte_lend.Text = dt.Rows[0][2].ToString();
                dte_return.Text = dt.Rows[0][3].ToString();
                dt = booking.viewCustomerBooking(cmb_bid.Text);
                cmb_cNIC.Text = dt.Rows[0][1].ToString();
                cmb_vLplate.Text = dt.Rows[0][2].ToString();
                cmb_cNIC_DropDownClosed(this, null);
                cmb_vLplate_DropDownClosed(this, null);
            }


            
        }

        private void cmb_cNIC_DropDownClosed(object sender, EventArgs e)
        {
            dt = customer.viewCustomer(cmb_cNIC.Text);
            txt_cName.Text = dt.Rows[0][1].ToString();
        }

        private void cmb_vLplate_DropDownClosed(object sender, EventArgs e)
        {
            dt = vehicle.viewVehicle(cmb_vLplate.Text);
            string model = dt.Rows[0][1].ToString();
            ModelPricing mp = new ModelPricing();
            dt = mp.viewPricing(model);
            txt_vYear.Text = dt.Rows[0][2].ToString();
            txt_vMake.Text = dt.Rows[0][3].ToString();
            txt_vModel.Text = dt.Rows[0][4].ToString();
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            Booking book = new Booking(cmb_bid.Text, book_date.Text, dte_lend.Text, dte_return.Text, Int32.Parse(txt_advance.Text));
            int i = book.updateBooking(cmb_cNIC.Text, cmb_vLplate.Text);
            if (i == 1)
            {
                MessageBox.Show("Data Saved Successfully");
               // btn_clr_Click(this, null);
               // form_addBooking_Loaded(this, null);
            }
            else
                MessageBox.Show("Could not save data,Please try agian");
        }

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            int i = booking.deleteBooking(cmb_bid.Text, cmb_cNIC.Text, cmb_vLplate.Text);           
            if (i == 1)
            {
                MessageBox.Show("Data Deleted Successfully");
                form_updateBooking_Loaded(this, null);
            }
            else
                MessageBox.Show("Could not delete data,Please try agian");
        }

       
    }
}
