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
        String utype;
        Vehicle vehicle = new Vehicle();

        public Dashboard()
        {
            InitializeComponent();
            this.PieChart();
        }
        public Dashboard(string utype,string uname)
        {
            InitializeComponent();
            this.utype = utype;
            lbl_user.Text = uname;
            this.PieChart();
            if(utype == "Manager")
            {
                list_report.Visibility = Visibility.Visible;
                list_accounts.Visibility = Visibility.Visible;
            }
        }

        public Func<ChartPoint, string> PointLabel { get; set; }

        public void PieChart()
        {
            PointLabel = chartPoint => string.Format("{0}({1:P})", chartPoint.Y, chartPoint.Participation);
            DataContext = this;
            SolidColorBrush brush1 = new SolidColorBrush();
            brush1.Color = Color.FromRgb(34, 19, 119);
            SolidColorBrush brush2 = new SolidColorBrush();
            brush2.Color = Color.FromRgb(136, 170, 255);
            SolidColorBrush brush3 = new SolidColorBrush();
            brush3.Color = Color.FromRgb(0, 51, 238);
            SolidColorBrush brush4 = new SolidColorBrush();
            brush4.Color = Color.FromRgb(68, 34, 238);
            SolidColorBrush brush5 = new SolidColorBrush();
            brush5.Color = Color.FromRgb(34, 119, 170);
            piechart.Series = new SeriesCollection
        {
            new PieSeries
            {
                Title = "SEDANS",
                Values = new ChartValues<double> {vehicle.getSedans()},
               // PushOut = 15,            
                DataLabels = true,
                LabelPoint = PointLabel,
                Fill = brush4
            },
            new PieSeries
            {
                Title = "HATCHBACKS",
                Values = new ChartValues<double> {vehicle.getHatchback()},
                DataLabels = true,
                LabelPoint = PointLabel,
                Fill = brush2

            },
            new PieSeries
            {
                Title = "SUVS",
                Values = new ChartValues<double> {vehicle.getSUV()},
                DataLabels = true,
                LabelPoint = PointLabel,
                Fill = brush3
            },
            new PieSeries
            {
                Title = "VAN",
                Values = new ChartValues<double> {vehicle.getVan()},
                DataLabels = true,
                LabelPoint = PointLabel,
                Fill = brush1
            }
            ,
            new PieSeries
            {
                Title = "MINI-VAN",
                Values = new ChartValues<double> {vehicle.getMinivan()},
                DataLabels = true,
                LabelPoint = PointLabel,
                Fill = brush5
            }
        };
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

        private void txt_logout_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.Show();
            this.Close();   
        }

        private void list_accounts_Selected(object sender, RoutedEventArgs e)
        {
            AddAccount aa = new AddAccount();
            aa.Show();
        }

        private void list_report_Selected(object sender, RoutedEventArgs e)
        {
            /*View.ReportView obj = new View.ReportView();
            obj.Show();*/
            /*View.ReportCustomerBooking rp = new View.ReportCustomerBooking();
            rp.Show();*/
            View.ReportMenu rm = new View.ReportMenu();
            rm.Show();
        }

        private void list_booking_Selected(object sender, RoutedEventArgs e)
        {
            searchViewBooking obj = new searchViewBooking();
            obj.Show();
        }
    }
}
