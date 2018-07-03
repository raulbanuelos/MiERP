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
    class SO_Productos
    {
        public int Productos(DO_Productos productos)
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
                    obj.Foto = productos.Foto;

                    conexion.Productos.Add(obj);
                    return conexion.SaveChanges();
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
                    obj.Foto = producto.Foto;



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
    }
}

   