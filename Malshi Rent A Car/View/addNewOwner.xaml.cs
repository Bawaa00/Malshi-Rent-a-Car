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
    /// Interaction logic for addNewOwner.xaml
    /// </summary>
    public partial class addNewOwner : Window
    {
        public addNewOwner()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            Owner owner = new Owner(txt_OwnFname.Text, txt_OwnLname.Text, txt_OwnNIC.Text, txt_OwnResAdrs.Text, txt_OwnWorkAdrs.Text, txt_OwnEmail.Text, Int32.Parse(txt_OwnTelMobile.Text), Int32.Parse(txt_OwnTelHome.Text),Int32.Parse(txt_OwnTelWork.Text), txt_OwnProfession.Text);
            int i = owner.addOwner();
            if (i==1)
            {
                MessageBox.Show("Data Saved Successfully!");
                btn_cls_Click(this, null);
            }
            else
            {
                MessageBox.Show("Couldnt Save data.Please Try Again");
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
        }
    }
}
