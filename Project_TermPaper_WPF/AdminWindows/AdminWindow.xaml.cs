using MySql.Data.MySqlClient;
using Project_TermPaper_WPF.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Project_TermPaper_WPF
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }


        private void UserView_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new UsersViewModel();
        }

        private void AddObjectsView_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new AddObjectsModel();
        }

        private void ObjectsView_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ObjectsViewModel();
        }

        private void SearchObjectsView_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new SearchObjectsViewModel();
        }

        private void StatementView_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new StatementViewModel();
        }

        private void ExitAdmin_Click(object sender, RoutedEventArgs e)
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
