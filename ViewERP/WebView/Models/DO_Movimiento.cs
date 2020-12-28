using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebView.Models
{
    public class DO_Movimiento
    {
        public int IdMovimiento { get; set; }
        public int IdArticulo { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public string BodegaDestino { get; set; }
        public string Tipo { get; set; }
        public string fecha { get; set; }
        public double CostoGuia { get; set; }
        public string NoFactura { get; set; }
    }
}