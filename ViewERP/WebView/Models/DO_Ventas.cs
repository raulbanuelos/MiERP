using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebView.Models
{
    public class DO_Ventas
    {
        public int IdArticulo { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Total {
            get
            {
                return Math.Round(Cantidad * Precio, 2);
            }
        }

        public int IdPromotor { get; set; }

        public string sFecha { get; set; }
    }
}