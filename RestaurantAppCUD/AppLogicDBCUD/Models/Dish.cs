using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogicDBCUD.Models
{
    public class Dish
    {
        public string name { get; set; }
        public string description { get; set; }

        private string commandString;

        public string requestADish(int id)
        {
            return @"SELECT * FROM Dish WHERE ID_Dish=" + id;
        }

        public string requestAlDishes()
        {
            return @"SELECT * FROM Dish";
        }

        public string readCommandString()
        {
            return commandString;
        }
    }
}
