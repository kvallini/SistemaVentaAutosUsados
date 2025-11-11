using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaVentaAutosUsados
{
    public partial class frmCatalogo : Form
    {
        private int clienteId;
        private DataTable vehiculosTable;
        private ConexionBD dbConnection;

        public frmCatalogo(int idCliente)
        {
            InitializeComponent();
            this.clienteId = idCliente;
            dbConnection = new ConexionBD();
        }

        private void frmCatalogo_Load(object sender, EventArgs e)
        {
            CargarVehiculos();
            CargarFiltros();
        }

        private void CargarVehiculos()
        {
            try
            {
                using (SqlConnection connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT ID_Vehiculo, Marca, Modelo, Año, Color, Precio, 
                            Kilometraje, Tipo_Combustible, Transmision, 
                            Estado_Vehiculo, Imagen_Principal
                            FROM VEHICULOS 
                            WHERE Estado_Vehiculo = 'Disponible'";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    vehiculosTable = new DataTable();
                    adapter.Fill(vehiculosTable);

                    dtgVehiculos.DataSource = vehiculosTable;
                    ConfigurarDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar vehículos: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView()
        {
            // Ocultar columnas que no queremos mostrar
            if (dtgVehiculos.Columns.Contains("ID_Vehiculo"))
                dtgVehiculos.Columns["ID_Vehiculo"].Visible = false;

            if (dtgVehiculos.Columns.Contains("Imagen_Principal"))
                dtgVehiculos.Columns["Imagen_Principal"].Visible = false;

            // Formatear columnas
            if (dtgVehiculos.Columns.Contains("Precio"))
            {
                dtgVehiculos.Columns["Precio"].DefaultCellStyle.Format = "C";
                dtgVehiculos.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Ajustar ancho de columnas
            dtgVehiculos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarFiltros()
        {
            try
            {
                cmbFiltroMarca.Items.Add("Todos");

                using (SqlConnection connection = dbConnection.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT DISTINCT Marca FROM VEHICULOS WHERE Estado_Vehiculo = 'Disponible'";
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        cmbFiltroMarca.Items.Add(reader["Marca"].ToString());
                    }
                }

                cmbFiltroMarca.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar filtros: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltrarVehiculos()
        {
            if (vehiculosTable == null) return;

            string marcaSeleccionada = cmbFiltroMarca.SelectedItem.ToString();

            if (marcaSeleccionada == "Todos")
            {
                vehiculosTable.DefaultView.RowFilter = "";
            }
            else
            {
                vehiculosTable.DefaultView.RowFilter = $"Marca = '{marcaSeleccionada}'";
            }
        }

        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            if (dtgVehiculos.CurrentRow != null)
            {
                int idVehiculo = Convert.ToInt32(dtgVehiculos.CurrentRow.Cells["ID_Vehiculo"].Value);

                // Abrir formulario de detalles
                fmrDetalleVehiculo detallesForm = new fmrDetalleVehiculo(idVehiculo, clienteId);
                detallesForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor seleccione un vehículo", "Selección requerida",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbFiltroMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarVehiculos();
        }

        private void dtgVehiculos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Por ahora vacío
        }

        private void dtgVehiculos_SelectionChanged(object sender, EventArgs e)
        {
            // Por ahora vacío
        }
    }
}