using Model;
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
            DO_Result_SalidaAlmacen re = new DO_Result_SalidaAlmacen();

            if (DataManager.verifiExistencia(idAlmacen,idArticulo,cantidad))
            {
                DO_Persona personaConectada = ((DO_Persona)Session["UsuarioConectado"]);
                DO_Persona personaSolicita = DataManager.GetPersona(personaSolicito);
                
                int result = DataManager.InsertSalidaArticuloAlmacen(idAlmacen, idArticulo, personaSolicita.Usuario, cantidad, condicionEntrega, personaConectada.Usuario);
                
                if (result > 0)
                {
                    re.idSalidaAlmacen = result;
                    re.NombreSolicitante = personaSolicita.ToString();
                    re.NombreAtendio = personaConectada.ToString();
                    re.FechaSolicitud = DateTime.Now;
                    re.CodigoArticulo = DataManager.GetArticulo(idArticulo).Codigo;
                    re.ResultCode = 1;
                    re.CantidadSolicitada = cantidad;
                    re.Respuesta = "La salida se registro correctamente.";

                    //Verificamos el stock mínimo
                    double nuevaExistencia = DataManager.GetExistenciaArticulo(idAlmacen, idArticulo);
                    double stockMinimo = DataManager.GetArticulo(idArticulo).stockMin;

                    if (nuevaExistencia <= stockMinimo)
                    {
                        re.Respuesta = re.Respuesta + "\n" + "La existencia del artículo es inferior al stock mínimo. El artículo se ingresará a la lista de alertas.";

                    }
                }
                else
                {
                    re.Respuesta = "Se generó un error al solicitar la cantidad, por favor intente mas tarde.";
                    re.ResultCode = 3;
                }
            }
            else
            {
                re.Respuesta = "No existe en el almacen la cantidad solicitada";
                re.ResultCode = 2;
            }
            
            var jsonResult = Json(re, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;

        }

        [ERPVerificaRol]
        public ActionResult Details(int id)
        {
            DO_Result_SalidaAlmacen m = DataManager.GetSalida(id);
            
            return View(m);
        }
        
    }
}