using MySql.Data.MySqlClient;
using Project_TermPaper_WPF.Classes;
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
    /// Interaction logic for SearchObjectsUserView.xaml
    /// </summary>
    public partial class SearchObjectsUserView : UserControl
    {

        public SearchObjectsUserView()
        {
            InitializeComponent();
        }

        private void SearchObjectsUser_Click(object sender, RoutedEventArgs e)
        {
            string type = comboBoxTypeSearch.Text;
            string rent_sale = comboBoxRentSaleSearch.Text;
            string str_command;

            if (type != "" && rent_sale == "")
            {
                str_command = "SELECT * FROM `objects` WHERE `type` = @type AND `client` is null";
            }
            else if (type == "" && rent_sale != "")
            {
                str_command = "SELECT * FROM `objects` WHERE `rent_sale` = @rent_sale AND `client` is null";
            }
            else
            {
                str_command = "SELECT * FROM `objects` WHERE `type` = @type AND `rent_sale` = @rent_sale AND `client` is null";
            }

            DB db = new DB();

            ArrayList list_str = new ArrayList() { "@type", "@rent_sale" };
            ArrayList list_var = new ArrayList() { type, rent_sale };

            Tuple<DataTable, bool> result = db.SelectTable(str_command, list_str, list_var);
            DataTable table = result.Item1;

            objectsListSearch.ItemsSource = table.DefaultView;
        }

        private void buttonCreateStatement_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultMes = MessageBox.Show("Ви бажаєте оформити заявку?", "Підтвердження", MessageBoxButton.YesNo);
            switch (resultMes)
            {
                case MessageBoxResult.Yes:

                    DB db = new DB();

                    int id = Convert.ToInt32(((Button)(sender)).Tag);

                    string str_command2 = "UPDATE `objects` SET `client` = @client, `statement` = @statement WHERE `objects`.`id` = @id";

                    ArrayList list_str2 = new ArrayList() { "@id", "@client", "@statement" };
                    ArrayList list_var2 = new ArrayList() { id, _CurrentUser.User.Login, "Створено" };

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
