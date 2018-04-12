using System;
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
