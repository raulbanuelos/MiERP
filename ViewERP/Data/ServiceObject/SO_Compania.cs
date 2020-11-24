using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
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
                    compania.FECHA_REGISTRO = DateTime.Now;

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

        public int UpdatePlan(int idCompania, int idPlan)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_COMPANIA tBL_COMPANIA = Conexion.TBL_COMPANIA.Where(x => x.ID_COMPANIA == idCompania).FirstOrDefault();

                    tBL_COMPANIA.ID_PLAN = idPlan;
                    tBL_COMPANIA.FECHA_REGISTRO = DateTime.Now;

                    Conexion.Entry(tBL_COMPANIA).State = EntityState.Modified;

                    return Conexion.SaveChanges();

                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public IList Get(int idCompania)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var lista = (from a in Conexion.TBL_COMPANIA
                                 where a.ID_COMPANIA == idCompania
                                 select a).ToList();

                    return lista;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
