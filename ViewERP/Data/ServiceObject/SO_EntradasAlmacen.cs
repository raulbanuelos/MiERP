using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ServiceObject
{
    public class SO_EntradasAlmacen
    {
        public int InsertEntrada(int idAlmacen, int idProveedor,string noFactura,DateTime fecha,string usuario)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_MOVIMIENTO_ALMACEN obj = new TBL_MOVIMIENTO_ALMACEN();

                    obj.ID_ALMACEN = idAlmacen;
                    obj.ID_PROVEEDOR = idProveedor;
                    obj.NO_FACTURA = noFactura;
                    obj.FECHA = fecha;
                    obj.USUARIO = usuario;

                    Conexion.TBL_MOVIMIENTO_ALMACEN.Add(obj);

                    int r = Conexion.SaveChanges();

                    return r > 0 ? obj.ID_MOVIMIENTO_ALMACEN : 0;
                }
            }
            catch (Exception er)
            {
                return 0;
            }
        }
        
    }
}
