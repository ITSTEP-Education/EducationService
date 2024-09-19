using AspNetWeb_NLayer.DAL.EF;
using AspNetWeb_NLayer.DAL.Entities;
using AspNetWeb_NLayer.DAL.Interfaces;
using AspNetWeb_NLayer.DAL.Repositories;
using AspNetWeb_NLayer.DAL.Tests;
using AspNetWeb_NLayer.DAL.Tests.Entities;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Diagnostics.CodeAnalysis;

namespace TestDAL
{
    [Collection(name: "DatabaseFixture")]
    public class ProductItemRepositoryTestsDb : IClassFixture<DatabaseFixture>
    {
        private ProductItemRepository repository;

        public ProductItemRepositoryTestsDb(DatabaseFixture fixture)
        {
            repository = new ProductItemRepository(fixture.context);
        }

        [Fact(DisplayName = "1 get IEnumerable<ProductItem> from SQL dbo.productitems")]
        public void GetAllItems_ReturnIEnumerableProductItem()
        {
            var result = repository.getAllItems();
            Assert.IsAssignableFrom<IEnumerable<ProductItem>>(result);
        }

        [Fact(DisplayName = "2 get correct type ProductItem from SQL dbo.productitems")]
        public void GetItem_ReturnProductItem()
        {
            var result = repository.getItem("c++");
            Assert.IsType<ProductItem>(result);
        }

        [Fact(DisplayName = "3 get ArgumentNullException if argument is null")]
        public void GetItem_ArgNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => repository.getItem(null));
        }

        [Fact(DisplayName = "4 get ArgumentNullException if argument is string.Empty")]
        public void GetItem_ArgStringEmpty_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => repository.getItem(string.Empty));
        }

        [Theory(Skip = "no more need", DisplayName = "5 get correct result of price ProductItem depend from name of product")]
        [InlineData("c++", 2000)]
        [InlineData("css", 500)]
        public void GetItem_ArgName_ReturnCorrectPrice(string name, int expected)
        {
            var result = repository.getItem(name);
            Assert.StrictEqual(expected, result?.price);
        }

        [Theory (DisplayName = "6 get correct result of ProductItem depend from name of product")]
        //[MemberData(nameof(TestProductItem))]
        [ClassData(typeof(ProductItemTestData))]
        public void GetItem_ArgName_ReturnCorrectProductItem(string name, ProductItem expected)
        {
            var result = repository.getItem(name);
            Assert.Equivalent(expected, result);
        }
    }
}