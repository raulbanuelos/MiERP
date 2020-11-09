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
    }
}
