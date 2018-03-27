using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using View.Models;

namespace View.Controllers
{
    public class AlmacenController : Controller
    {
        // GET: Almacen
        public ActionResult Index()
        {
            return View(DataManager.GetAllAlmacen(((DO_Persona)Session["UsuarioConectado"]).idCompania));
        }

        public ActionResult Create(DO_Almacen almacen = null)
        {
            if (!string.IsNullOrEmpty(almacen.Nombre))
            {
                almacen.idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;
                DataManager.InsertAlmacen(almacen);
                return RedirectToAction("Index", "Almacen");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int id = 0, DO_Almacen almacen = null)
        {
            if (id != 0 && almacen.idAlmacen == 0)
            {
                return View(DataManager.GetAlmacen(id));
            }
            else
            {
                almacen.idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;
                DataManager.UpdateAlamcen(almacen);
                return RedirectToAction("Index", "Almacen");
            }
        }

        public ActionResult Delete(int id = 0)
        {
            DataManager.DeleteAlmacen(id);
            return RedirectToAction("Index", "Almacen");
        }
    }
}