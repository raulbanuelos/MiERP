using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ServiceObject
{
    public class SO_Existencia
    {
        public int AddCantidad(DO_MovimientoAlmacen movimientoAlmacen)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_EXISTENCIA obj = Conexion.TBL_EXISTENCIA.Where(x => x.ID_ARTICULO == movimientoAlmacen.idArticulo && x.ID_ALMACEN == movimientoAlmacen.idAlmacen).FirstOrDefault();

                    
                    obj.CANTIDAD = obj.CANTIDAD + movimientoAlmacen.Cantidad;

                    Conexion.Entry(obj).State = EntityState.Modified;

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
