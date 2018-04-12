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
    
    public partial class TBL_ARTICULO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_ARTICULO()
        {
            this.TBL_MOVIMIENTO_ALMACEN = new HashSet<TBL_MOVIMIENTO_ALMACEN>();
            this.TBL_EXISTENCIA = new HashSet<TBL_EXISTENCIA>();
            this.TBL_MOVIMIENTO_SALIDA_ALMACEN = new HashSet<TBL_MOVIMIENTO_SALIDA_ALMACEN>();
        }
    
        public int ID_ARTICULO { get; set; }
        public int ID_COMPANIA { get; set; }
        public int ID_CATEGORIA { get; set; }
        public string CODIGO { get; set; }
        public string DESCRIPCION { get; set; }
        public string DESCRIPCION_LARGA { get; set; }
        public byte[] FOTO { get; set; }
        public Nullable<int> STOCK_MIN { get; set; }
        public Nullable<int> STOCK_MAX { get; set; }
        public bool CONSUMIBLE { get; set; }
    
        public virtual TBL_CATEGORIA_ARTICULO TBL_CATEGORIA_ARTICULO { get; set; }
        public virtual TBL_COMPANIA TBL_COMPANIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MOVIMIENTO_ALMACEN> TBL_MOVIMIENTO_ALMACEN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_EXISTENCIA> TBL_EXISTENCIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MOVIMIENTO_SALIDA_ALMACEN> TBL_MOVIMIENTO_SALIDA_ALMACEN { get; set; }
    }
}
