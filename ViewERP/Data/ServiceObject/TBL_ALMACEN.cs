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
    
    public partial class TBL_ALMACEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_ALMACEN()
        {
            this.TBL_MOVIMIENTO_ALMACEN = new HashSet<TBL_MOVIMIENTO_ALMACEN>();
            this.TBL_EXISTENCIA = new HashSet<TBL_EXISTENCIA>();
            this.TBL_MOVIMIENTO_SALIDA_ALMACEN = new HashSet<TBL_MOVIMIENTO_SALIDA_ALMACEN>();
        }
    
        public int ID_ALMACEN { get; set; }
        public int ID_COMPANIA { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
    
        public virtual TBL_COMPANIA TBL_COMPANIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MOVIMIENTO_ALMACEN> TBL_MOVIMIENTO_ALMACEN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_EXISTENCIA> TBL_EXISTENCIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MOVIMIENTO_SALIDA_ALMACEN> TBL_MOVIMIENTO_SALIDA_ALMACEN { get; set; }
    }
}
