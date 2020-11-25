using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebView.Models
{
    public class DO_Bitacora
    {
        public int IdBitacora { get; set; }
        public string NombreUsuario { get; set; }
        public string Accion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string StringFecha { get; set; }
    }
}