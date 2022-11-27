using AppLogicCUD.Services;
using System.Net;
using System.Xml.Linq;

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
    }
}
