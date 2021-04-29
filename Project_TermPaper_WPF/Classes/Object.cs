using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TermPaper_WPF
{
    class Object
    {
        private int id;

        private string type, location, address, number_rooms, floor, square, price, rent_sale, client, statement;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Number_rooms
        {
            get { return number_rooms; }
            set { number_rooms = value; }
        }

        public string Floor
        {
            get { return floor; }
            set { floor = value; }
        }

        public string Square
        {
            get { return square; }
            set { square = value; }
        }

        public string Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Rent_sale
        {
            get { return rent_sale; }
            set { rent_sale = value; }
        }

        public string Client
        {
            get { return client; }
            set { client = value; }
        }

        public string Statement
        {
            get { return statement; }
            set { statement = value; }
        }
    }
}
