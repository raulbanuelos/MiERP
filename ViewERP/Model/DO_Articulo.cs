using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Model
{
    [Table("TBL_ARTICULO")]
    public class DO_Articulo
    {
        [Key]
        public int idArticulo { get; set; }
        public int idCompania { get; set; }

        [StringLength(10, MinimumLength = 5,ErrorMessage ="El código debe ser de al menos 5 digitos")]
        [Required(ErrorMessage ="El campo es obligatorio")]
        public string Codigo { get; set; }

        [StringLength(50, MinimumLength = 5,ErrorMessage ="El campo debe ser de al menos 5 digitos y de máximo 50")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Descripcion { get; set; }
        
        [StringLength(50, MinimumLength = 5, ErrorMessage = "El campo debe ser de al menos 5 digitos y de máximo 100")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string NumeroDeSerie { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public int stockMin { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public int stockMax { get; set; }

        [Display(Name = "Categoria")]
        public int ID_CATEGORIA { get; set; }

        public DO_CategoriaArticulo Categoria { get; set; }

        public virtual IEnumerable<SelectListItem> Categorias { get; set; }

        public byte[] CodigoDeBarras { get; set; }

        [Display(Name = "Es consumible")]
        public bool IsConsumible { get; set; }

        [Display(Name = "Precio gerente")]
        public double PRECIO_GERENTE { get; set; }

        [Display(Name = "Precio master")]
        public double PRECIO_MASTER { get; set; }

        [Display(Name = "Precio promotor")]
        public double PRECIO_PROMOTOR { get; set; }

        [Display(Name = "Precio unidad")]
        public double PRECIO_UNIDAD { get; set; }




    }
}
