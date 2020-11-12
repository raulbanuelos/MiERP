using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ServiceObject
{
    public class SO_TR_Organizacion_Compania
    {
        public int Insert(int idOrganizacion, int idCompania)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TR_ERP_ORGANIZACION_COMPANIA tR_ERP_ORGANIZACION_COMPANIA = new TR_ERP_ORGANIZACION_COMPANIA();

                    tR_ERP_ORGANIZACION_COMPANIA.ID_ORGANIZACION = idOrganizacion;
                    tR_ERP_ORGANIZACION_COMPANIA.ID_COMPANIA = idCompania;

                    Conexion.TR_ERP_ORGANIZACION_COMPANIA.Add(tR_ERP_ORGANIZACION_COMPANIA);

                    Conexion.SaveChanges();

                    return tR_ERP_ORGANIZACION_COMPANIA.ID_ORG_COMPANIA;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public IList GetCompanyByIdOrganizacion(int idOrganizacion)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var list = (from a in Conexion.TR_ERP_ORGANIZACION_COMPANIA
                                join b in Conexion.TBL_COMPANIA on a.ID_COMPANIA equals b.ID_COMPANIA
                                where a.ID_ORGANIZACION == idOrganizacion
                                select b).ToList();

                    return list;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
