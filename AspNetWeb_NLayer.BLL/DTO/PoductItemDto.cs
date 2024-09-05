using AspNetWeb_NLayer.DAL.Entities;

namespace AspNetWeb_NLayer.BLL.DTO
{
    public class PoductItemDto
    {
        public int id {  get; set; }
        public string name { get; set; } = null!;
        public string typeEngeeniring { get; set; } = null!;

        public PoductItemDto() { }

        public PoductItemDto(ProductItem productItem)
        {
            this.id = productItem.id;
            this.name = productItem.name;
            this.typeEngeeniring = productItem.typeEngeeniring;
        }
    }
}
