using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("TBL_ARTICULO")]
    public class DO_Articulo
    {
        [Key]
        public int idArticulo { get; set; }
        public int idCompania { get; set; }

        [StringLength(10, MinimumLength = 1)]
        public string Codigo { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string Descripcion { get; set; }

        [StringLength(100, MinimumLength = 1)]
        public string DescripcionLarga { get; set; }


        public byte[] foto { get; set; }


        public int stockMin { get; set; }
        public int stockMax { get; set; }

        [Display(Name = "Categoria")]
        public int ID_CATEGORIA { get; set; }

        public virtual IEnumerable<SelectListItem> Categorias { get; set; }

    }
}
