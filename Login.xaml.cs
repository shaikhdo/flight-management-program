using System;
using System.Collections.Generic;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private string user = "Doaa";
        private string pass = "Shaikh";

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if((user == tbUser.Text)&&(pass == pbPass.Password))
            {
                MainWindow m = new MainWindow();
                m.Background = Brushes.Azure;
                m.Title = "Welcome";
                m.ShowDialog(); //launch new window, but still be able to see the other one
            }
            else
            {
                MessageBox.Show("Incorrect Username Or Password", "Login Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
