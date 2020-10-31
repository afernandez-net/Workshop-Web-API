using Camones.Shop.Domain.Entities;
using Camones.Shop.Infrastructure.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Camones.Shop.Infrastructure
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new CartEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CartItemEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder
                 .UseLazyLoadingProxies(false);
    }
}