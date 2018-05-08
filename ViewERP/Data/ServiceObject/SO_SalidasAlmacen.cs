using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ServiceObject
{
    public class SO_SalidasAlmacen
    {
        public int InsertSalida(int idAlmacen, string usuarioSolicito,string usuarioAtendio)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_MOVIMIENTO_SALIDA_ALMACEN obj = new TBL_MOVIMIENTO_SALIDA_ALMACEN();

                    obj.ID_ALMACEN = idAlmacen;
                    obj.USUARIO_SOLICITO = usuarioSolicito;
                    obj.FECHA_SALIDA = DateTime.Now;
                    obj.USUARIO_ATENDIO = usuarioAtendio;

                    Conexion.TBL_MOVIMIENTO_SALIDA_ALMACEN.Add(obj);

                    Conexion.SaveChanges();

                    return obj.ID_MOVIMIENTO_SALIDA_ALMACEN;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public IList GetArticulosSalida(int idMovimientoSalida)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var lista = (from d in Conexion.TBL_DETALLE_MOVIMIENTO_SALIDA_ALMACEN
                                 where d.ID_MOVIMIENTO_SALIDA_ALMACEN == idMovimientoSalida
                                 select d).ToList();

                    return lista;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IList GetMovimientoSalida(int idMovimientoSalida)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var lista = (from m in Conexion.TBL_MOVIMIENTO_SALIDA_ALMACEN
                                 where m.ID_MOVIMIENTO_SALIDA_ALMACEN == idMovimientoSalida
                                 select m).ToList();

                    return lista;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IList GetSalida(int idSalida)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var lista = (from s in Conexion.TBL_MOVIMIENTO_SALIDA_ALMACEN
                                 join w in Conexion.TBL_ALMACEN on s.ID_ALMACEN equals w.ID_ALMACEN
                                 join d in Conexion.TBL_DETALLE_MOVIMIENTO_SALIDA_ALMACEN on s.ID_MOVIMIENTO_SALIDA_ALMACEN equals d.ID_MOVIMIENTO_SALIDA_ALMACEN
                                 join a in Conexion.TBL_ARTICULO on d.ID_ARTICULO equals a.ID_ARTICULO
                                 where s.ID_MOVIMIENTO_SALIDA_ALMACEN == idSalida
                                 select new {
                                     s.ID_MOVIMIENTO_SALIDA_ALMACEN,
                                     s.ID_ALMACEN, w.NOMBRE,
                                     d.ID_ARTICULO,a.CODIGO,a.DESCRIPCION, a.FOTO,a.CONSUMIBLE,
                                     s.FECHA_SALIDA,s.USUARIO_SOLICITO,s.USUARIO_ATENDIO
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
