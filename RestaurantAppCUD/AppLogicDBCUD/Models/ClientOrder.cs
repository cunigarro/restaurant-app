using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogicDBCUD.Models
{
    public class ClientOrder
    {
        public int idClient { get; set; }
        public string date { get; set; }
        public int total { get; set; }

        private string commandString;

        public void addClientOrder()
        {
            string queryString;
            queryString = @"INSERT INTO ClientOrder(ID_Client, Date, Total) VALUES(" + idClient + ", '" + date + "', " + total + ")";
            commandString = queryString;
        }

        public void getLastRegister()
        {
            string queryString;
            queryString = @"SELECT TOP 1 * FROM ClientOrder ORDER BY ID_ClientOrder DESC;";
            commandString = queryString;
        }

        public string readCommandString()
        {
            return commandString;
        }
    }
}
