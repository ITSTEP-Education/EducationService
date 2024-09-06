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
        IUnitOfWork db;

        public ProductService(IUnitOfWork uow) 
        { 
            db = uow;
        }

        public ProductItemDto getProductDto(string? name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            var productItem = db.productItems.getItem(name);
            if (productItem == null) throw new ProductItemException("absent product in db", name);

            return new ProductItemDto(productItem);
        }

        public IEnumerable<ProductItemDto> getAllProductsDto() 
        {
            var products = db.productItems.getAllItems();
            if (products is null) throw new ProductItemException("absent table", "products");

            IMapper mapper = new MapperConfiguration( c => c.CreateMap<ProductItem, ProductItemDto>()).CreateMapper();
            return mapper.Map<IEnumerable<ProductItem>, IEnumerable<ProductItemDto>>(products);
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}
