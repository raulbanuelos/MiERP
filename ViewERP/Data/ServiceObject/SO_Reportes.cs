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

                Dictionary<string, object> paramentros = new Dictionary<string, object>();

                paramentros.Add("fechaInicial", fechaInicial);
                paramentros.Add("fechaFinal", fechaFinal);
                paramentros.Add("noFactura", noFactura);
                paramentros.Add("usuario", usuario);
                paramentros.Add("idAlmacen", idAlmacen);
                paramentros.Add("idProveedor", idProveedor);
                paramentros.Add("idArticulo", idArticulo);
                
                datos = conexion.EjecutarStoredProcedure("SP_ERP_GetEntradas_Articulos", paramentros);

                return datos;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
