using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVentaAutosUsados
{
    public partial class frmMenuCliente : Form
    {
        public frmMenuCliente()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            frmCatalogo catalogoForm = new frmCatalogo(UsuarioActual.ID_Cliente);
            catalogoForm.Show();
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {

        }

        private void btnCitas_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
