using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;
using PointF = Syncfusion.Drawing.PointF;
using Syncfusion.Pdf.Grid;

namespace RestaurantAppCUD
{
    public partial class invoiceForm : Form
    {
        public invoiceForm()
        {
            InitializeComponent();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void invoiceForm_Load(object sender, EventArgs e)
        {

        }

        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //Create a new PDF document.
            PdfDocument doc = new PdfDocument();
            //Add a page.
            PdfPage page = doc.Pages.Add();
            //Create a PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();
            //Create a DataTable.
            DataTable dataTable = new DataTable();
            //Add columns to the DataTable
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Name");
            //Add rows to the DataTable.
            dataTable.Rows.Add(new object[] { "E01", "Clay" });
            dataTable.Rows.Add(new object[] { "E02", "Thomas" });
            dataTable.Rows.Add(new object[] { "E03", "Andrew" });
            dataTable.Rows.Add(new object[] { "E04", "Paul" });
            dataTable.Rows.Add(new object[] { "E05", "Gary" });
            //Assign data source.
            pdfGrid.DataSource = dataTable;
            //Draw grid to the page of PDF document.
            pdfGrid.Draw(page, new PointF(10, 10));

            // for writing the file
            var fileStream = File.Create("Output.pdf");
            //Save the document.
            doc.Save(fileStream);
            //close the document
            doc.Close(true);
        }
    }
}
