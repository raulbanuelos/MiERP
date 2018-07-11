using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using View.Models;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
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


                    Excel.Application application = new Excel.Application();
                    Excel.Workbook workbook = application.Workbooks.Open(path).ActiveSheet;
                    Excel.Worksheet worksheet = workbook.ActiveSheet;
                    Excel.Range range = worksheet.UsedRange;

                    List<DO_OrdenesDetalle> orden = new List<DO_OrdenesDetalle>();



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