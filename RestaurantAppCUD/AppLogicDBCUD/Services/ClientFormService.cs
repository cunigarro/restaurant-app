using AppLogicDBCUD.Models;
using System.Data;

namespace AppLogicDBCUD.Services
{
    public class ClientFormService
    {
        public static void saveClientData(Client dataClient)
        {
            dataClient.insert();
        }

        public static string getLastClientId()
        {
            Client objClient = new Client();

            DataTable firstTableLastClient = objClient.getLastRegister();

            string lastClientId = "";

            foreach (DataRow row in firstTableLastClient.Rows)
            {
                lastClientId = row["ID_Client"].ToString();
            }

            return lastClientId;
        }
    }
}
