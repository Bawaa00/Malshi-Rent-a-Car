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
    /// Interaction logic for AddAccount.xaml
    /// </summary>
    public partial class AddAccount : Window
    {
        
        public AddAccount()
        {
            InitializeComponent();
        }

        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
            MessageBox msg = new MessageBox();
           HashCode hc = new HashCode();
            User user = new User(cmb_utype.Text, txt_uname.Text, hc.PassHash(txt_pass.Password), cmb_que.Text, txt_answer.Text);
            int i = user.addAccount();
            if (i == 1)
            {
                msg.informationMsg("Account Successfully Registered!");
                msg.Show();
            }
            else
            {
                msg.errorMsg("Sorry, couldn't save your data.Please try again");
                msg.Show();
            }
        }

        private void txt_uname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_uname.Text.Length == 0)
                error_msg.Text = "Please Enter Use Name  ";
            else
                error_msg.Text = "";
        }

        private void txt_answer_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_answer.Text.Length == 0)
                error_msg.Text = "Please Enter Answer  ";
            else
                error_msg.Text = "";
        }

        private void txt_pass_KeyUp(object sender, KeyEventArgs e)
        {

            
        }
    }
}
