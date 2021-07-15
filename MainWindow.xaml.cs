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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirlineManagementApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Logins> people = new List<Logins>();

        public MainWindow()
        {
            InitializeComponent();
            people.Add(new Logins(1, "Light", "peanutbutter", 1));
            people.Add(new Logins(2, "Misa", "stinkysock", 0));
            people.Add(new Logins(3, "L", "a", 1));
            people.Add(new Logins(4, "Ryuk", "frenchfryguy", 0));
            people.Add(new Logins(5, "Matsu", "woowoo", 0));

        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow c = new CustomerWindow();
            c.ShowDialog();

        }

        private void btnFlight_Click(object sender, RoutedEventArgs e)
        {
            FlightWindow f = new FlightWindow();
            f.ShowDialog();

        }

        private void btnAirline_Click(object sender, RoutedEventArgs e)
        {
            AirlinesWindow a = new AirlinesWindow();
            a.ShowDialog();

        }

        private void btnPassenger_Click(object sender, RoutedEventArgs e)
        {
            PassengerWindow p = new PassengerWindow();
            p.ShowDialog();
            
        }

        private void menHelp_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow h = new HelpWindow();
            h.ShowDialog();
        }

        private void menQuit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Are you sure you want to quit?", "Quit",
                        MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (MessageBox.Show("Are you sure you want to quit?", "Quit",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void menPass_Click(object sender, RoutedEventArgs e)
        {
            PassengerWindow p = new PassengerWindow();
            p.ShowDialog();

        }

        private void menCus_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow c = new CustomerWindow();
            c.ShowDialog();
        }

        private void menFlights_Click(object sender, RoutedEventArgs e)
        {
            FlightWindow f = new FlightWindow();
            f.ShowDialog();

        }

        private void menAir_Click(object sender, RoutedEventArgs e)
        {
            AirlinesWindow a = new AirlinesWindow();
            a.ShowDialog();

        }
    }
}
