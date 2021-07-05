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
using System.Text.RegularExpressions;

namespace Malshi_Rent_A_Car
{
    /// <summary>
    /// Interaction logic for Add_Service.xaml
    /// </summary>
    public partial class Add_Service : Window
    {
        public Add_Service()
        {
            InitializeComponent();
        }
        Service service = new Service();
        Vehicle vehicle = new Vehicle();
        Database db = new Database();
        DataTable dt = new DataTable();

        private void form_addService_Loaded(object sender, RoutedEventArgs e)
        {
            dt = vehicle.viewVehicle();
            cmb_vid.ItemsSource = dt.DefaultView;
            cmb_vid.DisplayMemberPath = "Plate No";
            cmb_vid.SelectedValuePath = "Plate No";
            dt = db.getData("Select max(sID) from Service");
            string id = dt.Rows[0][0].ToString();
            if (id == "")
            {
                txt_sid.Text = "S001";
            }
            else
            {
                var prefix = Regex.Match(id, "^\\D+").Value;
                var number = Regex.Replace(id, "^\\D+", "");
                var i = int.Parse(number) + 1;
                var newString = prefix + i.ToString(new string('0', number.Length));
                txt_sid.Text = newString;
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            Service Service = new Service(txt_sid.Text, txt_details.Text, txt_sLocation.Text, dte_service.Text, Convert.ToDouble(txt_mileage.Text), Convert.ToDouble(txt_nxtMileage.Text), Convert.ToDouble(txt_sCost.Text));
            int i = Service.addService(cmb_vid.Text);
            if (i == 1)
            {
                Console.WriteLine("Ela");
                MessageBox msg = new MessageBox();
                msg.Show();
                //MessageBox.Show("Data Saved Successfully!");
            }
            else
            {
                Console.WriteLine("Chora");
                //MessageBox.Show("Couldnt Save data.Please Try Again");
            }
        }

        private void btn_cls_Click(object sender, RoutedEventArgs e)
        {
            cmb_vid.SelectedIndex = -1;
            txt_sid.Clear();
            txt_details.Clear();
            txt_sLocation.Clear();
            dte_service.SelectedDate = null;
            txt_mileage.Clear();
            txt_mileage.Clear();
            txt_sCost.Clear();
        }

        private void txt_mileage_KeyUp(object sender, KeyEventArgs e)
        {
            if(txt_mileage.Text != "")
            {
                int next = Int32.Parse(txt_mileage.Text);
                txt_nxtMileage.Text = (next + 2500).ToString();
            }
            
        }
    }
}



