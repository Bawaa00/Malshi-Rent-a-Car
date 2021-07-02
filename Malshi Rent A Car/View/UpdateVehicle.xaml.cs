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
    /// Interaction logic for UpdateVehicle.xaml
    /// </summary>
    public partial class UpdateVehicle : Window
    {
        public UpdateVehicle()
        {
            InitializeComponent();
        }
        Database db;
        Vehicle vehicle = new Vehicle();
        DataTable dt = new DataTable();

        private void frm_updateVehicle_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = vehicle.viewVehicle();
            cmb_plateNo.ItemsSource = dt.DefaultView;
            cmb_plateNo.DisplayMemberPath = "Plate No";
            cmb_plateNo.SelectedValuePath = "Plate No";
        }

        private void cmb_plateNo_DropDownClosed(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = vehicle.viewVehicle();
            cmb_category.Text = dt.Rows[0][1].ToString();
            cmb_make.Text = dt.Rows[0][2].ToString();
            txt_model.Text = dt.Rows[0][9].ToString();
            cmb_color.Text = dt.Rows[0][3].ToString();
            cmb_year.Text = dt.Rows[0][4].ToString();
            cmb_Ecapacity.Text = dt.Rows[0][5].ToString();
            cmb_Ftype.Text = dt.Rows[0][6].ToString();
            cmb_passengers.Text = dt.Rows[0][7].ToString();
            cmb_insID.Text = dt.Rows[0][8].ToString();
            date_InsStart.Text = dt.Rows[0][8].ToString();
            date_InsEnd.Text = dt.Rows[0][8].ToString();
            date_LicStart.Text = dt.Rows[0][8].ToString();
            cmb_oNIC.Text = dt.Rows[0][8].ToString();
            txt_oName.Text = dt.Rows[0][8].ToString();
            txt_wName.Text = dt.Rows[0][8].ToString();
            txt_wAddress.Text = dt.Rows[0][8].ToString();
            txt_wContact.Text = dt.Rows[0][8].ToString();
        }
    }
}
