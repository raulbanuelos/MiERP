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
            return View(DataManager.GetAllAlmacen());
        }

        public ActionResult Create(DO_Almacen almacen = null)
        {
            if (!string.IsNullOrEmpty(almacen.Nombre))
            {
                DataManager.InsertAlmacen(almacen);
                return RedirectToAction("Index", "Almacen");
            }
            else
            {
                return View();
            }
        }
    }
}