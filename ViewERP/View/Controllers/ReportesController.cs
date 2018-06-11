using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class ReportesController : Controller
    {
        // GET: Reportes
        [ERPVerificaRol]
        public ActionResult EntradasArticulos()
        {
            return View();
        }
    }
}