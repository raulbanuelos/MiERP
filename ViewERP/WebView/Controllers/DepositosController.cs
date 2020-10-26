using System;
using System.Web;
using System.Web.Mvc;
using WebView.Models;


namespace WebView.Controllers
{
    public class DepositosController : Controller
    {
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

            urlArchivo = "74.208.247.212/erp/uploads/depositos/" + fileName; 

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
    }
}