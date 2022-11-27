using AppLogicCUD.Services;
using AppLogicCUD.Models;
using System.Data;

namespace RestaurantAppCUD
{
    public partial class MenuForm : Form
    {
        InvoiceForm invoiceFormInstance = new InvoiceForm();
        public string lastClientId;
        public static DataTable setValueForDataGrid = new DataTable();
        public static int totalInMenuForm = 0;

        public MenuForm()
        {
            InitializeComponent();
            setMenuInformation();
            setNamePriceInCheckedList(1);
        }

        public void setMenuInformation()
        {
            DataTable firstTable = MenuFormService.getAllMenus();

            comboBox1.DataSource = firstTable;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID_Menu";
        }

        private void setNamePriceInCheckedList(Int32 currentMenu)
        {
            DataTable newDataTable = MenuFormService.getDishesWithPrice(currentMenu);

            checkedListBox1.DataSource = newDataTable;
            checkedListBox1.DisplayMember = "Name_Price";
            checkedListBox1.ValueMember = "Price";
        }

        private void calculateCost(object sender, EventArgs e)
        {
            List<Int32> valuesSelected = new List<Int32>();

            foreach (object itemChecked in checkedListBox1.CheckedItems)
            {
                var row = (itemChecked as DataRowView).Row;
                valuesSelected.Add(Int32.Parse(row.ItemArray[4].ToString()));
            }

            totalInMenuForm = MenuFormService.calculateCost(valuesSelected);

            label3.Text = totalInMenuForm.ToString();
            button2.Enabled = true;
        }

        private void registerOrder(object sender, EventArgs e)
        {
            ClientOrder objClientOrder = new ClientOrder();

            objClientOrder.IdClient = Int32.Parse(ClientFormService.getLastClientId());
            objClientOrder.Date = DateTime.Now.ToString("M-d-yyyy");
            objClientOrder.Total = Int32.Parse(label3.Text);

            MenuFormService.registerOrder(objClientOrder);

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("ID_Dish", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Description", typeof(string));
            dataTable.Columns.Add("Price", typeof(string));

            foreach (DataRowView row in checkedListBox1.CheckedItems)
            {
                dataTable.ImportRow(row.Row);
            }

            setValueForDataGrid = dataTable;

            this.Hide();
            invoiceFormInstance.Show();
        }

        private void selectedMenu(object sender, EventArgs e)
        {
            if(comboBox1.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                string value = comboBox1.SelectedValue.ToString();
                setNamePriceInCheckedList(Int32.Parse(value));
            }
        }
    }
}
