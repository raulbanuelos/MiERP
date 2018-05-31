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
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public decimal cantidad { get; set; }
        public int idUnidad { get; set; }
    }
}
