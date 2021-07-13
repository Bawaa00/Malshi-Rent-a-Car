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
    /// Interaction logic for UpdateCustomer.xaml
    /// </summary>
    public partial class UpdateCustomer : Window
    {
        public UpdateCustomer()
        {
            InitializeComponent();
        }
        Database db = new Database();
        DataTable dt = new DataTable();
        Customer customer = new Customer();
        string path;

        private String GetDestinationPath(string filename)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string dir = appStartPath + "\\" + cmb_nic.Text;
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            appStartPath = String.Format(dir + "\\" + cmb_nic.Text + ".jpg");
            return appStartPath;
        }

        private void cmb_nic_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_nic.SelectedItem == null)
            {
                error_msg.Text = "Please Select NIC";
            }

            else
            { dt = customer.viewCustomerNIC(cmb_nic.Text);

                // cmb_nic.Text = dt.Rows[0][0].ToString();
                txt_firstname.Text = dt.Rows[0][1].ToString();
                txt_lname.Text = dt.Rows[0][2].ToString();
                txt_CusResAdrs.Text = dt.Rows[0][3].ToString();
                txt_CusWorkAdrs.Text = dt.Rows[0][8].ToString();
                txt_CusTelHome.Text = dt.Rows[0][5].ToString();
                txt_CusTelMobile.Text = dt.Rows[0][4].ToString();
                txt_CusTelWork.Text = dt.Rows[0][9].ToString();
                txt_CusEmail.Text = dt.Rows[0][6].ToString();
                txt_CusProfession.Text = dt.Rows[0][7].ToString();
                path = dt.Rows[0][10].ToString();
                txt_CusKinName.Text = dt.Rows[0][11].ToString();
                txt_CusKinkAdrs.Text = dt.Rows[0][12].ToString();
                txt_CusKinConatct.Text = dt.Rows[0][13].ToString();

                if (path != "")
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.UriSource = new Uri(path);
                    image.EndInit();
                    img_customer.Source = image;
                }
                else
                {
                    img_customer.Source = null;
                }
            }

        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = System.IO.Path.GetFileName(path);
                string destinationPath = GetDestinationPath(name);
                File.Copy(path, destinationPath, true);
                Customer upCustomer = new Customer(txt_firstname.Text, txt_lname.Text, cmb_nic.Text, txt_CusEmail.Text, txt_CusResAdrs.Text, Int32.Parse(txt_CusTelHome.Text), Int32.Parse(txt_CusTelMobile.Text), txt_CusProfession.Text, txt_CusWorkAdrs.Text, Int32.Parse(txt_CusTelWork.Text), txt_CusKinName.Text, txt_CusKinkAdrs.Text, Int32.Parse(txt_CusKinConatct.Text), destinationPath); ;
                int i = upCustomer.updateCustomer();
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

        private void bttn_delete_Click(object sender, RoutedEventArgs e)
        {
            int line = customer.deleteCustomer(cmb_nic.Text);
            if (line == 1)
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Data deleted successfully");
                msg.Show();
                cmb_nic.SelectedIndex = -1;
                txt_firstname.Clear();
                txt_lname.Clear();
                txt_CusEmail.Clear();
                txt_CusResAdrs.Clear();
                txt_CusTelHome.Clear();
                txt_CusTelMobile.Clear();
                txt_CusProfession.Clear();
                txt_CusWorkAdrs.Clear();
                txt_CusTelWork.Clear();
                txt_CusKinName.Clear();
                txt_CusKinkAdrs.Clear();
                txt_CusKinConatct.Clear();
            }

            else
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Could not save data,Please try agian");
                msg.Show();
            }

        }

        private void btn_upload_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Multiselect = false;
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                bool? result = open.ShowDialog();

                if (result == true)
                {
                    path = open.FileName; // Stores Original Path in Textbox    
                    ImageSource imgsource = new BitmapImage(new Uri(path)); // Just show The File In Image when we browse It
                    img_customer.Source = imgsource;
                }
            }
            catch (Exception ex)
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Oops soomething went worng. " + ex.Message);
                msg.Show();
            }
        }

        private void customer_update_Loaded_1(object sender, RoutedEventArgs e)
        {
            dt = customer.viewCustomer();
            cmb_nic.ItemsSource = dt.DefaultView;
            cmb_nic.DisplayMemberPath = "NIC";
            cmb_nic.SelectedValuePath = "NIC";
        }

        private void txt_firstname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_firstname.Text.Length == 0)
                error_msg.Text = "Please Enter Customer First Name  ";
            else if (txt_firstname.Text.Any(char.IsDigit))
                error_msg.Text = "First Name cannot have Numbers";
            else
                error_msg.Text = "";
        }

        private void txt_lname_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (txt_lname.Text.Length == 0)
                error_msg.Text = "Please Enter Custoer last Name  ";
            else if (txt_lname.Text.Any(char.IsDigit))
                error_msg.Text = "Last Name cannot have Numbers";
            else
                error_msg.Text = "";
        }

        private void txt_CusEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_CusEmail.Text.Length == 0)
                error_msg.Text = "Please Enter Custoer Email  ";
            else if (!IsValid(txt_CusEmail.Text))
                error_msg.Text = "Please enter a valid email address ";
            else
                error_msg.Text = "";
        }

        private void txt_CusResAdrs_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_CusResAdrs.Text.Length == 0)
                error_msg.Text = "Please Enter Custoer Home Addrss  ";
            else
                error_msg.Text = "";
        }

        private void txt_CusTelHome_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_CusTelHome.Text.Length == 0)
                error_msg.Text = "Please Enter Customer  Home Telephone ";
            else if (!Regex.IsMatch(txt_CusTelHome.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
                error_msg.Text = "Contact No not Valid";
            else
                error_msg.Text = "";
        }

        private void txt_CusTelMobile_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_CusTelMobile.Text.Length == 0)
                error_msg.Text = "Please Enter Customer Mobile Number ";
            else if (!Regex.IsMatch(txt_CusTelMobile.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))

                error_msg.Text = "Contact No not Valid";
            else
                error_msg.Text = "";

        }

        private void txt_CusProfession_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_CusProfession.Text.Length == 0)
                error_msg.Text = "Please Enter Custoer Profession  ";
            else
                error_msg.Text = "";
        }

        private void txt_CusWorkAdrs_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_CusWorkAdrs.Text.Length == 0)
                error_msg.Text = "Please Enter Custoer Work Address  ";
            else
                error_msg.Text = "";
        }

        private void txt_CusTelWork_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_CusTelWork.Text.Length == 0)
                error_msg.Text = "Please Enter Customer Work Telephone Number ";
            else if (!Regex.IsMatch(txt_CusTelWork.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
                error_msg.Text = "Contact No not Valid";
            else
                error_msg.Text = "";
        }

        private void txt_CusKinName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_CusKinName.Text.Length == 0)
                error_msg.Text = "Please Enter Custoer Kin Name ";
            else if (txt_CusKinName.Text.Any(char.IsDigit))
                error_msg.Text = "Last Name cannot have Numbers";
            else
                error_msg.Text = "";
        }

        private void txt_CusKinkAdrs_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_CusKinkAdrs.Text.Length == 0)
                error_msg.Text = "Please Enter Custoer Kin Address ";
            else
                error_msg.Text = "";
        }

        private void txt_CusKinConatct_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_CusKinConatct.Text.Length == 0)
                error_msg.Text = "Please Enter Customer Kin Contact Number ";
            else if (!Regex.IsMatch(txt_CusKinConatct.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))

                error_msg.Text = "Contact No not Valid";
            else
                error_msg.Text = "";
        }

        public bool IsValid(string emailaddress)
        {
            try
            {
                System.Net.Mail.MailAddress m = new System.Net.Mail.MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
