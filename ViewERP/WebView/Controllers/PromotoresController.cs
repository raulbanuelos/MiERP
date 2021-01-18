using Model;
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
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;

            List<SelectListItem> roles = new List<SelectListItem>();

            roles.Add(new SelectListItem { Text = "Promotor", Value = "4", Selected = true});
            roles.Add(new SelectListItem { Text = "Supervisor", Value = "6", Selected = false });
            roles.Add(new SelectListItem { Text = "Supervidor Elite", Value = "7", Selected = false });
            roles.Add(new SelectListItem { Text = "Asistente", Value = "8", Selected = false });

            ViewBag.Roles = roles;

            ViewBag.Personas = DataManager.GetPosiblesJefes(idCompania);

            return View();
        }

        [HttpPost]
        public JsonResult GuardarPromotor(string nombre, string correo, int idJefe, int idRol)
        {
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;

            DO_Persona dO_Persona = new DO_Persona();
            dO_Persona.Nombre = nombre;
            dO_Persona.idCompania = idCompania;

            //ID_ROL 4 es un promotor
            dO_Persona.ID_ROL = idRol;
            dO_Persona.ApellidoPaterno = string.Empty;
            dO_Persona.ApellidoMaterno = string.Empty;
            dO_Persona.Usuario = correo;
            dO_Persona.IdJefe = idJefe;
            dO_Persona.Contrasena = "4578624862";

            int r = DataManager.InsertPersona(dO_Persona);

            DO_Persona personaConectada = ((DO_Persona)Session["UsuarioConectado"]);

            DataManager.InsertBitacora(personaConectada.Nombre + " " + personaConectada.Usuario, "Se crea un promotor llamado: " + dO_Persona.Nombre);

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
            DO_Persona personaBuscada = DataManager.GetPersona(id);
            DO_Persona personaConectada = ((DO_Persona)Session["UsuarioConectado"]);

            DO_Compania dO_Compania = DataManager.GetCompania(personaConectada.idCompania);

            ViewBag.Personas = DataManager.GetPosiblesJefes(personaConectada.idCompania);

            foreach (SelectListItem item in ViewBag.Personas)
            {
                if (Convert.ToInt32(item.Value) == personaBuscada.IdJefe)
                {
                    item.Selected = true;
                }
            }

            List<SelectListItem> roles = new List<SelectListItem>();

            roles.Add(new SelectListItem { Text = "Promotor", Value = "4", Selected = false });
            roles.Add(new SelectListItem { Text = "Supervisor", Value = "6", Selected = false });
            roles.Add(new SelectListItem { Text = "Supervidor Elite", Value = "7", Selected = false });
            roles.Add(new SelectListItem { Text = "Asistente", Value = "8", Selected = false });

            foreach (var rol in roles)
            {
                if (Convert.ToInt32(rol.Value) == personaBuscada.ID_ROL)
                {
                    rol.Selected = true;
                }
            }

            ViewBag.Roles = roles;



            List<DO_Semana> dO_Semanas = DataManager.GetSemanas(dO_Compania.FechaRegistro);

            List<SelectListItem> listItems = new List<SelectListItem>();

            SelectListItem selectListItem1 = new SelectListItem();
            selectListItem1.Text = "Selecciona una opción";
            selectListItem1.Value = "0";
            listItems.Add(selectListItem1);

            foreach (var item in dO_Semanas)
            {
                SelectListItem selectListItem = new SelectListItem();

                selectListItem.Text = "Semana " + "#" + item.NoSemana + "  De  " + item.SFechaInicial + " a " + item.SFechaFinal;
                selectListItem.Value = item.IdSemana.ToString();

                listItems.Add(selectListItem);
            }

            ViewBag.Semanas = listItems;

            return View(personaBuscada);
        }

        public JsonResult GuardarDatosPromotor(int idUsuario, string nombre, string usuario, int idJefe, int idRol)
        {
            DO_Persona persona = DataManager.GetPersona(idUsuario);
            persona.Nombre = nombre;
            persona.Usuario = usuario;
            persona.IdJefe = idJefe;
            persona.ID_ROL = idRol;
            int r = DataManager.UpdatePersona(persona);

            var jsonResult = Json(r, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetVentasPromotorSemana(int idSemana, int idPromotor)
        {
            List<DO_Ventas> ventas = DataManager.GetVentasPromotor(idPromotor, idSemana);

            var jsonResult = Json(ventas, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetVentaSemanalDiariaPromotor(int idPromotor, int idSemana)
        {
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;

            DO_ChartData dO_ChartData = DataManager.GetVentaSemanalDiariaPromotor(idCompania,idPromotor, idSemana);

            var jsonResult = Json(dO_ChartData, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetLastFiveWeekSalesPromotor(int idPromotor, int idSemana)
        {
            DO_ChartData dO_ChartData = DataManager.GetLastFiveWeekSalesPromotor(idPromotor, idSemana);

            var jsonResult = Json(dO_ChartData, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
    }
}