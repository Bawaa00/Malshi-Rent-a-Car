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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Malshi_Rent_A_Car
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_log_Click(object sender, RoutedEventArgs e)
        {
            HashCode hc = new HashCode();
            User user = new User(txt_uname.Text, hc.PassHash(txt_pass.Password));
            int i = user.authorizeAccount();
            if (i == 1)
            {
                string type = user.getUserType();
                Dashboard dash = new Dashboard(type,txt_uname.Text);
               // Dashboard dash = new Dashboard();
                this.Close();
                dash.Show();
            }
            else
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Sorry,Invalid username or password");
                msg.Show();
            }                
        }

        private void lbl_forgot_MouseDown(object sender, MouseButtonEventArgs e)
        {
            View.ResetPassword obj = new View.ResetPassword();
            obj.Show();
            this.Close();
        }
    }
}
