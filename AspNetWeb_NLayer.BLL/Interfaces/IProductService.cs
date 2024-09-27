using AspNetWeb_NLayer.BLL.BussinesModels;
using AspNetWeb_NLayer.BLL.DTO;
using AspNetWeb_NLayer.DAL.Entities;
using AspNetWeb_NLayer.DAL.Interfaces;

namespace AspNetWeb_NLayer.BLL.Interfaces
{
    public interface IProductService
    {
        IUnitOfWork db { get; }

        IEnumerable<ProductItemDto> getAllProductsDto();

        ProductItem getProductItem(string? name);

        ProductItemDto getProductDto(string? name);

        ProductOrderDto getProductOrderDto(string? name, ClientTimeProperty cltTimeProps, ClientPayProperty cltPayProps);

        void Dispose();
    }
}
