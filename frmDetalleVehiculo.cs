using SistemaVentaAutosUsados.Models;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

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
                        // Cargar datos en los labels
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

                        // Cargar textboxes
                        txtEquipamientoBasico.Text = reader["Equipamiento_Basico"]?.ToString();
                        txtEquipamientoConfort.Text = reader["Equipamiento_Confort"]?.ToString();
                        txtEquipamientoSeguridad.Text = reader["Equipamiento_Seguridad"]?.ToString();

                        // CARGAR LA IMAGEN
                        string nombreImagen = reader["Imagen_Principal"]?.ToString();
                        CargarImagenVehiculo(nombreImagen);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar detalles: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarImagenVehiculo(string nombreImagen)
        {
            try
            {
                if (string.IsNullOrEmpty(nombreImagen))
                {
                    MessageBox.Show("Este vehículo no tiene imagen asignada");
                    return;
                }

                // CORREGIR LA RUTA BASE
                string rutaBase = @"C:\C#2025\IIICUATRI\PROYECTO\FOTOSVEH\";

                // AGREGAR EXTENSIÓN SI NO TIENE
                if (!nombreImagen.Contains("."))
                {
                    nombreImagen += ".jpg"; // O prueba con .png
                }

                string rutaCompleta = Path.Combine(rutaBase, nombreImagen);

                // VERIFICAR ANTES DE CARGAR
                if (!File.Exists(rutaCompleta))
                {
                    MessageBox.Show($"❌ No existe: {rutaCompleta}");

                    // Buscar archivos similares
                    string[] archivosSimilares = Directory.GetFiles(rutaBase, "*" + nombreImagen + "*");
                    if (archivosSimilares.Length > 0)
                    {
                        MessageBox.Show("¿Quizás quisiste decir?\n" + string.Join("\n", archivosSimilares));
                    }
                    return;
                }

                // SI LLEGA AQUÍ, CARGAR LA IMAGEN
                pictureBoxFoto1.Image = Image.FromFile(rutaCompleta);
                pictureBoxFoto1.SizeMode = PictureBoxSizeMode.Zoom;
                MessageBox.Show($"✅ Imagen cargada: {Path.GetFileName(rutaCompleta)}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar imagen: " + ex.Message);
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