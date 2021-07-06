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

namespace Malshi_Rent_A_Car.View
{
    /// <summary>
    /// Interaction logic for manageAccount.xaml
    /// </summary>
    public partial class manageAccount : Window
    {
        public manageAccount()
        {
            InitializeComponent();
            txt_uName.IsEnabled = true;
        }
        public manageAccount(string uname)
        {
            InitializeComponent();
            txt_uName.Text = uname;
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            HashCode hc = new HashCode();
            User user = new User(txt_uName.Text);
            int i = user.updatePassword(hc.PassHash(txt_pass.Password));
            if (i ==1)
            {
                MessageBox msg = new MessageBox();
                msg.informationMsg("Password Reseted Successfully!");
                this.Close();                 
                MainWindow login = new MainWindow();
                login.Show();
                msg.Show();
            }
            else
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Error.Please try again");
                msg.Show();
            }
        }
    }
}
