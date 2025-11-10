using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentaAutosUsados.Models
{
    public class Vehiculo
    {
        public int ID_Vehiculo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Año { get; set; }
        public decimal Precio { get; set; }
        public string Color { get; set; }
        public string Estado_Vehiculo { get; set; }
    }
}
