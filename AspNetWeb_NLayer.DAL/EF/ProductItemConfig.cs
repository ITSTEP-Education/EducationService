using AspNetWeb_NLayer.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetWeb_NLayer.DAL.EF
{
    public class ProductItemConfig : IEntityTypeConfiguration<ProductItem>
    {
        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder.ToTable("products").HasKey(c => c.id);
            builder.HasIndex(c => c.name).IsUnique();
        }
    }
}