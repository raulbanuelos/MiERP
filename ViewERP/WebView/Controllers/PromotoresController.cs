using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebView.Models;

namespace WebView.Controllers
{
    public class PromotoresController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ERPVerificaAccount]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GuardarPromotor(string nombre, string correo)
        {
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;

            DO_Persona dO_Persona = new DO_Persona();
            dO_Persona.Nombre = nombre;
            dO_Persona.idCompania = idCompania;

            //ID_ROL 4 es un promotor
            dO_Persona.ID_ROL = 4;
            dO_Persona.ApellidoPaterno = string.Empty;
            dO_Persona.ApellidoMaterno = string.Empty;
            dO_Persona.Usuario = correo;
            dO_Persona.Contrasena = "4578624862";

            int r = DataManager.InsertPersona(dO_Persona);

            var jsonResult = Json(r, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetAllPromotores(string parametro)
        {
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;

            List<DO_Persona> promotores = DataManager.GetAllPromotores(idCompania);

            DO_OrganizationChart chart = new DO_OrganizationChart();

            chart.Promotores = promotores;
            chart.Yo = ((DO_Persona)Session["UsuarioConectado"]);
            
            var jsonResult = Json(chart, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [ERPVerificaAccount]
        public ActionResult Editar(int id=0, DO_Persona persona = null)
        {
            return View(DataManager.GetPersona(id));
        }

        public JsonResult GuardarDatosPromotor(int idUsuario, string nombre, string usuario)
        {
            DO_Persona persona = DataManager.GetPersona(idUsuario);
            persona.Nombre = nombre;
            persona.Usuario = usuario;
            int r = DataManager.UpdatePersona(persona);

            var jsonResult = Json(r, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetVentaSemanalDiariaPromotor(int idPromotor)
        {
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;

            DO_ChartData dO_ChartData = DataManager.GetVentaSemanalDiariaPromotor(idCompania,idPromotor);

            var jsonResult = Json(dO_ChartData, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
    }
}