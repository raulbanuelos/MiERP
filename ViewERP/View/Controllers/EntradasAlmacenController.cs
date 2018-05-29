using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using View.Models;

namespace View.Controllers
{
    public class EntradasAlmacenController : Controller
    {
        // GET: EntradasAlmacen
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
        public JsonResult GuardarEntrada(int idAlmacen,int idArticulo,int idProveedor,int idUnidad,double cantidad,string noFactura)
        {
            string usuario = ((DO_Persona)Session["UsuarioConectado"]).Usuario;
            //int result = DataManager.InsertEntradaArticuloAlmacen(idAlmacen, idArticulo, idProveedor, idUnidad, cantidad, noFactura, DateTime.Now, usuario);
            int result = 0;
            var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        
    }
}