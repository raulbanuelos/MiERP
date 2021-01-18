using System.Web;
using System.Web.Mvc;
using WebView.Models;

namespace WebView.Controllers
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
                RolesPermitidos = "1,3,5";
                return RolesPermitidos.Contains(RolPersonaAutentificada.ToString());
            }

            if (nombreControlador.Equals("Articulo"))
            {
                RolesPermitidos = "1,3,5";
                return RolesPermitidos.Contains(RolPersonaAutentificada.ToString());
            }

            if (nombreControlador.Equals("CategoriaArticulo"))
            {
                RolesPermitidos = "5";
                return RolesPermitidos.Contains(RolPersonaAutentificada.ToString());
            }

            if (nombreControlador.Equals("EntradasAlmacen"))
            {
                RolesPermitidos = "1,3,5";
                return RolesPermitidos.Contains(RolPersonaAutentificada.ToString());
            }

            if (nombreControlador.Equals("Proveedor"))
            {
                RolesPermitidos = "1,3,5";
                return RolesPermitidos.Contains(RolPersonaAutentificada.ToString());
            }

            if (nombreControlador.Equals("Usuario"))
            {
                RolesPermitidos = "1,3,5";
                return RolesPermitidos.Contains(RolPersonaAutentificada.ToString());
            }

            if (nombreControlador.Equals("Home"))
            {
                RolesPermitidos = "1,3,5";
                return RolesPermitidos.Contains(RolPersonaAutentificada.ToString());
            }

            if (nombreControlador.Equals("LogIn"))
            {
                RolesPermitidos = "1,3,5";
                return RolesPermitidos.Contains(RolPersonaAutentificada.ToString());
            }

            if (nombreControlador.Equals("SalidasAlmacen"))
            {
                RolesPermitidos = "1,3,5";
                return RolesPermitidos.Contains(RolPersonaAutentificada.ToString());
            }

            if (nombreControlador.Equals("EntradasAlmacen"))
            {
                RolesPermitidos = "1,3,5";
                return RolesPermitidos.Contains(RolPersonaAutentificada.ToString());
            }

            if (nombreControlador.Equals("Existencia"))
            {
                RolesPermitidos = "1,3,5";
                return RolesPermitidos.Contains(RolPersonaAutentificada.ToString());
            }

            if (nombreControlador.Equals("Reportes"))
            {
                RolesPermitidos = "1,3,5";
                return RolesPermitidos.Contains(RolPersonaAutentificada.ToString());
            }

            if (nombreControlador.Equals("Ordenes"))
            {
                RolesPermitidos = "1,3,5";
                return RolesPermitidos.Contains(RolPersonaAutentificada.ToString());
            }

            if (nombreControlador.Equals("AlertasStock"))
            {
                RolesPermitidos = "1,3,5";
                return RolesPermitidos.Contains(RolPersonaAutentificada.ToString());
            }

            if (nombreControlador.Equals("Bitacora"))
            {
                RolesPermitidos = "5";
                return RolesPermitidos.Contains(RolPersonaAutentificada.ToString());
            }

            if (nombreControlador.Equals("MovimientoInterno"))
            {
                RolesPermitidos = "1,3,5";
                return RolesPermitidos.Contains(RolPersonaAutentificada.ToString());
            }

            if (nombreControlador.Equals("AdministracionERP"))
            {
                RolesPermitidos = "5";
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