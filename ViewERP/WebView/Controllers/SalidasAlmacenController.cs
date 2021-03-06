﻿using Model;
using System.Collections.Generic;
using System.Web.Mvc;
using WebView.Models;

namespace WebView.Controllers
{
    public class SalidasAlmacenController : Controller
    {
        [ERPVerificaAccount]
        [ERPVerificaRol]
        public ActionResult DarSalida()
        {
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;

            ViewBag.Personas = DataManager.ConvertListDOPersonaToSelectListItem(DataManager.GetAllPersona(idCompania));

            ViewBag.Almacenes = DataManager.ConvertListDOAlmacenToSelectListItem(DataManager.GetAllAlmacen(idCompania));

            ViewBag.Articulos = DataManager.ConvertListDOArticuloToSelectListItem(DataManager.GetAllArticulos(idCompania));

            List<SelectListItem> condicionesEntrega = new List<SelectListItem>();

            condicionesEntrega.Add(new SelectListItem { Text = "NUEVO", Value = "NUEVO" });
            condicionesEntrega.Add(new SelectListItem { Text = "USADO", Value = "USADO" });
            condicionesEntrega.Add(new SelectListItem { Text = "DAÑADO", Value = "DAÑADO" });


            ViewBag.CondicionesEntrega = condicionesEntrega;


            return View();
        }

        public JsonResult GuardarSalida(int idAlmacen, int personaSolicito, List<DO_DetalleSalidaArticulo> articulos)
        {
            DO_Result_SalidaAlmacen re = new DO_Result_SalidaAlmacen();

            DO_Persona personaConectada = ((DO_Persona)Session["UsuarioConectado"]);
            DO_Persona personaSolicita = DataManager.GetPersona(personaSolicito);

            int result = DataManager.InsertSalidaArticuloAlmacen(idAlmacen, personaSolicita.Usuario, personaConectada.Usuario, articulos);

            re.idSalidaAlmacen = result;
            if (result != 0)
            {
                re.ResultCode = 1;
            }

            DataManager.InsertBitacora(personaConectada.Nombre + " " + personaConectada.Usuario, "Se crea una salida de almacen");

            var jsonResult = Json(re, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;

        }

        public JsonResult ChecarExistencia(int idAlmacen, int idArticulo, double cantidadSolicitada)
        {
            double cantidadAlmacen = DataManager.GetExistenciaArticulo(idAlmacen, idArticulo);
            bool respuesta = false;

            respuesta = cantidadAlmacen >= cantidadSolicitada ? true : false;

            var jsonResult = Json(respuesta, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [ERPVerificaRol]
        public ActionResult ValeSalida(int idMovimientoSalida)
        {
            DO_ValeSalidaAlmacen obj = new DO_ValeSalidaAlmacen();

            obj = DataManager.GetValeSalida(idMovimientoSalida);

            return View(obj);
        }

        [HttpPost]
        public JsonResult GetAllCategoriasArticulos(string parametro)
        {
            List<DO_CategoriaArticulo> listaCategoriaArticulo = new List<DO_CategoriaArticulo>();
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;

            listaCategoriaArticulo = DataManager.ConvertDOArticuloToCategoriaArticulo(DataManager.GetAllArticulos(idCompania));

            var jsonResult = Json(listaCategoriaArticulo, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [ERPVerificaRol]
        public ActionResult RetornoMaterial()
        {
            return View();
        }

        [ERPVerificaRol]
        public ActionResult VerDetalleSalidaAbierta(string folio)
        {

            return View();
        }

        [HttpPost]
        public JsonResult GetSalidasAbiertas()
        {
            List<DO_MovimientoSalidaAlmacen> ListaSalidas = new List<DO_MovimientoSalidaAlmacen>();

            ListaSalidas = DataManager.GetSalidasAbiertas();

            var jsonResult = Json(ListaSalidas, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;

        }

        [HttpPost]
        public JsonResult GetDetalleSalida(string folio)
        {
            DO_MovimientoSalidaAlmacen salida = new DO_MovimientoSalidaAlmacen();

            salida = DataManager.GetDetalleMovimientoSalidaAlmacen(folio);

            var jsonResult = Json(salida, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public JsonResult UpdateRetornoArticulo(int idDetalle, string condiciones, double cantidad)
        {
            int r = DataManager.RetornoArticulo(idDetalle, condiciones, cantidad);

            var jsonResult = Json(r, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}