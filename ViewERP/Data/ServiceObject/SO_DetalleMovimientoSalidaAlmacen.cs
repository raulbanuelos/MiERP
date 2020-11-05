using Data.SQLServer;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Data.ServiceObject
{
    public class SO_DetalleMovimientoSalidaAlmacen
    {
        private string SP_ERP_GET_SALIDAS_ALMACEN_CURRENT_WEEK = "SP_ERP_GET_SALIDAS_ALMACEN_CURRENT_WEEK";
        private string SP_ERP_GET_SALIDAS_ALMACEN_POR_WEEK = "SP_ERP_GET_SALIDAS_ALMACEN_POR_WEEK";

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
                                     c.ID_ARTICULO,
                                     c.CODIGO,
                                     c.DESCRIPCION_LARGA,
                                     a.ID_MOVIMIENTO_SALIDA_ALMACEN,
                                     a.FOLIO,
                                     b.FECHA_REGRESO,
                                     b.CONDICION_ARTICULO_SALIDA,
                                     b.CONDICION_ARTICULO_REGRESO,
                                     b.CANTIDAD,
                                     b.ID_DETALLE_MOVIMIENTO_SALIDA_ALMACEN,
                                     a.FECHA_SALIDA, a.USUARIO_ATENDIO,a.USUARIO_SOLICITO
                                 }).ToList();

                    return lista;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int GetIdAlmacenByIdDetalleSalida(int idDetalle)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    int id = (from d in Conexion.TBL_DETALLE_MOVIMIENTO_SALIDA_ALMACEN
                              join s in Conexion.TBL_MOVIMIENTO_SALIDA_ALMACEN on d.ID_MOVIMIENTO_SALIDA_ALMACEN equals s.ID_MOVIMIENTO_SALIDA_ALMACEN
                              where d.ID_DETALLE_MOVIMIENTO_SALIDA_ALMACEN == idDetalle
                              select s.ID_ALMACEN).FirstOrDefault();

                    return id;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int GetIdArticuloByIdDetalleSalida(int idDetalle)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    int id = (from d in Conexion.TBL_DETALLE_MOVIMIENTO_SALIDA_ALMACEN
                              join a in Conexion.TBL_ARTICULO on d.ID_ARTICULO equals a.ID_ARTICULO
                              where d.ID_DETALLE_MOVIMIENTO_SALIDA_ALMACEN == idDetalle
                              select a.ID_ARTICULO).FirstOrDefault();

                    return id;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public DataSet GetSalidasCurrentWeek(int idCompania)
        {
            try
            {
                DataSet datos = null;

                ERP_SQL conexion = new ERP_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("idCompania", idCompania);

                datos = conexion.EjecutarStoredProcedure(SP_ERP_GET_SALIDAS_ALMACEN_CURRENT_WEEK, parametros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataSet GetSalidasPorWeek(int idCompania, int idSemana)
        {
            try
            {
                DataSet datos = null;

                ERP_SQL conexion = new ERP_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("idCompania", idCompania);
                parametros.Add("idSemana", idSemana);

                datos = conexion.EjecutarStoredProcedure(SP_ERP_GET_SALIDAS_ALMACEN_POR_WEEK, parametros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
