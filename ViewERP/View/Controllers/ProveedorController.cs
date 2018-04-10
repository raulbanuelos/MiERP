using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using View.Models;

namespace View.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        [ERPVerificaRol]
        public ActionResult Index()
        {
            return View(DataManager.GetAllProveedor(((DO_Persona)Session["UsuarioConectado"]).idCompania));
        }

        [ERPVerificaRol]
        public ActionResult Edit(int id = 0, DO_Proveedor proveedor = null)
        {

            if (id != 0 && proveedor.idProveedor == 0)
            {
                return View(DataManager.GetProveedor(id));
            }
            else
            {
                proveedor.idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;
                DataManager.UpdateProveedor(proveedor);
                return RedirectToAction("Index", "Proveedor");
            }

        }

        [ERPVerificaRol]
        public ActionResult Create(DO_Proveedor proveedor = null)
        {
            if (!string.IsNullOrEmpty(proveedor.Nombre))
            {
                proveedor.idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;
                DataManager.InsertProveedor(proveedor);
                return RedirectToAction("Index", "Proveedor");
            }
            else
            {
                return View();
            }
        }

        [ERPVerificaRol]
        public ActionResult Delete(int id = 0, DO_Proveedor model = null)
        {
            if (id != 0)
            {
                DataManager.DeleteProveedor(id);
                return RedirectToAction("Index", "Proveedor");
            }
            else
            {
                DataManager.DeleteProveedor(id);
                return RedirectToAction("Index", "Proveedor");
            }
        }
    }
}