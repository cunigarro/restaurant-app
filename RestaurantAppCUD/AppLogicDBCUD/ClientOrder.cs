using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogicDBCUD
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
            queryString = @"INSERT INTO ClientOrder(ID_Client, Date, Total) VALUES(" + this.idClient + ", '" + this.date + "', " + this.total + ")";
            commandString = queryString;
        }

        public string readCommandString()
        {
            return this.commandString;
        }
    }
}
