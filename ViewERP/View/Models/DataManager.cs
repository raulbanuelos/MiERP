using Data.ServiceObject;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Models
{
    public static class DataManager
    {
        #region Persona
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

        public static DO_Persona GetPersona(string usuario)
        {
            SO_Usuario service = new SO_Usuario();
            DO_Persona persona = new DO_Persona();

            IList informacionBD = service.GetPersona(usuario);

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

        public static List<SelectListItem> ConvertListDOPersonaToSelectListItem(List<DO_Persona> lista)
        {
            List<SelectListItem> listaResultante = new List<SelectListItem>();

            foreach (var item in lista)
            {
                SelectListItem obj = new SelectListItem();

                obj.Text = item.ToString();
                obj.Value = Convert.ToString(item.idUsuario);

                listaResultante.Add(obj);
            }

            return listaResultante;
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
                else if (g.Length == 2)
                {
                    g = "00" + g;
                }
                else if (g.Length == 3)
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
        #endregion

        #region Almacen
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

        public static List<SelectListItem> ConvertListDOAlmacenToSelectListItem(List<DO_Almacen> lista)
        {
            List<SelectListItem> listaResultante = new List<SelectListItem>();

            foreach (var item in lista)
            {
                SelectListItem obj = new SelectListItem();

                obj.Text = item.Nombre;
                obj.Value = Convert.ToString(item.idAlmacen);

                listaResultante.Add(obj);
            }

            return listaResultante;
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
        #endregion

        #region Articulo
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
                    articulo.NumeroDeSerie = (string)tipo.GetProperty("DESCRIPCION_LARGA").GetValue(item, null);
                    articulo.CodigoDeBarras = (byte[])tipo.GetProperty("FOTO").GetValue(item, null);
                    articulo.idArticulo = (int)tipo.GetProperty("ID_ARTICULO").GetValue(item, null);
                    articulo.idCompania = (int)tipo.GetProperty("ID_COMPANIA").GetValue(item, null);
                    articulo.ID_CATEGORIA = (int)tipo.GetProperty("ID_CATEGORIA").GetValue(item, null);
                    articulo.stockMax = (int)tipo.GetProperty("STOCK_MAX").GetValue(item, null);
                    articulo.stockMin = (int)tipo.GetProperty("STOCK_MIN").GetValue(item, null);
                    articulo.IsConsumible = (bool)tipo.GetProperty("CONSUMIBLE").GetValue(item, null);

                    articulo.Categoria = GetCategoriaArticulo(articulo.ID_CATEGORIA);

                    lista.Add(articulo);
                }
            }

            return lista;
        }

        public static List<DO_Articulo> GetAllArticulos(List<int> categorias)
        {
            SO_Articulo service = new SO_Articulo();

            List<DO_Articulo> lista = new List<DO_Articulo>();

            if (categorias != null)
            {
                foreach (int idCategoria in categorias)
                {
                    IList informacionBD = service.GetAllByCategory(idCategoria);

                    if (informacionBD != null)
                    {
                        foreach (var item in informacionBD)
                        {
                            System.Type tipo = item.GetType();

                            DO_Articulo articulo = new DO_Articulo();
                            articulo.Codigo = (string)tipo.GetProperty("CODIGO").GetValue(item, null);
                            articulo.Descripcion = (string)tipo.GetProperty("DESCRIPCION").GetValue(item, null);
                            articulo.NumeroDeSerie = (string)tipo.GetProperty("DESCRIPCION_LARGA").GetValue(item, null);
                            articulo.CodigoDeBarras = (byte[])tipo.GetProperty("FOTO").GetValue(item, null);
                            articulo.idArticulo = (int)tipo.GetProperty("ID_ARTICULO").GetValue(item, null);
                            articulo.idCompania = (int)tipo.GetProperty("ID_COMPANIA").GetValue(item, null);
                            articulo.ID_CATEGORIA = (int)tipo.GetProperty("ID_CATEGORIA").GetValue(item, null);
                            articulo.stockMax = (int)tipo.GetProperty("STOCK_MAX").GetValue(item, null);
                            articulo.stockMin = (int)tipo.GetProperty("STOCK_MIN").GetValue(item, null);
                            articulo.IsConsumible = (bool)tipo.GetProperty("CONSUMIBLE").GetValue(item, null);

                            articulo.Categoria = GetCategoriaArticulo(articulo.ID_CATEGORIA);

                            lista.Add(articulo);
                        }
                    }
                }
            }

            
            

            return lista;
        }

        public static List<SelectListItem> ConvertListDOArticuloToSelectListItem(List<DO_Articulo> lista)
        {
            List<SelectListItem> listaResultante = new List<SelectListItem>();

            foreach (var item in lista)
            {
                SelectListItem obj = new SelectListItem();

                obj.Text = item.Codigo + "          " + item.Descripcion;
                obj.Value = Convert.ToString(item.idArticulo);
                listaResultante.Add(obj);
            }

            return listaResultante;
        }

        public static DO_Articulo GetArticulo(int idArticulo)
        {
            SO_Articulo service = new SO_Articulo();

            DO_Articulo articulo = new DO_Articulo();

            articulo = service.GetArticulo(idArticulo);

            articulo.Categoria = GetCategoriaArticulo(articulo.ID_CATEGORIA);

            return articulo;
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

        public static string GetNextCodigoArticulo(string idCategoria)
        {
            SO_Articulo service = new SO_Articulo();

            string ultimoCodigo = service.GetLastCode(Convert.ToInt32(idCategoria));
            string nuevoCodigo = string.Empty;

            DO_CategoriaArticulo categoria = new DO_CategoriaArticulo();

            SO_CategoriaArticulo serviceCategoria = new SO_CategoriaArticulo();

            categoria = serviceCategoria.GetCategoriaArticulo(Convert.ToInt32(idCategoria));

            if (string.IsNullOrEmpty(ultimoCodigo))
            {
                nuevoCodigo = categoria.numeroCategoria + "00001";
            }
            else
            {
                string d = ultimoCodigo.Substring(2);
                string numeroCategoria = categoria.numeroCategoria;

                int g = Convert.ToInt32(d);

                g += 1;

                if (g.ToString().Length == 1)
                {
                    nuevoCodigo = numeroCategoria + "0000" + g;
                }
                else if (g.ToString().Length == 2)
                {
                    nuevoCodigo = numeroCategoria + "000" + g;
                }
                else if (g.ToString().Length == 3)
                {
                    nuevoCodigo = numeroCategoria + "00" + g;
                }
                else if (g.ToString().Length == 4)
                {
                    nuevoCodigo = numeroCategoria + "0" + g;
                }
                else if (g.ToString().Length == 5)
                {
                    nuevoCodigo = numeroCategoria + g;
                }
            }

            return nuevoCodigo;
        }

        public static bool verifiExistencia(int idAlmacen, int idArticulo, double cantidadSolicitada)
        {
            double existencia = GetExistenciaArticulo(idAlmacen, idArticulo);

            return existencia >= cantidadSolicitada ? true : false;
        }

        public static double GetExistenciaArticulo(int idAlmacen, int idArticulo)
        {
            SO_Existencia service = new SO_Existencia();

            return service.GetExistenciaArticulo(idAlmacen, idArticulo);
        }

        public static List<DO_Existencia> GetExistenciaArticulos(int idAlmacen)
        {
            SO_Existencia service = new SO_Existencia();

            List<DO_Existencia> listaResultante = new List<DO_Existencia>();

            IList informacionBD = service.GetAllExistencia(idAlmacen);

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    Type tipo = item.GetType();

                    DO_Existencia existencia = new DO_Existencia();

                    existencia.Cantidad = Convert.ToDouble(tipo.GetProperty("CANTIDAD").GetValue(item, null));
                    existencia.CodigoArticulo = (string)tipo.GetProperty("CODIGO").GetValue(item,null);
                    existencia.Descripcion = (string)tipo.GetProperty("DESCRIPCION").GetValue(item, null);
                    existencia.idExistencia = (int)tipo.GetProperty("ID_EXISTENCIA").GetValue(item, null);
                    existencia.NumeroSerie = (string)tipo.GetProperty("NUMERO_SERIE").GetValue(item, null);

                    listaResultante.Add(existencia);
                }
            }

            return listaResultante;
        }
        #endregion

        #region Categoria Articulo
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
                    categoriaArticulo.numeroCategoria = (string)tipo.GetProperty("NUM_CATEGORIA").GetValue(item, null);

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
                    categoriaArticulo.numeroCategoria = (string)tipo.GetProperty("NUM_CATEGORIA").GetValue(item, null);
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

        public static List<DO_CategoriaArticulo> ConvertDOArticuloToCategoriaArticulo(List<DO_Articulo> ListaArticulos)
        {
            List<DO_CategoriaArticulo> ListaResultante = new List<DO_CategoriaArticulo>();

            foreach (DO_Articulo item in ListaArticulos)
            {
                if (ListaResultante.Where(x => x.idCategoriaArticulo == item.ID_CATEGORIA).ToList().Count == 0)
                {
                    DO_CategoriaArticulo categoria = new DO_CategoriaArticulo();

                    categoria.idCategoriaArticulo = item.Categoria.idCategoriaArticulo;
                    categoria.NombreCategoria = item.Categoria.NombreCategoria;
                    ListaResultante.Add(categoria);
                }
            }

            foreach (DO_CategoriaArticulo categoria in ListaResultante)
            {
                foreach (DO_Articulo articulo in ListaArticulos)
                {
                    if (categoria.idCategoriaArticulo == articulo.Categoria.idCategoriaArticulo)
                    {
                        categoria.Articulos.Add(articulo);
                    }
                }
            }

            return ListaResultante;
        }
        #endregion

        #region Proveedor
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

        public static List<SelectListItem> ConvertListDOProveedorToSelectListItem(List<DO_Proveedor> lista)
        {
            List<SelectListItem> listaResultante = new List<SelectListItem>();

            foreach (var item in lista)
            {
                SelectListItem obj = new SelectListItem();

                obj.Text = item.Nombre;
                obj.Value = Convert.ToString(item.idProveedor);

                listaResultante.Add(obj);
            }

            return listaResultante;
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
        #endregion

        #region Rol
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
        #endregion

        #region Undiad
        public static List<DO_Unidad> GetAllUnidad()
        {
            SO_Unidad service = new SO_Unidad();

            List<DO_Unidad> listaResultante = new List<DO_Unidad>();

            IList informacionBD = service.GetAllUnidades();

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    Type tipo = item.GetType();

                    DO_Unidad unidad = new DO_Unidad();

                    unidad.idUnidad = (int)tipo.GetProperty("ID_UNIDAD").GetValue(item, null);
                    unidad.NombreUnidad = (string)tipo.GetProperty("NOMBRE_UNIDAD").GetValue(item, null);

                    listaResultante.Add(unidad);
                }
            }

            return listaResultante;
        }

        public static List<SelectListItem> ConvertListDOUnidadToSelectListItem(List<DO_Unidad> lista)
        {
            List<SelectListItem> listaResultante = new List<SelectListItem>();

            foreach (var item in lista)
            {
                SelectListItem obj = new SelectListItem();

                obj.Text = item.NombreUnidad;
                obj.Value = Convert.ToString(item.idUnidad);

                listaResultante.Add(obj);
            }

            return listaResultante;
        }
        #endregion

        #region Entradas
        public static int InsertEntradaArticuloAlmacen(int idAlmacen, int idProveedor,string noFactura,DateTime fecha,string usuario, List<DO_DetalleEntradaArticulo> articulos)
        {
            SO_EntradasAlmacen ServiceEntrada = new SO_EntradasAlmacen();
            
            SO_Existencia ServiceExistencia = new SO_Existencia();

            int idMovimientoEntrada = ServiceEntrada.InsertEntrada(idAlmacen, idProveedor, noFactura, fecha, usuario);

            int r = 0;

            if (idMovimientoEntrada > 0)
            {
                foreach (DO_DetalleEntradaArticulo detalle in articulos)
                {
                    if (InsertDetalleEntradaAlmacen(idMovimientoEntrada, detalle.idArticulo, detalle.cantidad, detalle.idUnidad) > 0)
                    {
                        r += ServiceExistencia.AddCantidad(idAlmacen, detalle.idArticulo, detalle.cantidad);
                    }
                }
            }

            return r;
        }

        public static int InsertDetalleEntradaAlmacen(int idMovimientoEntrada, int idArticulo, decimal cantidad,int idUnidad)
        {
            SO_Detalle_Entrada_Almacen service = new SO_Detalle_Entrada_Almacen();

            return service.Insert(idMovimientoEntrada, idArticulo, cantidad,idUnidad);
        }

        #endregion

        #region Salidas
        public static int InsertSalidaArticuloAlmacen(int idAlmacen,string usuarioSolicito,string usuarioAtendio, List<DO_DetalleSalidaArticulo> articulos)
        {
            SO_SalidasAlmacen service = new SO_SalidasAlmacen();
            SO_DetalleMovimientoSalidaAlmacen serviceDetalle = new SO_DetalleMovimientoSalidaAlmacen();

            string folio = GetNextFolioSalida();

            int idMovimientoSalidaAlmacen = service.InsertSalida(idAlmacen, usuarioSolicito, usuarioAtendio, folio);

            foreach (DO_DetalleSalidaArticulo item in articulos)
            {
                DO_DetalleSalidaAlmacen detalle = new DO_DetalleSalidaAlmacen();
                detalle.Articulo = GetArticulo(item.idCodigo);
                detalle.Cantidad = item.cantidad;
                detalle.condicionRegreso = string.Empty;
                detalle.condicionSalida = item.condicion;
                detalle.MovimientoSalidaAlmacen = new DO_MovimientoAlmacen { idMovimientoAlmacen = idMovimientoSalidaAlmacen };

                int r = serviceDetalle.Insert(detalle);
                SO_Existencia serviceExistencia = new SO_Existencia();
                int resultadoRemover = serviceExistencia.RemoveCantidad(idAlmacen, detalle.Articulo.idArticulo, detalle.Cantidad);

            }
            
            return idMovimientoSalidaAlmacen;
        }

        public static string GetNextFolioSalida()
        {
            //S000001918 -- Ejemplo
            string lastCode = string.Empty;
            string anio = DateTime.Now.Year.ToString().Substring(2,2);

            SO_SalidasAlmacen service = new SO_SalidasAlmacen();

            lastCode = service.GetLastCodeSalida();
            if (lastCode.Equals("ERROR"))
            {
                return "ERROR";
            }
            else
            {
                string consecutivo = lastCode.Substring(1, 7);
                string nextCode;

                int siguiente = Convert.ToInt32(consecutivo) + 1;

                if (siguiente.ToString().Length == 1)
                {
                    nextCode = "S" + "000000" + siguiente.ToString() + anio;
                }
                else
                {
                    if (siguiente.ToString().Length == 2)
                    {
                        nextCode = "S" + "00000" + siguiente.ToString() + anio;
                    }
                    else
                    {
                        if (siguiente.ToString().Length == 3)
                        {
                            nextCode = "S" + "0000" + siguiente.ToString() + anio;
                        }
                        else
                        {
                            if (siguiente.ToString().Length == 4)
                            {
                                nextCode = "S" + "000" + siguiente.ToString() + anio;
                            }
                            else
                            {
                                if (siguiente.ToString().Length == 5)
                                {
                                    nextCode = "S" + "00" + siguiente.ToString() + anio;
                                }
                                else
                                {
                                    if (siguiente.ToString().Length == 6)
                                    {
                                        nextCode = "S" + "0" + siguiente.ToString() + anio;
                                    }
                                    else
                                    {
                                        nextCode = "S" + siguiente.ToString() + anio;
                                    }
                                }
                                
                            }
                        }
                    }
                }

                return nextCode;
            }

        }

        public static DO_ValeSalidaAlmacen GetValeSalida(int idMovimientoSalida)
        {
            SO_SalidasAlmacen service = new SO_SalidasAlmacen();
            DO_ValeSalidaAlmacen vale = new DO_ValeSalidaAlmacen();


            IList informacionBD = service.GetMovimientoSalida(idMovimientoSalida);

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    DO_Persona personaSolicito = new DO_Persona();
                    DO_Persona personaAtendio = new DO_Persona();
                    Type tipo = item.GetType();

                    vale.ID_MOVIMIENTO_SALIDA_ALMACEN = (int)tipo.GetProperty("ID_MOVIMIENTO_SALIDA_ALMACEN").GetValue(item, null);
                    vale.Almacen = GetAlmacen((int)tipo.GetProperty("ID_ALMACEN").GetValue(item, null)).Nombre;
                    vale.idPersonaSolicito = (string)tipo.GetProperty("USUARIO_SOLICITO").GetValue(item, null);
                    vale.FechaSolicito = (DateTime)tipo.GetProperty("FECHA_SALIDA").GetValue(item, null);
                    vale.idPersonaAtendio = (string)tipo.GetProperty("USUARIO_ATENDIO").GetValue(item, null);
                    vale.Folio = (string)tipo.GetProperty("FOLIO").GetValue(item, null);
                    personaSolicito = GetPersona(vale.idPersonaSolicito);
                    personaAtendio = GetPersona(vale.idPersonaAtendio);

                    vale.NombrePersonaAtendio = personaAtendio.NombreCompleto;
                    vale.NombrePersonaSolicito = personaSolicito.NombreCompleto;

                }

                IList informacionBDArticulos = service.GetArticulosSalida(idMovimientoSalida);

                if (informacionBDArticulos != null)
                {
                    vale.ListaArticulos = new List<DO_DetalleSalidaArticulo>();

                    foreach (var item in informacionBDArticulos)
                    {
                        Type tipo = item.GetType();

                        DO_DetalleSalidaArticulo detalle = new DO_DetalleSalidaArticulo();

                        detalle.idCodigo = (int)tipo.GetProperty("ID_ARTICULO").GetValue(item, null);
                        detalle.cantidad = Convert.ToDouble(tipo.GetProperty("CANTIDAD").GetValue(item, null));
                        DO_Articulo articulo = GetArticulo(detalle.idCodigo);
                        detalle.codigo = articulo.Codigo;
                        detalle.condicion = (string)tipo.GetProperty("CONDICION_ARTICULO_SALIDA").GetValue(item, null);
                        detalle.Descripcion = (string)tipo.GetProperty("DESCRIPCION").GetValue(item, null);
                        

                        vale.ListaArticulos.Add(detalle);
                    }
                }
            }

            return vale;
        }

        public static DO_Result_SalidaAlmacen GetSalida(int idSalida)
        {
            SO_SalidasAlmacen service = new SO_SalidasAlmacen();

            DO_Result_SalidaAlmacen result = new DO_Result_SalidaAlmacen();

            IList informacionBD = service.GetSalida(idSalida);

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    Type tipo = item.GetType();

                    result = new DO_Result_SalidaAlmacen();

                    
                    result.FechaSolicitud = (DateTime)tipo.GetProperty("FECHA_SALIDA").GetValue(item, null);
                    result.idSalidaAlmacen = (int)tipo.GetProperty("ID_MOVIMIENTO_SALIDA_ALMACEN").GetValue(item, null);
                    result.NombreAlmacen = (string)tipo.GetProperty("NOMBRE").GetValue(item, null);
                    string usuarioAtendio = (string)tipo.GetProperty("USUARIO_ATENDIO").GetValue(item, null);
                    result.NombreAtendio = GetPersona(usuarioAtendio).NombreCompleto;

                    string usuarioSolicitante = (string)tipo.GetProperty("USUARIO_SOLICITO").GetValue(item, null);
                    result.NombreSolicitante = DataManager.GetPersona(usuarioSolicitante).NombreCompleto;
                    

                }
            }

            return result;
        }

        public static List<DO_MovimientoSalidaAlmacen> GetSalidasAbiertas()
        {
            List<DO_MovimientoSalidaAlmacen> ListaResultante = new List<DO_MovimientoSalidaAlmacen>();

            SO_SalidasAlmacen service = new SO_SalidasAlmacen();

            DataSet informacionBD = service.GetSalidasAbiertas();

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow element in informacionBD.Tables[0].Rows)
                    {
                        DO_MovimientoSalidaAlmacen obj = new DO_MovimientoSalidaAlmacen();

                        obj.IdMovimientoSalidaAlmacen = Convert.ToInt32(element["ID_MOVIMIENTO_SALIDA_ALMACEN"].ToString());
                        obj.IdAlmacen = Convert.ToInt32(element["ID_ALMACEN"].ToString());
                        obj.Folio = element["FOLIO"].ToString();
                        obj.UsuarioSolicito = element["USUARIO_SOLICITO"].ToString();
                        obj.UsuarioAtendio = element["USUARIO_ATENDIO"].ToString();
                        obj.FechaSalida = Convert.ToDateTime(element["FECHA_SALIDA"]);

                        ListaResultante.Add(obj);
                    }
                }
            }

            return ListaResultante;
        }

        public static DO_MovimientoSalidaAlmacen GetDetalleMovimientoSalidaAlmacen(string folio)
        {
            DO_MovimientoSalidaAlmacen salida = new DO_MovimientoSalidaAlmacen();

            SO_DetalleMovimientoSalidaAlmacen service = new SO_DetalleMovimientoSalidaAlmacen();

            IList informacionBD = service.GetDetalleSalida(folio);

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    Type tipo = item.GetType();

                    DO_DetalleSalidaAlmacen detalleArticulo = new DO_DetalleSalidaAlmacen();

                    int idArticulo = Convert.ToInt32(tipo.GetProperty("ID_ARTICULO").GetValue(item,null));

                    detalleArticulo.Articulo = GetArticulo(idArticulo);
                    detalleArticulo.Cantidad = Convert.ToDouble(tipo.GetProperty("CANTIDAD").GetValue(item,null));
                    detalleArticulo.condicionRegreso = Convert.ToString(tipo.GetProperty("CONDICION_ARTICULO_REGRESO").GetValue(item, null));
                    detalleArticulo.condicionSalida = Convert.ToString(tipo.GetProperty("CONDICION_ARTICULO_SALIDA").GetValue(item, null));
                    detalleArticulo.FechaRegreso = Convert.ToDateTime(tipo.GetProperty("FECHA_REGRESO").GetValue(item, null));
                    detalleArticulo.idDetalleSalidaAlmacen = Convert.ToInt32(tipo.GetProperty("ID_DETALLE_MOVIMIENTO_SALIDA_ALMACEN").GetValue(item, null));
                    salida.FechaSalida = Convert.ToDateTime(tipo.GetProperty("FECHA_SALIDA").GetValue(item, null));
                    salida.Folio = Convert.ToString(tipo.GetProperty("FOLIO").GetValue(item, null));
                    salida.UsuarioAtendio = Convert.ToString(tipo.GetProperty("USUARIO_ATENDIO").GetValue(item, null));
                    salida.UsuarioSolicito = Convert.ToString(tipo.GetProperty("USUARIO_SOLICITO").GetValue(item, null));
                    
                    salida.DetalleArticulo.Add(detalleArticulo);
                }
            }

            return salida;
        }

        public static int RetornoArticulo(int idDetalle, string condiciones, double cantidad)
        {
            SO_SalidasAlmacen service = new SO_SalidasAlmacen();
            
            int r =  service.RetornoArticulo(idDetalle, condiciones);

            if (r > 0)
            {
                SO_Existencia ServiceExistencia = new SO_Existencia();
                SO_DetalleMovimientoSalidaAlmacen ServiceDetalle = new SO_DetalleMovimientoSalidaAlmacen();
                int idAlmacen = ServiceDetalle.GetIdAlmacenByIdDetalleSalida(idDetalle);
                int idArticulo = ServiceDetalle.GetIdArticuloByIdDetalleSalida(idDetalle);
                return ServiceExistencia.AddCantidad(idAlmacen, idArticulo, Convert.ToDecimal(cantidad));
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region Alertas Stock
        public static IList<DO_AlertaStockMin> GetAllAlertas(int idCompania)
        {
            SO_AlertaStockMin service = new SO_AlertaStockMin();

            List<DO_AlertaStockMin> listaResultante = new List<DO_AlertaStockMin>();

            IList informacionBD = service.GetAllAlertasStockMinimo(idCompania);

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    DO_AlertaStockMin obj = new DO_AlertaStockMin();

                    Type tipo = item.GetType();

                    obj.idAlertaStockMin = (int)tipo.GetProperty("ID_ALERTA_STOCK_MIN").GetValue(item,null);
                    int idArticulo = (int)tipo.GetProperty("ID_ARTICULO").GetValue(item, null);
                    obj.Articulo = GetArticulo(idArticulo);
                    obj.Cantidad = Convert.ToDouble(tipo.GetProperty("CANTIDAD_MINIMA").GetValue(item,null));

                    listaResultante.Add(obj);

                }
            }

            return listaResultante;
        }

        public static int InsertAlertaStock(int idArticulo,double cantidad)
        {
            SO_AlertaStockMin service = new SO_AlertaStockMin();

            return service.Insert(idArticulo, cantidad);

        }
        #endregion

        #region General
        public static byte[] ImageToByteArray(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }
        #endregion

        #region Reportes
        public static List<DO_ReporteEntradaArticulo> GetReporteEntradaAlmacen(string fechaInicial, string fechaFinal, string noFactura, string usuario, int idAlmacen, int idProveedor, int idArticulo)
        {
            SO_Reportes service = new SO_Reportes();

            List<DO_ReporteEntradaArticulo> ListaResultante = new List<DO_ReporteEntradaArticulo>();

            DataSet informacionBD = service.GetEntradasArticulos(fechaInicial, fechaFinal, noFactura, usuario, idAlmacen, idProveedor, idArticulo);

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {
                        DO_ReporteEntradaArticulo obj = new DO_ReporteEntradaArticulo();

                        obj.CANTIDAD = Convert.ToDouble(item["CANTIDAD"].ToString());
                        obj.CODIGO_ARTICULO = item["CODIGO_ARTICULO"].ToString();
                        obj.DESCRIPCION_ARTICULO = item["DESCRIPCION_ARTICULO"].ToString();
                        obj.FECHA = Convert.ToDateTime(item["FECHA"].ToString());
                        obj.NOMBRE = item["NOMBRE"].ToString();
                        obj.NOMBRE_PROVEEDOR = item["NOMBRE_PROVEEDOR"].ToString();
                        obj.NOMBRE_UNIDAD = item["NOMBRE_UNIDAD"].ToString();
                        obj.NO_FACTURA = item["NO_FACTURA"].ToString();
                        obj.USUARIO = item["USUARIO"].ToString();

                        ListaResultante.Add(obj);
                    }
                }
            }

            return ListaResultante;
        }

        public static List<DO_ReporteSalidaArticulo> GetReporteSalidaAlmacen(string fechaInicial, string fechaFinal, string usuarioSolicito, string usuarioAtendio, string codigoArticulo, int idAlmacen)
        {
            List<DO_ReporteSalidaArticulo> ListaResultante = new List<DO_ReporteSalidaArticulo>();

            SO_Reportes Service = new SO_Reportes();

            DataSet informacionBD = Service.GetSalidasArticulos(fechaInicial, fechaFinal, usuarioSolicito, usuarioAtendio, codigoArticulo, idAlmacen);

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {
                        DO_ReporteSalidaArticulo salida = new DO_ReporteSalidaArticulo();

                        salida.NOMBRE_ALMACEN = item["NOMBRE_ALMACEN"].ToString();
                        DateTime fechaSalida = Convert.ToDateTime(item["FECHA_SALIDA"].ToString());

                        salida.FECHA_SALIDA = fechaSalida.ToShortDateString();
                        if (String.IsNullOrEmpty(item["FECHA_REGRESO"].ToString()))
                        {
                            salida.FECHA_REGRESO = "SIN REGRESO";
                        }
                        else
                        {
                            DateTime fechaRegreso = Convert.ToDateTime(item["FECHA_REGRESO"].ToString());
                            salida.FECHA_REGRESO = fechaRegreso.ToShortDateString();
                        }

                        salida.USUARIO_ATENDIO = item["USUARIO_ATENDIO"].ToString();
                        salida.USUARIO_SOLICITO = item["USUARIO_SOLICITO"].ToString();
                        salida.CODIGO = item["CODIGO"].ToString();
                        salida.DESCRIPCION_ARTICULO = item["DESCRIPCION_ARTICULO"].ToString();
                        salida.CANTIDAD = Convert.ToDouble(item["CANTIDAD"].ToString());
                        
                        ListaResultante.Add(salida);
                    }

                }
            }

            return ListaResultante;
        }
        #endregion

        #region Clientes

        public static List<DO_Clientes> GetAllClientes()
        {
            SO_Clientes Service = new SO_Clientes();

            List<DO_Clientes> ListaResultante = new List<DO_Clientes>();

            IList informacionBD = Service.ObtenerTodos();

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    DO_Clientes cliente = new DO_Clientes();

                    Type tipo = item.GetType();

                    cliente.Id_Cliente = (int)tipo.GetProperty("Id_Clientes").GetValue(item, null);
                    cliente.Nombre = (string)tipo.GetProperty("Nombre").GetValue(item, null);
                    cliente.RFC = (string)tipo.GetProperty("RFC").GetValue(item, null);
                    cliente.Telefono = (string)tipo.GetProperty("Telefono").GetValue(item, null);
                    cliente.Direccion = (string)tipo.GetProperty("Direccion").GetValue(item, null);
                    cliente.Correo = (string)tipo.GetProperty("Correo").GetValue(item, null);

                    ListaResultante.Add(cliente);
                }
            }

            return ListaResultante;
        }

        public static List<SelectListItem> ConvertListDOClienteToSelectListItem(List<DO_Clientes> lista)
        {
            List<SelectListItem> listaResultante = new List<SelectListItem>();

            foreach (var item in lista)
            {
                SelectListItem obj = new SelectListItem();

                obj.Text = item.Nombre;
                obj.Value = Convert.ToString(item.Id_Cliente);

                listaResultante.Add(obj);
            }

            return listaResultante;
        }

        public static int AltaCliente(string Correo, string Nombre, string RFC, string Telefono, string Direccion)
        {
            SO_Clientes service = new SO_Clientes();

            DO_Clientes cliente = new DO_Clientes();

            cliente.Correo = Correo;
            cliente.Nombre = Nombre;
            cliente.RFC = RFC;
            cliente.Telefono = Telefono;
            cliente.Direccion = Direccion;

           return service.AltaClientes(cliente);
        }

        public static int BajaCliente(int Id_Cliente)
        {
            SO_Clientes service = new SO_Clientes();

            return service.BorrarClientes(Id_Cliente);
        }

        public static int ActualizarCliente(string Correo, string Nombre, string RFC, string Telefono, string Direccion,int Id_Cliente)
        {
            SO_Clientes service = new SO_Clientes();

            DO_Clientes cliente = new DO_Clientes();

            cliente.Id_Cliente = Id_Cliente;
            cliente.Correo = Correo;
            cliente.Nombre = Nombre;
            cliente.RFC = RFC;
            cliente.Telefono = Telefono;
            cliente.Direccion = Direccion;

            return service.ActualizarCliente(cliente);
        }
        
        #endregion

        #region Productos

        public static List<DO_Productos> GetAllProductos()
        {
            List<DO_Productos> listaResultante = new List<DO_Productos>();

            SO_Productos service = new SO_Productos();

            IList informacionBD = service.ObtenerTodos();

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    DO_Productos producto = new DO_Productos();

                    Type tipo = item.GetType();

                    producto.Id_Productos = (int)tipo.GetProperty("Id_Productos").GetValue(item, null);
                    producto.Id_Categoria = (int)tipo.GetProperty("Id_Categoria").GetValue(item, null);
                    producto.Codigo = (string)tipo.GetProperty("Codigo").GetValue(item, null);
                    producto.Descripcion = (string)tipo.GetProperty("Descripcion").GetValue(item, null);
                    producto.foto = (byte[])tipo.GetProperty("foto").GetValue(item, null);

                    listaResultante.Add(producto);
                }
            }

            return listaResultante;
        }

        public static List<SelectListItem> ConvertListDOProductoToSelectListItem(List<DO_Productos> Lista)
        {
            List<SelectListItem> listaResultante = new List<SelectListItem>();

            foreach (var item in Lista)
            {
                SelectListItem obj = new SelectListItem();

                obj.Text = item.Descripcion;
                obj.Value = Convert.ToString(item.Id_Productos);

                listaResultante.Add(obj);
            }

            return listaResultante;
        }

        public static int AltaProducto(int Id_Categoria, string Codigo, string Descripcion, byte[] foto)
        {
            SO_Productos service = new SO_Productos();

            DO_Productos producto = new DO_Productos();

            producto.Id_Categoria = Id_Categoria;
            producto.Codigo = Codigo;
            producto.Descripcion = Descripcion;
            producto.foto =foto;

            return service.AltaProductos(producto);
        }

        public static int BajaProducto(int Id_Producto)
        {
            SO_Productos service = new SO_Productos();

            return service.BorrarProducto(Id_Producto);
        }

        public static int ActualizarProducto(int Id_Categoria, string Codigo, string Descripcion, byte[] foto,  int Id_Producto)
        {
            SO_Productos service = new SO_Productos();

            DO_Productos producto = new DO_Productos();

            producto.Id_Categoria = Id_Categoria;
            producto.Codigo =Codigo;
            producto.Descripcion =Descripcion;
            producto.foto = foto;

            return service.ActualizarProducto(producto);
        }

        public static DO_Productos GetProducto(int idProducto)
        {
            SO_Productos service = new SO_Productos();

            DO_Productos producto = new DO_Productos();

            IList informacionBD = service.GetProducto(idProducto);

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    producto = new DO_Productos();

                    Type tipo = item.GetType();

                    producto.Id_Productos = (int)tipo.GetProperty("Id_Productos").GetValue(item, null);
                    producto.Id_Categoria = (int)tipo.GetProperty("Id_Categoria").GetValue(item, null);
                    producto.Codigo = (string)tipo.GetProperty("Codigo").GetValue(item, null);
                    producto.Descripcion = (string)tipo.GetProperty("Descripcion").GetValue(item, null);
                    producto.foto = (byte[])tipo.GetProperty("foto").GetValue(item, null);
                }
            }

            return producto;
        }
        #endregion

        #region Ordenes
        public static int InsertOrden(string fechaSolicitud, string fechaEntrega, string requisicion, string proyecto, string folio, int idCliente, List<DO_SolicitudProducto> productos, string usuario)
        {
            SO_Ordenes service = new SO_Ordenes();

            DO_Ordenes orden = new DO_Ordenes();
            orden.Folio = folio;
            orden.FechaSolicitud = Convert.ToDateTime(fechaSolicitud);
            if (!string.IsNullOrEmpty(fechaEntrega))
            {
                orden.FechaEntrega = Convert.ToDateTime(fechaEntrega);
            }
            orden.Id_Cliente = idCliente;
            orden.Requisicion = requisicion;
            orden.Proyecto = proyecto;
            orden.Usuario = usuario;
            
            int idNewOrden = service.AltaOrdenes(orden);

            if (idNewOrden > 0)
            {
                foreach (var producto in productos)
                {
                    SO_OrdenDetalle serviceDetalle = new SO_OrdenDetalle();
                    DO_OrdenesDetalle detalle = new DO_OrdenesDetalle();

                    detalle.Id_Orden = idNewOrden;
                    detalle.Id_Producto = producto.idProducto;
                    detalle.Id_EstatusOrden = 1;
                    detalle.Cantidad = producto.cantidad;
                    detalle.EntregaParcial = 0;
                    detalle.EntregarA = producto.EntregarA;
                    detalle.FechaActualizacionEstatus = DateTime.Now;

                    serviceDetalle.AltaOrdenesDetalle(detalle);
                }
            }

            return idNewOrden;
        }

        public static int InsertArchivoOrden(int idOrden, byte[] archivoFisico,string extension,string nombreArchivo)
        {
            SO_ArchivosOrden service = new SO_ArchivosOrden();

            DO_ArchivosOrden archivo = new DO_ArchivosOrden();

            archivo.Archivo = archivoFisico;
            archivo.Extension = extension;
            archivo.Id_Orden = idOrden;
            archivo.Nombre = nombreArchivo;

            return service.AltaArchivosOrden(archivo);
        }

        public static List<DO_Ordenes> GetAllOrdenes()
        {
            SO_Ordenes service = new SO_Ordenes();

            List<DO_Ordenes> Lista = new List<DO_Ordenes>();

            IList informacionBD = service.ObtenerTodos();

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    Type tipo = item.GetType();

                    DO_Ordenes orden = new DO_Ordenes();

                    orden.Id_Orden = (int)tipo.GetProperty("Id_Orden").GetValue(item, null);
                    orden.Folio = (string)tipo.GetProperty("Folio").GetValue(item, null);
                    orden.FechaSolicitud = (DateTime)tipo.GetProperty("FechaSolicitud").GetValue(item, null);
                    orden.FechaEntrega = (DateTime)tipo.GetProperty("FechaEntrega").GetValue(item, null);
                    orden.Id_Cliente = (int)tipo.GetProperty("Id_Cliente").GetValue(item, null);
                    orden.Requisicion = (string)tipo.GetProperty("Requisicion").GetValue(item, null);
                    orden.Proyecto = (string)tipo.GetProperty("Proyecto").GetValue(item, null);
                    orden.Usuario = (string)tipo.GetProperty("Usuario").GetValue(item, null);

                    Lista.Add(orden);

                }
            }

            return Lista;
          
        }

        public static DO_Ordenes GetOrden(int idOrden)
        {
            SO_Ordenes ServiceOrden = new SO_Ordenes();
            DO_Ordenes orden = new DO_Ordenes();

            IList informacionBD = ServiceOrden.GetOrden(idOrden);

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    Type tipo = item.GetType();

                    orden.Id_Orden = (int)tipo.GetProperty("Id_Orden").GetValue(item, null);
                    orden.Folio = (string)tipo.GetProperty("Folio").GetValue(item, null);
                    orden.FechaSolicitud = (DateTime)tipo.GetProperty("FechaSolicitud").GetValue(item, null);
                    orden.FechaEntrega = (DateTime)tipo.GetProperty("FechaEntrega").GetValue(item, null);
                    orden.Id_Cliente = (int)tipo.GetProperty("Id_Cliente").GetValue(item, null);
                    orden.Requisicion = (string)tipo.GetProperty("Requisicion").GetValue(item, null);
                    orden.Proyecto = (string)tipo.GetProperty("Proyecto").GetValue(item, null);
                    orden.Usuario = (string)tipo.GetProperty("Usuario").GetValue(item, null);
                    
                }
            }

            if (orden.Id_Orden > 0)
            {
                SO_OrdenDetalle ServiceDetalleOrden = new SO_OrdenDetalle();

                IList informacionDetalleBD = ServiceDetalleOrden.GetAllByIdOrden(idOrden);

                orden.OrdernesDetalle = new List<DO_OrdenesDetalle>();

                if (informacionDetalleBD != null)
                {
                    foreach (var item in informacionDetalleBD)
                    {
                        Type tipo = item.GetType();
                        DO_OrdenesDetalle detalle = new DO_OrdenesDetalle();

                        detalle.Id_OrdenDetalle = (int)tipo.GetProperty("Id_OrdenDetalle").GetValue(item, null);
                        detalle.Id_Orden = (int)tipo.GetProperty("Id_Orden").GetValue(item, null);
                        detalle.Id_Producto = (int)tipo.GetProperty("Id_Producto").GetValue(item, null);
                        detalle.Id_EstatusOrden = (int)tipo.GetProperty("Id_EstatusOrden").GetValue(item, null);
                        detalle.Cantidad = (int)tipo.GetProperty("Cantidad").GetValue(item, null);
                        detalle.EntregaParcial = (int)tipo.GetProperty("EntregaParcial").GetValue(item, null);
                        detalle.EntregarA = (string)tipo.GetProperty("EntregarA").GetValue(item, null);
                        detalle.FechaActualizacionEstatus = (DateTime)tipo.GetProperty("FechaActualizacionEstatus").GetValue(item, null);

                        detalle.Producto = GetProducto(detalle.Id_Producto);
                        detalle.Estatus = GetEstatusOrden(detalle.Id_EstatusOrden);

                        orden.OrdernesDetalle.Add(detalle);

                    }
                }

            }
            return orden;
        }
        #endregion

        #region OrdenesDetalle

        public static int UpdateOrdenDetalle(int idOrdenDetalle,int idEstatusOrden,int entregaParcial,string entregarA)
        {
            SO_OrdenDetalle service = new SO_OrdenDetalle();

            DO_OrdenesDetalle ordendetalle = new DO_OrdenesDetalle();

            ordendetalle.Id_OrdenDetalle = idOrdenDetalle;
            ordendetalle.Id_EstatusOrden = idEstatusOrden;
            ordendetalle.EntregaParcial = entregaParcial;
            ordendetalle.EntregarA = entregarA;
            
            return service.ActualizarOrdenesDetalle(ordendetalle);
        }

        #endregion

        #region EstatusOrden

        public static DO_EstatusOrden GetEstatusOrden(int idEstatusOrden)
        {
            SO_EstatusOrden service = new SO_EstatusOrden();

            DO_EstatusOrden estatusOrden = new DO_EstatusOrden();

            IList informacionBD = service.GetEstatusOrden(idEstatusOrden);

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    Type tipo = item.GetType();

                    estatusOrden = new DO_EstatusOrden();

                    estatusOrden.Id_EstatusOrden = (int)tipo.GetProperty("Id_EstatusOrden").GetValue(item, null);
                    estatusOrden.EstatusOrden = (string)tipo.GetProperty("EstatusOrden1").GetValue(item, null);

                }
            }

            return estatusOrden;
        }

        public static List<DO_EstatusOrden> GetAllEstatus()
        {
            SO_EstatusOrden service = new SO_EstatusOrden();

            IList informacionBD = service.ObtenerTodos();

            List<DO_EstatusOrden> Lista = new List<DO_EstatusOrden>();

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    Type tipo = item.GetType();

                    DO_EstatusOrden estatus = new DO_EstatusOrden();

                    estatus.Id_EstatusOrden = (int)tipo.GetProperty("Id_EstatusOrden").GetValue(item, null);
                    estatus.EstatusOrden = (string)tipo.GetProperty("EstatusOrden1").GetValue(item, null);

                    Lista.Add(estatus);
                }
            }

            return Lista;
        }

        public static List<SelectListItem> ConvertListDOEstatusOrdenToSelectListItem(List<DO_EstatusOrden> Lista)
        {
            List<SelectListItem> listaResultante = new List<SelectListItem>();

            foreach (var item in Lista)
            {
                SelectListItem obj = new SelectListItem();

                obj.Text = item.EstatusOrden;
                obj.Value = Convert.ToString(item.Id_EstatusOrden);

                listaResultante.Add(obj);
            }

            return listaResultante;
        }

        #endregion

        #region Archivos
        public static byte[] GetBytesFromInputStream(Stream archivo)
        {
            //Inicializamos la variable que regresaremos
            byte[] ArchivoEnBytes = null;

            using (var binaryReader = new BinaryReader(archivo))
            {
                //Guardamos el archivo en el arreglo de bytes
                ArchivoEnBytes = binaryReader.ReadBytes((int)archivo.Length);
                //Regresamos el arreglo
                return ArchivoEnBytes;
            }
        } 
        #endregion
    }
}