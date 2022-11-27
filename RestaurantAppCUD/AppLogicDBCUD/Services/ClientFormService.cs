using AppLogicDBCUD.Models;
using System.Data;

namespace AppLogicDBCUD.Services
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

        public static string getLastClientId()
        {
            Connection objConnection;
            objConnection = new Connection();

            Client objClient = new Client();

            objClient.getLastRegister();
            string queryString = objClient.readCommandString();
            objConnection.setSentence(queryString);

            DataSet myDataLastClient = objConnection.Request();

            DataTable firstTableLastClient = myDataLastClient.Tables[0];

            string lastClientId = "";

            foreach (DataRow row in firstTableLastClient.Rows)
            {
                lastClientId = row["ID_Client"].ToString();
            }

            return lastClientId;
        }
    }
}
