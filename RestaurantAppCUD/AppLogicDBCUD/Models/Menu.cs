using System.Data;

namespace AppLogicDBCUD.Models
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

        public string requestAllMenus()
        {
            return @"SELECT * FROM Menu";
        }

        public string readCommandString()
        {
            return commandString;
        }
    }
}
