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

                DO_CategoriaArticulo categoriaArticulo = new DO_CategoriaArticulo();

                categoriaArticulo.idCompania = idCompania;
                categoriaArticulo.NombreCategoria = "ARTICULOS DE VENTA";
                categoriaArticulo.numeroCategoria = "01";

                int c = DataManager.InsertCategoriaArticulo(categoriaArticulo);

                DO_CategoriaArticulo categoriaArticulo1 = new DO_CategoriaArticulo();
                categoriaArticulo1.idCompania = idCompania;
                categoriaArticulo1.NombreCategoria = "OTROS";
                categoriaArticulo1.numeroCategoria = "02";

                c = DataManager.InsertCategoriaArticulo(categoriaArticulo1);

                DO_Proveedor proveedor = new DO_Proveedor();
                proveedor.Correo = "miproveedor@email.com";
                proveedor.Direccion = "Dirección";
                proveedor.idCompania = idCompania;
                proveedor.Nombre = "BODEGA ORIGEN 1";
                proveedor.RFC = "RFC";
                proveedor.Telefono1 = "TELEFONO 1";
                proveedor.Telefono2 = "TELEFONO 2";
                int rp = DataManager.InsertProveedor(proveedor);

                var jsonResult = Json(r, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;

            }

            return null;
            
        }
    }
}