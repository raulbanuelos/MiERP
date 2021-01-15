using Model;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebView.Models;

namespace WebView.Controllers
{
    public class VentasController : Controller
    {
        [ERPVerificaAccount]
        public ActionResult AgregarVenta()
        {
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;
            ViewBag.Articulos = DataManager.ConvertListDOArticuloToSelectListItem(DataManager.GetAllArticulos(idCompania));

            //Promotores

            List<DO_Persona> promotores = DataManager.GetAllPromotores(idCompania);
            promotores.Insert(0,new DO_Persona { idUsuario = 0, Nombre = "Ninguno" });

            ViewBag.Promotores = DataManager.ConvertListDoPersonaToSelectListItem(promotores);

            return View();
        }

        [HttpPost]
        public JsonResult GuardarVenta(int cantidad, DateTime fecha, int idArticulo, int idPromotor)
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

            //Checamos si el usuario eligió asignarla a un promotor
            if (idPromotor!= 0)
            {
                int promotorVenta = DataManager.InsertVentaPromotor(idVenta, idPromotor);
            }

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
        public JsonResult GetVentaDiaActualOrganizacion(string parametro)
        {
            int idOrganizacion = ((DO_Persona)Session["UsuarioConectado"]).idOrganizacion;

            double venta = DataManager.GetVentaDiaActualOrganizacion(idOrganizacion);

            var jsonResult = Json(venta, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        public JsonResult GetVentaSemanaActualOrganizacion(string parametro)
        {
            int idOrganizacion = ((DO_Persona)Session["UsuarioConectado"]).idOrganizacion;

            DO_Semana semanaActual = DataManager.GetSemanaActual();

            List<FO_Item> lista =  DataManager.GetVentaSemanalOrganizacionBySemanaByCompania(idOrganizacion, semanaActual.IdSemana);

            var jsonResult = Json(lista, JsonRequestBehavior.AllowGet);
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
        public JsonResult GetVentaSemanaActualByGerente(int idUsuario)
        {
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
        public JsonResult GetVentaSemanalDiaria(string parametro)
        {
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;

            DO_ChartData dO_ChartData = DataManager.GetVentaSemanalDiaria(idCompania);

            var jsonResult = Json(dO_ChartData, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetVentaSemanalDiariaGerente(int idCompania)
        {
            DO_ChartData dO_ChartData = DataManager.GetVentaSemanalDiaria(idCompania);

            var jsonResult = Json(dO_ChartData, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public JsonResult GetGananciaGerente(string parametro)
        {
            int idUsuario = ((DO_Persona)Session["UsuarioConectado"]).idUsuario;

            double gananciaTotal = DataManager.GetGananciaGerenteCurrentWeek(idUsuario);

            var jsonResult = Json(gananciaTotal, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult EliminarVenta(int idVenta)
        {
            #region Se borra la venta
            DO_Ventas venta = DataManager.GetVenta(idVenta);

            DO_Persona personaConectada = ((DO_Persona)Session["UsuarioConectado"]);
            List<DO_Almacen> almacens = DataManager.GetAllAlmacen(personaConectada.idCompania);
            DO_Almacen almacen = almacens[0];

            int r = DataManager.AddExistencia(almacen.idAlmacen, venta.IdArticulo, venta.Cantidad);

            r = DataManager.DeleteVentaPromotor(idVenta);
            r = DataManager.DeleteVentaDetails(idVenta);
            r = DataManager.DeleteVenta(idVenta);
            #endregion

            var jsonResult = Json(r, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GuardarCambiosVenta(int idVenta, int cantidad, DateTime fecha, int idArticulo, int idPromotor)
        {
            #region Se borra la venta
            DO_Ventas venta = DataManager.GetVenta(idVenta);

            DO_Persona personaConectada = ((DO_Persona)Session["UsuarioConectado"]);
            List<DO_Almacen> almacens = DataManager.GetAllAlmacen(personaConectada.idCompania);
            DO_Almacen almacen = almacens[0];

            int r = DataManager.AddExistencia(almacen.idAlmacen, venta.IdArticulo, venta.Cantidad);

            r = DataManager.DeleteVentaPromotor(idVenta);
            r = DataManager.DeleteVentaDetails(idVenta);
            r = DataManager.DeleteVenta(idVenta);
            #endregion

            #region Registro venta
            int idUsuario = ((DO_Persona)Session["UsuarioConectado"]).idUsuario;
            double precio = DataManager.GetPrecioMaster(idArticulo);
            double monto = cantidad * precio;

            idVenta = DataManager.InsertVenta(idUsuario, monto, fecha);

            r = DataManager.InsertDetailVenta(idVenta, idArticulo, cantidad, precio);

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

            int result = DataManager.InsertSalidaArticuloAlmacen(almacens[0].idAlmacen, "SALIDA VENTA", personaConectada.Usuario, articulos);

            #endregion

            //Checamos si el usuario eligió asignarla a un promotor
            if (idPromotor != 0)
            {
                int promotorVenta = DataManager.InsertVentaPromotor(idVenta, idPromotor);
            } 
            #endregion

            var jsonResult = Json(r, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        
        public ActionResult Edit(int id = 0, DO_Ventas venta = null)
        {
            DO_Ventas objVenta = DataManager.GetVenta(id);
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;

            List<DO_Persona> promotores = DataManager.GetAllPromotores(idCompania);
            List<SelectListItem> selectListItems = DataManager.ConvertListDoPersonaToSelectListItem(promotores);

            List<SelectListItem> articulos = DataManager.ConvertListDOArticuloToSelectListItem(DataManager.GetAllArticulos(idCompania));

            foreach (var item in articulos)
            {
                if (Convert.ToInt32(item.Value) == objVenta.IdArticulo)
                {
                    item.Selected = true;
                }
            }

            foreach (var item in selectListItems)
            {
                if (Convert.ToInt32(item.Value) == objVenta.IdPromotor)
                {
                    item.Selected = true;
                }
            }

            ViewBag.Articulos = articulos;
            ViewBag.Promotores = selectListItems;

            return View(objVenta);
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetVentasCurrentWeek(string parametro)
        {
            int idUsuario = ((DO_Persona)Session["UsuarioConectado"]).idUsuario;
            
            List<DO_Ventas> ventas = DataManager.GetVentasCurrentWeek(idUsuario);
            
            var jsonResult = Json(ventas, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
    }
}