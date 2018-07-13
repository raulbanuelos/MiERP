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
    public class SO_Productos
    {
        public int AltaProductos(DO_Productos productos)
        {
            try
            {
                using (var conexion = new EntitiesERP())
                {
                    Productos obj = new Productos();
                    obj.Id_Productos = productos.Id_Productos;
                    obj.Id_Categoria = productos.Id_Categoria;
                    obj.Codigo = productos.Codigo;
                    obj.Descripcion = productos.Descripcion;
                    obj.foto = productos.foto;

                    conexion.Productos.Add(obj);
                    conexion.SaveChanges();

                    return obj.Id_Productos;
                }
            }
            catch (Exception)
            {

                return 0;
            }

        }
        public int BorrarProducto(int Id_Producto)
        {
            try
            {
                using (var conexion = new EntitiesERP())
                {
                    Productos obj = conexion.Productos.Where(x => x.Id_Productos == Id_Producto).FirstOrDefault();

                    conexion.Entry(obj).State = EntityState.Deleted;
                    return conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }

        }
        public int ActualizarProducto(DO_Productos producto)
        {
            try
            {

                using (var conexion = new EntitiesERP())
                {
                    Productos obj = conexion.Productos.Where(x => x.Id_Productos == producto.Id_Productos).FirstOrDefault();

                    obj.Id_Productos = producto.Id_Productos;
                    obj.Id_Categoria = producto.Id_Categoria;
                    obj.Codigo = producto.Codigo;
                    obj.Descripcion = producto.Descripcion;
                    obj.foto = producto.foto;



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
                    var Lista = (from tabla in conexion.Productos select tabla).ToList();

                    return Lista;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public IList GetProducto(int idProducto)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var Lista = (from a in Conexion.Productos
                                 where a.Id_Productos == idProducto
                                 select a).ToList();

                    return Lista;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public  int GetIdProducto(string descripcion)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    Productos producto = Conexion.Productos.Where(x => x.Descripcion == descripcion).FirstOrDefault();

                    return producto.Id_Productos;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public string GetLastCode()
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    string codigo = (from a in Conexion.Productos
                                     orderby a.Id_Productos descending
                                     select a.Codigo).FirstOrDefault();

                    return codigo;
                }
            }
            catch (Exception)
            {
                return "ERROR";
            }
        }
    }
}

   