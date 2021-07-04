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
    /// Interaction logic for UpdateCustomer.xaml
    /// </summary>
    public partial class UpdateCustomer : Window
    {
        public UpdateCustomer()
        {
            InitializeComponent();
        }
        Database db = new Database();
        Customer customer = new Customer();

        private void customer_update_Loaded(object sender, RoutedEventArgs e)
        {

            DataTable dt = new DataTable();
            dt = db.getData("select * from Customer");
            cmb_nic.ItemsSource = dt.DefaultView;
            cmb_nic.DisplayMemberPath = "cNIC";
            cmb_nic.SelectedValuePath = "cNIC";


        }

        private void cmb_nic_DropDownClosed(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getData("select * from Customer where cNIC='" + cmb_nic.Text + "'");

            cmb_nic.Text = dt.Rows[0][0].ToString();
            txt_firstname.Text = dt.Rows[0][1].ToString();
            txt_lname.Text = dt.Rows[0][2].ToString();
            txt_CusResAdrs.Text = dt.Rows[0][3].ToString();
            txt_CusWorkAdrs.Text = dt.Rows[0][4].ToString();
            txt_CusTelHome.Text = dt.Rows[0][5].ToString();
            txt_CusTelMobile.Text = dt.Rows[0][6].ToString();
            txt_CusTelWork.Text = dt.Rows[0][7].ToString();
            txt_CusEmail.Text = dt.Rows[0][8].ToString();
            txt_CusProfession.Text = dt.Rows[0][9].ToString();
          
            
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            string a = " update Customer set  cus_FName = '" + txt_firstname.Text + "', cus_LName='" + txt_lname.Text + "', cEmail='" + txt_CusEmail.Text + "', residentAd='" + txt_CusResAdrs.Text + "', homeTel='" + txt_CusTelHome.Text + "', mobileTel='" + txt_CusTelMobile.Text + "', cProffession='" + txt_CusProfession.Text + "', workAd='" + txt_CusWorkAdrs.Text + "', workTel='" + txt_CusTelWork.Text + "' where cNIC = '" + cmb_nic.Text + "'";
            string b = " update Customer_Kin set kNmae='" + txt_CusKinName.Text + "' , kAddress = '" + txt_CusKinkAdrs.Text + "' , kContact = '" + txt_CusKinConatct.Text + "' where  CusID = '" + cmb_nic.Text + "'";

            int x = db.save_update_delete(a);
            int y = db.save_update_delete(b);
            if (x == 1 && y == 1)
                MessageBox.Show("Data save Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            else
                MessageBox.Show("Data cannot save", "error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void bttn_delete_Click(object sender, RoutedEventArgs e)
        {

            string a = " Delete from Customer where S_ID = '" + cmb_nic.Text + "'";

            int line = db.save_update_delete(a);
            if (line == 1)
                MessageBox.Show("Data delete Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            else
                MessageBox.Show("Data cannot delete", "error", MessageBoxButton.OK, MessageBoxImage.Error);


            cmb_nic.Items.Clear();
            txt_firstname.Clear();
            txt_lname.Clear();
            txt_CusEmail.Clear();
            txt_CusResAdrs.Clear();
            txt_CusTelHome.Clear();
            txt_CusTelMobile.Clear();
            txt_CusProfession.Clear();
            txt_CusWorkAdrs.Clear();
            txt_CusTelWork.Clear();
            txt_CusKinName.Clear();
            txt_CusKinkAdrs.Clear();
            txt_CusKinConatct.Clear();

        }
    }
}
