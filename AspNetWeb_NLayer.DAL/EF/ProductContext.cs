using AspNetWeb_NLayer.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetWeb_NLayer.DAL.EF
{
    public class ProductContext : DbContext
    {
        public DbSet<ProductItem> productItems { get; set; } = null!;

        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductItemConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
