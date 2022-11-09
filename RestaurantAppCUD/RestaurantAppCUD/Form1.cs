using System.Data;

namespace RestaurantAppCUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AppLogicDBCUD.Connection objConexion;
            objConexion = new AppLogicDBCUD.Connection();
            string queryString1;
            string queryString2;
            AppLogicDBCUD.Client objClient;
            objClient = new AppLogicDBCUD.Client();

            queryString1 = objClient.requestAllRecipes();
            objConexion.setSentence(queryString1);

            DataSet myDataSet;
            myDataSet = new DataSet();
            myDataSet = objConexion.Request();

            dataGridView1.DataSource = myDataSet.Tables[0];
        }
    }
}