﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
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

    public virtual DbSet<Languages> Languages { get; set; }

}

}

