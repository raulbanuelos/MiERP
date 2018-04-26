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
        public static int InsertEntradaArticuloAlmacen(int idAlmacen, int idArticulo, int idProveedor, int idUnidad,double cantidad,string noFactura,DateTime fecha,string usuario)
        {
            SO_EntradasAlmacen service = new SO_EntradasAlmacen();

            int r = service.InsertEntrada(idAlmacen, idArticulo, idProveedor, idUnidad, cantidad, noFactura, fecha, usuario);

            if (r > 0)
            {
                SO_Existencia serviceExistencia = new SO_Existencia();

                return serviceExistencia.AddCantidad(idAlmacen, idArticulo, cantidad);
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region Salidas
        public static int InsertSalidaArticuloAlmacen(int idAlmacen,string usuarioSolicito,string usuarioAtendio, List<DO_DetalleSalidaArticulo> articulos)
        {
            SO_SalidasAlmacen service = new SO_SalidasAlmacen();
            SO_DetalleMovimientoSalidaAlmacen serviceDetalle = new SO_DetalleMovimientoSalidaAlmacen();
            
            int idMovimientoSalidaAlmacen = service.InsertSalida(idAlmacen, usuarioSolicito, usuarioAtendio);

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
    }
}