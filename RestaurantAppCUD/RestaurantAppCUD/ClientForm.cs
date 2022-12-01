using AppLogicCUD.Services;
using AppLogicCUD.Models;

namespace RestaurantAppCUD
{
    public partial class ClientForm: Form
    {
        MenuForm menuFormInstance = new MenuForm();

        public ClientForm( )
        {
            InitializeComponent();
        }

        private void registerClient(object sender, EventArgs e)
        {
            try
            {
                Client objClient = new Client();

                objClient.Name = nameTextBox.Text;
                objClient.LastName = lastNameTextBox.Text;
                objClient.Age = Int16.Parse(ageTextBox.Text);
                objClient.Dni = Int32.Parse(dniTextBox.Text);
                objClient.Address = addressTextBox.Text;
                objClient.Email = emailTextBox.Text;

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

        private void validateNameTextBox(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                e.Cancel = true;
                nameTextBox.Focus();
                errorProvider.SetError(nameTextBox, "Por favor introduzca su nombre");
            } else
            {
                e.Cancel = true;
                errorProvider.SetError(nameTextBox, null);
            }
        }
    }
}