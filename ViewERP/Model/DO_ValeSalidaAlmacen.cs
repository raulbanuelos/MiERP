using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DO_ValeSalidaAlmacen
    {
        [Key]
        public int ID_MOVIMIENTO_SALIDA_ALMACEN { get; set; }
        public string Almacen { get; set; }
        public string PersonaSolicito { get; set; }
        public DateTime FechaSolicito { get; set; }
        public string PersonaAtendio { get; set; }

        public List<DO_DetalleSalidaArticulo> ListaArticulos { get; set; }


    }
}
