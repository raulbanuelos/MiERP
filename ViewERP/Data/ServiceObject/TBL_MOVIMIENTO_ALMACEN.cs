//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data.ServiceObject
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_MOVIMIENTO_ALMACEN
    {
        public int ID_MOVIMIENTO_ALMACEN { get; set; }
        public Nullable<int> ID_ALMACEN { get; set; }
        public Nullable<int> ID_ARTICULO { get; set; }
        public Nullable<int> ID_PROVEEDOR { get; set; }
        public Nullable<int> ID_UNIDAD { get; set; }
        public Nullable<int> CANTIDAD { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public string USUARIO { get; set; }
    
        public virtual TBL_ALMACEN TBL_ALMACEN { get; set; }
        public virtual TBL_ARTICULO TBL_ARTICULO { get; set; }
        public virtual TBL_PROVEEDOR TBL_PROVEEDOR { get; set; }
        public virtual TBL_UNIDAD TBL_UNIDAD { get; set; }
    }
}
