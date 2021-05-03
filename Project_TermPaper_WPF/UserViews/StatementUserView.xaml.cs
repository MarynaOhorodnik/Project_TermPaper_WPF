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
    /// Interaction logic for StatementUserView.xaml
    /// </summary>
    public partial class StatementUserView : UserControl
    {

        public StatementUserView()
        {
            InitializeComponent();
        }

        private void SearchStatementObjectsUser_Click(object sender, RoutedEventArgs e)
        {
            string statement = comboBoxStatementSearch.Text;
            string login_user = _CurrentUser.User.Login;
            string str_command;

            if (statement == "Усі")
            {
                str_command = "SELECT * FROM `objects` WHERE `client` = @login";
            }
            else
            {
                str_command = "SELECT * FROM `objects` WHERE `statement` = @statement AND `client` = @login";
            }

            DB db = new DB();

            ArrayList list_str = new ArrayList() { "@statement", "@login" };
            ArrayList list_var = new ArrayList() { statement, login_user };

            Tuple<DataTable, bool> result = db.SelectTable(str_command, list_str, list_var);
            DataTable table = result.Item1;

            statementObjectsListSearch.ItemsSource = table.DefaultView;
        }
    }
}
