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
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;

namespace Malshi_Rent_A_Car
{
    /// <summary>
    /// Interaction logic for UpdateOwner.xaml
    /// </summary>
    public partial class UpdateOwner : Window
    {
        public UpdateOwner()
        {
            InitializeComponent();
        }
        Database db = new Database();
        Owner owner = new Owner();
        string path;

        private String GetDestinationPath(string filename)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string dir = appStartPath + "\\" + cmb_onic.Text;
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            appStartPath = String.Format(dir + "\\" + cmb_onic.Text + ".jpg");
            return appStartPath;
        }

        private void form_updateOwner_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = owner.viewOwner();
            cmb_onic.ItemsSource = dt.DefaultView;
            cmb_onic.DisplayMemberPath = "NIC";
            cmb_onic.SelectedValuePath = "NIC";
        }

        private void cmb_onic_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_onic.SelectedItem == null)
            {
                error_msg.Text = "Please Select NIC";
            }
            else
            {
                DataTable dt = new DataTable();
                dt = owner.viewOwner(cmb_onic.Text);
                txt_OwnFname.Text = dt.Rows[0][1].ToString();
                txt_OwnLame.Text = dt.Rows[0][2].ToString();
                txt_OwnEmail.Text = dt.Rows[0][9].ToString();
                txt_OwnResAdrs.Text = dt.Rows[0][3].ToString();
                txt_OwnTelHome.Text = dt.Rows[0][4].ToString();
                txt_OwnTelMobile.Text = dt.Rows[0][5].ToString();
                txt_OwnProfession.Text = dt.Rows[0][6].ToString();
                txt_OwnWorkAdrs.Text = dt.Rows[0][7].ToString();
                txt_OwnTelWork.Text = dt.Rows[0][8].ToString();
                path = dt.Rows[0][10].ToString();
                if (path != "")
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.UriSource = new Uri(path);
                    image.EndInit();
                    img_owner.Source = image;
                }
                else
                {
                    img_owner.Source = null;
                }
            }
        }

        private void btn_cls_Click(object sender, RoutedEventArgs e)
        {
            txt_OwnFname.Clear();
            txt_OwnLame.Clear();
            txt_OwnEmail.Clear();
            txt_OwnResAdrs.Clear();
            txt_OwnTelHome.Clear();
            txt_OwnTelMobile.Clear();
            txt_OwnProfession.Clear();
            txt_OwnWorkAdrs.Clear();
            txt_OwnTelWork.Clear();
            img_owner.Source = null;
            cmb_onic.Text = "";
            error_msg.Text = "";
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = System.IO.Path.GetFileName(path);
                string destinationPath = GetDestinationPath(name);
                File.Copy(path, destinationPath, true);
                Owner owner = new Owner(txt_OwnFname.Text, txt_OwnLame.Text, cmb_onic.Text, txt_OwnResAdrs.Text, txt_OwnWorkAdrs.Text,txt_OwnEmail.Text, Int32.Parse(txt_OwnTelMobile.Text), Int32.Parse(txt_OwnTelHome.Text), Int32.Parse(txt_OwnTelWork.Text), txt_OwnProfession.Text,destinationPath );
                int i = owner.updateOwner();
                if (i == 1)
                {
                    MessageBox msg = new MessageBox();
                    msg.errorMsg("Data updated successfully!");
                    msg.Show();
                }
                else
                {
                    MessageBox msg = new MessageBox();
                    msg.errorMsg("Could not save data,Please try agian");
                    msg.Show();
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Please upload a photo");
                msg.Show();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Please fill the form correctly. Database Error");
                msg.Show();
            }
            catch (Exception ex)
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Oops something went worng. " + ex.Message);
                msg.Show();
            }
        }

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            int i = owner.deleteOwner(cmb_onic.Text);
            if (i == 1)
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Data deleted successfully");
                msg.Show();
                form_updateOwner_Loaded(this, null);
                btn_cls_Click(this, null);
            }
            else
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Could not save data,Please try agian");
                msg.Show();
            }
        }

        private void txt_OwnFname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnFname.Text.Length == 0)
                error_msg.Text = "Please Enter Owner First Name  ";
            else
                error_msg.Text = "";
        }

        private void txt_OwnLame_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnLame.Text.Length == 0)
                error_msg.Text = "Please Enter Owner Last Name  ";
            else
                error_msg.Text = "";
        }

        private void txt_OwnEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnEmail.Text.Length == 0)
                error_msg.Text = "Please Enter Owner Emal";
            else
                error_msg.Text = "";
        }

        private void txt_OwnResAdrs_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnResAdrs.Text.Length == 0)
                error_msg.Text = "Please Enter Owner Home Address";
            else
                error_msg.Text = "";
        }

        private void txt_OwnTelHome_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnTelHome.Text.Length == 0)
                error_msg.Text = "Please Enter Owner Home Number ";
            else if (!Regex.IsMatch(txt_OwnTelHome.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))

                error_msg.Text = "Contact No not Valid";
            else
                error_msg.Text = "";
        }

        private void txt_OwnTelMobile_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnTelMobile.Text.Length == 0)
                error_msg.Text = "Please Enter Owner Mobile Number ";
            else if (!Regex.IsMatch(txt_OwnTelMobile.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))

                error_msg.Text = "Contact No not Valid";
            else
                error_msg.Text = "";
        }

        private void txt_OwnProfession_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnProfession.Text.Length == 0)
                error_msg.Text = "Please Enter Owner Profession";
            else
                error_msg.Text = "";
        }

        private void txt_OwnWorkAdrs_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnWorkAdrs.Text.Length == 0)
                error_msg.Text = "Please Enter Owner Work Address";
            else
                error_msg.Text = "";
        }

        private void txt_OwnTelWork_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_OwnTelWork.Text.Length == 0)
                error_msg.Text = "Please Enter Owner Work Number ";
            else if (!Regex.IsMatch(txt_OwnTelWork.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))

                error_msg.Text = "Contact No not Valid";
            else
                error_msg.Text = "";
        }

        private void btn_upload_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Multiselect = false;
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                bool? result = open.ShowDialog();

                if (result == true)
                {
                    path = open.FileName; // Stores Original Path in Textbox    
                    ImageSource imgsource = new BitmapImage(new Uri(path)); // Just show The File In Image when we browse It
                    img_owner.Source = imgsource;
                }
            }
            catch (Exception ex)
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Oops soomething went worng. " + ex.Message);
                msg.Show();
            }
        }
    }
    
}
