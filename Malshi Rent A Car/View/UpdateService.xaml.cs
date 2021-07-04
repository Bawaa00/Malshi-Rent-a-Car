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
    /// Interaction logic for UpdateService.xaml
    /// </summary>
    public partial class UpdateService : Window
    {
        public UpdateService()
        {
            InitializeComponent();
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Service Service = new Service(txt_vehicleID.Text, txt_sID.Text,txt_sDetails.Text, txt_SLocation.Text, txt_sDate.Text, Convert.ToDouble(txt_milage.Text), Convert.ToDouble(txt_nxtMilage.Text), Convert.ToDouble(txt_sCost.Text));
            int i = Service.upDateService();
            if (i == 1)
            {
                MessageBox.Show("Data Saved Successfully!");
                Clear_Click(this, null);
            }
            else
            {
                MessageBox.Show("Couldnt Save data.Please Try Again");
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txt_vehicleID.Text = "";
            txt_sID.Clear();
            txt_sDetails.Clear();
            txt_SLocation.Clear();
            txt_sDate.Text = "";
            txt_milage.Clear();
            txt_nxtMilage.Clear();
            txt_sCost.Clear();

        }
    }
}
