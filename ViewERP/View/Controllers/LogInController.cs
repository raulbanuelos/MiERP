using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using View.Models;

namespace View.Controllers
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

                    Session["ADMINISTRADOR"] = false;
                    Session["ALMACEN"] = false;

                    switch (usuario.ID_ROL)
                    {
                        case 1:
                            Session["ADMINISTRADOR"] = true;
                            break;
                        case 2:
                            Session["ALMACEN"] = true;
                            break;
                        default:
                            break;
                    }
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