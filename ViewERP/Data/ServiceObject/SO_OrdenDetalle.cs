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
                    OrdenesDetalle obj = conexion.OrdenesDetalle.Where(x => x.Id_OrdenDetalle == ordenesdetalle.Id_OrdenDetalle).FirstOrDefault();
                    
                    obj.Id_EstatusOrden = ordenesdetalle.Id_EstatusOrden;
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

        public IList GetAllByIdOrden(int idOrden)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var Lista = (from a in Conexion.OrdenesDetalle
                                 where a.Id_Orden == idOrden
                                 select a).ToList();

                    return Lista;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IList GetDetallesOrdenes()
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var Lista = (from d in Conexion.OrdenesDetalle
                                 join o in Conexion.Ordenes on d.Id_Orden equals o.Id_Orden
                                 join p in Conexion.Productos on d.Id_Producto equals p.Id_Productos
                                 join e in Conexion.EstatusOrden on d.Id_EstatusOrden equals e.Id_EstatusOrden
                                 orderby o.FechaSolicitud descending
                                 select new
                                 {
                                     ID_DETALLE_ORDEN = d.Id_OrdenDetalle,
                                     PROYECTO = o.Proyecto,
                                     EQUIPO_REQUERIDO = p.Descripcion,
                                     ENVIAR_A = d.EntregarA,
                                     CANTIDAD_TOTAL = d.Cantidad,
                                     ENTREGA_PARCIAL = d.EntregaParcial,
                                     REQUISICION = o.Requisicion,
                                     FECHA_PEDIDO = o.FechaSolicitud,
                                     FECHA_ENTREGA = o.FechaEntrega.ToString(),
                                     ORDEN = o.Folio,
                                     ID_ESTATUS = e.Id_EstatusOrden,
                                     ESTATUS = e.EstatusOrden1
                                 }).ToList();

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