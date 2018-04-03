using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ServiceObject
{
    public class SO_Rol
    {
        public int Insert(DO_Rol rol)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_ROLE tblRol = new TBL_ROLE();

                    tblRol.ROL = rol.Rol;

                    Conexion.TBL_ROLE.Add(tblRol);

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Update(DO_Rol rol)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_ROLE obj = Conexion.TBL_ROLE.Where(x => x.ID_ROL == rol.idRol).FirstOrDefault();

                    obj.ROL = rol.Rol;

                    Conexion.Entry(obj).State = EntityState.Modified;

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Delete(int idRol)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_ROLE obj = Conexion.TBL_ROLE.Where(x => x.ID_ROL == idRol).FirstOrDefault();

                    Conexion.Entry(obj).State = EntityState.Deleted;

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public IList GetAll()
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var Lista = (from r in Conexion.TBL_ROLE
                                 select r).ToList();

                    return Lista;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DO_Rol GetRol(int idRol)
        {
            DO_Rol rol = new DO_Rol();
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_ROLE obj = Conexion.TBL_ROLE.Where(x => x.ID_ROL == idRol).FirstOrDefault();

                    rol.idRol = obj.ID_ROL;
                    rol.Rol = obj.ROL;

                    return rol;
                }
            }
            catch (Exception)
            {
                return rol;
            }
        }
    }
}
