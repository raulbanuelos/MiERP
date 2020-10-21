using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebView.Models;

namespace WebView.Controllers
{
    public class DepositosController : Controller
    {
        public ActionResult AgregarDeposito()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GuardarDeposito(double monto, DateTime fecha)
        {
            int idUsuario = ((DO_Persona)Session["UsuarioConectado"]).idUsuario;
            int r = DataManager.InsertDeposito(idUsuario, monto, fecha);

            var jsonResult = Json(r, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
    }
}