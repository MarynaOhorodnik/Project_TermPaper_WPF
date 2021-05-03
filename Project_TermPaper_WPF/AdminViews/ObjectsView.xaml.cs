using MySql.Data.MySqlClient;
using System;
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
    /// Interaction logic for ObjectsView.xaml
    /// </summary>
    public partial class ObjectsView : UserControl
    {
        public ObjectsView()
        {
            InitializeComponent();

            DB db = new DB();

            Tuple<DataTable, bool> result = db.SelectTable("SELECT * FROM `objects`");
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

        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {

            int id = Convert.ToInt32(((Button)(sender)).Tag);

            ChangeObject changeObject = new ChangeObject(id);
            changeObject.Show();


        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            DB db = new DB();

            Tuple<DataTable, bool> result = db.SelectTable("SELECT * FROM `objects`");
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
