﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Servicios_18_20.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBSuperEntities : DbContext
    {
        public DBSuperEntities()
            : base("name=DBSuperEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CARGo> CARGoes { get; set; }
        public virtual DbSet<CIUDad> CIUDads { get; set; }
        public virtual DbSet<CLIEnte> CLIEntes { get; set; }
        public virtual DbSet<COntactoPRoveedor> COntactoPRoveedors { get; set; }
        public virtual DbSet<DEPArtamento> DEPArtamentoes { get; set; }
        public virtual DbSet<DEtalleDEvolucion> DEtalleDEvolucions { get; set; }
        public virtual DbSet<DEtalleFActura> DEtalleFActuras { get; set; }
        public virtual DbSet<DEtalleFacturaCompra> DEtalleFacturaCompras { get; set; }
        public virtual DbSet<DEVOlucion> DEVOlucions { get; set; }
        public virtual DbSet<EMPLeado> EMPLeadoes { get; set; }
        public virtual DbSet<EMpleadoCArgo> EMpleadoCArgoes { get; set; }
        public virtual DbSet<FACTura> FACTuras { get; set; }
        public virtual DbSet<FActuraCOmpra> FActuraCOmpras { get; set; }
        public virtual DbSet<NOtaCRedito> NOtaCReditoes { get; set; }
        public virtual DbSet<PAI> PAIS { get; set; }
        public virtual DbSet<Perfil> Perfils { get; set; }
        public virtual DbSet<PRODucto> PRODuctoes { get; set; }
        public virtual DbSet<PRoductoPRoveedor> PRoductoPRoveedors { get; set; }
        public virtual DbSet<PROVeedor> PROVeedors { get; set; }
        public virtual DbSet<SUCUrsal> SUCUrsals { get; set; }
        public virtual DbSet<SUPErmercado> SUPErmercadoes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TELEfono> TELEfonoes { get; set; }
        public virtual DbSet<TIpoPRoducto> TIpoPRoductoes { get; set; }
        public virtual DbSet<TIpoTElefono> TIpoTElefonoes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Usuario_Perfil> Usuario_Perfil { get; set; }
        public virtual DbSet<ImagenesProducto> ImagenesProductoes { get; set; }
    }
}
