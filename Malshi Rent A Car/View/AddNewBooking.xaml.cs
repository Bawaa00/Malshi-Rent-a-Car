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
    /// Interaction logic for AddNewBooking.xaml
    /// </summary>
    public partial class AddNewBooking : Window
    {
        public AddNewBooking()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        Database db = new Database();
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

            dt = db.getData("Select max(bookingID) from Booking ");
            string id = dt.Rows[0][0].ToString();
            if (id == "")
            {
                txt_bid.Text = "B001";
            }
            else
            {
                var prefix = Regex.Match(id, "^\\D+").Value;
                var number = Regex.Replace(id, "^\\D+", "");
                var i = int.Parse(number) + 1;
                var newString = prefix + i.ToString(new string('0', number.Length));
                txt_bid.Text = newString;
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Booking book = new Booking(txt_bid.Text, book_date.Text, dte_lend.Text, dte_return.Text, Int32.Parse(txt_advance.Text));
                int i = book.addBooking(cmb_cNIC.Text, cmb_vLplate.Text);
                if (i == 1)
                {
                    MessageBox.Show("Data Saved Successfully");
                    btn_clr_Click(this, null);
                    form_addBooking_Loaded(this, null);
                }
                else
                    MessageBox.Show("Could not save data,Please try agian");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Please fill the form correctly");
                msg.Show();
            }
            catch (Exception ex)
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Oops something went worng. " + ex.Message);
                msg.Show();
            }
        }

        private void cmb_cNIC_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                dt = customer.viewCustomer(cmb_cNIC.Text);
                txt_cName.Text = dt.Rows[0][1].ToString();
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Database Error");
                msg.Show();
            }
            catch (Exception ex)
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Oops soomething went worng. " + ex.Message);
                msg.Show();
            }
        }

        private void cmb_vLplate_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                dt = vehicle.viewVehicle(cmb_vLplate.Text);
                string model = dt.Rows[0][1].ToString();
                ModelPricing mp = new ModelPricing();
                dt = mp.viewPricing(model);
                txt_vYear.Text = dt.Rows[0][2].ToString();
                txt_vMake.Text = dt.Rows[0][3].ToString();
                txt_vModel.Text = dt.Rows[0][4].ToString();
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Database Error");
                msg.Show();
            }
            catch (Exception ex)
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Oops soomething went worng. " + ex.Message);
                msg.Show();
            }

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

        private void txt_advance_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txt_advance.Text.Length ==  0)
            {
                error_msg.Text = "Please Enter Advance Amount";
            }
            else
            {
                error_msg.Text = "";
            }
        }

        private void txt_cName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cmb_cNIC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmb_cNIC.SelectedItem==null)
            {
                error_msg.Text = "Please select Customer NIC";

            }
            else
            {
                error_msg.Text = " ";
            }
        }

        private void cmb_vLplate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cmb_vLplate.SelectedItem == null)
            {
                error_msg.Text = "Please select vehicle license plate number ";

            }
            else
            {
                error_msg.Text = " ";
            }
        }

        private void dte_lend_CalendarClosed(object sender, RoutedEventArgs e)
        {

        }

        private void dte_return_CalendarClosed(object sender, RoutedEventArgs e)
        {
            DateTime lenddate = Convert.ToDateTime(dte_lend.Text);
            DateTime returndate = Convert.ToDateTime(dte_return.Text);
            if(lenddate<= returndate)
            {
                TimeSpan ts = returndate.Subtract(lenddate);
                int days = Convert.ToInt16(ts.Days);
                error_msg.Text = "";

            }
            else
            {
                error_msg.Text = "Retuen date cannot be lessthan lend date";
            }
        }
    }
}
