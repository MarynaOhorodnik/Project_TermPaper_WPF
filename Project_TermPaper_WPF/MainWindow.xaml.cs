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

namespace Project_TermPaper_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string surname = textBoxSurname.Text.Trim();
            string name = textBoxName.Text.Trim();
            string pass1 = passBox1.Password.Trim();
            string pass2 = passBox2.Password.Trim();
            string email = textBoxEmail.Text.Trim();

            if (login.Length < 5)
            {
                fillTextBox(textBoxLogin, "Мінімальна довжина логіну - 5 символів");
            }
            else
            {
                clearTextBox(textBoxLogin);

                if(!login.All(c => char.IsLetterOrDigit(c) || c == '_'))
                {
                    fillTextBox(textBoxLogin, "Логін повинен містити лише букви, цифри та символ _ ");
                }
                else
                {
                    clearTextBox(textBoxLogin);
                    if (checkUserLogin() || login == "admin")
                    {
                        fillTextBox(textBoxLogin, "Такий логін уже зареєстрований. Створіть інший");
                    }
                    else
                    {
                        clearTextBox(textBoxLogin);
                    }
                }
            }

            if(surname.Length < 2)
            {
                fillTextBox(textBoxSurname, "Мінімальна довжина прізвища - 2 символи");
            }
            else
            {
                clearTextBox(textBoxSurname);
                if (!surname.All(c => char.IsLetter(c)))
                {
                    fillTextBox(textBoxSurname, "Прізвище повинно містити лише літери");
                }
                else
                {
                    clearTextBox(textBoxSurname);
                }
            }

            if (name.Length < 2)
            {
                fillTextBox(textBoxName, "Мінімальна довжина ім'я - 2 символи");
            }
            else
            {
                clearTextBox(textBoxName);
                if (!name.All(c => char.IsLetter(c)))
                {
                    fillTextBox(textBoxName, "Ім'я повинно містити лише літери");
                }
                else
                {
                    clearTextBox(textBoxName);
                }
            }

            if (pass1.Length < 5)
            {
                fillTextBox(passBox1, "Мінімальна довжина паролю - 5 символів");
            }
            else
            {
                clearTextBox(passBox1);
                if (pass2 != pass1)
                {
                    fillTextBox(passBox2, "Паролі не збігаються");
                }
                else
                {
                    clearTextBox(passBox2);
                }
            }

            if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                fillTextBox(textBoxEmail, "Некоректне значення");
            }
            else
            {
                clearTextBox(textBoxEmail);
                if (checkUserEmail())
                {
                    fillTextBox(textBoxEmail, "Такий email уже зареєстрований. Використайте інший");
                }
                else
                {
                    clearTextBox(textBoxEmail);
                }
            }


            if (textBoxLogin.ToolTip is null && textBoxSurname.ToolTip is null && textBoxName.ToolTip is null && textBoxEmail.ToolTip is null && 
                passBox1.ToolTip is null && passBox2.ToolTip is null)
            {
                DB db = new DB();
                string str_command = "INSERT INTO `users` (`login`, `surname`, `name`, `email`, `pass`) VALUES (@login, @surname, @name, @email, @pass)";
                
                ArrayList list_str = new ArrayList() { "@login", "@surname", "@name", "@email", "@pass" };
                ArrayList list_var = new ArrayList() { login, surname, name, email, pass1 };

                bool flag = db.EditTable(str_command, list_str, list_var);


                if (flag)
                {
                    MessageBox.Show("Акаунт було створено.");
                    AuthWindow authWindow = new AuthWindow();
                    authWindow.Show();
                    Hide();
                }

                else
                {
                    MessageBox.Show("Акаунт не було створено. Спробуйте ще раз.");
                }
                
            }

        }

        private void Button_Auth_Window_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();
        }

        public Boolean checkUserLogin()
        {
            string str_command = "SELECT * FROM `users` WHERE `login` = @login";

            DB db = new DB();

            ArrayList list_str = new ArrayList() { "@login" };
            ArrayList list_var = new ArrayList() { textBoxLogin.Text };

            Tuple<DataTable, bool> result = db.SelectTable(str_command, list_str, list_var);
            DataTable table = result.Item1;


            if (table.Rows.Count > 0)
            {
                return true;
            }

            else
            {
                return false;
            }
                
        }

        public Boolean checkUserEmail()
        {
            string str_command = "SELECT * FROM `users` WHERE `email` = @email";

            DB db = new DB();

            ArrayList list_str = new ArrayList() { "@email" };
            ArrayList list_var = new ArrayList() { textBoxEmail.Text };

            Tuple<DataTable, bool> result = db.SelectTable(str_command, list_str, list_var);
            DataTable table = result.Item1;

            if (table.Rows.Count > 0)
            {
                return true;
            }

            else
            {
                return false;
            }

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