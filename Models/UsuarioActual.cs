using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentaAutosUsados
{
    public static class UsuarioActual
    {
        public static int ID_Usuario { get; set; }
        public static int ID_Rol { get; set; }
        public static string Nombre_Rol { get; set; }
        public static string Email { get; set; }
        public static int ID_Cliente { get; set; }

        public static void CerrarSesion()
        {
            ID_Usuario = 0;
            ID_Rol = 0;
            Nombre_Rol = "";
            Email = "";
            ID_Cliente = 0;
        }
    }
}
