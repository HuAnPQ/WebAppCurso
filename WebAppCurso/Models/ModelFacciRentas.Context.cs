﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppCurso.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities_FacciRentas : DbContext
    {
        public Entities_FacciRentas()
            : base("name=Entities_FacciRentas")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DetalleSimulacion> DetalleSimulacions { get; set; }
        public virtual DbSet<Heredero> Herederoes { get; set; }
        public virtual DbSet<Simulacion> Simulacions { get; set; }
    }
}