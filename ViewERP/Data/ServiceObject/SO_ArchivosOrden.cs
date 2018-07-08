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
    public class SO_ArchivosOrden
    {

        public int AltaArchivosOrden(DO_ArchivosOrden archivosorden)
        {
            try
            {
                using (var conexion = new EntitiesERP())
                {
                    ArchivosOrden obj = new ArchivosOrden();
                    obj.Id_ArchivosOrden = archivosorden.Id_ArchivoOrden;
                    obj.Archivo = archivosorden.Archivo;
                    obj.Nombre = archivosorden.Nombre;
                    obj.Extension = archivosorden.Extension;
                    obj.Id_Orden = archivosorden.Id_Orden;

                    conexion.ArchivosOrden.Add(obj);
                    return conexion.SaveChanges();
                }
            }
            catch (Exception)
            {

                return 0;
            }

        }
        public int BorrarArchivosOrden(int Id_ArchivoOrden)
        {
            try
            {
                using (var conexion = new EntitiesERP())
                {
                    ArchivosOrden obj = conexion.ArchivosOrden.Where(x => x.Id_ArchivosOrden == Id_ArchivoOrden).FirstOrDefault();

                    conexion.Entry(obj).State = EntityState.Deleted;
                    return conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }

        }
        public int ActualizarArchivosOrden(DO_ArchivosOrden archivosorden)
        {
            try
            {

                using (var conexion = new EntitiesERP())
                {
                    ArchivosOrden obj = conexion.ArchivosOrden.Where(x => x.Id_ArchivosOrden == archivosorden.Id_ArchivoOrden).FirstOrDefault();

                    obj.Id_ArchivosOrden = archivosorden.Id_ArchivoOrden;
                    obj.Archivo = archivosorden.Archivo;
                    obj.Nombre = archivosorden.Nombre;
                    obj.Extension = archivosorden.Extension;
                    obj.Id_Orden = archivosorden.Id_Orden;
                    
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
                    var Lista = (from tabla in conexion.ArchivosOrden select tabla).ToList();

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
