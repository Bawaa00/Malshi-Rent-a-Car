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
            HashCode hc = new HashCode();
            User user = new User(cmb_utype.Text, txt_uname.Text, hc.PassHash(txt_pass.Password), cmb_que.Text, txt_answer.Text);
            int i = user.addAccount();
            if (i == 1)
                MessageBox.Show("Account Created");
            else
                MessageBox.Show("Account Could Not Be Created");
        }
    }
}
