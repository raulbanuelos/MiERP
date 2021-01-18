using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebView.Models;

namespace WebView.Controllers
{
    public class AdministracionERPController : Controller
    {
        [ERPVerificaRol]
        public ActionResult Index()
        {
            return View();
        }

        [ERPVerificaRol]
        [HttpPost]
        public JsonResult RealizarCorteAlmacen(string parametro)
        {
            string respuesta = string.Empty;
            DO_Persona personaConectada = ((DO_Persona)Session["UsuarioConectado"]);

            int a = DataManager.SetCorteAlmacenes(personaConectada.Nombre + " "+ personaConectada.Usuario);

            if(a > 0)
            {
                respuesta = "Corte establecido correctamente. " + a + " registros modificados.";
            }
            else
            {
                respuesta = "Hubo un error, por favor intente mas tarde.";
            }

            var jsonResult = Json(respuesta, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
    }
}