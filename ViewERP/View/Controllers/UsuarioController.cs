using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using View.Models;

namespace View.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View(DataManager.GetAllPersona(((DO_Persona)Session["UsuarioConectado"]).idCompania));
        }

        public ActionResult Create(DO_Persona persona = null)
        {
            if (!string.IsNullOrEmpty(persona.Nombre))
            {
                persona.idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;
                DataManager.InsertPersona(persona);
                return RedirectToAction("Index", "Persona");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int id = 0, DO_Persona persona = null)
        {
            if (id != 0 && persona.idUsuario == 0)
            {
                return View(DataManager.GetAlmacen(id));
            }
            else
            {
                persona.idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;
                DataManager.UpdatePersona(persona);
                return RedirectToAction("Index", "Persona");
            }
        }

        public ActionResult Delete(int id = 0)
        {
            DataManager.DeletePersona(id);
            return RedirectToAction("Index", "Persona");
        }
    }
}