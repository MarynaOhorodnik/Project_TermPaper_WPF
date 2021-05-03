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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using Project_TermPaper_WPF.Classes;

namespace Project_TermPaper_WPF
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();

            if (login.Length == 0)
            {
                fillTextBox(textBoxLogin, "Обов'язково до заповнення");
            }
            else
            {
                clearTextBox(textBoxLogin);
            }

            if (pass.Length == 0)
            {
                fillTextBox(passBox, "Обов'язково до заповнення");
            }
            else
            {
                clearTextBox(passBox);
            }

            if (textBoxLogin.ToolTip is null && passBox.ToolTip is null)
            {
                string str_command = "SELECT * FROM `users` WHERE `login` = @login AND `pass` = @pass";

                DB db = new DB();

                ArrayList list_str = new ArrayList() { "@login", "@pass" };
                ArrayList list_var = new ArrayList() { login, pass };

                Tuple<DataTable, bool> result = db.SelectTable(str_command, list_str, list_var);
                DataTable table = result.Item1;
                bool flag = result.Item2;


                if (table.Rows.Count > 0)
                {
                    _CurrentUser.NewUser(login);
                    UserWindow userWindow = new UserWindow();
                    userWindow.Show();
                    this.Hide();
                }
                else if (login == "admin" && pass == "admin" && flag)
                {
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    this.Hide();
                }
                else if (flag)
                {
                    MessageBox.Show("Логін або пароль введенні неправильно. Спробуйте ще раз.");
                }
            }

        }

        private void Button_Reg_Window_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }

        public void clearTextBox(TextBox textbox)
        {
            textbox.ToolTip = null;
            textbox.Background = Brushes.Transparent;
        }
        public void clearTextBox(PasswordBox textbox)
        {
            textbox.ToolTip = null;
            textbox.Background = Brushes.Transparent;
        }

        public void fillTextBox(TextBox textbox, string str)
        {
            textbox.ToolTip = str;
            textbox.Background = Brushes.MistyRose;
        }
        public void fillTextBox(PasswordBox textbox, string str)
        {
            textbox.ToolTip = str;
            textbox.Background = Brushes.MistyRose;
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            this.Hide();
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

    }
}