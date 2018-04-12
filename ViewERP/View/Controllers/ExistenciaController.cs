using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using View.Models;

namespace View.Controllers
{
    public class ExistenciaController : Controller
    {
        // GET: Existencia
        [ERPVerificaRol]
        public ActionResult Index()
        {
            //hardCode
            return View(DataManager.GetExistenciaArticulos(1));
        }
    }
}