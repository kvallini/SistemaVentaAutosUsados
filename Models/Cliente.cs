using System;

namespace SistemaVentaAutosUsados.Models
{
    public class Cliente
    {
        public int ID_Cliente { get; set; }        
        public int ID_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Primer_Apellido { get; set; }
        public string Segundo_Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Estado { get; set; }

        public string NombreCompleto
        {
            get { return $"{Nombre} {Primer_Apellido} {Segundo_Apellido}"; }
        }
    }
}