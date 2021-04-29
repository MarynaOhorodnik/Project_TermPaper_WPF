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
    /// Interaction logic for SearchObjectsView.xaml
    /// </summary>
    public partial class SearchObjectsView : UserControl
    {
        public SearchObjectsView()
        {
            InitializeComponent();
        }

        private void SearchObjects_Click(object sender, RoutedEventArgs e)
        {
            string type = comboBoxTypeSearch.Text;
            string rent_sale = comboBoxRentSaleSearch.Text;
            string statement = comboBoxStatementObjectSearch.Text;
            string str_command;

            if(type != "" && rent_sale == "" && statement =="")
            {
                str_command = "SELECT * FROM `objects` WHERE `type` = @type";
            }
            else if(type == "" && rent_sale != "" && statement == "")
            {
                str_command = "SELECT * FROM `objects` WHERE `rent_sale` = @rent_sale";
            }
            else if (type == "" && rent_sale == "" && statement != "")
            {
                str_command = $"SELECT * FROM `objects` WHERE {cmd_statement(statement)}";
            }
            else if (type == "" && rent_sale != "" && statement != "")
            {
                str_command = $"SELECT * FROM `objects` WHERE `rent_sale` = @rent_sale AND {cmd_statement(statement)}";
            }
            else if (type != "" && rent_sale == "" && statement != "")
            {
                str_command = $"SELECT * FROM `objects` WHERE `type` = @type AND {cmd_statement(statement)}";
            }
            else if (type != "" && rent_sale != "" && statement == "")
            {
                str_command = "SELECT * FROM `objects` WHERE `type` = @type AND `rent_sale` = @rent_sale";
            }
            else
            {
                str_command = $"SELECT * FROM `objects` WHERE `type` = @type AND `rent_sale` = @rent_sale AND {cmd_statement(statement)}";
            }

            DB db = new DB();

            ArrayList list_str = new ArrayList() { "@type", "@rent_sale", "@statement" };
            ArrayList list_var = new ArrayList() { type, rent_sale, statement };

            Tuple<DataTable, bool> result = db.SelectTable(str_command, list_str, list_var);
            DataTable table = result.Item1;

            objectsListSearch.ItemsSource = table.DefaultView;
        }

        private void buttonChangeSearch_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(((Button)(sender)).Tag);

            ChangeObject changeObject = new ChangeObject(id);
            changeObject.Show();
        }

        public string cmd_statement(string statement)
        {
            if(statement == "Без заявки")
            {
                return "`statement` IS NULL";
            }
            else if(statement == "Усі заявки")
            {
                return "`statement` IS NOT NULL";
            }
            else
            {
                return "`statement` = @statement";
            }
        }
    }
}
