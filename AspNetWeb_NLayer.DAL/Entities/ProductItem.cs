
namespace AspNetWeb_NLayer.DAL.Entities
{
    public class ProductItem
    {
        public int id {  get; set; }
        public string name { get; set; } = null!;
        public string description { get; set; } = null!;
        public string typeEngeeniring { get; set; } = null!;
        public int durationMonth { get; set; }
        public float price { get; set; }

        public ProductItem() { }
        public ProductItem(string name, string description, string typeEngeeniring)
        {
            this.name = name.ToLower();
            this.description = description.ToLower();
            this.typeEngeeniring = typeEngeeniring.ToLower();
        }
    }
}
