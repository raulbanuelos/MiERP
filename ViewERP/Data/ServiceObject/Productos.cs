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
    
    public partial class Productos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Productos()
        {
            this.OrdenesDetalle = new HashSet<OrdenesDetalle>();
        }
    
        public int Id_Productos { get; set; }
        public Nullable<int> Id_Categoria { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public byte[] foto { get; set; }
    
        public virtual CategoriaProducto CategoriaProducto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdenesDetalle> OrdenesDetalle { get; set; }
    }
}