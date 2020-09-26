using Data.SQLServer;
using System;
using System.Collections.Generic;
using System.Data;

namespace Data.ServiceObject
{
    public class SO_Venta
    {
        private string SP_ERP_GetVentaDiaria = "SP_ERP_GetVentaDiaria";
        public int Insert(int idUsuario, double monto, DateTime fechaIngreso)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_VENTA venta = new TBL_VENTA();

                    venta.FECHA_INGRESO = fechaIngreso;
                    venta.ID_USUARIO = idUsuario;
                    venta.MONTO = monto;
                    venta.FECHA_REGISTRO = DateTime.Now;

                    Conexion.TBL_VENTA.Add(venta);

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public DataSet GetVentaDiaria(int idUsuario)
        {
            try
            {
                DataSet datos = null;

                ERP_SQL conexion = new ERP_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("idUsuario", idUsuario);

                datos = conexion.EjecutarStoredProcedure(SP_ERP_GetVentaDiaria, parametros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
