using AppLogicCUD.Services;

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
            InvoiceFormService.registerClientOrderDishes(MenuForm.setValueForDataGrid.Rows);

            string totalPayed = MenuForm.totalInMenuForm.ToString();

            InvoiceFormService.generateInvoicePdf(MenuForm.setValueForDataGrid, totalPayed);

            this.Close();
        }

        private void loadInvoice(object sender, EventArgs e)
        {
            dataGridView1.DataSource = MenuForm.setValueForDataGrid;
            total.Text = "Costo total: " + MenuForm.totalInMenuForm;
        }
    }
}
