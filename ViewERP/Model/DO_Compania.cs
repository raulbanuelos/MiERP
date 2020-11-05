using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DO_Compania
    {
        public int IdCompania { get; set; }
        public string Nombre { get; set; }
        public string RFC { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
