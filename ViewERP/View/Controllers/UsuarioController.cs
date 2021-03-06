﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using View.Models;

namespace View.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [ERPVerificaRol]
        public ActionResult Index()
        {
            return View(DataManager.GetAllPersona(((DO_Persona)Session["UsuarioConectado"]).idCompania));
        }

        [ERPVerificaRol]
        public ActionResult Create(DO_Persona persona = null)
        {
            if (!string.IsNullOrEmpty(persona.Nombre))
            {
                persona.Usuario = (string)TempData["numeroNomina"];
                persona.idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;
                DataManager.InsertPersona(persona);
                return RedirectToAction("Index", "Usuario");
            }
            else
            {
                DO_Persona model = new DO_Persona();
                model.Usuario = DataManager.GetNewNumberNomina();
                model.Roles = DataManager.GetAllRolSelectListItem();
                TempData["numeroNomina"] = model.Usuario;

                if (string.IsNullOrEmpty(model.Usuario))
                {
                    return RedirectToAction("Index", "Usuario");
                }
                else
                {
                    return View(model);
                }
                
            }
        }

        [ERPVerificaRol]
        public ActionResult Edit(int id = 0, DO_Persona persona = null)
        {
            if (id != 0 && persona.idUsuario == 0)
            {
                return View(DataManager.GetPersona(id));
            }
            else
            {
                persona.idCompania = ((DO_Persona)Session["UsuarioConectado"]).idCompania;
                DataManager.UpdatePersona(persona);
                return RedirectToAction("Index", "Usuario");
            }
        }

        [ERPVerificaRol]
        public ActionResult Delete(int id = 0)
        {
            DataManager.DeletePersona(id);
            return RedirectToAction("Index", "Usuario");
        }

        [ERPVerificaRol]
        public ActionResult ActualizarContrasena()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GuardarNuevaContrasena(string contrasenaAnterior, string nuevaContrasena)
        {
            int idPersona = ((DO_Persona)Session["UsuarioConectado"]).idUsuario;

            DO_ResponseRequest response = new DO_ResponseRequest();
            if (DataManager.CheckPass(idPersona,contrasenaAnterior))
            {
                response.Code = 1;
                if (DataManager.UpdateContrasena(idPersona, nuevaContrasena) > 0)
                {
                    response.Result = "La contraseña fué actualizada correctamente.";
                }
                else
                {
                    response.Code = 2;
                    response.Result = "Ocurrio un error al actualizar la contraseña, por favor intente mas tarde.";
                }
                
            }else
            {
                response.Code = 2;
                response.Result = "La contraseña anterior no es valida.";
            }

            var jsonResult = Json(response, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
    }
}