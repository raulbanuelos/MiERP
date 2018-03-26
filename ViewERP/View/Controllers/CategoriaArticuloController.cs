using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using View.Models;

namespace View.Controllers
{
    public class CategoriaArticuloController : Controller
    {
        // GET: CategoriaArticulo
        public ActionResult Index()
        {
            return View(DataManager.GetAllCategoriaArticulo());
        }

        public ActionResult Edit(int id = 0, DO_CategoriaArticulo categoriaArticulo = null)
        {

            if (id != 0 && categoriaArticulo.idCategoriaArticulo == 0)
            {
                return View(DataManager.GetCategoriaArticulo(id));
            }
            else
            {
                DataManager.UpdateCategoriaArticulo(categoriaArticulo);
                return RedirectToAction("Index", "CategoriaArticulo");
            }
        }

        public ActionResult Create(DO_CategoriaArticulo categoriaArticulo = null)
        {
            if (!string.IsNullOrEmpty(categoriaArticulo.NombreCategoria))
            {
                DataManager.InsertCategoriaArticulo(categoriaArticulo);
                return RedirectToAction("Index", "CategoriaArticulo");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Delete(int id = 0)
        {
            if (id != 0)
            {
                DataManager.DeleteCategoriaArticulo(id);
                return RedirectToAction("Index", "CategoriaArticulo");
            }
            else
            {
                return RedirectToAction("Index", "CategoriaArticulo");
            }
        }
    }
}