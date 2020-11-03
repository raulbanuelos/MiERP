using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ServiceObject
{
    public class SO_Details_Venta
    {
        public int Insert(int idVenta, int idArticulo, int cantidad, double precio)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_DETAILS_VENTA tBL_DETAILS_VENTA = new TBL_DETAILS_VENTA();

                    tBL_DETAILS_VENTA.ID_VENTA = idVenta;
                    tBL_DETAILS_VENTA.ID_ARTICULO = idArticulo;
                    tBL_DETAILS_VENTA.CANTIDAD = cantidad;
                    tBL_DETAILS_VENTA.PRECIO = precio;

                    Conexion.TBL_DETAILS_VENTA.Add(tBL_DETAILS_VENTA);

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public IList GetLastVenta(int idCompania)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var list = (from a in Conexion.TBL_VENTA
                                join b in Conexion.TBL_DETAILS_VENTA on a.ID_VENTA equals b.ID_VENTA
                                join c in Conexion.TBL_ARTICULO on b.ID_ARTICULO equals c.ID_ARTICULO
                                join d in Conexion.TBL_COMPANIA on c.ID_COMPANIA equals d.ID_COMPANIA
                                where d.ID_COMPANIA == idCompania
                                orderby a.FECHA_REGISTRO descending
                                select new { 
                                    c.DESCRIPCION,
                                    b.CANTIDAD,
                                    b.PRECIO
                                }).Take(5).ToList();

                    return list;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
