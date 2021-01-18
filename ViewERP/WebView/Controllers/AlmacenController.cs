using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebView.Models;

namespace WebView.Controllers
{
    public class AlmacenController : Controller
    {
        // GET: Almacen
        public ActionResult Index()
        {
            return View(DataManager.GetAllAlmacen(((DO_Persona)Session["UsuarioConectado"]).idCompania));
        }

        [HttpPost]
        public JsonResult Get(string parametro)
        {
            var jsonResult = Json(DataManager.GetAllAlmacen(((DO_Persona)Session["UsuarioConectado"]).idCompania), JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [ERPVerificaRol]
        public ActionResult Create(DO_Almacen almacen = null)
        {
            if (!string.IsNullOrEmpty(almacen.Nombre))
            {
                DO_Persona personaConectada = ((DO_Persona)Session["UsuarioConectado"]);

                almacen.idCompania = personaConectada.idCompania;

                DataManager.InsertAlmacen(almacen);

                DataManager.InsertBitacora(personaConectada.Nombre + " " + personaConectada.Usuario, "Creó un almacen llamado:" + almacen.Nombre);
                return RedirectToAction("Index", "Almacen");
            }
            else
            {
                return View();
            }
        }

        [ERPVerificaRol]
        public ActionResult Edit(int id = 0, DO_Almacen almacen = null)
        {
            if (id != 0 && almacen.idAlmacen == 0)
            {
                return View(DataManager.GetAlmacen(id));
            }
            else
            {
                DO_Persona personaConectada = ((DO_Persona)Session["UsuarioConectado"]);
                almacen.idCompania = personaConectada.idCompania;
                DataManager.UpdateAlamcen(almacen);

                DataManager.InsertBitacora(personaConectada.Nombre + " " + personaConectada.Usuario, "Se editó la informacion de un almacen");

                return RedirectToAction("Index", "Almacen");
            }
        }

        [ERPVerificaRol]
        public ActionResult Delete(int id = 0)
        {
            DataManager.DeleteAlmacen(id);
            DO_Persona personaConectada = ((DO_Persona)Session["UsuarioConectado"]);

            DataManager.InsertBitacora(personaConectada.Nombre + " " + personaConectada.Usuario, "Se eliminó un almacen con id: " + id);

            return RedirectToAction("Index", "Almacen");
        }
    }
}