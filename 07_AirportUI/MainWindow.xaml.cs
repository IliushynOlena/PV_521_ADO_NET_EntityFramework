using _05_EntityFramework;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _07_AirportUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AirportDbContext dbContext;
        public MainWindow()
        {
            int a = 5;//not null
            int? b = null;
            string s = null;//null  xxxxxxxxxxxxxxxxxxxxxxxxxxxx

            InitializeComponent();
            dbContext = new AirportDbContext();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = dbContext.Clients.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = dbContext.Flights.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = dbContext.Airplanes.ToList();
        }
    }
}