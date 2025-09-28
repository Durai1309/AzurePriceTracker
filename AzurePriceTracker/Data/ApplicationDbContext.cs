using AzurePriceTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace AzurePriceTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<AzurePrice> AzurePrices { get; set; }
        public DbSet<ServiceGroup> ServiceGroups { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AzurePrice>(entity =>
            {
                entity.ToTable("AzurePrices");
                entity.Property(e => e.ServiceId).HasDefaultValue("N/A");
                entity.Property(e => e.ProductId).HasDefaultValue("N/A");
                entity.Property(e => e.SkuId).HasDefaultValue("N/A");
            });

            modelBuilder.Entity<ServiceGroup>().ToTable("ServiceGroups");
            modelBuilder.Entity<ProductDetail>().ToTable("ProductDetails");
        }
    }
}