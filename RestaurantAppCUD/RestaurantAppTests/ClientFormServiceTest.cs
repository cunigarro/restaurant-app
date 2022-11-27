using AppLogicCUD.Services;
using AppLogicCUD.Models;
using System.Data;

namespace RestaurantAppTests
{
    public class ClientFormServiceTest
    {
        [Test]
        public void SaveClient()
        {
            Client client = new Client();

            int amountOfItems = client.findAll().Rows.Count;

            client.Name = "Andrés Arturo";
            client.LastName = "Gonzales Llanos";
            client.Age = 32;
            client.Dni = 5523434;
            client.Address = "Calle 3 No. 34 - 21";
            client.Email = "gonzalesllanos@gmail.com";

            ClientFormService.saveClientData(client);

            int amountAfterInsert = client.findAll().Rows.Count;

            Assert.That(amountAfterInsert, Is.EqualTo(amountOfItems + 1));

            string lastClientId = "";

            foreach (DataRow row in client.getLastRegister().Rows)
            {
                lastClientId = row["ID_Client"].ToString();
            }

            client.delete(Int32.Parse(lastClientId));
        }
    }
}