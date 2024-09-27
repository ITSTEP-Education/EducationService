using AspNetWeb_NLayer.BLL.Interfaces;
using AspNetWeb_NLayer.DAL.Entities;
using AspNetWeb_NLayer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetWeb_NLayer.BLL.Services
{
    public class OrderService : IOrderService
    {
        public IUnitOfWork db { get; }

        public OrderService(IUnitOfWork db)
        {
            this.db = db;
        }

        public void addProductOrerGuidDate(ProductOrder productOrder)
        {
            if (productOrder == null) throw new ArgumentNullException(nameof(productOrder.name));

            productOrder.guid = Guid.NewGuid().ToString();
            productOrder.dateTime = DateTime.Now;

            db.productOrders.addProduct(productOrder);
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}
