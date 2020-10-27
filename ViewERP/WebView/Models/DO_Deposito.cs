using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebView.Models
{
    public class DO_Deposito
    {
        public int IdDeposito { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaRegistro { get; set; }
        public double Importe { get; set; }
        public string Banco { get; set; }
        public string Descripcion { get; set; }
        public string UrlArchivo { get; set; }

        public string SFechaIngreso {
            get
            {
                return FechaIngreso.Day + "-" + FechaIngreso.Month + "-" + FechaIngreso.Year;
            }
        }
    }
}