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
    public class SO_Proveedor
    {
        public int Insert(DO_Proveedor proveedor)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_PROVEEDOR tblProveedor = new TBL_PROVEEDOR();

                    tblProveedor.CORREO = proveedor.Correo;
                    tblProveedor.DIRECCION = proveedor.Direccion;
                    tblProveedor.ID_COMPANIA = proveedor.idCompania;
                    tblProveedor.NOMBRE = proveedor.Nombre;
                    tblProveedor.RFC = proveedor.RFC;
                    tblProveedor.TELEFONO1 = proveedor.Telefono1;
                    tblProveedor.TELEFONO2 = proveedor.Telefono2;
                    

                    Conexion.TBL_PROVEEDOR.Add(tblProveedor);
                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Update(DO_Proveedor proveedor)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_PROVEEDOR obj = Conexion.TBL_PROVEEDOR.Where(x => x.ID_PROVEEDOR == proveedor.idProveedor).FirstOrDefault();

                    obj.CORREO = proveedor.Correo;
                    obj.DIRECCION = proveedor.Direccion;
                    obj.NOMBRE = proveedor.Nombre;
                    obj.RFC = proveedor.RFC;
                    obj.TELEFONO1 = proveedor.Telefono1;
                    obj.TELEFONO2 = proveedor.Telefono2;

                    Conexion.Entry(obj).State = EntityState.Modified;

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Delete(int idProveedor)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_PROVEEDOR obj = Conexion.TBL_PROVEEDOR.Where(x => x.ID_PROVEEDOR == idProveedor).FirstOrDefault();

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
                    var list = (from v in Conexion.TBL_PROVEEDOR
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

        public DO_Proveedor GetProveedor(int idProveedor)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_PROVEEDOR obj = Conexion.TBL_PROVEEDOR.Where(x => x.ID_PROVEEDOR == idProveedor).FirstOrDefault();

                    DO_Proveedor proveedor = new DO_Proveedor();

                    proveedor.idProveedor = obj.ID_PROVEEDOR;
                    proveedor.Correo = obj.CORREO;
                    proveedor.Direccion = obj.DIRECCION;
                    proveedor.idCompania = obj.ID_COMPANIA;
                    proveedor.Nombre = obj.NOMBRE;
                    proveedor.RFC = obj.RFC;
                    proveedor.Telefono1 = obj.TELEFONO1;
                    proveedor.Telefono2 = obj.TELEFONO2;

                    return proveedor;
                        
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
