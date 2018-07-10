using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DO_AlertaStock
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }
        public int CantidadEnAlmacen { get; set; }
    }
}
