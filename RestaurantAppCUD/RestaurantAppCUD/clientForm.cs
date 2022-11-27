using AppLogicDBCUD.Controllers;
using AppLogicDBCUD.Models;

namespace RestaurantAppCUD
{
    public partial class clientForm: Form
    {
        menuForm menuFormInstance = new menuForm();

        public clientForm( )
        {
            InitializeComponent();
        }

        private void registerClient(object sender, EventArgs e)
        {
            try
            {
                Client objClient;
                objClient = new Client();

                objClient.name = nameTextBox.Text;
                objClient.lastName = lastNameTextBox.Text;
                objClient.age = Int16.Parse(ageTextBox.Text);
                objClient.dni = Int32.Parse(dniTextBox.Text);
                objClient.address = addressTextBox.Text;
                objClient.email = emailTextBox.Text;

                ClientFormService.saveClientData(objClient);

                notification.Text = "Cliente agregado de manera exitosa.";

                this.Hide();
                menuFormInstance.Show();
            }
            catch (Exception ex)
            {
                notification.Text = "Error: " + ex.Message;
            }
        }
    }
}