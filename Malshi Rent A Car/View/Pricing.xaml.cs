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
    }
}
