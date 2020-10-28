using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using WebView.Models;

namespace WebView.Controllers
{
    public class CreateAccountController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CrearCuenta(string nombre, string email, string contrasena )
        {
            int idCompania = DataManager.InsertCompania(nombre, "RFC", "Dirección", "Telefono", email);

            if (idCompania > 0)
            {
                DO_Persona dO_Persona = new DO_Persona();
                dO_Persona.Nombre = nombre;
                dO_Persona.ApellidoMaterno = string.Empty;
                dO_Persona.ApellidoPaterno = string.Empty;
                dO_Persona.idCompania = idCompania;
                dO_Persona.ID_ROL = 1;
                dO_Persona.Contrasena = contrasena;
                dO_Persona.Usuario = email;

                int r = DataManager.InsertPersona(dO_Persona);

                DO_Almacen almacen = new DO_Almacen();
                almacen.idCompania = idCompania;
                almacen.Nombre = "Mi Bodega";
                almacen.Descripcion = "Esta es mi bodega";

                int rAlmacen = DataManager.InsertAlmacen(almacen);

                var jsonResult = Json(r, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;

            }

            return null;
            
        }
    }
}