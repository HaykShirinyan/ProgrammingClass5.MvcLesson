﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass5.MvcLesson.Models;

namespace ProgrammingClass5.MvcLesson.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Size> Sizes { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<ProductSize> ProductSizes { get; set; }

        public DbSet<ProductColor> ProductColors { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            users

            builder.Entity<ProductCategory>().HasKey(x => new { x.ProductId, x.CategoryId });

            builder.Entity<ProductSize>().HasKey(x => new { x.ProductId, x.SizeId });
            
            builder.Entity<ProductColor>().HasKey(x => new { x.ProductId, x.ColorId });
        }
    }
}
