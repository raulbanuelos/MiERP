using Data.SQLServer;
using System;
using System.Collections;
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

        public IList GetSemanas(DateTime dateTimeFirst)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var lista = (from s in Conexion.TBL_SEMANA
                                 where s.DIA_FINAL > dateTimeFirst && DateTime.Now > s.DIA_INICIAL
                                 orderby s.DIA_INICIAL descending
                                 select s).ToList();
                    return lista;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IList GetSemana(int idSemana)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var lista = (from a in Conexion.TBL_SEMANA
                             where a.ID_SEMANA == idSemana
                             select a).ToList();
                    return lista;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IList GetLastSemana(int idSemana, int c)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var list = (from a in Conexion.TBL_SEMANA
                                where a.ID_SEMANA <= idSemana
                                orderby a.ID_SEMANA descending
                                select a).Take(c).ToList();

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
