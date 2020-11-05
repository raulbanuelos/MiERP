using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ServiceObject
{
    public class SO_Details_Articulo
    {
        public int Insert(int idArticulo, double precioUnidad, double precioMaster, double precioPromotor, double precioGerente)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_DETAILS_ARTICULO tBL_DETAILS_ARTICULO = new TBL_DETAILS_ARTICULO();

                    tBL_DETAILS_ARTICULO.ID_ARTICULO = idArticulo;
                    tBL_DETAILS_ARTICULO.PRECIO_UNIDAD = precioUnidad;
                    tBL_DETAILS_ARTICULO.PRECIO_MASTER = precioMaster;
                    tBL_DETAILS_ARTICULO.PRECIO_PROMOTOR = precioPromotor;
                    tBL_DETAILS_ARTICULO.PRECIO_GERENTE = precioGerente;

                    Conexion.TBL_DETAILS_ARTICULO.Add(tBL_DETAILS_ARTICULO);

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Update(int idArticulo, double precioUnidad, double precioMaster, double precioPromotor, double precioGerente)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_DETAILS_ARTICULO tBL_DETAILS_ARTICULO = Conexion.TBL_DETAILS_ARTICULO.Where(x => x.ID_ARTICULO == idArticulo).FirstOrDefault();

                    tBL_DETAILS_ARTICULO.PRECIO_UNIDAD = precioUnidad;
                    tBL_DETAILS_ARTICULO.PRECIO_MASTER = precioMaster;
                    tBL_DETAILS_ARTICULO.PRECIO_PROMOTOR = precioPromotor;
                    tBL_DETAILS_ARTICULO.PRECIO_GERENTE = precioGerente;

                    Conexion.Entry(tBL_DETAILS_ARTICULO).State = EntityState.Modified;

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public double GetPrecioUnidad(int idArticulo)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    double precio = (from a in Conexion.TBL_DETAILS_ARTICULO
                                where a.ID_ARTICULO == idArticulo
                                select a.PRECIO_UNIDAD).FirstOrDefault();

                    return precio;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public double GetPrecioMaster(int idArticulo)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    double precio = (from a in Conexion.TBL_DETAILS_ARTICULO
                                     where a.ID_ARTICULO == idArticulo
                                     select a.PRECIO_MASTER).FirstOrDefault();

                    return precio;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public double GetPrecioGerente(int idArticulo)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    double precio = (from a in Conexion.TBL_DETAILS_ARTICULO
                                     where a.ID_ARTICULO == idArticulo
                                     select a.PRECIO_GERENTE).FirstOrDefault();

                    return precio;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public double GetPrecioPromotor(int idArticulo)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    double precio = (from a in Conexion.TBL_DETAILS_ARTICULO
                                     where a.ID_ARTICULO == idArticulo
                                     select a.PRECIO_PROMOTOR).FirstOrDefault();

                    return precio;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
