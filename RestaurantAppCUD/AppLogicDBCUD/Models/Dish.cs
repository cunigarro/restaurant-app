using AppLogicDBCUD.Services;
using System.Data;
using System.Net;

namespace AppLogicDBCUD.Models
{
    public class Dish
    {
        private string name;

        private string description;
        public string Name { get { return name; } set { name = value; } }
        public string Description { get { return description; } set { description = value; } }

        public DataTable getARegister(int id)
        {
            ConnectionService connectionService = new ConnectionService();
            string queryString = @"SELECT * FROM Dish WHERE ID_Dish=" + id + ";";
            return connectionService.consult(queryString);
        }

        public DataTable getAllRegisters()
        {
            ConnectionService connectionService = new ConnectionService();
            string queryString = @"SELECT * FROM Dish";
            return connectionService.consult(queryString);
        }
    }
}
