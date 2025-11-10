using System;
using System.Windows.Forms;

namespace SistemaVentaAutosUsados
{
    public partial class Form1 : Form
    {
        private ConexionBD conexionBD;

        public Form1()
        {
            InitializeComponent();
            conexionBD = new ConexionBD();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (conexionBD.ProbarConexion())
            {
                MessageBox.Show("✅ Conexión exitosa a la base de datos", "Éxito",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("❌ No se pudo conectar a la base de datos", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}