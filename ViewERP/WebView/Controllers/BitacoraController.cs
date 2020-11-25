using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebView.Models;

namespace WebView.Controllers
{
    public class BitacoraController : Controller
    {
        [ERPVerificaRol]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetBitacora(string parametro)
        {
            List<DO_Bitacora> bitacoras = new List<DO_Bitacora>();

            bitacoras = DataManager.GetBitacora();

            var jsonResult = Json(bitacoras, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
    }
}