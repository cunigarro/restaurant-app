using AppLogicCUD.Models;
using AppLogicCUD.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppTests
{
    internal class InvoiceFormServiceTest
    {
        [Test]
        public void GetLastClientOrderId()
        {
            ClientOrder clientOrder = new ClientOrder();

            DataTable expectedClientOrder = clientOrder.findFirstByOrderByIdDesc();

            string expectedClientOrderId = "";

            foreach (DataRow row in expectedClientOrder.Rows)
            {
                expectedClientOrderId = row["ID_ClientOrder"].ToString();
            }

            string clientOrderId = InvoiceFormService.getLastClientOrderId();

            Assert.That(expectedClientOrderId, Is.EqualTo(clientOrderId));
        }

        [Test]
        public void RegisterClientOrderDishes()
        {
            Dish dish = new Dish();
            DataTable lastDish = dish.findFirstByOrderByIdDesc();

            DataRowCollection dishes = lastDish.Rows;

            InvoiceFormService.registerClientOrderDishes(dishes);

            ClientOrder_Dish objClientOrderDish = new ClientOrder_Dish();

            string dishId = "";

            foreach (DataRow row in objClientOrderDish.findFirstByOrderByIdDesc().Rows)
            {
                dishId = row["ID_Dish"].ToString();
            }

            string expectedDishId = "";

            foreach (DataRow row in dishes)
            {
                expectedDishId = row["ID_Dish"].ToString();
            }

            Assert.That(expectedDishId, Is.EqualTo(dishId));
        }

        [Test]
        public void GenerateInvoicePdf()
        {

        }
    }
}
