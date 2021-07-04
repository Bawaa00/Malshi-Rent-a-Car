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

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Customer customer = new Customer(txt_CusFname.Text, txt_CusLname.Text, txt_CusNIC.Text, txt_CusEmail.Text, txt_CusResAdrs.Text, Int32.Parse(txt_CusTelHome.Text), Int32.Parse(txt_CusTelMobile.Text), txt_CusProfession.Text, txt_CusWorkAdrs.Text, Int32.Parse(txt_CusTelWork.Text), txt_CusKinName.Text, txt_CusKinkAdrs.Text, Int32.Parse(txt_CusKinConatct.Text));


                int i = customer.addCustomer();
                if (i == 1)
                {
                    MessageBox msg = new MessageBox();
                    msg.Show();
                   
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
                error_msg.Text = "Please Enter Customer Kin Contact Number ";
            else if (!Regex.IsMatch(txt_CusTelHome.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))

                error_msg.Text = "Contact No not Valid";
            else
                error_msg.Text = "";
        }

        private void txt_CusTelMobile_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_CusTelMobile.Text.Length == 0)
                error_msg.Text = "Please Enter Customer Kin Contact Number ";
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
                error_msg.Text = "Please Enter Customer Kin Contact Number ";
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
