using Model;
using System.Web.Mvc;
using WebView.Models;

namespace WebView.Controllers
{
    public class ContactosController : Controller
    {
        [ERPVerificaAccount]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GUardarContacto(string nombre, string rfc, string telefono, string celular, string direccion, string correo)
        {
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;

            DO_Persona dO_Persona = new DO_Persona();
            dO_Persona.Nombre = nombre;
            dO_Persona.idCompania = idCompania;
            dO_Persona.ID_ROL = 2;
            dO_Persona.ApellidoPaterno = string.Empty;
            dO_Persona.ApellidoMaterno = string.Empty;
            dO_Persona.Usuario = correo;
            dO_Persona.Contrasena = "87542112";

            int r = DataManager.InsertPersona(dO_Persona);

            DO_Proveedor dO_Proveedor = new DO_Proveedor();
            dO_Proveedor.idCompania = idCompania;
            dO_Proveedor.Nombre = "BODEGA " + nombre;
            dO_Proveedor.RFC = rfc;
            dO_Proveedor.Telefono1 = telefono;
            dO_Proveedor.Telefono2 = celular;
            dO_Proveedor.Direccion = direccion;
            dO_Proveedor.Correo = correo;

            int q = DataManager.InsertProveedor(dO_Proveedor);

            DO_Persona personaConectada = ((DO_Persona)Session["UsuarioConectado"]);

            DataManager.InsertBitacora(personaConectada.Nombre + " " + personaConectada.Usuario, "Se creó un contacto llamado: " + dO_Persona.Nombre);

            var jsonResult = Json(r, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
    }
}