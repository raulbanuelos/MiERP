using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ServiceObject
{
    public class SO_Unidad
    {
        public IList GetAllUnidades()
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var lista = (from u in Conexion.TBL_UNIDAD select u).ToList();

                    return lista;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
