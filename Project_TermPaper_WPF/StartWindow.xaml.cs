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

namespace Project_TermPaper_WPF
{
    /// <summary>
    /// Interaction logic for StartWindow1.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
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
            else if (type != "" && rent_sale != "")
            {
                str_command = "SELECT * FROM `objects` WHERE `type` = @type AND `rent_sale` = @rent_sale AND `client` is null";
            }
            else
            {
                str_command = "SELECT * FROM `objects` WHERE `client` is null";
            }

            DB db = new DB();

            ArrayList list_str = new ArrayList() { "@type", "@rent_sale" };
            ArrayList list_var = new ArrayList() { type, rent_sale };

            Tuple<DataTable, bool> result = db.SelectTable(str_command, list_str, list_var);
            DataTable table = result.Item1;

            objectsListSearch.ItemsSource = table.DefaultView;

            if (table.Rows.Count == 0)
            {
                ResltTextBlock.Text = "Немає результатів";
            }
            else
            {
                ResltTextBlock.Text = default;
            }
        }

        private void ButtonReg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void ButtonAuth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
