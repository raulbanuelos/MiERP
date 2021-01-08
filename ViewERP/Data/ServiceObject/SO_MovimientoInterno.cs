using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ServiceObject
{
    public class SO_MovimientoInterno
    {
        public int Insert(int idAlmacenOrigen, int idAlmacenDestino, string folio)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_MOVIMIENTO_ALMACEN_INTERNO tBL_MOVIMIENTO_ALMACEN_INTERNO = new TBL_MOVIMIENTO_ALMACEN_INTERNO();

                    tBL_MOVIMIENTO_ALMACEN_INTERNO.ID_ALMACEN_ORIGEN = idAlmacenOrigen;
                    tBL_MOVIMIENTO_ALMACEN_INTERNO.ID_ALMACEN_DESTINO = idAlmacenDestino;
                    tBL_MOVIMIENTO_ALMACEN_INTERNO.FOLIO = folio;
                    tBL_MOVIMIENTO_ALMACEN_INTERNO.FECHA = DateTime.Now;

                    Conexion.TBL_MOVIMIENTO_ALMACEN_INTERNO.Add(tBL_MOVIMIENTO_ALMACEN_INTERNO);

                    Conexion.SaveChanges();

                    return tBL_MOVIMIENTO_ALMACEN_INTERNO.ID_MOVIMIENTO_ALMACEN_INTERNO;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        
        public int InsertDetalle(int idMovimientoInterno, int idArticulo, decimal cantidad)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_DETALLE_MOVIMIENTO_ALMACEN_INTERNO tBL_DETALLE_MOVIMIENTO_ALMACEN_INTERNO = new TBL_DETALLE_MOVIMIENTO_ALMACEN_INTERNO();

                    tBL_DETALLE_MOVIMIENTO_ALMACEN_INTERNO.ID_MOVIMIENTO_ALMACEN_INTERNO = idMovimientoInterno;
                    tBL_DETALLE_MOVIMIENTO_ALMACEN_INTERNO.ID_ARTICULO = idArticulo;
                    tBL_DETALLE_MOVIMIENTO_ALMACEN_INTERNO.CANTIDAD = cantidad;

                    Conexion.TBL_DETALLE_MOVIMIENTO_ALMACEN_INTERNO.Add(tBL_DETALLE_MOVIMIENTO_ALMACEN_INTERNO);

                    Conexion.SaveChanges();

                    return tBL_DETALLE_MOVIMIENTO_ALMACEN_INTERNO.ID_DETALLE_MOVIMIENTO_ALMACEN_INTERNO;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
