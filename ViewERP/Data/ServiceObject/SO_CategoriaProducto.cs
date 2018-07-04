using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;
using System.Collections;
namespace Data.ServiceObject
{
    class SO_CategoriaProducto
    {
        public int CategoriaProducto(DO_CategoriaProducto categoriaproducto)
        {
            try
            {
                using (var conexion = new EntitiesERP())
                {
                    CategoriaProducto obj = new CategoriaProducto();
                    obj.Id_CategoriaProducto = categoriaproducto.Id_CategoriaProducto;
                    obj.NombreCategoria = categoriaproducto.NombreCategoria;


                    conexion.CategoriaProducto.Add(obj);
                    return conexion.SaveChanges();
                }
            }
            catch (Exception)
            {

                return 0;
            }

        }
        public int BorrarCategoriaProducto(int Id_CategoriaProducto)
        {
            try
            {
                using (var conexion = new EntitiesERP())
                {
                    CategoriaProducto obj = conexion.CategoriaProducto.Where(x => x.Id_CategoriaProducto == Id_CategoriaProducto).FirstOrDefault();

                    conexion.Entry(obj).State = EntityState.Deleted;
                    return conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }

        }
        public int ActualizarCategoriaProducto(DO_CategoriaProducto categoriaproducto)
        {
            try
            {

                using (var conexion = new EntitiesERP())
                {
                    CategoriaProducto obj = conexion.CategoriaProducto.Where(x => x.Id_CategoriaProducto == categoriaproducto.Id_CategoriaProducto).FirstOrDefault();
                    obj.Id_CategoriaProducto = categoriaproducto.Id_CategoriaProducto;
                    obj.NombreCategoria = categoriaproducto.NombreCategoria;

                    conexion.Entry(obj).State = EntityState.Modified;
                    return conexion.SaveChanges();
                }
            }
            catch (Exception)
            {

                return 0;
            }

        }
        public IList ObtenerTodos()
        {
            try
            {
                using (var conexion = new EntitiesERP())
                {
                    var Lista = (from tabla in conexion.CategoriaProducto
                                 select tabla).ToList();

                    return Lista;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

    }
}
