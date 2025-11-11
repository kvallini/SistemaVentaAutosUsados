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

        
        }    
}