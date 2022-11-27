using AppLogicDBCUD.Models;
using AppLogicDBCUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogicDBCUD.Controllers
{
    public class ClientFormService
    {
        public static void saveClientData(Client objClient)
        {
            Connection objConnection;
            objConnection = new Connection();

            objClient.addClient();
            string queryString = objClient.readCommandString();
            objConnection.setSentence(queryString);
            objConnection.runSentence();
        }
    }
}
