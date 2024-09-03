using AspNetWeb_NLayer.DAL.EF;
using AspNetWeb_NLayer.DAL.Entities;
using AspNetWeb_NLayer.DAL.Interfaces;

namespace AspNetWeb_NLayer.DAL.Repositories
{
    public class ProductItemRepository : IRepository<ProductItem>
    {
        public ProductContext context;

        public ProductItemRepository(ProductContext context)
        {
            this.context = context;
        }

        public IEnumerable<ProductItem> getAllItems() => context.productItems;

        public ProductItem? getItem (string? name) => context.productItems.FirstOrDefault(x => x.Equals(name!.ToLower()));
    }
}
