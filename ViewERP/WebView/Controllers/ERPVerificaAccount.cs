using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebView.Models;

namespace WebView.Controllers
{
    public class ERPVerificaAccount : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //Obtenemos el contexto de la petición actual
            HttpContext contexto = HttpContext.Current;

            //Obtenemos al usuario actual autentificado
            DO_Persona usuario = ((DO_Persona)contexto.Session["UsuarioConectado"]);

            //Validamos que en el contexto exista el objeto
            if (usuario == null) { return false; }

            if (usuario.NombrePlan == "FREE ALL TIME")
            {
                return true;
            }

            if (usuario.NombrePlan == "FREE 7 DAYS")
            {
                double days = (DateTime.Now - usuario.FechaRegistro).TotalDays;
                bool respuesta = days > 7 ? false : true;

                if (!respuesta)
                {
                    //TODO: Actualizar al nuevo plan.
                    int idNewPlan = usuario.ID_ROL == 1 ? 3 : 4;

                    int r = DataManager.UpdatePlan(usuario.idCompania, idNewPlan);
                    DO_Persona usuarioConectado = DataManager.GetPersona(usuario.idUsuario);
                    contexto.Session["UsuarioConectado"] = usuarioConectado;
                }

                return respuesta;
            }

            if (usuario.NombrePlan == "FREE 30 DIAS")
            {
                double days = (DateTime.Now - usuario.FechaRegistro).TotalDays;
                bool respuesta = days > 30 ? false : true;

                if (!respuesta)
                {
                    //TODO: Actualizar al nuevo plan.
                    int idNewPlan = usuario.ID_ROL == 1 ? 3 : 4;

                    int r = DataManager.UpdatePlan(usuario.idCompania, idNewPlan);
                    DO_Persona usuarioConectado = DataManager.GetPersona(usuario.idUsuario);
                    contexto.Session["UsuarioConectado"] = usuarioConectado;
                }

                return respuesta;
            }

            if (usuario.NombrePlan == "GERENTE MENSUAL")
            {
                bool isOk = DataManager.IsPagoOk(usuario.idCompania);
                return isOk;
            }

            if (usuario.NombrePlan == "GERENTE PROMOTOR MENSUAL")
            {
                bool isOk = DataManager.IsPagoOk(usuario.idCompania);
                return isOk;
            }

            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Suscripcion/Index.cshtml"
            };
        }
    }
}