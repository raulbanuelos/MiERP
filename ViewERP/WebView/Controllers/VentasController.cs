using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebView.Models;

namespace WebView.Controllers
{
    public class VentasController : Controller
    {
        // GET: Ventas
        public ActionResult AgregarVenta()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GuardarVenta(double monto, DateTime fecha)
        {
            int idUsuario = ((DO_Persona)Session["UsuarioConectado"]).idUsuario;
            int r = DataManager.InsertVenta(idUsuario, monto, fecha);

            var jsonResult = Json(r, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetVentaDiaActual(string parametro)
        {
            int idUsuario = ((DO_Persona)Session["UsuarioConectado"]).idUsuario;
            double venta = DataManager.GetVentaDiaActual(idUsuario);

            var jsonResult = Json(venta, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetVentaMesActual(string parametro)
        {
            int idUsuario = ((DO_Persona)Session["UsuarioConectado"]).idUsuario;
            double venta = DataManager.GetVentaMesActual(idUsuario);

            var jsonResult = Json(venta, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetVentaSemanaActual(string parametro)
        {
            int idUsuario = ((DO_Persona)Session["UsuarioConectado"]).idUsuario;
            double venta = DataManager.GetVentaSemanaActual(idUsuario);

            var jsonResult = Json(venta, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetVentaUltimosMeses(string parametro)
        {
            int idUsuario = ((DO_Persona)Session["UsuarioConectado"]).idUsuario;
            List<FO_Item> lista = DataManager.GetVentaUltimosMeses(idUsuario);

            var jsonResult = Json(lista, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
    }
}