using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ServiceObject
{
    public class SO_CorteExistencia
    {
        public IList Get(int idSemana, int idAlmacen)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var lista = (from a in Conexion.TBL_ERP_CORTE_EXISTENCIA_ALMACEN
                                 where a.ID_SEMANA == idSemana && a.ID_ALMACEN == idAlmacen
                                 select new
                                 {
                                     a.ID_ARTICULO,
                                     a.CANTIDAD
                                 }).ToList();

                    return lista;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public int Insert(int idSemana, int idAlmacen, int idArticulo, int cantidad)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_ERP_CORTE_EXISTENCIA_ALMACEN tBL_ERP_CORTE_EXISTENCIA_ALMACEN = new TBL_ERP_CORTE_EXISTENCIA_ALMACEN();

                    tBL_ERP_CORTE_EXISTENCIA_ALMACEN.ID_SEMANA = idSemana;
                    tBL_ERP_CORTE_EXISTENCIA_ALMACEN.ID_ALMACEN = idAlmacen;
                    tBL_ERP_CORTE_EXISTENCIA_ALMACEN.ID_ARTICULO = idArticulo;
                    tBL_ERP_CORTE_EXISTENCIA_ALMACEN.CANTIDAD = cantidad;

                    Conexion.TBL_ERP_CORTE_EXISTENCIA_ALMACEN.Add(tBL_ERP_CORTE_EXISTENCIA_ALMACEN);

                    Conexion.SaveChanges();

                    return tBL_ERP_CORTE_EXISTENCIA_ALMACEN.ID_CORTE_EXISTENCIA_ALMACEN;
                }
            }
            catch (Exception)
            {
                return 0;
            }    
        }
    }
}
