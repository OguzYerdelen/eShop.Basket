using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Basket.Domain.Concrete;
using Microsoft.Extensions.Logging.Abstractions;

namespace Basket.Infrastructure.Concrete.EntityFramework.Context
{
    public class EShopContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-F8NN27D;Database=eShopDB;Trusted_Connection=True;MultipleActiveResultSets=true;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryName = "Laptop",
                    CreatedDate = DateTime.Now.Date,
                    CreatedBy = "Oğuz Berkay Yerdelen",
                    Id = 1

                }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, ProductName = "MSI", CategoryId = 1, UnitsInStock = 500, UnitPrice = 1000, CreatedBy = "Oğuz Berkay Yerdelen" }
            );
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Oğuz Berkay", Surname = "Yerdelen" }
            );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Domain.Concrete.Basket> Baskets { get; set; }
    }
}
