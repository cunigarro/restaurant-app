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

        private void button3_Click(object sender, EventArgs e)
        {
            AppLogicDBCUD.Conexion objConexion;
            objConexion = new AppLogicDBCUD.Conexion();

            System.Data.OleDb.OleDbCommand miComando = new System.Data.OleDb.OleDbCommand();
            miComando.Connection=objConexion.
            miComando.CommandText = @"SELECT * FROM Clientes";
            miComando.ExecuteNonQuery();


        }
    }
}