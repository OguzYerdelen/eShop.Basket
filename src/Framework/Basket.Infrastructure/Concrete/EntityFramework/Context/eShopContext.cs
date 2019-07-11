using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Basket.Domain.Concrete;
using Microsoft.Extensions.Logging.Abstractions;

namespace Basket.Infrastructure.Concrete.EntityFramework.Context
{
    public class EShopContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-NGR96Q4;Database=eShopDB;Trusted_Connection=True;MultipleActiveResultSets=true;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Domain.Concrete.Basket> Baskets { get; set; }
    }
}
