using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using View.Models;

namespace View.Controllers
{
    public class SalidasAlmacenController : Controller
    {
        // GET: SalidasAlmacen
        [ERPVerificaRol]
        public ActionResult DarSalida()
        {
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;

            ViewBag.Personas =  DataManager.ConvertListDOPersonaToSelectListItem(DataManager.GetAllPersona(idCompania));
            ViewBag.Articulos = DataManager.ConvertListDOArticuloToSelectListItem(DataManager.GetAllArticulos(idCompania));
            ViewBag.Almacenes = DataManager.ConvertListDOAlmacenToSelectListItem(DataManager.GetAllAlmacen(idCompania));

            List<SelectListItem> condicionesEntrega = new List<SelectListItem>();

            condicionesEntrega.Add(new SelectListItem { Text = "NUEVO", Value = "NUEVO" });
            condicionesEntrega.Add(new SelectListItem { Text = "USADO", Value = "USADO" });
            condicionesEntrega.Add(new SelectListItem { Text = "DAÑADO", Value = "DAÑADO" });


            ViewBag.CondicionesEntrega = condicionesEntrega;


            return View();
        }

        public JsonResult GuardarSalida(int idAlmacen, int personaSolicito,List<DO_DetalleSalidaArticulo> articulos)
        {

            //articulos
            int[] idsArticulo = new int[1];
            string[] codigos = new string[1];
            double[] cantidades = new double[1];
            string[] condicionsSalidas = new string[1];
            
            DO_Result_SalidaAlmacen re = new DO_Result_SalidaAlmacen();

            DO_Persona personaConectada = ((DO_Persona)Session["UsuarioConectado"]);
            DO_Persona personaSolicita = DataManager.GetPersona(personaSolicito);

            int result = DataManager.InsertSalidaArticuloAlmacen(idAlmacen, personaSolicita.Usuario, personaConectada.Usuario,articulos);

            re.idSalidaAlmacen = result;

            var jsonResult = Json(re, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;

        }
        

        public ActionResult Detalles(int id)
        {
            DO_Result_SalidaAlmacen m = DataManager.GetSalida(id);

            return View(m);

        }
    }
}