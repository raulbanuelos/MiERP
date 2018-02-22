using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewERP.Models
{
    public class DO_Persona
    {
        public int idUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public int idRol { get; set; }
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