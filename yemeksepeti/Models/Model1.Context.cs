﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace yemeksepeti.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class yemeksepetiEntities2 : DbContext
    {
        public yemeksepetiEntities2()
            : base("name=yemeksepetiEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<restoran> restoran { get; set; }
        public virtual DbSet<restoranlar> restoranlar { get; set; }
        public virtual DbSet<siparis> siparis { get; set; }
        public virtual DbSet<user> user { get; set; }
        public virtual DbSet<yemek> yemek { get; set; }
    }
}