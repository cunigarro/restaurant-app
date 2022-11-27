using AppLogicCUD.Services;
using System.Data;

namespace AppLogicCUD.Models
{
    public class Menu_Dish
    {
        private string idMenu;

        private string idDish;
        public string IdMenu { get { return idMenu; } set { idMenu = value; } }
        public string IdDish { get { return idDish; } set { idDish = value; } }

        public DataTable getARegister(int id)
        {
            ConnectionService connectionService = new ConnectionService();
            string queryString = @"SELECT * FROM Menu_Dish WHERE ID_Menu = " + id + ";";
            return connectionService.consult(queryString);
        }
    }
}
