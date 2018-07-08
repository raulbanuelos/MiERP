using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;
using System.Collections;

namespace Data.ServiceObject
{
    public class SO_OrdenDetalle
    {
        public int AltaOrdenesDetalle(DO_OrdenesDetalle ordenesdetalle)
        {
            try
            {
                using (var conexion = new EntitiesERP())
                {
                    OrdenesDetalle obj = new OrdenesDetalle();
                    obj.Id_OrdenDetalle = ordenesdetalle.Id_OrdenDetalle;
                    obj.Id_Orden = ordenesdetalle.Id_Orden;
                    obj.Id_Producto = ordenesdetalle.Id_Producto;
                    obj.Id_EstatusOrden = ordenesdetalle.Id_EstatusOrden;
                    obj.Cantidad = ordenesdetalle.Cantidad;
                    obj.EntregaParcial = ordenesdetalle.EntregaParcial;
                    obj.EntregarA = ordenesdetalle.EntregarA;
                    obj.FechaActualizacionEstatus = ordenesdetalle.FechaActualizacionEstatus;

                    conexion.OrdenesDetalle.Add(obj);
                    return conexion.SaveChanges();
                }
            }
            catch (Exception)
            {

                return 0;
            }

        }
        public int BorrarOrdenesDetalle(int Id_OrdenDetalle)
        {
            try
            {
                using (var conexion = new EntitiesERP())
                {
                    OrdenesDetalle obj = conexion.OrdenesDetalle.Where(x => x.Id_OrdenDetalle == Id_OrdenDetalle).FirstOrDefault();

                    conexion.Entry(obj).State = EntityState.Deleted;
                    return conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }

        }
        public int ActualizarOrdenesDetalle(DO_OrdenesDetalle ordenesdetalle)
        {
            try
            {

                using (var conexion = new EntitiesERP())
                {
                    OrdenesDetalle obj = conexion.OrdenesDetalle.Where(x => x.Id_OrdenDetalle == ordenesdetalle.Id_Orden).FirstOrDefault();

                    obj.Id_OrdenDetalle = ordenesdetalle.Id_OrdenDetalle;
                    obj.Id_Orden = ordenesdetalle.Id_Orden;
                    obj.Id_Producto = ordenesdetalle.Id_Producto;
                    obj.Id_EstatusOrden = ordenesdetalle.Id_EstatusOrden;
                    obj.Cantidad = ordenesdetalle.Cantidad;
                    obj.EntregaParcial = ordenesdetalle.EntregaParcial;
                    obj.EntregarA = ordenesdetalle.EntregarA;
                    obj.FechaActualizacionEstatus = DateTime.Now;

                    conexion.Entry(obj).State = EntityState.Modified;
                    return conexion.SaveChanges();
                }
            }
            catch (Exception)
            {

                return 0;
            }

        }
        public IList ObtenerTodos()
        {
            try
            {
                using (var conexion = new EntitiesERP())
                {
                    var Lista = (from tabla in conexion.OrdenesDetalle select tabla).ToList();

                    return Lista;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

    }
}