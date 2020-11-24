using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ServiceObject
{
    public class SO_Bitacora
    {
        public int Insert(string accion, string nombreUsuario)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_ERP_BITACORA tBL_ERP_BITACORA = new TBL_ERP_BITACORA();

                    tBL_ERP_BITACORA.ACCION = accion;
                    tBL_ERP_BITACORA.FECHA_REGISTRO = DateTime.Now;
                    tBL_ERP_BITACORA.USUARIO = nombreUsuario;

                    Conexion.TBL_ERP_BITACORA.Add(tBL_ERP_BITACORA);

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public IList Get()
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var list = (from a in Conexion.TBL_ERP_BITACORA
                                orderby a.FECHA_REGISTRO descending
                                select a).Take(100).ToList();

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
