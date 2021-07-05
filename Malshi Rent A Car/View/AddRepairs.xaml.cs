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
    /// Interaction logic for AddRepairs_Maintenance_.xaml
    /// </summary>
    public partial class AddRepairs_Maintenance_ : Window
    {
        public AddRepairs_Maintenance_()
        {
            InitializeComponent();
        }
        Vehicle vehicle = new Vehicle();
        DataTable dt = new DataTable();

        private void cmb_Rtype_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_Rtype.SelectedIndex == 0)
            {
                lbl_option1.Visibility = Visibility.Visible;
                lbl_option1.Text = "Next Check";
                txt_option1.Visibility = Visibility.Visible;
                lbl_option2.Visibility = Visibility.Hidden;
                
                txt_option2.Visibility = Visibility.Hidden;
            }
            else if (cmb_Rtype.SelectedIndex == 1)
            {
                lbl_option1.Visibility = Visibility.Visible;
                lbl_option1.Text = "Claim (Rs)";
                lbl_option2.Visibility = Visibility.Visible;
                lbl_option2.Text = "Duration";
                txt_option1.Visibility = Visibility.Visible;
                txt_option2.Visibility = Visibility.Visible;
            }
        }

        private void frm_addRepair_Loaded(object sender, RoutedEventArgs e)
        {
            dt = vehicle.viewVehicle();
            cmb_vehicle.ItemsSource = dt.DefaultView;
            cmb_vehicle.DisplayMemberPath = "Plate No";
            cmb_vehicle.SelectedValuePath = "Plate No";
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmb_Rtype.SelectedIndex == 0)
                {
                    MaintenanceRepair mr = new MaintenanceRepair(txt_id.Text, date_repair.Text, txt_location.Text, Int32.Parse(txt_cost.Text), txt_details.Text, txt_option1.Text);
                    int i = mr.addRepair(cmb_vehicle.Text);
                    if (i == 1)
                    {
                        MessageBox.Show("Data saved successfully");
                    }
                    else
                        MessageBox.Show("Error.Failed to insert data");
                }
                else if (cmb_Rtype.SelectedIndex == 1)
                {
                    AccidentRepair ar = new AccidentRepair(txt_id.Text, date_repair.Text, txt_location.Text, Int32.Parse(txt_cost.Text), txt_details.Text, Int32.Parse(txt_option1.Text), Int32.Parse(txt_option2.Text));
                    int i = ar.addRepair(cmb_vehicle.Text);
                    if (i == 1)
                    {
                        MessageBox.Show("Data saved successfully");
                    }
                    else
                        MessageBox.Show("Error.Failed to insert data");
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Please fill the form correctly. Database Error");
                msg.Show();
            }


            catch (Exception ex)
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Oops something went worng. " + ex.Message);
                msg.Show();
            }

        }

        private void txt_location_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (txt_location.Text.Length == 0)
                error_msg.Text = "Please Enter Location ";
            else
                error_msg.Text = "";
        }

        private void txt_cost_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_cost.Text.Length == 0)
                error_msg.Text = "Please Enter Repair cost ";
            else if (!Regex.IsMatch(txt_cost.Text, "^[0-9]*$"))
                error_msg.Text = "Please enter numbers only";
            else
                error_msg.Text = "";
        }
    }
}
