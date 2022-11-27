using System.Data;
using System.Data.OleDb;

namespace AppLogicDBCUD.Services
{
    public class ConnectionService
    {
        protected OleDbConnection connect()
        {
            string queryConnect = @"Provider=SQLNCLI11; Data Source=DESKTOP-3M6BAF9; Initial Catalog=Restaurant; Persist Security Info=False; User ID=sa; Password=123456;";
            OleDbConnection connection = new OleDbConnection(queryConnect);
            connection.Open();
            return connection;
        }

         public void runCommand(string sql)
         {
            OleDbCommand command = new OleDbCommand(sql, connect());
            command.ExecuteNonQuery();
         }

        public DataTable consult(string sql)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, connect());
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
}