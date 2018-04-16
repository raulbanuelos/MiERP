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
        public int InsertSalida(int idAlmacen, int idArticulo, string usuarioSolicito, double cantidad,string condicionArticuloSalida,bool isConsumible,string usuarioAtendio)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_MOVIMIENTO_SALIDA_ALMACEN obj = new TBL_MOVIMIENTO_SALIDA_ALMACEN();

                    obj.ID_ALMACEN = idAlmacen;
                    obj.ID_ARTICULO = idArticulo;
                    obj.USUARIO_SOLICITO = usuarioSolicito;
                    obj.CANTIDAD = Convert.ToDecimal(cantidad);
                    obj.FECHA_SALIDA = DateTime.Now;
                    obj.CONDICION_ARTICULO_SALIDA = condicionArticuloSalida;
                    obj.CONSUMIBLE = isConsumible;
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

        public IList GetSalida(int idSalida)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var lista = (from s in Conexion.TBL_MOVIMIENTO_SALIDA_ALMACEN
                                 join w in Conexion.TBL_ALMACEN on s.ID_ALMACEN equals w.ID_ALMACEN
                                 join a in Conexion.TBL_ARTICULO on s.ID_ARTICULO equals a.ID_ARTICULO
                                 where s.ID_MOVIMIENTO_SALIDA_ALMACEN == idSalida
                                 select new {
                                     s.ID_MOVIMIENTO_SALIDA_ALMACEN,
                                     s.ID_ALMACEN, w.NOMBRE,
                                     s.ID_ARTICULO,a.CODIGO,a.DESCRIPCION, a.FOTO,a.CONSUMIBLE,
                                     s.FECHA_SALIDA,s.CANTIDAD,s.CONDICION_ARTICULO_SALIDA,s.USUARIO_SOLICITO,s.USUARIO_ATENDIO
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
