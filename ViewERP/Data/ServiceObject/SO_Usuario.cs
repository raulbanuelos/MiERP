using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ServiceObject
{
    public class SO_Usuario
    {
        public IList GetLogin(string usuario, string contrasena)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var lista = (from u in Conexion.TBL_USUARIO
                                 where u.USUARIO == usuario && u.CONTRASENA == contrasena
                                 select u).ToList();
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
