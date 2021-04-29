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
    /// Interaction logic for ChangeObject.xaml
    /// </summary>
    public partial class ChangeObject : Window
    {
        public ChangeObject(int id)
        {
            InitializeComponent();

            string str_command = "SELECT * FROM `objects` WHERE `id` = @id";
            DB db = new DB();

            ArrayList list_str = new ArrayList() { "@id" };
            ArrayList list_var = new ArrayList() { id.ToString() };

            Tuple<DataTable, bool> result = db.SelectTable(str_command, list_str, list_var);
            DataTable table = result.Item1;

            textBoxId.Text = table.Rows[0][0].ToString();
            comboBoxTypeChange.Text = table.Rows[0][1].ToString();
            textBoxLocationChange.Text = table.Rows[0][2].ToString();
            textBoxAddressChange.Text = table.Rows[0][3].ToString();
            textBoxNumberRoomsChange.Text = table.Rows[0][4].ToString();
            textBoxFloorChange.Text = table.Rows[0][5].ToString();
            textBoxSquareChange.Text = table.Rows[0][6].ToString();
            textBoxPriceChange.Text = table.Rows[0][7].ToString();
            comboBoxRentSaleChange.Text = table.Rows[0][8].ToString();
        }

        private void ButtonChange_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(textBoxId.Text);

            string location = textBoxLocationChange.Text;
            string address = textBoxAddressChange.Text;
            string number_rooms = textBoxNumberRoomsChange.Text;
            string floor = textBoxFloorChange.Text;
            string square = textBoxSquareChange.Text;
            string price = textBoxPriceChange.Text;
            string type = comboBoxTypeChange.Text;
            string rent_sale = comboBoxRentSaleChange.Text;

            TextBox[] textBoxes = new TextBox[] { textBoxLocationChange, textBoxAddressChange, textBoxNumberRoomsChange, textBoxFloorChange, 
                textBoxSquareChange, textBoxPriceChange };

            ComboBox[] comboBoxes = new ComboBox[] { comboBoxTypeChange, comboBoxRentSaleChange };

            CheckFieldsTextBox(textBoxes);
            CheckFieldsComboBox(comboBoxes);


            if (textBoxLocationChange.ToolTip is null && textBoxAddressChange.ToolTip is null && textBoxNumberRoomsChange.ToolTip is null 
                && textBoxFloorChange.ToolTip is null && textBoxSquareChange.ToolTip is null && textBoxPriceChange.ToolTip is null 
                && comboBoxTypeChange.ToolTip is null && comboBoxRentSaleChange.ToolTip is null)
            {
                DB db = new DB();
                string str_command = "UPDATE `objects` SET `type` = @type, `location` = @location, `address` = @address, `number_rooms` = @number_rooms, " +
                "`floor` = @floor, `square` = @square, `price` = @price, `rent_sale` = @rent_sale WHERE `objects`.`id` = @id";
                ArrayList list_str = new ArrayList() { "@id", "@type", "@location","@address", "@number_rooms", "@floor", "@square", "@price", "@rent_sale" };
                ArrayList list_var = new ArrayList() { id, type, location, address, number_rooms, floor, square, price, rent_sale };

                bool flag = db.EditTable(str_command, list_str, list_var);

                if (flag)
                {
                    MessageBox.Show("Дані було оновлено.");
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Дані не було оновлено. Спробуйте ще раз.");
                }
            }
        }


        public void CheckFieldsTextBox(TextBox[] list)
        {
            int j = 0;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[j].Text.Trim().Length == 0)
                {
                    fillTextBox(list[j], "Обов'язково до заповнення");
                }
                else
                {
                    clearTextBox(list[j]);
                }
                j += 1;
            }
        }

        public void CheckFieldsComboBox(ComboBox[] list)
        {
            int j = 0;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[j].Text.Trim().Length == 0)
                {
                    fillTextBox(list[j], "Обов'язково до заповнення");
                }
                else
                {
                    clearTextBox(list[j]);
                }
                j += 1;
            }
        }

        public void clearTextBox(TextBox textbox)
        {
            textbox.ToolTip = null;
            textbox.Background = Brushes.Transparent;
        }
        public void clearTextBox(ComboBox textbox)
        {
            textbox.ToolTip = null;
            textbox.Background = Brushes.Transparent;
        }

        public void fillTextBox(TextBox textbox, string str)
        {
            textbox.ToolTip = str;
            textbox.Background = Brushes.MistyRose;
        }
        public void fillTextBox(ComboBox textbox, string str)
        {
            textbox.ToolTip = str;
            textbox.Background = Brushes.MistyRose;
        }
    }
}
