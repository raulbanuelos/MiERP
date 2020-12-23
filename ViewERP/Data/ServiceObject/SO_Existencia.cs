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
    public class SO_Existencia
    {
        public int AddCantidad(int idAlmacen, int idArticulo,decimal cantidad)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_EXISTENCIA obj = Conexion.TBL_EXISTENCIA.Where(x => x.ID_ARTICULO == idArticulo && x.ID_ALMACEN == idAlmacen).FirstOrDefault();

                    if (obj != null)
                    {
                        obj.CANTIDAD = obj.CANTIDAD + cantidad;

                        Conexion.Entry(obj).State = EntityState.Modified;
                    }
                    else
                    {
                        TBL_EXISTENCIA objNuevo = new TBL_EXISTENCIA();

                        objNuevo.ID_ALMACEN = idAlmacen;
                        objNuevo.ID_ARTICULO = idArticulo;
                        objNuevo.CANTIDAD = Convert.ToDecimal(cantidad);

                        Conexion.TBL_EXISTENCIA.Add(objNuevo);
                    }
                    
                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int RemoveCantidad(int idAlmacen, int idArticulo, double cantidad)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_EXISTENCIA obj = Conexion.TBL_EXISTENCIA.Where(x => x.ID_ARTICULO == idArticulo && x.ID_ALMACEN == idAlmacen).FirstOrDefault();

                    obj.CANTIDAD = obj.CANTIDAD - Convert.ToDecimal(cantidad);

                    Conexion.Entry(obj).State = EntityState.Modified;
                    
                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public double GetExistenciaArticulo(int idAlmacen, int idArticulo)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    
                    decimal existencia = (from e in Conexion.TBL_EXISTENCIA
                                      where e.ID_ALMACEN == idAlmacen && e.ID_ARTICULO == idArticulo
                                      select e.CANTIDAD).FirstOrDefault();

                    return Convert.ToDouble(existencia);

                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public IList GetAllExistencia(int idAlmacen)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var lista = (from e in Conexion.TBL_EXISTENCIA
                                 join a in Conexion.TBL_ARTICULO on e.ID_ARTICULO equals a.ID_ARTICULO
                                 join p in Conexion.TBL_DETAILS_ARTICULO on a.ID_ARTICULO equals p.ID_ARTICULO
                                 where e.ID_ALMACEN == idAlmacen
                                 select new
                                 { 
                                     a.ID_ARTICULO,
                                     e.CANTIDAD,
                                     a.CODIGO,
                                     a.DESCRIPCION,
                                     NUMERO_SERIE = a.DESCRIPCION_LARGA,
                                     e.ID_EXISTENCIA,
                                     PRECIO_MASTER = p.PRECIO_MASTER
                                 }).ToList();

                    return lista;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
