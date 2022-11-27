namespace AppLogicDBCUD.Models
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
            return commandString;
        }
    }
}
