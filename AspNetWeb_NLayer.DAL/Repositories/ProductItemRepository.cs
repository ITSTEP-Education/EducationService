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
            if (name == null || name == string.Empty)
            {
                logger.LogError(1001, "DAL: failed getItem({@name})", name);
                throw new Exception($"empty parameter: name = {name}");
            }

            return context.productItems.FirstOrDefault(x => x.name.Equals(name.ToLower()));
        }
    }
}
