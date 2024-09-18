using AspNetWeb_NLayer.DAL.EF;
using AspNetWeb_NLayer.DAL.Entities;
using AspNetWeb_NLayer.DAL.Interfaces;
using AspNetWeb_NLayer.DAL.Repositories;
using AspNetWeb_NLayer.DAL.Tests.Entities;
using Moq;
using System.Diagnostics.CodeAnalysis;

namespace TestDAL
{
    public class ProductItemRepositoryTests
    {
        private ProductItemRepository repository;

        public ProductItemRepositoryTests()
        {
            repository = new ProductItemRepository(new ProductContext());
        }

        [Fact(DisplayName = "get IEnumerable<ProductItem> from SQL dbo.productitems")]
        public void GetAllItems_ReturnIEnumerableProductItem()
        {
            var result = repository.getAllItems();
            Assert.IsAssignableFrom<IEnumerable<ProductItem>>(result);
        }

        [Fact(DisplayName = "get correct type ProductItem from SQL dbo.productitems")]
        public void GetItem_ReturnProductItem()
        {
            var result = repository.getItem("c++");
            Assert.IsType<ProductItem>(result);
        }

        [Fact(DisplayName = "get ArgumentNullException if argument is null")]
        public void GetItem_ArgNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => repository.getItem(null));
        }

        [Fact(DisplayName = "get ArgumentNullException if argument is string.Empty")]
        public void GetItem_ArgStringEmpty_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => repository.getItem(string.Empty));
        }

        [Theory(DisplayName = "get correct result of price ProductItem depend from name of product")]
        [InlineData("c++", 2000)]
        [InlineData("css", 500)]
        public void GetItem_ArgName_ReturnCorrectPrice(string name, int expected)
        {
            var result = repository.getItem(name);
            Assert.StrictEqual(expected, result?.price);
        }

        [Theory (DisplayName = "get correct result of ProductItem depend from name of product")]
        //[MemberData(nameof(TestProductItem))]
        [ClassData(typeof(ProductItemTestData))]
        public void GetItem_ArgName_ReturnCorrectProductItem(string name, ProductItem expected)
        {
            var result = repository.getItem(name);
            Assert.Equivalent(expected, result);
        }
    }
}