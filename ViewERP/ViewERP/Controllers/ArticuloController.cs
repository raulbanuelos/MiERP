using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewERP.Models;

namespace ViewERP.Controllers
{
    public class ArticuloController : Controller
    {
        // GET: Articulo
        public ActionResult Index()
        {
            //HardCode
            return View(DataManager.GetAllArticulos(1));
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

        public ActionResult Create(DO_Articulo articulo = null)
        {
            if (!string.IsNullOrEmpty(articulo.Codigo))
            {
                DataManager.InsertArticulo(articulo);
                return RedirectToAction("Index", "Articulo");
            }
            else
            {
                DO_Articulo elmodel = new DO_Articulo();

                elmodel.Categorias = DataManager.GetAllCategoriaArticulo();

                return View(elmodel);
            }
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
                DataManager.DeleteCategoriaArticulo(id);
                return RedirectToAction("Index", "Articulo");
            }
        }
    }
}