using System;
using System.Collections;
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
    /// Interaction logic for AirlinesWindow.xaml
    /// </summary>
    public partial class AirlinesWindow : Window
    {
        Queue<Airline> qAirline = new Queue<Airline>();
        string mealThing;
        string flightThing;
        

        public AirlinesWindow()
        {
            InitializeComponent();

            qAirline.Enqueue(new Airline(0, "British Airways", "Boeing 767", 40, "Waldorf Salad"));
            qAirline.Enqueue(new Airline(1, "Saudia", "Boeing 787", 274, "Shrimp Kabsa"));
            qAirline.Enqueue(new Airline(2, "Aer Lingus", "Boeing 727", 50, "Shahi Paneer"));
            qAirline.Enqueue(new Airline(3, "Etihad", "Boeing 787", 150, "Unagi Roll"));
            qAirline.Enqueue(new Airline(4, "Pakistan International Airlines", "Boeing 737", 50, "Daal Makhani"));

            var names = from q in qAirline
                        select q.Name;
            listAirline.DataContext = names;

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if ((tbName.Name == "" || tbSeats.Text == "") || (rbUnagi.IsChecked == false && rbKabsa.IsChecked == false &&
                rbMakhani.IsChecked == false && rbPaneer.IsChecked == false  && rbWaldorf.IsChecked == false) ||
                (rb787.IsChecked == false && rb767.IsChecked == false && rb747.IsChecked == false && rb737.IsChecked == false
                && rb727.IsChecked == false))
            {
                MessageBox.Show("No text box can be empty and a radio button must be selected for meals and airline", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
         {
                //for meals 
                if (rbUnagi.IsChecked == true)
                {
                    mealThing = "Unagi Roll";
                }
                else if (rbKabsa.IsChecked == true)
                {
                    mealThing = "Shrimp Kabsa";
                }
                else if (rbWaldorf.IsChecked == true)
                {
                    mealThing = "Waldorf Salad";
                }
                else if (rbPaneer.IsChecked == true)
                {
                    mealThing = "Shahi Paneer";
                }
                else if (rbMakhani.IsChecked == true)
                {
                    mealThing = "Daal Makhani";
                }


                //for planes
                if (rb727.IsChecked == true)
                {
                    flightThing = "Boeing 727";
                }
                else if (rb737.IsChecked == true)
                {
                    flightThing = "Boeing 737";
                }
                else if (rb747.IsChecked == true)
                {
                    flightThing = "Boeing 747";
                }
                else if (rb767.IsChecked == true)
                {
                    flightThing = "Boeing 767";
                }
                else if (rb787.IsChecked == true)
                {
                    flightThing = "Boeing 787";
                }

                qAirline.Enqueue(new Airline(qAirline.Count, tbName.Text, flightThing, int.Parse(tbSeats.Text), mealThing));

                var names = from q in qAirline
                            select q.Name;
                listAirline.DataContext = names;
            }

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var list = qAirline.ToList();
            int airNum;
            bool checkInt = int.TryParse(tbSeats.Text, out airNum);


            if ((tbName.Name == "" || tbSeats.Text == "") || (rbUnagi.IsChecked == false && rbKabsa.IsChecked == false &&
                rbMakhani.IsChecked == false && rbPaneer.IsChecked == false && rbWaldorf.IsChecked == false) ||
                (rb787.IsChecked == false && rb767.IsChecked == false && rb747.IsChecked == false && rb737.IsChecked == false
                && rb727.IsChecked == false))
            {
                MessageBox.Show("No text box can be empty and a radio button must be selected for meals and airline", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                if ((listAirline.SelectedIndex >= 0) && (checkInt))
                {
                    Airline c = new Airline(listAirline.SelectedIndex, tbName.Text, flightThing, int.Parse(tbSeats.Text), mealThing);
                    list[listAirline.SelectedIndex] = c;

                    var queue = new Queue<Airline>(list);

                    var names = from q in queue
                                select q.Name;
                    listAirline.DataContext = names;

                }
            }
        }

        private void listAirline_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list = qAirline.ToList();
            var queue = new Queue<Airline>(list);

            int i = listAirline.SelectedIndex;
            var selectedAirline = from lis in list
                                   where lis.ID == i
                                   select lis;

            foreach (var s in selectedAirline)
            {
                string seatsNum = s.SeatsAvailable.ToString();

                tbName.Text = s.Name;
                tbSeats.Text = seatsNum;

                if(s.MealAvailable.Equals("Unagi Roll"))
                {
                    rbUnagi.IsChecked = true;
                }
                else if (s.MealAvailable.Equals("Shrimp Kabsa"))
                {
                    rbKabsa.IsChecked = true;
                }
                else if (s.MealAvailable.Equals("Waldorf Salad"))
                {
                    rbWaldorf.IsChecked = true;
                }
                else if (s.MealAvailable.Equals("Daal Makhani"))
                {
                    rbMakhani.IsChecked = true;
                }
                else if (s.MealAvailable.Equals("Shahi Paneer"))
                {
                    rbPaneer.IsChecked = true;
                }

                //for planes
                if(s.Airplane.Equals("Boeing 727"))
                {
                    rb727.IsChecked = true;
                }
                else if (s.Airplane.Equals("Boeing 737"))
                {
                    rb737.IsChecked = true;
                }
                else if (s.Airplane.Equals("Boeing 747"))
                {
                    rb747.IsChecked = true;
                }
                else if (s.Airplane.Equals("Boeing 767"))
                {
                    rb767.IsChecked = true;
                }
                else if (s.Airplane.Equals("Boeing 787"))
                {
                    rb787.IsChecked = true;
                }
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var list = qAirline.ToList();
            
            list.RemoveAt(listAirline.SelectedIndex);

            for (int i = 0; i < list.Count; i++)
            {
                list[i].ID = i;
            }

            var queue = new Queue<Airline>(list);

            var names = from q in queue
                        select q.Name;
            listAirline.DataContext = names;

        }

        private void menHelp_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow c = new HelpWindow();
            c.ShowDialog();
        }

        private void menAdd_Click(object sender, RoutedEventArgs e)
        {
            int airNum;
            bool checkInt = int.TryParse(tbSeats.Text, out airNum);

            if ((tbName.Name == "" || tbSeats.Text == "") || (rbUnagi.IsChecked == false && rbKabsa.IsChecked == false &&
               rbMakhani.IsChecked == false && rbPaneer.IsChecked == false && rbWaldorf.IsChecked == false) ||
               (rb787.IsChecked == false && rb767.IsChecked == false && rb747.IsChecked == false && rb737.IsChecked == false
               && rb727.IsChecked == false))
            {
                MessageBox.Show("No text box can be empty and a radio button must be selected for meals and airline", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (checkInt)
            {
                //for meals 
                if (rbUnagi.IsChecked == true)
                {
                    mealThing = "Unagi Roll";
                }
                else if (rbKabsa.IsChecked == true)
                {
                    mealThing = "Shrimp Kabsa";
                }
                else if (rbWaldorf.IsChecked == true)
                {
                    mealThing = "Waldorf Salad";
                }
                else if (rbPaneer.IsChecked == true)
                {
                    mealThing = "Shahi Paneer";
                }
                else if (rbMakhani.IsChecked == true)
                {
                    mealThing = "Daal Makhani";
                }


                //for planes
                if (rb727.IsChecked == true)
                {
                    flightThing = "Boeing 727";
                }
                else if (rb737.IsChecked == true)
                {
                    flightThing = "Boeing 737";
                }
                else if (rb747.IsChecked == true)
                {
                    flightThing = "Boeing 747";
                }
                else if (rb767.IsChecked == true)
                {
                    flightThing = "Boeing 767";
                }
                else if (rb787.IsChecked == true)
                {
                    flightThing = "Boeing 787";
                }

                qAirline.Enqueue(new Airline(qAirline.Count, tbName.Text, flightThing, int.Parse(tbSeats.Text), mealThing));

                var names = from q in qAirline
                            select q.Name;
                listAirline.DataContext = names;
            }

        }

        private void menUpdate_Click(object sender, RoutedEventArgs e)
        {
            var list = qAirline.ToList();
            int airNum;
            bool checkInt = int.TryParse(tbSeats.Text, out airNum);
            

            if ((tbName.Name == "" || tbSeats.Text == "") || (rbUnagi.IsChecked == false && rbKabsa.IsChecked == false &&
                rbMakhani.IsChecked == false && rbPaneer.IsChecked == false && rbWaldorf.IsChecked == false) ||
                (rb787.IsChecked == false && rb767.IsChecked == false && rb747.IsChecked == false && rb737.IsChecked == false
                && rb727.IsChecked == false))
            {
                MessageBox.Show("No text box can be empty and a radio button must be selected for meals and airline", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else 
            {
                if ((listAirline.SelectedIndex >= 0)&&(checkInt))
                {
                    Airline c = new Airline(listAirline.SelectedIndex, tbName.Text, flightThing, int.Parse(tbSeats.Text), mealThing);
                    list[listAirline.SelectedIndex] = c;

                    var queue = new Queue<Airline>(list);

                    var names = from q in queue
                                select q.Name;
                    listAirline.DataContext = names;
                }

                else
                {
                    MessageBox.Show("Make sure you select an index in range, and make sure you type in a number for seats", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void menDelete_Click(object sender, RoutedEventArgs e)
        {
            var list = qAirline.ToList();

            list.RemoveAt(listAirline.SelectedIndex);

            for (int i = 0; i < list.Count; i++)
            {
                list[i].ID = i;
            }

            var queue = new Queue<Airline>(list);

            var names = from q in queue
                        select q.Name;
            listAirline.DataContext = names;

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

