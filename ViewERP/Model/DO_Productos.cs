using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DO_Productos
    {
        public int Id_Productos { get; set; }
        public int Id_Categoria { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public BadImageFormatException foto;

    }
}
