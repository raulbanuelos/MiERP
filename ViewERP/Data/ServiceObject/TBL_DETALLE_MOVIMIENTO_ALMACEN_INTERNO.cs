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
    
    public partial class TBL_DETALLE_MOVIMIENTO_ALMACEN_INTERNO
    {
        public int ID_DETALLE_MOVIMIENTO_ALMACEN_INTERNO { get; set; }
        public Nullable<int> ID_MOVIMIENTO_ALMACEN_INTERNO { get; set; }
        public Nullable<int> ID_ARTICULO { get; set; }
        public Nullable<decimal> CANTIDAD { get; set; }
    
        public virtual TBL_ARTICULO TBL_ARTICULO { get; set; }
        public virtual TBL_MOVIMIENTO_ALMACEN_INTERNO TBL_MOVIMIENTO_ALMACEN_INTERNO { get; set; }
    }
}