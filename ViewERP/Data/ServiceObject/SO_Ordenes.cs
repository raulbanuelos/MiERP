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
    public class SO_Ordenes
    {
        public int AltaOrdenes(DO_Ordenes ordenes)
        {
            try
            {
                using (var conexion = new EntitiesERP())
                { 

                    Ordenes obj = new Ordenes();
                    obj.Id_Orden = ordenes.Id_Orden;
                    obj.Folio = ordenes.Folio;
                    obj.FechaSolicitud = ordenes.FechaSolicitud;
                    obj.FechaEntrega = ordenes.FechaEntrega;
                    obj.Id_Cliente = ordenes.Id_Cliente;
                    obj.Usuario = ordenes.Usuario;
                    obj.Requisicion = ordenes.Requisicion;
                    obj.Proyecto = ordenes.Proyecto;

                    conexion.Ordenes.Add(obj);

                    conexion.SaveChanges();

                    return obj.Id_Orden;
                }
            }
            catch (Exception)
            {

                return 0;
            }

        }
        public int BorrarOrdenes(int Id_Orden)
        {
            try
            {
                using (var conexion = new EntitiesERP())
                {
                    Ordenes obj = conexion.Ordenes.Where(x => x.Id_Orden == Id_Orden).FirstOrDefault();

                    conexion.Entry(obj).State = EntityState.Deleted;
                    return conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }

        }
        public int ActualizarOrdenes(DO_Ordenes ordenes)
        {
            try
            {

                using (var conexion = new EntitiesERP())
                {
                    Ordenes obj = conexion.Ordenes.Where(x => x.Id_Orden == ordenes.Id_Orden).FirstOrDefault();

                    obj.Id_Orden = ordenes.Id_Orden;
                    obj.Folio = ordenes.Folio;
                    obj.FechaSolicitud = ordenes.FechaSolicitud;
                    obj.FechaEntrega = ordenes.FechaEntrega;
                    obj.Id_Cliente = ordenes.Id_Cliente;
                    obj.Usuario = ordenes.Usuario;
                    obj.Requisicion = ordenes.Requisicion;
                    obj.Proyecto = ordenes.Proyecto;

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
                    var Lista = (from tabla in conexion.Ordenes select tabla).ToList();

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
