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
    public class SO_CategoriaArticulo
    {
        public int Insert(DO_CategoriaArticulo categoriaArticulo)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_CATEGORIA_ARTICULO tblCategoriaArticulo = new TBL_CATEGORIA_ARTICULO();

                    //tblCategoriaArticulo.ID_CATEGORIA_ARTICULO = categoriaArticulo.idCategoriaArticulo;
                    tblCategoriaArticulo.NOMBRE_CATEGORIA = categoriaArticulo.NombreCategoria;
                    tblCategoriaArticulo.ID_COMPANIA = categoriaArticulo.idCompania;
                    tblCategoriaArticulo.NUM_CATEGORIA = categoriaArticulo.numeroCategoria;

                    Conexion.TBL_CATEGORIA_ARTICULO.Add(tblCategoriaArticulo);
                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Update(DO_CategoriaArticulo categoriaArticulo)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_CATEGORIA_ARTICULO obj = Conexion.TBL_CATEGORIA_ARTICULO.Where(x => x.ID_CATEGORIA_ARTICULO == categoriaArticulo.idCategoriaArticulo).FirstOrDefault();

                    obj.ID_CATEGORIA_ARTICULO = categoriaArticulo.idCategoriaArticulo;
                    obj.NOMBRE_CATEGORIA = categoriaArticulo.NombreCategoria;
                    obj.NUM_CATEGORIA = categoriaArticulo.numeroCategoria;
                    
                    Conexion.Entry(obj).State = EntityState.Modified;

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Delete(int idCategoria)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_CATEGORIA_ARTICULO obj = Conexion.TBL_CATEGORIA_ARTICULO.Where(x => x.ID_CATEGORIA_ARTICULO == idCategoria).FirstOrDefault();

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
                    var list = (from v in Conexion.TBL_CATEGORIA_ARTICULO
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

        public DO_CategoriaArticulo GetCategoriaArticulo(int idCategoria)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_CATEGORIA_ARTICULO obj = Conexion.TBL_CATEGORIA_ARTICULO.Where(x => x.ID_CATEGORIA_ARTICULO == idCategoria).FirstOrDefault();

                    DO_CategoriaArticulo categoriaArticulo = new DO_CategoriaArticulo();

                    categoriaArticulo.idCategoriaArticulo = obj.ID_CATEGORIA_ARTICULO;
                    categoriaArticulo.NombreCategoria = obj.NOMBRE_CATEGORIA;
                    categoriaArticulo.idCompania = Convert.ToInt32(obj.ID_COMPANIA);
                    categoriaArticulo.numeroCategoria = obj.NUM_CATEGORIA;

                    return categoriaArticulo;

                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
