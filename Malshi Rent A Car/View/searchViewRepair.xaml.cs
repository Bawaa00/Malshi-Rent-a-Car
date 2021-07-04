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
    /// Interaction logic for searchViewRepair.xaml
    /// </summary>
    public partial class searchViewRepair : Window
    {
        public searchViewRepair()
        {
            InitializeComponent();
        }
        Database db = new Database();
        DataTable dt = new DataTable();
        MaintenanceRepair mr = new MaintenanceRepair();
        AccidentRepair ar = new AccidentRepair();

        private void cmb_RepCatagory_DropDownClosed(object sender, EventArgs e)
        {
            if (cmb_RepCatagory.SelectedIndex == 0)
            {
                dt = mr.viewRepair();
                dg_repair.ItemsSource = dt.DefaultView;
            }
            else if (cmb_RepCatagory.SelectedIndex == 1)
            {
                dt = ar.viewRepair();
                dg_repair.ItemsSource = dt.DefaultView;
            }
        }
    }
}
