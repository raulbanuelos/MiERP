using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DO_DetalleSalidaArticulo
    {
        public int idCodigo { get; set; }
        public string codigo { get; set; }
        public double cantidad { get; set; }
        public string condicion { get; set; }
        public string Descripcion { get; set; }
    }
}
