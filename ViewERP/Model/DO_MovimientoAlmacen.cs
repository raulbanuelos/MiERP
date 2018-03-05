using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DO_MovimientoAlmacen
    {
        public int idMovimientoAlmacen { get; set; }
        public int idTipoMovimientoAlmacen { get; set; }
        public int idAlmacen { get; set; }
        public int idArticulo { get; set; }
        public int idProveedor { get; set; }
        public int Cantidad { get; set; }
        public string Unidad { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
    }
}
