﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace femcoservice.Models
{
    public class DataContext:DbContext
    {
        public DataContext() :base("DefaultConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        public DbSet<Producto> Productoes { get; set; }
    }
}