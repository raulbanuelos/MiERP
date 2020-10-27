using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ServiceObject
{
    public class SO_Depositos
    {
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
    }
}
