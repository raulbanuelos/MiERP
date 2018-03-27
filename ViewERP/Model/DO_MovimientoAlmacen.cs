using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Model
{
    [Table("TBL_MOVIMIENTO_ALMACEN")]
    public class DO_MovimientoAlmacen
    {
        [Key]
        public int idMovimientoAlmacen { get; set; }

        public int idAlmacen { get; set; }

        public int idArticulo { get; set; }

        public int idProveedor { get; set; }

        public int idUnidad { get; set; }

        public int Cantidad { get; set; }

        public DateTime Fecha { get; set; }

        public string Usuario { get; set; }

        public virtual IEnumerable<SelectListItem> Almacenes { get; set; }

        public virtual IEnumerable<SelectListItem> Articulos { get; set; }

        public virtual IEnumerable<SelectListItem> Proveedores { get; set; }

        public virtual IEnumerable<SelectListItem> Unidades { get; set; }


    }
}
