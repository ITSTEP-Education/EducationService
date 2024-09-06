using AspNetWeb_NLayer.BLL.DTO;

namespace AspNetWeb_NLayer.BLL.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductItemDto> getAllProductsDto();

        ProductItemDto getProductDto(string? name);

        //ProductItemOrder getProductOrder(string? name);

        void Dispose();
    }
}
