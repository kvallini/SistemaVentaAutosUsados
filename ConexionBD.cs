using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace SistemaVentaAutosUsados
{
    public class ConexionBD
    {
        private SqlConnection conexion;

        public ConexionBD()
        {
            try
            {
                // CORRECCIÓN: Verificar "MiConexion" no "CAVALLINI"
                if (ConfigurationManager.ConnectionStrings["MiConexion"] == null)
                {
                    MessageBox.Show("No se encontró la cadena de conexión 'MiConexion' en el archivo de configuración.", "Error de Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
                conexion = new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } // 🔹 AQUÍ FALTABA ESTA LLAVE DE CIERRE DEL CONSTRUCTOR

        public SqlConnection AbrirConexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                    MessageBox.Show("Conexión abierta correctamente", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return conexion;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir conexión: {ex.Message}\n\n" +
                              $"Cadena usada: {conexion.ConnectionString}",
                              "Error de Conexión",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public void CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }

        public bool ProbarConexion()
        {
            try
            {
                AbrirConexion();
                CerrarConexion();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión: {ex.Message}\n\n" +
                              $"Solución:\n" +
                              $"1. Verifica que SQL Server esté instalado\n" +
                              $"2. Verifica que el servicio esté ejecutándose\n" +
                              $"3. Verifica el nombre de la base de datos\n" +
                              $"4. Verifica las credenciales",
                              "Error de Base de Datos",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}