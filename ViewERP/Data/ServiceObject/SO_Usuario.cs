using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ServiceObject
{
    public class SO_Usuario
    {
        public IList GetAllUsuarios(int idCompania)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var list = (from c in Conexion.TBL_USUARIO
                                where c.ID_COMPANIA == idCompania
                                select c).ToList();

                    return list;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IList GetLogin(string usuario, string contrasena)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var lista = (from u in Conexion.TBL_USUARIO
                                 where u.USUARIO == usuario && u.CONTRASENA == contrasena
                                 select u).ToList();
                    return lista;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int Insert(int idRol, int idCompania, string nombre, string aPaterno, string aMaterno,string usuario, string contrasena)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_USUARIO tblUsuario = new TBL_USUARIO();

                    tblUsuario.ID_ROL = idRol;
                    tblUsuario.ID_COMPANIA = idCompania;
                    tblUsuario.NOMBRE = nombre;
                    tblUsuario.APATERNO = aPaterno;
                    tblUsuario.AMATERNO = aMaterno;
                    tblUsuario.USUARIO = usuario;
                    tblUsuario.CONTRASENA = contrasena;

                    Conexion.TBL_USUARIO.Add(tblUsuario);

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Update(int idRol, int idCompania, string nombre, string aPaterno, string aMaterno, string usuario, string contrasena, int idUsuario)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_USUARIO obj = Conexion.TBL_USUARIO.Where(x => x.ID_USUARIO == idUsuario).ToList().FirstOrDefault();

                    obj.ID_ROL = idRol;
                    obj.ID_COMPANIA = idCompania;
                    obj.NOMBRE = nombre;
                    obj.APATERNO = aPaterno;
                    obj.AMATERNO = aMaterno;
                    obj.USUARIO = usuario;
                    obj.CONTRASENA = contrasena;

                    Conexion.Entry(obj).State = EntityState.Modified;

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Delete(int idUsuario)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_USUARIO obj = Conexion.TBL_USUARIO.Where(x => x.ID_USUARIO == idUsuario).ToList().FirstOrDefault();

                    Conexion.Entry(obj).State = EntityState.Deleted;

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
