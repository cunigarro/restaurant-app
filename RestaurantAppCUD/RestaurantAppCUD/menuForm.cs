﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantAppCUD
{
    public partial class menuForm : Form
    {
        invoiceForm invoiceFormInstance = new invoiceForm();
        public string lastClientId;

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

            queryString = objMenu.requestAMenu(1);
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

        private void setNamePriceInCheckedList()
        {
            AppLogicDBCUD.Connection objConnection = new AppLogicDBCUD.Connection();
            AppLogicDBCUD.Dish objDish = new AppLogicDBCUD.Dish();

            string queryStringDishes;

            queryStringDishes = objDish.requestAlDishes();
            objConnection.setSentence(queryStringDishes);

            DataSet myDataSetDishes;
            myDataSetDishes = new DataSet();
            myDataSetDishes = objConnection.Request();

            DataTable firstTableDishes = myDataSetDishes.Tables[0];

            checkedListBox1.DataSource = firstTableDishes;
            checkedListBox1.DisplayMember = "Name";
            checkedListBox1.ValueMember = "Price";
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void stepWizardControl1_SelectedPageChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
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
                foreach (DataColumn col in firstTableLastClient.Columns)
                {
                    lastClientId = row["ID_Client"].ToString();
                }
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

            this.Hide();
            invoiceFormInstance.Show();
        }
    }
}
