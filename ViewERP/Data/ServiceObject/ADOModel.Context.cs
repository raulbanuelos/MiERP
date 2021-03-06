﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EntitiesERP : DbContext
    {
        public EntitiesERP()
            : base("name=EntitiesERP")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBL_ALERTAS_STOCK_MIN> TBL_ALERTAS_STOCK_MIN { get; set; }
        public virtual DbSet<TBL_ALMACEN> TBL_ALMACEN { get; set; }
        public virtual DbSet<TBL_ARTICULO> TBL_ARTICULO { get; set; }
        public virtual DbSet<TBL_CATEGORIA_ARTICULO> TBL_CATEGORIA_ARTICULO { get; set; }
        public virtual DbSet<TBL_DETALLE_MOVIMIENTO_ENTRADA_ALMACEN> TBL_DETALLE_MOVIMIENTO_ENTRADA_ALMACEN { get; set; }
        public virtual DbSet<TBL_DETALLE_MOVIMIENTO_SALIDA_ALMACEN> TBL_DETALLE_MOVIMIENTO_SALIDA_ALMACEN { get; set; }
        public virtual DbSet<TBL_EXISTENCIA> TBL_EXISTENCIA { get; set; }
        public virtual DbSet<TBL_MOVIMIENTO_SALIDA_ALMACEN> TBL_MOVIMIENTO_SALIDA_ALMACEN { get; set; }
        public virtual DbSet<TBL_PROVEEDOR> TBL_PROVEEDOR { get; set; }
        public virtual DbSet<TBL_ROLE> TBL_ROLE { get; set; }
        public virtual DbSet<TBL_UNIDAD> TBL_UNIDAD { get; set; }
        public virtual DbSet<ArchivosOrden> ArchivosOrden { get; set; }
        public virtual DbSet<CategoriaProducto> CategoriaProducto { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<EstatusOrden> EstatusOrden { get; set; }
        public virtual DbSet<Ordenes> Ordenes { get; set; }
        public virtual DbSet<OrdenesDetalle> OrdenesDetalle { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<TBL_VENTA> TBL_VENTA { get; set; }
        public virtual DbSet<TBL_SEMANA> TBL_SEMANA { get; set; }
        public virtual DbSet<TBL_DEPOSITOS> TBL_DEPOSITOS { get; set; }
        public virtual DbSet<TBL_DETAILS_ARTICULO> TBL_DETAILS_ARTICULO { get; set; }
        public virtual DbSet<TBL_DETAILS_VENTA> TBL_DETAILS_VENTA { get; set; }
        public virtual DbSet<TBL_COMPANIA> TBL_COMPANIA { get; set; }
        public virtual DbSet<TBL_ERP_CORTE_EXISTENCIA_ALMACEN> TBL_ERP_CORTE_EXISTENCIA_ALMACEN { get; set; }
        public virtual DbSet<TBL_ORGANIZACION> TBL_ORGANIZACION { get; set; }
        public virtual DbSet<TR_ERP_ORGANIZACION_COMPANIA> TR_ERP_ORGANIZACION_COMPANIA { get; set; }
        public virtual DbSet<TBL_ERP_PLAN> TBL_ERP_PLAN { get; set; }
        public virtual DbSet<TBL_ERP_PAGO_PLAN> TBL_ERP_PAGO_PLAN { get; set; }
        public virtual DbSet<TBL_ERP_BITACORA> TBL_ERP_BITACORA { get; set; }
        public virtual DbSet<TBL_MOVIMIENTO_ALMACEN> TBL_MOVIMIENTO_ALMACEN { get; set; }
        public virtual DbSet<TBL_VENTA_PROMOTOR> TBL_VENTA_PROMOTOR { get; set; }
        public virtual DbSet<TBL_USUARIO> TBL_USUARIO { get; set; }
        public virtual DbSet<TBL_DETALLE_MOVIMIENTO_ALMACEN_INTERNO> TBL_DETALLE_MOVIMIENTO_ALMACEN_INTERNO { get; set; }
        public virtual DbSet<TBL_MOVIMIENTO_ALMACEN_INTERNO> TBL_MOVIMIENTO_ALMACEN_INTERNO { get; set; }
    
        [DbFunction("EntitiesERP", "GetIdEmpleados")]
        public virtual IQueryable<Nullable<int>> GetIdEmpleados(Nullable<int> jefeId)
        {
            var jefeIdParameter = jefeId.HasValue ?
                new ObjectParameter("JefeId", jefeId) :
                new ObjectParameter("JefeId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Nullable<int>>("[EntitiesERP].[GetIdEmpleados](@JefeId)", jefeIdParameter);
        }
    }
}
