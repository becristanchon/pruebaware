﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace facturacion.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OpheliaFacturacionEntities : DbContext
    {
        public OpheliaFacturacionEntities()
            : base("name=OpheliaFacturacionEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<c_categoria_productos> c_categoria_productos { get; set; }
        public virtual DbSet<c_tipo_documento> c_tipo_documento { get; set; }
        public virtual DbSet<p_detalle_factura> p_detalle_factura { get; set; }
        public virtual DbSet<p_facturas> p_facturas { get; set; }
        public virtual DbSet<p_persona> p_persona { get; set; }
        public virtual DbSet<p_productos> p_productos { get; set; }
    }
}
