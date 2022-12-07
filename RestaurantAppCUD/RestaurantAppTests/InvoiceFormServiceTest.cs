using AppLogicCUD.Models;
using AppLogicCUD.Services;
using System.Data;

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
            DataTable dataExample = new DataTable();

            dataExample.Columns.Add("ID_Dish", typeof(string));
            dataExample.Columns.Add("Name", typeof(string));
            dataExample.Columns.Add("Description", typeof(string));
            dataExample.Columns.Add("Price", typeof(string));

            dataExample.Rows.Add(new object[] { 
                1, 
                "Ejemplo plato",
                "Ejemplo descripción plato.", 
                "100000"
            });

            InvoiceFormService.generateInvoicePdf(dataExample, "100000");

            bool fileExistCheck = File.Exists("..\\..\\..\\..\\Factura.pdf");

            Assert.IsTrue(fileExistCheck);
        }
    }
}
