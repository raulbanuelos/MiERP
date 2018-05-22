using System.Collections.Generic;
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
        public string numeroCategoria { get; set; }

        public List<DO_Articulo> Articulos { get; set; }

        public DO_CategoriaArticulo()
        {
            Articulos = new List<DO_Articulo>();
        }
    }
}
