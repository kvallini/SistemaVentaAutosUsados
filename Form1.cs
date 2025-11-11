using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaVentaAutosUsados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor ingrese usuario y contraseña", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidarCredenciales(usuario, password))
            {
                // Login exitoso
                frmMenuCliente menuPrincipal = new frmMenuCliente();
                menuPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error de autenticación",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsuario.Focus();
            }
        }

        private bool ValidarCredenciales(string usuario, string password)
        {
            try
            {
                using (SqlConnection connection = new ConexionBD().GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT U.ID_Usuario, U.ID_Rol, R.Nombre_Rol, C.ID_Cliente
                                   FROM USUARIOS U
                                   INNER JOIN ROLES_SISTEMA R ON U.ID_Rol = R.ID_Rol
                                   LEFT JOIN CLIENTES C ON U.ID_Usuario = C.ID_Usuario
                                   WHERE U.Email = @Usuario 
                                   AND U.Password = @Password 
                                   AND U.Estado = 1";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UsuarioActual.ID_Usuario = reader.GetInt32(0);
                            UsuarioActual.ID_Rol = reader.GetInt32(1);
                            UsuarioActual.Nombre_Rol = reader.GetString(2);
                            UsuarioActual.Email = usuario;

                            if (!reader.IsDBNull(3))
                                UsuarioActual.ID_Cliente = reader.GetInt32(3);

                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }
    }
}