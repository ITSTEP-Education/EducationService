using AspNetWeb_NLayer.DAL.EF;
using AspNetWeb_NLayer.DAL.Entities;
using AspNetWeb_NLayer.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace AspNetWeb_NLayer.DAL.Tests.Tests
{
    public class ProductItemRepositoryTests : IDisposable
    {
        public ProductContext context { get; private set; }
        public ProductItemRepository repository { get; private set; }
        private bool isContextFilled;
        private bool disposed = false;

        public ProductItemRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ProductContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options;
            context = new ProductContext(options);
            repository = new ProductItemRepository(context);
        }

        [Fact(DisplayName = "2 get correct type ProductItem from SQL dbo.productitems")]
        public void GetItemByName_Return_CorrectProductItem()
        {
            fillContext();
            var result = repository.getItem("c++");

            Assert.NotNull(result);
            Assert.Equal(2000, result.price);
        }

        private void fillContext()
        {
            if (isContextFilled) return;

            context.productItems.AddRange(
                new ProductItem() { id = 1, name = "c++", description = "low-level language", typeEngeeniring = "back-end", durationMonth = 12, price = 2000 },
                new ProductItem() { id = 7, name = "css", description = "none", typeEngeeniring = "front-end", durationMonth = 4, price = 500 }
                );
            context.SaveChanges();

            isContextFilled = true;
        }

        protected virtual void Dispose(bool disposing)
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
