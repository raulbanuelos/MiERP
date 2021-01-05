using Model;
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
        public JsonResult CrearCuenta(string nombre, string email, string contrasena, string telefono, string direccion, int idRol)
        {

            DO_Persona dO_Persona1 =  DataManager.GetPersona(email);

            if (dO_Persona1.ID_ROL == 2 || dO_Persona1.idUsuario == 0)
            {
                //Se establece el plan de 7 dias libres por default.
                int idPlan = 1;
                int idCompania = DataManager.InsertCompania(nombre, "RFC", direccion, telefono, email, idPlan);

                if (idCompania > 0)
                {
                    DO_Persona dO_Persona = new DO_Persona();
                    dO_Persona.Nombre = nombre;
                    dO_Persona.ApellidoMaterno = string.Empty;
                    dO_Persona.ApellidoPaterno = string.Empty;
                    dO_Persona.idCompania = idCompania;
                    dO_Persona.ID_ROL = idRol;
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

                    if (idRol == 3)
                    {
                        DataManager.InsertOrganizacion(idCompania, "ORG." + nombre);
                    }

                    var jsonResult = Json("Cuenta activada exitosamente", JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;

                    return jsonResult;
                }
            }
            else
            {
                var jsonResult = Json("El correo ya existe, por favor ingresa otro.", JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }

            return null;
        }
    }
}