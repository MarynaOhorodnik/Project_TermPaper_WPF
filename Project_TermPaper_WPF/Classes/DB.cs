using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project_TermPaper_WPF
{
    class DB
    {
        MySqlConnection connection = new MySqlConnection("server=localhost; port=3306; username=root; password=root; database=db_project_termpaper");

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();

        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();

        }

        public MySqlConnection getConnection()
        {
            return connection;
        }

        public Tuple<DataTable, bool> SelectTable(string str_command)
        {
            DataTable table = new DataTable();

            bool flag = true;

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand(str_command, this.getConnection());


                adapter.SelectCommand = command;
                adapter.Fill(table);
            }

            catch
            {
                MessageBox.Show("Виникли проблеми з підключенням бази даних. Перевірте з'єднання.");
                flag = false;
            }

            return new Tuple<DataTable, bool>(table, flag);
        }

        public Tuple<DataTable, bool> SelectTable(string str_command, ArrayList list_str, ArrayList list_var)
        {
            DataTable table = new DataTable();

            int s = 0;
            int v = 0;
            bool flag =true;

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand(str_command, this.getConnection());
                for (int i = 0; i < list_str.Count; i++)
                {
                    command.Parameters.Add($"{list_str[s]}", MySqlDbType.VarChar).Value = list_var[v];
                    s += 1;
                    v += 1;
                }

                adapter.SelectCommand = command;
                adapter.Fill(table);
            }

            catch
            {
                MessageBox.Show("Виникли проблеми з підключенням бази даних. Перевірте з'єднання.");
                flag = false;
            }


            return new Tuple<DataTable, bool>(table, flag);
        }

        public bool EditTable(string str_command, ArrayList list_str, ArrayList list_var)
        {
            bool flag = true;

            int s = 0;
            int v = 0;

            try
            {
                MySqlCommand command = new MySqlCommand(str_command, this.getConnection());

                for (int i = 0; i < list_str.Count; i++)
                {
                    command.Parameters.Add($"{list_str[s]}", MySqlDbType.VarChar).Value = list_var[v];
                    s += 1;
                    v += 1;
                }

                this.openConnection();

                command.ExecuteNonQuery();

                this.closeConnection();
            }

            catch
            {
                MessageBox.Show("Виникли проблеми з підключенням бази даних. Перевірте з'єднання.");
                flag = false;
            }

            return flag;

        }

    }
}
