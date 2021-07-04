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
    /// Interaction logic for SearchViewCustomer.xaml
    /// </summary>
    public partial class SearchViewCustomer : Window
    {
        public SearchViewCustomer()
        {
            InitializeComponent();
        }

        Customer customer = new Customer();
        Database db = new Database();
      

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            AddCustomer obj = new AddCustomer();
            obj.Show();
        }

       

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            UpdateCustomer obj = new UpdateCustomer();
            obj.Show();
        }

        private void view_customer_Loaded(object sender, RoutedEventArgs e)
        {
           
                DataTable dt = new DataTable();
                dt = db.getData("select cus_FName  as 'FIRST NAME', cus_LName  as 'LAST NAME', cNIC as'NIC',cEmail  as 'EMAIL',residentAd  as 'HOME ADDRESS',homeTel  as 'HOME TEL',mobileTel  as 'MOBILE TEL',cProffession  as 'PROFESSION',workAd   as 'WORK ADDRESS',workTel   as 'WORK TEL',D_ID  as 'KIN NAME',D_name  as 'KIN ADDRESS',Model  as 'KIN TEL'" +
                    " from Customer,Customer_Kin" +
                    " where cNIC = CusID ");
                dg_customer.ItemsSource = dt.DefaultView;

                dt = db.getData("select * from Customer;");
                cmb_CusNIC.ItemsSource = dt.DefaultView;
                cmb_CusNIC.DisplayMemberPath = "BK_No";
                cmb_CusNIC.SelectedValuePath = "BK_No";

                dt = db.getData("Select * from Customer");
                cmb_CusName.ItemsSource = dt.DefaultView;
                cmb_CusName.DisplayMemberPath = "Cus_ID";
                cmb_CusName.SelectedValuePath = "Cus_ID";     

          
        }

        private void btn_view_Click(object sender, RoutedEventArgs e)
        {

            DataTable dt = new DataTable();
            dt = db.getData("select cus_FName  as 'FIRST NAME', cus_LName  as 'LAST NAME', cNIC as'NIC',cEmail  as 'EMAIL',residentAd  as 'HOME ADDRESS',homeTel  as 'HOME TEL',mobileTel  as 'MOBILE TEL',cProffession  as 'PROFESSION',workAd   as 'WORK ADDRESS',workTel   as 'WORK TEL',D_ID  as 'KIN NAME',D_name  as 'KIN ADDRESS',Model  as 'KIN TEL'" +
                " from Customer,Customer_Kin" +
                " where cNIC = CusID  ");
           dg_customer.ItemsSource = dt.DefaultView;
        }

        private void cmb_CusNIC_DropDownClosed(object sender, EventArgs e)
        {
            cmb_CusName.Text = "";

            DataTable dt = new DataTable();
            dt = db.getData("select cus_FName  as 'FIRST NAME', cus_LName  as 'LAST NAME', cNIC as'NIC',cEmail  as 'EMAIL',residentAd  as 'HOME ADDRESS',homeTel  as 'HOME TEL',mobileTel  as 'MOBILE TEL',cProffession  as 'PROFESSION',workAd   as 'WORK ADDRESS',workTel   as 'WORK TEL',D_ID  as 'KIN NAME',D_name  as 'KIN ADDRESS',Model  as 'KIN TEL'" +
                " from Customer,Customer_Kin" +
                 " where cNIC = CusID and DNO = D_ID and cNIC = '" + cmb_CusNIC.Text + "'");
            dg_customer.ItemsSource = dt.DefaultView;
        }

        private void cmb_CusName_DropDownClosed(object sender, EventArgs e)
        {
            cmb_CusNIC.Text = "";

            DataTable dt = new DataTable();
            dt = db.getData("select cus_FName  as 'FIRST NAME', cus_LName  as 'LAST NAME', cNIC as'NIC',cEmail  as 'EMAIL',residentAd  as 'HOME ADDRESS',homeTel  as 'HOME TEL',mobileTel  as 'MOBILE TEL',cProffession  as 'PROFESSION',workAd   as 'WORK ADDRESS',workTel   as 'WORK TEL',D_ID  as 'KIN NAME',D_name  as 'KIN ADDRESS',Model  as 'KIN TEL'" +
                " from Customer,Customer_Kin," +
                 " where cNIC = CusID  and cus_FName = '" + cmb_CusName.Text + "'");
            dg_customer.ItemsSource = dt.DefaultView;
        }
    }

}
