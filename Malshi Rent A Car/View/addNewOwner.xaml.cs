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
    /// Interaction logic for addNewOwner.xaml
    /// </summary>
    public partial class addNewOwner : Window
    {
        public addNewOwner()
        {
            InitializeComponent();
        }
        string filepath;


        private String GetDestinationPath(string filename)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string dir = appStartPath + "\\" + txt_OwnNIC.Text;
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            appStartPath = String.Format(dir + "\\" + txt_OwnNIC.Text + ".jpg");
            return appStartPath;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = System.IO.Path.GetFileName(filepath);
                string destinationPath = GetDestinationPath(name);
                File.Copy(filepath, destinationPath, true);
                Owner owner = new Owner(txt_OwnFname.Text, txt_OwnLname.Text, txt_OwnNIC.Text, txt_OwnResAdrs.Text, txt_OwnWorkAdrs.Text, txt_OwnEmail.Text, Int32.Parse(txt_OwnTelMobile.Text), Int32.Parse(txt_OwnTelHome.Text), Int32.Parse(txt_OwnTelWork.Text), txt_OwnProfession.Text,destinationPath);
                int i = owner.addOwner();
                if (i == 1)
                {
                    MessageBox msg = new MessageBox();
                    msg.errorMsg("Data Saved Successfully");
                    msg.Show();
                    btn_cls_Click(this, null);
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

        private void btn_cls_Click(object sender, RoutedEventArgs e)
        {
            txt_OwnFname.Clear();
            txt_OwnLname.Clear();
            txt_OwnNIC.Clear();
            txt_OwnEmail.Clear();
            txt_OwnResAdrs.Clear();
            txt_OwnTelHome.Clear();
            txt_OwnTelMobile.Clear();
            txt_OwnProfession.Clear();
            txt_OwnWorkAdrs.Clear();
            txt_OwnTelWork.Clear();
            img_owner.Source = null;
        }

        private void txt_OwnFname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnFname.Text.Length == 0)
                error_msg.Text = "Please Enter Owner First Name  ";
            else if (txt_OwnFname.Text.Any(char.IsDigit))
                error_msg.Text = "First Name cannot have Numbers";
            else
                error_msg.Text = "";
        }

        private void txt_OwnLname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnLname.Text.Length == 0)
                error_msg.Text = "Please Enter Owner Last Name  ";
            else if (txt_OwnLname.Text.Any(char.IsDigit))
                error_msg.Text = "Last Name cannot contain Numbers";
            error_msg.Text = "";
        }

        private void txt_OwnNIC_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnNIC.Text.Length == 0)
                error_msg.Text = "Please Enter Owner NIC ";
            else if (txt_OwnNIC.Text.Length < 10 || txt_OwnNIC.Text.Length > 12)
                error_msg.Text = "Invalid NIC  ";
            else
                error_msg.Text = "";
        }

        private void txt_OwnEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (txt_OwnEmail.Text.Length == 0)
                error_msg.Text = "Please Enter Owner Email";
            else if (!IsValid(txt_OwnEmail.Text))
                error_msg.Text = "Please enter a valid email address ";
            else
                error_msg.Text = "";
        }

        private void txt_OwnResAdrs_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnResAdrs.Text.Length == 0)
                error_msg.Text = "Please Enter Owner Home Address";
            else
                error_msg.Text = "";
        }

        private void txt_OwnTelHome_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (txt_OwnTelHome.Text.Length == 0)
                error_msg.Text = "Please Enter Owner Home Number ";
            else if (!Regex.IsMatch(txt_OwnTelHome.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
                error_msg.Text = "Contact No not Valid";
            else
                error_msg.Text = "";
        }

        private void txt_OwnTelMobile_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (txt_OwnTelMobile.Text.Length == 0)
                error_msg.Text = "Please Enter Owner Mobile Number ";
            else if (!Regex.IsMatch(txt_OwnTelMobile.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))

                error_msg.Text = "Contact No not Valid";
            else
                error_msg.Text = "";

        }

        private void txt_OwnProfession_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnProfession.Text.Length == 0)
                error_msg.Text = "Please Enter Owner Profession";
            else
                error_msg.Text = "";
        }

        private void txt_OwnWorkAdrs_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnWorkAdrs.Text.Length == 0)
                error_msg.Text = "Please Enter Owner Work Address";
            else
                error_msg.Text = "";
        }

        private void txt_OwnTelWork_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnTelWork.Text.Length == 0)
                error_msg.Text = "Please Enter Owner Work Number ";
            else if (!Regex.IsMatch(txt_OwnTelWork.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))

                error_msg.Text = "Contact No not Valid";
            else
                error_msg.Text = "";
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
                    filepath = open.FileName; // Stores Original Path in Textbox    
                    ImageSource imgsource = new BitmapImage(new Uri(filepath)); // Just show The File In Image when we browse It
                    img_owner.Source = imgsource;
                }
            }
            catch (Exception ex)
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Oops soomething went worng. " + ex.Message);
                msg.Show();
            }
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
