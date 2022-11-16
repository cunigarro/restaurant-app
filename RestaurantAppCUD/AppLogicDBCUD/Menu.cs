using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogicDBCUD
{
    public class Menu
    {
        public string name { get; set; }
        public string description { get; set; }

        private string commandString;

        public static DataTable selectedItems { get; set; }

        public string requestAMenu(int id)
        {
            return @"SELECT * FROM Menu WHERE ID_Menu=" + id;
        }

        public string readCommandString()
        {
            return this.commandString;
        }
    }
}
