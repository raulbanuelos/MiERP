using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace View.Models
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