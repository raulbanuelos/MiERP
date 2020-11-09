using Model;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebView.Models;

namespace WebView.Controllers
{
    public class RecordsWeekController : Controller
    {
        // GET: RecordsWeek
        public ActionResult Index()
        {
            DO_Persona personaConectada = ((DO_Persona)Session["UsuarioConectado"]);

            DO_Compania dO_Compania = DataManager.GetCompania(personaConectada.idCompania);

            List<DO_Semana> dO_Semanas = DataManager.GetSemanas(dO_Compania.FechaRegistro);

            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var item in dO_Semanas)
            {
                SelectListItem selectListItem = new SelectListItem();

                selectListItem.Text = "Semana " + "#" + item.NoSemana + "  De  " + item.SFechaInicial + " a " + item.SFechaFinal;
                selectListItem.Value = item.IdSemana.ToString();

                listItems.Add(selectListItem);
            }

            ViewBag.Semanas = listItems;

            return View();
        }

        [HttpPost]
        public JsonResult BajarArchivo(int idSemana)
        {
            DO_Persona personaConectada = ((DO_Persona)Session["UsuarioConectado"]);

            string path = Server.MapPath("~/formatoreporte.xlsx");
            SLDocument sLDocument = new SLDocument(path, "Reporte");

            List<DO_Deposito> depositos = new List<DO_Deposito>();
            depositos = DataManager.GetDepositosPorWeek(personaConectada.idUsuario, idSemana);

            List<DO_Movimiento> entradas = new List<DO_Movimiento>();
            entradas = DataManager.GetMovimientoEntradasPorWeek(personaConectada.idCompania, idSemana);

            List<DO_Movimiento> dO_Movimientos = new List<DO_Movimiento>();
            dO_Movimientos = DataManager.GetMovimientoSalidasPorWeek(personaConectada.idCompania, idSemana);

            List<DO_Ventas> ventas = new List<DO_Ventas>();
            ventas = DataManager.GetListVentaPorSemana(personaConectada.idUsuario, idSemana);

            DO_Semana dO_Semana = DataManager.GetSemana(idSemana);
            string rangoFecha = dO_Semana.SFechaInicial + " a " + dO_Semana.SFechaFinal;

            #region Llenado de información
            sLDocument.SetCellValue("F4", personaConectada.NombreCompleto);
            sLDocument.SetCellValue("F10", dO_Semana.NoSemana);
            sLDocument.SetCellValue("H10", rangoFecha);
            sLDocument.SetCellValue("K7", personaConectada.Usuario);
            #endregion


            string newPath = Server.MapPath("~/formatoreporte_" + personaConectada.Nombre + idSemana + ".xlsx");
            sLDocument.SaveAs(newPath);

            var jsonResult = Json("Archivo creado correctamente", JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetVentasPorWeek(int idSemana)
        {
            int idUsuario = ((DO_Persona)Session["UsuarioConectado"]).idUsuario;

            List<DO_Ventas> ventas = new List<DO_Ventas>();

            ventas = DataManager.GetListVentaPorSemana(idUsuario, idSemana);

            var jsonResult = Json(ventas, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetEntradasPorWeek(int idSemana)
        {
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;

            List<DO_Movimiento> dO_Movimientos = new List<DO_Movimiento>();

            dO_Movimientos = DataManager.GetMovimientoEntradasPorWeek(idCompania, idSemana);

            var jsonResult = Json(dO_Movimientos, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetSalidasPorWeek(int idSemana)
        {
            List<DO_Movimiento> dO_Movimientos = new List<DO_Movimiento>();

            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;

            dO_Movimientos = DataManager.GetMovimientoSalidasPorWeek(idCompania, idSemana);

            var jsonResult = Json(dO_Movimientos, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetDepositosPorWeek(int idSemana)
        {
            List<DO_Deposito> do_Depositos = new List<DO_Deposito>();

            int idUsuario = ((DO_Persona)Session["UsuarioConectado"]).idUsuario;

            do_Depositos = DataManager.GetDepositosPorWeek(idUsuario, idSemana);

            var jsonResult = Json(do_Depositos, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }


    }
}