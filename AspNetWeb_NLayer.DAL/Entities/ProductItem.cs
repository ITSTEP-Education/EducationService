
namespace AspNetWeb_NLayer.DAL.Entities
{
    public class ProductItem
    {
        public int id {  get; set; }
        public string name { get; set; } = null!;
        public string description { get; set; } = null!;

        public ProductItem(string name, string description)
        {
            this.name = name.ToLower();
            this.description = description.ToLower();
        }
    }
}
