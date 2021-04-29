using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
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
    /// Interaction logic for AddObjects.xaml
    /// </summary>
    public partial class AddObjects : UserControl
    {
        public AddObjects()
        {
            InitializeComponent();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            string location = textBoxLocation.Text;
            string address = textBoxAddress.Text;
            string number_rooms = textBoxNumberRooms.Text;
            string floor = textBoxFloor.Text;
            string square = textBoxSquare.Text;
            string price = textBoxPrice.Text;
            string type = comboBoxType.Text;
            string rent_sale = comboBoxRentSale.Text;


            TextBox[] textBoxes = new TextBox[] { textBoxLocation, textBoxAddress, textBoxNumberRooms, textBoxFloor, textBoxSquare, textBoxPrice };

            ComboBox[] comboBoxes = new ComboBox[] { comboBoxType, comboBoxRentSale };

            CheckFieldsTextBox(textBoxes);
            CheckFieldsComboBox(comboBoxes);


            if(textBoxLocation.ToolTip is null && textBoxAddress.ToolTip is null && textBoxNumberRooms.ToolTip is null && textBoxFloor.ToolTip is null 
                && textBoxSquare.ToolTip is null && textBoxPrice.ToolTip is null && comboBoxType.ToolTip is null && comboBoxRentSale.ToolTip is null)
            {
                DB db = new DB();
                string str_command = "INSERT INTO `objects` (`type`, `location`, `address`, `number_rooms`, `floor`, `square`, `price`, `rent_sale`) " +
                    "VALUES (@type, @location, @address, @number_rooms, @floor, @square, @price, @rent_sale)";

                ArrayList list_str = new ArrayList() { "@type", "@location", "@address", "@number_rooms", "@floor", "@square", "@price", "@rent_sale" };
                ArrayList list_var = new ArrayList() { type, location, address, number_rooms, floor, square, price, rent_sale };

                bool flag = db.EditTable(str_command, list_str, list_var);



                if (flag)
                {
                    MessageBox.Show("Дані було збережено.");
                }

                else
                {
                    MessageBox.Show("Дані не було збережено. Спробуйте ще раз.");
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
