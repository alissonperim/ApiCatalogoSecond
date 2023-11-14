using ApiCatalogoSecond.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoSecond.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options): base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Catalog Fluent Configuration
            modelBuilder.Entity<Category>(builder =>
            {
                builder.ToTable("Catalogs");
                builder
                    .HasMany(catalog => catalog.Products)
                    .WithOne(product => product.Category)
                    .HasForeignKey(product => product.CategoryId)
                    .IsRequired();
            });

            modelBuilder.Entity<Category>()
                .Property(p => p.Name)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<Category>()
                .Property(p => p.Description)
                .HasMaxLength(300)
                .IsRequired();
            #endregion

            #region Product Fluent Configuration
            modelBuilder.Entity<Product>(builder =>
            {
                builder.ToTable("Products");
            });

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(14, 2)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(300);

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.Image)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.Stock)
                .HasDefaultValue(0);
            #endregion
        }
    }
}
