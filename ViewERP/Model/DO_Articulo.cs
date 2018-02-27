using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("TBL_ARTICULO")]
    public class DO_Articulo
    {
        [Key]
        public int idArticulo { get; set; }
        public int idCompania { get; set; }
        public int idCategoria { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionLarga { get; set; }
        public byte[] foto { get; set; }
        public int stockMin { get; set; }
        public int stockMax { get; set; }
    }
}
