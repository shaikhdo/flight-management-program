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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private List<Customer> customers = new List<Customer>();

        public CustomerWindow()
        {
            InitializeComponent();

            customers.Add(new Customer(0, "Jonathan Joestar", "12 Angel St", "jonny@jojo.com", "123-4567"));
            customers.Add(new Customer(1, "Speedwagon", "45 Ogre St", "iluJojo@jojo.com", "459-5656"));
            customers.Add(new Customer(2, "Will Zeppeli", "123 Italian Street", "ripple@jojo.com", "889-4930"));
            customers.Add(new Customer(3, "Joeseph Joestar", "578 London Street", "jojo@jojo.com", "666-6666"));
            customers.Add(new Customer(4, "Jotaro Joestar", "35 Japan Street", "jotaro@jojo.com", "454-4545"));

            var names = from cus in customers
            select cus.Name;
            listCustomer.DataContext = names;
           
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(tbName.Text =="" || tbPhone.Text == "" || tbAddress.Text =="" || tbEmail.Text == "")
            {
                MessageBox.Show("No text box can be empty", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                customers.Add(new Customer(customers.Count, tbName.Text, tbAddress.Text, tbEmail.Text, tbPhone.Text));

                var names = from cus in customers
                            select cus.Name;
                listCustomer.DataContext = names;
            }

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            if (tbName.Text == "" || tbPhone.Text == "" || tbAddress.Text == "" || tbEmail.Text == "")
            {
                MessageBox.Show("No text box can be empty", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Customer c = new Customer(listCustomer.SelectedIndex, tbName.Text, tbAddress.Text, tbEmail.Text, tbPhone.Text);
                customers[listCustomer.SelectedIndex] = c;

                var names = from cus in customers
                            select cus.Name;
                listCustomer.DataContext = names;
            }
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listCustomer.SelectedIndex >= 0)
            {
                customers.RemoveAt(listCustomer.SelectedIndex);

                for (int i = 0; i < customers.Count; i++)
                {
                    customers[i].ID = i;
                }

                var names = from cus in customers
                            select cus.Name;
                listCustomer.DataContext = names;
            }
            else
            {
                MessageBox.Show("Your index is out of bounds", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void listCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = listCustomer.SelectedIndex;
            var selectedCustomer = from cus in customers
                                   where cus.ID == i
                                   select cus;

            foreach (var s in selectedCustomer)
            {
                tbName.Text = s.Name;
                tbAddress.Text = s.Address;
                tbEmail.Text = s.Email;
                tbPhone.Text = s.Phone;
            }

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

        private void menAdd_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text == "" || tbPhone.Text == "" || tbAddress.Text == "" || tbEmail.Text == "")
            {
                MessageBox.Show("No text box can be empty", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                customers.Add(new Customer(customers.Count, tbName.Text, tbAddress.Text, tbEmail.Text, tbPhone.Text));

                var names = from cus in customers
                            select cus.Name;
                listCustomer.DataContext = names;
            }
        }

        private void menUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text == "" || tbPhone.Text == "" || tbAddress.Text == "" || tbEmail.Text == "")
            {
                MessageBox.Show("No text box can be empty", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Customer c = new Customer(listCustomer.SelectedIndex, tbName.Text, tbAddress.Text, tbEmail.Text, tbPhone.Text);
                customers[listCustomer.SelectedIndex] = c;

                var names = from cus in customers
                            select cus.Name;
                listCustomer.DataContext = names;
            }
        }

        private void menDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listCustomer.SelectedIndex >= 0)
            {
                customers.RemoveAt(listCustomer.SelectedIndex);

                for (int i = 0; i < customers.Count; i++)
                {
                    customers[i].ID = i;
                }

                var names = from cus in customers
                            select cus.Name;
                listCustomer.DataContext = names;
            }
            else
            {
                MessageBox.Show("Your index is out of bounds", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void menHelp_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow h = new HelpWindow();
            h.ShowDialog();
        }
    }
}
