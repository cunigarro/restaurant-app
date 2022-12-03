using AppLogicCUD.Services;
using System.Data;

namespace AppLogicCUD.Models
{
    public class ClientOrder_Dish
    {
        private int idClientOrder;

        private int idDish;
        public int IdClientOrder { get { return idClientOrder; } set { idClientOrder = value; } }
        public int IdDish { get { return idDish; } set { idDish = value; } }

        public void insert()
        {
            ConnectionService connectionService = new ConnectionService();
            string queryString = @"INSERT INTO ClientOrder_Dish(ID_ClientOrder, ID_Dish) VALUES(" + IdClientOrder + ", " + IdDish + ");";
            connectionService.runCommand(queryString);
        }

        public DataTable findById(int id)
        {
            ConnectionService connectionService = new ConnectionService();
            string queryString = @"SELECT * FROM ClientOrder_Dish WHERE ID_ClientOrder = " + id + ";";
            return connectionService.consult(queryString);
        }

        public DataTable findFirstByOrderByIdDesc()
        {
            ConnectionService connectionService = new ConnectionService();
            string queryString = @"SELECT TOP 1 * FROM ClientOrder_Dish ORDER BY ID_ClientOrder DESC;";
            return connectionService.consult(queryString);
        }
    }
}
