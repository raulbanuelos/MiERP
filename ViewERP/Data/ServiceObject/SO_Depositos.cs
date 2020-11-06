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
    public class SO_Depositos
    {
        private string SP_ERP_GET_DEPOSITOS_POR_WEEK = "SP_ERP_GET_DEPOSITOS_POR_WEEK";
        public int Insert(int idUsuario, double monto, DateTime fechaIngreso, string banco, string descripcion, string urlArchivo)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_DEPOSITOS deposito = new TBL_DEPOSITOS();

                    deposito.FECHA_INGRESO = fechaIngreso;
                    deposito.ID_USUARIO = idUsuario;
                    deposito.MONTO = monto;
                    deposito.FECHA_REGISTRO = DateTime.Now;
                    deposito.BANCO = banco;
                    deposito.DESCRIPCION = descripcion;
                    deposito.URL_ARCHIVO = urlArchivo;

                    Conexion.TBL_DEPOSITOS.Add(deposito);

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public IList GetUltimosDepositos(int idUsuario)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var lista = (from a in Conexion.TBL_DEPOSITOS
                                 where a.ID_USUARIO == idUsuario
                                 orderby a.FECHA_INGRESO descending
                                 select a).Take(5).ToList();

                    return lista;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataSet GetDepositosPorWeek(int idUsuario, int idSemana)
        {
            try
            {
                DataSet datos = null;

                ERP_SQL conexion = new ERP_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("idUsuario", idUsuario);
                parametros.Add("idSemana", idSemana);

                datos = conexion.EjecutarStoredProcedure(SP_ERP_GET_DEPOSITOS_POR_WEEK, parametros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
