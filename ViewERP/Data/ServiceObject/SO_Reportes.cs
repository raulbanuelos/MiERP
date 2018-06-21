using Data.SQLServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ServiceObject
{
    public class SO_Reportes
    {
        public DataSet GetEntradasArticulos(string fechaInicial,string fechaFinal,string noFactura,string usuario,int idAlmacen,int idProveedor,int idArticulo)
        {
            try
            {
                DataSet datos = null;

                ERP_SQL conexion = new ERP_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("fechaInicial", fechaInicial);
                parametros.Add("fechaFinal", fechaFinal);
                parametros.Add("noFactura", noFactura);
                parametros.Add("usuario", usuario);
                parametros.Add("idAlmacen", idAlmacen);
                parametros.Add("idProveedor", idProveedor);
                parametros.Add("idArticulo", idArticulo);
                
                datos = conexion.EjecutarStoredProcedure("SP_ERP_GetEntradas_Articulos", parametros);

                return datos;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataSet GetSalidasArticulos(string fechaInicial, string fechaFinal, string usuarioSolicito, string usuarioAtendio, string codigoArticulo, int idAlmacen)
        {
            try
            {
                DataSet datos = null;

                ERP_SQL conexion = new ERP_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();

                parametros.Add("fechaInicial", fechaInicial);
                parametros.Add("fechaFinal", fechaFinal);
                parametros.Add("usuarioSolicito", usuarioSolicito);
                parametros.Add("usuarioAtendio", usuarioAtendio);
                parametros.Add("codigoArticulo", codigoArticulo);
                parametros.Add("idAlmancen", idAlmacen);

                datos = conexion.EjecutarStoredProcedure("SP_ERP_GetSalidas_Articulos", parametros);

                return datos;
                
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
