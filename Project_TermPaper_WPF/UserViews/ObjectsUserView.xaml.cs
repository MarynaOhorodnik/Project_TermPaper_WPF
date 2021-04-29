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

namespace Project_TermPaper_WPF.UserViews
{
    /// <summary>
    /// Interaction logic for ObjectsUserView.xaml
    /// </summary>
    public partial class ObjectsUserView : UserControl
    {
        User current_user = new User();

        public ObjectsUserView()
        {
            InitializeComponent();

            DB db = new DB();

            Tuple<DataTable, bool> result = db.SelectTable("SELECT * FROM `objects` WHERE `client` is null");
            DataTable table = result.Item1;

            objectsList.ItemsSource = table.DefaultView;
        }

        private void buttonCreateStatement_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultMes = MessageBox.Show("Ви бажаєте оформити заявку?", "Підтвердження", MessageBoxButton.YesNo);
            switch (resultMes)
            {
                case MessageBoxResult.Yes:

                    string str_command1 = "SELECT * FROM `users` WHERE `login` = @login";
                    DB db = new DB();

                    ArrayList list_str1 = new ArrayList() { "@login" };
                    ArrayList list_var1 = new ArrayList() { _Constants.Current_login_user };

                    Tuple<DataTable, bool> result = db.SelectTable(str_command1, list_str1, list_var1);
                    DataTable table = result.Item1;

                    string user_login = table.Rows[0][1].ToString();

                    int id = Convert.ToInt32(((Button)(sender)).Tag);

                    string str_command2 = "UPDATE `objects` SET `client` = @client, `statement` = @statement WHERE `objects`.`id` = @id";

                    ArrayList list_str2 = new ArrayList() { "@id", "@client", "@statement" };
                    ArrayList list_var2 = new ArrayList() { id, user_login, "Створено" };

                    bool flag = db.EditTable(str_command2, list_str2, list_var2);


                    if (flag)
                    {
                        MessageBox.Show("Заявку створено.");
                    }

                    else
                    {
                        MessageBox.Show("Заявку не було створено. Спробуйте ще раз.");
                    }

                    break;
                
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}
