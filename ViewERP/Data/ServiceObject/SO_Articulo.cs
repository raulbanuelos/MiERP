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
    public class SO_Articulo
    {
        public int Insert(DO_Articulo articulo)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_ARTICULO tblArticulo = new TBL_ARTICULO();

                    tblArticulo.CODIGO = articulo.Codigo;
                    tblArticulo.DESCRIPCION = articulo.Descripcion;
                    tblArticulo.DESCRIPCION_LARGA = articulo.NumeroDeSerie;
                    tblArticulo.FOTO = articulo.CodigoDeBarras;
                    tblArticulo.ID_CATEGORIA = articulo.ID_CATEGORIA;
                    tblArticulo.ID_COMPANIA = articulo.idCompania;
                    tblArticulo.STOCK_MAX = articulo.stockMax;
                    tblArticulo.STOCK_MIN = articulo.stockMin;
                    tblArticulo.ID_COMPANIA = articulo.idCompania;
                    tblArticulo.CONSUMIBLE = articulo.IsConsumible;

                    Conexion.TBL_ARTICULO.Add(tblArticulo);
                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Update(DO_Articulo articulo)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_ARTICULO obj = Conexion.TBL_ARTICULO.Where(x => x.CODIGO == articulo.Codigo).FirstOrDefault();
                    
                    obj.CODIGO = articulo.Codigo;
                    obj.DESCRIPCION = articulo.Descripcion;
                    obj.DESCRIPCION_LARGA = articulo.NumeroDeSerie;
                    obj.STOCK_MAX = articulo.stockMax;
                    obj.STOCK_MIN = articulo.stockMin;
                    obj.CONSUMIBLE = articulo.IsConsumible;

                    Conexion.Entry(obj).State = EntityState.Modified;

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Delete(int idArticulo)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_ARTICULO obj = Conexion.TBL_ARTICULO.Where(x => x.ID_ARTICULO == idArticulo).FirstOrDefault();

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
                    var list = (from v in Conexion.TBL_ARTICULO
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

        public IList GetAllByCategory(int idCategoria)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var list = (from v in Conexion.TBL_ARTICULO
                                where v.ID_CATEGORIA == idCategoria
                                select v).ToList();

                    return list;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DO_Articulo GetArticulo(int idArticulo)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_ARTICULO obj = Conexion.TBL_ARTICULO.Where(x => x.ID_ARTICULO == idArticulo).FirstOrDefault();

                    DO_Articulo articulo = new DO_Articulo();

                    articulo.idArticulo = obj.ID_ARTICULO;
                    articulo.ID_CATEGORIA = obj.ID_CATEGORIA;
                    articulo.idCompania = obj.ID_COMPANIA;
                    articulo.Codigo = obj.CODIGO;
                    articulo.Descripcion = obj.DESCRIPCION;
                    articulo.NumeroDeSerie = obj.DESCRIPCION_LARGA;
                    articulo.stockMax = Convert.ToInt32(obj.STOCK_MAX);
                    articulo.stockMin = Convert.ToInt32(obj.STOCK_MIN);
                    articulo.CodigoDeBarras = obj.FOTO;
                    articulo.IsConsumible = obj.CONSUMIBLE;

                    return articulo;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GetLastCode(int idCategoria)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    string codigo = (from c in Conexion.TBL_ARTICULO
                                     where c.ID_CATEGORIA == idCategoria
                                     orderby c.ID_ARTICULO descending
                                     select c.CODIGO).FirstOrDefault();

                    return codigo;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
