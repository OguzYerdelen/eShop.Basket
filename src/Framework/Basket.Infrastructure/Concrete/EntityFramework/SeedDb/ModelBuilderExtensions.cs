using System;
using System.Collections.Generic;
using System.Text;
using Basket.Domain.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Basket.Infrastructure.Concrete.EntityFramework.SeedDb
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
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
        }
    }
}
