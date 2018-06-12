using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DO_ReporteEntradaArticulo
    {
        public string NO_FACTURA { get; set; }
        public DateTime FECHA { get; set; }
        public string USUARIO { get; set; }
        public string NOMBRE { get; set; }
        public string NOMBRE_PROVEEDOR { get; set; }
        public string DESCRIPCION_ARTICULO { get; set; }
        public string CODIGO_ARTICULO { get; set; }
        public double CANTIDAD { get; set; }
        public string NOMBRE_UNIDAD { get; set; }
    }
}
