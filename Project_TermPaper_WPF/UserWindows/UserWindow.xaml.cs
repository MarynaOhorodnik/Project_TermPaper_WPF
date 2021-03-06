using System;
using Project_TermPaper_WPF.UserViewModels;
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
using System.Collections;
using System.Data;
using Project_TermPaper_WPF.Classes;

namespace Project_TermPaper_WPF
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();

            string login = _CurrentUser.User.Login;
            string surname = _CurrentUser.User.Surname;
            string name = _CurrentUser.User.Name;

            UserLogin.Content = "Логін: " + login;
            UserHello.Content = "Клієнт: \n" + surname + "\n" + name;
        }

        private void ObjectsUserView_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ObjectsUserViewModel();
        }

        private void SearchObjectsUserView_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new SearchObjectsUserViewModel();
        }

        private void StatementUserSearch_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new StatementUserViewModel();
        }

        private void ExitUser_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Ви бажаєте вийти з кабінету?", "Підтвердження", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    AuthWindow authWindow = new AuthWindow();
                    authWindow.Show();
                    this.Hide();
                    break;

                case MessageBoxResult.No:
                    break;
            }
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
