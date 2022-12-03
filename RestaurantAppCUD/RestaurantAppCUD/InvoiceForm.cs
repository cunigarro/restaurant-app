using AppLogicCUD.Services;
using System.Diagnostics;

namespace RestaurantAppCUD
{
    public partial class InvoiceForm : Form
    {
        public InvoiceForm()
        {
            InitializeComponent();
        }

        private void payOrder(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            InvoiceFormService.registerClientOrderDishes(MenuForm.setValueForDataGrid.Rows);

            string totalPayed = MenuForm.totalInMenuForm.ToString();

            InvoiceFormService.generateInvoicePdf(MenuForm.setValueForDataGrid, totalPayed);

            this.Close();

            stopwatch.Stop();
            Debug.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
        }

        private void loadInvoice(object sender, EventArgs e)
        {
            dataGridView1.DataSource = MenuForm.setValueForDataGrid;
            total.Text = "Costo total: " + MenuForm.totalInMenuForm;
        }
    }
}
