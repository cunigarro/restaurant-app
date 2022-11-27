using AppLogicCUD.Models;
using System.Data;

namespace AppLogicCUD.Services
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

            DataTable firstTableLastClient = objClient.findFirstByOrderByIdDesc();

            string lastClientId = "";

            foreach (DataRow row in firstTableLastClient.Rows)
            {
                lastClientId = row["ID_Client"].ToString();
            }

            return lastClientId;
        }
    }
}
