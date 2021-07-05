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

namespace Malshi_Rent_A_Car.View
{
    /// <summary>
    /// Interaction logic for BillPrint.xaml
    /// </summary>
    public partial class BillPrint : Window
    {
        public BillPrint()
        {
            InitializeComponent();
        }
        Database db = new Database();
        DataTable dt = new DataTable();

        private void form_bill_Loaded(object sender, RoutedEventArgs e)
        {
            lbl_billDate.Content = DateTime.Now.ToString();

            dt = db.getData("Select max(bill_ID) from Billing");
            string id = dt.Rows[0][0].ToString();
            if (id == "")
            {
                lbl_billID.Content = "BL001";
            }
            else
            {
                var prefix = Regex.Match(id, "^\\D+").Value;
                var number = Regex.Replace(id, "^\\D+", "");
                var i = int.Parse(number) + 1;
                var newString = prefix + i.ToString(new string('0', number.Length));
                lbl_billID.Content = newString;
            }
        }
    }
}
