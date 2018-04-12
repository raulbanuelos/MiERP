using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DO_Unidad
    {
        [Key]
        public int idUnidad { get; set; }
        public string NombreUnidad { get; set; }
    }
}
