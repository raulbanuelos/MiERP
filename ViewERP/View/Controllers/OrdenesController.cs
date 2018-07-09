using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using View.Models;

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
        
    }
}