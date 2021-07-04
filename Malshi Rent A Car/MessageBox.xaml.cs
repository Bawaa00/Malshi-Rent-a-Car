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
    /// Interaction logic for MessageBox.xaml
    /// </summary>
    public partial class MessageBox : Window
    {
        public MessageBox()
        {
            InitializeComponent();
        }

        public void errorMsg(string msg)
        {
           // icon-error
            txt_msg.Text = msg;
        }

        public void warningMsg(string msg)
        {
           // icon-warning
            txt_msg.Text = msg;
        }

        public void confimationMsg(string msg)
        {
            btn_cancel.Visibility = Visibility.Visible;
           // icon-Report;
            txt_msg.Text = msg;
        }

        public void informationMsg(string msg)
        {
            //icon-InfoCircle;
            txt_msg.Text = msg;
        }

        internal static void Show(string v)
        {
            throw new NotImplementedException();
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        internal static void Show(string v1, string v2, MessageBoxButton oK, MessageBoxImage information)
        {
            throw new NotImplementedException();
        }
    }
}
