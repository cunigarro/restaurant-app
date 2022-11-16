using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogicDBCUD
{
    public class Menu_Dish
    {
        public string idMenu { get; set; }
        public string idDish { get; set; }

        private string commandString;

        public void getDishWithMenuId(int menuId)
        {
            string queryString;
            queryString = @"SELECT * FROM Menu_Dish WHERE ID_Menu = " + menuId + ";";
            commandString = queryString;
        }

        public string readCommandString()
        {
            return this.commandString;
        }
    }
}
