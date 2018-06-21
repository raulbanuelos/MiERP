using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DO_ReporteSalidaArticulo
    {
        public string NOMBRE_ALMACEN { get; set; }
        public string FECHA_SALIDA { get; set; }
        public string FECHA_REGRESO { get; set; }
        public string USUARIO_ATENDIO { get; set; }
        public string USUARIO_SOLICITO { get; set; }
        public string CODIGO { get; set; }
        public string DESCRIPCION_ARTICULO { get; set; }
        public double CANTIDAD { get; set; }
    }
}
