using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogicDBCUD.Models
{
    public class ClientOrder_Dish
    {
        public int idClientOrder { get; set; }
        public int idDish { get; set; }

        public string registerDish()
        {
            return @"INSERT INTO ClientOrder_Dish(ID_ClientOrder, ID_Dish) VALUES(" + idClientOrder + ", " + idDish + ");";
        }
    }
}
