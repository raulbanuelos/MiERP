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
    
    public partial class TBL_ERP_CORTE_EXISTENCIA_ALMACEN
    {
        public int ID_CORTE_EXISTENCIA_ALMACEN { get; set; }
        public int ID_SEMANA { get; set; }
        public int ID_ALMACEN { get; set; }
        public int ID_ARTICULO { get; set; }
        public int CANTIDAD { get; set; }
    
        public virtual TBL_ALMACEN TBL_ALMACEN { get; set; }
        public virtual TBL_ARTICULO TBL_ARTICULO { get; set; }
        public virtual TBL_SEMANA TBL_SEMANA { get; set; }
    }
}
