using Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebView.Models;

namespace WebView.Controllers
{
    public class ExistenciasController : Controller
    {
        [HttpPost]
        public JsonResult GetExistencias(string parametro)
        {
            //Codigo para obtener el id del almacen de la persona conectada.
            //Solo se maneja el primer Almacen.
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;
            List<DO_Almacen> dO_Almacens = DataManager.GetAllAlmacen(idCompania);
            int idAlmacen = dO_Almacens[0].idAlmacen;

            List<DO_Existencia> dO_Existencias = DataManager.GetExistenciaArticulos(idAlmacen);

            dO_Existencias =  dO_Existencias.OrderByDescending(x => x.Cantidad).ToList();

            var jsonResult = Json(dO_Existencias, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetExistenciasByCompania(int idCompania)
        {
            //Codigo para obtener el id del almacen de la persona conectada.
            //Solo se maneja el primer Almacen.
            List<DO_Almacen> dO_Almacens = DataManager.GetAllAlmacen(idCompania);
            int idAlmacen = dO_Almacens[0].idAlmacen;

            List<DO_Existencia> dO_Existencias = DataManager.GetExistenciaArticulos(idAlmacen);

            dO_Existencias = dO_Existencias.OrderByDescending(x => x.Cantidad).ToList();

            var jsonResult = Json(dO_Existencias, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
    }
}