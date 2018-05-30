using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DO_DetalleEntradaArticulo
    {
        public int idArticulo { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public double Cantidad { get; set; }
        public int idUnidad { get; set; }
    }
}
