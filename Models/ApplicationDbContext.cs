//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;

namespace EMA_Project.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<Place> Place { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<PlaceProduct> PlaceProduct { get; set; }
        public DbSet<Student> Student { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure table name for Tourist entity
            builder.Entity<Student>().ToTable("Student");
            builder.Entity<Place>().ToTable("Place");
            builder.Entity<Product>().ToTable("Product");
            builder.Entity<PlaceProduct>().ToTable("PlaceProduct");
            builder.Entity<Student>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<PlaceProduct>()
           .HasKey(pp => new { pp.PlaceId, pp.ProductId });

            builder.Entity<PlaceProduct>()
                .HasOne(pp => pp.Place)
                .WithMany(p => p.PlaceProducts)
                .HasForeignKey(pp => pp.PlaceId);

            builder.Entity<PlaceProduct>()
                .HasOne(pp => pp.Product)
                .WithMany(p => p.PlaceProducts)
                .HasForeignKey(pp => pp.ProductId);

        }


    }
}