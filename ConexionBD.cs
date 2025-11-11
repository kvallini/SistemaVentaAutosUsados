using System.Data.SqlClient;
using System.Configuration;

namespace SistemaVentaAutosUsados
{
    public class ConexionBD
    {
        public SqlConnection GetConnection()
        {
            string connectionString = "";

            if (ConfigurationManager.ConnectionStrings["MiConexion"] != null)
            {
                connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            }
            else
            {
                // Si falla, usa esta cadena directa 
                connectionString = @"Server=CAVALLINI\CURSOSQL2022;Database=SISTEMA_VENTA_AUTOS_USADOS;User Id=sa;Password=12345678;";
            }

            return new SqlConnection(connectionString);
        }
    }
}