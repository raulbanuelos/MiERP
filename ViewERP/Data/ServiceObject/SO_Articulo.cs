using Data.SQLServer;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Data.ServiceObject
{
    public class SO_Articulo
    {
        private string SP_ERP_DELETE_ARTICULO = "SP_ERP_DELETE_ARTICULO";
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
                    Conexion.SaveChanges();

                    return tblArticulo.ID_ARTICULO;
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
                DataSet datos = null;

                ERP_SQL conexion = new ERP_SQL();

                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("idArticulo", idArticulo);

                datos = conexion.EjecutarStoredProcedure(SP_ERP_DELETE_ARTICULO, parametros);

                return 1;
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
                                join d in Conexion.TBL_DETAILS_ARTICULO on v.ID_ARTICULO equals d.ID_ARTICULO
                                where v.ID_COMPANIA == idCompania
                                select new {
                                    v.CODIGO,
                                    v.DESCRIPCION,
                                    v.DESCRIPCION_LARGA,
                                    v.FOTO,
                                    v.ID_ARTICULO,
                                    v.ID_COMPANIA,
                                    v.ID_CATEGORIA,
                                    v.STOCK_MAX,
                                    v.STOCK_MIN,
                                    v.CONSUMIBLE,
                                    d.PRECIO_GERENTE,
                                    d.PRECIO_MASTER,
                                    d.PRECIO_PROMOTOR,
                                    d.PRECIO_UNIDAD
                                }).ToList();

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

        public IList GetArticulo(int idArticulo)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {

                    var list = (from a in Conexion.TBL_ARTICULO
                               join d in Conexion.TBL_DETAILS_ARTICULO on a.ID_ARTICULO equals d.ID_ARTICULO
                               where a.ID_ARTICULO == idArticulo
                               select new
                               {
                                   a.ID_ARTICULO,
                                   a.ID_CATEGORIA,
                                   a.ID_COMPANIA,
                                   a.CODIGO,
                                   a.DESCRIPCION,
                                   a.DESCRIPCION_LARGA,
                                   a.STOCK_MAX,
                                   a.STOCK_MIN, 
                                   a.FOTO,
                                   a.CONSUMIBLE,
                                   d.PRECIO_GERENTE,
                                   d.PRECIO_MASTER,
                                   d.PRECIO_PROMOTOR,
                                   d.PRECIO_UNIDAD
                               }).ToList();

                    return list;
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
