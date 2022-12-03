using AppLogicCUD.Models;
using AppLogicCUD.Services;
using System.Data;
using System.Diagnostics;

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

            menuComboBox.DataSource = firstTable;
            menuComboBox.DisplayMember = "Name";
            menuComboBox.ValueMember = "ID_Menu";
        }

        private void setNamePriceInCheckedList(Int32 currentMenu)
        {
            DataTable newDataTable = MenuFormService.getDishesWithPrice(currentMenu);

            dishesCheckedListBox.DataSource = newDataTable;
            dishesCheckedListBox.DisplayMember = "Name_Price";
            dishesCheckedListBox.ValueMember = "Price";
        }

        private void calculateCost(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<Int32> valuesSelected = new List<Int32>();

            foreach (object itemChecked in dishesCheckedListBox.CheckedItems)
            {
                var row = (itemChecked as DataRowView).Row;
                valuesSelected.Add(Int32.Parse(row.ItemArray[4].ToString()));
            }

            totalInMenuForm = MenuFormService.calculateCost(valuesSelected);

            label3.Text = totalInMenuForm.ToString();
            stopwatch.Stop();
            // Debug.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
        }

        private void registerOrder(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

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

            foreach (DataRowView row in dishesCheckedListBox.CheckedItems)
            {
                dataTable.ImportRow(row.Row);
            }

            setValueForDataGrid = dataTable;

            this.Hide();
            invoiceFormInstance.Show();

            stopwatch.Stop();
            // Debug.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
        }

        private void selectedMenu(object sender, EventArgs e)
        {
            if (menuComboBox.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                string value = menuComboBox.SelectedValue.ToString();
                setNamePriceInCheckedList(Int32.Parse(value));
            }
        }

        private void fieldsValidation(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var fieldBox = sender;

            if (fieldBox.GetType().BaseType.Name == "ListBox")
            {
                CheckedListBox checkedListBox = fieldBox as CheckedListBox;

                if (checkedListBox.Name == "dishesCheckedListBox" & checkedListBox.CheckedItems.Count <= 0)
                {
                    e.Cancel = true;
                    checkedListBox.Focus();
                    errorProvider.SetError(checkedListBox, "Selecciona un plato");
                    button2.Enabled = false;
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(checkedListBox, null);
                    button2.Enabled = true;
                }
            }
            else if (fieldBox.GetType().BaseType.Name == "ListControl")
            {
                System.Windows.Forms.ComboBox comboBox = fieldBox as System.Windows.Forms.ComboBox;

                if (comboBox.Name == "menuComboBox" & comboBox.SelectedValue == "")
                {
                    e.Cancel = true;
                    comboBox.Focus();
                    errorProvider.SetError(comboBox, "Selecciona un men{u");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(comboBox, null);
                }
            }
        }
    }
}
