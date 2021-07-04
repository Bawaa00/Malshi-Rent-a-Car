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
            }
        }

        private void frm_updateRepair_Loaded(object sender, RoutedEventArgs e)
        {
            dt = vehicle.viewVehicle();
            cmb_vehicle.ItemsSource = dt.DefaultView;
            cmb_vehicle.DisplayMemberPath = "Plate No";
            cmb_vehicle.SelectedValuePath = "Plate No";

        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
