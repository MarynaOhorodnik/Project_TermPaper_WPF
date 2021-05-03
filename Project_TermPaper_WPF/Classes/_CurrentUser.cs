using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TermPaper_WPF.Classes
{
    public static class _CurrentUser
    {
        private static User user;

        public static User User
        {
            get { return user; }
            set { user = value; }
        }

        public static void NewUser(string login_user)
        {
            string str_command = "SELECT * FROM `users` WHERE `login` = @login";
            DB db = new DB();

            ArrayList list_str = new ArrayList() { "@login" };
            ArrayList list_var = new ArrayList() {login_user };

            Tuple<DataTable, bool> result = db.SelectTable(str_command, list_str, list_var);
            DataTable table = result.Item1;

            int id = Convert.ToInt32(table.Rows[0][0]);
            string login = table.Rows[0][1].ToString();
            string surname = table.Rows[0][2].ToString();
            string name = table.Rows[0][3].ToString();
            string email = table.Rows[0][4].ToString();
            string pass = table.Rows[0][5].ToString();

            user = new User(id, login, surname, name, email, pass);
        }
    }
}
