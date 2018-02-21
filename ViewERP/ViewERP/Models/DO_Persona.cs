using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewERP.Models
{
    public class DO_Persona
    {
        public int idPersona { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public int idJerarquia { get; set; }
        public string CURP { get; set; }
        public string Telefono { get; set; }
        public DateTime fechaNacimiento { get; set; }
        
    }
}