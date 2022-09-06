using CadastroProduto.ProductAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace CadastroProduto.ProductAPI.Infra.Context
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProductDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasKey(x => x.Id);
            modelBuilder.Entity<Product>().Property(x => x.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Description).HasMaxLength(255);
            modelBuilder.Entity<Product>().Property(x => x.Value).HasColumnType("decimal(8,2)").IsRequired();
        }
    }
}
