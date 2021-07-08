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
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;


namespace Malshi_Rent_A_Car
{
    /// <summary>
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Window
    {
        public AddCustomer()
        {
            InitializeComponent();
        }
        string path;

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            string name = System.IO.Path.GetFileName(path);
            string destinationPath = GetDestinationPath(name);
            File.Copy(path, destinationPath, true);
            Customer customer = new Customer(txt_CusFname.Text,txt_CusLname.Text,txt_CusNIC.Text,txt_CusEmail.Text,txt_CusResAdrs.Text,Int32.Parse(txt_CusTelHome.Text),Int32.Parse(txt_CusTelMobile.Text),txt_CusProfession.Text,txt_CusWorkAdrs.Text,Int32.Parse(txt_CusTelWork.Text),txt_CusKinName.Text,txt_CusKinkAdrs.Text,Int32.Parse(txt_CusKinConatct.Text),destinationPath);
            int i = customer.addCustomer();
                if (i == 1)
                {
                    MessageBox msg = new MessageBox();
                    msg.errorMsg("Data Saved Successfully");
                    msg.Show();
                    btn_clear_Click(this, null);
                }
                else
                {
                    MessageBox msg = new MessageBox();
                    msg.errorMsg("Sorry, couldn't save your data.Please try again");
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

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            txt_CusFname.Clear();
            txt_CusLname.Clear();
            txt_CusNIC.Clear();
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
            img_customer.Source = null;
        }

        private String GetDestinationPath(string filename)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string dir = appStartPath + "\\" + txt_CusNIC.Text;
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            appStartPath = String.Format(dir + "\\" + txt_CusNIC.Text + ".jpg");
            return appStartPath;
        }

        private void btn_upload_Click(object sender, RoutedEventArgs e)
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

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txt_CusFname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_CusFname.Text.Length == 0)
                error_msg.Text = "Please Enter Customer First Name  ";
            else
                error_msg.Text = "";
        }

        private void txt_CusLname_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (txt_CusLname.Text.Length == 0)
                error_msg.Text = "Please Enter Custoer last Name  ";
            else
                error_msg.Text = "";
        }

        private void txt_CusNIC_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_CusNIC.Text.Length == 0)
                error_msg.Text = "Please Enter Custoer NIC  ";
            else
                error_msg.Text = "";
        }

        private void txt_CusEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_CusEmail.Text.Length == 0)
                error_msg.Text = "Please Enter Custoer Email  ";
            else
                error_msg.Text = "";
        }

        
        private void txt_CusResAdrs_TextChanged_1(object sender, TextChangedEventArgs e)
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
    }
}
