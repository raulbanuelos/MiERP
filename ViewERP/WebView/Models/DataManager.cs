using Data.ServiceObject;
using DocumentFormat.OpenXml.Office2013.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
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

namespace WebView.Models
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
                    persona.FechaRegistro = Convert.ToDateTime(tipo.GetProperty("FECHA_REGISTRO").GetValue(item, null));
                    persona.NombrePlan = (string)tipo.GetProperty("NOMBRE_PLAN").GetValue(item, null);
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
                    persona.NombrePlan = (string)tipo.GetProperty("NOMBRE_PLAN").GetValue(item, null);
                    persona.IdJefe = string.IsNullOrEmpty(Convert.ToString(tipo.GetProperty("JefeId").GetValue(item, null))) ? 0 : (int)tipo.GetProperty("JefeId").GetValue(item, null);
                    persona.Rol = (string)tipo.GetProperty("ROL").GetValue(item, null);
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

        public static List<DO_Persona> GetAllPersona()
        {
            List<DO_Persona> lista = new List<DO_Persona>();

            SO_Usuario service = new SO_Usuario();

            IList informacionBD = service.GetAllUsuarios();

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
                    persona.NombreCompania = (string)tipo.GetProperty("NOMBRE_COMPANIA").GetValue(item, null);
                    persona.ApellidoPaterno = (string)tipo.GetProperty("APATERNO").GetValue(item, null);
                    persona.ApellidoMaterno = (string)tipo.GetProperty("AMATERNO").GetValue(item, null);
                    persona.Usuario = (string)tipo.GetProperty("USUARIO").GetValue(item, null);
                    persona.Rol = (string)tipo.GetProperty("ROL").GetValue(item, null);
                    persona.IdPlan = (int)tipo.GetProperty("ID_PLAN").GetValue(item, null);
                    persona.NombrePlan = (string)tipo.GetProperty("NOMBRE_PLAN").GetValue(item, null);
                    persona.FechaRegistro = (DateTime)tipo.GetProperty("FECHA_REGISTRO").GetValue(item, null);
                    persona.SFechaRegistro = ConvertDatetime(persona.FechaRegistro);
                    lista.Add(persona);
                }
            }

            return lista.OrderBy(x => x.NombreCompania).ToList();
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

            return service.Insert(persona.ID_ROL, persona.idCompania, persona.Nombre, persona.ApellidoPaterno, persona.ApellidoMaterno, persona.Usuario, persona.Contrasena, persona.IdJefe);
        }

        public static int UpdatePersona(DO_Persona persona)
        {
            SO_Usuario service = new SO_Usuario();

            return service.Update(persona.ID_ROL, persona.idCompania, persona.Nombre, persona.ApellidoPaterno, persona.ApellidoMaterno, persona.Usuario, persona.idUsuario, persona.IdJefe);
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

        public static int UpdateContrasena(int idPersona, string contrasena)
        {
            SO_Usuario service = new SO_Usuario();

            return service.UpdateContrasena(idPersona, contrasena);
        }

        public static bool CheckPass(int idPersona, string password)
        {
            SO_Usuario service = new SO_Usuario();

            return service.CheckPassword(idPersona, password);
        }

        public static List<int> GetIdJefe(int idUsuario)
        {
            SO_Usuario sO_Usuario = new SO_Usuario();

            IList informacionBD = sO_Usuario.GetJefeId(idUsuario);

            List<int> ids = new List<int>();

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    Type type = item.GetType();

                    int id = Convert.ToInt32(item);
                    ids.Add(id);
                }
            }

            return ids;
        }

        public static List<DO_OrganizationChart> GetMiOrganizacion(int idUsuario)
        {
            List<int> ids = GetIdJefe(idUsuario);

            List<DO_OrganizationChart> charts = new List<DO_OrganizationChart>();

            SO_Usuario sO_Usuario = new SO_Usuario();

            foreach (var id in ids)
            {
                DO_OrganizationChart dO_Organizacion = new DO_OrganizationChart();

                DO_Persona dO_Persona = GetPersona(id);

                dO_Organizacion.Yo = dO_Persona;

                charts.Add(dO_Organizacion);
            }

            return charts;
        }

        public static List<SelectListItem> GetPosiblesJefes()
        {
            SO_Usuario sO_Usuario = new SO_Usuario();

            IList informacionBD = sO_Usuario.GetPosiblesJefes();

            List<DO_Persona> personas = new List<DO_Persona>();

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

                    personas.Add(persona);
                }
            }

            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var item in personas)
            {
                SelectListItem selectListItem = new SelectListItem();

                selectListItem.Value = Convert.ToString(item.idUsuario);
                selectListItem.Text = item.Nombre;

                listItems.Add(selectListItem);
            }

            SelectListItem selectListItem1 = new SelectListItem();
            selectListItem1.Value = "0";
            selectListItem1.Text = "Reporto a";
            selectListItem1.Selected = true;

            return listItems;
        }

        public static List<SelectListItem> GetPosiblesJefes(int idCompania)
        {
            SO_Usuario sO_Usuario = new SO_Usuario();

            IList informacionBD = sO_Usuario.GetPosiblesJefes(idCompania);

            List<DO_Persona> personas = new List<DO_Persona>();

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

                    personas.Add(persona);
                }
            }

            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var item in personas)
            {
                SelectListItem selectListItem = new SelectListItem();

                selectListItem.Value = Convert.ToString(item.idUsuario);
                selectListItem.Text = item.Nombre;

                listItems.Add(selectListItem);
            }

            SelectListItem selectListItem1 = new SelectListItem();
            selectListItem1.Value = "0";
            selectListItem1.Text = "Reporto a";
            selectListItem1.Selected = true;

            return listItems;
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
                    articulo.PRECIO_GERENTE = Convert.ToDouble(tipo.GetProperty("PRECIO_GERENTE").GetValue(item, null));
                    articulo.PRECIO_MASTER = Convert.ToDouble(tipo.GetProperty("PRECIO_MASTER").GetValue(item, null));
                    articulo.PRECIO_PROMOTOR = Convert.ToDouble(tipo.GetProperty("PRECIO_PROMOTOR").GetValue(item, null));
                    articulo.PRECIO_UNIDAD = Convert.ToDouble(tipo.GetProperty("PRECIO_UNIDAD").GetValue(item, null));

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

                obj.Text = item.Descripcion;
                obj.Value = Convert.ToString(item.idArticulo);
                listaResultante.Add(obj);
            }

            return listaResultante;
        }

        public static List<SelectListItem> ConvertListDoPersonaToSelectListItem(List<DO_Persona> promotores)
        {
            List<SelectListItem> listaResultante = new List<SelectListItem>();

            foreach (var item in promotores)
            {
                SelectListItem obj = new SelectListItem();

                obj.Text = item.Nombre;
                obj.Value = Convert.ToString(item.idUsuario);
                listaResultante.Add(obj);
            }

            return listaResultante;
        }

        public static DO_Articulo GetArticulo(int idArticulo)
        {
            SO_Articulo service = new SO_Articulo();

            DO_Articulo articulo = new DO_Articulo();

            //articulo = service.GetArticulo(idArticulo);

            IList informacionBD = service.GetArticulo(idArticulo);
            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    Type type = item.GetType();

                    articulo = new DO_Articulo();

                    articulo.Codigo = (string)type.GetProperty("CODIGO").GetValue(item, null);
                    articulo.Descripcion = (string)type.GetProperty("DESCRIPCION").GetValue(item, null);
                    articulo.NumeroDeSerie = (string)type.GetProperty("DESCRIPCION_LARGA").GetValue(item, null);
                    articulo.CodigoDeBarras = (byte[])type.GetProperty("FOTO").GetValue(item, null);
                    articulo.idArticulo = (int)type.GetProperty("ID_ARTICULO").GetValue(item, null);
                    articulo.idCompania = (int)type.GetProperty("ID_COMPANIA").GetValue(item, null);
                    articulo.ID_CATEGORIA = (int)type.GetProperty("ID_CATEGORIA").GetValue(item, null);
                    articulo.stockMax = (int)type.GetProperty("STOCK_MAX").GetValue(item, null);
                    articulo.stockMin = (int)type.GetProperty("STOCK_MIN").GetValue(item, null);
                    articulo.IsConsumible = (bool)type.GetProperty("CONSUMIBLE").GetValue(item, null);
                    articulo.PRECIO_GERENTE = Convert.ToDouble(type.GetProperty("PRECIO_GERENTE").GetValue(item, null));
                    articulo.PRECIO_MASTER = Convert.ToDouble(type.GetProperty("PRECIO_MASTER").GetValue(item, null));
                    articulo.PRECIO_PROMOTOR = Convert.ToDouble(type.GetProperty("PRECIO_PROMOTOR").GetValue(item, null));
                    articulo.PRECIO_UNIDAD = Convert.ToDouble(type.GetProperty("PRECIO_UNIDAD").GetValue(item, null));
                }
            }

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

        public static List<DO_Existencia> GetExistenciasByCompania(int idCompania)
        {
            List<DO_Existencia> existencias = new List<DO_Existencia>();

            List<DO_Articulo> articulos = GetAllArticulos(idCompania);

            SO_Existencia sO_Existencia = new SO_Existencia();

            DataSet dataSet = sO_Existencia.GetByCompania(idCompania);

            if (dataSet != null)
            {
                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in dataSet.Tables[0].Rows)
                    {
                        DO_Existencia existencia = new DO_Existencia();

                        existencia.IdArticulo = Convert.ToInt32(item["ID_ARTICULO"]);
                        existencia.Descripcion = Convert.ToString(item["DESCRIPCION"]);
                        double precioGerente = articulos.Where(x => x.idArticulo == existencia.IdArticulo).FirstOrDefault().PRECIO_MASTER;
                        existencia.Cantidad = Convert.ToDouble(item["CANTIDAD"]);
                        existencia.ValorInventario = existencia.Cantidad * precioGerente;

                        existencias.Add(existencia);
                    }
                }
            }

            return existencias;
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

                    existencia.IdArticulo = Convert.ToInt32(tipo.GetProperty("ID_ARTICULO").GetValue(item, null));
                    existencia.Cantidad = Convert.ToDouble(tipo.GetProperty("CANTIDAD").GetValue(item, null));
                    existencia.CodigoArticulo = (string)tipo.GetProperty("CODIGO").GetValue(item, null);
                    existencia.Descripcion = (string)tipo.GetProperty("DESCRIPCION").GetValue(item, null);
                    existencia.idExistencia = (int)tipo.GetProperty("ID_EXISTENCIA").GetValue(item, null);
                    existencia.NumeroSerie = (string)tipo.GetProperty("NUMERO_SERIE").GetValue(item, null);
                    double precioMaster = Convert.ToDouble(tipo.GetProperty("PRECIO_MASTER").GetValue(item, null));

                    existencia.ValorInventario = existencia.Cantidad * precioMaster;

                    listaResultante.Add(existencia);
                }
            }

            return listaResultante;
        }

        public static int InsertDetailsArticulo(int idArticulo, double precioUnidad, double precioMaster, double precioPromotor, double precioGerente)
        {
            SO_Details_Articulo details_Articulo = new SO_Details_Articulo();

            return details_Articulo.Insert(idArticulo, precioUnidad, precioMaster, precioPromotor, precioGerente);
        }

        public static int UpdateDetailsArticulo(int idArticulo, double precioUnidad, double precioMaster, double precioPromotor, double precioGerente)
        {
            SO_Details_Articulo sO_Details_Articulo = new SO_Details_Articulo();

            return sO_Details_Articulo.Update(idArticulo, precioUnidad, precioMaster, precioPromotor, precioGerente);
        }

        public static double GetPrecioUnidad(int idArticulo)
        {
            SO_Details_Articulo sO_Details_Articulo = new SO_Details_Articulo();

            return sO_Details_Articulo.GetPrecioUnidad(idArticulo);
        }

        public static double GetPrecioGerente(int idArticulo)
        {
            SO_Details_Articulo sO_Details_Articulo = new SO_Details_Articulo();

            return sO_Details_Articulo.GetPrecioGerente(idArticulo);
        }

        public static double GetPrecioMaster(int idArticulo)
        {
            SO_Details_Articulo sO_Details_Articulo = new SO_Details_Articulo();

            return sO_Details_Articulo.GetPrecioMaster(idArticulo);
        }

        public static double GetPrecioPromotor(int idArticulo)
        {
            SO_Details_Articulo sO_Details_Articulo = new SO_Details_Articulo();

            return sO_Details_Articulo.GetPrecioPromotor(idArticulo);
        }

        public static List<FO_Item> GetCorteExistencia(int idSemana, int idAlmacen)
        {
            SO_CorteExistencia sO_CorteExistencia = new SO_CorteExistencia();

            List<FO_Item> existencias = new List<FO_Item>();

            IList list = sO_CorteExistencia.Get(idSemana, idAlmacen);

            if (list != null)
            {
                foreach (var item in list)
                {
                    Type type = item.GetType();

                    FO_Item fO_Item = new FO_Item();

                    fO_Item.NombreInt = Convert.ToInt32(type.GetProperty("ID_ARTICULO").GetValue(item, null));
                    fO_Item.ValueInt = Convert.ToInt32(type.GetProperty("CANTIDAD").GetValue(item, null));

                    existencias.Add(fO_Item);
                }
            }

            return existencias;
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
        public static int InsertEntradaArticuloAlmacen(int idAlmacen, int idProveedor, string noFactura, DateTime fecha, string usuario, List<DO_DetalleEntradaArticulo> articulos, double costoGuia)
        {
            SO_EntradasAlmacen ServiceEntrada = new SO_EntradasAlmacen();

            SO_Existencia ServiceExistencia = new SO_Existencia();

            int idMovimientoEntrada = ServiceEntrada.InsertEntrada(idAlmacen, idProveedor, noFactura, fecha, usuario, costoGuia);

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

        public static int InsertDetalleEntradaAlmacen(int idMovimientoEntrada, int idArticulo, decimal cantidad, int idUnidad)
        {
            SO_Detalle_Entrada_Almacen service = new SO_Detalle_Entrada_Almacen();

            return service.Insert(idMovimientoEntrada, idArticulo, cantidad, idUnidad);
        }

        public static List<DO_Movimiento> GetMovimientoSalidasCurrentWeek(int idCompania)
        {
            SO_DetalleMovimientoSalidaAlmacen sO_SalidasAlmacen = new SO_DetalleMovimientoSalidaAlmacen();

            DataSet informacionBD = sO_SalidasAlmacen.GetSalidasCurrentWeek(idCompania);

            List<DO_Movimiento> dO_Movimientos = new List<DO_Movimiento>();

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {
                        DO_Movimiento dO_Movimiento = new DO_Movimiento();

                        dO_Movimiento.Nombre = item["DESCRIPCION"].ToString();
                        dO_Movimiento.Cantidad = Convert.ToInt32(item["CANTIDAD"]);
                        dO_Movimiento.BodegaDestino = item["DESTINO"].ToString();

                        dO_Movimientos.Add(dO_Movimiento);
                    }
                }
            }
            return dO_Movimientos;
        }

        public static List<DO_Movimiento> GetMovimientoEntradasCurrentWeek(int idCompania)
        {
            SO_Detalle_Entrada_Almacen so_Entradas = new SO_Detalle_Entrada_Almacen();

            DataSet informacionBD = so_Entradas.GetEntradasCurrentWeek(idCompania);

            List<DO_Movimiento> dO_Movimientos = new List<DO_Movimiento>();

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {
                        DO_Movimiento dO_Movimiento = new DO_Movimiento();

                        dO_Movimiento.Nombre = item["DESCRIPCION"].ToString();
                        dO_Movimiento.Cantidad = Convert.ToInt32(item["CANTIDAD"]);
                        dO_Movimiento.BodegaDestino = item["DESTINO"].ToString();
                        DateTime dateTime = Convert.ToDateTime(item["fecha"]);
                        dO_Movimiento.fecha = dateTime.Year + "-" + dateTime.Month + "-" + dateTime.Day;

                        dO_Movimientos.Add(dO_Movimiento);
                    }
                }
            }
            return dO_Movimientos;
        }

        public static List<DO_Movimiento> GetMovimientoEntradasPorWeek(int idCompania, int idSemana)
        {
            SO_Detalle_Entrada_Almacen so_Entradas = new SO_Detalle_Entrada_Almacen();

            DataSet informacionBD = so_Entradas.GetEntradasPorWeek(idCompania, idSemana);

            List<DO_Movimiento> dO_Movimientos = new List<DO_Movimiento>();

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {
                        DO_Movimiento dO_Movimiento = new DO_Movimiento();

                        dO_Movimiento.IdArticulo = Convert.ToInt32(item["ID_ARTICULO"]);
                        dO_Movimiento.Nombre = item["DESCRIPCION"].ToString();
                        dO_Movimiento.Cantidad = Convert.ToInt32(item["CANTIDAD"]);
                        dO_Movimiento.BodegaDestino = item["DESTINO"].ToString();

                        dO_Movimientos.Add(dO_Movimiento);
                    }
                }
            }
            return dO_Movimientos;
        }

        public static List<DO_Movimiento> GetMovimientoEntradasPorWeekDetalle(int idCompania, int idSemana)
        {
            SO_Detalle_Entrada_Almacen so_Entradas = new SO_Detalle_Entrada_Almacen();

            DataSet informacionBD = so_Entradas.GetEntradasPorWeekDetalle(idCompania, idSemana);

            List<DO_Movimiento> dO_Movimientos = new List<DO_Movimiento>();

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {
                        DO_Movimiento dO_Movimiento = new DO_Movimiento();

                        dO_Movimiento.IdArticulo = Convert.ToInt32(item["ID_ARTICULO"]);
                        dO_Movimiento.Nombre = item["DESCRIPCION"].ToString();
                        dO_Movimiento.Cantidad = Convert.ToInt32(item["CANTIDAD"]);
                        dO_Movimiento.BodegaDestino = item["DESTINO"].ToString();
                        DateTime date = Convert.ToDateTime(item["FECHA"]);
                        dO_Movimiento.fecha = ConvertDatetime(date);

                        dO_Movimientos.Add(dO_Movimiento);
                    }
                }
            }
            return dO_Movimientos;
        }

        public static List<DO_Movimiento> GetAllEntradas(int idAlmacen, int idSemana)
        {
            List<DO_Movimiento> entradas = new List<DO_Movimiento>();

            DO_Semana rangoSemana = GetSemana(idSemana);

            SO_Detalle_Entrada_Almacen sO_Detalle_Entrada_Almacen = new SO_Detalle_Entrada_Almacen();

            IList informacionBD = sO_Detalle_Entrada_Almacen.GetAllEntradasPorWeek(idAlmacen, rangoSemana.FechaInicial, rangoSemana.FechaFinal);

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    Type type = item.GetType();

                    DO_Movimiento movimiento = new DO_Movimiento();

                    movimiento.IdMovimiento = (int)type.GetProperty("ID_MOVIMIENTO_ALMACEN").GetValue(item, null);
                    movimiento.NoFactura = (string)type.GetProperty("NO_FACTURA").GetValue(item, null);
                    movimiento.CostoGuia = Convert.ToDouble(type.GetProperty("COSTO_GUIA").GetValue(item, null));

                    entradas.Add(movimiento);
                }
            }

            return entradas;
        }

        #endregion

        #region Salidas
        public static List<DO_Movimiento> GetMovimientoSalidasPorWeek(int idCompania, int idSemana)
        {
            SO_DetalleMovimientoSalidaAlmacen sO_SalidasAlmacen = new SO_DetalleMovimientoSalidaAlmacen();

            DataSet informacionBD = sO_SalidasAlmacen.GetSalidasPorWeek(idCompania, idSemana);

            List<DO_Movimiento> dO_Movimientos = new List<DO_Movimiento>();

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {
                        DO_Movimiento dO_Movimiento = new DO_Movimiento();

                        dO_Movimiento.IdArticulo = Convert.ToInt32(item["ID_ARTICULO"]);
                        dO_Movimiento.Nombre = item["DESCRIPCION"].ToString();
                        dO_Movimiento.Cantidad = Convert.ToInt32(item["CANTIDAD"]);
                        dO_Movimiento.BodegaDestino = item["DESTINO"].ToString();

                        dO_Movimientos.Add(dO_Movimiento);
                    }
                }
            }
            return dO_Movimientos;
        }

        public static List<DO_Movimiento> GetMovimientoSalidasPorWeekDetalle(int idCompania, int idSemana)
        {
            SO_DetalleMovimientoSalidaAlmacen sO_SalidasAlmacen = new SO_DetalleMovimientoSalidaAlmacen();

            DataSet informacionBD = sO_SalidasAlmacen.GetSalidasPorWeekDetalle(idCompania, idSemana);

            List<DO_Movimiento> dO_Movimientos = new List<DO_Movimiento>();

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {
                        DO_Movimiento dO_Movimiento = new DO_Movimiento();

                        dO_Movimiento.IdArticulo = Convert.ToInt32(item["ID_ARTICULO"]);
                        dO_Movimiento.Nombre = item["DESCRIPCION"].ToString();
                        dO_Movimiento.Cantidad = Convert.ToInt32(item["CANTIDAD"]);
                        dO_Movimiento.BodegaDestino = item["DESTINO"].ToString();
                        DateTime fechaSalida = Convert.ToDateTime(item["FECHA_SALIDA"]);
                        dO_Movimiento.fecha = ConvertDatetime(fechaSalida);

                        dO_Movimientos.Add(dO_Movimiento);
                    }
                }
            }
            return dO_Movimientos;
        }

        public static int InsertSalidaArticuloAlmacen(int idAlmacen, string usuarioSolicito, string usuarioAtendio, List<DO_DetalleSalidaArticulo> articulos)
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
            string anio = DateTime.Now.Year.ToString().Substring(2, 2);

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

                    int idArticulo = Convert.ToInt32(tipo.GetProperty("ID_ARTICULO").GetValue(item, null));

                    detalleArticulo.Articulo = GetArticulo(idArticulo);
                    detalleArticulo.Cantidad = Convert.ToDouble(tipo.GetProperty("CANTIDAD").GetValue(item, null));
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

            int r = service.RetornoArticulo(idDetalle, condiciones);

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

                    obj.idAlertaStockMin = (int)tipo.GetProperty("ID_ALERTA_STOCK_MIN").GetValue(item, null);
                    int idArticulo = (int)tipo.GetProperty("ID_ARTICULO").GetValue(item, null);
                    obj.Articulo = GetArticulo(idArticulo);
                    obj.Cantidad = Convert.ToDouble(tipo.GetProperty("CANTIDAD_MINIMA").GetValue(item, null));

                    listaResultante.Add(obj);

                }
            }

            return listaResultante;
        }

        public static int InsertAlertaStock(int idArticulo, double cantidad)
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

        public static int ActualizarCliente(string Correo, string Nombre, string RFC, string Telefono, string Direccion, int Id_Cliente)
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
            producto.foto = foto;

            return service.AltaProductos(producto);
        }

        public static int BajaProducto(int Id_Producto)
        {
            SO_Productos service = new SO_Productos();

            return service.BorrarProducto(Id_Producto);
        }

        public static int ActualizarProducto(int Id_Categoria, string Codigo, string Descripcion, byte[] foto, int Id_Producto)
        {
            SO_Productos service = new SO_Productos();

            DO_Productos producto = new DO_Productos();

            producto.Id_Categoria = Id_Categoria;
            producto.Codigo = Codigo;
            producto.Descripcion = Descripcion;
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

        public static int GetIdProducto(string descripcion)
        {
            SO_Productos service = new SO_Productos();

            return service.GetIdProducto(descripcion);
        }

        public static string GetNextCodeProducto()
        {
            SO_Productos service = new SO_Productos();

            string lastCode = service.GetLastCode();
            string newCode = "";
            if (lastCode != "ERROR")
            {

                string numeric = lastCode.Substring(3);

                int numero = Convert.ToInt32(numeric) + 1;

                if (numero.ToString().Length == 1)
                {
                    newCode = "MAQ00000" + numero;
                }
                else
                {
                    if (numero.ToString().Length == 2)
                    {
                        newCode = "MAQ0000" + numero;
                    }
                    else
                    {
                        if (numero.ToString().Length == 3)
                        {
                            newCode = "MAQ000" + numero;
                        }
                        else
                        {
                            if (numero.ToString().Length == 4)
                            {
                                newCode = "MAQ00" + numero;
                            }
                            else
                            {
                                if (numero.ToString().Length == 5)
                                {
                                    newCode = "MAQ0" + numero;
                                }
                                else
                                {
                                    if (numero.ToString().Length == 6)
                                    {
                                        newCode = "MAQ" + numero;
                                    }
                                }
                            }
                        }
                    }
                }
                return newCode;
            }
            else
                return string.Empty;
        }
        #endregion

        #region Ordenes
        public static int InsertOrden(string fechaSolicitud, string fechaEntrega, string requisicion, string proyecto, string folio, int idCliente, List<DO_SolicitudProducto> productos, string usuario)
        {
            SO_Ordenes service = new SO_Ordenes();

            DO_Ordenes orden = new DO_Ordenes();
            orden.Folio = folio;
            //orden.FechaSolicitud = Convert.ToDateTime(fechaSolicitud);

            orden.FechaSolicitud = DateTime.ParseExact(fechaSolicitud, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            if (!string.IsNullOrEmpty(fechaEntrega) && fechaEntrega != "Sin-Fecha")
            {
                //orden.FechaEntrega = Convert.ToDateTime(fechaEntrega);
                orden.FechaEntrega = DateTime.ParseExact(fechaEntrega, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToShortDateString();

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

        public static int InsertArchivoOrden(int idOrden, byte[] archivoFisico, string extension, string nombreArchivo)
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
                    if ((string)tipo.GetProperty("FechaEntrega").GetValue(item, null) == "Sin Fecha")
                    {
                        orden.FechaEntrega = "Sin Fecha";
                    }
                    else
                    {
                        orden.FechaEntrega = Convert.ToDateTime(tipo.GetProperty("FechaEntrega").GetValue(item, null)).ToShortDateString();
                        if (orden.FechaEntrega == "01/01/0001")
                        {
                            orden.FechaEntrega = "Sin Fecha";
                        }

                    }

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
                    if ((string)tipo.GetProperty("FechaEntrega").GetValue(item, null) == "Sin fecha")
                    {
                        orden.FechaEntrega = "Sin Fecha";
                    }
                    else
                    {
                        orden.FechaEntrega = Convert.ToDateTime(tipo.GetProperty("FechaEntrega").GetValue(item, null)).ToShortDateString();
                        if (orden.FechaEntrega == "01/01/0001")
                        {
                            orden.FechaEntrega = "Sin Fecha";
                        }
                    }

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

        public static List<DO_C_Orcen> ReadOrden(DataTable dt)
        {
            List<DO_C_Orcen> ListaResultante = new List<DO_C_Orcen>();

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        DO_C_Orcen orden = new DO_C_Orcen();

                        orden.Proyecto = item[1].ToString();
                        orden.PlantaDestino = item[2].ToString();
                        orden.EquipoRequerido = item[3].ToString();
                        orden.EnviarA = item[4].ToString();
                        orden.CantidadTotal = Convert.ToInt32(item[5].ToString());

                        if (string.IsNullOrEmpty(item[6].ToString()))
                        {
                            orden.EntregaParcial = 0;
                        }
                        else
                        {
                            orden.EntregaParcial = Convert.ToInt32(item[6].ToString());
                        }

                        if (string.IsNullOrEmpty(item[7].ToString()))
                        {
                            orden.Entrega = 0;
                        }
                        else
                        {
                            orden.Entrega = Convert.ToInt32(item[7].ToString());
                        }

                        orden.NoVale = item[8].ToString();
                        orden.Requisicion = item[9].ToString();
                        orden.FechaPedido = item[10].ToString();
                        orden.FechaEntrega = item[11].ToString();
                        orden.OrdenCompra = item[12].ToString();

                        ListaResultante.Add(orden);
                    }
                }
            }

            return ListaResultante;
        }

        public static bool InsertOrdenFromFile(List<DO_C_Orcen> lista, int idCliente, string usuario)
        {
            bool respuesta = true;
            foreach (var item in lista)
            {
                int idProducto = GetIdProducto(item.EquipoRequerido);
                //Checamos si existe el producto, si no existe, agregamos el producto
                if (idProducto == 0)
                {
                    idProducto = AltaProducto(1, GetNextCodeProducto(), item.EquipoRequerido, new byte[0]);
                }

                List<DO_SolicitudProducto> productosSolicitados = new List<DO_SolicitudProducto>();

                //por el momento solo sera un producto por orden.
                DO_SolicitudProducto productoSolicitado = new DO_SolicitudProducto();

                productoSolicitado.cantidad = item.CantidadTotal;
                productoSolicitado.descripcion = item.EquipoRequerido;
                productoSolicitado.EntregarA = item.EnviarA;
                productoSolicitado.idProducto = idProducto;
                productosSolicitados.Add(productoSolicitado);
                int r = InsertOrden(item.FechaPedido, item.FechaEntrega, item.Requisicion, item.Proyecto, item.NoVale, idCliente, productosSolicitados, usuario);
                respuesta = r > 0 && respuesta ? true : false;
            }

            return respuesta;
        }

        #endregion

        #region OrdenesDetalle

        public static int UpdateOrdenDetalle(int idOrdenDetalle, int idEstatusOrden, int entregaParcial, string entregarA)
        {
            SO_OrdenDetalle service = new SO_OrdenDetalle();

            DO_OrdenesDetalle ordendetalle = new DO_OrdenesDetalle();

            ordendetalle.Id_OrdenDetalle = idOrdenDetalle;
            ordendetalle.Id_EstatusOrden = idEstatusOrden;
            ordendetalle.EntregaParcial = entregaParcial;
            ordendetalle.EntregarA = entregarA;

            return service.ActualizarOrdenesDetalle(ordendetalle);
        }

        public static List<DO_C_Orcen> GetAllDetalleOrden()
        {
            List<DO_C_Orcen> Lista = new List<DO_C_Orcen>();

            SO_OrdenDetalle service = new SO_OrdenDetalle();

            IList informacionBD = service.GetDetallesOrdenes();

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    Type tipo = item.GetType();

                    DO_C_Orcen ordenDetalle = new DO_C_Orcen();

                    ordenDetalle.idDetalle = (int)tipo.GetProperty("ID_DETALLE_ORDEN").GetValue(item, null);
                    ordenDetalle.Proyecto = (string)tipo.GetProperty("PROYECTO").GetValue(item, null);
                    ordenDetalle.EquipoRequerido = (string)tipo.GetProperty("EQUIPO_REQUERIDO").GetValue(item, null);
                    ordenDetalle.EnviarA = (string)tipo.GetProperty("ENVIAR_A").GetValue(item, null);
                    ordenDetalle.CantidadTotal = (int)tipo.GetProperty("CANTIDAD_TOTAL").GetValue(item, null);
                    ordenDetalle.EntregaParcial = (int)tipo.GetProperty("ENTREGA_PARCIAL").GetValue(item, null);
                    ordenDetalle.Requisicion = (string)tipo.GetProperty("REQUISICION").GetValue(item, null);
                    DateTime fechaPedido = Convert.ToDateTime(tipo.GetProperty("FECHA_PEDIDO").GetValue(item, null));
                    ordenDetalle.FechaPedido = fechaPedido.Day + "/" + fechaPedido.Month + "/" + fechaPedido.Year;


                    ordenDetalle.FechaEntrega = (string)tipo.GetProperty("FECHA_ENTREGA").GetValue(item, null);
                    ordenDetalle.OrdenCompra = (string)tipo.GetProperty("ORDEN").GetValue(item, null);

                    Lista.Add(ordenDetalle);

                }
            }

            return Lista;
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

        #region ALERTAS
        public static List<DO_AlertaStock> GetAlertas(int idCompania)
        {
            SO_AlertaStockMin service = new SO_AlertaStockMin();

            List<DO_AlertaStock> Lista = new List<DO_AlertaStock>();

            IList informacionBD = service.GetAlertaStock(idCompania);

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    Type tipo = item.GetType();

                    DO_AlertaStock alerta = new DO_AlertaStock();

                    alerta.Codigo = (string)tipo.GetProperty("CODIGO").GetValue(item, null);
                    alerta.Descripcion = (string)tipo.GetProperty("DESCRIPCION").GetValue(item, null);
                    alerta.StockMin = (int)tipo.GetProperty("STOCK_MIN").GetValue(item, null);
                    alerta.StockMax = (int)tipo.GetProperty("STOCK_MAX").GetValue(item, null);
                    alerta.CantidadEnAlmacen = Convert.ToInt32((decimal)tipo.GetProperty("CANTIDAD_EN_ALMACEN").GetValue(item, null));

                    Lista.Add(alerta);

                }
            }

            return Lista;
        }
        #endregion

        #region Ventas
        public static int InsertVenta(int idUsuario, double monto, DateTime fechaIngreso)
        {
            SO_Venta serviceVenta = new SO_Venta();

            return serviceVenta.Insert(idUsuario, monto, fechaIngreso);
        }

        public static List<DO_ResultMorris> GetVentaDiaria(int idUsuario)
        {
            SO_Venta serviceVenta = new SO_Venta();

            List<DO_ResultMorris> listaResultante = new List<DO_ResultMorris>();

            DataSet informacionBD = serviceVenta.GetVentaDiaria(idUsuario);

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {
                        DO_ResultMorris result = new DO_ResultMorris();
                        DateTime date = Convert.ToDateTime(item["FECHA"]);

                        result.period = date.Day + "/" + date.Month + "/" + date.Year;
                        result.Sales = Convert.ToInt32(item["MONTO"].ToString());

                        listaResultante.Add(result);
                    }
                }
            }

            return listaResultante;
        }

        public static double GetVentaDiaActual(int idUsuario)
        {
            double monto = 0;

            SO_Venta serviceVenta = new SO_Venta();

            DataSet informacionBD = serviceVenta.GetVentaHoy(idUsuario);

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {
                        monto = Convert.ToDouble(item["MONTO_VENTA_DIARIA"].ToString());
                    }
                }
            }

            return monto;
        }

        public static double GetVentaDiaActualOrganizacion(int idOrganizacion)
        {
            double monto = 0;

            SO_Venta serviceVenta = new SO_Venta();

            DataSet informacionBD = serviceVenta.GetVentaHoyOrganizacion(idOrganizacion);

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {
                        monto = Convert.ToDouble(item["MONTO_VENTA_DIARIA"].ToString());
                    }
                }
            }

            return monto;
        }

        public static List<FO_Item> GetVentaSemanalOrganizacionBySemanaByCompania(int idOrganizacion, int idSemana)
        {
            SO_Venta sO_Venta = new SO_Venta();

            DataSet dataSet = sO_Venta.GetVentaOrganizacionXSemanaXCompania(idOrganizacion, idSemana);

            List<FO_Item> items = new List<FO_Item>();

            if (dataSet != null)
            {
                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in dataSet.Tables[0].Rows)
                    {
                        FO_Item fO_Item = new FO_Item();

                        fO_Item.Nombre = item["NOMBRE"].ToString();
                        fO_Item.ValueDouble = Convert.ToDouble(item["MONTO_VENTA_DIARIA"]);

                        items.Add(fO_Item);
                    }
                }
            }

            return items;
        }

        public static double GetVentaMesActual(int idUsuario)
        {
            double monto = 0;

            SO_Venta serviceVenta = new SO_Venta();

            DataSet informacionBD = serviceVenta.GetVentaMesActual(idUsuario);

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {
                        monto = Convert.ToDouble(item["MONTO_VENTA_MENSUAL"].ToString());
                    }
                }
            }

            return monto;
        }

        public static List<FO_Item> GetVentaUltimosMeses(int idUsuario)
        {
            List<FO_Item> lista = new List<FO_Item>();

            SO_Venta serviceVenta = new SO_Venta();

            DataSet informacionBD = serviceVenta.GetVentaUltimosMeses(idUsuario);

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {
                        FO_Item foItem = new FO_Item();

                        foItem.ValueDouble = Convert.ToDouble(item["MONTO"].ToString());
                        foItem.Nombre = item["MESES"].ToString();

                        DateTime fecha = Convert.ToDateTime(item["MESES"].ToString());
                        foItem.ValueDate = fecha;

                        lista.Add(foItem);
                    }
                }
            }

            lista = lista.OrderBy(x => x.ValueDate).ToList();

            foreach (var item in lista)
            {
                int mes = item.ValueDate.Month;
                if (mes == 1)
                {
                    item.Nombre = "Ene-" + item.ValueDate.Year;
                } else if (mes == 2)
                {
                    item.Nombre = "Feb-" + item.ValueDate.Year;
                } else if (mes == 3)
                {
                    item.Nombre = "Mar-" + item.ValueDate.Year;
                }
                else if (mes == 4)
                {
                    item.Nombre = "Abr-" + item.ValueDate.Year;
                }
                else if (mes == 5)
                {
                    item.Nombre = "May-" + item.ValueDate.Year;
                }
                else if (mes == 6)
                {
                    item.Nombre = "Jun-" + item.ValueDate.Year;
                }
                else if (mes == 7)
                {
                    item.Nombre = "Jul-" + item.ValueDate.Year;
                }
                else if (mes == 8)
                {
                    item.Nombre = "Ago-" + item.ValueDate.Year;
                }
                else if (mes == 9)
                {
                    item.Nombre = "Sep-" + item.ValueDate.Year;
                }
                else if (mes == 10)
                {
                    item.Nombre = "Oct-" + item.ValueDate.Year;
                }
                else if (mes == 11)
                {
                    item.Nombre = "Nov-" + item.ValueDate.Year;
                }
                else if (mes == 12)
                {
                    item.Nombre = "Dic-" + item.ValueDate.Year;
                }
            }

            return lista;
        }

        public static int InsertDetailVenta(int idVenta, int idArticulo, int cantidad, double precio)
        {
            SO_Details_Venta sO_Details_Venta = new SO_Details_Venta();

            return sO_Details_Venta.Insert(idVenta, idArticulo, cantidad, precio);
        }

        public static List<DO_Ventas> GetListLastVentas(int idCompania)
        {
            SO_Details_Venta sO_Details_Venta = new SO_Details_Venta();

            IList informacionBD = sO_Details_Venta.GetLastVenta(idCompania);

            List<DO_Ventas> dO_Ventas = new List<DO_Ventas>();

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    Type type = item.GetType();

                    DO_Ventas venta = new DO_Ventas();

                    venta.Nombre = type.GetProperty("DESCRIPCION").GetValue(item, null).ToString();
                    venta.Cantidad = Convert.ToInt32(type.GetProperty("CANTIDAD").GetValue(item, null).ToString());
                    venta.Precio = Convert.ToDouble(type.GetProperty("PRECIO").GetValue(item, null));

                    dO_Ventas.Add(venta);
                }
            }

            return dO_Ventas;
        }

        public static List<DO_Ventas> GetListVentaPorSemana(int idUsuario, int idSemana)
        {
            SO_Venta sO_Details_Venta = new SO_Venta();

            DataSet informacionBD = sO_Details_Venta.GetVentaPorSemana(idUsuario, idSemana);

            List<DO_Ventas> dO_Ventas = new List<DO_Ventas>();

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {
                        DO_Ventas venta = new DO_Ventas();

                        venta.IdArticulo = Convert.ToInt32(item["ID_ARTICULO"]);
                        venta.Nombre = item["DESCRIPCION"].ToString();
                        venta.Cantidad = Convert.ToInt32(item["CANTIDAD"]);
                        venta.Precio = Convert.ToDouble(item["MONTO"]);

                        dO_Ventas.Add(venta);
                    }
                }
            }

            return dO_Ventas;
        }

        public static List<DO_Semana> GetLastSemana(int idSemana, int c)
        {
            List<DO_Semana> semanas = new List<DO_Semana>();

            SO_Semana sO_Semana = new SO_Semana();

            IList informacionBd = sO_Semana.GetLastSemana(idSemana, c);

            if (informacionBd != null)
            {
                foreach (var item in informacionBd)
                {
                    Type type = item.GetType();

                    DO_Semana semana = new DO_Semana();

                    semana.FechaInicial = Convert.ToDateTime(type.GetProperty("DIA_INICIAL").GetValue(item, null));
                    semana.FechaFinal = Convert.ToDateTime(type.GetProperty("DIA_FINAL").GetValue(item, null));
                    semana.NoSemana = Convert.ToInt32(type.GetProperty("NO_SEMANA").GetValue(item, null));

                    semanas.Add(semana);
                }
            }

            return semanas;
        }

        public static DO_ChartData GetLastFiveWeekSalesPromotor(int idPromotor, int idSemana)
        {
            #region Configuración colores

            List<string> backGroundColors = new List<string>();
            backGroundColors.Add("#56d798");
            backGroundColors.Add("#ff8397");
            backGroundColors.Add("#6970d5");
            backGroundColors.Add("#6970d5");
            backGroundColors.Add("#24BF99");
            backGroundColors.Add("#15715B");
            backGroundColors.Add("#15713F");
            backGroundColors.Add("#3BC279");
            backGroundColors.Add("#217BB2");
            backGroundColors.Add("#316ACD");
            backGroundColors.Add("#8230CB");
            backGroundColors.Add("#f38b4a");

            List<string> borderColors = new List<string>();
            borderColors.Add("rgba(54, 162, 235, 1)");
            borderColors.Add("rgba(255, 206, 86, 1)");
            borderColors.Add("rgba(75, 192, 192, 1)");
            borderColors.Add("rgba(153, 102, 255, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            #endregion

            DO_ChartData dO_ChartData = new DO_ChartData();

            List<DO_Semana> semanas = DataManager.GetLastSemana(idSemana, 5);

            dO_ChartData.labels = new List<string>();
            semanas.Reverse();

            foreach (var semana in semanas)
            {
                dO_ChartData.labels.Add("Semana #" + semana.NoSemana);
            }

            //dO_ChartData.labels.Add("Semana 5");
            //dO_ChartData.labels.Add("Semana 4");
            //dO_ChartData.labels.Add("Semana 3");
            //dO_ChartData.labels.Add("Semana 2");
            //dO_ChartData.labels.Add("Semana 1");
            dO_ChartData.datasets = new List<DataSetChart>();

            SO_Venta sO_Venta = new SO_Venta();

            DataSet informacionBD = sO_Venta.GetVentaPromotorLastFiveWeek(idPromotor, idSemana);

            if (informacionBD != null)
            {
                DataSetChart dataSetChart1 = new DataSetChart();
                dataSetChart1.label = "Venta total";
                dataSetChart1.data = new List<double>();
                dataSetChart1.backgroundColor = backGroundColors[9];
                dataSetChart1.borderColor = borderColors[9];
                dataSetChart1.type = "line";
                dataSetChart1.fill = false;


                if (informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {
                        dataSetChart1.data.Add(Convert.ToDouble(item["TOTAL"]));
                    }
                }
                else
                {
                    dataSetChart1.data.Add(0);
                }

                if (informacionBD.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[1].Rows)
                    {
                        dataSetChart1.data.Add(Convert.ToDouble(item["TOTAL"]));
                    }
                }
                else
                {
                    dataSetChart1.data.Add(0);
                }

                if (informacionBD.Tables[2].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[2].Rows)
                    {
                        dataSetChart1.data.Add(Convert.ToDouble(item["TOTAL"]));
                    }
                }
                else
                {
                    dataSetChart1.data.Add(0);
                }

                if (informacionBD.Tables[3].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[3].Rows)
                    {
                        dataSetChart1.data.Add(Convert.ToDouble(item["TOTAL"]));
                    }
                }
                else
                {
                    dataSetChart1.data.Add(0);
                }

                if (informacionBD.Tables[4].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[4].Rows)
                    {
                        dataSetChart1.data.Add(Convert.ToDouble(item["TOTAL"]));
                    }
                }
                else
                {
                    dataSetChart1.data.Add(0);
                }

                dO_ChartData.datasets.Add(dataSetChart1);
            }

            return dO_ChartData;
        }

        public static DO_ChartData GetVentaSemanalDiariaPromotor(int idCompania, int idPromotor, int idSemana)
        {
            List<DO_Articulo> articulos = DataManager.GetAllArticulos(idCompania);

            SO_Venta serviceVenta = new SO_Venta();

            #region Configuración colores
            DO_ChartData dO_ChartData = new DO_ChartData();
            dO_ChartData.labels = new List<string>();
            dO_ChartData.labels.Add("Lunes");
            dO_ChartData.labels.Add("Martes");
            dO_ChartData.labels.Add("Miercoles");
            dO_ChartData.labels.Add("Jueves");
            dO_ChartData.labels.Add("Viernes");
            dO_ChartData.labels.Add("Sabado");
            dO_ChartData.labels.Add("Domingo");
            dO_ChartData.datasets = new List<DataSetChart>();

            List<string> backGroundColors = new List<string>();
            backGroundColors.Add("#56d798");
            backGroundColors.Add("#ff8397");
            backGroundColors.Add("#6970d5");
            backGroundColors.Add("#6970d5");
            backGroundColors.Add("#24BF99");
            backGroundColors.Add("#15715B");
            backGroundColors.Add("#15713F");
            backGroundColors.Add("#3BC279");
            backGroundColors.Add("#217BB2");
            backGroundColors.Add("#316ACD");
            backGroundColors.Add("#8230CB");
            backGroundColors.Add("#f38b4a");

            List<string> borderColors = new List<string>();
            borderColors.Add("rgba(54, 162, 235, 1)");
            borderColors.Add("rgba(255, 206, 86, 1)");
            borderColors.Add("rgba(75, 192, 192, 1)");
            borderColors.Add("rgba(153, 102, 255, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            #endregion

            int f = 0;

            double[] totales = new double[7];

            foreach (var articulo in articulos)
            {
                DataSetChart dataSetChart = new DataSetChart();

                dataSetChart.label = articulo.Descripcion;
                dataSetChart.data = new List<double>();
                dataSetChart.cantidad = new List<int>();
                dataSetChart.backgroundColor = backGroundColors[f];
                dataSetChart.borderColor = borderColors[f];
                dataSetChart.type = "bar";


                DataSet dataSet = serviceVenta.GetVentaSemanalDiariaPromotor(articulo.idArticulo, idPromotor, idSemana);

                if (dataSet != null)
                {
                    if (dataSet.Tables.Count > 0)
                    {
                        if (dataSet.Tables[0].Rows.Count == 0)
                        {
                            dataSetChart.data.Add(0);
                            dataSetChart.cantidad.Add(0);
                        }
                        else
                        {
                            double monto = 0;
                            foreach (DataRow item in dataSet.Tables[0].Rows)
                            {
                                monto = Convert.ToDouble(item["PRECIO"]);
                                dataSetChart.cantidad.Add(Convert.ToInt32(item["CANTIDAD"]));
                            }
                            totales[0] += monto;
                            dataSetChart.data.Add(monto);

                        }

                        if (dataSet.Tables[1].Rows.Count == 0)
                        {
                            dataSetChart.data.Add(0);
                            dataSetChart.cantidad.Add(0);
                        }
                        else
                        {
                            double monto = 0;
                            foreach (DataRow item in dataSet.Tables[1].Rows)
                            {
                                monto = Convert.ToDouble(item["PRECIO"]);
                                dataSetChart.cantidad.Add(Convert.ToInt32(item["CANTIDAD"]));
                            }
                            totales[1] += monto;
                            dataSetChart.data.Add(monto);
                        }

                        if (dataSet.Tables[2].Rows.Count == 0)
                        {
                            dataSetChart.data.Add(0);
                            dataSetChart.cantidad.Add(0);
                        }
                        else
                        {
                            double monto = 0;
                            foreach (DataRow item in dataSet.Tables[2].Rows)
                            {
                                monto = Convert.ToDouble(item["PRECIO"]);
                                dataSetChart.cantidad.Add(Convert.ToInt32(item["CANTIDAD"]));
                            }
                            totales[2] += monto;
                            dataSetChart.data.Add(monto);
                        }

                        if (dataSet.Tables[3].Rows.Count == 0)
                        {
                            dataSetChart.data.Add(0);
                            dataSetChart.cantidad.Add(0);
                        }
                        else
                        {
                            double monto = 0;
                            foreach (DataRow item in dataSet.Tables[3].Rows)
                            {
                                monto = Convert.ToDouble(item["PRECIO"]);
                                dataSetChart.cantidad.Add(Convert.ToInt32(item["CANTIDAD"]));
                            }
                            totales[3] += monto;
                            dataSetChart.data.Add(monto);
                        }

                        if (dataSet.Tables[4].Rows.Count == 0)
                        {
                            dataSetChart.data.Add(0);
                            dataSetChart.cantidad.Add(0);
                        }
                        else
                        {
                            double monto = 0;
                            foreach (DataRow item in dataSet.Tables[4].Rows)
                            {
                                monto = Convert.ToDouble(item["PRECIO"]);
                                dataSetChart.cantidad.Add(Convert.ToInt32(item["CANTIDAD"]));
                            }
                            totales[4] += monto;
                            dataSetChart.data.Add(monto);
                        }

                        if (dataSet.Tables[5].Rows.Count == 0)
                        {
                            dataSetChart.data.Add(0);
                            dataSetChart.cantidad.Add(0);
                        }
                        else
                        {
                            double monto = 0;
                            foreach (DataRow item in dataSet.Tables[5].Rows)
                            {
                                monto = Convert.ToDouble(item["PRECIO"]);
                                dataSetChart.cantidad.Add(Convert.ToInt32(item["CANTIDAD"]));
                            }
                            totales[5] += monto;
                            dataSetChart.data.Add(monto);
                        }

                        if (dataSet.Tables[6].Rows.Count == 0)
                        {
                            dataSetChart.data.Add(0);
                            dataSetChart.cantidad.Add(0);
                        }
                        else
                        {
                            double monto = 0;
                            foreach (DataRow item in dataSet.Tables[6].Rows)
                            {
                                monto = Convert.ToDouble(item["PRECIO"]);
                                dataSetChart.cantidad.Add(Convert.ToInt32(item["CANTIDAD"]));
                            }
                            totales[6] += monto;
                            dataSetChart.data.Add(monto);
                        }
                    }
                }
                dO_ChartData.datasets.Add(dataSetChart);
                f++;
            }

            DataSetChart dataSetChart1 = new DataSetChart();
            dataSetChart1.label = "Venta total";
            dataSetChart1.data = new List<double>();
            dataSetChart1.backgroundColor = backGroundColors[9];
            dataSetChart1.borderColor = borderColors[9];
            dataSetChart1.type = "line";
            dataSetChart1.fill = false;

            dataSetChart1.data.Add(totales[0]);
            dataSetChart1.data.Add(totales[1]);
            dataSetChart1.data.Add(totales[2]);
            dataSetChart1.data.Add(totales[3]);
            dataSetChart1.data.Add(totales[4]);
            dataSetChart1.data.Add(totales[5]);
            dataSetChart1.data.Add(totales[6]);

            dO_ChartData.datasets.Add(dataSetChart1);

            return dO_ChartData;
        }

        public static DO_ChartData GetVentaSemanalDiaria(int idCompania, int idSemana)
        {
            List<DO_Articulo> articulos = GetAllArticulos(idCompania);
            SO_Venta serviceVenta = new SO_Venta();

            #region Configuracion Colores
            DO_ChartData dO_ChartData = new DO_ChartData();
            dO_ChartData.labels = new List<string>();
            dO_ChartData.labels.Add("Lunes");
            dO_ChartData.labels.Add("Martes");
            dO_ChartData.labels.Add("Miercoles");
            dO_ChartData.labels.Add("Jueves");
            dO_ChartData.labels.Add("Viernes");
            dO_ChartData.labels.Add("Sabado");
            dO_ChartData.labels.Add("Domingo");
            dO_ChartData.datasets = new List<DataSetChart>();

            List<string> backGroundColors = new List<string>();
            backGroundColors.Add("#56d798");
            backGroundColors.Add("#ff8397");
            backGroundColors.Add("#6970d5");
            backGroundColors.Add("#6970d5");
            backGroundColors.Add("#24BF99");
            backGroundColors.Add("#15715B");
            backGroundColors.Add("#15713F");
            backGroundColors.Add("#3BC279");
            backGroundColors.Add("#217BB2");
            backGroundColors.Add("#316ACD");
            backGroundColors.Add("#8230CB");
            backGroundColors.Add("#f38b4a");
            backGroundColors.Add("#f40b4a");
            backGroundColors.Add("#f41c4a");
            backGroundColors.Add("#f42d4a");
            backGroundColors.Add("#f43e4a");
            backGroundColors.Add("#f44f4a");
            backGroundColors.Add("#f45g4a");
            backGroundColors.Add("#f46h4a");
            backGroundColors.Add("#f49i4a");
            backGroundColors.Add("#5FD08E");
            backGroundColors.Add("#7B3483");
            backGroundColors.Add("#CEB9F6");
            backGroundColors.Add("#A4D6F1");
            backGroundColors.Add("#00B196");
            backGroundColors.Add("#5C8C3C");
            backGroundColors.Add("#32A937");
            backGroundColors.Add("#8E83DC");
            backGroundColors.Add("#EA5E81");
            backGroundColors.Add("#C07B7D");
            backGroundColors.Add("#1C56222");
            backGroundColors.Add("#F2731D");
            backGroundColors.Add("#4E4DC3");
            backGroundColors.Add("#AA2868");
            backGroundColors.Add("#804563");
            backGroundColors.Add("#DC2009");
            backGroundColors.Add("#37FAAE");
            backGroundColors.Add("#0E17A9");
            backGroundColors.Add("#69F24F");
            backGroundColors.Add("#400F4A");
            backGroundColors.Add("#9BE9EF");
            backGroundColors.Add("#F7C495");
            backGroundColors.Add("#CDE190");
            backGroundColors.Add("#29BC35");
            backGroundColors.Add("#8596DA");
            backGroundColors.Add("#5BB3D6");
            backGroundColors.Add("#B78E7B");
            backGroundColors.Add("#8DAB76");
            backGroundColors.Add("#E9861C");
            backGroundColors.Add("#4560C1");
            backGroundColors.Add("#1B7DBC");
            backGroundColors.Add("#775862");
            backGroundColors.Add("#D33307");
            backGroundColors.Add("#A95002");
            backGroundColors.Add("#052AA8");
            backGroundColors.Add("#DB47A3");
            backGroundColors.Add("#372248");
            backGroundColors.Add("#92FCEE");
            backGroundColors.Add("#6919E9");
            backGroundColors.Add("#C4F48E");
            backGroundColors.Add("#20CF34");
            backGroundColors.Add("#F6EC2F");
            backGroundColors.Add("#52C6D4");
            backGroundColors.Add("#28E3CF");
            backGroundColors.Add("#84BE75");
            backGroundColors.Add("#E0991A");
            backGroundColors.Add("#B6B615");
            backGroundColors.Add("#1290BB");
            backGroundColors.Add("#6E6B60");
            backGroundColors.Add("#44885B");
            backGroundColors.Add("#A06301");
            backGroundColors.Add("#767FFC");
            backGroundColors.Add("#D25AA1");
            backGroundColors.Add("#2E3547");
            backGroundColors.Add("#045242");
            backGroundColors.Add("#602CE7");
            backGroundColors.Add("#BC078D");
            backGroundColors.Add("#922488");
            backGroundColors.Add("#EDFF2D");
            backGroundColors.Add("#C41C28");
            backGroundColors.Add("#1FF6CE");
            backGroundColors.Add("#7BD173");
            backGroundColors.Add("#51EE6E");
            backGroundColors.Add("#ADC914");
            backGroundColors.Add("#09A3B9");
            backGroundColors.Add("#DFC0B4");
            backGroundColors.Add("#3B9B5A");
            backGroundColors.Add("#11B855");
            backGroundColors.Add("#6D92FA");
            backGroundColors.Add("#C96DA0");
            backGroundColors.Add("#9F8A9B");
            backGroundColors.Add("#FB6540");
            backGroundColors.Add("#573FE6");
            backGroundColors.Add("#2D5CE1");
            backGroundColors.Add("#893786");
            backGroundColors.Add("#5F5481");
            backGroundColors.Add("#BB2F27");
            backGroundColors.Add("#1709CC");
            backGroundColors.Add("#ED26C7");
            backGroundColors.Add("#49016D");
            backGroundColors.Add("#A4DC12");
            backGroundColors.Add("#7AF90D");
            backGroundColors.Add("#D6D3B3");
            backGroundColors.Add("#ACF0AE");
            backGroundColors.Add("#08CB53");
            backGroundColors.Add("#64A5F9");
            backGroundColors.Add("#3AC2F4");
            backGroundColors.Add("#969D99");
            backGroundColors.Add("#F2783F");
            backGroundColors.Add("#C8953A");
            backGroundColors.Add("#246FDF");
            backGroundColors.Add("#FA8CDA");
            backGroundColors.Add("#566780");
            backGroundColors.Add("#B24225");
            backGroundColors.Add("#885F20");
            backGroundColors.Add("#E439C6");
            backGroundColors.Add("#40146B");
            backGroundColors.Add("#163166");
            backGroundColors.Add("#720C0C");
            backGroundColors.Add("#482907");


            List<string> borderColors = new List<string>();
            borderColors.Add("rgba(54, 162, 235, 1)");
            borderColors.Add("rgba(255, 206, 86, 1)");
            borderColors.Add("rgba(75, 192, 192, 1)");
            borderColors.Add("rgba(153, 102, 255, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");

            #endregion

            int f = 0;

            double[] totales = new double[7];

            foreach (var articulo in articulos)
            {
                DataSetChart dataSetChart = new DataSetChart();

                dataSetChart.label = articulo.Descripcion;
                dataSetChart.data = new List<double>();
                dataSetChart.cantidad = new List<int>();
                dataSetChart.backgroundColor = backGroundColors[f];
                dataSetChart.borderColor = borderColors[f];
                dataSetChart.type = "bar";


                DataSet dataSet = serviceVenta.GetVentaSemanalDiaria(articulo.idArticulo, idSemana);

                if (dataSet != null)
                {
                    if (dataSet.Tables.Count > 0)
                    {
                        if (dataSet.Tables[0].Rows.Count == 0)
                        {
                            dataSetChart.data.Add(0);
                            dataSetChart.cantidad.Add(0);
                        }
                        else
                        {
                            double monto = 0;
                            foreach (DataRow item in dataSet.Tables[0].Rows)
                            {
                                monto = Convert.ToDouble(item["PRECIO"]);
                                dataSetChart.cantidad.Add(Convert.ToInt32(item["CANTIDAD"]));
                            }
                            totales[0] += monto;
                            dataSetChart.data.Add(monto);

                        }

                        if (dataSet.Tables[1].Rows.Count == 0)
                        {
                            dataSetChart.data.Add(0);
                            dataSetChart.cantidad.Add(0);
                        }
                        else
                        {
                            double monto = 0;
                            foreach (DataRow item in dataSet.Tables[1].Rows)
                            {
                                monto = Convert.ToDouble(item["PRECIO"]);
                                dataSetChart.cantidad.Add(Convert.ToInt32(item["CANTIDAD"]));
                            }
                            totales[1] += monto;
                            dataSetChart.data.Add(monto);
                        }

                        if (dataSet.Tables[2].Rows.Count == 0)
                        {
                            dataSetChart.data.Add(0);
                            dataSetChart.cantidad.Add(0);
                        }
                        else
                        {
                            double monto = 0;
                            foreach (DataRow item in dataSet.Tables[2].Rows)
                            {
                                monto = Convert.ToDouble(item["PRECIO"]);
                                dataSetChart.cantidad.Add(Convert.ToInt32(item["CANTIDAD"]));
                            }
                            totales[2] += monto;
                            dataSetChart.data.Add(monto);
                        }

                        if (dataSet.Tables[3].Rows.Count == 0)
                        {
                            dataSetChart.data.Add(0);
                            dataSetChart.cantidad.Add(0);
                        }
                        else
                        {
                            double monto = 0;
                            foreach (DataRow item in dataSet.Tables[3].Rows)
                            {
                                monto = Convert.ToDouble(item["PRECIO"]);
                                dataSetChart.cantidad.Add(Convert.ToInt32(item["CANTIDAD"]));
                            }
                            totales[3] += monto;
                            dataSetChart.data.Add(monto);
                        }

                        if (dataSet.Tables[4].Rows.Count == 0)
                        {
                            dataSetChart.data.Add(0);
                            dataSetChart.cantidad.Add(0);
                        }
                        else
                        {
                            double monto = 0;
                            foreach (DataRow item in dataSet.Tables[4].Rows)
                            {
                                monto = Convert.ToDouble(item["PRECIO"]);
                                dataSetChart.cantidad.Add(Convert.ToInt32(item["CANTIDAD"]));
                            }
                            totales[4] += monto;
                            dataSetChart.data.Add(monto);
                        }

                        if (dataSet.Tables[5].Rows.Count == 0)
                        {
                            dataSetChart.data.Add(0);
                            dataSetChart.cantidad.Add(0);
                        }
                        else
                        {
                            double monto = 0;
                            foreach (DataRow item in dataSet.Tables[5].Rows)
                            {
                                monto = Convert.ToDouble(item["PRECIO"]);
                                dataSetChart.cantidad.Add(Convert.ToInt32(item["CANTIDAD"]));
                            }
                            totales[5] += monto;
                            dataSetChart.data.Add(monto);
                        }

                        if (dataSet.Tables[6].Rows.Count == 0)
                        {
                            dataSetChart.data.Add(0);
                            dataSetChart.cantidad.Add(0);
                        }
                        else
                        {
                            double monto = 0;
                            foreach (DataRow item in dataSet.Tables[6].Rows)
                            {
                                monto = Convert.ToDouble(item["PRECIO"]);
                                dataSetChart.cantidad.Add(Convert.ToInt32(item["CANTIDAD"]));
                            }
                            totales[6] += monto;
                            dataSetChart.data.Add(monto);
                        }
                    }
                }
                dO_ChartData.datasets.Add(dataSetChart);
                f++;
            }

            DataSetChart dataSetChart1 = new DataSetChart();
            dataSetChart1.label = "Venta total";
            dataSetChart1.data = new List<double>();
            dataSetChart1.backgroundColor = backGroundColors[9];
            dataSetChart1.borderColor = borderColors[9];
            dataSetChart1.type = "line";
            dataSetChart1.fill = false;

            dataSetChart1.data.Add(totales[0]);
            dataSetChart1.data.Add(totales[1]);
            dataSetChart1.data.Add(totales[2]);
            dataSetChart1.data.Add(totales[3]);
            dataSetChart1.data.Add(totales[4]);
            dataSetChart1.data.Add(totales[5]);
            dataSetChart1.data.Add(totales[6]);

            dO_ChartData.datasets.Add(dataSetChart1);

            return dO_ChartData;
        }

        public static DO_ChartData GetVentaSemanalDiaria(int idCompania)
        {
            List<DO_Articulo> articulos = GetAllArticulos(idCompania);
            SO_Venta serviceVenta = new SO_Venta();

            #region Configuracion Colores
            DO_ChartData dO_ChartData = new DO_ChartData();
            dO_ChartData.labels = new List<string>();
            dO_ChartData.labels.Add("Lunes");
            dO_ChartData.labels.Add("Martes");
            dO_ChartData.labels.Add("Miercoles");
            dO_ChartData.labels.Add("Jueves");
            dO_ChartData.labels.Add("Viernes");
            dO_ChartData.labels.Add("Sabado");
            dO_ChartData.labels.Add("Domingo");
            dO_ChartData.datasets = new List<DataSetChart>();

            List<string> backGroundColors = new List<string>();
            backGroundColors.Add("#56d798");
            backGroundColors.Add("#ff8397");
            backGroundColors.Add("#6970d5");
            backGroundColors.Add("#6970d5");
            backGroundColors.Add("#24BF99");
            backGroundColors.Add("#15715B");
            backGroundColors.Add("#15713F");
            backGroundColors.Add("#3BC279");
            backGroundColors.Add("#217BB2");
            backGroundColors.Add("#316ACD");
            backGroundColors.Add("#8230CB");
            backGroundColors.Add("#f38b4a");
            backGroundColors.Add("#f40b4a");
            backGroundColors.Add("#f41c4a");
            backGroundColors.Add("#f42d4a");
            backGroundColors.Add("#f43e4a");
            backGroundColors.Add("#f44f4a");
            backGroundColors.Add("#f45g4a");
            backGroundColors.Add("#f46h4a");
            backGroundColors.Add("#f49i4a");
            backGroundColors.Add("#5FD08E");
            backGroundColors.Add("#7B3483");
            backGroundColors.Add("#CEB9F6");
            backGroundColors.Add("#A4D6F1");
            backGroundColors.Add("#00B196");
            backGroundColors.Add("#5C8C3C");
            backGroundColors.Add("#32A937");
            backGroundColors.Add("#8E83DC");
            backGroundColors.Add("#EA5E81");
            backGroundColors.Add("#C07B7D");
            backGroundColors.Add("#1C56222");
            backGroundColors.Add("#F2731D");
            backGroundColors.Add("#4E4DC3");
            backGroundColors.Add("#AA2868");
            backGroundColors.Add("#804563");
            backGroundColors.Add("#DC2009");
            backGroundColors.Add("#37FAAE");
            backGroundColors.Add("#0E17A9");
            backGroundColors.Add("#69F24F");
            backGroundColors.Add("#400F4A");
            backGroundColors.Add("#9BE9EF");
            backGroundColors.Add("#F7C495");
            backGroundColors.Add("#CDE190");
            backGroundColors.Add("#29BC35");
            backGroundColors.Add("#8596DA");
            backGroundColors.Add("#5BB3D6");
            backGroundColors.Add("#B78E7B");
            backGroundColors.Add("#8DAB76");
            backGroundColors.Add("#E9861C");
            backGroundColors.Add("#4560C1");
            backGroundColors.Add("#1B7DBC");
            backGroundColors.Add("#775862");
            backGroundColors.Add("#D33307");
            backGroundColors.Add("#A95002");
            backGroundColors.Add("#052AA8");
            backGroundColors.Add("#DB47A3");
            backGroundColors.Add("#372248");
            backGroundColors.Add("#92FCEE");
            backGroundColors.Add("#6919E9");
            backGroundColors.Add("#C4F48E");
            backGroundColors.Add("#20CF34");
            backGroundColors.Add("#F6EC2F");
            backGroundColors.Add("#52C6D4");
            backGroundColors.Add("#28E3CF");
            backGroundColors.Add("#84BE75");
            backGroundColors.Add("#E0991A");
            backGroundColors.Add("#B6B615");
            backGroundColors.Add("#1290BB");
            backGroundColors.Add("#6E6B60");
            backGroundColors.Add("#44885B");
            backGroundColors.Add("#A06301");
            backGroundColors.Add("#767FFC");
            backGroundColors.Add("#D25AA1");
            backGroundColors.Add("#2E3547");
            backGroundColors.Add("#045242");
            backGroundColors.Add("#602CE7");
            backGroundColors.Add("#BC078D");
            backGroundColors.Add("#922488");
            backGroundColors.Add("#EDFF2D");
            backGroundColors.Add("#C41C28");
            backGroundColors.Add("#1FF6CE");
            backGroundColors.Add("#7BD173");
            backGroundColors.Add("#51EE6E");
            backGroundColors.Add("#ADC914");
            backGroundColors.Add("#09A3B9");
            backGroundColors.Add("#DFC0B4");
            backGroundColors.Add("#3B9B5A");
            backGroundColors.Add("#11B855");
            backGroundColors.Add("#6D92FA");
            backGroundColors.Add("#C96DA0");
            backGroundColors.Add("#9F8A9B");
            backGroundColors.Add("#FB6540");
            backGroundColors.Add("#573FE6");
            backGroundColors.Add("#2D5CE1");
            backGroundColors.Add("#893786");
            backGroundColors.Add("#5F5481");
            backGroundColors.Add("#BB2F27");
            backGroundColors.Add("#1709CC");
            backGroundColors.Add("#ED26C7");
            backGroundColors.Add("#49016D");
            backGroundColors.Add("#A4DC12");
            backGroundColors.Add("#7AF90D");
            backGroundColors.Add("#D6D3B3");
            backGroundColors.Add("#ACF0AE");
            backGroundColors.Add("#08CB53");
            backGroundColors.Add("#64A5F9");
            backGroundColors.Add("#3AC2F4");
            backGroundColors.Add("#969D99");
            backGroundColors.Add("#F2783F");
            backGroundColors.Add("#C8953A");
            backGroundColors.Add("#246FDF");
            backGroundColors.Add("#FA8CDA");
            backGroundColors.Add("#566780");
            backGroundColors.Add("#B24225");
            backGroundColors.Add("#885F20");
            backGroundColors.Add("#E439C6");
            backGroundColors.Add("#40146B");
            backGroundColors.Add("#163166");
            backGroundColors.Add("#720C0C");
            backGroundColors.Add("#482907");


            List<string> borderColors = new List<string>();
            borderColors.Add("rgba(54, 162, 235, 1)");
            borderColors.Add("rgba(255, 206, 86, 1)");
            borderColors.Add("rgba(75, 192, 192, 1)");
            borderColors.Add("rgba(153, 102, 255, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            #endregion

            int f = 0;

            double[] totales = new double[7];

            foreach (var articulo in articulos)
            {
                DataSetChart dataSetChart = new DataSetChart();

                dataSetChart.label = articulo.Descripcion;
                dataSetChart.data = new List<double>();
                dataSetChart.cantidad = new List<int>();
                dataSetChart.backgroundColor = backGroundColors[f];
                dataSetChart.borderColor = borderColors[f];
                dataSetChart.type = "bar";


                DataSet dataSet = serviceVenta.GetVentaSemanalDiaria(articulo.idArticulo);

                if (dataSet != null)
                {
                    if (dataSet.Tables.Count > 0)
                    {
                        if (dataSet.Tables[0].Rows.Count == 0)
                        {
                            dataSetChart.data.Add(0);
                            dataSetChart.cantidad.Add(0);
                        }
                        else
                        {
                            double monto = 0;
                            foreach (DataRow item in dataSet.Tables[0].Rows)
                            {
                                monto = Convert.ToDouble(item["PRECIO"]);
                                dataSetChart.cantidad.Add(Convert.ToInt32(item["CANTIDAD"]));
                            }
                            totales[0] += monto;
                            dataSetChart.data.Add(monto);

                        }

                        if (dataSet.Tables[1].Rows.Count == 0)
                        {
                            dataSetChart.data.Add(0);
                            dataSetChart.cantidad.Add(0);
                        }
                        else
                        {
                            double monto = 0;
                            foreach (DataRow item in dataSet.Tables[1].Rows)
                            {
                                monto = Convert.ToDouble(item["PRECIO"]);
                                dataSetChart.cantidad.Add(Convert.ToInt32(item["CANTIDAD"]));
                            }
                            totales[1] += monto;
                            dataSetChart.data.Add(monto);
                        }

                        if (dataSet.Tables[2].Rows.Count == 0)
                        {
                            dataSetChart.data.Add(0);
                            dataSetChart.cantidad.Add(0);
                        }
                        else
                        {
                            double monto = 0;
                            foreach (DataRow item in dataSet.Tables[2].Rows)
                            {
                                monto = Convert.ToDouble(item["PRECIO"]);
                                dataSetChart.cantidad.Add(Convert.ToInt32(item["CANTIDAD"]));
                            }
                            totales[2] += monto;
                            dataSetChart.data.Add(monto);
                        }

                        if (dataSet.Tables[3].Rows.Count == 0)
                        {
                            dataSetChart.data.Add(0);
                            dataSetChart.cantidad.Add(0);
                        }
                        else
                        {
                            double monto = 0;
                            foreach (DataRow item in dataSet.Tables[3].Rows)
                            {
                                monto = Convert.ToDouble(item["PRECIO"]);
                                dataSetChart.cantidad.Add(Convert.ToInt32(item["CANTIDAD"]));
                            }
                            totales[3] += monto;
                            dataSetChart.data.Add(monto);
                        }

                        if (dataSet.Tables[4].Rows.Count == 0)
                        {
                            dataSetChart.data.Add(0);
                            dataSetChart.cantidad.Add(0);
                        }
                        else
                        {
                            double monto = 0;
                            foreach (DataRow item in dataSet.Tables[4].Rows)
                            {
                                monto = Convert.ToDouble(item["PRECIO"]);
                                dataSetChart.cantidad.Add(Convert.ToInt32(item["CANTIDAD"]));
                            }
                            totales[4] += monto;
                            dataSetChart.data.Add(monto);
                        }

                        if (dataSet.Tables[5].Rows.Count == 0)
                        {
                            dataSetChart.data.Add(0);
                            dataSetChart.cantidad.Add(0);
                        }
                        else
                        {
                            double monto = 0;
                            foreach (DataRow item in dataSet.Tables[5].Rows)
                            {
                                monto = Convert.ToDouble(item["PRECIO"]);
                                dataSetChart.cantidad.Add(Convert.ToInt32(item["CANTIDAD"]));
                            }
                            totales[5] += monto;
                            dataSetChart.data.Add(monto);
                        }

                        if (dataSet.Tables[6].Rows.Count == 0)
                        {
                            dataSetChart.data.Add(0);
                            dataSetChart.cantidad.Add(0);
                        }
                        else
                        {
                            double monto = 0;
                            foreach (DataRow item in dataSet.Tables[6].Rows)
                            {
                                monto = Convert.ToDouble(item["PRECIO"]);
                                dataSetChart.cantidad.Add(Convert.ToInt32(item["CANTIDAD"]));
                            }
                            totales[6] += monto;
                            dataSetChart.data.Add(monto);
                        }
                    }
                }
                dO_ChartData.datasets.Add(dataSetChart);
                f++;
            }

            DataSetChart dataSetChart1 = new DataSetChart();
            dataSetChart1.label = "Venta total";
            dataSetChart1.data = new List<double>();
            dataSetChart1.backgroundColor = backGroundColors[9];
            dataSetChart1.borderColor = borderColors[9];
            dataSetChart1.type = "line";
            dataSetChart1.fill = false;

            dataSetChart1.data.Add(totales[0]);
            dataSetChart1.data.Add(totales[1]);
            dataSetChart1.data.Add(totales[2]);
            dataSetChart1.data.Add(totales[3]);
            dataSetChart1.data.Add(totales[4]);
            dataSetChart1.data.Add(totales[5]);
            dataSetChart1.data.Add(totales[6]);

            dO_ChartData.datasets.Add(dataSetChart1);

            return dO_ChartData;
        }

        public static int InsertVentaPromotor(int idVenta, int idPromotor)
        {
            SO_Venta sO_Venta = new SO_Venta();

            return sO_Venta.InsertVentaPromotor(idVenta, idPromotor);
        }

        public static int DeleteVentaPromotor(int idVenta)
        {
            SO_Venta sO_Venta = new SO_Venta();

            return sO_Venta.DeleteVentaPromotor(idVenta);
        }

        public static int DeleteVentaDetails(int idVenta)
        {
            SO_Venta sO_Venta = new SO_Venta();

            return sO_Venta.DeleteVentaDetails(idVenta);
        }

        public static int DeleteVenta(int idVenta)
        {
            SO_Venta sO_Venta = new SO_Venta();

            return sO_Venta.DeleteVenta(idVenta);
        }

        public static int AddExistencia(int idAlmacen, int idArticulo, double cantidad)
        {
            SO_Existencia sO_Existencia = new SO_Existencia();

            return sO_Existencia.AddCantidad(idAlmacen, idArticulo, Convert.ToDecimal(cantidad));
        }

        public static DO_ChartData GetVentaSemanalDiariaByPromotor(int idUsuarioGerente)
        {
            List<string> backGroundColors = new List<string>();
            backGroundColors.Add("#56d798");
            backGroundColors.Add("#ff8397");
            backGroundColors.Add("#6970d5");
            backGroundColors.Add("#6970d5");
            backGroundColors.Add("#24BF99");
            backGroundColors.Add("#15715B");
            backGroundColors.Add("#15713F");
            backGroundColors.Add("#3BC279");
            backGroundColors.Add("#217BB2");
            backGroundColors.Add("#316ACD");
            backGroundColors.Add("#8230CB");
            backGroundColors.Add("#f38b4a");

            List<string> borderColors = new List<string>();
            borderColors.Add("rgba(54, 162, 235, 1)");
            borderColors.Add("rgba(255, 206, 86, 1)");
            borderColors.Add("rgba(75, 192, 192, 1)");
            borderColors.Add("rgba(153, 102, 255, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");
            borderColors.Add("rgba(255, 159, 64, 1)");

            DO_ChartData venta = new DO_ChartData();
            venta.labels = new List<string>();
            DataSetChart dataSetChart = new DataSetChart();
            dataSetChart.data = new List<double>();
            dataSetChart.backgroundColor = backGroundColors[9];
            dataSetChart.borderColor = borderColors[9];

            SO_Venta serviceVentas = new SO_Venta();

            DataSet informacionBD = serviceVentas.GetVentaSenamalDiariaByPromotor(idUsuarioGerente);

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {

                        venta.labels.Add(Convert.ToString(item["NOMBRE_PROMOTOR"]));


                        double monto = Convert.ToDouble(item["MONTO_TOTAL"]);
                        dataSetChart.label = "Ganancia";
                        dataSetChart.data.Add(monto);
                        venta.datasets = new List<DataSetChart>();
                        venta.datasets.Add(dataSetChart);

                    }
                }
            }

            return venta;
        }

        public static List<DO_Ventas> GetVentasPromotor(int idPromotor, int idSemana)
        {
            SO_Venta sO_Venta = new SO_Venta();

            DataSet informacionBD = sO_Venta.GetVentaSemanalPromotor(idPromotor, idSemana);

            List<DO_Ventas> ventas = new List<DO_Ventas>();

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {
                        DO_Ventas venta = new DO_Ventas();

                        venta.Cantidad = Convert.ToInt32(item["CANTIDAD"]);
                        venta.Precio = Convert.ToDouble(item["PRECIO"]);
                        venta.Nombre = Convert.ToString(item["DESCRIPCION"]);
                        DateTime fecha = Convert.ToDateTime(item["FECHA_INGRESO"]);
                        venta.sFecha = ConvertDatetime(fecha);
                        ventas.Add(venta);
                    }
                }
            }

            return ventas;
        }

        public static double GetGananciaGerenteCurrentWeek(int idUsuario)
        {
            SO_Venta sO_Venta = new SO_Venta();

            DataSet informacionBD = sO_Venta.GetGananciaGerenteCurrentWeek(idUsuario);

            double gananciaTotal = 0;

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow venta in informacionBD.Tables[0].Rows)
                    {
                        gananciaTotal += Convert.ToDouble(venta["GANANCIA_GERENTE"]);
                    }
                }
            }

            return gananciaTotal;
        }

        public static List<DO_Ventas> GetVentasCurrentWeek(int idUsuario)
        {
            SO_Venta sO_Venta = new SO_Venta();

            List<DO_Ventas> ventas = new List<DO_Ventas>();

            DataSet informacionBD = sO_Venta.GetAll(idUsuario);

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {
                        DO_Ventas venta = new DO_Ventas();

                        venta.IdVenta = Convert.ToInt32(item["ID_VENTA"]);
                        venta.IdArticulo = Convert.ToInt32(item["ID_ARTICULO"]);
                        venta.Nombre = Convert.ToString(item["DESCRIPCION"]);
                        venta.Cantidad = Convert.ToInt32(item["CANTIDAD"]);
                        venta.Precio = Convert.ToDouble(item["PRECIO"]);
                        DateTime fechaIngreso = Convert.ToDateTime(item["FECHA_INGRESO"]);
                        venta.sFecha = ConvertDatetime(fechaIngreso);
                        venta.IdPromotor = Convert.ToInt32(item["ID_USUARIO_PROMOTOR"]);
                        venta.NombrePromotor = Convert.ToString(item["PROMOTOR"]);

                        ventas.Add(venta);
                    }
                }
            }

            return ventas;
        }

        public static DO_Ventas GetVenta(int idVenta)
        {
            SO_Venta sO_Venta = new SO_Venta();

            DataSet informacionBD = sO_Venta.Get(idVenta);

            DO_Ventas venta = new DO_Ventas();

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {
                        venta = new DO_Ventas();

                        venta.IdVenta = Convert.ToInt32(item["ID_VENTA"]);
                        venta.IdArticulo = Convert.ToInt32(item["ID_ARTICULO"]);
                        venta.Nombre = Convert.ToString(item["DESCRIPCION"]);
                        venta.Cantidad = Convert.ToInt32(item["CANTIDAD"]);
                        venta.Precio = Convert.ToDouble(item["PRECIO"]);
                        DateTime fechaIngreso = Convert.ToDateTime(item["FECHA_INGRESO"]);
                        venta.Fecha = Convert.ToDateTime(item["FECHA_INGRESO"]);
                        venta.sFecha = ConvertDatetime(fechaIngreso);
                        venta.IdPromotor = Convert.ToInt32(item["ID_USUARIO_PROMOTOR"]);
                        venta.NombrePromotor = Convert.ToString(item["PROMOTOR"]);

                    }
                }
            }

            return venta;
        }

        #endregion

        #region Depositos
        public static int InsertDeposito(int idUsuario, double monto, DateTime fechaIngreso, string banco, string descripcion, string urlArchivo)
        {
            SO_Depositos serviceDeposito = new SO_Depositos();

            return serviceDeposito.Insert(idUsuario, monto, fechaIngreso, banco, descripcion, urlArchivo);
        }

        public static double GetVentaSemanaActual(int idUsuario)
        {
            double monto = 0;

            SO_Venta serviceVenta = new SO_Venta();

            DataSet informacionBD = serviceVenta.GetVentaSemanaActual(idUsuario);

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {
                        monto = Convert.ToDouble(item["MONTO_SEMANAL"].ToString());
                    }
                }
            }

            return monto;
        }

        public static List<DO_Deposito> GetUltimosDepositos(int idUsuario)
        {
            SO_Depositos sO_Depositos = new SO_Depositos();

            IList informacionBD = sO_Depositos.GetUltimosDepositos(idUsuario);

            List<DO_Deposito> dO_Depositos = new List<DO_Deposito>();

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    Type type = item.GetType();

                    DO_Deposito dO_Deposito = new DO_Deposito();

                    dO_Deposito.IdDeposito = Convert.ToInt32(type.GetProperty("ID_DEPOSITO").GetValue(item, null));
                    dO_Deposito.IdUsuario = Convert.ToInt32(type.GetProperty("ID_USUARIO").GetValue(item, null));
                    dO_Deposito.FechaIngreso = Convert.ToDateTime(type.GetProperty("FECHA_INGRESO").GetValue(item, null));
                    dO_Deposito.FechaRegistro = Convert.ToDateTime(type.GetProperty("FECHA_REGISTRO").GetValue(item, null));
                    dO_Deposito.Importe = Convert.ToDouble(type.GetProperty("MONTO").GetValue(item, null));
                    dO_Deposito.Banco = Convert.ToString(type.GetProperty("BANCO").GetValue(item, null));
                    dO_Deposito.Descripcion = Convert.ToString(type.GetProperty("DESCRIPCION").GetValue(item, null));
                    dO_Deposito.UrlArchivo = Convert.ToString(type.GetProperty("URL_ARCHIVO").GetValue(item, null));

                    dO_Depositos.Add(dO_Deposito);
                }
            }

            return dO_Depositos;
        }

        public static List<DO_Deposito> GetDepositosPorWeek(int idUsuario, int idSemana)
        {
            SO_Depositos sO_Depositos = new SO_Depositos();

            DataSet informacionBD = sO_Depositos.GetDepositosPorWeek(idUsuario, idSemana);

            List<DO_Deposito> dO_Depositos = new List<DO_Deposito>();

            if (informacionBD != null)
            {
                if (informacionBD.Tables.Count > 0 && informacionBD.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in informacionBD.Tables[0].Rows)
                    {
                        DO_Deposito dO_Deposito = new DO_Deposito();

                        dO_Deposito.Descripcion = item["DESCRIPCION"].ToString();
                        dO_Deposito.Banco = item["BANCO"].ToString();
                        dO_Deposito.Importe = Convert.ToDouble(item["MONTO"]);
                        dO_Deposito.UrlArchivo = item["URL_ARCHIVO"].ToString();
                        dO_Deposito.FechaIngreso = Convert.ToDateTime(item["FECHA_INGRESO"]);

                        dO_Depositos.Add(dO_Deposito);
                    }
                }
            }

            return dO_Depositos;
        }
        #endregion

        #region Semana
        public static DO_Semana GetSemana(int idSemana)
        {
            DO_Semana dO_Semana = new DO_Semana();

            SO_Semana sO_Semana = new SO_Semana();

            IList list = sO_Semana.GetSemana(idSemana);

            if (list != null)
            {
                foreach (var item in list)
                {
                    Type type = item.GetType();

                    dO_Semana = new DO_Semana();

                    dO_Semana.IdSemana = Convert.ToInt32(type.GetProperty("ID_SEMANA").GetValue(item, null));
                    dO_Semana.NoSemana = Convert.ToInt32(type.GetProperty("NO_SEMANA").GetValue(item, null));
                    dO_Semana.Year = Convert.ToInt32(type.GetProperty("ANIO").GetValue(item, null));
                    dO_Semana.FechaFinal = Convert.ToDateTime(type.GetProperty("DIA_FINAL").GetValue(item, null));
                    dO_Semana.FechaInicial = Convert.ToDateTime(type.GetProperty("DIA_INICIAL").GetValue(item, null));
                    dO_Semana.SFechaInicial = dO_Semana.FechaInicial.ToShortDateString();
                    dO_Semana.SFechaFinal = dO_Semana.FechaFinal.ToShortDateString();
                }
            }

            return dO_Semana;
        }

        public static DO_Semana GetSemanaActual()
        {
            DO_Semana dO_Semana = new DO_Semana();

            SO_Semana sO_Semana = new SO_Semana();

            DataSet dataSet = sO_Semana.GetSemanaActual();

            if (dataSet != null)
            {
                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in dataSet.Tables[0].Rows)
                    {
                        dO_Semana.IdSemana = Convert.ToInt32(item["ID_SEMANA"]);
                        dO_Semana.NoSemana = Convert.ToInt32(item["NO_SEMANA"].ToString());
                        dO_Semana.Year = Convert.ToInt32(item["ANIO"].ToString());
                        dO_Semana.FechaInicial = Convert.ToDateTime(item["DIA_INICIAL"].ToString());
                        dO_Semana.FechaFinal = Convert.ToDateTime(item["DIA_FINAL"].ToString());

                        dO_Semana.SFechaInicial = dO_Semana.FechaInicial.ToShortDateString();
                        dO_Semana.SFechaFinal = dO_Semana.FechaFinal.ToShortDateString();

                    }
                }
            }

            return dO_Semana;
        }

        public static List<DO_Semana> GetSemanas(DateTime dateTime)
        {
            List<DO_Semana> dO_Semanas = new List<DO_Semana>();

            SO_Semana sO_Semana = new SO_Semana();

            IList list = sO_Semana.GetSemanas(dateTime);

            if (list != null)
            {
                foreach (var item in list)
                {
                    Type type = item.GetType();

                    DO_Semana dO_Semana = new DO_Semana();

                    dO_Semana.IdSemana = Convert.ToInt32(type.GetProperty("ID_SEMANA").GetValue(item, null));
                    dO_Semana.NoSemana = Convert.ToInt32(type.GetProperty("NO_SEMANA").GetValue(item, null));
                    dO_Semana.Year = Convert.ToInt32(type.GetProperty("ANIO").GetValue(item, null));
                    dO_Semana.FechaInicial = Convert.ToDateTime(type.GetProperty("DIA_INICIAL").GetValue(item, null));
                    dO_Semana.FechaFinal = Convert.ToDateTime(type.GetProperty("DIA_FINAL").GetValue(item, null));

                    dO_Semana.SFechaInicial = dO_Semana.FechaInicial.ToShortDateString();
                    dO_Semana.SFechaFinal = dO_Semana.FechaFinal.ToShortDateString();

                    dO_Semanas.Add(dO_Semana);
                }
            }

            return dO_Semanas;
        }
        #endregion

        #region Compañia
        public static int InsertCompania(string nombre, string rfc, string direccion, string telefono, string correo, int idPlan)
        {
            SO_Compania sO_Compania = new SO_Compania();

            return sO_Compania.Insert(nombre, rfc, direccion, telefono, correo, idPlan);
        }

        public static List<DO_Compania> GetAllCompanias()
        {
            List<DO_Compania> companias = new List<DO_Compania>();

            SO_Compania sO_Compania = new SO_Compania();

            IList informacionBD = sO_Compania.Get();

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    Type type = item.GetType();

                    DO_Compania compania = new DO_Compania();

                    compania.Correo = type.GetProperty("CORREO").GetValue(item, null).ToString();
                    compania.Direccion = type.GetProperty("DIRECCION").GetValue(item, null).ToString();
                    compania.RFC = type.GetProperty("RFC").GetValue(item, null).ToString();
                    compania.Telefono = type.GetProperty("TELEFONO").GetValue(item, null).ToString();
                    compania.IdCompania = Convert.ToInt32(type.GetProperty("ID_COMPANIA").GetValue(item, null).ToString());
                    compania.FechaRegistro = Convert.ToDateTime(type.GetProperty("FECHA_REGISTRO").GetValue(item, null));
                    compania.IdPlan = Convert.ToInt32(type.GetProperty("ID_PLAN").GetValue(item, null));

                    companias.Add(compania);
                }
            }

            return companias;
        }

        public static DO_Compania GetCompania(int idCompania)
        {
            SO_Compania sO_Compania = new SO_Compania();

            IList informacionBD = sO_Compania.Get(idCompania);

            DO_Compania dO_Compania = new DO_Compania();

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    Type type = item.GetType();

                    dO_Compania = new DO_Compania();

                    dO_Compania.Correo = type.GetProperty("CORREO").GetValue(item, null).ToString();
                    dO_Compania.Direccion = type.GetProperty("DIRECCION").GetValue(item, null).ToString();
                    dO_Compania.RFC = type.GetProperty("RFC").GetValue(item, null).ToString();
                    dO_Compania.Telefono = type.GetProperty("TELEFONO").GetValue(item, null).ToString();
                    dO_Compania.IdCompania = Convert.ToInt32(type.GetProperty("ID_COMPANIA").GetValue(item, null).ToString());
                    dO_Compania.FechaRegistro = Convert.ToDateTime(type.GetProperty("FECHA_REGISTRO").GetValue(item, null));
                    dO_Compania.IdPlan = Convert.ToInt32(type.GetProperty("ID_PLAN").GetValue(item, null));
                }
            }

            return dO_Compania;
        }

        public static int UpdatePlan(int idCompania, int idPlan)
        {
            SO_Compania sO_Compania = new SO_Compania();

            return sO_Compania.UpdatePlan(idCompania, idPlan);
        }
        #endregion

        #region Organizacion

        public static int InsertOrganizacion(int idCompania, string nombre)
        {
            SO_Organizacion serviceOrganizacion = new SO_Organizacion();

            return serviceOrganizacion.Insert(idCompania, nombre);
        }

        public static int UpdateOrganizacion(int idOrganizacion, string nombre)
        {
            SO_Organizacion serviceOrganizacion = new SO_Organizacion();

            return serviceOrganizacion.Update(idOrganizacion, nombre);
        }

        public static DO_Organizacion GetOrganizacionByIdCompania(int idCompania)
        {
            SO_Organizacion serviceOrganizacion = new SO_Organizacion();

            IList list = serviceOrganizacion.GetByCompania(idCompania);

            DO_Organizacion organizacion = new DO_Organizacion();

            if (list != null)
            {
                foreach (var item in list)
                {
                    Type type = item.GetType();

                    organizacion = new DO_Organizacion();

                    organizacion.IdOrganizacion = Convert.ToInt32(type.GetProperty("ID_ORGANIZACION").GetValue(item, null));
                    organizacion.Nombre = type.GetProperty("NOMBRE_ORGANIZACION").GetValue(item, null).ToString();
                    organizacion.FechaRegistro = Convert.ToDateTime(type.GetProperty("FECHA_REGISTRO").GetValue(item, null));
                    organizacion.IdCompaniaAdmin = Convert.ToInt32(type.GetProperty("ID_COMPANIA_ADMIN").GetValue(item, null));

                    organizacion.Companias = new List<DO_Compania>();

                    SO_TR_Organizacion_Compania sO_TR_Organizacion_Compania = new SO_TR_Organizacion_Compania();

                    IList informacionCompanies = sO_TR_Organizacion_Compania.GetCompanyByIdOrganizacion(organizacion.IdOrganizacion);

                    if (informacionCompanies != null)
                    {
                        foreach (var itemCompanie in informacionCompanies)
                        {
                            Type type1 = itemCompanie.GetType();

                            DO_Compania dO_Compania = new DO_Compania();

                            dO_Compania.Correo = type1.GetProperty("CORREO").GetValue(itemCompanie, null).ToString();
                            dO_Compania.Direccion = type1.GetProperty("DIRECCION").GetValue(itemCompanie, null).ToString();
                            dO_Compania.RFC = type1.GetProperty("RFC").GetValue(itemCompanie, null).ToString();
                            dO_Compania.Telefono = type1.GetProperty("TELEFONO").GetValue(itemCompanie, null).ToString();
                            dO_Compania.IdCompania = Convert.ToInt32(type1.GetProperty("ID_COMPANIA").GetValue(itemCompanie, null).ToString());
                            dO_Compania.FechaRegistro = Convert.ToDateTime(type1.GetProperty("FECHA_REGISTRO").GetValue(itemCompanie, null));

                            organizacion.Companias.Add(dO_Compania);
                        }
                    }
                }
            }

            return organizacion;
        }

        public static DO_Organizacion GetOrganizacion(int idOrganizacion)
        {
            SO_Organizacion serviceOrganizacion = new SO_Organizacion();

            IList list = serviceOrganizacion.Get(idOrganizacion);

            DO_Organizacion organizacion = new DO_Organizacion();

            if (list != null)
            {
                foreach (var item in list)
                {
                    Type type = item.GetType();

                    organizacion = new DO_Organizacion();

                    organizacion.IdOrganizacion = idOrganizacion;
                    organizacion.Nombre = type.GetProperty("NOMBRE_ORGANIZACION").GetValue(item, null).ToString();
                    organizacion.FechaRegistro = Convert.ToDateTime(type.GetProperty("FECHA_REGISTRO").GetValue(item, null));
                    organizacion.IdCompaniaAdmin = Convert.ToInt32(type.GetProperty("ID_COMPANIA_ADMIN").GetValue(item, null));

                    organizacion.Companias = new List<DO_Compania>();

                    SO_TR_Organizacion_Compania sO_TR_Organizacion_Compania = new SO_TR_Organizacion_Compania();

                    IList informacionCompanies =  sO_TR_Organizacion_Compania.GetCompanyByIdOrganizacion(idOrganizacion);

                    if (informacionCompanies != null)
                    {
                        foreach (var itemCompanie in informacionCompanies)
                        {
                            Type type1 = itemCompanie.GetType();

                            DO_Compania dO_Compania = new DO_Compania();

                            dO_Compania.Correo = type1.GetProperty("CORREO").GetValue(itemCompanie, null).ToString();
                            dO_Compania.Direccion = type1.GetProperty("DIRECCION").GetValue(itemCompanie, null).ToString();
                            dO_Compania.RFC = type1.GetProperty("RFC").GetValue(itemCompanie, null).ToString();
                            dO_Compania.Telefono = type1.GetProperty("TELEFONO").GetValue(itemCompanie, null).ToString();
                            dO_Compania.IdCompania = Convert.ToInt32(type1.GetProperty("ID_COMPANIA").GetValue(itemCompanie, null).ToString());
                            dO_Compania.FechaRegistro = Convert.ToDateTime(type1.GetProperty("FECHA_REGISTRO").GetValue(itemCompanie, null));

                            organizacion.Companias.Add(dO_Compania);
                        }
                    }
                }
            }
            return organizacion;
        }

        public static int InsertOrganizacionCompania(int idOrganizacion, int idCompania)
        {
            SO_TR_Organizacion_Compania sO_TR_Organizacion_Compania = new SO_TR_Organizacion_Compania();

            return sO_TR_Organizacion_Compania.Insert(idOrganizacion, idCompania);
        }

        public static List<DO_Compania> GetCompaniaByIdOrganizacion(int idOrganizacion)
        {
            SO_TR_Organizacion_Compania sO_TR_Organizacion_Compania = new SO_TR_Organizacion_Compania();

            IList list = sO_TR_Organizacion_Compania.GetCompanyByIdOrganizacion(idOrganizacion);

            List<DO_Compania> companias = new List<DO_Compania>();

            if (list != null)
            {
                foreach (var item in list)
                {
                    Type type = item.GetType();

                    DO_Compania dO_Compania = new DO_Compania();

                    dO_Compania.Correo = type.GetProperty("CORREO").GetValue(item, null).ToString();
                    dO_Compania.Direccion = type.GetProperty("DIRECCION").GetValue(item, null).ToString();
                    dO_Compania.RFC = type.GetProperty("RFC").GetValue(item, null).ToString();
                    dO_Compania.Telefono = type.GetProperty("TELEFONO").GetValue(item, null).ToString();
                    dO_Compania.IdCompania = Convert.ToInt32(type.GetProperty("ID_COMPANIA").GetValue(item, null).ToString());
                    dO_Compania.FechaRegistro = Convert.ToDateTime(type.GetProperty("FECHA_REGISTRO").GetValue(item, null));

                    companias.Add(dO_Compania);
                }
            }

            return companias;
        }
        #endregion

        #region Pagos
        public static bool IsPagoOk(int idCompania)
        {
            SO_Pagos servicePagos = new SO_Pagos();

            IList list = servicePagos.GetUltimoPago(idCompania);

            bool entro = false;
            DateTime ultimoPago= DateTime.MinValue;

            if (list != null)
            {
                foreach (var item in list)
                {
                    Type type = item.GetType();

                    ultimoPago = Convert.ToDateTime(type.GetProperty("FECHA_PAGO").GetValue(item, null));
                    entro = true;
                }
            }

            if (entro)
            {
                double days = (DateTime.Now - ultimoPago).TotalDays;

                return days > 30 ? false : true;
            }
            else
                return false;
        }
        #endregion

        #region Bitácora
        public static int InsertBitacora(string nombreUsuario, string accion)
        {
            SO_Bitacora sO_Bitacora = new SO_Bitacora();

            return sO_Bitacora.Insert(accion, nombreUsuario);
        }

        public static List<DO_Bitacora> GetBitacora()
        {
            SO_Bitacora sO_Bitacora = new SO_Bitacora();

            List<DO_Bitacora> bitacoras = new List<DO_Bitacora>();

            IList list = sO_Bitacora.Get();

            if (list != null)
            {
                foreach (var item in list)
                {
                    Type type = item.GetType();

                    DO_Bitacora dO_Bitacora = new DO_Bitacora();

                    dO_Bitacora.IdBitacora = (int)type.GetProperty("ID_BITACORA").GetValue(item, null);
                    dO_Bitacora.NombreUsuario = (string)type.GetProperty("USUARIO").GetValue(item, null);
                    dO_Bitacora.Accion = (string)type.GetProperty("ACCION").GetValue(item, null);
                    dO_Bitacora.FechaRegistro = (DateTime)type.GetProperty("FECHA_REGISTRO").GetValue(item, null);
                    dO_Bitacora.StringFecha = dO_Bitacora.FechaRegistro.Year + "-" + dO_Bitacora.FechaRegistro.Month + "-" + dO_Bitacora.FechaRegistro.Day + " " + dO_Bitacora.FechaRegistro.Hour + ":" + dO_Bitacora.FechaRegistro.Minute + ":" + dO_Bitacora.FechaRegistro.Second;

                    bitacoras.Add(dO_Bitacora);
                }
            }

            return bitacoras;
        }
        #endregion

        #region Promotores
        internal static List<DO_Persona> GetAllPromotores(int idCompania)
        {
            List<DO_Persona> promotores = new List<DO_Persona>();

            SO_Usuario sO_Usuario = new SO_Usuario();

            IList informacionBD = sO_Usuario.GetAllPromotores(idCompania);

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    Type type = item.GetType();

                    DO_Persona persona = new DO_Persona();

                    persona.idUsuario = Convert.ToInt32(type.GetProperty("ID_USUARIO").GetValue(item, null));
                    persona.Nombre = Convert.ToString(type.GetProperty("NOMBRE").GetValue(item, null));
                    persona.Usuario = Convert.ToString(type.GetProperty("USUARIO").GetValue(item, null));
                    persona.ID_ROL = Convert.ToInt32(type.GetProperty("ID_ROL").GetValue(item, null));
                    persona.idCompania = Convert.ToInt32(type.GetProperty("ID_COMPANIA").GetValue(item, null));
                    persona.Rol = Convert.ToString(type.GetProperty("ROL").GetValue(item, null));

                    promotores.Add(persona);
                }
            }

            return promotores;
        }
        #endregion

        #region Utils
        public static string ConvertDatetime(DateTime date)
        {
            string dateF = string.Empty;
            string month = string.Empty;

            if (date.Month ==1)
            {
                month = "ENE";
            }
            else if(date.Month == 2) {
                month = "FEB";
            }else if(date.Month == 3)
            {
                month = "MAR";
            }else if (date.Month == 4)
            {
                month = "ABR";
            }else if(date.Month == 5)
            {
                month = "MAY";
            }
            else if (date.Month == 6)
            {
                month = "JUN";
            }
            else if (date.Month == 7)
            {
                month = "JUL";
            }
            else if (date.Month == 8)
            {
                month = "AGO";
            }
            else if (date.Month == 9)
            {
                month = "SEP";
            }
            else if (date.Month == 10)
            {
                month = "OCT";
            }
            else if (date.Month == 11)
            {
                month = "NOV";
            }
            else if (date.Month == 12)
            {
                month = "DIC";
            }

            string day = date.Day.ToString().Length == 1 ? "0" + date.Day.ToString() : date.Day.ToString();

            dateF = date.Year + "-" + month + "-" + day;

            return dateF;
        }
        #endregion

        #region Administrador
        public static List<DO_GerentePromotor> GetGerentePromotor()
        {
            SO_Usuario serviceUsuario = new SO_Usuario();

            List<DO_GerentePromotor> promotors = new List<DO_GerentePromotor>();

            IList informacionBD = serviceUsuario.GetAllGerentes();

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    Type type = item.GetType();

                    DO_GerentePromotor gerentePromotor = new DO_GerentePromotor();

                    gerentePromotor.Nombre = type.GetProperty("NOMBRE").GetValue(item, null).ToString();
                    gerentePromotor.Usuario = type.GetProperty("USUARIO").GetValue(item, null).ToString();
                    gerentePromotor.Rol = type.GetProperty("ROL").GetValue(item, null).ToString();
                    gerentePromotor.FechaRegistro = Convert.ToDateTime(type.GetProperty("FECHA_REGISTRO").GetValue(item, null)).ToString();
                    gerentePromotor.NombrePlan = type.GetProperty("NOMBRE_PLAN").GetValue(item, null).ToString();

                    promotors.Add(gerentePromotor);
                }
            }

            return promotors;
        }

        public static int InsertInitialStock(int idCompania, int idArticulo, int cantidad)
        {
            List<DO_Almacen> almacens = GetAllAlmacen(idCompania);
            int idCorte = 0;

            if (almacens.Count > 0)
            {
                DO_Almacen almacenPrincipal = almacens[0];
                DO_Semana semanaActual = GetSemanaActual();
                SO_CorteExistencia sO_CorteExistencia = new SO_CorteExistencia();

                SO_Existencia sO_Existencia = new SO_Existencia();

                sO_Existencia.AddCantidad(almacenPrincipal.idAlmacen, idArticulo, cantidad);

                idCorte = sO_CorteExistencia.Insert(semanaActual.IdSemana, almacenPrincipal.idAlmacen, idArticulo, cantidad);
            }

            return idCorte;
        }

        public static int SetCorteAlmacenes(string nombreUsuario)
        {
            int respuesta = 0;

            List<DO_Compania> companias = GetAllCompanias();

            foreach (var compania in companias)
            {
                List<DO_Almacen> almacens = GetAllAlmacen(compania.IdCompania);

                if (almacens.Count > 0)
                {
                    DO_Almacen almacen = almacens[0];

                    List<DO_Existencia> existencias = DataManager.GetExistenciasByCompania(compania.IdCompania);
                    DO_Semana semanaActual = GetSemanaActual();

                    SO_CorteExistencia sO_CorteExistencia = new SO_CorteExistencia();

                    foreach (var existencia in existencias)
                    {
                        int idCorte = sO_CorteExistencia.Insert(semanaActual.IdSemana, almacen.idAlmacen, existencia.IdArticulo, Convert.ToInt32(existencia.Cantidad));

                        if (idCorte > 0)
                            respuesta++;
                    }
                }
            }

            if (respuesta > 0)
            {
                SO_Bitacora sO_Bitacora = new SO_Bitacora();

                InsertBitacora(nombreUsuario, "Se establece el corte de almacen de la semana.");
            }

            return respuesta;
        }
        #endregion

        #region Movimiento Interno
        
        public static int InsertDetalleMovimientoInterno(int idMovimientoInterno, int idArticulo, decimal cantidad)
        {
            SO_MovimientoInterno sO_MovimientoInterno = new SO_MovimientoInterno();

            return sO_MovimientoInterno.InsertDetalle(idMovimientoInterno, idArticulo, cantidad);
        }

        public static int InsertMovimientoInterno(int idAlmacenOrigen, int idAlmacenDestino, string folio, List<DO_DetalleEntradaArticulo> articulos)
        {
            SO_MovimientoInterno sO_MovimientoInterno = new SO_MovimientoInterno();
            SO_Existencia ServiceExistencia = new SO_Existencia();

            int idMovimientoInterno = sO_MovimientoInterno.Insert(idAlmacenOrigen, idAlmacenDestino, folio);

            int r = 0;

            if (idMovimientoInterno > 0)
            {
                foreach (var detalle in articulos)
                {
                    if (InsertDetalleMovimientoInterno(idMovimientoInterno,detalle.idArticulo, detalle.cantidad) > 0)
                    {
                        r += ServiceExistencia.AddCantidad(idAlmacenDestino, detalle.idArticulo, detalle.cantidad);
                        r += ServiceExistencia.RemoveCantidad(idAlmacenOrigen, detalle.idArticulo, Convert.ToDouble(detalle.cantidad));

                    }
                }
            }

            return r;
        }
        #endregion
    }
}