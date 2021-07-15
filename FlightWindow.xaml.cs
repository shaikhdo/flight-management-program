using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AirlineManagementApplication
{
    /// <summary>
    /// Interaction logic for FlightWindow.xaml
    /// </summary>
    public partial class FlightWindow : Window

    {
        private List<Flight> flights = new List<Flight>();

        public FlightWindow()
        {
            InitializeComponent();


            flights.Add(new Flight(0, 324, "Toronto (CAD)", "London (GB)", "28/06/2021", 6.5));
            flights.Add(new Flight(1, 666, "Beijing (CHN)", "Frankfurt (GER)", "29/06/2021", 11));
            flights.Add(new Flight(2, 101, "Riyadh (KSA)", "Washington (USA)", "29/06/2021", 17.25));
            flights.Add(new Flight(3, 182, "Islamabad (PKS)", "Sydney (AUS)", "28/06/2021", 27.5));
            flights.Add(new Flight(4, 948, "Jerusalem (PAL)", "Aleppo (SYR)", "30/06/2021", 3));

            var names = from fly in flights
                        select fly.AirlineID;
            listFlight.DataContext = names;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int airNum;
            double time;

            bool checkInt = int.TryParse(tbAirID.Text, out airNum);
            bool checkDbl = double.TryParse(tbAirID.Text, out time);

            if (tbAirID.Text == "" || tbDepCity.Text == "" || tbDesCity.Text == "" || tbDate.Text == "" || tbFlight.Text == "")
            {
                MessageBox.Show("No text box can be empty", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (checkInt && checkDbl)
            {
                flights.Add(new Flight(flights.Count, int.Parse(tbAirID.Text), tbDepCity.Text, tbDesCity.Text, tbDate.Text, double.Parse(tbFlight.Text)));

                var names = from fly in flights
                            select fly.AirlineID;
                listFlight.DataContext = names;
            }
            else
            {
                MessageBox.Show("No text box can be empty, Airline ID must be a whole number (ie 84), and Flight" +
                    "Time must be in a whole number or decimal format", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int airNum;
            double time;

            bool checkInt = int.TryParse(tbAirID.Text, out airNum);
            bool checkDbl = double.TryParse(tbAirID.Text, out time);

            if (tbAirID.Text == "" || tbDepCity.Text == "" || tbDesCity.Text == "" || tbDate.Text == "" || tbFlight.Text == "")
            {
                MessageBox.Show("No text box can be empty", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (checkInt && checkDbl)
            {
                Flight f = new Flight(listFlight.SelectedIndex, int.Parse(tbAirID.Text), tbDepCity.Text, tbDesCity.Text, tbDate.Text, double.Parse(tbFlight.Text));
                flights[listFlight.SelectedIndex] = f;

                var names = from fly in flights
                            select fly.AirlineID;
                listFlight.DataContext = names;

            }
            else
            {
                MessageBox.Show("No text box can be empty, Airline ID must be a whole number (ie 84), and Flight" +
                   "Time must be in a whole number or decimal format", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listFlight.SelectedIndex >= 0)
            {
                flights.RemoveAt(listFlight.SelectedIndex);

                for (int i = 0; i < flights.Count; i++)
                {
                    flights[i].ID = i;
                }

                var names = from fly in flights
                            select fly.AirlineID;
                listFlight.DataContext = names;
            }
            
        }

        private void listFlight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = listFlight.SelectedIndex;
            var selectedFlight = from fly in flights
                                   where fly.ID == i
                                   select fly;

            foreach (var s in selectedFlight)
            {
                string airNum = s.AirlineID.ToString();
                string time = s.FlightTime.ToString();

                tbAirID.Text = airNum;
                tbDepCity.Text = s.DepartureCity;
                tbDesCity.Text = s.DestinationCity;
                tbDate.Text = s.DepartureDate;
                tbFlight.Text = time;

            }

        }

        private void menQuit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Are you sure you want to quit?", "Quit",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning );
            if (MessageBox.Show("Are you sure you want to quit?", "Quit",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }

        }

        private void menUpdate_Click(object sender, RoutedEventArgs e)
        {
            int airNum;
            double time;

            bool checkInt = int.TryParse(tbAirID.Text, out airNum);
            bool checkDbl = double.TryParse(tbAirID.Text, out time);

            if (tbAirID.Text == "" || tbDepCity.Text == "" || tbDesCity.Text == "" || tbDate.Text == "" || tbFlight.Text == "")
            {
                MessageBox.Show("No text box can be empty", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (checkInt && checkDbl)
            {
                Flight f = new Flight(listFlight.SelectedIndex, int.Parse(tbAirID.Text), tbDepCity.Text, tbDesCity.Text, tbDate.Text, double.Parse(tbFlight.Text));
                flights[listFlight.SelectedIndex] = f;

                var names = from fly in flights
                            select fly.AirlineID;
                listFlight.DataContext = names;

            }
            else
            {
                MessageBox.Show("No text box can be empty, Airline ID must be a whole number (ie 84), and Flight" +
                   "Time must be in a whole number or decimal format", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void menAdd_Click(object sender, RoutedEventArgs e)
        {
            int airNum;
            double time;

            bool checkInt = int.TryParse(tbAirID.Text, out airNum);
            bool checkDbl = double.TryParse(tbAirID.Text, out time);

            if (tbAirID.Text == "" || tbDepCity.Text == "" || tbDesCity.Text == "" || tbDate.Text == "" || tbFlight.Text == "")
            {
                MessageBox.Show("No text box can be empty", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (checkInt && checkDbl)
            {
                flights.Add(new Flight(flights.Count, int.Parse(tbAirID.Text), tbDepCity.Text, tbDesCity.Text, tbDate.Text, double.Parse(tbFlight.Text)));

                var names = from fly in flights
                            select fly.AirlineID;
                listFlight.DataContext = names;
            }
            else
            {
                MessageBox.Show("No text box can be empty, Airline ID must be a whole number (ie 84), and Flight" +
                    "Time must be in a whole number or decimal format", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void menDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listFlight.SelectedIndex >= 0)
            {
                flights.RemoveAt(listFlight.SelectedIndex);

                for (int i = 0; i < flights.Count; i++)
                {
                    flights[i].ID = i;
                }

                var names = from fly in flights
                            select fly.AirlineID;
                listFlight.DataContext = names;
            }


        }

        private void menHelp_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow h = new HelpWindow();
            h.ShowDialog();

        }
    }
}
