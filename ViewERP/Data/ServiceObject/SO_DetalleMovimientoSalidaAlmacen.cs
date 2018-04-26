using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ServiceObject
{
    public class SO_DetalleMovimientoSalidaAlmacen
    {
        public int Insert(DO_DetalleSalidaAlmacen detalleSalida)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_DETALLE_MOVIMIENTO_SALIDA_ALMACEN tblDetalleSalida = new TBL_DETALLE_MOVIMIENTO_SALIDA_ALMACEN();

                    tblDetalleSalida.ID_MOVIMIENTO_SALIDA_ALMACEN = detalleSalida.MovimientoSalidaAlmacen.idMovimientoAlmacen;
                    tblDetalleSalida.ID_ARTICULO = detalleSalida.Articulo.idArticulo;
                    tblDetalleSalida.CANTIDAD = Convert.ToDecimal(detalleSalida.Cantidad);
                    tblDetalleSalida.CONDICION_ARTICULO_SALIDA = detalleSalida.condicionSalida;
                    tblDetalleSalida.CONDICION_ARTICULO_REGRESO = detalleSalida.condicionRegreso;

                    Conexion.TBL_DETALLE_MOVIMIENTO_SALIDA_ALMACEN.Add(tblDetalleSalida);

                    return Conexion.SaveChanges();

                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
