using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Data.ServiceObject;
using System.Collections;
using Model;

namespace ViewERP.Models
{
    public static class DataManager
    {
        public static DO_Persona GetLogin(string usuario,string contrasena)
        {
            DO_Persona persona = null;

            SO_Usuario login = new SO_Usuario();

            IList informacionBD = login.GetLogin(usuario, contrasena);

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    Type tipo = item.GetType();

                    persona = new DO_Persona();

                    persona.ApellidoPaterno = (string)tipo.GetProperty("APATERNO").GetValue(item, null);
                    persona.ApellidoMaterno = (string)tipo.GetProperty("AMATERNO").GetValue(item, null);
                    persona.Nombre = (string)tipo.GetProperty("NOMBRE").GetValue(item, null);
                    persona.idUsuario = (int)tipo.GetProperty("ID_USUARIO").GetValue(item, null);
                    persona.idCompania = (int)tipo.GetProperty("ID_COMPANIA").GetValue(item, null);
                    persona.idRol = (int)tipo.GetProperty("ID_ROL").GetValue(item, null);
                    persona.Usuario = (string)tipo.GetProperty("USUARIO").GetValue(item, null);

                }
            }

            return persona;
        }

        public static int InsertProveedor(DO_Proveedor proveedor)
        {
            SO_Proveedor service = new SO_Proveedor();

            return service.Insert(proveedor);
        }

        public static int UpdateProveedor(DO_Proveedor proveedor)
        {
            SO_Proveedor service = new SO_Proveedor();

            return service.Update(proveedor);
        }

        public static int DeleteProveedor(int idProveedor)
        {
            SO_Proveedor service = new SO_Proveedor();

            return service.Delete(idProveedor);
        }

        public static List<DO_Proveedor> GetAllProveedor()
        {
            List<DO_Proveedor> lista = new List<DO_Proveedor>();

            SO_Proveedor service = new SO_Proveedor();

            //HardCode
            IList informacionBD = service.GetAll(1);

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    System.Type tipo = item.GetType();

                    DO_Proveedor proveedor = new DO_Proveedor();

                    proveedor.idProveedor = (int)tipo.GetProperty("ID_PROVEEDOR").GetValue(item, null);
                    proveedor.Correo = (string)tipo.GetProperty("CORREO").GetValue(item, null);
                    proveedor.Direccion = (string)tipo.GetProperty("DIRECCION").GetValue(item, null);
                    proveedor.Nombre = (string)tipo.GetProperty("NOMBRE").GetValue(item, null);
                    proveedor.RFC = (string)tipo.GetProperty("RFC").GetValue(item, null);
                    proveedor.Telefono1 = (string)tipo.GetProperty("TELEFONO1").GetValue(item, null);
                    proveedor.Telefono2 = (string)tipo.GetProperty("TELEFONO2").GetValue(item, null);
                    lista.Add(proveedor);

                }
            }
            
            return lista;
        }

        public static DO_Proveedor GetProveedor(int idProveedor)
        {
            DO_Proveedor proveedor = new DO_Proveedor();

            SO_Proveedor service = new SO_Proveedor();

            proveedor = service.GetProveedor(idProveedor);

            return proveedor;
        }

        public static int InsertCategoriaArticulo(DO_CategoriaArticulo categoriaArticulo)
        {
            SO_CategoriaArticulo service = new SO_CategoriaArticulo();

            return service.Insert(categoriaArticulo);
        }

        public static int UpdateCategoriaArticulo(DO_CategoriaArticulo categoriaArticulo)
        {
            SO_CategoriaArticulo service = new SO_CategoriaArticulo();

            return service.Update(categoriaArticulo);
        }

        public static int DeleteCategoriaArticulo(int idCategoriaArticulo)
        {
            SO_CategoriaArticulo service = new SO_CategoriaArticulo();

            return service.Delete(idCategoriaArticulo);
        }

        public static List<DO_CategoriaArticulo> GetAllCategoriaArticulo()
        {
            List<DO_CategoriaArticulo> lista = new List<DO_CategoriaArticulo>();

            SO_CategoriaArticulo service = new SO_CategoriaArticulo();

            IList informacionBD = service.GetAll();

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    System.Type tipo = item.GetType();

                    DO_CategoriaArticulo categoriaArticulo = new DO_CategoriaArticulo();

                    categoriaArticulo.idCategoriaArticulo = (int)tipo.GetProperty("ID_CATEGORIA_ARTICULO").GetValue(item, null);
                    categoriaArticulo.NombreCategoria = (string)tipo.GetProperty("NOMBRE_CATEGORIA").GetValue(item, null);
                    
                    lista.Add(categoriaArticulo);

                }
            }

            return lista;
        }

        public static DO_CategoriaArticulo GetCategoriaArticulo(int idCategoriaArticulo)
        {
            SO_CategoriaArticulo service = new SO_CategoriaArticulo();

            return service.GetCategoriaArticulo(idCategoriaArticulo);
        }

        public static int InsertAlmacen(DO_Almacen almacen)
        {
            SO_Almacen service = new SO_Almacen();

            return service.Insert(almacen);
        }

        public static int UpdateAlamcen(DO_Almacen almacen)
        {
            SO_Almacen service = new SO_Almacen();

            return service.Update(almacen);
        }

        public static int DeleteAlmacen(int idAlmacen)
        {
            SO_Almacen service = new SO_Almacen();

            return service.Delete(idAlmacen);
        }

        public static List<DO_Almacen> GetAllAlmacen()
        {
            List<DO_Almacen> lista = new List<DO_Almacen>();

            SO_Almacen service = new SO_Almacen();

            //HardCode
            IList informacionBD = service.GetAll(1);

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    DO_Almacen almacen = new DO_Almacen();

                    System.Type tipo = item.GetType();

                    almacen.idAlmacen = (int)tipo.GetProperty("ID_ALMACEN").GetValue(item, null);
                    almacen.idCompania = (int)tipo.GetProperty("ID_COMPANIA").GetValue(item, null);
                    almacen.Nombre = (string)tipo.GetProperty("NOMBRE").GetValue(item, null);
                    almacen.Descripcion = (string)tipo.GetProperty("DESCRIPCION").GetValue(item, null);
                    
                    lista.Add(almacen);
                }
            }

            return lista;
        }

        public static DO_Almacen GetAlmacen(int idAlmacen)
        {
            SO_Almacen service = new SO_Almacen();

            return service.GetCategoriaArticulo(idAlmacen);
        }

        public static int InsertArticulo(DO_Articulo articulo)
        {
            SO_Articulo service = new SO_Articulo();

            return service.Insert(articulo);
        }

        public static int UpdateArticulo(DO_Articulo articulo)
        {
            SO_Articulo service = new SO_Articulo();

            return service.Update(articulo);
        }

        public static int DeleteArticulo(int idArticulo)
        {
            SO_Articulo service = new SO_Articulo();

            return service.Delete(idArticulo);
        }

        public static List<DO_Articulo> GetAllArticulos(int idCompania)
        {
            SO_Articulo service = new SO_Articulo();

            IList informacionBD = service.GetAll(idCompania);

            List<DO_Articulo> lista = new List<DO_Articulo>();

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    System.Type tipo = item.GetType();

                    DO_Articulo articulo = new DO_Articulo();
                    articulo.Codigo = (string)tipo.GetProperty("CODIGO").GetValue(item, null);
                    articulo.Descripcion = (string)tipo.GetProperty("DESCRIPCION").GetValue(item, null);
                    articulo.DescripcionLarga = (string)tipo.GetProperty("DESCRIPCION_LARGA").GetValue(item, null);
                    articulo.foto = (byte[])tipo.GetProperty("FOTO").GetValue(item, null);
                    articulo.idArticulo = (int)tipo.GetProperty("ID_ARTICULO").GetValue(item, null);
                    articulo.idCompania = (int)tipo.GetProperty("ID_COMPANIA").GetValue(item, null);
                    articulo.idCategoria = (int)tipo.GetProperty("ID_CATEGORIA").GetValue(item, null);
                    articulo.stockMax = (int)tipo.GetProperty("STOCK_MAX").GetValue(item, null);
                    articulo.stockMin = (int)tipo.GetProperty("STOCK_MIN").GetValue(item, null);

                    lista.Add(articulo);
                }
            }

            return lista;
        }

        public static DO_Articulo GetArticulo(int idArticulo)
        {
            SO_Articulo service = new SO_Articulo();

            return service.GetArticulo(idArticulo);
        }
    }
}