namespace AppLogicDBCUD.Models
{
    public class Dish
    {
        public string name { get; set; }
        public string description { get; set; }

        private string commandString;

        public string requestADish(int id)
        {
            return @"SELECT * FROM Dish WHERE ID_Dish=" + id;
        }

        public string requestAllDishes()
        {
            return @"SELECT * FROM Dish";
        }

        public string readCommandString()
        {
            return commandString;
        }
    }
}
