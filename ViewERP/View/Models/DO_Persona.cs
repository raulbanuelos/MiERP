using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace View.Models
{
    public class DO_Persona
    {
        [Key]
        public int idUsuario { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido paterno")]
        public string ApellidoPaterno { get; set; }

        [Display(Name = "Apellido materno")]
        public string ApellidoMaterno { get; set; }

        [Display(Name = "No. de nomina")]
        public string Usuario { get; set; }

        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }

        [Display(Name = "Rol")]
        public int idRol { get; set; }

        [Display(Name = "ID COMPAÑIA")]
        public int idCompania { get; set; }

        public string NombreCompleto
        {
            get
            {
                return Nombre + " " + ApellidoPaterno + " " + ApellidoMaterno;
            }
        }
    }
}