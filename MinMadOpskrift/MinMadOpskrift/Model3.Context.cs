﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MinMadOpskrift
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MinMadOpskriftEntities3 : DbContext
    {
        public MinMadOpskriftEntities3()
            : base("name=MinMadOpskriftEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bruger> Bruger { get; set; }
        public virtual DbSet<Opskrift> Opskrift { get; set; }
    }
}
