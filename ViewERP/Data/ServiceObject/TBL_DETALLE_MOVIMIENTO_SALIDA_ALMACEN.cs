//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data.ServiceObject
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_DETALLE_MOVIMIENTO_SALIDA_ALMACEN
    {
        public int ID_DETALLE_MOVIMIENTO_SALIDA_ALMACEN { get; set; }
        public int ID_MOVIMIENTO_SALIDA_ALMACEN { get; set; }
        public int ID_ARTICULO { get; set; }
        public decimal CANTIDAD { get; set; }
        public string CONDICION_ARTICULO_SALIDA { get; set; }
        public string CONDICION_ARTICULO_REGRESO { get; set; }
    
        public virtual TBL_MOVIMIENTO_SALIDA_ALMACEN TBL_MOVIMIENTO_SALIDA_ALMACEN { get; set; }
    }
}