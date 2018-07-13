using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using View.Models;
using System.IO;
using System.Data.OleDb;
using System.Data;

namespace View.Controllers

{
    public class OrdenesController : Controller
    {
        // GET: Ordenes
        [ERPVerificaRol]
        public ActionResult Index()
        {
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
            List<DO_Ordenes> listaOrdenes = DataManager.GetAllOrdenes();

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

                    string conexion = "Provider=Microsoft.ACE.OLEDB.13.0;Data Source = " + path + " ;Extended Properties = \"Excel 8.0;HDR = Yes\"";

                    OleDbConnection conector = default(OleDbConnection);
                    conector = new OleDbConnection(conexion);
                    conector.Open();

                    OleDbCommand consulta = default(OleDbCommand);
                    consulta = new OleDbCommand("select * from [Hoja1$]",conector);

                    OleDbDataAdapter adaptador = new OleDbDataAdapter();
                    adaptador.SelectCommand = consulta;

                    DataSet ds = new DataSet();

                    adaptador.Fill(ds);

                    conector.Close();

                    //Excel.Application application = new Excel.Application();
                    //Excel.Workbook workbook = application.Workbooks.Open(path).ActiveSheet;
                    //Excel.Worksheet worksheet = workbook.ActiveSheet;
                    //Excel.Range range = worksheet.UsedRange;

                    //List<DO_CargaOrden> ordenes = new List<DO_CargaOrden>();

                    //for (int row = 1; row < range.Rows.Count; row++)
                    //{
                    //    DO_CargaOrden orden = new DO_CargaOrden();
                    //    orden.Proyecto = ((Excel.Range)range.Cells[row, 2]).Text;
                    //    orden.PlantaDestino = ((Excel.Range)range.Cells[row, 3]).Text;
                    //    orden.EquipoRequerido = ((Excel.Range)range.Cells[row, 4]).Text;
                    //    orden.EnviarA = ((Excel.Range)range.Cells[row, 5]).Text;
                    //    orden.CantidadTotal = ((Excel.Range)range.Cells[row, 6]).Text;
                    //    if(((Excel.Range)range.Cells[row, 7]).Text == "")
                    //    {
                    //        orden.EntregaParcial = 0;
                    //    }
                    //    else
                    //    {
                    //        orden.EntregaParcial = ((Excel.Range)range.Cells[row, 7]).Text;
                    //    }

                    //    orden.Entrega = ((Excel.Range)range.Cells[row, 8]).Text;
                    //    orden.NoVale = ((Excel.Range)range.Cells[row, 9]).Text;
                    //    orden.Requisicion = ((Excel.Range)range.Cells[row, 10]).Text;
                    //    orden.FechaPedido = ((Excel.Range)range.Cells[row, 11]).Text;
                    //    orden.FechaEntrega = ((Excel.Range)range.Cells[row, 12]).Text;
                    //    orden.OrdenCompra = ((Excel.Range)range.Cells[row, 13]).Text;


                    //    ordenes.Add(orden);
                    //}

                    ViewBag.Error = "Archivo cargado";
                    return View("CargarOrden");
                }
                else
                {
                    ViewBag.Error = "File type is encorrect<br>";
                    return View("CargarOrden");
                }
            }


            
        }

    }
}