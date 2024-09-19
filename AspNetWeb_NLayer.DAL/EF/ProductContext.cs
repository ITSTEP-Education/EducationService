using AspNetWeb_NLayer.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AspNetWeb_NLayer.DAL.EF
{
    public class ProductContext : DbContext
    {
        public DbSet<ProductItem> productItems { get; set; } = null!;

        //public ProductContext() { }
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var config = new ConfigurationBuilder()
        //        .AddJsonFile("appsettings.json")
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .Build();

        //    optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultDbConnection"));
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductItemConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
