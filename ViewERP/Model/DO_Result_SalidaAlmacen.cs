using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DO_Result_SalidaAlmacen
    {
        public int idSalidaAlmacen { get; set; }
        public string NombreSolicitante { get; set; }
        public string NombreAlmacen { get; set; }

        //public string CodigoArticulo { get; set; }
        //public string DescripcionArticulo { get; set; }
        //public double CantidadSolicitada { get; set; }
        //public byte[] codigoBarras { get; set; }

        public List<DO_DetalleSalidaArticulo> ListaArticulos { get; set; }

        public DateTime FechaSolicitud { get; set; }
        public string NombreAtendio { get; set; }

        public string Respuesta { get; set; }
        public int ResultCode { get; set; }
    }
}
