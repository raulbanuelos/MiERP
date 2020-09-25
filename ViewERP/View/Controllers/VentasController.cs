using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using View.Models;

namespace View.Controllers
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
    }
}