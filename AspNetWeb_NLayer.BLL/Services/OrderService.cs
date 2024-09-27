using AspNetWeb_NLayer.BLL.Infrastructure;
using AspNetWeb_NLayer.BLL.Interfaces;
using AspNetWeb_NLayer.DAL.Entities;
using AspNetWeb_NLayer.DAL.Interfaces;
using System.Xml;

namespace AspNetWeb_NLayer.BLL.Services
{
    public class OrderService : IOrderService
    {
        public IUnitOfWork db { get; }

        public OrderService(IUnitOfWork db)
        {
            this.db = db;
        }

        public IEnumerable<ProductOrder> getAllOrders()
        {
            var orders = db.productOrders.getAllItems();
            if (orders == null) throw new ProductItemException("absent in db any records", "productorders");

            return orders;
        }

        public ProductOrder getOrder(string guid)
        {
            var productOrder = db.productOrders.getItem(guid);
            if (productOrder == null) throw new ProductItemException("absent productorder in db", guid??"none");

            return productOrder;
        }

        public void addProductOrderGuidDate(ProductOrder productOrder)
        {
            if (productOrder == null) throw new ArgumentNullException(nameof(productOrder.name));

            productOrder.timeStudy = Math.Abs(productOrder.timeStudy);
            productOrder.sumPay = Math.Abs(productOrder.sumPay);

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
