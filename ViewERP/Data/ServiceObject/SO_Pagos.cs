using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ServiceObject
{
    public class SO_Pagos
    {
        public IList GetUltimoPago(int idCompania)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var fechaUltimoPago = (from a in Conexion.TBL_ERP_PAGO_PLAN
                                           where a.ID_COMPANIA == idCompania
                                           orderby a.FECHA_PAGO descending
                                           select a).Take(1).ToList();
                    return fechaUltimoPago;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
