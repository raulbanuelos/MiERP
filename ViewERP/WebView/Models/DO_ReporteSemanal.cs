using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebView.Models
{
    public class DO_ReporteSemanal
    {
        public int IdArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public int InventarioInicial { get; set; }
        public int Entradas { get; set; }
        public string Origen { get; set; }
        public int Salidas { get; set; }
        public string Destino { get; set; }
        public int ArticulosVendidos { get; set; }
        public double CostoUnitario { get; set; }

    }
}