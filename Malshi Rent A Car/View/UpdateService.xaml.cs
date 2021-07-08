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
    /// Interaction logic for UpdateService.xaml
    /// </summary>
    public partial class UpdateService : Window
    {
        public UpdateService()
        {
            InitializeComponent();
        }
        Vehicle vehicle = new Vehicle();
        Service service = new Service();
        DataTable dt = new DataTable();

        private void form_updateService_Loaded(object sender, RoutedEventArgs e)
        {
            dt = vehicle.viewVehicle();
            cmb_vehicleID.ItemsSource = dt.DefaultView;
            cmb_vehicleID.DisplayMemberPath = "Plate No";
            cmb_vehicleID.SelectedValuePath = "Plate No";

            dt = service.viewService();
            cmb_sID.ItemsSource = dt.DefaultView;
            cmb_sID.DisplayMemberPath = "Service ID";
            cmb_sID.SelectedValuePath = "Service ID";

            txt_SLocation.Clear();
            txt_milage.Clear();
            date_service.SelectedDate = null;
            txt_nxtMilage.Clear();
            txt_sCost.Clear();
            txt_sDetails.Clear();
        }

        private void cmb_sID_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_sID.SelectedItem == null)
            {
                error_msg.Text = "Please Select SID";
            }
            else
            {
                dt = service.viewServiceID(cmb_sID.Text);
                cmb_vehicleID.Text = dt.Rows[0][0].ToString();
                txt_sDetails.Text = dt.Rows[0][2].ToString();
                txt_SLocation.Text = dt.Rows[0][3].ToString();
                date_service.Text = dt.Rows[0][4].ToString();
                txt_milage.Text = dt.Rows[0][5].ToString();
                txt_nxtMilage.Text = dt.Rows[0][6].ToString();
                txt_sCost.Text = dt.Rows[0][7].ToString();
            }
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Service upService = new Service(cmb_sID.Text, txt_sDetails.Text, txt_SLocation.Text, date_service.Text, Int32.Parse(txt_milage.Text), Int32.Parse(txt_nxtMilage.Text), Int32.Parse(txt_sCost.Text));
                int i = upService.updateService(cmb_vehicleID.Text);
                if (i == 1)
                {
                    MessageBox msg = new MessageBox();
                    msg.errorMsg("Data updated successfully!");
                    msg.Show();
                }
                else
                {
                    MessageBox msg = new MessageBox();
                    msg.errorMsg("Sorry, couldn't save your data.Please try again");
                    msg.Show();
                }
            }

            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Please fill the form correctly.");
                msg.Show();
            }
            catch (Exception ex)
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Oops something went worng. " + ex.Message);
                msg.Show();
            }
        }

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            int i = service.deleteService(cmb_sID.Text);
            if (i == 1)
            {
                MessageBox msg = new MessageBox();
                msg.Show();
                form_updateService_Loaded(this, null);
            }
            else
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Sorry, couldn't delete your data.Please try again");
                msg.Show();
               
            }
        }

        private void txt_milage_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_milage.Text != "")
            {
                int next = Int32.Parse(txt_milage.Text);
                txt_nxtMilage.Text = (next + 2500).ToString();
            }
        }

        private void cmb_vehicleID_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_vehicleID.SelectedItem == null)
            {
                error_msg.Text = "Please SelectVehicle ID";
            }
            else { error_msg.Text = ""; }
        }

        private void txt_SLocation_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (txt_SLocation.Text.Length == 0)
                error_msg.Text = "Please Enter Location ";
            else
                error_msg.Text = "";
        }

        private void txt_milage_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_milage.Text.Length == 0)
                error_msg.Text = "Please Enter Milage";
            else if (!Regex.IsMatch(txt_milage.Text, "^[0-9]*$"))
                error_msg.Text = "Please enter numbers only";
            else
                error_msg.Text = "";
        }

        private void txt_nxtMilage_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_nxtMilage.Text.Length == 0)
                error_msg.Text = "Please Enter Next Milage";
            else if (!Regex.IsMatch(txt_nxtMilage.Text, "^[0-9]*$"))
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

        private void txt_sDetails_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (txt_sDetails.Text.Length == 0)
                error_msg.Text = "Please Enter Details";
            else
                error_msg.Text = "";
        }
    }
}
