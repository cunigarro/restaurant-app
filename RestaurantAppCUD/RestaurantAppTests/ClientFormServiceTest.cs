using AppLogicCUD.Services;
using AppLogicCUD.Models;
using System.Data;

namespace RestaurantAppTests
{
    public class ClientFormServiceTest
    {
        [Test]
        public void SaveClientData()
        {
            Client client = new Client();

            int expectedAmountOfItems = client.findAll().Rows.Count + 1;

            client.Name = "Andrés Arturo";
            client.LastName = "Gonzales Llanos";
            client.Age = 32;
            client.Dni = 552344334;
            client.Address = "Calle 3 No. 34 - 21";
            client.Email = "gonzalesllanos@gmail.com";

            ClientFormService.saveClientData(client);

            int actualAmountOfItem = client.findAll().Rows.Count;

            Assert.That(expectedAmountOfItems, Is.EqualTo(actualAmountOfItem));

            // Removing register used for test
            string lastClientId = "";

            foreach (DataRow row in client.findFirstByOrderByIdDesc().Rows)
            {
                lastClientId = row["ID_Client"].ToString();
            }

            client.delete(Int32.Parse(lastClientId));
        }

        [Test]
        public void GetLastClientId()
        {
            Client client = new Client();

            string lastClientIdFromService = ClientFormService.getLastClientId();

            string lastClientId = "";

            foreach (DataRow row in client.findFirstByOrderByIdDesc().Rows)
            {
                lastClientId = row["ID_Client"].ToString();
            }

            Assert.That(lastClientIdFromService, Is.EqualTo(lastClientId));
        }
    }
}