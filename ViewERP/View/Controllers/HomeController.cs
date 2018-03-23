using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CerrarSession()
        {
            Session.Abandon();

            return RedirectToAction("Index", "LogIn");
        }
    }
}