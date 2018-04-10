using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        [Display(Name = "No. de nómina")]
        public string Usuario { get; set; }
        
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }

        [Display(Name = "idRol")]
        public int ID_ROL { get; set; }

        [Display(Name = "Rol")]
        public string Rol { get; set; }

        [Display(Name = "ID COMPAÑIA")]
        public int idCompania { get; set; }

        public string NombreCompleto
        {
            get
            {
                return Nombre + " " + ApellidoPaterno + " " + ApellidoMaterno;
            }
        }

        public virtual IEnumerable<SelectListItem> Roles { get; set; }

        public override string ToString()
        {
            return Nombre + " " + ApellidoPaterno + " " + ApellidoMaterno;
        }
    }
}