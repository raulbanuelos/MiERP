using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebView.Models;

namespace WebView.Controllers
{
    public class HomeController : Controller
    {
        [ERPVerificaRol]
        public ActionResult Index()
        {
            return View();
        }

        [ERPVerificaRol]
        public ActionResult CerrarSession()
        {
            Session.Abandon();

            return RedirectToAction("Index", "LogIn");
        }

        [HttpPost]
        public JsonResult GetSemanaActual(string parametro)
        {
            DO_Semana semana = DataManager.GetSemanaActual();

            double numDia = Convert.ToDouble((int)DateTime.Now.DayOfWeek);

            semana.PctDia = Math.Round(numDia / 7.0 * 100.0,0);

            var jsonResult = Json(semana, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetEntradasCurretnWeek(string parametro)
        {
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;

            List<DO_Movimiento> dO_Movimientos = new List<DO_Movimiento>();

            dO_Movimientos = DataManager.GetMovimientoEntradasCurrentWeek(idCompania);

            var jsonResult = Json(dO_Movimientos, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetSalidasCurretnWeek(string parametro)
        {
            List<DO_Movimiento> dO_Movimientos = new List<DO_Movimiento>();

            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;

            dO_Movimientos = DataManager.GetMovimientoSalidasCurrentWeek(idCompania);

            var jsonResult = Json(dO_Movimientos, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        public JsonResult GetVentaPromotor(string parametro)
        {
            int idUsuario = ((DO_Persona)Session["UsuarioConectado"]).idUsuario;

            DO_ChartData ventas = DataManager.GetVentaSemanalDiariaByPromotor(idUsuario);

            var jsonResult = Json(ventas, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        public ActionResult IndexByGerente(int id = 0)
        {
            DO_Persona persona = DataManager.GetPersona(id);
            return View(persona);
        }
    }
}