using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using WebView.Models;

namespace WebView.Controllers
{
    public class DepositosController : Controller
    {
        [ERPVerificaAccount]
        public ActionResult AgregarDeposito()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GuardarDeposito()
        {
            int idUsuario = ((DO_Persona)Session["UsuarioConectado"]).idUsuario;

            string urlArchivo = string.Empty;
            string fileName = string.Empty;
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i];
                int fileSize = file.ContentLength;
                fileName = file.FileName;
                string mimeType = file.ContentType;
                System.IO.Stream fileContent = file.InputStream;

                urlArchivo = Server.MapPath("~/uploads/depositos/") + fileName;
                //To save file, use SaveAs method
                file.SaveAs(urlArchivo);
            }

            urlArchivo = "/uploads/depositos/" + fileName;

            double monto = 0;
            DateTime fecha = DateTime.Now;
            string banco = string.Empty;
            string descripcion = string.Empty;

            monto = Convert.ToDouble(Request.Form["monto"]);
            fecha = Convert.ToDateTime(Request.Form["fecha"]);
            banco = Convert.ToString(Request.Form["banco"]);
            descripcion = Convert.ToString(Request.Form["descripcion"]);

            int r = DataManager.InsertDeposito(idUsuario, monto, fecha, banco,descripcion,urlArchivo);

            var jsonResult = Json(r, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetUltimosDepositos(string parametro)
        {
            int idUsuario = ((DO_Persona)Session["UsuarioConectado"]).idUsuario;
            List<DO_Deposito> list= DataManager.GetUltimosDepositos(idUsuario);

            var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetDepositosByCompania(int idUsuario)
        {
            List<DO_Deposito> do_Depositos = new List<DO_Deposito>();

            DO_Semana semanaActual = DataManager.GetSemanaActual();

            do_Depositos = DataManager.GetDepositosPorWeek(idUsuario, semanaActual.IdSemana);

            var jsonResult = Json(do_Depositos, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
    }
}