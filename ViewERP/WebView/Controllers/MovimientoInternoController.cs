using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebView.Models;

namespace WebView.Controllers
{
    public class MovimientoInternoController : Controller
    {
        [ERPVerificaAccount]
        [ERPVerificaRol]
        public ActionResult DarMovimientoInterno()
        {
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;

            ViewBag.Almacenes = DataManager.ConvertListDOAlmacenToSelectListItem(DataManager.GetAllAlmacen(idCompania));
            ViewBag.Articulos = DataManager.ConvertListDOArticuloToSelectListItem(DataManager.GetAllArticulos(idCompania));
            
            return View();
        }

        [HttpPost]
        public JsonResult GuardarMovimientoInterno(int idAlmacenOrigen, int idAlmacenDestino,DateTime fecha, List<DO_DetalleEntradaArticulo> articulos)
        {
            int r = DataManager.InsertMovimientoInterno(idAlmacenOrigen, idAlmacenDestino, "FOLIO", articulos);

            DO_Persona personaConectada = ((DO_Persona)Session["UsuarioConectado"]);

            DataManager.InsertBitacora(personaConectada.Nombre + " " + personaConectada.Usuario, "Se crea un movimiento de almacen interno con idAlmacenOrigen: " + idAlmacenOrigen + " Y idAlmacenDestino:" + idAlmacenDestino);

            var jsonResult = Json(r, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
    }
}