using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Data.ServiceObject;
using System.Collections;

namespace ViewERP.Models
{
    public static class DataManager
    {
        public static DO_Persona GetLogin(string usuario,string contrasena)
        {
            DO_Persona persona = null;

            SO_Usuario login = new SO_Usuario();

            IList informacionBD = login.GetLogin(usuario, contrasena);

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    Type tipo = item.GetType();

                    persona = new DO_Persona();

                    persona.ApellidoPaterno = (string)tipo.GetProperty("APATERNO").GetValue(item, null);
                    persona.ApellidoMaterno = (string)tipo.GetProperty("AMATERNO").GetValue(item, null);
                    persona.Nombre = (string)tipo.GetProperty("NOMBRE").GetValue(item, null);
                    persona.idUsuario = (int)tipo.GetProperty("ID_USUARIO").GetValue(item, null);
                    persona.idCompania = (int)tipo.GetProperty("ID_COMPANIA").GetValue(item, null);
                    persona.idRol = (int)tipo.GetProperty("ID_ROL").GetValue(item, null);
                    persona.Usuario = (string)tipo.GetProperty("USUARIO").GetValue(item, null);

                }
            }

            return persona;
        }
    }
}