using Model;
using System.Web.Mvc;
using WebView.Models;

namespace WebView.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        [ERPVerificaRol]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ingresar([Bind(Include = "Usuario,Contrasena")] DO_Persona persona)
        {
            if (ModelState.IsValid)
            {
                DO_Persona usuario = DataManager.GetLogin(persona.Usuario, persona.Contrasena);
                if (usuario != null)
                {
                    Session["UsuarioConectado"] = usuario;
                    Session["NombrePersona"] = usuario.NombreCompleto;
                    Session["CorreoPersona"] = usuario.Usuario;

                    Session["ADMINISTRADOR"] = false;
                    Session["ALMACEN"] = false;
                    Session["PRODUCCION"] = false;

                    switch (usuario.ID_ROL)
                    {
                        case 1:
                            Session["ADMINISTRADOR"] = true;
                            break;
                        case 2:
                            Session["ALMACEN"] = true;
                            break;
                        case 4:
                            Session["PRODUCCION"] = true;
                            break;

                        default:
                            break;
                    }

                    DO_Organizacion organizacion = DataManager.GetOrganizacionByIdCompania(usuario.idCompania);

                    Session["IS_ORGANIZACION"] = organizacion.IdOrganizacion != 0 ? true : false;
                    usuario.idOrganizacion = organizacion.IdOrganizacion;

                    return RedirectToAction("Index", "Home");
                }
                else
                    return View("Index");
            }
            else
                return View("Index");
        }
    }
}