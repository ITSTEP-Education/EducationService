using AspNetWeb_NLayer.DAL.Entities;

namespace AspNetWeb_NLayer.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<ProductItem> productItems {  get; }

        public void Save();
    }
}
