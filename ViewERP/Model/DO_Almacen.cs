using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("TBL_ALMACEN")]
    public class DO_Almacen
    {
        [Key]
        public int idAlmacen { get; set; }
        public int idCompania { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
