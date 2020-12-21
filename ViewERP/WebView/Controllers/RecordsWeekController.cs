using Model;
using SpreadsheetLight;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            SelectListItem selectListItem1 = new SelectListItem();
            selectListItem1.Text = "Selecciona una opción";
            selectListItem1.Value = "0";
            listItems.Add(selectListItem1);

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

        [ERPVerificaAccount]
        public ActionResult BajarArchivo(int idSemana)
        {
            DO_Persona personaConectada = ((DO_Persona)Session["UsuarioConectado"]);
            DO_Compania compania = DataManager.GetCompania(personaConectada.idCompania);

            string path = Server.MapPath("~/assets/files/formatoreportesemanal.xlsx");
            SLDocument sLDocument = new SLDocument(path, "Reporte");

            List<DO_Deposito> depositos = new List<DO_Deposito>();
            depositos = DataManager.GetDepositosPorWeek(personaConectada.idUsuario, idSemana);

            List<DO_Movimiento> entradas = new List<DO_Movimiento>();
            entradas = DataManager.GetMovimientoEntradasPorWeek(personaConectada.idCompania, idSemana);

            List<DO_Movimiento> salidas = new List<DO_Movimiento>();
            salidas = DataManager.GetMovimientoSalidasPorWeek(personaConectada.idCompania, idSemana);

            List<DO_Ventas> ventas = new List<DO_Ventas>();
            ventas = DataManager.GetListVentaPorSemana(personaConectada.idUsuario, idSemana);

            DO_Semana dO_Semana = DataManager.GetSemana(idSemana);
            string rangoFecha = dO_Semana.SFechaInicial + " a " + dO_Semana.SFechaFinal;

            List<DO_ReporteSemanal> dO_Reportes = new List<DO_ReporteSemanal>();
            
            //Entradas
            foreach (DO_Movimiento entrada in entradas)
            {
                if (dO_Reportes.Where(x => x.IdArticulo == entrada.IdArticulo).ToList().Count > 0)
                {
                    DO_ReporteSemanal reporteSemanal = dO_Reportes.Where(x => x.IdArticulo == entrada.IdArticulo).FirstOrDefault();
                    int index = dO_Reportes.IndexOf(reporteSemanal);

                    dO_Reportes[index].Entradas += entrada.Cantidad;
                    dO_Reportes[index].Origen += entrada.BodegaDestino + "(" + entrada.Cantidad + ") ";
                }
                else
                {
                    DO_ReporteSemanal reporteSemanal = new DO_ReporteSemanal();

                    reporteSemanal.NombreArticulo = entrada.Nombre;
                    reporteSemanal.Entradas = entrada.Cantidad;
                    reporteSemanal.Origen = entrada.BodegaDestino + "(" + entrada.Cantidad + ") ";
                    reporteSemanal.IdArticulo = entrada.IdArticulo;

                    dO_Reportes.Add(reporteSemanal);
                }
            }

            //Salidas
            foreach (DO_Movimiento salida in salidas)
            {
                if (dO_Reportes.Where(x => x.IdArticulo == salida.IdArticulo).ToList().Count > 0)
                {
                    DO_ReporteSemanal reporteSemanal = dO_Reportes.Where(x => x.IdArticulo == salida.IdArticulo).FirstOrDefault();
                    int index = dO_Reportes.IndexOf(reporteSemanal);

                    dO_Reportes[index].Salidas += salida.Cantidad;
                    dO_Reportes[index].Destino += salida.BodegaDestino + "(" + salida.Cantidad + ") ";
                }
                else
                {
                    DO_ReporteSemanal reporteSemanal = new DO_ReporteSemanal();

                    reporteSemanal.NombreArticulo = salida.Nombre;
                    reporteSemanal.Salidas = salida.Cantidad;
                    reporteSemanal.Destino = salida.BodegaDestino + "(" + salida.Cantidad + ") ";
                    reporteSemanal.IdArticulo = salida.IdArticulo;

                    dO_Reportes.Add(reporteSemanal);
                }
            }

            //Ventas
            foreach (var venta in ventas)
            {
                if (dO_Reportes.Where(x => x.IdArticulo == venta.IdArticulo).ToList().Count > 0)
                {
                    DO_ReporteSemanal reporteSemanal = dO_Reportes.Where(x => x.IdArticulo == venta.IdArticulo).FirstOrDefault();
                    int index = dO_Reportes.IndexOf(reporteSemanal);

                    dO_Reportes[index].ArticulosVendidos += venta.Cantidad;
                }
                else
                {
                    DO_ReporteSemanal reporteSemanal = new DO_ReporteSemanal();

                    reporteSemanal.NombreArticulo = venta.Nombre;
                    reporteSemanal.IdArticulo = venta.IdArticulo;
                    reporteSemanal.ArticulosVendidos = venta.Cantidad;

                    dO_Reportes.Add(reporteSemanal);
                }
            }

            //PRECIO
            foreach (DO_ReporteSemanal item in dO_Reportes)
            {
                double costo = DataManager.GetArticulo(item.IdArticulo).PRECIO_UNIDAD;
                
                item.CostoUnitario = costo;
            }

            //Inventario inicial
            List<DO_Almacen> almacens = DataManager.GetAllAlmacen(compania.IdCompania);
            List<FO_Item> existencias = DataManager.GetCorteExistencia(idSemana, almacens[0].idAlmacen);
            foreach (var item in dO_Reportes)
            {
                int i = existencias.Where(x => x.NombreInt == item.IdArticulo).ToList().Count;
                if (i == 0)
                {
                    item.InventarioInicial = 0;
                }
                else
                {
                    FO_Item temp = existencias.Where(x => x.NombreInt == item.IdArticulo).FirstOrDefault();
                    int existencia = temp.ValueInt;
                    item.InventarioInicial = existencia;
                }

            }
            
            #region Llenado de información
            sLDocument.SetCellValue("F4", personaConectada.NombreCompleto);
            sLDocument.SetCellValue("I5", compania.Direccion);
            sLDocument.SetCellValue("F7", compania.Telefono);
            sLDocument.SetCellValue("F10", dO_Semana.NoSemana);
            sLDocument.SetCellValue("H10", rangoFecha);
            sLDocument.SetCellValue("K7", personaConectada.Usuario);

            //Llenado de depositos.
            int c = 32;
            foreach (var deposito in depositos)
            {
                sLDocument.SetCellValue("A" + c, deposito.FechaIngreso);
                sLDocument.SetCellValue("B" + c, deposito.Banco);
                sLDocument.SetCellValue("C" + c, deposito.Importe);
                c++;
            }

            c = 17;
            //Llenado de articulos
            foreach (var reporteSemanal in dO_Reportes)
            {
                sLDocument.SetCellValue("B" + c, reporteSemanal.NombreArticulo);
                sLDocument.SetCellValue("C" + c, reporteSemanal.InventarioInicial);
                sLDocument.SetCellValue("D" + c, reporteSemanal.Entradas);
                sLDocument.SetCellValue("E" + c, reporteSemanal.Origen);
                sLDocument.SetCellValue("F" + c, reporteSemanal.Salidas);
                sLDocument.SetCellValue("G" + c, reporteSemanal.Destino);
                sLDocument.SetCellValue("I" + c, reporteSemanal.ArticulosVendidos);
                sLDocument.SetCellValue("K" + c, reporteSemanal.CostoUnitario);
                
                c++;
            }

            #endregion

            sLDocument.AutoFitRow(18);

            if (!Directory.Exists(Server.MapPath("~/files/reportesemanal/" + personaConectada.Nombre)))
            {
                Directory.CreateDirectory(Server.MapPath("~/files/reportesemanal/" + personaConectada.Nombre));
            }

            string newPath = Server.MapPath("~/files/reportesemanal/" + personaConectada.Nombre + "/reporte_" + dO_Semana.NoSemana +".xlsx");
            sLDocument.SaveAs(newPath);

            byte[] fileBytes = System.IO.File.ReadAllBytes(newPath);

            string fileName = "Reporte_" + dO_Semana.NoSemana + "_" + personaConectada.Nombre + ".xlsx";

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
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

            dO_Movimientos = DataManager.GetMovimientoEntradasPorWeekDetalle(idCompania, idSemana);

            var jsonResult = Json(dO_Movimientos, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetSalidasPorWeek(int idSemana)
        {
            List<DO_Movimiento> dO_Movimientos = new List<DO_Movimiento>();

            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;

            dO_Movimientos = DataManager.GetMovimientoSalidasPorWeekDetalle(idCompania, idSemana);

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