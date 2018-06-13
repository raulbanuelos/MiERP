using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using View.Models;

namespace View.Controllers
{
    public class ReportesController : Controller
    {
        // GET: Reportes
        [ERPVerificaRol]
        public ActionResult EntradasArticulos()
        {
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;

            List<SelectListItem> proveedores = DataManager.ConvertListDOProveedorToSelectListItem(DataManager.GetAllProveedor(idCompania));
            proveedores.Add(new SelectListItem { Text = "Ninguno", Value = "0", Selected = true });
            ViewBag.Proveedores = proveedores;

            List<SelectListItem> almacenes = DataManager.ConvertListDOAlmacenToSelectListItem(DataManager.GetAllAlmacen(idCompania));
            almacenes.Add(new SelectListItem { Text = "Ninguno", Value = "0", Selected = true });
            ViewBag.Almacenes = almacenes;

            return View();
        }

        [HttpPost]
        public JsonResult GetEntradasArticulos(string fechaInicial, string fechaFinal,string noFactura,string usuario,string idAlmacen,string idProveedor,string idArticulo)
        {
            List<DO_ReporteEntradaArticulo> lista = new List<DO_ReporteEntradaArticulo>();

            idArticulo = "0";

            lista = DataManager.GetReporteEntrada(fechaInicial, fechaFinal, noFactura, usuario, Convert.ToInt32(idAlmacen), Convert.ToInt32(idProveedor), Convert.ToInt32(idArticulo));

            var jsonResult = Json(lista, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
    }
}