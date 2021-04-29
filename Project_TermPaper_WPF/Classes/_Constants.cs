using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TermPaper_WPF
{
    public static class _Constants
    {
        private static string current_login_user;

        public static string Current_login_user
        {
            get { return current_login_user; }
            set { current_login_user = value; }
        }
    }
}
