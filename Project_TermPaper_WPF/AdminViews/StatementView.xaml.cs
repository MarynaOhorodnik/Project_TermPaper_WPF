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
    /// Interaction logic for StatementView.xaml
    /// </summary>
    public partial class StatementView : UserControl
    {
        public StatementView()
        {
            InitializeComponent();
        }

        private void buttonChangeStatement_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(((Button)(sender)).Tag);

            ChangeStatement changeStatement = new ChangeStatement(id);
            changeStatement.Show();
        }

        private void SearchStatementObjectsUser_Click(object sender, RoutedEventArgs e)
        {
            string statement = comboBoxStatementSearch.Text;
            string str_command;

            if (statement == "Усі")
            {
                str_command = "SELECT * FROM `objects` WHERE `client` is not null";
            }
            else
            {
                str_command = "SELECT * FROM `objects` WHERE `statement` = @statement AND `client` is not null";
            }

            DB db = new DB();
            ArrayList list_str = new ArrayList() { "@statement" };
            ArrayList list_var = new ArrayList() { statement };

            Tuple<DataTable, bool> result = db.SelectTable(str_command, list_str, list_var);
            DataTable table = result.Item1;

            statementObjectsList.ItemsSource = table.DefaultView;

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
