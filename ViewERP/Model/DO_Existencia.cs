using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DO_Existencia
    {
        public int IdArticulo { get; set; }
        [Key]
        public int idExistencia { get; set; }
        public string CodigoArticulo { get; set; }
        public string Descripcion { get; set; }
        public string NumeroSerie { get; set; }
        public double Cantidad { get; set; }

    }
}
