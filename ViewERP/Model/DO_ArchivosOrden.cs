using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class DO_ArchivosOrden
    {
        public int Id_ArchivoOrden { get; set; }
        public byte[] Archivo { get; set; }
        public string Nombre { get; set; }
        public string Extension { get; set; }
        public int Id_Orden { get; set; }
    }
}
