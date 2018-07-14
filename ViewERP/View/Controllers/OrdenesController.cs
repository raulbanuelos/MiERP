using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using View.Models;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Data;

namespace View.Controllers

{
    public class OrdenesController : Controller
    {
        // GET: Ordenes
        [ERPVerificaRol]
        public ActionResult Index()
        {
            List<SelectListItem> Estatus = new List<SelectListItem>();

            Estatus = DataManager.ConvertListDOEstatusOrdenToSelectListItem(DataManager.GetAllEstatus());

            ViewBag.Estatus = Estatus;

            return View();
        }

        [ERPVerificaRol]
        public ActionResult Crear()
        {
            List<SelectListItem> clientes = DataManager.ConvertListDOClienteToSelectListItem(DataManager.GetAllClientes());
            ViewBag.Clientes = clientes;

            List<SelectListItem> Productos = DataManager.ConvertListDOProductoToSelectListItem(DataManager.GetAllProductos());
            ViewBag.Productos = Productos;

            return View();
        }

        [HttpPost]
        public JsonResult GuardarOrden(string fechaSolicitud, string fechaEntrega, string requisicion, string proyecto, string folio, int idCliente, List<DO_SolicitudProducto> productos)
        {
            string usuario = ((DO_Persona)Session["UsuarioConectado"]).Usuario;
            
            int r = DataManager.InsertOrden(fechaSolicitud, fechaEntrega, requisicion, proyecto, folio, idCliente, productos, usuario);

            var jsonResult = Json(r, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public ActionResult SubirArchivosOrdenes()
        {
            int idOrden = Convert.ToInt32(Request.Form["idOrden"]);
            foreach (string fileName in Request.Files)
            {
                HttpPostedFileBase Archivo = Request.Files[fileName];

                var FileSize = Archivo.ContentLength;
                string NombreArchivo = Archivo.FileName;
                byte[] ArchivoFisico = DataManager.GetBytesFromInputStream(Archivo.InputStream);
                string extencion = Archivo.FileName;

                DataManager.InsertArchivoOrden(idOrden, ArchivoFisico, extencion, NombreArchivo);

            }

            List<SelectListItem> clientes = DataManager.ConvertListDOClienteToSelectListItem(DataManager.GetAllClientes());
            ViewBag.Clientes = clientes;

            List<SelectListItem> Productos = DataManager.ConvertListDOProductoToSelectListItem(DataManager.GetAllProductos());
            ViewBag.Productos = Productos;

            return View("Crear");

        }

        [HttpPost]
        public JsonResult GetAllOrdenes(string parametro)
        {
            //List<DO_Ordenes> listaOrdenes = DataManager.GetAllOrdenes();

            List<SelectListItem> Estatus = new List<SelectListItem>();

            Estatus = DataManager.ConvertListDOEstatusOrdenToSelectListItem(DataManager.GetAllEstatus());

            ViewBag.Estatus = Estatus;

            List<DO_C_Orcen> listaOrdenes = DataManager.GetAllDetalleOrden();

            var jsonResult = Json(listaOrdenes, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [ERPVerificaRol]
        public ActionResult DetailsOrden(int id)
        {

            List<SelectListItem> Estatus = new List<SelectListItem>();

            Estatus = DataManager.ConvertListDOEstatusOrdenToSelectListItem(DataManager.GetAllEstatus());

            ViewBag.Estatus = Estatus;
            return View();
        }

        [HttpPost]
        public JsonResult GetOrdenDetalle(int idOrden)
        {
            DO_Ordenes orden = DataManager.GetOrden(idOrden);

            var jsonResult = Json(orden, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult ActualizarDetalleOrden(int idDetalleOrden, int entregaParcial,string entregarA,int estatusOrden)
        {

            int r = DataManager.UpdateOrdenDetalle(idDetalleOrden, estatusOrden, entregaParcial, entregarA);

            var jsonResult = Json(r, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [ERPVerificaRol]
        public ActionResult CargarOrden()
        {

            List<SelectListItem> ListaClientes = DataManager.ConvertListDOClienteToSelectListItem(DataManager.GetAllClientes());

            ViewBag.Clientes = ListaClientes;

            return View();
        }

        [HttpPost]
        public ActionResult Import(HttpPostedFileBase excelfile)
        {
            string usuario = ((DO_Persona)Session["UsuarioConectado"]).Usuario;
            int idCliente = 1;

            List<SelectListItem> ListaClientes = DataManager.ConvertListDOClienteToSelectListItem(DataManager.GetAllClientes());

            ViewBag.Clientes = ListaClientes;

            if (excelfile == null || excelfile.ContentLength == 0)
            {
                ViewBag.Error = "Please select a excel file";
                return View("CargarOrden");
            }
            else
            {
                if (excelfile.FileName.EndsWith("xls")|| excelfile.FileName.EndsWith("xlsx"))
                {
                    string path = Server.MapPath("~/Content/" + Path.GetFileName(excelfile.FileName));
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                    excelfile.SaveAs(path);

                    //read data from excel file

                    DataTable dataTable = new DataTable();
                    try
                    {
                        using (SpreadsheetDocument spreadSheetDocument = SpreadsheetDocument.Open(path, false))
                        {
                            WorkbookPart workbookPart = spreadSheetDocument.WorkbookPart;
                            IEnumerable<Sheet> sheets = spreadSheetDocument.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
                            string relationshipId = sheets.First().Id.Value;
                            WorksheetPart worksheetPart = (WorksheetPart)spreadSheetDocument.WorkbookPart.GetPartById(relationshipId);
                            Worksheet workSheet = worksheetPart.Worksheet;
                            SheetData sheetData = workSheet.GetFirstChild<SheetData>();
                            IEnumerable<Row> rows = sheetData.Descendants<Row>();

                            foreach (Cell cell in rows.ElementAt(0))
                            {
                                dataTable.Columns.Add(GetCellValue(spreadSheetDocument, cell));
                            }

                            foreach (Row row in rows)
                            {
                                DataRow dataRow = dataTable.NewRow();
                                for (int i = 0; i < row.Descendants<Cell>().Count(); i++)
                                {
                                    dataRow[i] = GetCellValue(spreadSheetDocument, row.Descendants<Cell>().ElementAt(i));
                                }

                                dataTable.Rows.Add(dataRow);
                            }

                        }

                        dataTable.Rows.RemoveAt(0);
                    }
                    catch (Exception er)
                    {

                        throw;
                    }

                    List<DO_C_Orcen> Lista =  DataManager.ReadOrden(dataTable);

                    bool ingreso = DataManager.InsertOrdenFromFile(Lista, idCliente, usuario);

                    ViewBag.Error = ingreso ? "Datos cargados": "Upps, se genero un error, es posible que no se cargaron todos los datos.";
                    return View("CargarOrden");
                }
                else
                {
                    ViewBag.Error = "File type is encorrect<br>";
                    return View("CargarOrden");
                }
            }
        }
        
        private static string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
            string value = cell.CellValue.InnerXml;

            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
            }
            else
            {
                return value;
            }
        }
    }
}