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
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Charts;
using System.Data;

namespace Malshi_Rent_A_Car
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        String utype;
        Vehicle vehicle = new Vehicle();
        public Dashboard(string utype)
        {
            InitializeComponent();
            this.utype = utype;
        }
        public Func<ChartPoint, string> PointLabel { get; set; }

        public void PieChart()
        {
            PointLabel = chartPoint => string.Format("{0}({1:P})", chartPoint.Y, chartPoint.Participation);
            DataContext = this;
        }

        public void labelData()
        {

           /* string path;
            DataTable dt = new DataTable();
            dt = db.getData("select COUNT(L_Plate) from Vehicle");
            label_vehicle.Content = dt.Rows[0][0].ToString();
            dt = db.getData("select COUNT(D_ID) from Driver");
            label_driver.Content = dt.Rows[0][0].ToString();
            dt = db.getData("select COUNT(Cus_ID) from Customer");
            label_customer.Content = dt.Rows[0][0].ToString();

            try
            {
                string lnum;
                dt = db.getData("select L_Plate,COUNT(L_Plate) from Car_Booking,Vehicle where L_Plate = VNO group by L_Plate");
                lnum = dt.Rows[0][0].ToString();
                dt = db.getData("select * from Vehicle where L_Plate = '" + lnum + "'");
                lbl_year.Content = dt.Rows[0][1].ToString();
                lbl_make.Content = dt.Rows[0][2].ToString();
                lbl_model.Content = dt.Rows[0][3].ToString();
                lbl_cat.Content = dt.Rows[0][4].ToString();
                path = dt.Rows[0][13].ToString();
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = new Uri(path);
                image.EndInit();
                img_vehicle.Source = image;
            }
            catch (IndexOutOfRangeException)
            {
               Messagebox obj = new Messagebox();
                obj.errorMsg("Database Error");
                obj.Show();
            }
            catch (Exception ex)
            {
                Messagebox msg = new Messagebox();
                msg.errorMsg("Oops soomething went worng. " + ex.Message);
                msg.Show();
            }*/
        }

        private void list_customer_Selected(object sender, RoutedEventArgs e)
        {
            SearchViewCustomer obj = new SearchViewCustomer();
            obj.Show();
        }

        private void list_owners_Selected(object sender, RoutedEventArgs e)
        {
            searchViewOwners obj = new searchViewOwners();
            obj.Show();
        }

        private void list_pricing_Selected(object sender, RoutedEventArgs e)
        {
            Pricing obj = new Pricing();
            obj.Show();
        }

        private void list_repairs_Selected(object sender, RoutedEventArgs e)
        {
            searchViewRepair obj = new searchViewRepair();
            obj.Show();
        }

        private void list_service_Selected(object sender, RoutedEventArgs e)
        {
            searchViewServices obj = new searchViewServices();
            obj.Show();
        }

        private void list_vehicle_Selected(object sender, RoutedEventArgs e)
        {
            SearchViewVehicle obj = new SearchViewVehicle();
            obj.Show();
        }

        private void form_dashboard_Loaded(object sender, RoutedEventArgs e)
        {
            txt_totV.Text=vehicle.getTotalVehicleCount().ToString();
            txt_available.Text = vehicle.getAvaialableVehicleCount().ToString();
        }
    }
}
