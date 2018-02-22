using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewERP.Models;

namespace ViewERP.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
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