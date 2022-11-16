using System.Data;
using System.Windows.Forms;

namespace RestaurantAppCUD
{
    public partial class clientForm: Form
    {
        menuForm menuFormInstance = new menuForm();

        public clientForm()
        {
            InitializeComponent();
        }

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

                this.Hide();
                menuFormInstance.Show();
            }
            catch (Exception ex)
            {
                notification.Text = "Error: " + ex.Message;
            }
        }

        private void notification_Click(object sender, EventArgs e)
        {

        }
    }
}