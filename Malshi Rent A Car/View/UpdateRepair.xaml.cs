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
    /// Interaction logic for UpdateRepair.xaml
    /// </summary>
    public partial class UpdateRepair : Window
    {
        public UpdateRepair()
        {
            InitializeComponent();
        }
        Vehicle vehicle = new Vehicle();
        DataTable dt = new DataTable();
        MaintenanceRepair mr = new MaintenanceRepair();
        AccidentRepair ar = new AccidentRepair();

        private void cmb_Rtype_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_Rtype.SelectedItem == null)
            {
                error_msg.Text = "Please Select Repair Type";
            }
            else
            {
                if (cmb_Rtype.SelectedIndex == 0)
                {
                    lbl_option1.Visibility = Visibility.Visible;
                    lbl_option1.Text = "Next Check";
                    txt_option1.Visibility = Visibility.Visible;
                    lbl_option2.Visibility = Visibility.Hidden;

                    txt_option2.Visibility = Visibility.Hidden;

                    dt = mr.viewRepair();
                    cmb_id.ItemsSource = dt.DefaultView;
                    cmb_id.DisplayMemberPath = "Repair ID";
                    cmb_id.SelectedValuePath = "Repair ID";

                    frm_updateRepair_Loaded(this, null);
                }
                else if (cmb_Rtype.SelectedIndex == 1)
                {
                    lbl_option1.Visibility = Visibility.Visible;
                    lbl_option1.Text = "Claim (Rs)";
                    lbl_option2.Visibility = Visibility.Visible;
                    lbl_option2.Text = "Duration";
                    txt_option1.Visibility = Visibility.Visible;
                    txt_option2.Visibility = Visibility.Visible;

                    dt = ar.viewRepair();
                    cmb_id.ItemsSource = dt.DefaultView;
                    cmb_id.DisplayMemberPath = "Repair ID";
                    cmb_id.SelectedValuePath = "Repair ID";

                    frm_updateRepair_Loaded(this, null);
                }
            }
        }

        private void frm_updateRepair_Loaded(object sender, RoutedEventArgs e)
        {
            dt = vehicle.viewVehicle();
            cmb_vehicle.ItemsSource = dt.DefaultView;
            cmb_vehicle.DisplayMemberPath = "Plate No";
            cmb_vehicle.SelectedValuePath = "Plate No";

            cmb_id.SelectedIndex = -1;
            date_repair.SelectedDate = null;
            cmb_vehicle.SelectedIndex = -1;
            txt_location.Clear();
            txt_cost.Clear();
            txt_details.Clear();
            txt_option1.Clear();
            txt_option2.Clear();

        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmb_Rtype.SelectedIndex == 0)
                {
                    MaintenanceRepair mr = new MaintenanceRepair(cmb_id.Text, date_repair.Text, txt_location.Text, Int32.Parse(txt_cost.Text), txt_details.Text, txt_option1.Text);
                    int i = mr.updateRepair(cmb_vehicle.Text);
                    if (i == 1)
                    {
                        MessageBox msg = new MessageBox();
                        msg.errorMsg("Data updated successfully!");
                        msg.Show();
                        frm_updateRepair_Loaded(this, null);
                    }

                    else
                    {
                        MessageBox msg = new MessageBox();
                        msg.errorMsg("Could not save data,Please try agian");
                        msg.Show();
                    }
                }
                else if (cmb_Rtype.SelectedIndex == 1)
                {
                    AccidentRepair ar = new AccidentRepair(cmb_id.Text, date_repair.Text, txt_location.Text, Int32.Parse(txt_cost.Text), txt_details.Text, Int32.Parse(txt_option1.Text), Int32.Parse(txt_option2.Text));
                    int i = ar.updateRepair(cmb_vehicle.Text);
                    if (i == 1)
                    {
                        MessageBox msg = new MessageBox();
                        msg.errorMsg("Data updated successfully!");
                        msg.Show();
                        frm_updateRepair_Loaded(this, null);
                    }
                    else
                    {
                        MessageBox msg = new MessageBox();
                        msg.errorMsg("Could not save data,Please try agian");
                        msg.Show();
                    }
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

        private void cmb_id_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_Rtype.SelectedIndex == 0)
            {
                DataTable dt = new DataTable();
                dt = mr.viewRepair(cmb_id.Text);
                date_repair.Text = dt.Rows[0][2].ToString();
                cmb_vehicle.Text = dt.Rows[0][0].ToString();
                txt_location.Text = dt.Rows[0][3].ToString();
                txt_cost.Text = dt.Rows[0][5].ToString();
                txt_details.Text = dt.Rows[0][4].ToString();
                txt_option1.Text = dt.Rows[0][6].ToString();
           
            }
            else if (cmb_Rtype.SelectedIndex == 1)
            {
                DataTable dt = new DataTable();
                dt = ar.viewRepair(cmb_id.Text);
                date_repair.Text = dt.Rows[0][2].ToString();
                cmb_vehicle.Text = dt.Rows[0][0].ToString();
                txt_location.Text = dt.Rows[0][3].ToString();
                txt_cost.Text = dt.Rows[0][5].ToString();
                txt_details.Text = dt.Rows[0][4].ToString();
                txt_option1.Text = dt.Rows[0][6].ToString();
                txt_option2.Text = dt.Rows[0][7].ToString();
            }
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_Rtype.SelectedIndex == 0)
            {
                int i = mr.deleteRepair(cmb_id.Text);
                if (i == 1)
                {
                    MessageBox msg = new MessageBox();
                    msg.errorMsg("Data deleted successfully!");
                    msg.Show();
                    frm_updateRepair_Loaded(this, null);
                }
                else
                {
                    MessageBox msg = new MessageBox();
                    msg.errorMsg("Could not delete data,Please try agian");
                    msg.Show();
                }
            }
            else if (cmb_Rtype.SelectedIndex == 1)
            {
                int i = ar.deleteRepair(cmb_id.Text);
                if (i == 1)
                {
                    MessageBox msg = new MessageBox();
                    msg.errorMsg("Data deleted successfully!");
                    msg.Show();
                    frm_updateRepair_Loaded(this, null);
                }
                else
                {
                    MessageBox msg = new MessageBox();
                    msg.errorMsg("Could not delete data,Please try agian");
                    msg.Show();
                }
            }
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

        private void txt_location_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_location.Text.Length == 0)
                error_msg.Text = "Please Enter Location ";
            else
                error_msg.Text = "";
        }

        private void txt_details_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_details.Text.Length == 0)
                error_msg.Text = "Please Enter Details about the repair ";
            else
                error_msg.Text = "";
        }
    }
}
