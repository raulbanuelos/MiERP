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
    public class SO_Almacen
    {
        public int Insert(DO_Almacen almacen)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_ALMACEN tblAlmacen = new TBL_ALMACEN();

                    tblAlmacen.ID_ALMACEN = almacen.idAlmacen;
                    tblAlmacen.ID_COMPANIA = almacen.idCompania;
                    tblAlmacen.NOMBRE = almacen.Nombre;
                    tblAlmacen.DESCRIPCION = almacen.Descripcion;

                    Conexion.TBL_ALMACEN.Add(tblAlmacen);
                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Update(DO_Almacen almacen)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_ALMACEN obj = Conexion.TBL_ALMACEN.Where(x => x.ID_ALMACEN == almacen.idAlmacen).FirstOrDefault();

                    obj.NOMBRE = almacen.Nombre;
                    obj.DESCRIPCION = almacen.Descripcion;
                    obj.ID_COMPANIA = almacen.idCompania;

                    Conexion.Entry(obj).State = EntityState.Modified;

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Delete(int idAlmacen)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_ALMACEN obj = Conexion.TBL_ALMACEN.Where(x => x.ID_ALMACEN == idAlmacen).FirstOrDefault();

                    Conexion.Entry(obj).State = EntityState.Deleted;

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public IList GetAll(int idCompania)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var list = (from v in Conexion.TBL_ALMACEN
                                where v.ID_COMPANIA == idCompania
                                select v).ToList();

                    return list;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DO_Almacen GetCategoriaArticulo(int idAlmacen)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_ALMACEN obj = Conexion.TBL_ALMACEN.Where(x => x.ID_ALMACEN == idAlmacen).FirstOrDefault();

                    DO_Almacen almacen = new DO_Almacen();

                    almacen.idAlmacen = obj.ID_ALMACEN;
                    almacen.idCompania = obj.ID_COMPANIA;
                    almacen.Nombre = obj.NOMBRE;
                    almacen.Descripcion = obj.DESCRIPCION;
                    return almacen;

                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
