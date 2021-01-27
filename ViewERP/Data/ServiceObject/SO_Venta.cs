using Data.SQLServer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
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
        private string SP_ERP_GET_VENTA_SEMANAL_DIARIA_PROMOTOR = "SP_ERP_GET_VENTA_SEMANAL_DIARIA_PROMOTOR";
        private string SP_ERP_GET_VENTA_SEMANAL_PROMOTOR = "SP_ERP_GET_VENTA_SEMANAL_PROMOTOR";
        private string SP_ERP_GET_VENTA_ULTIMAS_5_SEMANAS_PROMOTOR = "SP_ERP_GET_VENTA_ULTIMAS_5_SEMANAS_PROMOTOR";
        private string SP_ERP_GET_GANANCIA_GERENTE_CURRENT_WEEK = "SP_ERP_GET_GANANCIA_GERENTE_CURRENT_WEEK";
        private string SP_ERP_GET_VENTAS_BY_USUARIO = "SP_ERP_GET_VENTAS_BY_USUARIO";
        private string SP_ERP_GET_VENTA = "SP_ERP_GET_VENTA";
        private string SP_ERP_GET_VENTA_SEMANAL_DIARIA_BY_WEEK = "SP_ERP_GET_VENTA_SEMANAL_DIARIA_BY_WEEK";

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

        public DataSet GetVentaSemanalDiaria(int idArticulo, int idSemana)
        {
            try
            {
                DataSet datos = null;

                ERP_SQL conexion = new ERP_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("idArticulo", idArticulo);
                parametros.Add("idSemana", idSemana);

                datos = conexion.EjecutarStoredProcedure(SP_ERP_GET_VENTA_SEMANAL_DIARIA_BY_WEEK, parametros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataSet GetVentaSemanalDiariaPromotor(int idArticulo, int idPromotor, int idSemana)
        {
            try
            {
                DataSet datos = null;

                ERP_SQL conexion = new ERP_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("idArticulo", idArticulo);
                parametros.Add("idPromotor", idPromotor);
                parametros.Add("idSemana", idSemana);

                datos = conexion.EjecutarStoredProcedure(SP_ERP_GET_VENTA_SEMANAL_DIARIA_PROMOTOR, parametros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataSet GetVentaSemanalPromotor(int idPromotor, int idSemana)
        {
            try
            {
                DataSet datos = null;

                ERP_SQL conexion = new ERP_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("idPromotor", idPromotor);
                parametros.Add("idSemana", idSemana);

                datos = conexion.EjecutarStoredProcedure(SP_ERP_GET_VENTA_SEMANAL_PROMOTOR, parametros);

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

        public int DeleteVentaPromotor(int idVenta)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_VENTA_PROMOTOR ventaPromotor = Conexion.TBL_VENTA_PROMOTOR.Where(x => x.ID_VENTA == idVenta).FirstOrDefault();

                    Conexion.Entry(ventaPromotor).State = EntityState.Deleted;

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int DeleteVentaDetails(int idVenta)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_DETAILS_VENTA tBL_DETAILS_VENTA = Conexion.TBL_DETAILS_VENTA.Where(x => x.ID_VENTA == idVenta).FirstOrDefault();

                    Conexion.Entry(tBL_DETAILS_VENTA).State = EntityState.Deleted;

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int DeleteVenta(int idVenta)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_VENTA tBL_VENTA = Conexion.TBL_VENTA.Where(x => x.ID_VENTA == idVenta).FirstOrDefault();

                    Conexion.Entry(tBL_VENTA).State = EntityState.Deleted;

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }


        public DataSet GetVentaPromotorLastFiveWeek(int idPromotor, int idSemana)
        {
            try
            {
                DataSet datos = null;

                ERP_SQL conexion = new ERP_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("idPromotor", idPromotor);
                parametros.Add("idSemana", idSemana);

                datos = conexion.EjecutarStoredProcedure(SP_ERP_GET_VENTA_ULTIMAS_5_SEMANAS_PROMOTOR, parametros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataSet GetGananciaGerenteCurrentWeek(int idUsuario)
        {
            try
            {
                DataSet datos = null;

                ERP_SQL conexion = new ERP_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("idUsuario", idUsuario);

                datos = conexion.EjecutarStoredProcedure(SP_ERP_GET_GANANCIA_GERENTE_CURRENT_WEEK, parametros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataSet GetAll(int idUsuario)
        {
            try
            {
                DataSet datos = null;

                ERP_SQL conexion = new ERP_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("idUsuario", idUsuario);

                datos = conexion.EjecutarStoredProcedure(SP_ERP_GET_VENTAS_BY_USUARIO, parametros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataSet Get(int idVenta)
        {
            try
            {
                DataSet datos = null;

                ERP_SQL conexion = new ERP_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("@idVenta", idVenta);

                datos = conexion.EjecutarStoredProcedure(SP_ERP_GET_VENTA, parametros);

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
