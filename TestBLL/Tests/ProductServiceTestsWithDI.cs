using AspNetWeb_NLayer.BLL.BussinesModels;
using AspNetWeb_NLayer.BLL.DTO;
using AspNetWeb_NLayer.BLL.Infrastructure;
using AspNetWeb_NLayer.BLL.Interfaces;
using AspNetWeb_NLayer.BLL.Services;
using AspNetWeb_NLayer.BLL.Tests.Fixtures;
using AspNetWeb_NLayer.DAL.Entities;
using AspNetWeb_NLayer.DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace AspNetWeb_NLayer.BLL.Tests.Tests
{
    public class ProductServiceTestsWithDI : IClassFixture<DependencyInjectionFixture>
    {
        private readonly IProductService productService;
        private readonly Mock<IUnitOfWork> mockUOW;

        public ProductServiceTestsWithDI()
        {
            mockUOW = new Mock<IUnitOfWork>();

            mockSetUp();

            var service = new ServiceCollection();

            service.AddScoped(_ => mockUOW.Object);
            service.AddScoped<IProductService, ProductService>();

            var serviceProvider = service.BuildServiceProvider();
            productService = serviceProvider.GetRequiredService<IProductService>();
        }

        [Fact(DisplayName = "3 get ProductItem by Name and return correct price")]
        public void GetProductItem_ByName_ReturnCorrectPrice()
        {
            var result = productService.getProductItem("c++");

            Assert.Equal(2000, result.price);
        }

        [Fact(DisplayName = "4 get list of ProductsDto from list ProductsItem with correct result")]
        public void GetProductsDto_FromProductItem_UseMap_ReturnCorrectResult()
        {
            var result = productService.getAllProductsDto();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.IsType<ProductItemDto>(result.ElementAt(0));
        }

        [Theory(DisplayName = "5 get ProductOrder from ProductItem after aplied BLL EducationTime and EducationPayment")]
        [MemberData(nameof(GetProductOrderData))]
        public void GetProductOrder_WithBussinesModels_ReturnCorrectResult(string name,
            ClientTimeProperty cltTimeProps, ClientPayProperty cltPayProps, ProductItemOrder expected)
        {
            var result = productService.getProductOrder(name, cltTimeProps, cltPayProps);

            Assert.Equivalent(expected, result);
        }

        public static IEnumerable<object[]> GetProductOrderData()
        {
            yield return new object[] {
            "css",
            new ClientTimeProperty(){ EducationForm = "holiday", EngineerType = "front-end"},
            new ClientPayProperty(){ IsInvitedPerson = true, PayMethod = "credit", PayPeriod = "monthly"},
            new ProductItemOrder(){ name = "css", typeEngeeniring = "front-end", timeStudy = 6, sumPay = 700 }
            };
        }

        private void mockSetUp()
        {
            //for test5
            mockUOW.Setup(uow => uow.productItems.getItem("css")).Returns(new ProductItem() { id = 7, name = "css", description = "none", typeEngeeniring = "front-end", durationMonth = 4, price = 1200 });

            //for test4
            mockUOW.Setup(uow => uow.productItems.getAllItems()).Returns(new List<ProductItem>(){
                    new ProductItem() { id = 1, name = "c++", description = "low-level language", typeEngeeniring = "back-end", durationMonth = 12, price = 2000 },
                    new ProductItem() { id = 7, name = "css", description = "none", typeEngeeniring = "front-end", durationMonth = 4, price = 500 }
            });

            //for test3
            mockUOW.Setup(uow => uow.productItems.getItem("c++")).Returns(new ProductItem()
            { id = 1, name = "c++", description = "low-level language", typeEngeeniring = "back-end", durationMonth = 12, price = 2000 });

        }
    }
}
