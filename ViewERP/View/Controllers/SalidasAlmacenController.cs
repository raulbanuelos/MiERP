using System;
using System.Collections.Generic;
using System.Linq;
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

        public JsonResult GuardarSalida(int idAlmacen, int personaSolicito, int idArticulo,string condicionEntrega,double cantidad)
        {
            string respuesta = "";

            if (DataManager.verifiExistencia(idAlmacen,idArticulo,cantidad))
            {
                DO_Persona personaConectada = ((DO_Persona)Session["UsuarioConectado"]);
                DO_Persona personaSolicita = DataManager.GetPersona(personaSolicito);
                
                int result = DataManager.InsertSalidaArticuloAlmacen(idAlmacen, idArticulo, personaSolicita.Usuario, cantidad, condicionEntrega, personaConectada.Usuario);

                if (result > 0)
                {
                    respuesta = "La salida se registro correctamente.";
                }
                else
                {
                    respuesta = "Se generó un error al solicitar la cantidad, por favor intente mas tarde.";
                }
            }
            else
            {
                respuesta = "No existe en el almacen la cantidad solicitada";
            }
            
            var jsonResult = Json(respuesta, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;

        }
    }
}