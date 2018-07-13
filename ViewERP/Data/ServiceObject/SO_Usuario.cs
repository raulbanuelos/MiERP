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

        public IList GetPersona(int idPersona)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var list = (from c in Conexion.TBL_USUARIO
                                where c.ID_USUARIO == idPersona
                                select c).ToList();

                    return list;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IList GetPersona(string usuario)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var list = (from c in Conexion.TBL_USUARIO
                                where c.USUARIO == usuario
                                select c).ToList();

                    return list;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IList GetAllUsuarios(int idCompania)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var list = (from c in Conexion.TBL_USUARIO
                               join r in Conexion.TBL_ROLE on c.ID_ROL equals r.ID_ROL
                                where c.ID_COMPANIA == idCompania
                                select new {
                                    c.ID_USUARIO,
                                    c.ID_ROL,
                                    c.ID_COMPANIA,
                                    c.NOMBRE,
                                    c.APATERNO,
                                    c.AMATERNO,
                                    c.USUARIO,
                                    c.CONTRASENA,
                                    r.ROL
                                }).ToList();

                    return list;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GetLastPersonAdded(int anio)
        {
            
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var list = (from u in Conexion.TBL_USUARIO
                                where u.USUARIO.Contains("ML"+anio)
                                select new {
                                    u.USUARIO,
                                    u.ID_USUARIO
                                }).ToList().OrderByDescending(x =>x.ID_USUARIO).FirstOrDefault().USUARIO;

                    return list;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public bool ExistNameUser(string user)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    int c = (from u in Conexion.TBL_USUARIO
                             where u.USUARIO == user
                             select u).ToList().Count;

                    return c > 0 ? true : false;
                }
            }
            catch (Exception)
            {
                return false;
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
            catch (Exception er)
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

        public int Update(int idRol, int idCompania, string nombre, string aPaterno, string aMaterno, string usuario, int idUsuario)
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
