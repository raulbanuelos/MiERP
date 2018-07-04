using Model;
using System;
using System.Collections;
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

        public IList GetDetalleSalida(string folio)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var lista = (from a in Conexion.TBL_MOVIMIENTO_SALIDA_ALMACEN
                                 join b in Conexion.TBL_DETALLE_MOVIMIENTO_SALIDA_ALMACEN on a.ID_MOVIMIENTO_SALIDA_ALMACEN equals b.ID_MOVIMIENTO_SALIDA_ALMACEN
                                 join c in Conexion.TBL_ARTICULO on b.ID_ARTICULO equals c.ID_ARTICULO
                                 where a.FOLIO == folio
                                 select new
                                 {
                                     c.CODIGO,
                                     c.DESCRIPCION_LARGA,
                                     a.ID_MOVIMIENTO_SALIDA_ALMACEN,
                                     a.FOLIO,
                                     b.FECHA_REGRESO,
                                     b.CONDICION_ARTICULO_SALIDA,
                                     b.CONDICION_ARTICULO_REGRESO,
                                     b.CANTIDAD
                                 }).ToList();

                    return lista;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
