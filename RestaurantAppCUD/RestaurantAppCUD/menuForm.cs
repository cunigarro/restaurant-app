using AppLogicDBCUD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace RestaurantAppCUD
{
    public partial class menuForm : Form
    {
        invoiceForm invoiceFormInstance = new invoiceForm();
        public string lastClientId;
        public int currentMenu = 1;
        public static DataTable setValueForDataGrid = new DataTable();

        public menuForm()
        {
            InitializeComponent();
            setMenuInformation();
            setNamePriceInCheckedList();
        }

        public void setMenuInformation()
        {
            AppLogicDBCUD.Connection objConnection = new AppLogicDBCUD.Connection();
            AppLogicDBCUD.Menu objMenu = new AppLogicDBCUD.Menu();

            string queryString;

            queryString = objMenu.requestAMenu(currentMenu);
            objConnection.setSentence(queryString);

            DataSet myDataSet;
            myDataSet = new DataSet();
            myDataSet = objConnection.Request();

            DataTable firstTable = myDataSet.Tables[0];

            foreach (DataRow row in firstTable.Rows)
            {
                foreach (DataColumn col in firstTable.Columns)
                {
                    object value = row[col];
                    label1.Text = row["Name"].ToString();
                    label2.Text = row["Description"].ToString();
                }
            }         
        }

        private List<Int32> getDishesWithMenuId()
        {
            AppLogicDBCUD.Connection objConnection = new AppLogicDBCUD.Connection();
            AppLogicDBCUD.Menu_Dish objMenuDish = new AppLogicDBCUD.Menu_Dish();

            string queryDishesWithMenuId;

            objMenuDish.getDishWithMenuId(currentMenu);
            queryDishesWithMenuId = objMenuDish.readCommandString();
            objConnection.setSentence(queryDishesWithMenuId);

            DataSet dishesIdDataSet;
            dishesIdDataSet = new DataSet();
            dishesIdDataSet = objConnection.Request();

            DataTable dishesIdTable = dishesIdDataSet.Tables[0];
            List<Int32> dishesIdList = new List<Int32>();

            foreach (DataRow row in dishesIdTable.Rows)
            {
                Int32 dishId = Int32.Parse(row["ID_Dish"].ToString());
                dishesIdList.Add(dishId);
            }

            return dishesIdList;
        }

        private void setNamePriceInCheckedList()
        {
            List<Int32> dishesIdList = getDishesWithMenuId();

            AppLogicDBCUD.Connection objConnection = new AppLogicDBCUD.Connection();
            AppLogicDBCUD.Dish objDish = new AppLogicDBCUD.Dish();

            string queryStringDishes;

            queryStringDishes = objDish.requestAlDishes();
            objConnection.setSentence(queryStringDishes);

            DataSet myDataSetDishes;
            myDataSetDishes = new DataSet();
            myDataSetDishes = objConnection.Request();

            DataTable firstTableDishes = myDataSetDishes.Tables[0];

            DataTable newDataTable = new DataTable();

            newDataTable.Columns.Add("ID_Dish", typeof(string));
            newDataTable.Columns.Add("Name", typeof(string));
            newDataTable.Columns.Add("Description", typeof(string));
            newDataTable.Columns.Add("Price", typeof(string));

            foreach (DataRow row in firstTableDishes.Rows)
            {
                if (dishesIdList.Contains(Int32.Parse(row["ID_Dish"].ToString())))
                {
                    newDataTable.ImportRow(row);
                }
            }

            checkedListBox1.DataSource = newDataTable;
            checkedListBox1.DisplayMember = "Name";
            checkedListBox1.ValueMember = "Price";
        }

        private string returnLastClient()
        {
            AppLogicDBCUD.Connection objConnection = new AppLogicDBCUD.Connection();
            AppLogicDBCUD.Client objClient = new AppLogicDBCUD.Client();

            string queryStringLastClient;
            
            objClient.getLastRegister();
            queryStringLastClient = objClient.readCommandString();
            objConnection.setSentence(queryStringLastClient);

            DataSet myDataLastClient;
            myDataLastClient = new DataSet();
            myDataLastClient = objConnection.Request();

            DataTable firstTableLastClient = myDataLastClient.Tables[0];

            string lastClientId = "";

            foreach (DataRow row in firstTableLastClient.Rows)
            {
                lastClientId = row["ID_Client"].ToString();
            }

            return lastClientId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int total = 0;
            foreach (object itemChecked in checkedListBox1.CheckedItems)
            {
                var row = (itemChecked as DataRowView).Row;
                total += Int32.Parse(row.ItemArray[3].ToString());
            }

            label3.Text = total.ToString();
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AppLogicDBCUD.Connection objConnection = new AppLogicDBCUD.Connection();
            AppLogicDBCUD.ClientOrder objClientOrder = new AppLogicDBCUD.ClientOrder();

            string queryString;

            objClientOrder.idClient = Int32.Parse(returnLastClient());
            objClientOrder.date = DateTime.Now.ToString("M-d-yyyy");
            objClientOrder.total = Int32.Parse(label3.Text);

            objClientOrder.addClientOrder();

            queryString = objClientOrder.readCommandString();
            objConnection.setSentence(queryString);
            objConnection.runSentence();

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("ID_Dish", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Description", typeof(string));
            dataTable.Columns.Add("Price", typeof(string));

            foreach (DataRowView row in checkedListBox1.SelectedItems)
            {
                dataTable.ImportRow(row.Row);
            }

            setValueForDataGrid = dataTable;

            this.Hide();
            invoiceFormInstance.Show();
        }
    }
}
