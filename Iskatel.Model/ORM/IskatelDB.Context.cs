﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Iskatel.Model.ORM
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class iskateli_devEntities1 : DbContext
    {
        public iskateli_devEntities1()
            : base("name=iskateli_devEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Data> Data { get; set; }
        public virtual DbSet<Entity> Entity { get; set; }
        public virtual DbSet<Relation> Relation { get; set; }
        public virtual DbSet<Class> Class { get; set; }
    }
}
