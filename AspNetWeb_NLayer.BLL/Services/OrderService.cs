using AspNetWeb_NLayer.BLL.Interfaces;
using AspNetWeb_NLayer.DAL.Entities;
using AspNetWeb_NLayer.DAL.Interfaces;

namespace AspNetWeb_NLayer.BLL.Services
{
    public class OrderService : IOrderService
    {
        public IUnitOfWork db { get; }

        public OrderService(IUnitOfWork db)
        {
            this.db = db;
        }

        public void addProductOrderGuidDate(ProductOrder productOrder)
        {
            if (productOrder == null) throw new ArgumentNullException(nameof(productOrder.name));

            productOrder.guid = Guid.NewGuid().ToString();

            bool flag = DateTime.TryParse(DateTime.Now.ToString("g"), out DateTime result);
            if (!flag) throw new Exception("DateTime is null");

            productOrder.dateTime = result;

            db.productOrders.addProduct(productOrder);
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}
