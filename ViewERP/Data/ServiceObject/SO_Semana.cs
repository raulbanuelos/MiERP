using Data.SQLServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Data.ServiceObject
{
    public class SO_Semana
    {
        private string SP_ERP_GET_SEMANA_ACTUAL = "SP_ERP_GET_SEMANA_ACTUAL";

        public DataSet GetSemanaActual()
        {
            try
            {
                DataSet datos = null;

                ERP_SQL conexion = new ERP_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();

                datos = conexion.EjecutarStoredProcedure(SP_ERP_GET_SEMANA_ACTUAL, parametros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
