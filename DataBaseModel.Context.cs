﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------


namespace WpfApp1
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class DbModel : DbContext
{
    public DbModel()
        : base("name=DbModel")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<ProductList> ProductList { get; set; }

    public virtual DbSet<Products> Products { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    public virtual DbSet<Baskets> Baskets { get; set; }

    public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

}

}

