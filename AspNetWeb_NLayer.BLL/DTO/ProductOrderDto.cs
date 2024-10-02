
namespace AspNetWeb_NLayer.BLL.DTO
{
    ///// <include file='../DocXML/BLLDocumentation.xml' path='docs/members[@name="models"]/ProductItemOrder/*'/>
    public class ProductOrderDto
    {
        public string name { get; set; } = null!;
        public string typeEngeeniring { get; set; } = null!;
        public int timeStudy { get; set; }
        public float sumPay { get; set; }

    }
}
