﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ServiceObject
{
    public class SO_EntradasAlmacen
    {
        public int InsertEntrada(int idAlmacen, int idProveedor,int idUnidad,string noFactura,DateTime fecha,string usuario)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_MOVIMIENTO_ALMACEN obj = new TBL_MOVIMIENTO_ALMACEN();

                    obj.ID_ALMACEN = idAlmacen;
                    obj.ID_PROVEEDOR = idProveedor;
                    obj.ID_UNIDAD = idUnidad;
                    obj.NO_FACTURA = noFactura;
                    obj.FECHA = fecha;
                    obj.USUARIO = usuario;

                    Conexion.TBL_MOVIMIENTO_ALMACEN.Add(obj);

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception er)
            {
                return 0;
            }
        }
    }
}
