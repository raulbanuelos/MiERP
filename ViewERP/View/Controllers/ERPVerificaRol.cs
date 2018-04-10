﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using View.Models;

namespace View.Controllers
{
    public class ERPVerificaRol : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //Obtenemos el contexto de la petición actual
            HttpContext contexto = HttpContext.Current;

            //Obtenemos al usuario actual autentificado
            DO_Persona usuario = ((DO_Persona)contexto.Session["UsuarioConectado"]);
            
            //Validamos que en el contexto exista el objeto
            if (usuario == null) { return false; }

            int RolPersonaAutentificada = usuario.ID_ROL;

            // Obtenemos el nombre de la acción que se quieren ejecutar
            string nombreAccion = HttpContext.Current.Request.RequestContext.RouteData.GetRequiredString("action");

            //Obtenemos el nombre del controlador que se quiere ejecutar
            string nombreControlador = HttpContext.Current.Request.RequestContext.RouteData.GetRequiredString("controller");

            //0=>no existe, 1=>ADMINISTRADOR, 2=>ALMACEN, 1=>OPERARIO

            string RolesPermitidos; 
            if (nombreControlador.Equals("Almacen"))
            {
                RolesPermitidos = "1";
                return RolesPermitidos.Contains(RolPersonaAutentificada.ToString());
            }


            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/LogIn/Index.cshtml"
            };
        }
    }
}