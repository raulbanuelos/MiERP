using Data.SQLServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Policy;

namespace Data.ServiceObject
{
    public class SO_Venta
    {
        private string SP_ERP_GetVentaDiaria = "SP_ERP_GetVentaDiaria";
        private string SP_ERP_GET_MONTO_VENTA_DIARIA = "SP_ERP_GET_MONTO_VENTA_DIARIA";
        private string SP_ERP_GET_MONTO_VENTA_MENSUAL = "SP_ERP_GET_MONTO_VENTA_MENSUAL";
        private string SP_ERP_GET_VENTA_SEMANAL = "SP_ERP_GET_VENTA_SEMANAL";
        private string SP_ERP_GET_VENTA_ULTIMOS_MESES = "SP_ERP_GET_VENTA_ULTIMOS_MESES";
        private string SP_ERP_GET_VENTA_SEMANA_HISTORICO = "SP_ERP_GET_VENTA_SEMANA_HISTORICO";
        private string SP_ERP_GET_MONTO_VENTA_DIARIA_ORGANIZACION = "SP_ERP_GET_MONTO_VENTA_DIARIA_ORGANIZACION";
        private string SP_ERP_GET_VENTA_SEMANAL_ORGANIZACION_BY_COMPANIAS = "SP_ERP_GET_VENTA_SEMANAL_ORGANIZACION_BY_COMPANIAS";
        private string SP_ERP_GET_VENTA_SEMANAL_DIARIA = "SP_ERP_GET_VENTA_SEMANAL_DIARIA";
        private string SP_ERP_GET_MONTO_VENTA_SEMANA_ACTUAL_BY_PROMOTOR = "SP_ERP_GET_MONTO_VENTA_SEMANA_ACTUAL_BY_PROMOTOR";

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

                    Conexion.SaveChanges();

                    return venta.ID_VENTA;
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

        public DataSet GetVentaHoy(int idUsuario)
        {
            try
            {
                DataSet datos = null;

                ERP_SQL conexion = new ERP_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("idUsuario", idUsuario);

                datos = conexion.EjecutarStoredProcedure(SP_ERP_GET_MONTO_VENTA_DIARIA, parametros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataSet GetVentaHoyOrganizacion(int idOrganizacion)
        {
            try
            {
                DataSet datos = null;

                ERP_SQL conexion = new ERP_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("idOrganizacion", idOrganizacion);

                datos = conexion.EjecutarStoredProcedure(SP_ERP_GET_MONTO_VENTA_DIARIA_ORGANIZACION, parametros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataSet GetVentaOrganizacionXSemanaXCompania(int idOrganizacion, int idSemana)
        {
            try
            {
                DataSet datos = null;

                ERP_SQL conexion = new ERP_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("idOrganizacion", idOrganizacion);
                parametros.Add("idSemana", idSemana);

                datos = conexion.EjecutarStoredProcedure(SP_ERP_GET_VENTA_SEMANAL_ORGANIZACION_BY_COMPANIAS, parametros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        public DataSet GetVentaMesActual(int idUsuario)
        {
            try
            {
                DataSet datos = null;

                ERP_SQL conexion = new ERP_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("idUsuario", idUsuario);

                datos = conexion.EjecutarStoredProcedure(SP_ERP_GET_MONTO_VENTA_MENSUAL, parametros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataSet GetVentaSemanaActual(int idUsuario)
        {
            try
            {
                DataSet datos = null;

                ERP_SQL conexion = new ERP_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("idUsuario", idUsuario);

                datos = conexion.EjecutarStoredProcedure(SP_ERP_GET_VENTA_SEMANAL, parametros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataSet GetVentaUltimosMeses(int idUsuario)
        {
            try
            {
                DataSet datos = null;

                ERP_SQL conexion = new ERP_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("idUsuario", idUsuario);

                datos = conexion.EjecutarStoredProcedure(SP_ERP_GET_VENTA_ULTIMOS_MESES, parametros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataSet GetVentaPorSemana(int idUsuario, int idSemana)
        {
            try
            {
                DataSet datos = null;

                ERP_SQL conexion = new ERP_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("idUsuario", idUsuario);
                parametros.Add("idSemana", idSemana);

                datos = conexion.EjecutarStoredProcedure(SP_ERP_GET_VENTA_SEMANA_HISTORICO, parametros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataSet GetVentaSemanalDiaria(int idArticulo)
        {
            try
            {
                DataSet datos = null;

                ERP_SQL conexion = new ERP_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("idArticulo", idArticulo);

                datos = conexion.EjecutarStoredProcedure(SP_ERP_GET_VENTA_SEMANAL_DIARIA, parametros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataSet GetVentaSenamalDiariaByPromotor(int idUsuarioGerente)
        {
            try
            {
                DataSet datos = null;

                ERP_SQL conexion = new ERP_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("idUsuario", idUsuarioGerente);

                datos = conexion.EjecutarStoredProcedure(SP_ERP_GET_MONTO_VENTA_SEMANA_ACTUAL_BY_PROMOTOR, parametros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int InsertVentaPromotor(int idVenta, int idPromotor)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_VENTA_PROMOTOR tBL_VENTA_PROMOTOR = new TBL_VENTA_PROMOTOR();

                    tBL_VENTA_PROMOTOR.ID_USUARIO = idPromotor;
                    tBL_VENTA_PROMOTOR.ID_VENTA = idVenta;

                    Conexion.TBL_VENTA_PROMOTOR.Add(tBL_VENTA_PROMOTOR);

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
