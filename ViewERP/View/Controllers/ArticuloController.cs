using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using View.Models;

namespace View.Controllers
{
    public class ArticuloController : Controller
    {
        // GET: Articulo
        [ERPVerificaRol]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetAllArticulos(string parametro)
        {
            List<DO_Articulo> lista = DataManager.GetAllArticulos(((DO_Persona)Session["UsuarioConectado"]).idCompania);
            
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
        public JsonResult GuardarArticulo(string codigo, string descripocionCorta, string descripcionLarga, int stockMinimo, int stockMaximo,int idCategoria,bool isConsumible)
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

            int result = DataManager.InsertArticulo(articulo);

            var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;

        }

        [HttpPost]
        [ERPVerificaRol]
        public JsonResult GuardarCambiosArticulo(string codigo, string descripcionCorta, string descripcionLarga, int stockMinimo, int stockMaximo,bool isConsumible)
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

            int result = DataManager.UpdateArticulo(articulo);

            var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;

        }

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