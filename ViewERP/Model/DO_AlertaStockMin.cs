using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DO_AlertaStockMin
    {
        [Key]
        public int idAlertaStockMin { get; set; }
        public DO_Articulo Articulo { get; set; }
        public double Cantidad { get; set; }

    }
}
