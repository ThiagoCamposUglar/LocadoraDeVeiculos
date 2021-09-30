using System.Data.SqlClient;

namespace LocadoraDeVeiculos
{
    public class Conexao
    {
        private static string connString = @"Data Source=DESKTOP-S1KNSLQ\SQLEXPRESS;Initial Catalog=dbLocadoraDeVeiculos;integrated Security=true;User Id=thiag;Password=030702";

        private static SqlConnection conn = null;

        public static SqlConnection ObterConexao()
        {
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
            }
            catch (SqlException)
            {
                conn = null;
            }

            return conn;
        }

        public static void FecharConexao()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
    }
}
