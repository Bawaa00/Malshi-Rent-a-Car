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
    /// Interaction logic for Pricing.xaml
    /// </summary>
    public partial class Pricing : Window
    {
        public Pricing()
        {
            InitializeComponent();
        }
        Database db = new Database();
        DataTable dt = new DataTable();
        ModelPricing price = new ModelPricing();

        private void form_pricing_Loaded(object sender, RoutedEventArgs e)
        {
            dt =price.viewPricing();
            dg_price.ItemsSource = dt.DefaultView;

            cmb_cat.SelectedIndex = -1;
            cmb_make.SelectedIndex = -1;
            cmb_year.SelectedIndex = -1;
            txt_model.Clear();
            txt_short.Clear();
            txt_long.Clear();
            txt_extra.Clear();
        }

        private void rbtn_add_Checked(object sender, RoutedEventArgs e)
        {
            dg_price.IsEnabled = false;

            dt = db.getData("Select max(pID) from Pricing ");
            string id = dt.Rows[0][0].ToString();
            if (id == "")
            {
                txt_modelID.Text = "P001";
            }
            else
            {
                var prefix = Regex.Match(id, "^\\D+").Value;
                var number = Regex.Replace(id, "^\\D+", "");
                var i = int.Parse(number) + 1;
                var newString = prefix + i.ToString(new string('0', number.Length));
                txt_modelID.Text = newString;
            }
        }

        private void rbtn_update_Checked(object sender, RoutedEventArgs e)
        {
            dg_price.IsEnabled = true;
            txt_modelID.Text = "";
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            ModelPricing price = new ModelPricing(txt_modelID.Text, cmb_cat.Text,Int32.Parse(cmb_year.Text), cmb_make.Text, txt_model.Text,Int32.Parse(txt_short.Text),Int32.Parse(txt_long.Text),float.Parse(txt_extra.Text));
            int i = price.addPricing();
            if (i == 1)
            {
                MessageBox msg = new MessageBox();
                msg.Show();
                form_pricing_Loaded(this, null);
                rbtn_add_Checked(this, null);
            }
            else
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Sorry, couldn't save your data.Please try again");
                msg.Show();
            }
        }

        private void dg_price_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {  
            DataRowView dataRow = (DataRowView)dg_price.SelectedItem;
            if (dataRow != null)
            {
                int index = dg_price.CurrentCell.Column.DisplayIndex;
                txt_modelID.Text = dataRow.Row.ItemArray[0].ToString();
                cmb_cat.Text = dataRow.Row.ItemArray[1].ToString();
                cmb_year.Text = dataRow.Row.ItemArray[2].ToString();
                cmb_make.Text = dataRow.Row.ItemArray[3].ToString();
                txt_model.Text = dataRow.Row.ItemArray[4].ToString();
                txt_short.Text = dataRow.Row.ItemArray[5].ToString();
                txt_long.Text = dataRow.Row.ItemArray[6].ToString();
                txt_extra.Text = dataRow.Row.ItemArray[7].ToString();
            }
              
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            ModelPricing upPrice = new ModelPricing(txt_modelID.Text, cmb_cat.Text, Int32.Parse(cmb_year.Text), cmb_make.Text, txt_model.Text, Int32.Parse(txt_short.Text), Int32.Parse(txt_long.Text), float.Parse(txt_extra.Text));
            int i = upPrice.updatePricing();
            if (i == 1)
            {
                MessageBox msg = new MessageBox();
                msg.Show();
                form_pricing_Loaded(this, null);
                rbtn_add_Checked(this, null);
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
            int i = price.deletePricing(txt_modelID.Text);
            if (i == 1)
            {
                MessageBox msg = new MessageBox();
                msg.Show();
                form_pricing_Loaded(this, null);
                rbtn_add_Checked(this, null);
            }
            else
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Sorry, couldn't save your data.Please try again");
                msg.Show();
            }
        }
    }
}
