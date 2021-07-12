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
using System.Text.RegularExpressions;

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
        string insID;
        string path;

        private void frm_updateVehicle_Loaded(object sender, RoutedEventArgs e)
        {
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
            if (cmb_plateNo.SelectedItem == null)
            {
                error_msg.Text = "Please Select Vehicle Number";
            }
            else
            { dt = vehicle.viewVehicle(cmb_plateNo.Text);
                cmb_modelID.Text = dt.Rows[0][1].ToString();
                cmb_category.Text = dt.Rows[0][2].ToString();
                txt_year.Text = dt.Rows[0][3].ToString();
                txt_make.Text = dt.Rows[0][4].ToString();
                txt_model.Text = dt.Rows[0][5].ToString();
                cmb_color.Text = dt.Rows[0][6].ToString();
                cmb_trans.Text = dt.Rows[0][7].ToString();
                cmb_Ecapacity.Text = dt.Rows[0][8].ToString();
                cmb_Ftype.Text = dt.Rows[0][9].ToString();
                cmb_passengers.Text = dt.Rows[0][10].ToString();
                //insID = dt.Rows[0][].ToString();

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
                cmb_ins_DropDownClosed(this, null);

                if (path != "")
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.UriSource = new Uri(path);
                    image.EndInit();
                    img_vehicle.Source = image;
                }
                else
                {
                    img_vehicle.Source = null;
                }
            }
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            int i = vehicle.deleteVehicle(cmb_plateNo.Text);
            if (i == 1)
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Data deleted successfully!");
                msg.Show();
                frm_updateVehicle_Loaded(this, null);
            }
            else
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Could not delete data,Please try agian");
                msg.Show();
            }
        }

        private void cmb_ins_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_ins.SelectedItem == null)
            {
                error_msg.Text = "Please Select Company";
            }
            else
            {
                dt = insurance.viewInsurance(cmb_ins.Text);
                insID = dt.Rows[0][0].ToString();
            }
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            if (error_msg.Text!="")
            {
                try
                {
                    string name = System.IO.Path.GetFileName(path);
                    string destinationPath = GetDestinationPath(name);
                    File.Copy(path, destinationPath, true);
                    Vehicle vehicle = new Vehicle(cmb_plateNo.Text, cmb_category.Text, cmb_color.Text, destinationPath, cmb_trans.Text, Int32.Parse(cmb_Ecapacity.Text), Int32.Parse(cmb_passengers.Text), date_LicStart.Text, date_LicEnd.Text, date_InsEnd.Text, date_InsStart.Text, cmb_Ftype.Text, date_lend.Text, Int32.Parse(txt_pay.Text), txt_wName.Text, txt_wAddress.Text, Int32.Parse(txt_wContact.Text));
                    int i = vehicle.updateVehicle(cmb_modelID.Text, insID, cmb_oNIC.Text);
                    if (i == 1)
                    {
                        MessageBox msg = new MessageBox();
                        msg.errorMsg("Data updated successfully!");
                        msg.Show();
                    }
                    else
                    {
                        MessageBox msg = new MessageBox();
                        msg.errorMsg("Could not save data,Please try agian");
                        msg.Show();
                    }
                }
                catch (ArgumentNullException)
                {
                    MessageBox msg = new MessageBox();
                    msg.errorMsg("Please upload a photo");
                    msg.Show();
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
 
        }

        private void cmb_modelID_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_modelID.SelectedItem == null)
            {
                error_msg.Text = "Please Select Model";
            }
            else {
                dt = model.viewPricing(cmb_modelID.Text);
                //modelID = dt.Rows[0][0].ToString();
                cmb_category.Text = dt.Rows[0][1].ToString();
                txt_make.Text = dt.Rows[0][3].ToString();
                txt_model.Text = dt.Rows[0][4].ToString();
                txt_year.Text = dt.Rows[0][2].ToString();
            }
        }

        private void cmb_oNIC_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_oNIC.SelectedItem == null)
            {
                error_msg.Text = "Please Select Owner NIC";
            }
            else
            {
                dt = owner.viewOwner(cmb_oNIC.Text);
                txt_oName.Text = dt.Rows[0][1].ToString();
            }
        }

        private String GetDestinationPath(string filename)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string dir = appStartPath + "\\" + cmb_plateNo.Text;
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            appStartPath = String.Format(dir + "\\" + cmb_plateNo.Text + ".jpg");
            return appStartPath;
        }

        private void btn_upload_Click(object sender, RoutedEventArgs e)
        {
            try { 
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            bool? result = open.ShowDialog();

            if (result == true)
            {
                path = open.FileName; // Stores Original Path in Textbox    
                ImageSource imgsource = new BitmapImage(new Uri(path)); // Just show The File In Image when we browse It
                img_vehicle.Source = imgsource;
            }
            }
            catch (Exception ex)
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Oops soomething went worng. " + ex.Message);
                msg.Show();
            }
        }

        private void cmb_category_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_category.SelectedItem == null)
            {
                error_msg.Text = "Please Select Category";
            }
            else { error_msg.Text = ""; }
        }

        private void cmb_color_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_color.SelectedItem == null)
            {
                error_msg.Text = "Please Select Color";
            }
            else { error_msg.Text = ""; }
        }

        private void cmb_Ecapacity_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_Ecapacity.SelectedItem == null)
            {
                error_msg.Text = "Please Select Engin Capacity";
            }
            else { error_msg.Text = ""; }
        }

        private void cmb_trans_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_trans.SelectedItem == null)
            {
                error_msg.Text = "Please Select Transmission";
            }
            else { error_msg.Text = ""; }
        }

        private void cmb_Ftype_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_Ftype.SelectedItem == null)
            {
                error_msg.Text = "Please Select Fuel Type";
            }
            else { error_msg.Text = ""; }
        }

        private void cmb_passengers_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_passengers.SelectedItem == null)
            {
                error_msg.Text = "Please Select Number of Passengers";
            }
            else { error_msg.Text = ""; }
        }

        private void txt_wName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_wName.Text.Length == 0)
                error_msg.Text = "Please Enter Witness Name";
            else if (txt_wName.Text.Any(char.IsDigit))
                error_msg.Text = "Witness Name cannot have Numbers";
            else
                error_msg.Text = "";
        }

        private void txt_wAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_wAddress.Text.Length == 0)
                error_msg.Text = "Please Enter Witness Address";
            else
                error_msg.Text = "";
        }

        private void txt_wContact_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_wContact.Text.Length == 0)
                error_msg.Text = "Please Enter Witness Contact Number ";
            else if (!Regex.IsMatch(txt_wContact.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))

                error_msg.Text = "Contact No not Valid";
            else
                error_msg.Text = "";
        }

        private void txt_pay_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_pay.Text.Length == 0)
                error_msg.Text = "Please Enter Cost per month ";
            else if (!Regex.IsMatch(txt_pay.Text, "^[0-9]*$"))
                error_msg.Text = "Please enter numbers only";
            else
                error_msg.Text = "";
        }

        private void date_InsStart_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (date_InsEnd.Text != "")
            {
                DateTime startdate = Convert.ToDateTime(date_InsStart.Text);
                DateTime exdate = Convert.ToDateTime(date_InsEnd.Text);
                if (startdate <= exdate)
                {
                    TimeSpan ts = exdate.Subtract(startdate);
                    int days = Convert.ToInt16(ts.Days);
                    error_msg.Text = "";
                }
                else
                {
                    error_msg.Text = "Invalid Insurance date.Please check again";
                }
            }
        }

        private void date_InsEnd_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (date_InsStart.Text != "")
            {
                DateTime startdate = Convert.ToDateTime(date_InsStart.Text);
                DateTime exdate = Convert.ToDateTime(date_InsEnd.Text);
                if (startdate <= exdate)
                {
                    TimeSpan ts = exdate.Subtract(startdate);
                    int days = Convert.ToInt16(ts.Days);
                    error_msg.Text = "";
                }
                else
                {
                    error_msg.Text = "Invalid Insurance date.Please check again";
                }
            }
        }

        private void date_LicStart_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (date_LicEnd.Text != "")
            {
                DateTime startdate = Convert.ToDateTime(date_LicStart.Text);
                DateTime exdate = Convert.ToDateTime(date_LicEnd.Text);
                if (startdate <= exdate)
                {
                    TimeSpan ts = exdate.Subtract(startdate);
                    int days = Convert.ToInt16(ts.Days);
                    error_msg.Text = "";
                }
                else
                {
                    error_msg.Text = "Invalid License date.Please check again";
                }
            }
        }

        private void date_LicEnd_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (date_LicStart.Text != "")
            {
                DateTime startdate = Convert.ToDateTime(date_LicStart.Text);
                DateTime exdate = Convert.ToDateTime(date_LicEnd.Text);
                if (startdate <= exdate)
                {
                    TimeSpan ts = exdate.Subtract(startdate);
                    int days = Convert.ToInt16(ts.Days);
                    error_msg.Text = "";
                }
                else
                {
                    error_msg.Text = "Invalid License date.Please check again";
                }
            }
        }
    }
}
