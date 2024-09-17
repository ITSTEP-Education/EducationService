using AspNetWeb_NLayer.BLL.BussinesModels;

namespace AspNetWeb_Product.Models
{
    public class ClientProperty
    {
        public ClientTimeProperty cltTimeProps { get; set; } = null!;
        public ClientPayProperty cltPayProps { get; set; } = null!;
    }
}
