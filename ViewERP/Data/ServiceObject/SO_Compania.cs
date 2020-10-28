using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ServiceObject
{
    public class SO_Compania
    {
        public int Insert(string nombre, string rfc, string direccion, string telefono, string correo)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_COMPANIA compania = new TBL_COMPANIA();

                    compania.NOMBRE = nombre;
                    compania.RFC = rfc;
                    compania.DIRECCION = direccion;
                    compania.TELEFONO = telefono;
                    compania.CORREO = correo;

                    Conexion.TBL_COMPANIA.Add(compania);

                    Conexion.SaveChanges();

                    return compania.ID_COMPANIA;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
