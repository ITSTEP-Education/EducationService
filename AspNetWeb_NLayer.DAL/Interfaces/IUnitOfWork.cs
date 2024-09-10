using AspNetWeb_NLayer.DAL.Entities;
using AspNetWeb_NLayer.DAL.Repositories;
using Microsoft.Extensions.Logging;

namespace AspNetWeb_NLayer.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<ProductItem> productItems {  get; }
        public ILogger<ProductItemRepository> logger { get; }

        public void Save();
    }
}
