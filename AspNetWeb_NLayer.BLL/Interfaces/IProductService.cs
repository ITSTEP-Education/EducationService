using AspNetWeb_NLayer.BLL.BussinesModels;
using AspNetWeb_NLayer.BLL.DTO;
using AspNetWeb_NLayer.DAL.Entities;
using AspNetWeb_NLayer.DAL.Interfaces;

namespace AspNetWeb_NLayer.BLL.Interfaces
{
    public interface IProductService
    {
        IUnitOfWork db { get; }

        ProductItem getProductItem(string? name);

        IEnumerable<ProductItemDto> getAllProductsDto();

        ProductItemDto getProductDto(string? name);

        ProductItemOrder getProductOrder(string? name, ClientTimeProperty cltTimeProps, ClientPayProperty cltPayProps);

        void Dispose();
    }
}
