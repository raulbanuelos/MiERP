using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ServiceObject
{
    public class SO_Organizacion
    {
        public int Insert(int idCompania, string nombre)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_ORGANIZACION tBL_ORGANIZACION = new TBL_ORGANIZACION();

                    tBL_ORGANIZACION.ID_COMPANIA_ADMIN = idCompania;
                    tBL_ORGANIZACION.NOMBRE_ORGANIZACION = nombre;
                    tBL_ORGANIZACION.FECHA_REGISTRO = DateTime.Now;

                    Conexion.TBL_ORGANIZACION.Add(tBL_ORGANIZACION);

                    Conexion.SaveChanges();

                    return tBL_ORGANIZACION.ID_ORGANIZACION;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Update(int idOrganizacion, string nombre)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_ORGANIZACION tBL_ORGANIZACION = Conexion.TBL_ORGANIZACION.Where(x => x.ID_ORGANIZACION == idOrganizacion).FirstOrDefault();

                    tBL_ORGANIZACION.NOMBRE_ORGANIZACION = nombre;

                    Conexion.Entry(tBL_ORGANIZACION).State = EntityState.Modified;

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public IList GetByCompania(int idCompania)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var list = (from a in Conexion.TBL_ORGANIZACION
                                where a.ID_COMPANIA_ADMIN == idCompania
                                select a).ToList();

                    return list;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IList Get(int idOrganizacion)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var list = (from a in Conexion.TBL_ORGANIZACION
                                where a.ID_ORGANIZACION == idOrganizacion
                                select a).ToList();

                    return list;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
