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
        public ActionResult Index()
        {
            return View(DataManager.GetAllArticulos(((DO_Persona)Session["UsuarioConectado"]).idCompania));
        }

        public ActionResult Edit(int id = 0, DO_Articulo articulo = null)
        {
            if (id != 0 && articulo.idArticulo == 0)
            {
                return View(DataManager.GetArticulo(id));
            }
            else
            {
                DataManager.UpdateArticulo(articulo);
                return RedirectToAction("Index", "Articulo");
            }
        }

        [HttpPost]
        public JsonResult GetNewCode(string idCategoria)
        {
            DO_Articulo modelo = new DO_Articulo();

            modelo.Codigo = DataManager.GetNextCodigoArticulo(idCategoria);

            var jsonResult = Json(modelo, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GuardarArticulo(string codigo, string descripocionCorta, string descripcionLarga, int stockMinimo, int stockMaximo,int idCategoria)
        {
            BarcodeLib.Barcode codigoBarras = new BarcodeLib.Barcode();
            Image imagen = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, codigo, Color.Black, Color.White, 400, 100);

            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;

            DO_Articulo articulo = new DO_Articulo();

            articulo.Codigo = codigo;
            articulo.CodigoDeBarras = DataManager.ImageToByteArray(imagen);
            articulo.Descripcion = descripocionCorta;
            articulo.DescripcionLarga = descripcionLarga;
            articulo.ID_CATEGORIA = idCategoria;
            articulo.stockMax = stockMaximo;
            articulo.stockMin = stockMinimo;
            articulo.idCompania = idCompania;

            int result = DataManager.InsertArticulo(articulo);

            var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;

        }

        public ActionResult Create(DO_Articulo articulo = null)
        {
            int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;
            ViewBag.CategoriasArticulo = DataManager.GetAllCategoriaArticuloSelectListItem(idCompania);

            return View();
        }

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

        public ActionResult Details(int id)
        {
            DO_Articulo articulo = DataManager.GetArticulo(id);

            return View(articulo);
        }
    }
}