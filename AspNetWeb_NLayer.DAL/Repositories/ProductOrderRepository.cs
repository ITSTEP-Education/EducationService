using AspNetWeb_NLayer.DAL.EF;
using AspNetWeb_NLayer.DAL.Entities;
using AspNetWeb_NLayer.DAL.Interfaces;

namespace AspNetWeb_NLayer.DAL.Repositories
{
    public class ProductOrderRepository : IRepository<ProductOrder>
    {
        public ProductContext context;

        public ProductOrderRepository(ProductContext context)
        {
            this.context = context;
        }

        public IEnumerable<ProductOrder> getAllItems() => context.productOrders;

        public ProductOrder? getItem(string? guid)
        {
            if (guid == null || guid == string.Empty) throw new ArgumentNullException(nameof(guid));

            return context.productOrders.FirstOrDefault(x => x.guid.Equals(guid));
        }

        public void addProduct(ProductOrder productOrder)
        {
            context.productOrders.Add(productOrder);
            context.SaveChanges();
        }

    }
}
