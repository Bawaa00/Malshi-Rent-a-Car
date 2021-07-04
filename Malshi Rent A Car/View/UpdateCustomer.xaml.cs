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
using System.Diagnostics;
using System.IO;
using System.Data;
using Microsoft.Win32;

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
        DataTable dt = new DataTable();
        Customer customer = new Customer();
        string path;

        private String GetDestinationPath(string filename)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string dir = appStartPath + "\\" + cmb_nic.Text;
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            appStartPath = String.Format(dir + "\\" + cmb_nic.Text + ".jpg");
            return appStartPath;
        }

        private void customer_update_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt1 = new DataTable();
            dt1 = customer.viewCustomer();
            cmb_nic.ItemsSource = dt1.DefaultView;
            cmb_nic.DisplayMemberPath = "NIC";
            cmb_nic.SelectedValuePath = "NIC";

        }

        private void cmb_nic_DropDownClosed(object sender, EventArgs e)
        {
            dt = customer.viewCustomer(cmb_nic.Text);

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
            path = dt.Rows[0][10].ToString();

            if (path != "")
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = new Uri(path);
                image.EndInit();
                img_customer.Source = image;
            }
            else
            {
                img_customer.Source = null;
            }


        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            string name = System.IO.Path.GetFileName(path);
            string destinationPath = GetDestinationPath(name);
            File.Copy(path, destinationPath, true);
            Customer upCustomer = new Customer(txt_firstname.Text, txt_lname.Text, cmb_nic.Text, txt_CusEmail.Text, txt_CusResAdrs.Text, Int32.Parse(txt_CusTelHome.Text), Int32.Parse(txt_CusTelMobile.Text), txt_CusProfession.Text, txt_CusWorkAdrs.Text, Int32.Parse(txt_CusTelWork.Text), txt_CusKinName.Text, txt_CusKinkAdrs.Text, Int32.Parse(txt_CusKinConatct.Text), destinationPath); ;
            int i = upCustomer.updateCustomer();
            if (i ==1)
                MessageBox.Show("Data save Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            else
                MessageBox.Show("Data cannot save", "error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void bttn_delete_Click(object sender, RoutedEventArgs e)
        {
            int line = customer.deleteCustomer(cmb_nic.Text);            
            if (line == 1)
            {
                MessageBox.Show("Data delete Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
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
               
            else
                MessageBox.Show("Data cannot delete", "error", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void btn_upload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            bool? result = open.ShowDialog();

            if (result == true)
            {
                path = open.FileName; // Stores Original Path in Textbox    
                ImageSource imgsource = new BitmapImage(new Uri(path)); // Just show The File In Image when we browse It
                img_customer.Source = imgsource;
            }
        }
    }
}
