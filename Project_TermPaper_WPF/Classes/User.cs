using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TermPaper_WPF
{
    class User
    {
        public int id;

        public string login, surname, name, email, pass;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        public User() { }

        public User(int id, string login, string surname, string name, string email, string pass)
        {
            this.id = id;
            this.login = login;
            this.surname = surname;
            this.name = name;
            this.email = email;
            this.pass = pass;
        }
    }
}
