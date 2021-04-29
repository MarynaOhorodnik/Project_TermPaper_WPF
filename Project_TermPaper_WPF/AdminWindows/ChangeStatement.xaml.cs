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
using System.Windows.Shapes;

namespace Project_TermPaper_WPF
{
    /// <summary>
    /// Interaction logic for ChangeStatement.xaml
    /// </summary>
    public partial class ChangeStatement : Window
    {
        public ChangeStatement(int id)
        {
            InitializeComponent();

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `objects` WHERE `id` = @id", db.getConnection());
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;


            adapter.SelectCommand = command;
            adapter.Fill(table);

            textBoxId.Text = table.Rows[0][0].ToString();
            comboBoxType.Text = table.Rows[0][1].ToString();
            textBoxLocation.Text = table.Rows[0][2].ToString();
            textBoxAddress.Text = table.Rows[0][3].ToString();
            textBoxNumberRooms.Text = table.Rows[0][4].ToString();
            textBoxFloor.Text = table.Rows[0][5].ToString();
            textBoxSquare.Text = table.Rows[0][6].ToString();
            textBoxPrice.Text = table.Rows[0][7].ToString();
            comboBoxRentSale.Text = table.Rows[0][8].ToString();
            textBoxClient.Text = table.Rows[0][9].ToString();
            comboBoxStatement.Text = table.Rows[0][10].ToString();
        }

        private void ButtonStatement_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(textBoxId.Text);

            string statement = comboBoxStatement.Text;

            DB db = new DB();

            string str_command = "UPDATE `objects` SET `statement` = @statement WHERE `objects`.`id` = @id";

            ArrayList list_str = new ArrayList() { "@id", "@statement" };
            ArrayList list_var = new ArrayList() { id, statement };

            bool flag = db.EditTable(str_command, list_str, list_var);


            if (flag)
            {
                MessageBox.Show("Дані заявки було оновлено.");
                this.Hide();
            }

            else
            {
                MessageBox.Show("Дані заявки не було оновлено. Спробуйте ще раз.");
            }

        }
    }
}
