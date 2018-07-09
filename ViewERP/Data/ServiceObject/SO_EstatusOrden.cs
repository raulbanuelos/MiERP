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
    public class SO_EstatusOrden
    {
        public int EstatusOrden(DO_EstatusOrden estatusorden)
        {
            try
            {
                using (var conexion = new EntitiesERP())
                {
                    EstatusOrden obj = new EstatusOrden();
                    obj.Id_EstatusOrden = estatusorden.Id_EstatusOrden;
                    obj.EstatusOrden1 = estatusorden.EstatusOrden;


                    conexion.EstatusOrden.Add(obj);
                    return conexion.SaveChanges();
                }
            }
            catch (Exception)
            {

                return 0;
            }

        }
        public int BorrarEstatusOrden(int Id_EstatusOrden)
        {
            try
            {
                using (var conexion = new EntitiesERP())
                {
                    EstatusOrden obj = conexion.EstatusOrden.Where(x => x.Id_EstatusOrden == Id_EstatusOrden).FirstOrDefault();

                    conexion.Entry(obj).State = EntityState.Deleted;
                    return conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }

        }
        public int ActualizarEstatusOrden(DO_EstatusOrden estatusorden)
        {
            try
            {

                using (var conexion = new EntitiesERP())
                {
                    EstatusOrden obj = conexion.EstatusOrden.Where(x => x.Id_EstatusOrden == estatusorden.Id_EstatusOrden).FirstOrDefault();

                    obj.Id_EstatusOrden = estatusorden.Id_EstatusOrden;
                    obj.EstatusOrden1 = estatusorden.EstatusOrden;



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
                    var Lista = (from tabla in conexion.EstatusOrden select tabla).ToList();

                    return Lista;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public IList GetEstatusOrden(int idEstatusOrden)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var Lista = (from a in Conexion.EstatusOrden
                                 where a.Id_EstatusOrden == idEstatusOrden
                                 select a).ToList();

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
