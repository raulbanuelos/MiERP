using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DO_Organizacion
    {
        public int IdOrganizacion { get; set; }
        
        public int IdCompaniaAdmin { get; set; }

        public string Nombre { get; set; }

        public List<DO_Compania> Companias { get; set; }

        public DateTime FechaRegistro { get; set; }


    }
}
