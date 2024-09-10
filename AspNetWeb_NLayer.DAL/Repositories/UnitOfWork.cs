using AspNetWeb_NLayer.DAL.EF;
using AspNetWeb_NLayer.DAL.Entities;
using AspNetWeb_NLayer.DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace AspNetWeb_NLayer.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ILogger<ProductItemRepository> logger {  get; }
        private ProductContext context;
        private ProductItemRepository productItemRepository = null!;
        private bool disposed = false;

        public UnitOfWork(ProductContext context, ILogger<ProductItemRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public IRepository<ProductItem> productItems
        {
            get { 
                if (productItemRepository == null)
                    productItemRepository = new ProductItemRepository(context, logger);
                return productItemRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
