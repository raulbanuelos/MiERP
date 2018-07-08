using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public  class DO_OrdenesDetalle
    {
        public int Id_OrdenDetalle { get; set; }
        public int Id_Orden { get; set; }
        public int Id_Producto { get; set; }
        public int Id_EstatusOrden { get; set; }
        public int Cantidad { get; set; }
        public int EntregaParcial { get; set; }
        public string EntregarA { get; set; }
        public DateTime? FechaActualizacionEstatus { get; set; }
    }
}
