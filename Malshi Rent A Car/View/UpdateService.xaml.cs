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
using System.Data;

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
        Vehicle vehicle = new Vehicle();
        Service service = new Service();
        DataTable dt = new DataTable();

        private void form_updateService_Loaded(object sender, RoutedEventArgs e)
        {
            dt = vehicle.viewVehicle();
            cmb_vehicleID.ItemsSource = dt.DefaultView;
            cmb_vehicleID.DisplayMemberPath = "Plate No";
            cmb_vehicleID.SelectedValuePath = "Plate No";

            dt = service.viewService();
            cmb_sID.ItemsSource = dt.DefaultView;
            cmb_sID.DisplayMemberPath = "Service ID";
            cmb_sID.SelectedValuePath = "Service ID";

            txt_SLocation.Clear();
            txt_milage.Clear();
            date_service.SelectedDate = null;
            txt_nxtMilage.Clear();
            txt_sCost.Clear();
            txt_sDetails.Clear();
        }

        private void cmb_sID_DropDownClosed(object sender, EventArgs e)
        {
            dt = service.viewServiceID(cmb_sID.Text);
            cmb_vehicleID.Text = dt.Rows[0][0].ToString();
            txt_sDetails.Text = dt.Rows[0][2].ToString();
            txt_SLocation.Text = dt.Rows[0][3].ToString();
            date_service.Text = dt.Rows[0][4].ToString();
            txt_milage.Text = dt.Rows[0][5].ToString();
            txt_nxtMilage.Text = dt.Rows[0][6].ToString();
            txt_sCost.Text = dt.Rows[0][7].ToString();
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            Service upService = new Service(cmb_sID.Text, txt_sDetails.Text, txt_SLocation.Text, date_service.Text, Int32.Parse(txt_milage.Text), Int32.Parse(txt_nxtMilage.Text), Int32.Parse(txt_sCost.Text));
            int i = upService.updateService(cmb_vehicleID.Text);
            if (i ==1 )
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

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            int i = service.deleteService(cmb_sID.Text);
            if (i == 1)
            {
                MessageBox msg = new MessageBox();
                msg.Show();
            }
            else
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Sorry, couldn't delete your data.Please try again");
                msg.Show();
                form_updateService_Loaded(this, null);
            }
        }

        private void txt_milage_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_milage.Text != "")
            {
                int next = Int32.Parse(txt_milage.Text);
                txt_nxtMilage.Text = (next + 2500).ToString();
            }
        }
    }
}
