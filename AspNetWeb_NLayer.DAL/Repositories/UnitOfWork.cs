using AspNetWeb_NLayer.DAL.EF;
using AspNetWeb_NLayer.DAL.Entities;
using AspNetWeb_NLayer.DAL.Interfaces;

namespace AspNetWeb_NLayer.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProductContext context;
        private ProductItemRepository productItemRepository = null!;
        private bool disposed = false;

        public UnitOfWork(ProductContext context)
        {
            this.context = context;
        }

        public IRepository<ProductItem> productItems
        {
            get { 
                if (productItemRepository == null)
                    productItemRepository = new ProductItemRepository(context);
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
