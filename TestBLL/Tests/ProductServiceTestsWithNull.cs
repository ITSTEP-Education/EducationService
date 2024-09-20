using AspNetWeb_NLayer.BLL.BussinesModels;
using AspNetWeb_NLayer.BLL.DTO;
using AspNetWeb_NLayer.BLL.Infrastructure;
using AspNetWeb_NLayer.BLL.Services;
using AspNetWeb_NLayer.DAL.Entities;
using AspNetWeb_NLayer.DAL.Interfaces;
using Moq;

namespace AspNetWeb_NLayer.BLL.Tests.Tests;

public class ProductServiceTestsWithNull
{
    public Mock<IUnitOfWork> mockUOW { get; private set; }
    public ProductService service { get; private set; } = null!;

    public ProductServiceTestsWithNull()
    {
        mockUOW = new Mock<IUnitOfWork>();
        mockSetUp();
        service = new ProductService(mockUOW.Object);
    }

    [Fact(DisplayName = "1 get ProductItem by Name and throw ProductItemException for null")]
    public void GetProductItem_ByName_ReturnException()
    {
        Assert.Throws<ProductItemException>(() => service.getProductItem("c+_"));
    }

    [Fact(DisplayName = "2 get list of ProductsDto from list ProductsItem with exception")]
    public void GetProductsDto_FromProductItem_ReturnException()
    {
        Assert.Throws<ProductItemException>(() => service.getAllProductsDto());
    }

    private void mockSetUp()
    {
        //for test2
        mockUOW.Setup(uow => uow.productItems.getAllItems()).Returns((List<ProductItem>?)null);

        //for test1
        mockUOW.Setup(uow => uow.productItems.getItem(It.IsAny<string>())).Returns((ProductItem?)null);
    }
}