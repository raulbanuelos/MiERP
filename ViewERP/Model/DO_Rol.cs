using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DO_Rol
    {
        [Key]
        public int idRol { get; set; }

        [Display(Name = "Rol")]
        public string Rol { get; set; }
    }
}
