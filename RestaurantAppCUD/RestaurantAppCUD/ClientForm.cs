using AppLogicCUD.Services;
using AppLogicCUD.Models;
using System.Linq.Expressions;

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

        private void validateTextBox(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (string.IsNullOrEmpty(textBox.Text))
            {
                e.Cancel = true;
                nameTextBox.Focus();
                errorProvider.SetError(textBox, this.validationTexts(textBox.Name));
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(textBox, null);
            }
        }

        private string validationTexts(string textBoxRef)
        {
            switch (textBoxRef)
            {
                case "nameTextBox":
                    return "Por favor introduzca sus nombres";
                case "lastNameTextBox":
                    return "Por favor introduzca sus apellidos";
                case "ageTextBox":
                    return "Por favor introduzca su edad";
                case "dniTextBox":
                    return "Por favor introduzca su número de documento";
                case "addressTextBox":
                    return "Por favor introduzca su dirección";
                case "emailTextBox":
                    return "Por favor introduzca su correo electrónico";
                default:
                    return "Por favor introduzca un valor";
            }
        }
    }
}