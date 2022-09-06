using CadastroProduto.CategoryAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace CadastroProduto.CategoryAPI.Infra.Context
{
    public class CategoryDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public CategoryDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(100).IsRequired();
        }
    }
}
