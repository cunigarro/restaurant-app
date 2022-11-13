using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantAppCUD
{
    public partial class menuForm : Form
    {
        public menuForm()
        {
            InitializeComponent();
            setMenuInformation();
        }

        public void setMenuInformation()
        {
            AppLogicDBCUD.Connection objConnection;
            objConnection = new AppLogicDBCUD.Connection();

            string queryString;
            AppLogicDBCUD.Menu objMenu;
            objMenu = new AppLogicDBCUD.Menu();
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

            string queryStringDishes;
            AppLogicDBCUD.Dish objDish;
            objDish = new AppLogicDBCUD.Dish();
            queryStringDishes = objDish.requestAlDishes();
            objConnection.setSentence(queryStringDishes);

            DataSet myDataSetDishes;
            myDataSetDishes = new DataSet();
            myDataSetDishes = objConnection.Request();

            DataTable firstTableDishes = myDataSetDishes.Tables[0];

            checkedListBox1.DataSource = firstTableDishes;
            checkedListBox1.DisplayMember = "Name";
            checkedListBox1.ValueMember = "ID_Dish";
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
    }
}
