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

                    Session["GERENTE"] = false;
                    Session["CONTACTO"] = false;
                    Session["PRODUCCION"] = false;
                    Session["ADMINISTRADOR"] = false;
                    Session["GERENTE_PROMOTOR"] = false;

                    switch (usuario.ID_ROL)
                    {
                        case 1:
                            Session["GERENTE"] = true;
                            break;
                        case 2:
                            Session["CONTACTO"] = true;
                            break;
                        case 3:
                            Session["GERENTE_PROMOTOR"] = true;
                            break;
                        case 4:
                            Session["PRODUCCIÓN"] = true;
                            break;
                        case 5:
                            Session["ADMINISTRADOR"] = true;
                            break;
                        default:
                            break;
                    }

                    DO_Organizacion organizacion = DataManager.GetOrganizacionByIdCompania(usuario.idCompania);

                    Session["IS_ORGANIZACION"] = organizacion.IdOrganizacion != 0 ? true : false;
                    usuario.idOrganizacion = organizacion.IdOrganizacion;

                    int r = DataManager.InsertBitacora(usuario.NombreCompleto, "INGRESA A LA PLATAFORMA");

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