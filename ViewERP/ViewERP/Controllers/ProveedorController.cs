using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewERP.Models;

namespace ViewERP.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        public ActionResult Index()
        {

            return View(DataManager.GetAllProveedor());
        }

        public ActionResult Edit(int id = 0,DO_Proveedor proveedor = null)
        {

            if (id != 0 && proveedor.idProveedor == 0)
            {
                return View(DataManager.GetProveedor(id));
            }
            else
            {
                DataManager.UpdateProveedor(proveedor);
                return RedirectToAction("Index","Proveedor");
            }
            
        }

        

        

    }
}