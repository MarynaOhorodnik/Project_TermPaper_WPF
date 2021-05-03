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
    /// Interaction logic for ObjectsUserView.xaml
    /// </summary>
    public partial class ObjectsUserView : UserControl
    {

        public ObjectsUserView()
        {
            InitializeComponent();

            DB db = new DB();

            Tuple<DataTable, bool> result = db.SelectTable("SELECT * FROM `objects` WHERE `client` is null");
            DataTable table = result.Item1;

            objectsList.ItemsSource = table.DefaultView;

            if (table.Rows.Count == 0)
            {
                ResltTextBlock.Text = "Немає результатів";
            }
            else
            {
                ResltTextBlock.Text = default;
            }
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

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            DB db = new DB();

            Tuple<DataTable, bool> result = db.SelectTable("SELECT * FROM `objects` WHERE `client` is null");
            DataTable table = result.Item1;

            objectsList.ItemsSource = table.DefaultView;

            if (table.Rows.Count == 0)
            {
                ResltTextBlock.Text = "Немає результатів";
            }
            else
            {
                ResltTextBlock.Text = default;
            }
        }
    }
}
