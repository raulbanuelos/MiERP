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
        public string Nombre { get; set; }
        public string RFC { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
    }
}
