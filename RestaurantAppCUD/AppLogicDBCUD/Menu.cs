using System;
using System.Collections.Generic;
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

        public string requestAMenu(int id)
        {
            return @"SELECT * FROM Menu";
        }

        public string readCommandString()
        {
            return this.commandString;
        }
    }
}
