using System;
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
    }
}
