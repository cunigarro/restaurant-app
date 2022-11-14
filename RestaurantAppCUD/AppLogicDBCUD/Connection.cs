using System.Data;
using System.Data.OleDb;

namespace AppLogicDBCUD
{
    public class Connection
    {

        private string queryString;
        OleDbConnection dbConnection;
        OleDbTransaction dbTransaction;

        private string message;

        public Connection()
        {
            dbConnection = new OleDbConnection();
            dbConnection.ConnectionString = @"Provider=SQLNCLI11; Data Source=DESKTOP-3M6BAF9; Initial Catalog=Restaurant; Persist Security Info=False; User ID=sa; Password=123456;";
        }

        public void setSentence(string queryS)
        {
            queryString = queryS;
        }

        public string runSentence()
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = dbConnection;
                dbConnection.Open();

                dbTransaction = dbConnection.BeginTransaction();
                command.Connection = dbConnection;
                command.Transaction = dbTransaction;
                command.CommandText = queryString;
                command.ExecuteNonQuery();
                dbTransaction.Commit();
                return "Todo Ok";
            } catch (Exception e)
            {
                dbTransaction.Rollback();
                return "Hubo un error: " + e.Message;
            }
        }

        public DataSet Request()
        {
            try
            {
                dbConnection.Open();
                OleDbDataAdapter objRes;
                objRes = new OleDbDataAdapter(queryString, dbConnection);
                DataSet data;
                data = new DataSet();
                objRes.Fill(data, "Tabla");
                return data;
            } catch (Exception e)
            {
                DataSet data2;
                data2 = new DataSet();
                message = "Se presento un error:" + e.Message;
                return data2;
            }
            finally
            {
                dbConnection.Close();
            }
        }
    }
}