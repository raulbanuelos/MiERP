using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("studentdetails")]
    public class DO_Proveedor
    {
        [Key]
        public int idProveedor { get; set; }
        public int idCompania { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "RFC")]
        public string RFC { get; set; }

        [Display(Name = "Teléfono 1")]
        public string Telefono1 { get; set; }

        [Display(Name = "Teléfono 2")]
        public string Telefono2 { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Name = "Correo")]
        public string Correo { get; set; }
    }
}
