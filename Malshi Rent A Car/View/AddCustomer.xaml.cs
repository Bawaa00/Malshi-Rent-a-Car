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
    /// Interaction logic for AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Window
    {
        public AddCustomer()
        {
            InitializeComponent();
        }
        string path;

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            string name = System.IO.Path.GetFileName(path);
            string destinationPath = GetDestinationPath(name);
            File.Copy(path, destinationPath, true);
            Customer customer = new Customer(txt_CusFname.Text,txt_CusLname.Text,txt_CusNIC.Text,txt_CusEmail.Text,txt_CusResAdrs.Text,Int32.Parse(txt_CusTelHome.Text),Int32.Parse(txt_CusTelMobile.Text),txt_CusProfession.Text,txt_CusWorkAdrs.Text,Int32.Parse(txt_CusTelWork.Text),txt_CusKinName.Text,txt_CusKinkAdrs.Text,Int32.Parse(txt_CusKinConatct.Text),destinationPath);
            int i = customer.addCustomer();
                if (i == 1)
                {
                    MessageBox.Show("Data Saved Successfully!");
                    btn_clear_Click(this,null);
                }
                else
                {
                    MessageBox.Show("Couldnt Save data.Please Try Again");
                }
            
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            txt_CusFname.Clear();
            txt_CusLname.Clear();
            txt_CusNIC.Clear();
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
            img_customer.Source = null;
        }

        private String GetDestinationPath(string filename)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string dir = appStartPath + "\\" + txt_CusNIC.Text;
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            appStartPath = String.Format(dir + "\\" + txt_CusNIC.Text + ".jpg");
            return appStartPath;
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
