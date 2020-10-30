using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using View.Models;

namespace View.Controllers
{
    public class ExistenciaController : Controller
    {
        // GET: Existencia
        [ERPVerificaRol]
        public ActionResult Index()
        {
            //Codigo para obtener el id del almacen de la persona conectada.
            //Solo se maneja el primer Almacen.
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;
            List<DO_Almacen> dO_Almacens = DataManager.GetAllAlmacen(idCompania);
            int idAlmacen = dO_Almacens[0].idAlmacen;

            //Retornamos la vista con la lista de existencia.
            return View(DataManager.GetExistenciaArticulos(idAlmacen));
        }
    }
}