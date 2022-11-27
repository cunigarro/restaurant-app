using AppLogicDBCUD.Services;

namespace RestaurantAppCUD
{
    public partial class invoiceForm : Form
    {
        public invoiceForm()
        {
            InitializeComponent();
        }

        private void payOrder(object sender, EventArgs e)
        {
            InvoiceFormService.registerClientOrderDishes(menuForm.setValueForDataGrid.Rows);

            string totalPayed = menuForm.totalInMenuForm.ToString();

            InvoiceFormService.generateInvoicePdf(menuForm.setValueForDataGrid, totalPayed);

            this.Close();
        }

        private void loadInvoice(object sender, EventArgs e)
        {
            dataGridView1.DataSource = menuForm.setValueForDataGrid;
            total.Text = "Costo total: " + menuForm.totalInMenuForm;
        }
    }
}
