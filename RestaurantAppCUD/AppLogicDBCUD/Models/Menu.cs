using AppLogicCUD.Services;
using System.Data;

namespace AppLogicCUD.Models
{
    public class Menu
    {
        private string name;

        private string description;
        public string Name { get { return name; } set { name = value; } }
        public string Description { get { return description; } set { description = value; } } 

        public DataTable findById(int id)
        {
            ConnectionService connectionService = new ConnectionService();
            string queryString = @"SELECT * FROM Menu WHERE ID_Menu=" + id;
            return connectionService.consult(queryString);
        }

        public DataTable findAll()
        {
            ConnectionService connectionService = new ConnectionService();
            string queryString = @"SELECT * FROM Menu";
            return connectionService.consult(queryString);
        }

        public DataTable findFirstByOrderByIdDesc()
        {
            ConnectionService connectionService = new ConnectionService();
            string queryString = @"SELECT TOP 1 * FROM Menu ORDER BY ID_Menu DESC;";
            return connectionService.consult(queryString);
        }
    }
}
