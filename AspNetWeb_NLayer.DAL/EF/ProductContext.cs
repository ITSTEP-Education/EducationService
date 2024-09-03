﻿using AspNetWeb_NLayer.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AspNetWeb_NLayer.DAL.EF
{
    public class ProductContext : DbContext
    {
        public DbSet<ProductItem> productItems { get; set; } = null!;

        public ProductContext(DbContextOptions<ProductContext> options) : base(options) {
            //options.UseSqlServer(connection, b => b.MigrationsAssembly("AspNetWeb_Product"))
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductItemConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
