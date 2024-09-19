using AspNetWeb_NLayer.DAL.EF;
using AspNetWeb_NLayer.DAL.Entities;
using AspNetWeb_NLayer.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace AspNetWeb_NLayer.DAL.Tests
{
    public class ProductItemRepositoryTests
    {
        public Mock<DbSet<ProductItem>> mockSetProductItem { get; private set; }
        public Mock<ProductContext> mockProductContext { get; private set; }

        public ProductItemRepositoryTests()
        {
            mockSetProductItem = new Mock<DbSet<ProductItem>>();
            mockProductContext = new Mock<ProductContext>();
        }

        [Fact(DisplayName = "2 get correct type ProductItem from SQL dbo.productitems")]
        public void GetItem_ReturnProductItem()
        {
            mockSetProductItem.Setup(c => c.FirstOrDefault(x => x.name.Equals(It.IsAny<object[]>()))).Returns(new ProductItem()
            {
                id = 1,
                name = "c++",
                description = "low-level language",
                typeEngeeniring = "back-end",
                durationMonth = 12,
                price = 2000
            });

            mockProductContext.Setup(c => c.productItems).Returns(mockSetProductItem.Object);
            var service = new ProductItemRepository(mockProductContext.Object);

            var result = service.getItem("c++");

            Assert.NotNull(result);
            //Assert.IsType<ProductItem>(result);
            //Assert.Equal(2000, result.price);
        }
    }
}
