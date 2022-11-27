using AppLogicCUD.Models;
using System.Data;
using Syncfusion.Pdf;
using PointF = Syncfusion.Drawing.PointF;
using Syncfusion.Pdf.Grid;

namespace AppLogicCUD.Services
{
    public class InvoiceFormService
    {
        public static string getLastClientOrderId()
        {
            ClientOrder objClientOrder = new ClientOrder();

            DataTable firstTableLastClient = objClientOrder.findFirstByOrderByIdDesc();

            string lastClientOrderId = "";

            foreach (DataRow row in firstTableLastClient.Rows)
            {
                lastClientOrderId = row["ID_ClientOrder"].ToString();
            }

            return lastClientOrderId;
        }

        public static void registerClientOrderDishes(DataRowCollection dishesSelected)
        {
            ClientOrder_Dish objClientOrderDish = new ClientOrder_Dish();

            foreach (DataRow dishRow in dishesSelected)
            {
                objClientOrderDish.IdClientOrder = Int32.Parse(InvoiceFormService.getLastClientOrderId());
                objClientOrderDish.IdDish = Int32.Parse(dishRow["ID_Dish"].ToString());
                objClientOrderDish.insert();
            }
        }

        public static void generateInvoicePdf(DataTable itemsPayed, string totalPayed)
        {
            PdfDocument doc = new PdfDocument();
            PdfPage page = doc.Pages.Add();
            PdfGrid pdfGrid = new PdfGrid();
            itemsPayed.Rows.Add(new object[] { "Total", "", "", totalPayed });
            pdfGrid.DataSource = itemsPayed;
            pdfGrid.Draw(page, new PointF(10, 10));
            var fileStream = File.Create("C:\\Users\\chris\\Documents\\Factura.pdf");
            doc.Save(fileStream);
            doc.Close(true);
        }
    }
}
