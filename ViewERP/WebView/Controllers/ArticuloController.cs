using Model;
using System.Collections.Generic;
using System.Drawing;
using System.Web.Mvc;
using WebView.Models;

namespace WebView.Controllers
{
    public class ArticuloController : Controller
    {
        [ERPVerificaRol]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetAllCategoria(string parametro)
        {
            int idCompania = ((Models.DO_Persona)Session["UsuarioConectado"]).idCompania;

            List<DO_CategoriaArticulo> ListaCategorias = Models.DataManager.GetAllCategoriaArticulo(idCompania);

            var jsonResult = Json(ListaCategorias, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;

        }

        [HttpPost]
        public JsonResult GetAllArticulos(string parametro)
        {
            List<DO_Articulo> lista = Models.DataManager.GetAllArticulos(((Models.DO_Persona)Session["UsuarioConectado"]).idCompania);

            var jsonResult = Json(lista, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [ERPVerificaRol]
        public ActionResult Edit(int id = 0, DO_Articulo articulo = null)
        {
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;
            ViewBag.CategoriasArticulo = DataManager.GetAllCategoriaArticuloSelectListItem(idCompania);
            return View(DataManager.GetArticulo(id));
        }

        [HttpPost]
        [ERPVerificaRol]
        public JsonResult GetNewCode(string idCategoria)
        {
            DO_Articulo modelo = new DO_Articulo();

            modelo.Codigo = DataManager.GetNextCodigoArticulo(idCategoria);

            var jsonResult = Json(modelo, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        [ERPVerificaRol]
        public JsonResult GuardarArticulo(string codigo, string descripocionCorta, string descripcionLarga, int stockMinimo, int stockMaximo, int idCategoria, bool isConsumible, double precioUnidad, double precioMaster, double precioPromotor, double precioGerente, int inventarioInicial)
        {
            BarcodeLib.Barcode codigoBarras = new BarcodeLib.Barcode();
            codigoBarras.IncludeLabel = true;
            Image imagen = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, codigo, Color.Black, Color.White, 400, 100);

            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;

            DO_Articulo articulo = new DO_Articulo();

            articulo.Codigo = codigo;
            articulo.CodigoDeBarras = DataManager.ImageToByteArray(imagen);
            articulo.Descripcion = descripocionCorta;
            articulo.NumeroDeSerie = descripcionLarga;
            articulo.ID_CATEGORIA = idCategoria;
            articulo.stockMax = stockMaximo;
            articulo.stockMin = stockMinimo;
            articulo.idCompania = idCompania;
            articulo.IsConsumible = isConsumible;

            int idArticulo = DataManager.InsertArticulo(articulo);

            int idDetailsArticulo = DataManager.InsertDetailsArticulo(idArticulo, precioUnidad, precioMaster, precioPromotor, precioGerente);

            DataManager.InsertInitialStock(idCompania, idArticulo, inventarioInicial);

            DO_Persona personaConectada = ((DO_Persona)Session["UsuarioConectado"]);

            DataManager.InsertBitacora(personaConectada.Nombre + " " + personaConectada.Usuario, "Se creó un articulo llamado: " + descripocionCorta);

            var jsonResult = Json(idDetailsArticulo, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;

        }

        [HttpPost]
        [ERPVerificaAccount]
        [ERPVerificaRol]
        public JsonResult GuardarCambiosArticulo(string codigo, string descripcionCorta, string descripcionLarga, int stockMinimo, int stockMaximo, bool isConsumible, double precioUnidad, double precioMaster, double precioGerente, double precioPromotor, int idArticulo)
        {
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;
            DO_Articulo articulo = new DO_Articulo();
            articulo.Codigo = codigo;
            articulo.Descripcion = descripcionCorta;
            articulo.NumeroDeSerie = descripcionLarga;
            articulo.stockMax = stockMaximo;
            articulo.stockMin = stockMinimo;
            articulo.idCompania = idCompania;
            articulo.IsConsumible = isConsumible;
            articulo.PRECIO_UNIDAD = precioUnidad;
            articulo.PRECIO_MASTER = precioMaster;
            articulo.PRECIO_GERENTE = precioGerente;
            articulo.PRECIO_PROMOTOR = precioPromotor;
            articulo.idArticulo = idArticulo;

            int result = DataManager.UpdateArticulo(articulo);

            result = DataManager.UpdateDetailsArticulo(articulo.idArticulo, articulo.PRECIO_UNIDAD, articulo.PRECIO_MASTER, articulo.PRECIO_PROMOTOR, articulo.PRECIO_GERENTE);

            DO_Persona personaConectada = ((DO_Persona)Session["UsuarioConectado"]);

            DataManager.InsertBitacora(personaConectada.Nombre + " " + personaConectada.Usuario, "Se edito la información del articulo llamado: " + articulo.Descripcion);

            var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;

        }

        [ERPVerificaAccount]
        [ERPVerificaRol]
        public ActionResult Create(DO_Articulo articulo = null)
        {
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;
            ViewBag.CategoriasArticulo = DataManager.GetAllCategoriaArticuloSelectListItem(idCompania);
            return View();
        }

        [ERPVerificaRol]
        public ActionResult Delete(int id = 0)
        {
            if (id != 0)
            {
                DataManager.DeleteArticulo(id);
                return RedirectToAction("Index", "Articulo");
            }
            else
            {
                return RedirectToAction("Index", "Articulo");
            }
        }

        [ERPVerificaRol]
        public ActionResult Details(int id)
        {
            DO_Articulo articulo = DataManager.GetArticulo(id);

            return View(articulo);
        }

        [HttpPost]
        public JsonResult FiltarCategorias(List<int> categorias)
        {
            List<DO_Articulo> lista = new List<DO_Articulo>();
            if (categorias != null)
            {
                lista = DataManager.GetAllArticulos(categorias);
            }
            else
            {
                lista = DataManager.GetAllArticulos(((DO_Persona)Session["UsuarioConectado"]).idCompania);
            }

            var jsonResult = Json(lista, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
    }
}