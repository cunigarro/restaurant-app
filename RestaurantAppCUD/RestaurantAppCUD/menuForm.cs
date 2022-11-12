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

            dataGridView1.DataSource = myDataSet.Tables[0];
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void stepWizardControl1_SelectedPageChanged(object sender, EventArgs e)
        {

        }
    }
}
