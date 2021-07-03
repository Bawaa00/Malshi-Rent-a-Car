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
        ModelPricing model = new ModelPricing();
        DataTable dt = new DataTable();
        Insurance insurance = new Insurance();
        Owner owner = new Owner();
        string path;

        private void frm_updateVehicle_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = vehicle.viewVehicle();
            cmb_plateNo.ItemsSource = dt.DefaultView;
            cmb_plateNo.DisplayMemberPath = "Plate No";
            cmb_plateNo.SelectedValuePath = "Plate No";
            dt = model.viewPricing();
            cmb_modelID.ItemsSource = dt.DefaultView;
            cmb_modelID.DisplayMemberPath = "Model ID";
            cmb_modelID.SelectedValuePath = "Model ID";
            dt = insurance.viewInsurance();
            cmb_ins.ItemsSource = dt.DefaultView;
            cmb_ins.DisplayMemberPath = "insName";
            cmb_ins.SelectedValuePath = "insName";
            dt = owner.viewOwner();
            cmb_oNIC.ItemsSource = dt.DefaultView;
            cmb_oNIC.DisplayMemberPath = "NIC";
            cmb_oNIC.SelectedValuePath = "NIC";
        }

        private void cmb_plateNo_DropDownClosed(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = vehicle.viewVehicle(cmb_plateNo.Text);
            cmb_modelID.Text = dt.Rows[0][1].ToString();
            cmb_category.Text = dt.Rows[0][2].ToString();
            cmb_year.Text = dt.Rows[0][3].ToString();
            cmb_make.Text = dt.Rows[0][4].ToString();
            txt_model.Text = dt.Rows[0][5].ToString();
            cmb_color.Text = dt.Rows[0][6].ToString();
            cmb_trans.Text = dt.Rows[0][7].ToString();
            cmb_Ecapacity.Text = dt.Rows[0][8].ToString();
            cmb_Ftype.Text = dt.Rows[0][9].ToString();
            cmb_passengers.Text = dt.Rows[0][10].ToString();
            path = dt.Rows[0][12].ToString();
            date_LicStart.Text = dt.Rows[0][13].ToString();
            date_LicEnd.Text = dt.Rows[0][14].ToString();
            cmb_ins.Text = dt.Rows[0][16].ToString();
            date_InsStart.Text = dt.Rows[0][17].ToString();
            date_InsEnd.Text = dt.Rows[0][18].ToString();   
            cmb_oNIC.Text = dt.Rows[0][19].ToString();
            txt_oName.Text = dt.Rows[0][20].ToString();
            date_lend.Text = dt.Rows[0][21].ToString();
            txt_pay.Text = dt.Rows[0][22].ToString();
            txt_wName.Text = dt.Rows[0][23].ToString();
            txt_wAddress.Text = dt.Rows[0][24].ToString();
            txt_wContact.Text = dt.Rows[0][25].ToString();

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.UriSource = new Uri(path);
            image.EndInit();
            img_vehicle.Source = image;
            //12 photo 16 insurance
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            int i = vehicle.updateVehicle(cmb_plateNo.Text, cmb_category.Text, cmb_color.Text, "path", cmb_trans.Text, Int32.Parse(cmb_Ecapacity.Text), Int32.Parse(cmb_passengers.Text), date_LicStart.Text, date_LicEnd.Text, date_InsEnd.Text, date_InsStart.Text, cmb_Ftype.Text, date_lend.Text, Int32.Parse(txt_pay.Text), txt_wName.Text, txt_wAddress.Text, Int32.Parse(txt_wContact.Text), cmb_modelID.Text, "I002", cmb_oNIC.Text);
            if (i == 1)
            {
                MessageBox.Show("Data Update Successfully");
            }
            else
                MessageBox.Show("Error.Could not update data");
        }
    }
}
