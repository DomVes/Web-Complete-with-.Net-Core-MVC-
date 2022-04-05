﻿using GlampingITM.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlampingITM.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set;  }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
        }
    }
}
