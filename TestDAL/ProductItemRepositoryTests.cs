using AspNetWeb_NLayer.DAL.EF;
using AspNetWeb_NLayer.DAL.Entities;
using AspNetWeb_NLayer.DAL.Interfaces;
using AspNetWeb_NLayer.DAL.Repositories;
using Moq;

namespace TestDAL
{
    public class ProductItemRepositoryTests
    {
        private ProductItemRepository repository;

        public ProductItemRepositoryTests()
        {
            repository = new ProductItemRepository(new ProductContext());
        }

        //get IEnumerable<ProductItem> from SQL dbo.productitems
        [Fact]
        public void GetAllItemsReturnIsType()
        {
            var result = repository.getAllItems();
            Assert.IsAssignableFrom<IEnumerable<ProductItem>>(result);
        }

        //get correct type ProductItem from SQL dbo.productitems
        [Fact]
        public void GetItemIsType()
        {
            var result = repository.getItem("c++");
            Assert.IsType<ProductItem>(result);
        }

        //get ArgumentNullException if argument is null
        [Fact]
        public void GetItemArgNull()
        {
            Assert.Throws<ArgumentNullException>(() => repository.getItem(null));
        }

        //get ArgumentNullException if argument is string.Empty
        [Fact]
        public void GetItemArgStringEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => repository.getItem(string.Empty));
        }

        //get correct result of ProductItem depend from name of product
        [Theory]
        [InlineData("c++", 2000)]
        [InlineData("css", 500)]
        public void GetItemCorrectResult(string name, int expected)
        {
            var result = repository.getItem(name);
            Assert.StrictEqual(expected, result?.price);
        }
    }
}