using AppLogicCUD.Services;
using System.Data;

namespace AppLogicCUD.Models
{
    public class Client
    {
        private string name;

        private string lastName;
        
        private int age;
        
        private int dni;
        
        private string address;
        
        private string email;
        public string Name { get { return name; } set { name = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }   
        public int Age { get { return age; } set { age = value; } }
        public int Dni { get { return dni; } set { dni = value; } }
        public string Address { get { return address; } set { address = value; } }  
        public string Email { get { return email; } set { email = value; } }

        public void insert()
        {
            ConnectionService connectionService = new ConnectionService();
            string queryString = @"INSERT INTO Client(Name, LastName, Age, DNI, Address, Email) VALUES('" + Name + "', '" + LastName + "', " + Age + ", " + Dni + ", '" + Address + "', '" + Email + "')";
            connectionService.runCommand(queryString);
        }

        public DataTable findAll()
        {
            ConnectionService connectionService = new ConnectionService();
            string queryString = @"SELECT * FROM Client;";
            return connectionService.consult(queryString);
        }

        public void delete(int id)
        {
            ConnectionService connectionService = new ConnectionService();
            string queryString = @"DELETE FROM Client WHERE ID_Client=" + id + ";"; 
            connectionService.runCommand(queryString);
        }

        public DataTable findById(int id)
        {
            ConnectionService connectionService = new ConnectionService();
            string queryString = @"SELECT * FROM Client WHERE ID_Client = " + id + ";";
            return connectionService.consult(queryString);
        }

        public DataTable getLastRegister()
        {

            ConnectionService connectionService = new ConnectionService();
            string queryString = @"SELECT TOP 1 * FROM Client ORDER BY ID_Client DESC;";
            return connectionService.consult(queryString);
        }
    }
}
