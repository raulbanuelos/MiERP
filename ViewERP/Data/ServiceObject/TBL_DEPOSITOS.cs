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
    
    public partial class TBL_DEPOSITOS
    {
        public int ID_DEPOSITO { get; set; }
        public Nullable<int> ID_USUARIO { get; set; }
        public Nullable<System.DateTime> FECHA_INGRESO { get; set; }
        public Nullable<System.DateTime> FECHA_REGISTRO { get; set; }
        public Nullable<double> MONTO { get; set; }
        public string BANCO { get; set; }
        public string DESCRIPCION { get; set; }
        public string URL_ARCHIVO { get; set; }
    
        public virtual TBL_USUARIO TBL_USUARIO { get; set; }
    }
}
