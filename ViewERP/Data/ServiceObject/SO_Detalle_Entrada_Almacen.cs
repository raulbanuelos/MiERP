﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ServiceObject
{
    public class SO_Detalle_Entrada_Almacen
    {
        public int Insert(int idMovimientoEntrada, int idArticulo, decimal cantidad,int idUnidad)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_DETALLE_MOVIMIENTO_ENTRADA_ALMACEN detalle = new TBL_DETALLE_MOVIMIENTO_ENTRADA_ALMACEN();

                    detalle.ID_MOVIMIENTO_ENTRADA_ALMACEN = idMovimientoEntrada;
                    detalle.ID_ARTICULO = idArticulo;
                    detalle.CANTIDAD = cantidad;
                    detalle.ID_UNIDAD = idUnidad;

                    Conexion.TBL_DETALLE_MOVIMIENTO_ENTRADA_ALMACEN.Add(detalle);

                    if (Conexion.SaveChanges() > 0)
                    {
                        return detalle.ID_DETALLE_MOVIMIENTO_ENTRADA_ALMACEN;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Update(int idDetalle, int idArticulo, int cantidad,int idUnidad)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_DETALLE_MOVIMIENTO_ENTRADA_ALMACEN obj = Conexion.TBL_DETALLE_MOVIMIENTO_ENTRADA_ALMACEN.Where(x => x.ID_DETALLE_MOVIMIENTO_ENTRADA_ALMACEN == idDetalle).FirstOrDefault();

                    obj.ID_ARTICULO = idArticulo;
                    obj.CANTIDAD = cantidad;
                    obj.ID_UNIDAD = idUnidad;

                    Conexion.Entry(obj).State = EntityState.Modified;

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Delete(int idDetalle)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_DETALLE_MOVIMIENTO_ENTRADA_ALMACEN obj = Conexion.TBL_DETALLE_MOVIMIENTO_ENTRADA_ALMACEN.Where(x => x.ID_DETALLE_MOVIMIENTO_ENTRADA_ALMACEN == idDetalle).FirstOrDefault();
                    
                    Conexion.Entry(obj).State = EntityState.Deleted;

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public IList GetDetalle(int idEntradaAlmacen)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    var Lista = (from a in Conexion.TBL_DETALLE_MOVIMIENTO_ENTRADA_ALMACEN
                                 where a.ID_MOVIMIENTO_ENTRADA_ALMACEN == idEntradaAlmacen
                                 select a).ToList();

                    return Lista;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}