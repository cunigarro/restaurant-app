using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLogicCUD.Models;
using AppLogicCUD.Services;

namespace RestaurantAppTests
{
    internal class MenuFormServiceTest
    {
        [Test]
        public void CalculateCost()
        {
            List<Int32> values = new List<Int32> { 25000, 21000, 31000 };

            Int32 result = MenuFormService.calculateCost(values);

            Assert.AreEqual(77000, result);
        }

        [Test]
        public void RegisterOrder()
        {
            ClientOrder orderClient = new ClientOrder();
            Client client = new Client();

            string lastClientId = "";

            foreach (DataRow row in client.findFirstByOrderByIdDesc().Rows)
            {
                lastClientId = row["ID_Client"].ToString();
            }

            int amountOfItems = orderClient.findAll().Rows.Count;

            orderClient.IdClient = Int32.Parse(lastClientId);
            orderClient.Date = DateTime.Now.ToString("M-d-yyyy");
            orderClient.Total = 70000;

            MenuFormService.registerOrder(orderClient);

            int amountAfterInsert = orderClient.findAll().Rows.Count;

            Assert.That(amountOfItems + 1, Is.EqualTo(amountAfterInsert));

            string lastClientOrderId = "";

            foreach (DataRow row in orderClient.findFirstByOrderByIdDesc().Rows)
            {
                lastClientOrderId = row["ID_ClientOrder"].ToString();
            }

            orderClient.delete(Int32.Parse(lastClientOrderId));
        }

        [Test]
        public void GetDishesWithMenuId()
        {

        }

        [Test]
        public void GetAllDishes()
        {

        }

        [Test]
        public void GetAllMenus()
        {

        }

        [Test]
        public void GetDishesWithPrice()
        {

        }
    }
}
