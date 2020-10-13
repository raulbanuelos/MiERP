using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using View.Models;

namespace View.Controllers
{
    public class HomeController : Controller
    {
        [ERPVerificaRol]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetExistencias(string parametro)
        {
            //HARDCODE
            List<DO_Existencia> lista = DataManager.GetExistenciaArticulos(2005);

            List<DO_ResultMorris> listaResultante = new List<DO_ResultMorris>();

            foreach (var item in lista)
            {
                listaResultante.Add(new DO_ResultMorris { value = Convert.ToInt32(item.Cantidad), label = item.Descripcion });
            }

            var jsonResult = Json(listaResultante, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetVentasDiarias(string parametro)
        {
            //HARDCODE

            int idUsuario = ((DO_Persona)Session["UsuarioConectado"]).idUsuario;

            List<DO_ResultMorris> listaResultante = new List<DO_ResultMorris>();

            listaResultante = DataManager.GetVentaDiaria(idUsuario);

            var jsonResult = Json(listaResultante, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [ERPVerificaRol]
        public ActionResult CerrarSession()
        {
            Session.Abandon();

            return RedirectToAction("Index", "LogIn");
        }
    }
}