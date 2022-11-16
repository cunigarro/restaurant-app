using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogicDBCUD
{
    public class Client
    {   
        public string name { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public int dni { get; set; }
        public string address { get; set; }
        public string email { get; set; }

        private string commandString;

        public void addClient()
        {
            string queryString;
            queryString = @"INSERT INTO Client(Name, LastName, Age, DNI, Address, Email) VALUES('" + this.name + "', '" + this.lastName + "', " + this.age + ", " + this.dni + ", '" + this.address + "', '" + this.email + "')";
            commandString = queryString;
        }

        public void requestAClient(int id)
        {
            string queryString;
            queryString = @"SELECT * FROM Client WHERE ID_Client = " + id + ";";
            commandString = queryString;
        }

        public void getLastRegister()
        {
            string queryString;
            queryString = @"SELECT TOP 1 * FROM Client ORDER BY ID_Client DESC;";
            commandString = queryString;
        }

        public string readCommandString()
        {
            return this.commandString;
        }
    }
}
