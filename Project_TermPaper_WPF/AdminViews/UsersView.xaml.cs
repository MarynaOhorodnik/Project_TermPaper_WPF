using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_TermPaper_WPF.AdminViews
{
    /// <summary>
    /// Interaction logic for UsersView.xaml
    /// </summary>
    public partial class UsersView : UserControl
    {
        public UsersView()
        {
            InitializeComponent();

            DB db = new DB();

            Tuple<DataTable, bool> result = db.SelectTable("SELECT * FROM `users`");
            DataTable table = result.Item1;

            usersList.ItemsSource = table.DefaultView;

        }

        private void SearchUsers_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLoginSearch.Text.Trim();
            string surname = textBoxSurnameSearch.Text.Trim();
            string name = textBoxNameSearch.Text.Trim();
            string str_command;

            if (login != "" && surname == "" && name == "")
            {
                str_command = "SELECT * FROM `users` WHERE `login` LIKE @login";
            }
            else if (login == "" && surname != "" && name == "")
            {
                str_command = "SELECT * FROM `users` WHERE `surname` LIKE @surname";
            }
            else if (login == "" && surname == "" && name != "")
            {
                str_command = "SELECT * FROM `users` WHERE name LIKE @name";
            }
            else if (login == "" && surname != "" && name != "")
            {
                str_command = "SELECT * FROM `users` WHERE `surname` LIKE @surname AND name LIKE @name";
            }
            else if (login != "" && surname == "" && name != "")
            {
                str_command = "SELECT * FROM `users` WHERE `login` LIKE @login AND name LIKE @name";
            }
            else if (login != "" && surname != "" && name == "")
            {
                str_command = "SELECT * FROM `users` WHERE `login` LIKE @login AND `surname` LIKE @surname";
            }
            else
            {
                str_command = "SELECT * FROM `users` WHERE `login` LIKE @login AND `surname` LIKE @surname AND name LIKE @name";
            }

            DB db = new DB();


            ArrayList list_str = new ArrayList() { "@login", "@surname", "@name" };
            ArrayList list_var = new ArrayList() { login + "%", surname + "%", name + "%" };

            Tuple<DataTable, bool> result = db.SelectTable(str_command, list_str, list_var);
            DataTable table = result.Item1;

            usersList.ItemsSource = table.DefaultView;
        }

    }

}
