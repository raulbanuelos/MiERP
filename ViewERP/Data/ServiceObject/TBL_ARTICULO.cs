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
    
    public partial class TBL_ARTICULO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_ARTICULO()
        {
            this.TBL_EXISTENCIA = new HashSet<TBL_EXISTENCIA>();
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
    
        public virtual TBL_COMPANIA TBL_COMPANIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_EXISTENCIA> TBL_EXISTENCIA { get; set; }
        public virtual TBL_CATEGORIA_ARTICULO TBL_CATEGORIA_ARTICULO { get; set; }
    }
}
