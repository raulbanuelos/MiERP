using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebView.Models;

namespace WebView.Controllers
{
    public class OrganizacionController : Controller
    {
        // GET: Organizacion
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetOrganizacion(string parametro)
        {
            DO_Persona personaConectada = ((DO_Persona)Session["UsuarioConectado"]);
            List<DO_OrganizationChart> miOrganizacion = DataManager.GetMiOrganizacion(personaConectada.idUsuario);

            var jsonResult = Json(miOrganizacion, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
    }
}