using System.Data.SqlClient;
using System.Configuration;

namespace SistemaVentaAutosUsados
{
    public class ConexionBD
    {
        public SqlConnection GetConnection()
        {
            string connectionString = @"Server=localhost;Database=SISTEMA_VENTA_AUTOS_USADOS;Integrated Security=True;";
            return new SqlConnection(connectionString);
        }
    }
}