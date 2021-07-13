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
using System.Net.Mail;

namespace Malshi_Rent_A_Car
{
    /// <summary>
    /// Interaction logic for AddAccount.xaml
    /// </summary>
    public partial class AddAccount : Window
    {
        
        public AddAccount()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        Database db = new Database();
        User user = new User();

        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
            if(txt_uname.Text !="" && txt_retype.Password != "")
            {
                try
                {
                    MessageBox msg = new MessageBox();
                    HashCode hc = new HashCode();
                    User user = new User(cmb_utype.Text, txt_uname.Text, hc.PassHash(txt_pass.Password), txt_email.Text);
                    int i = user.addAccount();
                    if (i == 1)
                    {
                        msg.informationMsg("Account Successfully Registered!");
                        msg.Show();
                        fom_addAccount_Loaded(this, null);
                    }
                    else
                    {
                        msg.errorMsg("Sorry, couldn't create Account.Please try again");
                        msg.Show();
                    }
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    MessageBox msg = new MessageBox();
                    msg.errorMsg("Please fill the form correctly. ");
                    msg.Show();
                }
                catch (System.FormatException)
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
            else
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Please fill the Form Properly");
                msg.Show();
            }
           
        }

        private void txt_uname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_uname.Text.Length == 0)
                error_msg.Text = "Please Enter a UserName  ";
            else if (txt_uname.Text.Length <= 5)
                error_msg.Text = "Username to short ";
            else
            {
                dt = user.checkUser(txt_uname.Text);
                if (dt.Rows.Count == 1)
                {
                    error_msg.Text = "Sorry Username already taken";
                    txt_uname.Focus();
                }
                else
                {
                    error_msg.Text = "Valid Username";
                }
            }
          
        }

        private void txt_pass_KeyUp(object sender, KeyEventArgs e)
        {
            if (!Regex.IsMatch(txt_pass.Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$"))
                error_msg.Text = "Invalid Password";
            else
                error_msg.Text = "Valid Password";

        }

        private void cmb_utype_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_utype.SelectedItem == null)
                error_msg.Text = "Please Select Use Type";
            else { error_msg.Text = ""; }
        }

        private void txt_retype_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_pass.Password != txt_retype.Password)
                error_msg.Text = "Passwords do not match";
            else if (txt_pass.Password == txt_retype.Password)
                error_msg.Text = "Passwords Match";
        }

        private void fom_addAccount_Loaded(object sender, RoutedEventArgs e)
        {
            cmb_utype.SelectedIndex = -1;
            txt_uname.Clear();
            txt_pass.Clear();
            txt_retype.Clear();
            txt_email.Clear();
        }

        private void txt_email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_email.Text.Length == 0)
                error_msg.Text = "Please enter a email address  ";
            else if(!IsValid(txt_email.Text))
                error_msg.Text = "Please enter a valid email address ";
            else
                error_msg.Text = "";
        }

        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
