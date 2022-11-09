using System.Data.OleDb;

namespace AppLogicDBCUD
{
    public class Conexion
    {
        OleDbConnection dbConnection = new OleDbConnection();
        string dbPath = "";
        string sql;
        OleDbDataReader dataReader;


        bool OpenCon()
        {
            try
            {
                dbConnection.ConnectionString = @"Data Source=DESKTOP-3M6BAF9; Initial Catalog=Kaizan; Persist Securty Info=True; User ID=sa; Password=123456;";
                dbConnection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public
    }
}