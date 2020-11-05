using Model;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebView.Models;

namespace WebView.Controllers
{
    public class VentasController : Controller
    {
        // GET: Ventas
        public ActionResult AgregarVenta()
        {
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;
            ViewBag.Articulos = DataManager.ConvertListDOArticuloToSelectListItem(DataManager.GetAllArticulos(idCompania));
            return View();
        }

        [HttpPost]
        public JsonResult GuardarVenta(int cantidad, DateTime fecha, int idArticulo)
        {
            int idUsuario = ((DO_Persona)Session["UsuarioConectado"]).idUsuario;
            DO_Persona personaConectada = ((DO_Persona)Session["UsuarioConectado"]);

            double precio = DataManager.GetPrecioMaster(idArticulo);
            double monto = cantidad * precio;

            int idVenta = DataManager.InsertVenta(idUsuario, monto, fecha);

            int r = DataManager.InsertDetailVenta(idVenta, idArticulo, cantidad, precio);

            #region Registro en almacen
            DO_Articulo articulo = DataManager.GetArticulo(idArticulo);
            
            List<DO_DetalleSalidaArticulo> articulos = new List<DO_DetalleSalidaArticulo>();
            DO_DetalleSalidaArticulo dO_DetalleSalida = new DO_DetalleSalidaArticulo();
            dO_DetalleSalida.cantidad = cantidad;
            dO_DetalleSalida.codigo = articulo.Codigo;
            dO_DetalleSalida.condicion = "NUEVO";
            dO_DetalleSalida.Descripcion = articulo.Descripcion;
            dO_DetalleSalida.idCodigo = idArticulo;
            articulos.Add(dO_DetalleSalida);

            List<DO_Almacen> almacens = DataManager.GetAllAlmacen(personaConectada.idCompania);

            int result = DataManager.InsertSalidaArticuloAlmacen(almacens[0].idAlmacen, "SALIDA VENTA", personaConectada.Usuario, articulos);

            #endregion

            var jsonResult = Json(r, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetVentaDiaActual(string parametro)
        {
            int idUsuario = ((DO_Persona)Session["UsuarioConectado"]).idUsuario;
            double venta = DataManager.GetVentaDiaActual(idUsuario);

            var jsonResult = Json(venta, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetVentaMesActual(string parametro)
        {
            int idUsuario = ((DO_Persona)Session["UsuarioConectado"]).idUsuario;
            double venta = DataManager.GetVentaMesActual(idUsuario);

            var jsonResult = Json(venta, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetVentaSemanaActual(string parametro)
        {
            int idUsuario = ((DO_Persona)Session["UsuarioConectado"]).idUsuario;
            double venta = DataManager.GetVentaSemanaActual(idUsuario);

            var jsonResult = Json(venta, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetVentaUltimosMeses(string parametro)
        {
            int idUsuario = ((DO_Persona)Session["UsuarioConectado"]).idUsuario;
            List<FO_Item> lista = DataManager.GetVentaUltimosMeses(idUsuario);

            var jsonResult = Json(lista, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }


        [HttpPost]
        public JsonResult GetLastVentas(string parametro)
        {
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;

            List<DO_Ventas> lastVentas = DataManager.GetListLastVentas(idCompania);

            var jsonResult = Json(lastVentas, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
    }
}