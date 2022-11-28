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

        }

        [Test]
        public void GenerateInvoicePdf()
        {

        }
    }
}
