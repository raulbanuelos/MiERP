using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("TBL_CATEGORIA_ARTICULO")]
    public class DO_CategoriaArticulo
    {
        [Key]
        public int idCategoriaArticulo { get; set; }
        public int idCompania { get; set; }
        public string NombreCategoria { get; set; }
    }
}
