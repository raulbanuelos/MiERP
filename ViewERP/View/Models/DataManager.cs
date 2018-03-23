using Data.ServiceObject;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace View.Models
{
    public static class DataManager
    {
        public static DO_Persona GetLogin(string usuario, string contrasena)
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

        public static List<DO_Almacen> GetAllAlmacen()
        {
            List<DO_Almacen> lista = new List<DO_Almacen>();

            SO_Almacen service = new SO_Almacen();

            //HardCode
            IList informacionBD = service.GetAll(1);

            if (informacionBD != null)
            {
                foreach (var item in informacionBD)
                {
                    DO_Almacen almacen = new DO_Almacen();

                    System.Type tipo = item.GetType();

                    almacen.idAlmacen = (int)tipo.GetProperty("ID_ALMACEN").GetValue(item, null);
                    almacen.idCompania = (int)tipo.GetProperty("ID_COMPANIA").GetValue(item, null);
                    almacen.Nombre = (string)tipo.GetProperty("NOMBRE").GetValue(item, null);
                    almacen.Descripcion = (string)tipo.GetProperty("DESCRIPCION").GetValue(item, null);

                    lista.Add(almacen);
                }
            }

            return lista;
        }

        public static int InsertAlmacen(DO_Almacen almacen)
        {
            SO_Almacen service = new SO_Almacen();

            return service.Insert(almacen);
        }

        public static DO_Almacen GetAlmacen(int idAlmacen)
        {
            SO_Almacen service = new SO_Almacen();

            return service.GetCategoriaArticulo(idAlmacen);
        }

        public static int UpdateAlamcen(DO_Almacen almacen)
        {
            SO_Almacen service = new SO_Almacen();

            return service.Update(almacen);
        }

        public static int DeleteAlmacen(int idAlmacen)
        {
            SO_Almacen service = new SO_Almacen();

            return service.Delete(idAlmacen);
        }
    }
}