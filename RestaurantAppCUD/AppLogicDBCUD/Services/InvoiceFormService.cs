using AppLogicDBCUD.Models;
using System.Data;
using Syncfusion.Pdf;
using PointF = Syncfusion.Drawing.PointF;
using Syncfusion.Pdf.Grid;

namespace AppLogicDBCUD.Services
{
    public class InvoiceFormService
    {
        public static string getLastClientOrderId()
        {
            AppLogicDBCUD.Connection objConnection = new AppLogicDBCUD.Connection();
            ClientOrder objClientOrder = new ClientOrder();

            string queryStringClientOrder;

            objClientOrder.getLastRegister();
            queryStringClientOrder = objClientOrder.readCommandString();
            objConnection.setSentence(queryStringClientOrder);

            DataSet myDataLastClient;
            myDataLastClient = new DataSet();
            myDataLastClient = objConnection.Request();

            DataTable firstTableLastClient = myDataLastClient.Tables[0];

            string lastClientOrderId = "";

            foreach (DataRow row in firstTableLastClient.Rows)
            {
                lastClientOrderId = row["ID_ClientOrder"].ToString();
            }

            return lastClientOrderId;
        }

        public static void registerClientOrderDishes(DataRowCollection dishesSelected)
        {
            Connection objConnection = new Connection();
            ClientOrder_Dish objClientOrderDish = new ClientOrder_Dish();

            string queryStringClientOrderDish;

            foreach (DataRow dishRow in dishesSelected)
            {
                objClientOrderDish.idClientOrder = Int32.Parse(InvoiceFormService.getLastClientOrderId());
                objClientOrderDish.idDish = Int32.Parse(dishRow["ID_Dish"].ToString());
                queryStringClientOrderDish = objClientOrderDish.registerDish();
                objConnection.setSentence(queryStringClientOrderDish);
                objConnection.runSentence();
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
