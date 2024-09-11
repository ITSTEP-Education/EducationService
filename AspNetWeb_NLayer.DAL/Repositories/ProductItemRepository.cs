using AspNetWeb_NLayer.DAL.EF;
using AspNetWeb_NLayer.DAL.Entities;
using AspNetWeb_NLayer.DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace AspNetWeb_NLayer.DAL.Repositories
{
    public class ProductItemRepository : IRepository<ProductItem>
    {
        public ProductContext context;
        private readonly ILogger<ProductItemRepository> logger;

        public ProductItemRepository(ProductContext context, ILogger<ProductItemRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public IEnumerable<ProductItem> getAllItems() => context.productItems;

        public ProductItem? getItem(string? name)
        {
            //logger.LogError(1001, "AspNetWeb_NLayer.DAL.Repositories.\nLogWarning HttpGet GetProductItem by {name}", name);

            if (name == null || name == string.Empty) throw new ArgumentNullException(nameof(name));

            return context.productItems.FirstOrDefault(x => x.name.Equals(name.ToLower()));
        }
    }
}
