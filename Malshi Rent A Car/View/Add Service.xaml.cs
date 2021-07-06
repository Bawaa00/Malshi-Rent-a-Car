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
    /// Interaction logic for Add_Service.xaml
    /// </summary>
    public partial class Add_Service : Window
    {
        public Add_Service()
        {
            InitializeComponent();
        }
        Service service = new Service();
        Vehicle vehicle = new Vehicle();
        Database db = new Database();
        DataTable dt = new DataTable();

        private void form_addService_Loaded(object sender, RoutedEventArgs e)
        {
            dt = vehicle.viewVehicle();
            cmb_vid.ItemsSource = dt.DefaultView;
            cmb_vid.DisplayMemberPath = "Plate No";
            cmb_vid.SelectedValuePath = "Plate No";
            dt = db.getData("Select max(sID) from Service");
            string id = dt.Rows[0][0].ToString();
            if (id == "")
            {
                txt_sid.Text = "S001";
            }
            else
            {
                var prefix = Regex.Match(id, "^\\D+").Value;
                var number = Regex.Replace(id, "^\\D+", "");
                var i = int.Parse(number) + 1;
                var newString = prefix + i.ToString(new string('0', number.Length));
                txt_sid.Text = newString;
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Service Service = new Service(txt_sid.Text, txt_details.Text, txt_sLocation.Text, dte_service.Text, Convert.ToDouble(txt_mileage.Text), Convert.ToDouble(txt_nxtMileage.Text), Convert.ToDouble(txt_sCost.Text));
                int i = Service.addService(cmb_vid.Text);
                if (i == 1)
                {
                    MessageBox msg = new MessageBox();
                    msg.Show();
                    //MessageBox.Show("Data Saved Successfully!");
                }
                else
                {
                    MessageBox msg = new MessageBox();
                    msg.errorMsg("Sorry, couldn't save your data.Please try again");
                    msg.Show();
                    //MessageBox.Show("Couldnt Save data.Please Try Again");
                }
            }
          
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Please fill the form correctly. ");
                msg.Show();
            }
            catch (Exception ex)
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Oops something went worng. " + ex.Message);
                msg.Show();
            }
        }

        private void btn_cls_Click(object sender, RoutedEventArgs e)
        {
            cmb_vid.SelectedIndex = -1;
            txt_sid.Clear();
            txt_details.Clear();
            txt_sLocation.Clear();
            dte_service.SelectedDate = null;
            txt_mileage.Clear();
            txt_mileage.Clear();
            txt_sCost.Clear();
        }

        private void txt_mileage_KeyUp(object sender, KeyEventArgs e)
        {
            if(txt_mileage.Text != "")
            {
                int next = Int32.Parse(txt_mileage.Text);
                txt_nxtMileage.Text = (next + 2500).ToString();
            }
            
        }

        private void cmb_vid_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_vid.SelectedItem == null)
            {
                error_msg.Text = "Please Select Number of Passengers";
            }
            else { error_msg.Text = ""; }
        }

        private void txt_mileage_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_mileage.Text.Length == 0)
                error_msg.Text = "Please Enter Milage";
            else if (!Regex.IsMatch(txt_mileage.Text, "^[0-9]*$"))
                error_msg.Text = "Please enter numbers only";
            else
                error_msg.Text = "";
        }

        private void txt_sCost_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_sCost.Text.Length == 0)
                error_msg.Text = "Please Enter cost";
            else if (!Regex.IsMatch(txt_sCost.Text, "^[0-9]*$"))
                error_msg.Text = "Please enter numbers only";
            else
                error_msg.Text = "";
        }

        private void txt_sLocation_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (txt_sLocation.Text.Length == 0)
                error_msg.Text = "Please Enter Location ";
            else
                error_msg.Text = "";
        }

        private void txt_details_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_details.Text.Length == 0)
                error_msg.Text = "Please Enter Details";
            else
                error_msg.Text = "";
        }
    }
}



