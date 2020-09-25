using System;

namespace Data.ServiceObject
{
    public class SO_Venta
    {
        public int Insert(int idUsuario, double monto, DateTime fechaIngreso)
        {
            try
            {
                using (var Conexion = new EntitiesERP())
                {
                    TBL_VENTA venta = new TBL_VENTA();

                    venta.FECHA_INGRESO = fechaIngreso;
                    venta.ID_USUARIO = idUsuario;
                    venta.MONTO = monto;
                    venta.FECHA_REGISTRO = DateTime.Now;

                    Conexion.TBL_VENTA.Add(venta);

                    return Conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
