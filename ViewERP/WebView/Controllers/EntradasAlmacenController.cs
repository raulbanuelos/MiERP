using Model;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebView.Models;

namespace WebView.Controllers
{
    public class EntradasAlmacenController : Controller
    {
        [ERPVerificaAccount]
        [ERPVerificaRol]
        public ActionResult DarEntrada()
        {
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;

            ViewBag.Almacenes = DataManager.ConvertListDOAlmacenToSelectListItem(DataManager.GetAllAlmacen(idCompania));
            ViewBag.Articulos = DataManager.ConvertListDOArticuloToSelectListItem(DataManager.GetAllArticulos(idCompania));
            ViewBag.Proveedores = DataManager.ConvertListDOProveedorToSelectListItem(DataManager.GetAllProveedor(idCompania));
            ViewBag.Unidades = DataManager.ConvertListDOUnidadToSelectListItem(DataManager.GetAllUnidad());

            return View();
        }

        [ERPVerificaRol]
        public JsonResult GuardarEntrada(int idAlmacen, int idArticulo, int idProveedor, int idUnidad, double cantidad, string noFactura)
        {
            string usuario = ((DO_Persona)Session["UsuarioConectado"]).Usuario;
            //int result = DataManager.InsertEntradaArticuloAlmacen(idAlmacen, idArticulo, idProveedor, idUnidad, cantidad, noFactura, DateTime.Now, usuario);
            int result = 0;
            var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetAllCategoriasArticulos(string parametro)
        {
            List<DO_CategoriaArticulo> listaCategoriaArticulo = new List<DO_CategoriaArticulo>();
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;

            listaCategoriaArticulo = DataManager.ConvertDOArticuloToCategoriaArticulo(DataManager.GetAllArticulos(idCompania));

            var jsonResult = Json(listaCategoriaArticulo, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GuardarEntrada(int idAlmacen, int idProveedor, string Factura, DateTime fecha, List<DO_DetalleEntradaArticulo> articulos)
        {
            int r = DataManager.InsertEntradaArticuloAlmacen(idAlmacen, idProveedor, Factura, fecha, ((DO_Persona)Session["UsuarioConectado"]).Usuario, articulos);

            var jsonResult = Json(r, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
    }
}