using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaVentaAutosUsados
{
    public partial class fmrDetalleVehiculo : Form
    {
        private int vehiculoId;
        private int clienteId;
        private ConexionBD dbConnection;

        public fmrDetalleVehiculo(int idVehiculo, int idCliente)
        {
            InitializeComponent();
            this.vehiculoId = idVehiculo;
            this.clienteId = idCliente;
            dbConnection = new ConexionBD();
        }

        private void fmrDetalleVehiculo_Load(object sender, EventArgs e)
        {
            CargarDetallesVehiculo();
        }

        private void CargarDetallesVehiculo()
        {
            try
            {
                using (SqlConnection connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT * FROM VEHICULOS WHERE ID_Vehiculo = @VehiculoId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@VehiculoId", vehiculoId);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        lblMarca.Text = reader["Marca"].ToString();
                        lblModelo.Text = reader["Modelo"].ToString();
                        lblAño.Text = reader["Año"].ToString();
                        lblColor.Text = reader["Color"].ToString();
                        lblPrecio.Text = Convert.ToDecimal(reader["Precio"]).ToString("C");
                        lblKilometraje.Text = reader["Kilometraje"].ToString() + " km";
                        lblCombustible.Text = reader["Tipo_Combustible"].ToString();
                        lblTransmision.Text = reader["Transmision"].ToString();
                        lblPasajeros.Text = reader["Numero_Pasajeros"].ToString();
                        lblPuertas.Text = reader["Numero_Puertas"].ToString();
                        lblTipo.Text = reader["Tipo_Vehiculo"].ToString();
                        lblEstado.Text = reader["Estado_Vehiculo"].ToString();
                        txtEquipamientoBasico.Text = reader["Equipamiento_Basico"]?.ToString();
                        txtEquipamientoConfort.Text = reader["Equipamiento_Confort"]?.ToString();
                        txtEquipamientoSeguridad.Text = reader["Equipamiento_Seguridad"]?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar detalles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSolicitarCita_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Solicitar cita - Próximamente");
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reservar vehículo - Próximamente");
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}