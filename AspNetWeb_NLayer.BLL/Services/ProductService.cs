using AspNetWeb_NLayer.BLL.DTO;
using AspNetWeb_NLayer.BLL.Interfaces;
using AspNetWeb_NLayer.DAL.Interfaces;
using AspNetWeb_NLayer.BLL.Infrastructure;
using AutoMapper;
using AspNetWeb_NLayer.DAL.Entities;

namespace AspNetWeb_NLayer.BLL.Services
{
    public class ProductService :IProductService
    {
        IUnitOfWork db = null!;

        public ProductService(IUnitOfWork uow) 
        { 
            db = uow;
        }

        public ProductItemDto getProductDto(string? name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            var productItem = db.productItems.getItem(name);
            if (productItem == null) throw new ProductItemException("absent product in db", name);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductItem, ProductItemDto>()).CreateMapper();

            //return new ProductItemDto(productItem);
            return mapper.Map<ProductItem, ProductItemDto>(productItem);
        }
    }
}
