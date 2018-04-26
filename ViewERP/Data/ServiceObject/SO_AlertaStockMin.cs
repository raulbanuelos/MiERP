using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ServiceObject
{
    public class SO_AlertaStockMin
    {
        public IList GetAllAlertasStockMinimo(int idCompania)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var lista = (from a in Conexion.TBL_ALERTAS_STOCK_MIN
                                 join ar in Conexion.TBL_ARTICULO on a.ID_ARTICULO equals ar.ID_ARTICULO
                                 where ar.ID_COMPANIA == idCompania
                                 select a).ToList();

                    return lista;

                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int Insert(int idArticulo, double cantidad)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_ALERTAS_STOCK_MIN obj = new TBL_ALERTAS_STOCK_MIN();

                    obj.CANTIDAD_MINIMA = Convert.ToDecimal(cantidad);
                    obj.ID_ARTICULO = idArticulo;

                    Conexion.TBL_ALERTAS_STOCK_MIN.Add(obj);
                    return obj.ID_ALERTA_STOCK_MIN;

                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int UpdateCantidadMas(int idArticulo, double cantidad)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_ALERTAS_STOCK_MIN obj = Conexion.TBL_ALERTAS_STOCK_MIN.Where(x => x.ID_ARTICULO == idArticulo).FirstOrDefault();

                    obj.CANTIDAD_MINIMA = obj.CANTIDAD_MINIMA + Convert.ToDecimal(cantidad);

                    Conexion.Entry(obj).State = EntityState.Modified;

                    return Conexion.SaveChanges();

                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int UpdateCantidadMenos(int idArticulo, double cantidad)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_ALERTAS_STOCK_MIN obj = Conexion.TBL_ALERTAS_STOCK_MIN.Where(x => x.ID_ARTICULO == idArticulo).FirstOrDefault();

                    obj.CANTIDAD_MINIMA = obj.CANTIDAD_MINIMA - Convert.ToDecimal(cantidad);

                    Conexion.Entry(obj).State = EntityState.Modified;

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
