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
    /// Interaction logic for InsuranceManagement.xaml
    /// </summary>
    public partial class InsuranceManagement : Window
    {
        public InsuranceManagement()
        {
            InitializeComponent();
        }
        Database db = new Database();
        DataTable dt = new DataTable();
        Insurance ins = new Insurance();

        private void form_insurance_Loaded(object sender, RoutedEventArgs e)
        {
            dt = ins.viewInsurance();
            dg_insurance.ItemsSource = dt.DefaultView;
            txt_insID.Clear();
            txt_company.Clear();

        }

        private void rbtn_add_Checked(object sender, RoutedEventArgs e)
        {
            dg_insurance.IsEnabled = false;

            dt = db.getData("Select max(insID) from Insurance ");
            string id = dt.Rows[0][0].ToString();
            if (id == "")
            {
                txt_insID.Text = "I001";
            }
            else
            {
                var prefix = Regex.Match(id, "^\\D+").Value;
                var number = Regex.Replace(id, "^\\D+", "");
                var i = int.Parse(number) + 1;
                var newString = prefix + i.ToString(new string('0', number.Length));
                txt_insID.Text = newString;
            }
            btn_add.Visibility = Visibility.Visible;
            btn_update.Visibility = Visibility.Hidden;
            btn_del.Visibility = Visibility.Hidden;
        }

        private void rbtn_update_Checked(object sender, RoutedEventArgs e)
        {
            dg_insurance.IsEnabled = true;
            form_insurance_Loaded(this, null);
            btn_add.Visibility = Visibility.Hidden;
            btn_update.Visibility = Visibility.Visible;
            btn_del.Visibility = Visibility.Visible;
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            Insurance insurance = new Insurance(txt_insID.Text, txt_company.Text);
            int i = insurance.addInsurance();
            if (i == 1)
            {
                MessageBox msg = new MessageBox();
                msg.Show();
                form_insurance_Loaded(this, null);
                rbtn_add_Checked(this, null);
            }
            else
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Sorry, couldn't save your data.Please try again");
                msg.Show();
            }
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            Insurance insurance = new Insurance(txt_insID.Text, txt_company.Text);
            int i = insurance.updateInsurance();
            if (i == 1)
            {
                MessageBox msg = new MessageBox();
                msg.Show();
                form_insurance_Loaded(this, null);
                //rbtn_add_Checked(this, null);
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
            int i = ins.deleteInsurance(txt_insID.Text);
            if (i == 1)
            {
                MessageBox msg = new MessageBox();
                msg.Show();
                form_insurance_Loaded(this, null);
                //rbtn_add_Checked(this, null);
            }
            else
            {
                MessageBox msg = new MessageBox();
                msg.errorMsg("Sorry, couldn't delete your data.Please try again");
                msg.Show();
            }
        }

        private void dg_insurance_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)dg_insurance.SelectedItem;
            if (dataRow != null)
            {
                int index = dg_insurance.CurrentCell.Column.DisplayIndex;
                txt_insID.Text = dataRow.Row.ItemArray[0].ToString();
                txt_company.Text = dataRow.Row.ItemArray[1].ToString();

            }
        }
    }
}
