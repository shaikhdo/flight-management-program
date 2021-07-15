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
    /// Interaction logic for PassengerWindow.xaml
    /// </summary>
    public partial class PassengerWindow : Window
    {

        private Stack<Passenger> passengers = new Stack<Passenger>();

        public PassengerWindow()
        {
            InitializeComponent();

            passengers.Push(new Passenger(4, 0, 324));
            passengers.Push(new Passenger(3, 1, 666));
            passengers.Push(new Passenger(2, 2, 101));
            passengers.Push(new Passenger(1, 3, 182));
            passengers.Push(new Passenger(0, 4, 948));


            var names = from p in passengers
                        orderby p.ID
                        select p.CustomerID;
            listPassenger.DataContext = names;

        }

    private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int suc;
            int ylf;
            bool checkInt = int.TryParse(tbCustID.Text, out suc);
            bool checkNum = int.TryParse(tbFlightID.Text, out ylf);

            if (tbCustID.Text=="" || tbFlightID.Text== "")
            {
                MessageBox.Show("No text box can be empty", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (checkInt && checkNum)
            {
                passengers.Push(new Passenger(passengers.Count, int.Parse(tbCustID.Text), int.Parse(tbFlightID.Text)));

                var names = from p in passengers
                            orderby p.ID
                            select p.CustomerID;
                listPassenger.DataContext = names;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var list = passengers.ToList();
            int suc;
            int ylf;
            bool checkInt = int.TryParse(tbCustID.Text, out suc);
            bool checkNum = int.TryParse(tbFlightID.Text, out ylf);

            if (tbCustID.Text == "" || tbFlightID.Text == "")
            {
                MessageBox.Show("No text box can be empty", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                if ((listPassenger.SelectedIndex >= 0)&&(checkInt && checkNum))
                {
                    Passenger c = new Passenger(listPassenger.SelectedIndex, int.Parse(tbCustID.Text), int.Parse(tbFlightID.Text));
                    list[listPassenger.SelectedIndex] = c;

                    var stack = new Stack<Passenger>(list);

                    var names = from s in stack
                                select s.CustomerID;
                    listPassenger.DataContext = names;
                }

                else
                {
                    MessageBox.Show("Selected index is out of bounds", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var list = passengers.ToList();

            if (listPassenger.SelectedIndex >= 0)
            {
                list.RemoveAt(listPassenger.SelectedIndex);

                for (int i = 0; i < list.Count; i++)
                {
                    list[i].ID = i;
                }

                var stack = new Stack<Passenger>(list);

                var names = from q in stack
                            select q.CustomerID;
                listPassenger.DataContext = names;
            }

        }

        private void listPassenger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = listPassenger.SelectedIndex;
            var selectedPas = from pas in passengers
                              where pas.ID == i
                              select pas;

            foreach (var s in selectedPas)
            {
                string cust = s.CustomerID.ToString();
                string fly = s.FlightID.ToString();

                tbCustID.Text = cust;
                tbFlightID.Text = fly;
            }
        }

        private void menAdd_Click(object sender, RoutedEventArgs e)
        {
            int suc;
            int ylf;
            bool checkInt = int.TryParse(tbCustID.Text, out suc);
            bool checkNum = int.TryParse(tbFlightID.Text, out ylf);

            if (tbCustID.Text == "" || tbFlightID.Text == "")
            {
                MessageBox.Show("No text box can be empty", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (checkInt && checkNum)
            {
                passengers.Push(new Passenger(passengers.Count, int.Parse(tbCustID.Text), int.Parse(tbFlightID.Text)));

                var names = from p in passengers
                            orderby p.ID
                            select p.CustomerID;
                listPassenger.DataContext = names;
            }
        }

        private void menUpdate_Click(object sender, RoutedEventArgs e)
        {
            var list = passengers.ToList();
            int suc;
            int ylf;
            bool checkInt = int.TryParse(tbCustID.Text, out suc);
            bool checkNum = int.TryParse(tbFlightID.Text, out ylf);

            if (tbCustID.Text == "" || tbFlightID.Text == "")
            {
                MessageBox.Show("No text box can be empty", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                if ((listPassenger.SelectedIndex >= 0) && (checkInt && checkNum))
                {
                    Passenger c = new Passenger(listPassenger.SelectedIndex, int.Parse(tbCustID.Text), int.Parse(tbFlightID.Text));
                    list[listPassenger.SelectedIndex] = c;

                    var stack = new Stack<Passenger>(list);

                    var names = from s in stack
                                select s.CustomerID;
                    listPassenger.DataContext = names;
                }

                else
                {
                    MessageBox.Show("Selected index is out of bounds", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void menDelete_Click(object sender, RoutedEventArgs e)
        {
            var list = passengers.ToList();

            if (listPassenger.SelectedIndex >= 0)
            {
                list.RemoveAt(listPassenger.SelectedIndex);

                for (int i = 0; i < list.Count; i++)
                {
                    list[i].ID = i;
                }

                var stack = new Stack<Passenger>(list);

                var names = from q in stack
                            select q.CustomerID;
                listPassenger.DataContext = names;
            }
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
    }
}

          
