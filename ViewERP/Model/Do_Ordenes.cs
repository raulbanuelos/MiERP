using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class  DO_Ordenes
    {
        public int Id_Orden { get; set; }
        public string Folio { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string FechaEntrega { get; set; }
        public int Id_Cliente { get; set; }
        public string Requisicion { get; set; }
        public string Proyecto { get; set; }
        public string Usuario { get; set; }
        public List<DO_OrdenesDetalle> OrdernesDetalle { get; set; }
    }
}
