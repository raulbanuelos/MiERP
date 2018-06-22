using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DO_MovimientoSalidaAlmacen
    {
        [Key]
        public int IdMovimientoSalidaAlmacen { get; set; }
        public int IdAlmacen { get; set; }
        public string Folio { get; set; }
        public string UsuarioSolicito { get; set; }
        public DateTime FechaSalida { get; set; }
        public string UsuarioAtendio { get; set; }
    }
}
