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
using Session_1.Classes;
using Session_1.Frames;
using Session_1.DataBase;
using Session_1.Properties;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Session_1.Frames
{
    /// <summary>
    /// Логика взаимодействия для Avtorisation.xaml
    /// </summary>
    public partial class Avtorisation : Page
    {
        public Avtorisation()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            AccountYesNo.CheckAccount(Login.Text, Password.Text);
        }

        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Login.Text.Length > 0)
            {
                LoginText.Visibility = Visibility.Hidden;
                Login.Opacity = 1;
            }
            else
            {
                LoginText.Visibility = Visibility.Visible;
                Login.Opacity = 0.5;
            }
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Password.Text.Length > 0)
            {
                PasswordText.Visibility = Visibility.Hidden;
                Password.Opacity = 1;
            }
            else
            {
                PasswordText.Visibility = Visibility.Visible;
                Password.Opacity = 0.5;
            }
        }
    }
}
