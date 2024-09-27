using AspNetWeb_NLayer.DAL.Entities;
using AspNetWeb_NLayer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetWeb_NLayer.BLL.Interfaces
{
    public interface IOrderService
    {
        IUnitOfWork db { get; }

        public void addProductOrerGuidDate(ProductOrder productOrder);

        void Dispose();
    }
}
