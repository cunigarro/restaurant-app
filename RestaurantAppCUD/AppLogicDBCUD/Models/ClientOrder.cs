using AppLogicCUD.Services;
using System.Data;
using System.Net;
using System.Xml.Linq;

namespace AppLogicCUD.Models
{
    public class ClientOrder
    {
        private int idClient;

        private string date;
        
        private int total;
        public int IdClient { get { return idClient; } set { idClient = value; } }
        public string Date { get { return date; } set { date = value; } }
        public int Total { get { return total; } set { total = value; } }

        public void insert()
        {
            ConnectionService connectionService = new ConnectionService();
            string queryString = @"INSERT INTO ClientOrder(ID_Client, Date, Total) VALUES(" + IdClient + ", '" + Date + "', " + Total + ")";
            connectionService.runCommand(queryString);
        }

        public DataTable getLastRegister()
        {
            ConnectionService connectionService = new ConnectionService();
            string queryString = @"SELECT TOP 1 * FROM ClientOrder ORDER BY ID_ClientOrder DESC;";
            return connectionService.consult(queryString);
        }
    }
}
