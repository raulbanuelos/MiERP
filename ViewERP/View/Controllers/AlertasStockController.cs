using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using View.Models;

namespace View.Controllers
{
    public class AlertasStockController : Controller
    {
        // GET: AlertasStock
        public ActionResult Index()
        {
            return View();
        }

        [ERPVerificaRol]
        public ActionResult Alertas()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetAlertas(string parametro)
        {
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;

            List<DO_AlertaStock> Lista = DataManager.GetAlertas(idCompania);

            var jsonResult = Json(Lista, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;

        }
    }
}