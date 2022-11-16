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
using AppLogicDBCUD;

namespace RestaurantAppCUD
{
    public partial class invoiceForm : Form
    {
        public invoiceForm()
        {
            InitializeComponent();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
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
            PdfDocument doc = new PdfDocument();
            PdfPage page = doc.Pages.Add();
            PdfGrid pdfGrid = new PdfGrid();
            menuForm.setValueForDataGrid.Rows.Add(new object[] { "Total", "", "", menuForm.totalInMenuForm });
            pdfGrid.DataSource = menuForm.setValueForDataGrid;
            pdfGrid.Draw(page, new PointF(10, 10));
            var fileStream = File.Create("C:\\Users\\chris\\Documents\\Factura.pdf");
            doc.Save(fileStream);
            doc.Close(true);
            this.Close();
        }

        private void invoiceForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = menuForm.setValueForDataGrid;
            total.Text = "Total: " + menuForm.totalInMenuForm;
        }
    }
}
