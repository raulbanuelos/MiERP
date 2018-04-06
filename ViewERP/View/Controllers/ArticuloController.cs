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

        public ActionResult Create(DO_Articulo articulo = null)
        {
            if (!string.IsNullOrEmpty(articulo.Codigo))
            {
                articulo.idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;
                DataManager.InsertArticulo(articulo);
                return RedirectToAction("Index", "Articulo");
            }
            else
            {
                BarcodeLib.Barcode a = new BarcodeLib.Barcode();
                
                DO_Articulo elmodel = new DO_Articulo();

                //HardCode
                elmodel.Codigo = "05006001";

                BarcodeLib.Barcode codigoBarras = new BarcodeLib.Barcode();
                codigoBarras.IncludeLabel = true;
                Image imagen;

                imagen = codigoBarras.Encode(BarcodeLib.TYPE.CODE128, elmodel.Codigo, Color.Black, Color.White, 400, 100);

                elmodel.CodigoDeBarras = DataManager.ImageToByteArray(imagen);

                int idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;
                elmodel.Categorias = DataManager.GetAllCategoriaArticuloSelectListItem(idCompania);
                elmodel.idCompania = idCompania;
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
                return RedirectToAction("Index", "Articulo");
            }
        }
    }
}