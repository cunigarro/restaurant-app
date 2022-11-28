using AppLogicCUD.Services;
using System.Data;
using System.Net;

namespace AppLogicCUD.Models
{
    public class Dish
    {
        private string name;

        private string description;
        public string Name { get { return name; } set { name = value; } }
        public string Description { get { return description; } set { description = value; } }

        public DataTable findById(int id)
        {
            ConnectionService connectionService = new ConnectionService();
            string queryString = @"SELECT * FROM Dish WHERE ID_Dish=" + id + ";";
            return connectionService.consult(queryString);
        }

        public DataTable findAll()
        {
            ConnectionService connectionService = new ConnectionService();
            string queryString = @"SELECT * FROM Dish";
            return connectionService.consult(queryString);
        }

        public DataTable findFirstByOrderByIdDesc()
        {
            ConnectionService connectionService = new ConnectionService();
            string queryString = @"SELECT TOP 1 * FROM Dish ORDER BY ID_Dish DESC;";
            return connectionService.consult(queryString);
        }
    }
}
