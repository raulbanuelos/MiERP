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
        public virtual DbSet<TBL_COMPANIA> TBL_COMPANIA { get; set; }
        public virtual DbSet<TBL_DETALLE_MOVIMIENTO_ENTRADA_ALMACEN> TBL_DETALLE_MOVIMIENTO_ENTRADA_ALMACEN { get; set; }
        public virtual DbSet<TBL_DETALLE_MOVIMIENTO_SALIDA_ALMACEN> TBL_DETALLE_MOVIMIENTO_SALIDA_ALMACEN { get; set; }
        public virtual DbSet<TBL_EXISTENCIA> TBL_EXISTENCIA { get; set; }
        public virtual DbSet<TBL_MOVIMIENTO_ALMACEN> TBL_MOVIMIENTO_ALMACEN { get; set; }
        public virtual DbSet<TBL_MOVIMIENTO_SALIDA_ALMACEN> TBL_MOVIMIENTO_SALIDA_ALMACEN { get; set; }
        public virtual DbSet<TBL_PROVEEDOR> TBL_PROVEEDOR { get; set; }
        public virtual DbSet<TBL_ROLE> TBL_ROLE { get; set; }
        public virtual DbSet<TBL_UNIDAD> TBL_UNIDAD { get; set; }
        public virtual DbSet<TBL_USUARIO> TBL_USUARIO { get; set; }
        public virtual DbSet<ArchivosOrden> ArchivosOrden { get; set; }
        public virtual DbSet<CategoriaProducto> CategoriaProducto { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<EstatusOrden> EstatusOrden { get; set; }
        public virtual DbSet<Ordenes> Ordenes { get; set; }
        public virtual DbSet<OrdenesDetalle> OrdenesDetalle { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
    }
}
