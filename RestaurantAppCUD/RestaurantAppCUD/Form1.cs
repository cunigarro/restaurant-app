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
            AppLogicDBCUD.Connection objConnection;
            objConnection = new AppLogicDBCUD.Connection();

            string queryString;
            AppLogicDBCUD.Recipe objRecipe;
            objRecipe = new AppLogicDBCUD.Recipe();

            queryString = objRecipe.requestAllRecipes();
            objConnection.setSentence(queryString);

            DataSet myDataSet;
            myDataSet = new DataSet();
            myDataSet = objConnection.Request();

            dataGridView1.DataSource = myDataSet.Tables[0];

            label5.Text = "Se muestran todas las recetas";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AppLogicDBCUD.Connection objConnection;
                objConnection = new AppLogicDBCUD.Connection();

                string queryString;
                AppLogicDBCUD.Recipe objRecipe;
                objRecipe = new AppLogicDBCUD.Recipe();

                objRecipe.setIdRecipe(Int16.Parse(textBox3.Text));
                objRecipe.setIdIngredient(Int16.Parse(textBox1.Text));
                objRecipe.setIdMeasure(Int16.Parse(textBox2.Text));
                objRecipe.setDescription(richTextBox1.Text);
                objRecipe.addRecipe();

                queryString = objRecipe.readCommandString();
                objConnection.setSentence(queryString);
                objConnection.runSentence();

                label5.Text = "Se agrega receta";
            } 
            catch (Exception ex)
            {
                label5.Text = "Error: " + ex.Message;
            }

            
        }
    }
}