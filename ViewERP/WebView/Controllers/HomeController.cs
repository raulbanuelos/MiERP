using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebView.Models;

namespace WebView.Controllers
{
    public class HomeController : Controller
    {
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

            var jsonResult = Json(semana, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
    }
}