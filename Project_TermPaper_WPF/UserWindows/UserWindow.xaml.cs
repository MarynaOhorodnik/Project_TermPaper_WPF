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

            User user = CurrentUser();

            string login = user.Login;
            string surname = user.Surname;
            string name = user.Name;

            UserLogin.Content = "Логін: " + login;
            UserHello.Content = "Клієнт: \n" + surname + "\n" + name;
        }

        private User CurrentUser()
        {
            string str_command = "SELECT * FROM `users` WHERE `login` = @login";
            DB db = new DB();

            ArrayList list_str = new ArrayList() { "@login" };
            ArrayList list_var = new ArrayList() { _Constants.Current_login_user };

            Tuple<DataTable, bool> result = db.SelectTable(str_command, list_str, list_var);
            DataTable table = result.Item1;

            User user = new User();
            user.Id = (int)table.Rows[0][0];
            user.Login = table.Rows[0][1].ToString();
            user.Surname = table.Rows[0][2].ToString();
            user.Name = table.Rows[0][3].ToString();
            user.Pass = table.Rows[0][4].ToString();

            return user;
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
