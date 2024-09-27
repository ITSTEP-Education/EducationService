using AspNetWeb_NLayer.DAL.Filter;


namespace AspNetWeb_NLayer.DAL.Entities
{
    public class ProductOrder
    {
        [SwaggerIgnore]
        public int id {  get; set; }
        public string name { get; set; } = null!;
        public string typeEngeeniring { get; set; } = null!;
        public int timeStudy { get; set; }
        public float sumPay { get; set; }
        [SwaggerIgnore]
        public string guid { get; set; } = "";
        [SwaggerIgnore]
        public DateTime dateTime { get; set; }

    }
}
