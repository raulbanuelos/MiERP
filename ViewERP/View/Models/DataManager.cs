using Data.ServiceObject;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Models
{
    public static class DataManager
    {
        public static DO_Persona GetLogin(string usuario, string contrasena)
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
                    persona.ID_ROL = (int)tipo.GetProperty("ID_ROL").GetValue(item, null);
                    persona.Usuario = (string)tipo.GetProperty("USUARIO").GetValue(item, null);

                }
            }

            return persona;
        }

        public static DO_Persona GetPersona(int idPersona)
        {
            SO_Usuario service = new SO_Usuario();
            DO_Persona persona = new DO_Persona();

            IList informacionBD = service.GetPersona(idPersona);

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    System.Type tipo = item.GetType();

                    persona.idUsuario = (int)tipo.GetProperty("ID_USUARIO").GetValue(item, null);
                    persona.ID_ROL = (int)tipo.GetProperty("ID_ROL").GetValue(item, null);
                    persona.idCompania = (int)tipo.GetProperty("ID_COMPANIA").GetValue(item, null);
                    persona.Nombre = (string)tipo.GetProperty("NOMBRE").GetValue(item, null);
                    persona.ApellidoPaterno = (string)tipo.GetProperty("APATERNO").GetValue(item, null);
                    persona.ApellidoMaterno = (string)tipo.GetProperty("AMATERNO").GetValue(item, null);
                    persona.Usuario = (string)tipo.GetProperty("USUARIO").GetValue(item, null);
                    
                }
            }

            persona.Roles = GetAllRolSelectListItem();

            return persona;
        }

        public static List<DO_Persona> GetAllPersona(int idCompania)
        {
            List<DO_Persona> lista = new List<DO_Persona>();

            SO_Usuario service = new SO_Usuario();

            IList informacionBD = service.GetAllUsuarios(idCompania);

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    System.Type tipo = item.GetType();

                    DO_Persona persona = new DO_Persona();

                    persona.idUsuario = (int)tipo.GetProperty("ID_USUARIO").GetValue(item, null);
                    persona.ID_ROL = (int)tipo.GetProperty("ID_ROL").GetValue(item, null);
                    persona.idCompania = (int)tipo.GetProperty("ID_COMPANIA").GetValue(item, null);
                    persona.Nombre = (string)tipo.GetProperty("NOMBRE").GetValue(item, null);
                    persona.ApellidoPaterno = (string)tipo.GetProperty("APATERNO").GetValue(item, null);
                    persona.ApellidoMaterno = (string)tipo.GetProperty("AMATERNO").GetValue(item, null);
                    persona.Usuario = (string)tipo.GetProperty("USUARIO").GetValue(item, null);
                    persona.Rol = (string)tipo.GetProperty("ROL").GetValue(item, null);
                    lista.Add(persona);
                }
            }

            return lista;
        }

        public static int InsertPersona(DO_Persona persona)
        {
            SO_Usuario service = new SO_Usuario();

            return service.Insert(persona.ID_ROL, persona.idCompania, persona.Nombre, persona.ApellidoPaterno, persona.ApellidoMaterno, persona.Usuario, persona.Contrasena);
        }

        public static int UpdatePersona(DO_Persona persona)
        {
            SO_Usuario service = new SO_Usuario();

            return service.Update(persona.ID_ROL, persona.idCompania, persona.Nombre, persona.ApellidoPaterno, persona.ApellidoMaterno, persona.Usuario, persona.idUsuario);
        }

        public static int DeletePersona(int idPersona)
        {
            SO_Usuario service = new SO_Usuario();

            return service.Delete(idPersona);
        }
        
        public static string GetNewNumberNomina()
        {
            string numeroNomina = string.Empty;

            SO_Usuario service = new SO_Usuario();

            string lastPerson = service.GetLastPersonAdded(DateTime.Now.Year);

            if (!string.IsNullOrEmpty(lastPerson))
            {
                int h = Convert.ToInt32(lastPerson.Substring(6));
                h += 1;

                string g = h.ToString();

                if (g.Length == 1)
                {
                    g = "000" + g;
                }
                else if(g.Length == 2)
                {
                    g = "00" + g;
                }
                else if(g.Length == 3)
                {
                    g = "0" + g;
                }

                numeroNomina = "ML" + DateTime.Now.Year + g;

            }
            else
            {
                numeroNomina = "ML" + DateTime.Now.Year + "0001";
            }
            
            return service.ExistNameUser(numeroNomina) ? string.Empty : numeroNomina;
        }

        public static List<DO_Almacen> GetAllAlmacen(int idCompania)
        {
            List<DO_Almacen> lista = new List<DO_Almacen>();

            SO_Almacen service = new SO_Almacen();
            
            IList informacionBD = service.GetAll(idCompania);

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

        public static int InsertAlmacen(DO_Almacen almacen)
        {
            SO_Almacen service = new SO_Almacen();

            return service.Insert(almacen);
        }

        public static DO_Almacen GetAlmacen(int idAlmacen)
        {
            SO_Almacen service = new SO_Almacen();

            return service.GetCategoriaArticulo(idAlmacen);
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
                    articulo.ID_CATEGORIA = (int)tipo.GetProperty("ID_CATEGORIA").GetValue(item, null);
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

        public static int InsertArticulo(DO_Articulo articulo)
        {
            SO_Articulo service = new SO_Articulo();

            return service.Insert(articulo);
        }

        public static List<SelectListItem> GetAllCategoriaArticuloSelectListItem(int idCompania)
        {
            List<DO_CategoriaArticulo> lista = new List<DO_CategoriaArticulo>();

            SO_CategoriaArticulo service = new SO_CategoriaArticulo();

            IList informacionBD = service.GetAll(idCompania);

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
            
           return ConvertListDOCategoriaToSelectListItem(lista);
        }

        public static List<DO_CategoriaArticulo> GetAllCategoriaArticulo(int idCompania)
        {
            List<DO_CategoriaArticulo> lista = new List<DO_CategoriaArticulo>();

            SO_CategoriaArticulo service = new SO_CategoriaArticulo();

            IList informacionBD = service.GetAll(idCompania);

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

        public static List<SelectListItem> ConvertListDOCategoriaToSelectListItem(List<DO_CategoriaArticulo> lista)
        {
            List<SelectListItem> listaResultante = new List<SelectListItem>();

            foreach (var item in lista)
            {
                SelectListItem obj = new SelectListItem();
                obj.Text = item.NombreCategoria;
                obj.Value = Convert.ToString(item.idCategoriaArticulo);
                listaResultante.Add(obj);
            }

            return listaResultante;
        }

        public static DO_CategoriaArticulo GetCategoriaArticulo(int idCategoriaArticulo)
        {
            SO_CategoriaArticulo service = new SO_CategoriaArticulo();

            return service.GetCategoriaArticulo(idCategoriaArticulo);
        }

        public static int UpdateCategoriaArticulo(DO_CategoriaArticulo categoriaArticulo)
        {
            SO_CategoriaArticulo service = new SO_CategoriaArticulo();

            return service.Update(categoriaArticulo);
        }

        public static int InsertCategoriaArticulo(DO_CategoriaArticulo categoriaArticulo)
        {
            SO_CategoriaArticulo service = new SO_CategoriaArticulo();

            return service.Insert(categoriaArticulo);
        }

        public static int DeleteCategoriaArticulo(int idCategoriaArticulo)
        {
            SO_CategoriaArticulo service = new SO_CategoriaArticulo();

            return service.Delete(idCategoriaArticulo);
        }

        public static List<DO_Proveedor> GetAllProveedor(int idCompania)
        {
            List<DO_Proveedor> lista = new List<DO_Proveedor>();

            SO_Proveedor service = new SO_Proveedor();
            
            IList informacionBD = service.GetAll(idCompania);

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

        public static List<SelectListItem> GetAllRolSelectListItem()
        {
            List<DO_Rol> lista = new List<DO_Rol>();

            SO_Rol service = new SO_Rol();

            IList informacionBD = service.GetAll();

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    System.Type tipo = item.GetType();

                    DO_Rol rol = new DO_Rol();

                    rol.idRol = (int)tipo.GetProperty("ID_ROL").GetValue(item, null);
                    rol.Rol = (string)tipo.GetProperty("ROL").GetValue(item, null);

                    lista.Add(rol);
                }
            }

            return ConvertListDORolToSelectListItem(lista);
        }

        public static List<SelectListItem> ConvertListDORolToSelectListItem(List<DO_Rol> lista)
        {
            List<SelectListItem> listaResultante = new List<SelectListItem>();

            foreach (var item in lista)
            {
                SelectListItem obj = new SelectListItem();
                obj.Text = item.Rol;
                obj.Value = Convert.ToString(item.idRol);
                listaResultante.Add(obj);
            }

            return listaResultante;
        }

        public static DO_Rol GetRol(int idRol)
        {
            SO_Rol service = new SO_Rol();

            return service.GetRol(idRol);
        }

        public static int InsertRol(DO_Rol rol)
        {
            SO_Rol service = new SO_Rol();

            return service.Insert(rol);
        }

        public static int UpdateRol(DO_Rol rol)
        {
            SO_Rol service = new SO_Rol();

            return service.Update(rol);
        }

        public static int DeleteRol(int idRol)
        {
            SO_Rol service = new SO_Rol();

            return service.Delete(idRol);
        }
        
        public static byte[] ImageToByteArray(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }
    }
}