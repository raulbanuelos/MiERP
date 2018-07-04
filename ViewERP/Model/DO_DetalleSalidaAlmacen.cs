using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DO_DetalleSalidaAlmacen
    {
        [Key]
        public int idDetalleSalidaAlmacen { get; set; }
        public DO_MovimientoAlmacen MovimientoSalidaAlmacen { get; set; }
        public DO_Articulo Articulo { get; set; }
        public double Cantidad { get; set; }
        public string condicionSalida { get; set; }
        public string condicionRegreso { get; set; }
        public DateTime? FechaRegreso { get; set; }


    }
}
