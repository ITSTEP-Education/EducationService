using AspNetWeb_NLayer.BLL.BussinesModels;
using AspNetWeb_NLayer.BLL.DTO;
using AspNetWeb_NLayer.BLL.Infrastructure;
using AspNetWeb_NLayer.BLL.Services;
using AspNetWeb_NLayer.DAL.Entities;
using AspNetWeb_NLayer.DAL.Interfaces;
using Moq;

namespace AspNetWeb_NLayer.BLL.Tests;

public class ProductServiceTests
{
    public Mock<IUnitOfWork> mockUOW;

    public ProductServiceTests()
    {
        mockUOW = new Mock<IUnitOfWork>();
    }

    [Fact(DisplayName = "1 get ProductItem by Name and return correct price")]
    public void GetProductItem_ByName_ReturnCorrectPrice()
    {
        mockUOW.Setup(uow => uow.productItems.getItem("c++")).Returns(new ProductItem()
        { id = 1, name = "c++", description = "low-level language", typeEngeeniring = "back-end", durationMonth = 12, price = 2000 });
        var service = new ProductService(mockUOW.Object);

        var result = service.getProductItem("c++");

        Assert.Equal(2000, result.price);
    }

    [Fact(DisplayName = "2 get ProductItem by Name and throw ProductItemException for null")]
    public void GetProductItem_ByName_ReturnException()
    {
        mockUOW.Setup(uow => uow.productItems.getItem(It.IsAny<string>())).Returns((ProductItem?)null);
        var service = new ProductService(mockUOW.Object);

        Assert.Throws<ProductItemException>(() => service.getProductItem("c+_"));
    }

    [Fact(DisplayName = "3 get list of ProductsDto from list ProductsItem with correct result")]
    public void GetProductsDto_FromProductItem_UseMap_ReturnCorrectResult()
    {
        mockUOW.Setup(uow => uow.productItems.getAllItems()).Returns(new List<ProductItem>(){
            new ProductItem() { id = 1, name = "c++", description = "low-level language", typeEngeeniring = "back-end", durationMonth = 12, price = 2000 },
            new ProductItem() { id = 7, name = "css", description = "none", typeEngeeniring = "front-end", durationMonth = 4, price = 500 }
        });
        var service = new ProductService(mockUOW.Object);

        var result = service.getAllProductsDto();

        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.IsType<ProductItemDto>(result.ElementAt(0));
    }

    [Fact(DisplayName = "4 get list of ProductsDto from list ProductsItem with exception")]
    public void GetProductsDto_FromProductItem_ReturnException()
    {
        mockUOW.Setup(uow => uow.productItems.getAllItems()).Returns((List<ProductItem>?)null);
        var service = new ProductService(mockUOW.Object);

        Assert.Throws<ProductItemException>(() => service.getAllProductsDto());
    }

    [Theory(DisplayName = "5 get ProductOrder from ProductItem after aplied BLL EducationTime and EducationPayment")]
    [MemberData(nameof(GetProductOrderData))]
    public void GetProductOrder_WithBussinesModels_ReturnCorrectResult(string name, ProductItem productItem, ClientTimeProperty cltTimeProps,
        ClientPayProperty cltPayProps, ProductItemOrder expected)
    {
        mockUOW.Setup(uow => uow.productItems.getItem(name)).Returns(productItem);
        var service = new ProductService(mockUOW.Object);

        var result = service.getProductOrder(name, cltTimeProps, cltPayProps);

        Assert.Equivalent(expected, result);
    }

    public static IEnumerable<object[]> GetProductOrderData()
    {
        yield return new object[] { 
            "css", 
            new ProductItem() { id = 7, name = "css", description = "none", typeEngeeniring = "front-end", durationMonth = 4, price = 1200 }, 
            new ClientTimeProperty(){ EducationForm = "holiday", EngineerType = "front-end"},
            new ClientPayProperty(){ IsInvitedPerson = true, PayMethod = "credit", PayPeriod = "monthly"},
            new ProductItemOrder(){ name = "css", typeEngeeniring = "front-end", timeStudy = 6, sumPay = 700 }
        };
    }
}