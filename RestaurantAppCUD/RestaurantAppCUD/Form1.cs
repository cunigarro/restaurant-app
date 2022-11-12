using System.Data;
using System.Windows.Forms;

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

        /* private void button3_Click(object sender, EventArgs e)
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

                objRecipe.setIdIngredient(Int16.Parse(textBox1.Text));
                objRecipe.setIdMeasure(Int16.Parse(textBox2.Text));
                objRecipe.setDescription(richTextBox1.Text);
                objRecipe.addRecipe();

                queryString = objRecipe.readCommandString();
                objConnection.setSentence(queryString);
                objConnection.runSentence();

            } 
            catch (Exception ex)
            {
                label5.Text = "Error: " + ex.Message;
            }    
        }  */

        private void nextBtn_Click(object sender, EventArgs e)
        {
            try
            {
                AppLogicDBCUD.Connection objConnection;
                objConnection = new AppLogicDBCUD.Connection();

                string queryString;

                AppLogicDBCUD.Client objClient;
                objClient = new AppLogicDBCUD.Client();

                objClient.name = nameTextBox.Text;
                objClient.lastName = lastNameTextBox.Text;
                objClient.age = Int16.Parse(ageTextBox.Text);
                objClient.dni = Int32.Parse(dniTextBox.Text);
                objClient.address = addressTextBox.Text;
                objClient.email = emailTextBox.Text;

                objClient.addClient();

                queryString = objClient.readCommandString();
                objConnection.setSentence(queryString);
                objConnection.runSentence();

                notification.Text = "Cliente agregado de manera exitosa.";
            }
            catch (Exception ex)
            {
                notification.Text = "Error: " + ex.Message;
            }
        }
    }
}