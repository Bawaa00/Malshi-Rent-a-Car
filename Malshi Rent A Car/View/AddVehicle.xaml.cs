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
using System.Diagnostics;
using System.IO;
using System.Data;
using Microsoft.Win32;

namespace Malshi_Rent_A_Car
{
    /// <summary>
    /// Interaction logic for AddVehicle.xaml
    /// </summary>
    public partial class AddVehicle : Window
    {
        public AddVehicle()
        {
            InitializeComponent();
        }
        Vehicle vehicle = new Vehicle();
        ModelPricing model = new ModelPricing();
        Owner owner = new Owner();

        Database db = new Database();
        string filepath;

        private void btn_upload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            bool? result = open.ShowDialog();

            if (result == true)
            {
                filepath = open.FileName; // Stores Original Path in Textbox    
                ImageSource imgsource = new BitmapImage(new Uri(filepath)); // Just show The File In Image when we browse It
                img_vehicle.Source = imgsource;
            }
        }

        private void btn_cls_Click(object sender, RoutedEventArgs e)
        {
            cmb_modelID.SelectedIndex = -1;
            txt_catagory.Clear();
            txt_make.Clear();
            txt_model.Clear();
            txt_color.SelectedIndex = -1;
            txt_year.Clear();
            txt_Lplate.Clear();
            cmb_Ecapacity.SelectedIndex = -1;
            cmb_Ftype.SelectedIndex = -1;
            cmb_noPassengers.SelectedIndex = -1;
            cmb_ins.SelectedIndex = -1;
            /*date_InsuranceStart.SelectedDate;
            date_InsuranceEnd.SelectedDate;
            date_licenceStart.SelectedDate;
            date_LicenceEnd.SelectedDate;*/
            cmb_ownerNIC.SelectedIndex = -1;
            txt_oName.Clear();
            txt_wName.Clear();
            txt_wAdd.Clear();
            txt_wContact.Clear();
        }

        private void form_addVehicle_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = model.viewPricing();
            cmb_modelID.ItemsSource = dt.DefaultView;
            cmb_modelID.DisplayMemberPath = "Model ID";
            cmb_modelID.SelectedValuePath = "Model ID";
            dt = owner.viewOwner();
            cmb_ownerNIC.ItemsSource = dt.DefaultView;
            cmb_ownerNIC.DisplayMemberPath = "NIC";
            cmb_ownerNIC.SelectedValuePath = "NIC";
        }

        private void cmb_modelID_DropDownClosed(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = model.viewPricing(cmb_modelID.Text);
            txt_catagory.Text = dt.Rows[0][1].ToString();
            txt_make.Text = dt.Rows[0][3].ToString();
            txt_model.Text = dt.Rows[0][4].ToString();
            txt_year.Text = dt.Rows[0][2].ToString();
        }

        private void cmb_ownerNIC_DropDownClosed(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = owner.viewOwner(cmb_ownerNIC.Text);
            txt_oName.Text = dt.Rows[0][1].ToString();
        }
    }
}
