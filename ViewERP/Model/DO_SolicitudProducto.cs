using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DO_SolicitudProducto
    {
        public int idProducto { get; set; }
        public string descripcion { get; set; }
        public int cantidad { get; set; }
        public string EntregarA { get; set; }
    }
}
