using AppLogicDBCUD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
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
        public static DataTable setValueForDataGrid = new DataTable();
        public static int totalInMenuForm = 0;

        public menuForm()
        {
            InitializeComponent();
            setMenuInformation();
            setNamePriceInCheckedList(1);
        }

        public void setMenuInformation()
        {
            AppLogicDBCUD.Connection objConnection = new AppLogicDBCUD.Connection();
            AppLogicDBCUD.Menu objMenu = new AppLogicDBCUD.Menu();

            string queryString;

            queryString = objMenu.requestAllMenus();
            objConnection.setSentence(queryString);

            DataSet myDataSet;
            myDataSet = new DataSet();
            myDataSet = objConnection.Request();

            DataTable firstTable = myDataSet.Tables[0];

            comboBox1.DataSource = firstTable;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID_Menu";
        }

        private List<Int32> getDishesWithMenuId(int currentMenu)
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

        private void setNamePriceInCheckedList(Int32 currentMenu)
        {
            List<Int32> dishesIdList = getDishesWithMenuId(currentMenu);

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
            newDataTable.Columns.Add("Name_Price", typeof(string));
            newDataTable.Columns.Add("Description", typeof(string));
            newDataTable.Columns.Add("Price", typeof(string));

            foreach (DataRow row in firstTableDishes.Rows)
            {
                if (dishesIdList.Contains(Int32.Parse(row["ID_Dish"].ToString())))
                {
                    newDataTable.Rows.Add(new object[] { row["ID_Dish"], row["Name"], row["Name"] + " - " + row["Price"], row["Description"], row["Price"] });
                }
            }

            checkedListBox1.DataSource = newDataTable;
            checkedListBox1.DisplayMember = "Name_Price";
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
                total += Int32.Parse(row.ItemArray[4].ToString());
            }

            totalInMenuForm = total;

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

            foreach (DataRowView row in checkedListBox1.CheckedItems)
            {
                dataTable.ImportRow(row.Row);
            }

            setValueForDataGrid = dataTable;

            this.Hide();
            invoiceFormInstance.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                string value = comboBox1.SelectedValue.ToString();
                setNamePriceInCheckedList(Int32.Parse(value));
            }
        }
    }
}
